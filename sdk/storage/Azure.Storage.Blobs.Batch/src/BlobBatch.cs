// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Storage.Blobs.Models;

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
        public BlobBatch(BlobBatchClient client) =>
            _client = client ?? throw new ArgumentNullException(nameof(client));

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
        /// blob is later deleted during garbage collection.
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
        /// A <see cref="Response"/> on successfully deleting.  The response
        /// cannot be used until the batch has been submitted with
        /// <see cref="BlobBatchClient.SubmitBatchAsync"/>.
        /// </returns>
        public virtual Response DeleteBlob(
            string blobContainerName,
            string blobName,
            DeleteSnapshotsOption snapshotsOption = default,
            BlobRequestConditions conditions = default)
        {
            var blobUri = new BlobUriBuilder(_client.Uri)
            {
                BlobContainerName = blobContainerName,
                BlobName = blobName
            };
            return DeleteBlob(
                blobUri.ToUri(),
                snapshotsOption,
                conditions);
        }

        /// <summary>
        /// The <see cref="DeleteBlob(Uri, DeleteSnapshotsOption, BlobRequestConditions)"/>
        /// operation marks the specified blob or snapshot for deletion. The
        /// blob is later deleted during garbage collection.
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
        /// A <see cref="Response"/> on successfully deleting.  The response
        /// cannot be used until the batch has been submitted with
        /// <see cref="BlobBatchClient.SubmitBatchAsync"/>.
        /// </returns>
        public virtual Response DeleteBlob(
            Uri blobUri,
            DeleteSnapshotsOption snapshotsOption = default,
            BlobRequestConditions conditions = default)
        {
            SetBatchOperationType(BlobBatchOperationType.Delete);
            HttpMessage message = BatchRestClient.Blob.DeleteAsync_CreateMessage(
                _client.BatchOperationPipeline,
                blobUri,
                version: _client.Version.ToVersionString(),
                deleteSnapshots: snapshotsOption == DeleteSnapshotsOption.None ? null : (DeleteSnapshotsOption?)snapshotsOption,
                leaseId: conditions?.LeaseId,
                ifModifiedSince: conditions?.IfModifiedSince,
                ifUnmodifiedSince: conditions?.IfUnmodifiedSince,
                ifMatch: conditions?.IfMatch,
                ifNoneMatch: conditions?.IfNoneMatch);
            _messages.Add(message);
            return new DelayedResponse(message, response => BatchRestClient.Blob.DeleteAsync_CreateResponse(_client.ClientDiagnostics, response));
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
            var blobUri = new BlobUriBuilder(_client.Uri)
            {
                BlobContainerName = blobContainerName,
                BlobName = blobName
            };
            return SetBlobAccessTier(
                blobUri.ToUri(),
                accessTier,
                rehydratePriority,
                leaseAccessConditions);
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
            SetBatchOperationType(BlobBatchOperationType.SetAccessTier);
            HttpMessage message = BatchRestClient.Blob.SetAccessTierAsync_CreateMessage(
                _client.BatchOperationPipeline,
                blobUri,
                tier: accessTier,
                version: _client.Version.ToVersionString(),
                rehydratePriority: rehydratePriority,
                leaseId: leaseAccessConditions?.LeaseId);
            _messages.Add(message);
            return new DelayedResponse(message, response => BatchRestClient.Blob.SetAccessTierAsync_CreateResponse(_client.ClientDiagnostics, response));
        }

        /// <summary>
        /// Dispose all messages in the batch.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            foreach (HttpMessage message in _messages) {
                message.Dispose();
            }
        }
        #endregion SetBlobAccessTier
    }
}
