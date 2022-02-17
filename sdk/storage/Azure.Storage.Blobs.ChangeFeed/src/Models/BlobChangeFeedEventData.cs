// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Storage.Blobs.ChangeFeed.Models;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// BlobChangeFeedEventData.
    /// </summary>
    public class BlobChangeFeedEventData
    {
        /// <summary>
        /// Internal constructor.
        /// </summary>
        internal BlobChangeFeedEventData() { }

        internal BlobChangeFeedEventData(Dictionary<string, object> record)
        {
            BlobOperationName = new BlobOperationName((string)record[Constants.ChangeFeed.EventData.Api]);
            ClientRequestId = (string)record[Constants.ChangeFeed.EventData.ClientRequestId];
            RequestId = Guid.Parse((string)record[Constants.ChangeFeed.EventData.RequestId]);
            ETag = new ETag((string)record[Constants.ChangeFeed.EventData.Etag]);
            ContentType = (string)record[Constants.ChangeFeed.EventData.ContentType];
            ContentLength = (long)record[Constants.ChangeFeed.EventData.ContentLength];
            BlobType = ((string)record[Constants.ChangeFeed.EventData.BlobType]) switch
            {
                Constants.ChangeFeed.EventData.BlockBlob => BlobType.Block,
                Constants.ChangeFeed.EventData.PageBlob => BlobType.Page,
                Constants.ChangeFeed.EventData.AppendBlob => BlobType.Append,
                _ => default
            };
            BlobVersion = ExtractBlobVersion(record);
            ContainerVersion = ExtractContainerVersion(record);
            BlobAccessTier = ExtractBlobAccessTier(record);
            record.TryGetValue(Constants.ChangeFeed.EventData.ContentOffset, out object contentOffset);
            ContentOffset = (long?)contentOffset;
            record.TryGetValue(Constants.ChangeFeed.EventData.DestinationUrl, out object destinationUrl);
            DestinationUri = !string.IsNullOrEmpty((string)destinationUrl) ? new Uri((string)destinationUrl) : null;
            record.TryGetValue(Constants.ChangeFeed.EventData.SourceUrl, out object sourceUrl);
            SourceUri = !string.IsNullOrEmpty((string)sourceUrl) ? new Uri((string)sourceUrl) : null;
            record.TryGetValue(Constants.ChangeFeed.EventData.Url, out object url);
            Uri = !string.IsNullOrEmpty((string)url) ? new Uri((string)url) : null;
            record.TryGetValue(Constants.ChangeFeed.EventData.Recursive, out object recursive);
            Recursive = (bool?)recursive;
            Sequencer = (string)record[Constants.ChangeFeed.EventData.Sequencer];
            PreviousInfo = ExtractPreviousInfo(record);
            Snapshot = ExtractSnapshot(record);
            UpdatedBlobProperties = ExtractBlobProperties(record);
            AsyncOperationInfo = ExtractAsyncOperationInfo(record);
        }

        /// <summary>
        /// The operation that triggered the event.
        /// </summary>
        public BlobOperationName BlobOperationName { get; internal set; }

        /// <summary>
        /// A client-provided request id for the storage API operation. This id can be used to correlate to Azure Storage
        /// diagnostic logs using the "client-request-id" field in the logs, and can be provided in client requests using
        /// the "x-ms-client-request-id" header.
        /// </summary>
        public string ClientRequestId { get; internal set; }

        /// <summary>
        /// Service-generated request id for the storage API operation. Can be used to correlate to Azure Storage diagnostic
        /// logs using the "request-id-header" field in the logs and is returned from initiating API call in the
        /// 'x-ms-request-id' header.
        /// </summary>
        public Guid RequestId { get; internal set; }

        /// <summary>
        /// The value that you can use to perform operations conditionally.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// The content type specified for the blob.
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// The size of the blob in bytes.
        /// </summary>
        public long ContentLength { get; internal set; }

        /// <summary>
        /// The type of blob. Valid values are either BlockBlob or PageBlob.
        /// </summary>
        public BlobType BlobType { get; internal set; }

        /// <summary>
        /// Version of the blob.
        /// </summary>
        public string BlobVersion { get; internal set; }

        /// <summary>
        /// Version of the container the blob is in.
        /// </summary>
        public string ContainerVersion { get; internal set; }

        /// <summary>
        /// Access Tier of the blob.
        /// </summary>
        public AccessTier? BlobAccessTier { get; internal set; }

        /// <summary>
        /// The offset in bytes of a write operation taken at the point where the event-triggering application completed
        /// writing to the file.
        /// Appears only for events triggered on blob storage accounts that have a hierarchical namespace.
        /// </summary>
        public long? ContentOffset { get; internal set; }

        /// <summary>
        /// The url of the file that will exist after the operation completes. For example, if a file is renamed,
        /// the destinationUrl property contains the url of the new file name.
        /// Appears only for events triggered on blob storage accounts that have a hierarchical namespace.
        /// </summary>
        public Uri DestinationUri { get; internal set; }

        /// <summary>
        /// The url of the file that exists prior to the operation. For example, if a file is renamed, the sourceUrl
        /// contains the url of the original file name prior to the rename operation.
        /// Appears only for events triggered on blob storage accounts that have a hierarchical namespace.
        /// </summary>
        public Uri SourceUri { get; internal set; }

        /// <summary>
        /// The path to the blob.
        /// If the client uses a Blob REST API, then the url has this structure:
        /// (storage-account-name).blob.core.windows.net/(container-name)/(file-name)
        /// If the client uses a Data Lake Storage REST API, then the url has this structure:
        /// (storage-account-name).dfs.core.windows.net/(file-system-name)/(file-name).
        /// </summary>
        public Uri Uri { get; internal set; }

        /// <summary>
        /// True to perform the operation on all child directories; otherwise False.
        /// Appears only for events triggered on blob storage accounts that have a hierarchical namespace.
        /// </summary>
        public bool? Recursive { get; internal set; }

        /// <summary>
        /// An opaque string value representing the logical sequence of events for any particular blob name.
        /// Users can use standard string comparison to understand the relative sequence of two events on the same blob name.
        /// </summary>
        public string Sequencer { get; internal set; }

        /// <summary>
        /// Previous info for the blob.
        /// </summary>
        public Dictionary<string, object> PreviousInfo { get; internal set; }

        /// <summary>
        /// The Snapshot associated with the event.
        /// </summary>
        public string Snapshot { get; internal set; }

        /// <summary>
        /// Blob properties that were updated during this event.
        /// </summary>
        public Dictionary<string, BlobChangeFeedEventUpdatedBlobProperty> UpdatedBlobProperties { get; internal set; }

        /// <summary>
        /// AsyncOperationInfo.
        /// </summary>
        public ChangeFeedEventAsyncOperationInfo AsyncOperationInfo { get; internal set; }

        private static string ExtractBlobVersion(Dictionary<string, object> recordDictionary)
        {
            if (recordDictionary.TryGetValue(
                Constants.ChangeFeed.EventData.BlobVersion,
                out object blobVersionObject))
            {
                Dictionary<string, object> blobVersionDictionary = (Dictionary<string, object>)blobVersionObject;
                return (string)blobVersionDictionary[Constants.ChangeFeed.EventData.String];
            }
                return null;
        }

        private static string ExtractContainerVersion(Dictionary<string, object> recordDictionary)
        {
            if (recordDictionary.TryGetValue(
                Constants.ChangeFeed.EventData.ContainerVersion,
                out object containerVersionObject))
            {
                Dictionary<string, object> containerVersionDictionary = (Dictionary<string, object>)containerVersionObject;
                return (string)containerVersionDictionary[Constants.ChangeFeed.EventData.String];
            }
            return null;
        }

        private static AccessTier? ExtractBlobAccessTier(Dictionary<string, object> recordDictionary)
        {
            if (recordDictionary.TryGetValue(
                Constants.ChangeFeed.EventData.BlobTier,
                out object blobTierString))
            {
                return new AccessTier((string)blobTierString);
            }
            return null;
        }

        private static Dictionary<string, object> ExtractPreviousInfo(Dictionary<string, object> recordDictionary)
        {
            if (recordDictionary.TryGetValue(
                Constants.ChangeFeed.EventData.PreviousInfo,
                out object previousInfoObject))
            {
                Dictionary<string, object> previousInfoDictionary = (Dictionary<string, object>)previousInfoObject;

                 return (Dictionary<string, object>)previousInfoDictionary[Constants.ChangeFeed.EventData.Map];
            }
            return null;
        }

        private static string ExtractSnapshot(Dictionary<string, object> recordDictionary)
        {
            if (recordDictionary.TryGetValue(
                Constants.ChangeFeed.EventData.Snapshot,
                out object snapshotObject))
            {
                Dictionary<string, object> snapshotDictionary = (Dictionary<string, object>)snapshotObject;
                return (string)snapshotDictionary[Constants.ChangeFeed.EventData.String];
            }
            return null;
        }

        private static Dictionary<string, BlobChangeFeedEventUpdatedBlobProperty> ExtractBlobProperties(
            Dictionary<string, object> recordDictionary)
        {
            if (recordDictionary.TryGetValue(
                Constants.ChangeFeed.EventData.BlobPropertiesUpdated,
                out object blobPropertiesUpdatedObject))
            {
                Dictionary<string, object> updatedPropertiesDictionary = (Dictionary<string, object>)blobPropertiesUpdatedObject;
                Dictionary<string, object> mapDictionary = (Dictionary<string, object>)updatedPropertiesDictionary[Constants.ChangeFeed.EventData.Map];

                Dictionary<string, BlobChangeFeedEventUpdatedBlobProperty> result = new Dictionary<string, BlobChangeFeedEventUpdatedBlobProperty>();

                foreach (KeyValuePair<string, object> kvp in mapDictionary)
                {
                    Dictionary<string, object> propertyMap = (Dictionary<string, object>)kvp.Value;
                    result.Add(
                        kvp.Key,
                        new BlobChangeFeedEventUpdatedBlobProperty
                        {
                            PropertyName = kvp.Key,
                            PreviousValue = (string)propertyMap[Constants.ChangeFeed.EventData.Previous],
                            NewValue = (string)propertyMap[Constants.ChangeFeed.EventData.Current]
                        });
                }

                return result;
            }
            return null;
        }

        private static ChangeFeedEventAsyncOperationInfo ExtractAsyncOperationInfo(Dictionary<string, object> recordDictionary)
        {
            if (recordDictionary.TryGetValue(
                Constants.ChangeFeed.EventData.AsyncOperationInfo,
                out object asyncOperationInfoObject))
            {
                Dictionary<string, object> asyncOperationInfoDictionary = (Dictionary<string, object>)asyncOperationInfoObject;

                return new ChangeFeedEventAsyncOperationInfo
                {
                    DestinationAccessTier = new AccessTier((string)asyncOperationInfoDictionary[Constants.ChangeFeed.EventData.DestinationTier])
                };
            }
            return null;
        }
    }
}
