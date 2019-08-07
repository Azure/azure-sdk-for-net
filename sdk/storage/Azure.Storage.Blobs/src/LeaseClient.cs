// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// The <see cref="LeaseClient"/> allows you to manipulate Azure
    /// Storage leases on containers and blobs.
    /// </summary>
    public class LeaseClient
    {
        /// <summary>
        /// The <see cref="BlobClient"/> to manage leases for.
        /// </summary>
        private readonly BlobBaseClient _blob;

        /// <summary>
        /// Gets the <see cref="BlobClient"/> to manage leases for.
        /// </summary>
        protected virtual BlobBaseClient BlobClient => this._blob;

        /// <summary>
        /// The <see cref="BlobContainerClient"/> to manage leases for.
        /// </summary>
        private readonly BlobContainerClient _container;

        /// <summary>
        /// Gets the <see cref="BlobContainerClient"/> to manage leases for.
        /// </summary>
        protected virtual BlobContainerClient ContainerClient => this._container;

        /// <summary>
        /// Gets the URI of the object being leased.
        /// </summary>
        public Uri Uri => this.BlobClient?.Uri ?? this.ContainerClient?.Uri;

        /// <summary>
        /// Gets the Lease ID for this lease.
        /// </summary>
        public virtual string LeaseId { get; private set; }

        /// <summary>
        /// The <see cref="HttpPipeline"/> transport pipeline used to send
        /// every request.
        /// </summary>
        private HttpPipeline Pipeline => this.BlobClient?.Pipeline ?? this.ContainerClient.Pipeline;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeaseClient"/> class
        /// for mocking.
        /// </summary>
        protected LeaseClient()
        {
            this._blob = null;
            this._container = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeaseClient"/>  class.
        /// </summary>
        /// <param name="client">
        /// A <see cref="BlobClient"/> representing the blob being leased.
        /// </param>
        /// <param name="leaseId">
        /// An optional lease ID.  If no lease ID is provided, a random lease
        /// ID will be created.
        /// </param>
        public LeaseClient(BlobBaseClient client, string leaseId = null)
        {
            this._blob = client ?? throw new ArgumentNullException(nameof(client));
            this._container = null;
            this.LeaseId = leaseId ?? CreateUniqueLeaseId();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeaseClient"/>  class.
        /// </summary>
        /// <param name="client">
        /// A <see cref="BlobContainerClient"/> representing the container
        /// being leased.
        /// </param>
        /// <param name="leaseId">
        /// An optional lease ID.  If no lease ID is provided, a random lease
        /// ID will be created.
        /// </param>
        public LeaseClient(BlobContainerClient client, string leaseId = null)
        {
            this._blob = null;
            this._container = client ?? throw new ArgumentNullException(nameof(client));
            this.LeaseId = leaseId ?? CreateUniqueLeaseId();
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
            if (this.BlobClient == null && this.ContainerClient == null)
            {
                // This can only happen if someone's not being careful while mocking
                throw new InvalidOperationException(
                    $"{nameof(LeaseClient)} requires either a ${nameof(BlobBaseClient)} or ${nameof(BlobContainerClient)}");
            }
        }

        #region Acquire
        /// <summary>
        /// The <see cref="Acquire"/> operation acquires a lease on
        /// the blob or container.  The lease <paramref name="duration"/> must
        /// be between 15 to 60 seconds, or infinite (-1).
        ///
        /// If the container does not have an active lease, the Blob service
        /// creates a lease on the blob or container and returns it.  If the
        /// container has an active lease, you can only request a new lease
        /// using the active lease ID as <see cref="LeaseId"/>, but you can
        /// specify a new <paramref name="duration"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container" />.
        /// </summary>
        /// <param name="duration">
        /// Specifies the duration of the lease, in seconds, or -1 for a lease
        /// that never expires.  A non-infinite lease can be between 15 and
        /// 60 seconds. A lease duration cannot be changed using
        /// <see cref="RenewAsync"/> or <see cref="ChangeAsync"/>.
        /// </param>
        /// <param name="httpAccessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<Lease> Acquire(
            int duration,
            HttpAccessConditions? httpAccessConditions = default,
            CancellationToken cancellationToken = default) =>
            this.AcquireInternal(
                duration,
                httpAccessConditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="AcquireAsync"/> operation acquires a lease on
        /// the blob or container.  The lease <paramref name="duration"/> must
        /// be between 15 to 60 seconds, or infinite (-1).
        ///
        /// If the container does not have an active lease, the Blob service
        /// creates a lease on the blob or container and returns it.  If the
        /// container has an active lease, you can only request a new lease
        /// using the active lease ID as <see cref="LeaseId"/>, but you can
        /// specify a new <paramref name="duration"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container" />.
        /// </summary>
        /// <param name="duration">
        /// Specifies the duration of the lease, in seconds, or -1 for a lease
        /// that never expires.  A non-infinite lease can be between 15 and
        /// 60 seconds. A lease duration cannot be changed using
        /// <see cref="RenewAsync"/> or <see cref="ChangeAsync"/>.
        /// </param>
        /// <param name="httpAccessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<Lease>> AcquireAsync(
            int duration,
            HttpAccessConditions? httpAccessConditions = default,
            CancellationToken cancellationToken = default) =>
            await this.AcquireInternal(
                duration,
                httpAccessConditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

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
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container" />.
        /// </summary>
        /// <param name="duration">
        /// Specifies the duration of the lease, in seconds, or -1 for a lease
        /// that never expires.  A non-infinite lease can be between 15 and
        /// 60 seconds. A lease duration cannot be changed using
        /// <see cref="RenewAsync"/> or <see cref="ChangeAsync"/>.
        /// </param>
        /// <param name="httpAccessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
        /// conditions on acquiring a lease.
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<Lease>> AcquireInternal(
            int duration,
            HttpAccessConditions? httpAccessConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            this.EnsureClient();
            using (this.Pipeline.BeginLoggingScope(nameof(LeaseClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(LeaseClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(this.LeaseId)}: {this.LeaseId}\n" +
                    $"{nameof(duration)}: {duration}");
                try
                {
                    if (this.BlobClient != null)
                    {
                        return await BlobRestClient.Blob.AcquireLeaseAsync(
                            this.Pipeline,
                            this.Uri,
                            duration: duration,
                            proposedLeaseId: this.LeaseId,
                            ifModifiedSince: httpAccessConditions?.IfModifiedSince,
                            ifUnmodifiedSince: httpAccessConditions?.IfUnmodifiedSince,
                            ifMatch: httpAccessConditions?.IfMatch,
                            ifNoneMatch: httpAccessConditions?.IfNoneMatch,
                            async: async,
                            operationName: Constants.Blob.Lease.AcquireOperationName,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        if (httpAccessConditions?.IfMatch != default || httpAccessConditions?.IfNoneMatch != default)
                        {
                            throw BlobErrors.BlobConditionsMustBeDefault(
                                nameof(HttpAccessConditions.IfMatch),
                                nameof(HttpAccessConditions.IfNoneMatch));
                        }
                        return await BlobRestClient.Container.AcquireLeaseAsync(
                            this.Pipeline,
                            this.Uri,
                            duration: duration,
                            proposedLeaseId: this.LeaseId,
                            ifModifiedSince: httpAccessConditions?.IfModifiedSince,
                            ifUnmodifiedSince: httpAccessConditions?.IfUnmodifiedSince,
                            async: async,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(LeaseClient));
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
        /// matches that associated with the blob or container.  Note that the]
        /// lease may be renewed even if it has expired as long as the blob or
        /// container has not been leased again since the expiration of that
        /// lease.  When you renew a lease, the lease duration clock resets.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container" />.
        /// </summary>
        /// <param name="httpAccessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<Lease> Renew(
            HttpAccessConditions? httpAccessConditions = default,
            CancellationToken cancellationToken = default) =>
            this.RenewInternal(
                httpAccessConditions,
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
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container" />.
        /// </summary>
        /// <param name="httpAccessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<Lease>> RenewAsync(
            HttpAccessConditions? httpAccessConditions = default,
            CancellationToken cancellationToken = default) =>
            await this.RenewInternal(
                httpAccessConditions,
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
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container" />.
        /// </summary>
        /// <param name="httpAccessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<Lease>> RenewInternal(
            HttpAccessConditions? httpAccessConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            using (this.Pipeline.BeginLoggingScope(nameof(LeaseClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(LeaseClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(this.LeaseId)}: {this.LeaseId}\n" +
                    $"{nameof(httpAccessConditions)}: {httpAccessConditions}");
                try
                {
                    if (this.BlobClient != null)
                    {
                        return await BlobRestClient.Blob.RenewLeaseAsync(
                            this.Pipeline,
                            this.Uri,
                            leaseId: this.LeaseId,
                            ifModifiedSince: httpAccessConditions?.IfModifiedSince,
                            ifUnmodifiedSince: httpAccessConditions?.IfUnmodifiedSince,
                            ifMatch: httpAccessConditions?.IfMatch,
                            ifNoneMatch: httpAccessConditions?.IfNoneMatch,
                            async: async,
                            operationName: Constants.Blob.Lease.RenewOperationName,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        if (httpAccessConditions?.IfMatch != default || httpAccessConditions?.IfNoneMatch != default)
                        {
                            throw BlobErrors.BlobConditionsMustBeDefault(
                                nameof(HttpAccessConditions.IfMatch),
                                nameof(HttpAccessConditions.IfNoneMatch));
                        }
                        return await BlobRestClient.Container.RenewLeaseAsync(
                            this.Pipeline,
                            this.Uri,
                            leaseId: this.LeaseId,
                            ifModifiedSince: httpAccessConditions?.IfModifiedSince,
                            ifUnmodifiedSince: httpAccessConditions?.IfUnmodifiedSince,
                            async: async,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(LeaseClient));
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
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container" />.
        /// </summary>
        /// <param name="httpAccessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<ReleasedObjectInfo> Release(
            HttpAccessConditions? httpAccessConditions = default,
            CancellationToken cancellationToken = default) =>
            this.ReleaseInternal(
                httpAccessConditions,
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
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container" />.
        /// </summary>
        /// <param name="httpAccessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ReleasedObjectInfo>> ReleaseAsync(
            HttpAccessConditions? httpAccessConditions = default,
            CancellationToken cancellationToken = default) =>
            await this.ReleaseInternal(
                httpAccessConditions,
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
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container" />.
        /// </summary>
        /// <param name="httpAccessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<ReleasedObjectInfo>> ReleaseInternal(
            HttpAccessConditions? httpAccessConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            this.EnsureClient();
            using (this.Pipeline.BeginLoggingScope(nameof(LeaseClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(LeaseClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(this.LeaseId)}: {this.LeaseId}\n" +
                    $"{nameof(httpAccessConditions)}: {httpAccessConditions}");
                try
                {
                    if (this.BlobClient != null)
                    {
                        var response =
                            await BlobRestClient.Blob.ReleaseLeaseAsync(
                                this.Pipeline,
                                this.Uri,
                                leaseId: this.LeaseId,
                                ifModifiedSince: httpAccessConditions?.IfModifiedSince,
                                ifUnmodifiedSince: httpAccessConditions?.IfUnmodifiedSince,
                                ifMatch: httpAccessConditions?.IfMatch,
                                ifNoneMatch: httpAccessConditions?.IfNoneMatch,
                                async: async,
                                operationName: Constants.Blob.Lease.ReleaseOperationName,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        return new Response<ReleasedObjectInfo>(
                            response.GetRawResponse(),
                            new ReleasedObjectInfo(response.Value));
                    }
                    else
                    {
                        if (httpAccessConditions?.IfMatch != default || httpAccessConditions?.IfNoneMatch != default)
                        {
                            throw BlobErrors.BlobConditionsMustBeDefault(
                                nameof(HttpAccessConditions.IfMatch),
                                nameof(HttpAccessConditions.IfNoneMatch));
                        }
                        var response =
                            await BlobRestClient.Container.ReleaseLeaseAsync(
                                this.Pipeline,
                                this.Uri,
                                leaseId: this.LeaseId,
                                ifModifiedSince: httpAccessConditions?.IfModifiedSince,
                                ifUnmodifiedSince: httpAccessConditions?.IfUnmodifiedSince,
                                async: async,
                                cancellationToken: cancellationToken)
                                .ConfigureAwait(false);
                        return new Response<ReleasedObjectInfo>(
                            response.GetRawResponse(),
                            new ReleasedObjectInfo(response.Value));
                    }
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(LeaseClient));
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
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container" />.
        /// </summary>
        /// <param name="proposedId">
        /// An optional proposed lease ID, in a GUID string format. A
        /// <see cref="StorageRequestFailedException"/> will be thrown if the
        /// proposed lease ID is not in the correct format.
        /// </param>
        /// <param name="httpAccessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<Lease> Change(
            string proposedId,
            HttpAccessConditions? httpAccessConditions = default,
            CancellationToken cancellationToken = default) =>
            this.ChangeInternal(
                proposedId,
                httpAccessConditions,
                false, // async
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="ChangeAsync"/> operation changes the lease
        /// of an active lease.  A change must include the current
        /// <see cref="LeaseId"/> and a new <paramref name="proposedId"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container" />.
        /// </summary>
        /// <param name="proposedId">
        /// An optional proposed lease ID, in a GUID string format. A
        /// <see cref="StorageRequestFailedException"/> will be thrown if the
        /// proposed lease ID is not in the correct format.
        /// </param>
        /// <param name="httpAccessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<Lease>> ChangeAsync(
            string proposedId,
            HttpAccessConditions? httpAccessConditions = default,
            CancellationToken cancellationToken = default) =>
            await this.ChangeInternal(
                proposedId,
                httpAccessConditions,
                true, // async
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="ChangeInternal"/> operation changes the lease
        /// of an active lease.  A change must include the current
        /// <see cref="LeaseId"/> and a new <paramref name="proposedId"/>.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container" />.
        /// </summary>
        /// <param name="proposedId">
        /// An optional proposed lease ID, in a GUID string format. A
        /// <see cref="StorageRequestFailedException"/> will be thrown if the
        /// proposed lease ID is not in the correct format.
        /// </param>
        /// <param name="httpAccessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<Lease>> ChangeInternal(
            string proposedId,
            HttpAccessConditions? httpAccessConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            this.EnsureClient();
            using (this.Pipeline.BeginLoggingScope(nameof(LeaseClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(LeaseClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(this.LeaseId)}: {this.LeaseId}\n" +
                    $"{nameof(proposedId)}: {proposedId}\n" +
                    $"{nameof(httpAccessConditions)}: {httpAccessConditions}");
                try
                {
                    if (this.BlobClient != null)
                    {
                        return await BlobRestClient.Blob.ChangeLeaseAsync(
                            this.Pipeline,
                            this.Uri,
                            leaseId: this.LeaseId,
                            proposedLeaseId: proposedId,
                            ifModifiedSince: httpAccessConditions?.IfModifiedSince,
                            ifUnmodifiedSince: httpAccessConditions?.IfUnmodifiedSince,
                            ifMatch: httpAccessConditions?.IfMatch,
                            ifNoneMatch: httpAccessConditions?.IfNoneMatch,
                            async: async,
                            operationName: "Azure.Storage.Blobs.Specialized.LeaseClient.Change",
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        if (httpAccessConditions?.IfMatch != default || httpAccessConditions?.IfNoneMatch != default)
                        {
                            throw BlobErrors.BlobConditionsMustBeDefault(
                                nameof(HttpAccessConditions.IfMatch),
                                nameof(HttpAccessConditions.IfNoneMatch));
                        }
                        return await BlobRestClient.Container.ChangeLeaseAsync(
                            this.Pipeline,
                            this.Uri,
                            leaseId: this.LeaseId,
                            proposedLeaseId: proposedId,
                            ifModifiedSince: httpAccessConditions?.IfModifiedSince,
                            ifUnmodifiedSince: httpAccessConditions?.IfUnmodifiedSince,
                            async: async,
                            operationName: Constants.Blob.Lease.ChangeOperationName,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(LeaseClient));
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
        /// break <paramref name="breakPeriodInSeconds"/> is allowed to elapse,
        /// during which time no lease operation except
        /// <see cref="Break"/> and <see cref="Release"/> can be
        /// performed on the blob or container.  When a lease is successfully
        /// broken, the response indicates the interval in seconds until a new
        /// lease can be acquired.
        ///
        /// A lease that has been broken can also be released.  A client can
        /// immediately acquire a blob or container lease that has been
        /// released.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container" />.
        /// </summary>
        /// <param name="breakPeriodInSeconds">
        /// Specifies the proposed duration the lease should continue before
        /// it is broken, in seconds, between 0 and 60.  This break period is
        /// only used if it is shorter than the time remaining on the lease.
        /// If longer, the time remaining on the lease is used.  A new lease
        /// will not be available before the break period has expired, but the
        /// lease may be held for longer than the break period.  If this value
        /// is not provided, a fixed-duration lease breaks after the remaining
        /// lease period elapses, and an infinite lease breaks immediately.
        /// </param>
        /// <param name="httpAccessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<Lease> Break(
            int? breakPeriodInSeconds = default,
            HttpAccessConditions? httpAccessConditions = default,
            CancellationToken cancellationToken = default) =>
            this.BreakInternal(
                breakPeriodInSeconds,
                httpAccessConditions,
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
        /// break <paramref name="breakPeriodInSeconds"/> is allowed to elapse,
        /// during which time no lease operation except
        /// <see cref="BreakAsync"/> and <see cref="ReleaseAsync"/> can be
        /// performed on the blob or container.  When a lease is successfully
        /// broken, the response indicates the interval in seconds until a new
        /// lease can be acquired.
        ///
        /// A lease that has been broken can also be released.  A client can
        /// immediately acquire a blob or container lease that has been
        /// released.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container" />.
        /// </summary>
        /// <param name="breakPeriodInSeconds">
        /// Specifies the proposed duration the lease should continue before
        /// it is broken, in seconds, between 0 and 60.  This break period is
        /// only used if it is shorter than the time remaining on the lease.
        /// If longer, the time remaining on the lease is used.  A new lease
        /// will not be available before the break period has expired, but the
        /// lease may be held for longer than the break period.  If this value
        /// is not provided, a fixed-duration lease breaks after the remaining
        /// lease period elapses, and an infinite lease breaks immediately.
        /// </param>
        /// <param name="httpAccessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<Lease>> BreakAsync(
            int? breakPeriodInSeconds = default,
            HttpAccessConditions? httpAccessConditions = default,
            CancellationToken cancellationToken = default) =>
            await this.BreakInternal(
                breakPeriodInSeconds,
                httpAccessConditions,
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
        /// break <paramref name="breakPeriodInSeconds"/> is allowed to elapse,
        /// during which time no lease operation except
        /// <see cref="BreakAsync"/> and <see cref="ReleaseAsync"/> can be
        /// performed on the blob or container.  When a lease is successfully
        /// broken, the response indicates the interval in seconds until a new
        /// lease can be acquired.
        ///
        /// A lease that has been broken can also be released.  A client can
        /// immediately acquire a blob or container lease that has been
        /// released.
        ///
        /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/lease-container" />.
        /// </summary>
        /// <param name="breakPeriodInSeconds">
        /// Specifies the proposed duration the lease should continue before
        /// it is broken, in seconds, between 0 and 60.  This break period is
        /// only used if it is shorter than the time remaining on the lease.
        /// If longer, the time remaining on the lease is used.  A new lease
        /// will not be available before the break period has expired, but the
        /// lease may be held for longer than the break period.  If this value
        /// is not provided, a fixed-duration lease breaks after the remaining
        /// lease period elapses, and an infinite lease breaks immediately.
        /// </param>
        /// <param name="httpAccessConditions">
        /// Optional <see cref="HttpAccessConditions"/> to add
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
        /// A <see cref="StorageRequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        private async Task<Response<Lease>> BreakInternal(
            int? breakPeriodInSeconds,
            HttpAccessConditions? httpAccessConditions,
            bool async,
            CancellationToken cancellationToken)
        {
            this.EnsureClient();
            using (this.Pipeline.BeginLoggingScope(nameof(LeaseClient)))
            {
                this.Pipeline.LogMethodEnter(
                    nameof(LeaseClient),
                    message:
                    $"{nameof(this.Uri)}: {this.Uri}\n" +
                    $"{nameof(breakPeriodInSeconds)}: {breakPeriodInSeconds}\n" +
                    $"{nameof(httpAccessConditions)}: {httpAccessConditions}");
                try
                {
                    if (this.BlobClient != null)
                    {
                        return (await BlobRestClient.Blob.BreakLeaseAsync(
                            this.Pipeline,
                            this.Uri,
                            breakPeriod: breakPeriodInSeconds,
                            ifModifiedSince: httpAccessConditions?.IfModifiedSince,
                            ifUnmodifiedSince: httpAccessConditions?.IfUnmodifiedSince,
                            ifMatch: httpAccessConditions?.IfMatch,
                            ifNoneMatch: httpAccessConditions?.IfNoneMatch,
                            async: async,
                            operationName: Constants.Blob.Lease.BreakOperationName,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false))
                            .ToLease();
                    }
                    else
                    {
                        if (httpAccessConditions?.IfMatch != default || httpAccessConditions?.IfNoneMatch != default)
                        {
                            throw BlobErrors.BlobConditionsMustBeDefault(
                                nameof(HttpAccessConditions.IfMatch),
                                nameof(HttpAccessConditions.IfNoneMatch));
                        }
                        return (await BlobRestClient.Container.BreakLeaseAsync(
                            this.Pipeline,
                            this.Uri,
                            breakPeriod: breakPeriodInSeconds,
                            ifModifiedSince: httpAccessConditions?.IfModifiedSince,
                            ifUnmodifiedSince: httpAccessConditions?.IfUnmodifiedSince,
                            async: async,
                            cancellationToken: cancellationToken)
                            .ConfigureAwait(false))
                            .ToLease();
                    }
                }
                catch (Exception ex)
                {
                    this.Pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this.Pipeline.LogMethodExit(nameof(LeaseClient));
                }
            }
        }
        #endregion Break
    }

    /// <summary>
    /// Add easy to discover methods to <see cref="BlobContainerClient"/> and
    /// <see cref="BlobClient"/> for easily creating <see cref="LeaseClient"/>
    /// instances.
    /// </summary>
    public static partial class SpecializedBlobExtensions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeaseClient"/> class.
        /// </summary>
        /// <param name="client">
        /// A <see cref="BlobClient"/> representing the blob being leased.
        /// </param>
        /// <param name="leaseId">
        /// An optional lease ID.  If no lease ID is provided, a random lease
        /// ID will be created.
        /// </param>
        public static LeaseClient GetLeaseClient(
            this BlobBaseClient client,
            string leaseId = null) =>
            new LeaseClient(client, leaseId);

        /// <summary>
        /// Initializes a new instance of the <see cref="LeaseClient"/> class.
        /// </summary>
        /// <param name="client">
        /// A <see cref="BlobContainerClient"/> representing the container
        /// being leased.
        /// </param>
        /// <param name="leaseId">
        /// An optional lease ID.  If no lease ID is provided, a random lease
        /// ID will be created.
        /// </param>
        public static LeaseClient GetLeaseClient(
            this BlobContainerClient client,
            string leaseId = null) =>
            new LeaseClient(client, leaseId);
    }
}
