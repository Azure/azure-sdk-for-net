// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Batch;
using Azure.Storage.Blobs.Batch.Models;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Shared;

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// A <see cref="BlobBatch"/> allows you to batch multiple Azure Storage
    /// operations in a single request via <see cref="BlobBatchClient.SubmitBatch"/>.
    ///
    /// For more information, see
    /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/blob-batch">
    /// Blob Batch</see>.
    /// </summary>
    public class BlobBatch : IDisposable
    {
        /// <summary>
        /// The number of pending requests in the batch.
        /// </summary>
        public int RequestCount => _messages.Count;

        /// <summary>
        /// If this BlobBatch is container scoped.
        /// </summary>
        private readonly bool _isContainerScoped;

        /// <summary>
        /// If this BlobBatch is container scoped.
        /// </summary>
        internal bool IsContainerScoped => _isContainerScoped;

        /// <summary>
        /// The <see cref="BlobBatchClient"/> associated with this batch.  It
        /// provides the Uri, BatchOperationPipeline, etc.
        /// </summary>
        private readonly BlobBatchClient _client;

        /// <summary>
        /// Storage requires each batch request to contain the same type of
        /// operation.
        /// </summary>
        private BlobBatchOperationType? _operationType;

        /// <summary>
        /// The list of messages that will be sent as part of this batch.
        /// </summary>
        private readonly IList<HttpMessage> _messages = new List<HttpMessage>();

        /// <summary>
        /// A value indicating whether the batch has already been submitted.
        /// </summary>
        internal bool Submitted { get; private set; }

        /// <summary>
        /// <see cref="BlobRestClient"/>.
        /// </summary>
        private readonly BlobRestClient _blobRestClient;

        /// <summary>
        /// <see cref="BlobRestClient"/>.
        /// </summary>
        internal virtual BlobRestClient BlobRestClient => _blobRestClient;

        /// <summary>
        /// The <see cref="ClientDiagnostics"/> instance used to create diagnostic scopes
        /// every request.
        /// </summary>;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// True when batch is disposed, false otherwise
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// The <see cref="ClientDiagnostics"/> instance used to create diagnostic scopes
        /// every request.
        /// </summary>
        internal virtual ClientDiagnostics ClientDiagnostics => _clientDiagnostics;

        /// <summary>
        /// Creates a new instance of the <see cref="BlobBatch"/> for mocking.
        /// </summary>
        protected BlobBatch()
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="BlobBatch"/> class.
        /// </summary>
        /// <param name="client">
        /// The <see cref="BlobBatchClient"/> associated with this batch.
        /// </param>
        public BlobBatch(BlobBatchClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _isContainerScoped = client.IsContainerScoped;
            _clientDiagnostics = client.ClientDiagnostics;

            BlobUriBuilder uriBuilder = new BlobUriBuilder(client.Uri)
            {
                BlobContainerName = null,
                BlobName = null
            };

            _blobRestClient = new BlobRestClient(
                clientDiagnostics: _client.ClientDiagnostics,
                pipeline: _client.Pipeline,
                url: uriBuilder.ToUri().AbsoluteUri,
                version: _client.Version.ToVersionString());
        }

        /// <summary>
        /// Gets the list of messages to submit as part of this batch.
        ///
        /// Note that calling this method marks the batch as submitted and no
        /// further operations can be added.
        /// </summary>
        /// <returns>
        /// The list of messages to submit as part of this batch.
        /// </returns>
        internal IList<HttpMessage> GetMessagesToSubmit()
        {
            Submitted = true;
            return _messages;
        }

        /// <summary>
        /// Verify whether the <paramref name="client"/> is the batch client
        /// associated with this batch.
        /// </summary>
        /// <param name="client">The BlobBatchClient to check.</param>
        internal bool IsAssociatedClient(BlobBatchClient client) =>
            _client == client;

        /// <summary>
        /// Set the batch operation type or throw if not allowed.
        /// </summary>
        /// <param name="operationType">
        /// The type of operation to perform.
        /// </param>
        private void SetBatchOperationType(BlobBatchOperationType operationType)
        {
            if (Submitted)
            {
                throw BatchErrors.BatchAlreadySubmitted();
            }
            else if (_operationType != null && _operationType != operationType)
            {
                throw BatchErrors.OnlyHomogenousOperationsAllowed(_operationType.Value);
            }
            _operationType = operationType;
        }

        #region DeleteBlob
        /// <summary>
        /// The <see cref="DeleteBlob(string, string, DeleteSnapshotsOption, BlobRequestConditions)"/>
        /// operation marks the specified blob or snapshot for  deletion. The
        /// blob is later deleted during garbage collection which could take several minutes.
        ///
        /// Note that in order to delete a blob, you must delete all of its
        /// snapshots. You can delete both at the same time using
        /// <see cref="DeleteSnapshotsOption.IncludeSnapshots"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-blob">Delete Blob</see>.
        /// </summary>
        /// <param name="blobContainerName">
        /// The name of the container containing the blob to delete.
        /// </param>
        /// <param name="blobName">
        /// The name of the blob to delete.
        /// </param>
        /// <param name="snapshotsOption">
        /// Specifies options for deleting blob snapshots.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// deleting this blob.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully marking for deletion.  The response
        /// cannot be used until the batch has been submitted with
        /// <see cref="BlobBatchClient.SubmitBatchAsync"/>.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response DeleteBlob(
            string blobContainerName,
            string blobName,
            DeleteSnapshotsOption snapshotsOption,
            BlobRequestConditions conditions)
        {
            DeleteBlobOptions options = null;
            if (snapshotsOption != DeleteSnapshotsOption.None ||
                conditions != null)
            {
                options = new()
                {
                    SnapshotsOption = snapshotsOption,
                    Conditions = conditions,
                };
            }
            return DeleteBlob(blobContainerName, blobName, options);
        }

        /// <summary>
        /// The <see cref="DeleteBlob(string, string, DeleteBlobOptions)"/>
        /// operation marks the specified blob or snapshot for  deletion. The
        /// blob is later deleted during garbage collection which could take several minutes.
        ///
        /// Note that in order to delete a blob, you must delete all of its
        /// snapshots. You can delete both at the same time using
        /// <see cref="DeleteSnapshotsOption.IncludeSnapshots"/> in <paramref name="options"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-blob">Delete Blob</see>.
        /// </summary>
        /// <param name="blobContainerName">
        /// The name of the container containing the blob to delete.
        /// </param>
        /// <param name="blobName">
        /// The name of the blob to delete.
        /// </param>
        /// <param name="options">
        /// Optional parameters for the delete options.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully marking for deletion.  The response
        /// cannot be used until the batch has been submitted with
        /// <see cref="BlobBatchClient.SubmitBatchAsync"/>.
        /// </returns>
        public virtual Response DeleteBlob(
            string blobContainerName,
            string blobName,
            DeleteBlobOptions options = default)
        {
            SetBatchOperationType(BlobBatchOperationType.Delete);

            HttpMessage message = BlobRestClient.CreateDeleteRequest(
                containerName: blobContainerName,
                blob: blobName.EscapePath(),
                versionId: options?.VersionID,
                timeout: null,
                leaseId: options?.Conditions?.LeaseId,
                deleteSnapshots: options?.SnapshotsOption.ToDeleteSnapshotsOptionType(),
                ifModifiedSince: options?.Conditions?.IfModifiedSince,
                ifUnmodifiedSince: options?.Conditions?.IfUnmodifiedSince,
                ifMatch: options?.Conditions?.IfMatch?.ToString(),
                ifNoneMatch: options?.Conditions?.IfNoneMatch?.ToString(),
                ifTags: options?.Conditions?.TagConditions,
                blobDeleteType: null);

            _messages.Add(message);

            return new DelayedResponse(
                message,
                response =>
                {
                    switch (response.Status)
                    {
                        case 202:
                            BlobDeleteHeaders blobDeleteHeaders = new BlobDeleteHeaders(response);
                            return ResponseWithHeaders.FromValue(blobDeleteHeaders, response);
                        default:
                            throw new RequestFailedException(response);
                    }
                });
        }

        /// <summary>
        /// The <see cref="DeleteBlob(Uri, DeleteSnapshotsOption, BlobRequestConditions)"/>
        /// operation marks the specified blob or snapshot for deletion. The
        /// blob is later deleted during garbage collection which could take several minutes.
        ///
        /// Note that in order to delete a blob, you must delete all of its
        /// snapshots. You can delete both at the same time using
        /// <see cref="DeleteSnapshotsOption.IncludeSnapshots"/>.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/delete-blob">Delete Blob</see>.
        /// </summary>
        /// <param name="blobUri">
        /// The blob to delete's primary <see cref="Uri"/> endpoint.
        /// </param>
        /// <param name="snapshotsOption">
        /// Specifies options for deleting blob snapshots.
        /// </param>
        /// <param name="conditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// deleting this blob.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully marking for deletion.  The response
        /// cannot be used until the batch has been submitted with
        /// <see cref="BlobBatchClient.SubmitBatchAsync"/>.
        /// </returns>
        public virtual Response DeleteBlob(
            Uri blobUri,
            DeleteSnapshotsOption snapshotsOption = default,
            BlobRequestConditions conditions = default)
        {
            BlobUriBuilder uriBuilder = new BlobUriBuilder(blobUri);

            return DeleteBlob(
                blobContainerName: uriBuilder.BlobContainerName,
                blobName: uriBuilder.BlobName,
                snapshotsOption: snapshotsOption,
                conditions: conditions);
        }
        #endregion DeleteBlob

        #region SetBlobAccessTier
        /// <summary>
        /// The <see cref="SetBlobAccessTier(string, string, AccessTier, RehydratePriority?, BlobRequestConditions)"/>
        /// operation sets the tier on a blob.  The operation is allowed on
        /// block blobs in a blob storage or general purpose v2 account.
        ///
        /// A block blob's tier determines Hot/Cool/Archive storage type.  This
        /// operation does not update the blob's ETag.  For detailed
        /// information about block blob level tiering see
        /// <see href="https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blob-storage-tiers">
        /// Blob Storage Tiers</see>.
        /// </summary>
        /// <param name="blobContainerName">
        /// The name of the container containing the blob to set the tier of.
        /// </param>
        /// <param name="blobName">
        /// The name of the blob to set the tier of.
        /// </param>
        /// <param name="accessTier">
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="leaseAccessConditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// setting the access tier.
        /// </param>
        /// <param name="rehydratePriority">
        /// Optional <see cref="RehydratePriority"/>
        /// Indicates the priority with which to rehydrate an archived blob.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully deleting.  The response
        /// cannot be used until the batch has been submitted with
        /// <see cref="BlobBatchClient.SubmitBatchAsync"/>.
        /// </returns>
        public virtual Response SetBlobAccessTier(
            string blobContainerName,
            string blobName,
            AccessTier accessTier,
            RehydratePriority? rehydratePriority = default,
            BlobRequestConditions leaseAccessConditions = default)
        {
            SetBatchOperationType(BlobBatchOperationType.SetAccessTier);

            HttpMessage message = BlobRestClient.CreateSetAccessTierRequest(
                containerName: blobContainerName,
                blob: blobName.EscapePath(),
                accessTier.ToBatchAccessTier(),
                versionId: null,
                timeout: null,
                rehydratePriority: rehydratePriority.ToBatchRehydratePriority(),
                leaseId: leaseAccessConditions?.LeaseId,
                ifTags: leaseAccessConditions?.TagConditions);

            _messages.Add(message);

            return new DelayedResponse(
                message,
                response =>
                {
                    switch (response.Status)
                    {
                        case 200:
                        case 202:
                            BlobSetAccessTierHeaders blobSetAccessTierHeaders = new BlobSetAccessTierHeaders(response);
                            return ResponseWithHeaders.FromValue(blobSetAccessTierHeaders, response);
                        default:
                            throw new RequestFailedException(response);
                    }
                });
        }

        /// <summary>
        /// The <see cref="SetBlobAccessTier(Uri, AccessTier, RehydratePriority?, BlobRequestConditions)"/>
        /// operation sets the tier on a blob.  The operation is allowed on
        /// block blobs in a blob storage or general purpose v2 account.
        ///
        /// A block blob's tier determines Hot/Cool/Archive storage type.  This
        /// operation does not update the blob's ETag.  For detailed
        /// information about block blob level tiering
        /// <see href="https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blob-storage-tiers">
        /// Blob Storage Tiers</see>.
        ///
        /// </summary>
        /// <param name="blobUri">
        /// The blob's primary <see cref="Uri"/> endpoint.
        /// </param>
        /// <param name="accessTier">
        /// Indicates the tier to be set on the blob.
        /// </param>
        /// <param name="rehydratePriority">
        /// Optional <see cref="RehydratePriority"/>
        /// Indicates the priority with which to rehydrate an archived blob.
        /// </param>
        /// <param name="leaseAccessConditions">
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// setting the access tier.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> on successfully deleting.  The response
        /// cannot be used until the batch has been submitted with
        /// <see cref="BlobBatchClient.SubmitBatchAsync"/>.
        /// </returns>
        public virtual Response SetBlobAccessTier(
            Uri blobUri,
            AccessTier accessTier,
            RehydratePriority? rehydratePriority = default,
            BlobRequestConditions leaseAccessConditions = default)
        {
            BlobUriBuilder uriBuilder = new BlobUriBuilder(blobUri);

            return SetBlobAccessTier(
                blobContainerName: uriBuilder.BlobContainerName,
                blobName: uriBuilder.BlobName,
                accessTier: accessTier,
                rehydratePriority: rehydratePriority,
                leaseAccessConditions: leaseAccessConditions);
        }

        /// <summary>
        /// Dispose all messages in the batch.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            if (!_disposed)
            {
                _disposed = true;
                foreach (HttpMessage message in _messages)
                {
                    message.Dispose();
                }
            }
        }
        #endregion SetBlobAccessTier
    }
}
