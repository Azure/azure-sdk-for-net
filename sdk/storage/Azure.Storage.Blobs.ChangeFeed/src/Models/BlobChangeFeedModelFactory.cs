// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            string api,
            string clientRequestId,
            Guid requestId,
            ETag eTag,
            string contentType,
            long contentLength,
            BlobType blobType,
            long contentOffset,
            Uri destinationUri,
            Uri sourceUri,
            Uri uri,
            bool recursive,
            string sequencer)
            => new BlobChangeFeedEventData
            {
                BlobOperationName = api,
                ClientRequestId = clientRequestId,
                RequestId = requestId,
                ETag = eTag,
                ContentType = contentType,
                ContentLength = contentLength,
                BlobType = blobType,
                ContentOffset = contentOffset,
                DestinationUri = destinationUri,
                SourceUri = sourceUri,
                Uri = uri,
                Recursive = recursive,
                Sequencer = sequencer
            };
    }
}
