// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;

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
        /// A lease duration cannot be changed using <see cref="RenewAsync"/>
        /// or <see cref="ChangeAsync"/>.
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
        /// </remarks>
        public virtual Response<BlobLease> Acquire(
            TimeSpan duration,
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            ParseAcquireResponse(AcquireInternal(
                duration,
                conditions,
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
        /// A lease duration cannot be changed using <see cref="RenewAsync"/>
        /// or <see cref="ChangeAsync"/>.
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
        /// </remarks>
        public virtual async Task<Response<BlobLease>> AcquireAsync(
            TimeSpan duration,
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            ParseAcquireResponse(await AcquireInternal(
                duration,
                conditions,
                async: true,
                new RequestContext() { CancellationToken = cancellationToken })
                .ConfigureAwait(false));

        private Response<BlobLease> ParseAcquireResponse(Response response)
        {
            if (BlobClient != null)
            {
                return Response.FromValue(
                    ResponseWithHeaders.FromValue(new BlobAcquireLeaseHeaders(response), response).ToBlobLease(),
                    response);
            }
            else
            {
                return Response.FromValue(
                    ResponseWithHeaders.FromValue(new ContainerAcquireLeaseHeaders(response), response).ToBlobLease(),
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
        /// A lease duration cannot be changed using <see cref="RenewAsync"/>
        /// or <see cref="ChangeAsync"/>.
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
        /// </remarks>
        public virtual Response Acquire(
            TimeSpan duration,
            RequestConditions conditions,
            RequestContext context) =>
            AcquireInternal(
                duration,
                conditions,
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
        /// A lease duration cannot be changed using <see cref="RenewAsync"/>
        /// or <see cref="ChangeAsync"/>.
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
        /// A lease duration cannot be changed using <see cref="RenewAsync"/>
        /// or <see cref="ChangeAsync"/>.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobLeaseRequestConditions"/> to add
        /// conditions on acquiring a lease.
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
        /// </remarks>
        private async Task<Response> AcquireInternal(
            TimeSpan duration,
            RequestConditions conditions,
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
                                proposedLeaseId: LeaseId,
                                requestConditions: conditions,
                                context: context)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            response = BlobContainerClient.ContainerRestClient.AcquireLease(
                                duration: serviceDuration,
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
        /// The <see cref="Renew"/> operation renews the blob or
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
        /// </remarks>
        public virtual Response<BlobLease> Renew(
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            RenewInternal(
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="RenewAsync"/> operation renews the blob or
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
        /// </remarks>
        public virtual async Task<Response<BlobLease>> RenewAsync(
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await RenewInternal(
                conditions,
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
        /// </remarks>
        private async Task<Response<BlobLease>> RenewInternal(
            RequestConditions conditions,
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
                        ResponseWithHeaders<BlobRenewLeaseHeaders> blobClientResponse;

                        if (async)
                        {
                            blobClientResponse = await BlobClient.BlobRestClient.RenewLeaseAsync(
                                leaseId: LeaseId,
                                ifModifiedSince: conditions?.IfModifiedSince,
                                ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                                ifMatch: conditions?.IfMatch?.ToString(),
                                ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                                ifTags: tagConditions,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            blobClientResponse = BlobClient.BlobRestClient.RenewLease(
                                leaseId: LeaseId,
                                ifModifiedSince: conditions?.IfModifiedSince,
                                ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                                ifMatch: conditions?.IfMatch?.ToString(),
                                ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                                ifTags: tagConditions,
                                cancellationToken: cancellationToken);
                        }

                        response = Response.FromValue(
                            blobClientResponse.ToBlobLease(),
                            blobClientResponse.GetRawResponse());
                    }
                    else
                    {
                        conditions.ValidateConditionsNotPresent(
                            invalidConditions:
                                BlobRequestConditionProperty.IfMatch
                                | BlobRequestConditionProperty.IfNoneMatch,
                            operationName: nameof(BlobLeaseClient.Release),
                            parameterName: nameof(conditions));

                        ResponseWithHeaders<ContainerRenewLeaseHeaders> containerClientResponse;

                        if (async)
                        {
                            containerClientResponse = await BlobContainerClient.ContainerRestClient.RenewLeaseAsync(
                                leaseId: LeaseId,
                                ifModifiedSince: conditions?.IfModifiedSince,
                                ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            containerClientResponse = BlobContainerClient.ContainerRestClient.RenewLease(
                                leaseId: LeaseId,
                                ifModifiedSince: conditions?.IfModifiedSince,
                                ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                                cancellationToken: cancellationToken);
                        }

                        response = Response.FromValue(
                            containerClientResponse.ToBlobLease(),
                            containerClientResponse.GetRawResponse());
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
        /// The <see cref="Release"/> operation releases the
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
        /// </remarks>
        public virtual Response<ReleasedObjectInfo> Release(
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            ReleaseInternal(
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="ReleaseAsync"/> operation releases the
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
        /// </remarks>
        public virtual async Task<Response<ReleasedObjectInfo>> ReleaseAsync(
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await ReleaseInternal(
                conditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="ReleaseInternal"/> operation releases the
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
                        ResponseWithHeaders<BlobReleaseLeaseHeaders> response;

                        if (async)
                        {
                            response = await BlobClient.BlobRestClient.ReleaseLeaseAsync(
                                leaseId: LeaseId,
                                ifModifiedSince: conditions?.IfModifiedSince,
                                ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                                ifMatch: conditions?.IfMatch?.ToString(),
                                ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                                ifTags: tagConditions,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            response = BlobClient.BlobRestClient.ReleaseLease(
                                leaseId: LeaseId,
                                ifModifiedSince: conditions?.IfModifiedSince,
                                ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                                ifMatch: conditions?.IfMatch?.ToString(),
                                ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                                ifTags: tagConditions,
                                cancellationToken: cancellationToken);
                        }

                        return Response.FromValue(
                            response.ToReleasedObjectInfo(),
                            response.GetRawResponse());
                    }
                    else
                    {
                        conditions.ValidateConditionsNotPresent(
                            invalidConditions:
                                BlobRequestConditionProperty.IfMatch
                                | BlobRequestConditionProperty.IfNoneMatch,
                            operationName: nameof(BlobLeaseClient.Release),
                            parameterName: nameof(conditions));

                        ResponseWithHeaders<ContainerReleaseLeaseHeaders> response;

                        if (async)
                        {
                            response = await BlobContainerClient.ContainerRestClient.ReleaseLeaseAsync(
                                leaseId: LeaseId,
                                ifModifiedSince: conditions?.IfModifiedSince,
                                ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            response = BlobContainerClient.ContainerRestClient.ReleaseLease(
                                leaseId: LeaseId,
                                ifModifiedSince: conditions?.IfModifiedSince,
                                ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                                cancellationToken: cancellationToken);
                        }

                        return Response.FromValue(
                            response.ToReleasedObjectInfo(),
                            response.GetRawResponse());
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
        /// The <see cref="Change"/> operation changes the lease
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
        /// </remarks>
        public virtual Response<BlobLease> Change(
            string proposedId,
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            ChangeInternal(
                proposedId,
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="ChangeAsync"/> operation changes the lease
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
        /// </remarks>
        public virtual async Task<Response<BlobLease>> ChangeAsync(
            string proposedId,
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await ChangeInternal(
                proposedId,
                conditions,
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
        /// </remarks>
        private async Task<Response<BlobLease>> ChangeInternal(
            string proposedId,
            RequestConditions conditions,
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
                        ResponseWithHeaders<BlobChangeLeaseHeaders> blobClientResponse;

                        if (async)
                        {
                            blobClientResponse = await BlobClient.BlobRestClient.ChangeLeaseAsync(
                                leaseId: LeaseId,
                                proposedLeaseId: proposedId,
                                ifModifiedSince: conditions?.IfModifiedSince,
                                ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                                ifMatch: conditions?.IfMatch?.ToString(),
                                ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                                ifTags: tagCondition,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            blobClientResponse = BlobClient.BlobRestClient.ChangeLease(
                                leaseId: LeaseId,
                                proposedLeaseId: proposedId,
                                ifModifiedSince: conditions?.IfModifiedSince,
                                ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                                ifMatch: conditions?.IfMatch?.ToString(),
                                ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                                ifTags: tagCondition,
                                cancellationToken: cancellationToken);
                        }

                        response = Response.FromValue(
                            blobClientResponse.ToBlobLease(),
                            blobClientResponse.GetRawResponse());
                    }
                    else
                    {
                        conditions.ValidateConditionsNotPresent(
                            invalidConditions:
                                BlobRequestConditionProperty.IfMatch
                                | BlobRequestConditionProperty.IfNoneMatch,
                            operationName: nameof(BlobLeaseClient.Change),
                            parameterName: nameof(conditions));

                        ResponseWithHeaders<ContainerChangeLeaseHeaders> containerClientResponse;

                        if (async)
                        {
                            containerClientResponse = await BlobContainerClient.ContainerRestClient.ChangeLeaseAsync(
                                leaseId: LeaseId,
                                proposedLeaseId: proposedId,
                                ifModifiedSince: conditions?.IfModifiedSince,
                                ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            containerClientResponse = BlobContainerClient.ContainerRestClient.ChangeLease(
                                leaseId: LeaseId,
                                proposedLeaseId: proposedId,
                                ifModifiedSince: conditions?.IfModifiedSince,
                                ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                                cancellationToken: cancellationToken);
                        }

                        response = Response.FromValue(
                            containerClientResponse.ToBlobLease(),
                            containerClientResponse.GetRawResponse());
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
        /// The <see cref="Break"/> operation breaks the blob or
        /// container's previously-acquired lease (if it exists).
        ///
        /// Once a lease is broken, it cannot be renewed.  Any authorized
        /// request can break the lease; the request is not required to
        /// specify a matching lease ID.  When a lease is broken, the lease
        /// break <paramref name="breakPeriod"/> is allowed to elapse,
        /// during which time no lease operation except
        /// <see cref="Break(TimeSpan?, RequestConditions, CancellationToken)"/>
        /// and <see cref="Release"/> can be
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
        /// </remarks>
        public virtual Response<BlobLease> Break(
            TimeSpan? breakPeriod = default,
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            BreakInternal(
                breakPeriod,
                conditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="BreakAsync"/> operation breaks the blob or
        /// container's previously-acquired lease (if it exists).
        ///
        /// Once a lease is broken, it cannot be renewed.  Any authorized
        /// request can break the lease; the request is not required to
        /// specify a matching lease ID.  When a lease is broken, the lease
        /// break <paramref name="breakPeriod"/> is allowed to elapse,
        /// during which time no lease operation except
        /// <see cref="BreakAsync(TimeSpan?, RequestConditions, CancellationToken)"/>
        /// and <see cref="ReleaseAsync"/> can be
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
        /// </remarks>
        public virtual async Task<Response<BlobLease>> BreakAsync(
            TimeSpan? breakPeriod = default,
            RequestConditions conditions = default,
            CancellationToken cancellationToken = default) =>
            await BreakInternal(
                breakPeriod,
                conditions,
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
        /// <see cref="BreakAsync"/>
        /// and <see cref="ReleaseAsync"/> can be
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
        /// </remarks>
        private async Task<Response<BlobLease>> BreakInternal(
            TimeSpan? breakPeriod,
            RequestConditions conditions,
            bool async,
            CancellationToken cancellationToken)
        {
            EnsureClient();
            long? serviceBreakPeriod = breakPeriod != null ? Convert.ToInt64(breakPeriod.Value.TotalSeconds) : (long?) null;
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
                        ResponseWithHeaders<BlobBreakLeaseHeaders> response;

                        if (async)
                        {
                            response = await BlobClient.BlobRestClient.BreakLeaseAsync(
                                breakPeriod: serviceBreakPeriod,
                                ifModifiedSince: conditions?.IfModifiedSince,
                                ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                                ifMatch: conditions?.IfMatch?.ToString(),
                                ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                                ifTags: tagConditions,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            response = BlobClient.BlobRestClient.BreakLease(
                                breakPeriod: serviceBreakPeriod,
                                ifModifiedSince: conditions?.IfModifiedSince,
                                ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                                ifMatch: conditions?.IfMatch?.ToString(),
                                ifNoneMatch: conditions?.IfNoneMatch?.ToString(),
                                ifTags: tagConditions,
                                cancellationToken: cancellationToken);
                        }

                        return Response.FromValue(
                            response.ToBlobLease(),
                            response.GetRawResponse());
                    }
                    else
                    {
                        conditions.ValidateConditionsNotPresent(
                            invalidConditions:
                                BlobRequestConditionProperty.IfMatch
                                | BlobRequestConditionProperty.IfNoneMatch,
                            operationName: nameof(BlobLeaseClient.Break),
                            parameterName: nameof(conditions));

                        ResponseWithHeaders<ContainerBreakLeaseHeaders> response;

                        if (async)
                        {
                            response = await BlobContainerClient.ContainerRestClient.BreakLeaseAsync(
                                breakPeriod: serviceBreakPeriod,
                                ifModifiedSince: conditions?.IfModifiedSince,
                                ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            response = BlobContainerClient.ContainerRestClient.BreakLease(
                                breakPeriod: serviceBreakPeriod,
                                ifModifiedSince: conditions?.IfModifiedSince,
                                ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                                cancellationToken: cancellationToken);
                        }

                        return Response.FromValue(
                            response.ToBlobLease(),
                            response.GetRawResponse());
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
