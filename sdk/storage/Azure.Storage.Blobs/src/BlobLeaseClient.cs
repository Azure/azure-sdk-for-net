// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using static Azure.Storage.Blobs.BlobExtensions;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// The <see cref="BlobLeaseClient"/> allows you to manipulate Azure
    /// Storage leases on containers and blobs.
    /// </summary>
    public class BlobLeaseClient
    {
        /// <summary>
        /// The <see cref="BlobClient"/> to manage leases for.
        /// </summary>
        private readonly BlobBaseClient _blob;

        /// <summary>
        /// Gets the <see cref="BlobClient"/> to manage leases for.
        /// </summary>
        protected virtual BlobBaseClient BlobClient => _blob;

        /// <summary>
        /// The <see cref="BlobContainerClient"/> to manage leases for.
        /// </summary>
        private readonly BlobContainerClient _container;

        /// <summary>
        /// Gets the <see cref="BlobContainerClient"/> to manage leases for.
        /// </summary>
        protected virtual BlobContainerClient BlobContainerClient => _container;

        /// <summary>
        /// Gets the URI of the object being leased.
        /// </summary>
        public Uri Uri => BlobClient?.Uri ?? BlobContainerClient?.Uri;

        private string _leaseId;
        /// <summary>
        /// Gets the Lease ID for this lease.
        /// </summary>
        public virtual string LeaseId
        {
            get => Volatile.Read(ref _leaseId);
            private set => Volatile.Write(ref _leaseId, value);
        }

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        private HttpPipeline Pipeline => BlobClient?.ClientConfiguration.Pipeline ?? BlobContainerClient.ClientConfiguration.Pipeline;

        /// <summary>
        /// The version of the service to use when sending requests.
        /// </summary>
        internal virtual BlobClientOptions.ServiceVersion Version => BlobClient?.ClientConfiguration.Version ?? BlobContainerClient.ClientConfiguration.Version;

        /// <summary>
        /// The <see cref="ClientDiagnostics"/> instance used to create diagnostic scopes
        /// every request.
        /// </summary>
        internal virtual ClientDiagnostics ClientDiagnostics => BlobClient?.ClientConfiguration.ClientDiagnostics ?? BlobContainerClient.ClientConfiguration.ClientDiagnostics;

        /// <summary>
        /// The <see cref="TimeSpan"/> representing an infinite lease duration.
        /// </summary>
        public static readonly TimeSpan InfiniteLeaseDuration = TimeSpan.FromSeconds(Constants.Blob.Lease.InfiniteLeaseDuration);

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobLeaseClient"/> class
        /// for mocking.
        /// </summary>
        protected BlobLeaseClient()
        {
            _blob = null;
            _container = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobLeaseClient"/>  class.
        /// </summary>
        /// <param name="client">
        /// A <see cref="BlobClient"/> representing the blob being leased.
        /// </param>
        /// <param name="leaseId">
        /// An optional lease ID.  If no lease ID is provided, a random lease
        /// ID will be created.
        /// </param>
        public BlobLeaseClient(BlobBaseClient client, string leaseId = null)
        {
            _blob = client ?? throw Errors.ArgumentNull(nameof(client));
            _container = null;
            LeaseId = leaseId ?? CreateUniqueLeaseId();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobLeaseClient"/>  class.
        /// </summary>
        /// <param name="client">
        /// A <see cref="BlobContainerClient"/> representing the blob container
        /// being leased.
        /// </param>
        /// <param name="leaseId">
        /// An optional lease ID.  If no lease ID is provided, a random lease
        /// ID will be created.
        /// </param>
        public BlobLeaseClient(BlobContainerClient client, string leaseId = null)
        {
            _blob = null;
            _container = client ?? throw Errors.ArgumentNull(nameof(client));
            LeaseId = leaseId ?? CreateUniqueLeaseId();
        }

        /// <summary>
        /// Gets a unique lease ID.
        /// </summary>
        /// <returns>A unique lease ID.</returns>
        private static string CreateUniqueLeaseId() => Guid.NewGuid().ToString();

        /// <summary>
        /// Ensure either the Blob or Container is present.
        /// </summary>
        private void EnsureClient()
        {
            if (BlobClient == null && BlobContainerClient == null)
            {
                // This can only happen if someone's not being careful while mocking
                throw BlobErrors.BlobOrContainerMissing(nameof(BlobLeaseClient), nameof(BlobBaseClient), nameof(BlobContainerClient));
            }
        }

        #region Acquire
        /// <summary>
        /// The <see cref="Acquire(TimeSpan, RequestConditions, CancellationToken)"/>
        /// operation acquires a lease on the blob or container. The lease
        /// <paramref name="duration"/> must be between 15 to 60 seconds, or
        /// infinite (-1).
        ///
        /// If the container does not have an active lease, the Blob service
        /// creates a lease on the blob or container and returns it.  If the
        /// container has an active lease, you can only request a new lease
        /// using the active lease ID as <see cref="LeaseId"/>, but you can
        /// specify a new <paramref name="duration"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="duration">
        /// Specifies the duration of the lease, in seconds, or specify
        /// <see cref="InfiniteLeaseDuration"/> for a lease that never expires.
        /// A non-infinite lease can be between 15 and 60 seconds.
        /// A lease duration cannot be changed using <see cref="RenewAsync(BlobLeaseRenewOptions, CancellationToken)"/>
        /// or <see cref="ChangeAsync(string, BlobLeaseChangeOptions, CancellationToken)"/>.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<BlobLease> Acquire(
            TimeSpan duration,
            BlobLeaseAcquireOptions options,
            CancellationToken cancellationToken = default) =>
            ParseAcquireResponse(AcquireInternal(
                duration,
                options?.Conditions,
                requestPriority: options?.RequestPriority,
                async: false,
                new RequestContext() { CancellationToken = cancellationToken })
                .EnsureCompleted());

        /// <summary>
        /// The <see cref="Acquire(TimeSpan, RequestConditions, CancellationToken)"/>
        /// operation acquires a lease on the blob or container. The lease
        /// <paramref name="duration"/> must be between 15 to 60 seconds, or
        /// infinite (-1).
        ///
        /// If the container does not have an active lease, the Blob service
        /// creates a lease on the blob or container and returns it.  If the
        /// container has an active lease, you can only request a new lease
        /// using the active lease ID as <see cref="LeaseId"/>, but you can
        /// specify a new <paramref name="duration"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="duration">
        /// Specifies the duration of the lease, in seconds, or specify
        /// <see cref="InfiniteLeaseDuration"/> for a lease that never expires.
        /// A non-infinite lease can be between 15 and 60 seconds.
        /// A lease duration cannot be changed using <see cref="RenewAsync(BlobLeaseRenewOptions, CancellationToken)"/>
        /// or <see cref="ChangeAsync(string, BlobLeaseChangeOptions, CancellationToken)"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobLeaseRequestConditions"/> to add
        /// conditions on acquiring a lease.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BlobLease> Acquire(
            TimeSpan duration,
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            ParseAcquireResponse(AcquireInternal(
                duration,
                conditions,
                requestPriority: default,
                async: false,
                new RequestContext() { CancellationToken = cancellationToken })
                .EnsureCompleted());

        /// <summary>
        /// The <see cref="AcquireAsync(TimeSpan, RequestConditions, CancellationToken)"/>
        /// operation acquires a lease on the blob or container. The lease
        /// <paramref name="duration"/> must be between 15 to 60 seconds, or
        /// infinite (-1).
        ///
        /// If the container does not have an active lease, the Blob service
        /// creates a lease on the blob or container and returns it.  If the
        /// container has an active lease, you can only request a new lease
        /// using the active lease ID as <see cref="LeaseId"/>, but you can
        /// specify a new <paramref name="duration"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="duration">
        /// Specifies the duration of the lease, in seconds, or specify
        /// <see cref="InfiniteLeaseDuration"/> for a lease that never expires.
        /// A non-infinite lease can be between 15 and 60 seconds.
        /// A lease duration cannot be changed using <see cref="RenewAsync(BlobLeaseRenewOptions, CancellationToken)"/>
        /// or <see cref="ChangeAsync(string, BlobLeaseChangeOptions, CancellationToken)"/>.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<BlobLease>> AcquireAsync(
            TimeSpan duration,
            BlobLeaseAcquireOptions options,
            CancellationToken cancellationToken = default) =>
            ParseAcquireResponse(await AcquireInternal(
                duration,
                options?.Conditions,
                requestPriority: options?.RequestPriority,
                async: true,
                new RequestContext() { CancellationToken = cancellationToken })
                .ConfigureAwait(false));

        /// <summary>
        /// The <see cref="AcquireAsync(TimeSpan, RequestConditions, CancellationToken)"/>
        /// operation acquires a lease on the blob or container. The lease
        /// <paramref name="duration"/> must be between 15 to 60 seconds, or
        /// infinite (-1).
        ///
        /// If the container does not have an active lease, the Blob service
        /// creates a lease on the blob or container and returns it.  If the
        /// container has an active lease, you can only request a new lease
        /// using the active lease ID as <see cref="LeaseId"/>, but you can
        /// specify a new <paramref name="duration"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="duration">
        /// Specifies the duration of the lease, in seconds, or specify
        /// <see cref="InfiniteLeaseDuration"/> for a lease that never expires.
        /// A non-infinite lease can be between 15 and 60 seconds.
        /// A lease duration cannot be changed using <see cref="RenewAsync(BlobLeaseRenewOptions, CancellationToken)"/>
        /// or <see cref="ChangeAsync(string, BlobLeaseChangeOptions, CancellationToken)"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobLeaseRequestConditions"/> to add
        /// conditions on acquiring a lease.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BlobLease>> AcquireAsync(
            TimeSpan duration,
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            ParseAcquireResponse(await AcquireInternal(
                duration,
                conditions,
                requestPriority: default,
                async: true,
                new RequestContext() { CancellationToken = cancellationToken })
                .ConfigureAwait(false));

        private Response<BlobLease> ParseAcquireResponse(Response response)
        {
            if (BlobClient != null)
            {
                return Response.FromValue(response.ToBlobLease(BlobLeaseHeaderType.BlobAcquire),
                    response);
            }
            else
            {
                return Response.FromValue(
                    response.ToBlobLease(BlobLeaseHeaderType.ContainerAcquire),
                    response);
            }
        }

        /// <summary>
        /// The <see cref="Acquire(TimeSpan, RequestConditions, RequestContext)"/>
        /// operation acquires a lease on the blob or container. The lease
        /// <paramref name="duration"/> must be between 15 to 60 seconds, or
        /// infinite (-1).
        ///
        /// If the container does not have an active lease, the Blob service
        /// creates a lease on the blob or container and returns it.  If the
        /// container has an active lease, you can only request a new lease
        /// using the active lease ID as <see cref="LeaseId"/>, but you can
        /// specify a new <paramref name="duration"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="duration">
        /// Specifies the duration of the lease, in seconds, or specify
        /// <see cref="InfiniteLeaseDuration"/> for a lease that never expires.
        /// A non-infinite lease can be between 15 and 60 seconds.
        /// A lease duration cannot be changed using <see cref="RenewAsync(BlobLeaseRenewOptions, CancellationToken)"/>
        /// or <see cref="ChangeAsync(string, BlobLeaseChangeOptions, CancellationToken)"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobLeaseRequestConditions"/> to add
        /// conditions on acquiring a lease.
        /// </param>
        /// <param name="context">
        /// Optional <see cref="RequestContext"/> for the operation.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> as returned by the Storage service.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response Acquire(
            TimeSpan duration,
            RequestConditions conditions,
            RequestContext context) =>
            AcquireInternal(
                duration,
                conditions,
                requestPriority: default,
                async: false,
                context)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="AcquireAsync(TimeSpan, RequestConditions, RequestContext)"/>
        /// operation acquires a lease on the blob or container. The lease
        /// <paramref name="duration"/> must be between 15 to 60 seconds, or
        /// infinite (-1).
        ///
        /// If the container does not have an active lease, the Blob service
        /// creates a lease on the blob or container and returns it.  If the
        /// container has an active lease, you can only request a new lease
        /// using the active lease ID as <see cref="LeaseId"/>, but you can
        /// specify a new <paramref name="duration"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="duration">
        /// Specifies the duration of the lease, in seconds, or specify
        /// <see cref="InfiniteLeaseDuration"/> for a lease that never expires.
        /// A non-infinite lease can be between 15 and 60 seconds.
        /// A lease duration cannot be changed using <see cref="RenewAsync(BlobLeaseRenewOptions, CancellationToken)"/>
        /// or <see cref="ChangeAsync(string, BlobLeaseChangeOptions, CancellationToken)"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobLeaseRequestConditions"/> to add
        /// conditions on acquiring a lease.
        /// </param>
        /// <param name="context">
        /// Optional <see cref="RequestContext"/> for the operation.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> as returned by the Storage service.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response> AcquireAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            TimeSpan duration,
            RequestConditions conditions,
            RequestContext context) =>
            (await AcquireInternal(
                duration,
                conditions,
                requestPriority: default,
                async: true,
                context)
                .ConfigureAwait(false));

        /// <summary>
        /// The <see cref="AcquireInternal"/> operation acquires a lease on
        /// the blob or container.  The lease <paramref name="duration"/> must
        /// be between 15 to 60 seconds, or infinite (-1).
        ///
        /// If the container does not have an active lease, the Blob service
        /// creates a lease on the blob or container and returns it.  If the
        /// container has an active lease, you can only request a new lease
        /// using the active lease ID as <see cref="LeaseId"/>, but you can
        /// specify a new <paramref name="duration"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="duration">
        /// Specifies the duration of the lease, in seconds, or specify
        /// <see cref="InfiniteLeaseDuration"/> for a lease that never expires.
        /// A non-infinite lease can be between 15 and 60 seconds.
        /// A lease duration cannot be changed using <see cref="RenewAsync(BlobLeaseRenewOptions, CancellationToken)"/>
        /// or <see cref="ChangeAsync(string, BlobLeaseChangeOptions, CancellationToken)"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobLeaseRequestConditions"/> to add
        /// conditions on acquiring a lease.
        /// </param>
        /// <param name="requestPriority">
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="context">
        /// Optional <see cref="RequestContext"/> for this operation.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response> AcquireInternal(
            TimeSpan duration,
            RequestConditions conditions,
            int? requestPriority,
            bool async,
            RequestContext context)
        {
            EnsureClient();
            // generated code needs nonnull values
            conditions ??= new RequestConditions();
            context ??= new RequestContext();
            // Int64 is an overflow safe cast relative to TimeSpan.MaxValue
            var serviceDuration = duration < TimeSpan.Zero ? Constants.Blob.Lease.InfiniteLeaseDuration : Convert.ToInt64(duration.TotalSeconds);
            using (Pipeline.BeginLoggingScope(nameof(BlobLeaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobLeaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(LeaseId)}: {LeaseId}\n" +
                    $"{nameof(duration)}: {duration}");

                DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(BlobLeaseClient)}.{nameof(Acquire)}");

                try
                {
                    scope.Start();
                    string tagCondition = null;
                    if (conditions is BlobLeaseRequestConditions leaseConditions)
                    {
                        tagCondition = leaseConditions?.TagConditions;
                    }

                    Response response;
                    if (BlobClient != null)
                    {
                        if (async)
                        {
                            response = await BlobClient.BlobRestClient.AcquireLeaseAsync(
                                duration: serviceDuration,
                                requestPriority: requestPriority,
                                timeout: default,
                                proposedLeaseId: LeaseId,
                                requestConditions: conditions,
                                ifTags: tagCondition,
                                context: context)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            response = BlobClient.BlobRestClient.AcquireLease(
                                duration: serviceDuration,
                                requestPriority: requestPriority,
                                timeout: default,
                                proposedLeaseId: LeaseId,
                                requestConditions: conditions,
                                ifTags: tagCondition,
                                context: context);
                        }
                    }
                    else
                    {
                        conditions.ValidateConditionsNotPresent(
                            invalidConditions:
                                BlobRequestConditionProperty.IfMatch
                                | BlobRequestConditionProperty.IfNoneMatch,
                            operationName: nameof(BlobLeaseClient.Acquire),
                            parameterName: nameof(conditions));

                        if (async)
                        {
                            response = await BlobContainerClient.ContainerRestClient.AcquireLeaseAsync(
                                duration: serviceDuration,
                                requestPriority: requestPriority,
                                timeout: default,
                                proposedLeaseId: LeaseId,
                                requestConditions: conditions,
                                context: context)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            response = BlobContainerClient.ContainerRestClient.AcquireLease(
                                duration: serviceDuration,
                                requestPriority: requestPriority,
                                timeout: default,
                                proposedLeaseId: LeaseId,
                                requestConditions: conditions,
                                context: context);
                        }
                    }

                    if (response.Headers.TryGetValue(Constants.HeaderNames.LeaseId, out string value))
                    {
                        LeaseId = value;
                    }
                    return response;
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(BlobLeaseClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Acquire

        #region Renew
        /// <summary>
        /// The <see cref="Renew(BlobLeaseRenewOptions, CancellationToken)"/> operation renews the blob or
        /// container's previously-acquired lease.
        ///
        /// The lease can be renewed if the leaseId
        /// matches that associated with the blob or container.  Note that the
        /// lease may be renewed even if it has expired as long as the blob or
        /// container has not been leased again since the expiration of that
        /// lease.  When you renew a lease, the lease duration clock resets.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<BlobLease> Renew(
            BlobLeaseRenewOptions options,
            CancellationToken cancellationToken = default) =>
            RenewInternal(
                options?.Conditions,
                options?.RequestPriority,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="Renew(BlobLeaseRenewOptions, CancellationToken)"/> operation renews the blob or
        /// container's previously-acquired lease.
        ///
        /// The lease can be renewed if the leaseId
        /// matches that associated with the blob or container.  Note that the
        /// lease may be renewed even if it has expired as long as the blob or
        /// container has not been leased again since the expiration of that
        /// lease.  When you renew a lease, the lease duration clock resets.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobLeaseRequestConditions"/> to add
        /// conditions on renewing a lease.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BlobLease> Renew(
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            RenewInternal(
                conditions,
                default,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="RenewAsync(BlobLeaseRenewOptions, CancellationToken)"/> operation renews the blob or
        /// container's previously-acquired lease.
        ///
        /// The lease can be renewed if the leaseId
        /// matches that associated with the blob or container.  Note that the]
        /// lease may be renewed even if it has expired as long as the blob or
        /// container has not been leased again since the expiration of that
        /// lease.  When you renew a lease, the lease duration clock resets.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<BlobLease>> RenewAsync(
            BlobLeaseRenewOptions options,
            CancellationToken cancellationToken = default) =>
            await RenewInternal(
                options?.Conditions,
                options?.RequestPriority,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="RenewAsync(BlobLeaseRenewOptions, CancellationToken)"/> operation renews the blob or
        /// container's previously-acquired lease.
        ///
        /// The lease can be renewed if the leaseId
        /// matches that associated with the blob or container.  Note that the]
        /// lease may be renewed even if it has expired as long as the blob or
        /// container has not been leased again since the expiration of that
        /// lease.  When you renew a lease, the lease duration clock resets.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobLeaseRequestConditions"/> to add
        /// conditions on renewing a lease.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BlobLease>> RenewAsync(
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await RenewInternal(
                conditions,
                default,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="RenewInternal"/> operation renews the blob or
        /// container's previously-acquired lease.
        ///
        /// The lease can be renewed if the leaseId
        /// matches that associated with the blob or container.  Note that the]
        /// lease may be renewed even if it has expired as long as the blob or
        /// container has not been leased again since the expiration of that
        /// lease.  When you renew a lease, the lease duration clock resets.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobLeaseRequestConditions"/> to add
        /// conditions on renewing a lease.
        /// </param>
        /// <param name="requestPriority">
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<BlobLease>> RenewInternal(
            RequestConditions conditions,
            int? requestPriority,
            bool async,
            CancellationToken cancellationToken)
        {
            using (Pipeline.BeginLoggingScope(nameof(BlobLeaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobLeaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(LeaseId)}: {LeaseId}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(BlobLeaseClient)}.{nameof(Renew)}");

                try
                {
                    scope.Start();
                    string tagConditions = null;
                    if (conditions != null && conditions.GetType() == typeof(BlobLeaseRequestConditions))
                    {
                        tagConditions = ((BlobLeaseRequestConditions)conditions).TagConditions;
                    }

                    Response<BlobLease> response;
                    if (BlobClient != null)
                    {
                        Response blobClientResponse;
                        Argument.AssertNotNull(LeaseId, nameof(LeaseId));

                        if (async)
                        {
                            blobClientResponse = await BlobClient.BlobRestClient.RenewLeaseAsync(
                                leaseId: LeaseId,
                                requestPriority: requestPriority,
                                requestConditions: conditions,
                                ifTags: tagConditions,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            blobClientResponse = BlobClient.BlobRestClient.RenewLease(
                                leaseId: LeaseId,
                                requestPriority: requestPriority,
                                requestConditions: conditions,
                                ifTags: tagConditions,
                                cancellationToken: cancellationToken);
                        }

                        response = Response.FromValue(
                            blobClientResponse.ToBlobLease(BlobLeaseHeaderType.BlobRenew),
                            blobClientResponse);
                    }
                    else
                    {
                        conditions.ValidateConditionsNotPresent(
                            invalidConditions:
                                BlobRequestConditionProperty.IfMatch
                                | BlobRequestConditionProperty.IfNoneMatch,
                            operationName: nameof(BlobLeaseClient.Release),
                            parameterName: nameof(conditions));

                        Response containerClientResponse;
                        Argument.AssertNotNull(LeaseId, nameof(LeaseId));

                        if (async)
                        {
                            containerClientResponse = await BlobContainerClient.ContainerRestClient.RenewLeaseAsync(
                                leaseId: LeaseId,
                                requestPriority: requestPriority,
                                requestConditions: conditions,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            containerClientResponse = BlobContainerClient.ContainerRestClient.RenewLease(
                                leaseId: LeaseId,
                                requestPriority: requestPriority,
                                requestConditions: conditions,
                                cancellationToken: cancellationToken);
                        }

                        response = Response.FromValue(
                            containerClientResponse.ToBlobLease(BlobLeaseHeaderType.ContainerRenew),
                            containerClientResponse);
                    }

                    LeaseId = response.Value.LeaseId;
                    return response;
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(BlobLeaseClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Renew

        #region Release
        /// <summary>
        /// The <see cref="Release(BlobLeaseReleaseOptions, CancellationToken)"/> operation releases the
        /// container or blob's previously-acquired lease.
        ///
        /// The lease may be released if the <see cref="LeaseId"/>
        /// matches that associated with the container or blob.  Releasing the
        /// lease allows another client to immediately acquire the lease for the
        /// container or blob as soon as the release is complete.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ReleaseObjectLeaseInfo}"/> describing the
        /// updated blob or container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<ReleasedObjectInfo> Release(
            BlobLeaseReleaseOptions options,
            CancellationToken cancellationToken = default) =>
            ReleaseInternal(
                options?.Conditions,
                options?.RequestPriority,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="Release(BlobLeaseReleaseOptions, CancellationToken)"/> operation releases the
        /// container or blob's previously-acquired lease.
        ///
        /// The lease may be released if the <see cref="LeaseId"/>
        /// matches that associated with the container or blob.  Releasing the
        /// lease allows another client to immediately acquire the lease for the
        /// container or blob as soon as the release is complete.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobLeaseRequestConditions"/> to add
        /// conditions on releasing a lease.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ReleaseObjectLeaseInfo}"/> describing the
        /// updated blob or container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ReleasedObjectInfo> Release(
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            ReleaseInternal(
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="ReleaseAsync(BlobLeaseReleaseOptions, CancellationToken)"/> operation releases the
        /// container or blob's previously-acquired lease.
        ///
        /// The lease may be released if the <see cref="LeaseId"/>
        /// matches that associated with the container or blob.  Releasing the
        /// lease allows another client to immediately acquire the lease for the
        /// container or blob as soon as the release is complete.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ReleasedObjectInfo}"/> describing the
        /// updated blob or container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<ReleasedObjectInfo>> ReleaseAsync(
            BlobLeaseReleaseOptions options,
            CancellationToken cancellationToken = default) =>
            await ReleaseInternal(
                options?.Conditions,
                options?.RequestPriority,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="ReleaseAsync(BlobLeaseReleaseOptions, CancellationToken)"/> operation releases the
        /// container or blob's previously-acquired lease.
        ///
        /// The lease may be released if the <see cref="LeaseId"/>
        /// matches that associated with the container or blob.  Releasing the
        /// lease allows another client to immediately acquire the lease for the
        /// container or blob as soon as the release is complete.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobLeaseRequestConditions"/> to add
        /// conditions on releasing a lease.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ReleasedObjectInfo}"/> describing the
        /// updated blob or container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ReleasedObjectInfo>> ReleaseAsync(
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await ReleaseInternal(
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="ReleaseInternal(RequestConditions, bool, CancellationToken)"/> operation releases the
        /// container or blob's previously-acquired lease.
        ///
        /// The lease may be released if the <see cref="LeaseId"/>
        /// matches that associated with the container or blob.  Releasing the
        /// lease allows another client to immediately acquire the lease for the
        /// container or blob as soon as the release is complete.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="conditions">
        /// Optional <see cref="BlobLeaseRequestConditions"/> to add
        /// conditions on releasing a lease.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{ReleasedObjectInfo}"/> describing the
        /// updated blob or container.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // Client method should have an optional CancellationToken (both name and it being optional matters) or a RequestContext as the last parameter.
        public virtual async Task<Response<ReleasedObjectInfo>> ReleaseInternal(
            RequestConditions conditions,
#pragma warning disable AZC0105 // DO NOT add 'async' parameter to public methods. This method is published, so it can't be modified.
            bool async,
#pragma warning restore AZC0105 // DO NOT add 'async' parameter to public methods.
            CancellationToken cancellationToken)
#pragma warning restore AZC0002 // Client method should have an optional CancellationToken (both name and it being optional matters) or a RequestContext as the last parameter.
            => await ReleaseInternal(
                conditions,
                requestPriority: default,
                async,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Releases the lease.
        /// </summary>
        /// <param name="conditions">Optional conditions on releasing the lease.</param>
        /// <param name="requestPriority">
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </param>
        /// <param name="async">Whether to invoke the operation asynchronously.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be cancelled.</param>
        /// <returns>A <see cref="Response{ReleasedObjectInfo}"/> describing the released lease.</returns>
        internal async Task<Response<ReleasedObjectInfo>> ReleaseInternal(
            RequestConditions conditions,
            int? requestPriority,
            bool async,
            CancellationToken cancellationToken)
        {
            EnsureClient();
            using (Pipeline.BeginLoggingScope(nameof(BlobLeaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobLeaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(LeaseId)}: {LeaseId}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(BlobLeaseClient)}.{nameof(Release)}");

                try
                {
                    scope.Start();
                    string tagConditions = default;

                    if (conditions != null && conditions.GetType() == typeof(BlobLeaseRequestConditions))
                    {
                        tagConditions = ((BlobLeaseRequestConditions)conditions).TagConditions;
                    }

                    if (BlobClient != null)
                    {
                        Response response;
                        Argument.AssertNotNull(LeaseId, nameof(LeaseId));

                        if (async)
                        {
                            response = await BlobClient.BlobRestClient.ReleaseLeaseAsync(
                                leaseId: LeaseId,
                                requestPriority: requestPriority,
                                requestConditions: conditions,
                                ifTags: tagConditions,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            response = BlobClient.BlobRestClient.ReleaseLease(
                                leaseId: LeaseId,
                                requestPriority: requestPriority,
                                requestConditions: conditions,
                                ifTags: tagConditions,
                                cancellationToken: cancellationToken);
                        }

                        return Response.FromValue(
                            response.ToReleasedObjectInfo(),
                            response);
                    }
                    else
                    {
                        conditions.ValidateConditionsNotPresent(
                            invalidConditions:
                                BlobRequestConditionProperty.IfMatch
                                | BlobRequestConditionProperty.IfNoneMatch,
                            operationName: nameof(BlobLeaseClient.Release),
                            parameterName: nameof(conditions));

                        Response containerReleaseResponse;
                        Argument.AssertNotNull(LeaseId, nameof(LeaseId));

                        if (async)
                        {
                            containerReleaseResponse = await BlobContainerClient.ContainerRestClient.ReleaseLeaseAsync(
                                leaseId: LeaseId,
                                requestPriority: requestPriority,
                                requestConditions: conditions,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            containerReleaseResponse = BlobContainerClient.ContainerRestClient.ReleaseLease(
                                leaseId: LeaseId,
                                requestPriority: requestPriority,
                                requestConditions: conditions,
                                cancellationToken: cancellationToken);
                        }

                        return Response.FromValue(
                            containerReleaseResponse.ToReleasedObjectInfo(),
                            containerReleaseResponse);
                    }
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(BlobLeaseClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Release

        #region Change
        /// <summary>
        /// The <see cref="Change(string, BlobLeaseChangeOptions, CancellationToken)"/> operation changes the lease
        /// of an active lease.  A change must include the current
        /// <see cref="LeaseId"/> and a new <paramref name="proposedId"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="proposedId">
        /// An optional proposed lease ID, in a GUID string format. A
        /// <see cref="RequestFailedException"/> will be thrown if the
        /// proposed lease ID is not in the correct format.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<BlobLease> Change(
            string proposedId,
            BlobLeaseChangeOptions options,
            CancellationToken cancellationToken = default) =>
            ChangeInternal(
                proposedId,
                options?.Conditions,
                options?.RequestPriority,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="Change(string, BlobLeaseChangeOptions, CancellationToken)"/> operation changes the lease
        /// of an active lease.  A change must include the current
        /// <see cref="LeaseId"/> and a new <paramref name="proposedId"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="proposedId">
        /// An optional proposed lease ID, in a GUID string format. A
        /// <see cref="RequestFailedException"/> will be thrown if the
        /// proposed lease ID is not in the correct format.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobLeaseRequestConditions"/> to add
        /// conditions on changing a lease.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BlobLease> Change(
            string proposedId,
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            ChangeInternal(
                proposedId,
                conditions,
                default,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="ChangeAsync(string, BlobLeaseChangeOptions, CancellationToken)"/> operation changes the lease
        /// of an active lease.  A change must include the current
        /// <see cref="LeaseId"/> and a new <paramref name="proposedId"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="proposedId">
        /// An optional proposed lease ID, in a GUID string format. A
        /// <see cref="RequestFailedException"/> will be thrown if the
        /// proposed lease ID is not in the correct format.
        /// </param>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<BlobLease>> ChangeAsync(
            string proposedId,
            BlobLeaseChangeOptions options,
            CancellationToken cancellationToken = default) =>
            await ChangeInternal(
                proposedId,
                options?.Conditions,
                options?.RequestPriority,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="ChangeAsync(string, BlobLeaseChangeOptions, CancellationToken)"/> operation changes the lease
        /// of an active lease.  A change must include the current
        /// <see cref="LeaseId"/> and a new <paramref name="proposedId"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="proposedId">
        /// An optional proposed lease ID, in a GUID string format. A
        /// <see cref="RequestFailedException"/> will be thrown if the
        /// proposed lease ID is not in the correct format.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobLeaseRequestConditions"/> to add
        /// conditions on changing a lease.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BlobLease>> ChangeAsync(
            string proposedId,
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await ChangeInternal(
                proposedId,
                conditions,
                default,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="ChangeInternal"/> operation changes the lease
        /// of an active lease.  A change must include the current
        /// <see cref="LeaseId"/> and a new <paramref name="proposedId"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="proposedId">
        /// An optional proposed lease ID, in a GUID string format. A
        /// <see cref="RequestFailedException"/> will be thrown if the
        /// proposed lease ID is not in the correct format.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobLeaseRequestConditions"/> to add
        /// conditions on changing a lease.
        /// </param>
        /// <param name="requestPriority">
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<BlobLease>> ChangeInternal(
            string proposedId,
            RequestConditions conditions,
            int? requestPriority,
            bool async,
            CancellationToken cancellationToken)
        {
            EnsureClient();
            using (Pipeline.BeginLoggingScope(nameof(BlobLeaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobLeaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(LeaseId)}: {LeaseId}\n" +
                    $"{nameof(proposedId)}: {proposedId}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(BlobLeaseClient)}.{nameof(Change)}");

                try
                {
                    scope.Start();
                    string tagCondition = null;
                    if (conditions != null && conditions.GetType() == typeof(BlobLeaseRequestConditions))
                    {
                        tagCondition = ((BlobLeaseRequestConditions)conditions).TagConditions;
                    }

                    Response<BlobLease> response;
                    if (BlobClient != null)
                    {
                        Response blobClientResponse;
                        Argument.AssertNotNull(LeaseId, nameof(LeaseId));
                        Argument.AssertNotNull(proposedId, nameof(proposedId));

                        if (async)
                        {
                            blobClientResponse = await BlobClient.BlobRestClient.ChangeLeaseAsync(
                                leaseId: LeaseId,
                                proposedLeaseId: proposedId,
                                requestPriority: requestPriority,
                                requestConditions: conditions,
                                ifTags: tagCondition,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            blobClientResponse = BlobClient.BlobRestClient.ChangeLease(
                                leaseId: LeaseId,
                                proposedLeaseId: proposedId,
                                requestPriority: requestPriority,
                                requestConditions: conditions,
                                ifTags: tagCondition,
                                cancellationToken: cancellationToken);
                        }

                        response = Response.FromValue(
                            blobClientResponse.ToBlobLease(BlobLeaseHeaderType.BlobChange),
                            blobClientResponse);
                    }
                    else
                    {
                        conditions.ValidateConditionsNotPresent(
                            invalidConditions:
                                BlobRequestConditionProperty.IfMatch
                                | BlobRequestConditionProperty.IfNoneMatch,
                            operationName: nameof(BlobLeaseClient.Change),
                            parameterName: nameof(conditions));

                        Response containerClientResponse;
                        Argument.AssertNotNull(LeaseId, nameof(LeaseId));
                        Argument.AssertNotNull(proposedId, nameof(proposedId));

                        if (async)
                        {
                            containerClientResponse = await BlobContainerClient.ContainerRestClient.ChangeLeaseAsync(
                                leaseId: LeaseId,
                                proposedLeaseId: proposedId,
                                requestPriority: requestPriority,
                                requestConditions: conditions,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            containerClientResponse = BlobContainerClient.ContainerRestClient.ChangeLease(
                                leaseId: LeaseId,
                                proposedLeaseId: proposedId,
                                requestPriority: requestPriority,
                                requestConditions: conditions,
                                cancellationToken: cancellationToken);
                        }

                        response = Response.FromValue(
                            containerClientResponse.ToBlobLease(BlobLeaseHeaderType.ContainerChange),
                            containerClientResponse);
                    }

                    LeaseId = response.Value.LeaseId;
                    return response;
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(BlobLeaseClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Change

        #region Break
        /// <summary>
        /// The <see cref="Break(BlobLeaseBreakOptions, CancellationToken)"/> operation breaks the blob or
        /// container's previously-acquired lease (if it exists).
        ///
        /// Once a lease is broken, it cannot be renewed.  Any authorized
        /// request can break the lease; the request is not required to
        /// specify a matching lease ID.  When a lease is broken, the lease
        /// break <see cref="BlobLeaseBreakOptions.BreakPeriod"/> is allowed to elapse,
        /// during which time no lease operation except
        /// <see cref="Break(TimeSpan?, RequestConditions, CancellationToken)"/>
        /// and <see cref="Release(BlobLeaseReleaseOptions, CancellationToken)"/> can be
        /// performed on the blob or container.  When a lease is successfully
        /// broken, the response indicates the interval in seconds until a new
        /// lease can be acquired.
        ///
        /// A lease that has been broken can also be released.  A client can
        /// immediately acquire a blob or container lease that has been
        /// released.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the broken lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual Response<BlobLease> Break(
            BlobLeaseBreakOptions options,
            CancellationToken cancellationToken = default) =>
            BreakInternal(
                options?.BreakPeriod,
                options?.Conditions,
                options?.RequestPriority,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="Break(BlobLeaseBreakOptions, CancellationToken)"/> operation breaks the blob or
        /// container's previously-acquired lease (if it exists).
        ///
        /// Once a lease is broken, it cannot be renewed.  Any authorized
        /// request can break the lease; the request is not required to
        /// specify a matching lease ID.  When a lease is broken, the lease
        /// break <paramref name="breakPeriod"/> is allowed to elapse,
        /// during which time no lease operation except
        /// <see cref="Break(TimeSpan?, RequestConditions, CancellationToken)"/>
        /// and <see cref="Release(BlobLeaseReleaseOptions, CancellationToken)"/> can be
        /// performed on the blob or container.  When a lease is successfully
        /// broken, the response indicates the interval in seconds until a new
        /// lease can be acquired.
        ///
        /// A lease that has been broken can also be released.  A client can
        /// immediately acquire a blob or container lease that has been
        /// released.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="breakPeriod">
        /// Specifies the proposed duration the lease should continue before
        /// it is broken, in seconds, between 0 and 60.  This break period is
        /// only used if it is shorter than the time remaining on the lease.
        /// If longer, the time remaining on the lease is used.  A new lease
        /// will not be available before the break period has expired, but the
        /// lease may be held for longer than the break period.  If this value
        /// is not provided, a fixed-duration lease breaks after the remaining
        /// lease period elapses, and an infinite lease breaks immediately.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobLeaseRequestConditions"/> to add
        /// conditions on breaking a lease.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the broken lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BlobLease> Break(
            TimeSpan? breakPeriod = default,
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            BreakInternal(
                breakPeriod,
                conditions,
                default,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="BreakAsync(BlobLeaseBreakOptions, CancellationToken)"/> operation breaks the blob or
        /// container's previously-acquired lease (if it exists).
        ///
        /// Once a lease is broken, it cannot be renewed.  Any authorized
        /// request can break the lease; the request is not required to
        /// specify a matching lease ID.  When a lease is broken, the lease
        /// break <see cref="BlobLeaseBreakOptions.BreakPeriod"/> is allowed to elapse,
        /// during which time no lease operation except
        /// <see cref="BreakAsync(TimeSpan?, RequestConditions, CancellationToken)"/>
        /// and <see cref="ReleaseAsync(BlobLeaseReleaseOptions, CancellationToken)"/> can be
        /// performed on the blob or container.  When a lease is successfully
        /// broken, the response indicates the interval in seconds until a new
        /// lease can be acquired.
        ///
        /// A lease that has been broken can also be released.  A client can
        /// immediately acquire a blob or container lease that has been
        /// released.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="options">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the broken lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        public virtual async Task<Response<BlobLease>> BreakAsync(
            BlobLeaseBreakOptions options,
            CancellationToken cancellationToken = default) =>
            await BreakInternal(
                options?.BreakPeriod,
                options?.Conditions,
                options?.RequestPriority,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="BreakAsync(BlobLeaseBreakOptions, CancellationToken)"/> operation breaks the blob or
        /// container's previously-acquired lease (if it exists).
        ///
        /// Once a lease is broken, it cannot be renewed.  Any authorized
        /// request can break the lease; the request is not required to
        /// specify a matching lease ID.  When a lease is broken, the lease
        /// break <paramref name="breakPeriod"/> is allowed to elapse,
        /// during which time no lease operation except
        /// <see cref="BreakAsync(TimeSpan?, RequestConditions, CancellationToken)"/>
        /// and <see cref="ReleaseAsync(BlobLeaseReleaseOptions, CancellationToken)"/> can be
        /// performed on the blob or container.  When a lease is successfully
        /// broken, the response indicates the interval in seconds until a new
        /// lease can be acquired.
        ///
        /// A lease that has been broken can also be released.  A client can
        /// immediately acquire a blob or container lease that has been
        /// released.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="breakPeriod">
        /// Specifies the proposed duration the lease should continue before
        /// it is broken, in seconds, between 0 and 60.  This break period is
        /// only used if it is shorter than the time remaining on the lease.
        /// If longer, the time remaining on the lease is used.  A new lease
        /// will not be available before the break period has expired, but the
        /// lease may be held for longer than the break period.  If this value
        /// is not provided, a fixed-duration lease breaks after the remaining
        /// lease period elapses, and an infinite lease breaks immediately.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobLeaseRequestConditions"/> to add
        /// conditions on breaking a lease.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the broken lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BlobLease>> BreakAsync(
            TimeSpan? breakPeriod = default,
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await BreakInternal(
                breakPeriod,
                conditions,
                default,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="BreakInternal"/> operation breaks the blob or
        /// container's previously-acquired lease (if it exists).
        ///
        /// Once a lease is broken, it cannot be renewed.  Any authorized
        /// request can break the lease; the request is not required to
        /// specify a matching lease ID.  When a lease is broken, the lease
        /// break <paramref name="breakPeriod"/> is allowed to elapse,
        /// during which time no lease operation except
        /// <see cref="BreakAsync(BlobLeaseBreakOptions, CancellationToken)"/>
        /// and <see cref="ReleaseAsync(BlobLeaseReleaseOptions, CancellationToken)"/> can be
        /// performed on the blob or container.  When a lease is successfully
        /// broken, the response indicates the interval in seconds until a new
        /// lease can be acquired.
        ///
        /// A lease that has been broken can also be released.  A client can
        /// immediately acquire a blob or container lease that has been
        /// released.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container">
        /// Lease Container</see>.
        /// </summary>
        /// <param name="breakPeriod">
        /// Specifies the proposed duration the lease should continue before
        /// it is broken, in seconds, between 0 and 60.  This break period is
        /// only used if it is shorter than the time remaining on the lease.
        /// If longer, the time remaining on the lease is used.  A new lease
        /// will not be available before the break period has expired, but the
        /// lease may be held for longer than the break period.  If this value
        /// is not provided, a fixed-duration lease breaks after the remaining
        /// lease period elapses, and an infinite lease breaks immediately.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobLeaseRequestConditions"/> to add
        /// conditions on breaking a lease.
        /// </param>
        /// <param name="requestPriority">
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </param>
        /// <param name="async">
        /// Whether to invoke the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Lease}"/> describing the broken lease.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// If multiple failures occur, an <see cref="AggregateException"/> will be thrown,
        /// containing each failure instance.
        /// </remarks>
        private async Task<Response<BlobLease>> BreakInternal(
            TimeSpan? breakPeriod,
            RequestConditions conditions,
            int? requestPriority,
            bool async,
            CancellationToken cancellationToken)
        {
            EnsureClient();
            long? serviceBreakPeriod = breakPeriod != null ? Convert.ToInt64(breakPeriod.Value.TotalSeconds) : (long?)null;
            using (Pipeline.BeginLoggingScope(nameof(BlobLeaseClient)))
            {
                Pipeline.LogMethodEnter(
                    nameof(BlobLeaseClient),
                    message:
                    $"{nameof(Uri)}: {Uri}\n" +
                    $"{nameof(breakPeriod)}: {breakPeriod}\n" +
                    $"{nameof(conditions)}: {conditions}");

                DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(BlobLeaseClient)}.{nameof(Break)}");

                try
                {
                    scope.Start();
                    string tagConditions = null;
                    if (conditions != null && conditions.GetType() == typeof(BlobLeaseRequestConditions))
                    {
                        tagConditions = ((BlobLeaseRequestConditions)conditions).TagConditions;
                    }

                    if (BlobClient != null)
                    {
                        Response response;

                        if (async)
                        {
                            response = await BlobClient.BlobRestClient.BreakLeaseAsync(
                                requestPriority: requestPriority,
                                breakPeriod: serviceBreakPeriod,
                                requestConditions: conditions,
                                ifTags: tagConditions,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            response = BlobClient.BlobRestClient.BreakLease(
                                requestPriority: requestPriority,
                                breakPeriod: serviceBreakPeriod,
                                requestConditions: conditions,
                                ifTags: tagConditions,
                                cancellationToken: cancellationToken);
                        }

                        return Response.FromValue(
                            response.ToBlobLease(BlobLeaseHeaderType.BlobBreak),
                            response);
                    }
                    else
                    {
                        conditions.ValidateConditionsNotPresent(
                            invalidConditions:
                                BlobRequestConditionProperty.IfMatch
                                | BlobRequestConditionProperty.IfNoneMatch,
                            operationName: nameof(BlobLeaseClient.Break),
                            parameterName: nameof(conditions));

                        Response containerBreakResponse;

                        if (async)
                        {
                            containerBreakResponse = await BlobContainerClient.ContainerRestClient.BreakLeaseAsync(
                                requestPriority: requestPriority,
                                breakPeriod: serviceBreakPeriod,
                                requestConditions: conditions,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            containerBreakResponse = BlobContainerClient.ContainerRestClient.BreakLease(
                                requestPriority: requestPriority,
                                breakPeriod: serviceBreakPeriod,
                                requestConditions: conditions,
                                cancellationToken: cancellationToken);
                        }

                        return Response.FromValue(
                            containerBreakResponse.ToBlobLease(BlobLeaseHeaderType.ContainerBreak),
                            containerBreakResponse);
                    }
                }
                catch (Exception ex)
                {
                    Pipeline.LogException(ex);
                    scope.Failed(ex);
                    throw;
                }
                finally
                {
                    Pipeline.LogMethodExit(nameof(BlobLeaseClient));
                    scope.Dispose();
                }
            }
        }
        #endregion Break
    }

    /// <summary>
    /// Add easy to discover methods to <see cref="BlobContainerClient"/> and
    /// <see cref="BlobClient"/> for easily creating <see cref="BlobLeaseClient"/>
    /// instances.
    /// </summary>
    public static partial class SpecializedBlobExtensions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobLeaseClient"/> class.
        /// </summary>
        /// <param name="client">
        /// A <see cref="BlobClient"/> representing the blob being leased.
        /// </param>
        /// <param name="leaseId">
        /// An optional lease ID.  If no lease ID is provided, a random lease
        /// ID will be created.
        /// </param>
        public static BlobLeaseClient GetBlobLeaseClient(
            this BlobBaseClient client,
            string leaseId = null) =>
            client.GetBlobLeaseClientCore(leaseId);

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobLeaseClient"/> class.
        /// </summary>
        /// <param name="client">
        /// A <see cref="BlobContainerClient"/> representing the container
        /// being leased.
        /// </param>
        /// <param name="leaseId">
        /// An optional lease ID.  If no lease ID is provided, a random lease
        /// ID will be created.
        /// </param>
        public static BlobLeaseClient GetBlobLeaseClient(
            this BlobContainerClient client,
            string leaseId = null) =>
            client.GetBlobLeaseClientCore(leaseId);
    }
}
