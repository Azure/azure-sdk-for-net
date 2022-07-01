// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// BlobChangeFeedModelFactory for building mock objects.
    /// </summary>
    public static class BlobChangeFeedModelFactory
    {
        /// <summary>
        /// Creates a new BlobChangeFeedEvent instance for mocking.
        /// </summary>
        public static BlobChangeFeedEvent BlobChangeFeedEvent(
            string topic,
            string subject,
            BlobChangeFeedEventType eventType,
            DateTimeOffset eventTime,
            Guid id,
            BlobChangeFeedEventData eventData,
            long dataVersion,
            string metadataVersion)
            => new BlobChangeFeedEvent
            {
                Topic = topic,
                Subject = subject,
                EventType = eventType,
                EventTime = eventTime,
                Id = id,
                EventData = eventData,
                SchemaVersion = dataVersion,
                MetadataVersion = metadataVersion
            };

        /// <summary>
        /// Creates a new BlobChangeFeedEventData instance for mocking.
        /// </summary>
        public static BlobChangeFeedEventData BlobChangeFeedEventData(
            string blobOperationName,
            string clientRequestId,
            Guid requestId,
            ETag eTag,
            string contentType,
            long contentLength,
            BlobType blobType,
            string blobVersion,
            string containerVersion,
            AccessTier? blobAccessTier,
            long contentOffset,
            Uri destinationUri,
            Uri sourceUri,
            Uri uri,
            bool recursive,
            string sequencer,
            ChangeFeedEventPreviousInfo previousInfo,
            string snapshot,
            Dictionary<string, BlobPropertyChange> updatedBlobProperties,
            BlobOperationResult asyncOperationInfo,
            BlobTagsChange updatedBlobTags)
            => new BlobChangeFeedEventData
            {
                BlobOperationName = blobOperationName,
                ClientRequestId = clientRequestId,
                RequestId = requestId,
                ETag = eTag,
                ContentType = contentType,
                ContentLength = contentLength,
                BlobType = blobType,
                BlobVersion = blobVersion,
                ContainerVersion = containerVersion,
                BlobAccessTier = blobAccessTier,
                ContentOffset = contentOffset,
                DestinationUri = destinationUri,
                SourceUri = sourceUri,
                Uri = uri,
                Recursive = recursive,
                Sequencer = sequencer,
                PreviousInfo = previousInfo,
                Snapshot = snapshot,
                UpdatedBlobProperties = updatedBlobProperties,
                LongRunningOperationInfo = asyncOperationInfo,
                UpdatedBlobTags = updatedBlobTags
            };

        /// <summary>
        /// Creates a ChangeFeedEventPreviousInfo for mocking.
        /// </summary>
        public static ChangeFeedEventPreviousInfo ChangeFeedEventPreviousInfo(
            string softDeleteSnapshot,
            bool wasBlobSoftDeleted,
            string blobVersion,
            string lastVersion,
            AccessTier? previousTier)
            => new ChangeFeedEventPreviousInfo
            {
                SoftDeleteSnapshot = softDeleteSnapshot,
                WasBlobSoftDeleted = wasBlobSoftDeleted,
                NewBlobVersion = blobVersion,
                OldBlobVersion = lastVersion,
                PreviousTier = previousTier
            };

        /// <summary>
        /// Creates a BlobChangeFeedEventUpdatedBlobProperty for mocking.
        /// </summary>
        public static BlobPropertyChange BlobChangeFeedEventUpdatedBlobProperty(
            string propertyName,
            string previousValue,
            string newValue)
            => new BlobPropertyChange
            {
                PropertyName = propertyName,
                OldValue = previousValue,
                NewValue = newValue
            };

        /// <summary>
        /// Creates a BlobChangeFeedEventAsyncOperationInfo for mocking.
        /// </summary>
        public static BlobOperationResult BlobChangeFeedEventAsyncOperationInfo(
            AccessTier? destinationAccessTier,
            bool wasAsyncOperation,
            string copyId)
            => new BlobOperationResult
            {
                DestinationAccessTier = destinationAccessTier,
                IsAsync = wasAsyncOperation,
                CopyId = copyId
            };

        /// <summary>
        /// Creates a BlobChangeFeedEventUpdatedBlobTags for mocking.
        /// </summary>
        public static BlobTagsChange BlobChangeFeedEventUpdatedBlobTags(
            Dictionary<string, string> previousTags,
            Dictionary<string, string> newTags)
            => new BlobTagsChange
            {
                OldTags = previousTags,
                NewTags = newTags
            };
    }
}
