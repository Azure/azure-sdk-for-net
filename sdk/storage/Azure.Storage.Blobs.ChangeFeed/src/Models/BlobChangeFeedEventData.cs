// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
            record.TryGetValue(Constants.ChangeFeed.EventData.BlobVersionLower, out object blobVersionObject);
            BlobVersion = (string)blobVersionObject;
            record.TryGetValue(Constants.ChangeFeed.EventData.ContainerVersion, out object containerVersionObject);
            ContainerVersion = (string)containerVersionObject;
            record.TryGetValue(Constants.ChangeFeed.EventData.BlobTier, out object blobTierObject);
            if (blobTierObject != null)
            {
                BlobAccessTier = new AccessTier((string)blobTierObject);
            }
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
            record.TryGetValue(Constants.ChangeFeed.EventData.PreviousInfo, out object previousInfoObject);
            PreviousInfo = ExtractPreviousInfo(record);
            record.TryGetValue(Constants.ChangeFeed.EventData.Snapshot, out object snapshotObject);
            Snapshot = (string)snapshotObject;
            UpdatedBlobProperties = ExtractBlobProperties(record);
            LongRunningOperationInfo = ExtractAsyncOperationInfo(record);
            UpdatedBlobTags = ExtractUpdatedBlobTags(record);
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
        public ChangeFeedEventPreviousInfo PreviousInfo { get; internal set; }

        /// <summary>
        /// The Snapshot associated with the event.
        /// </summary>
        public string Snapshot { get; internal set; }

        /// <summary>
        /// Blob properties that were updated during this event.
        /// </summary>
        public Dictionary<string, BlobPropertyChange> UpdatedBlobProperties { get; internal set; }

        /// <summary>
        /// AsyncOperationInfo.
        /// </summary>
        public BlobOperationResult LongRunningOperationInfo { get; internal set; }

        /// <summary>
        /// Blob tags that were updated during this event.
        /// </summary>
        public BlobTagsChange UpdatedBlobTags { get; internal set; }

        private static ChangeFeedEventPreviousInfo ExtractPreviousInfo(Dictionary<string, object> recordDictionary)
        {
            // Note that these property keys may be present in the dictionary, but with a value of null.
            // This is why we need to do the null check, instead of if(Dictionary.TryGetValue()).
            recordDictionary.TryGetValue(Constants.ChangeFeed.EventData.PreviousInfo, out object previousInfoObject);
            if (previousInfoObject == null)
            {
                return null;
            }

            Dictionary<string, object> previousInfoDictionary = (Dictionary<string, object>)previousInfoObject;

            ChangeFeedEventPreviousInfo previousInfo = new ChangeFeedEventPreviousInfo();

            previousInfoDictionary.TryGetValue(Constants.ChangeFeed.EventData.SoftDeletedSnapshot, out object softDeletedSnapshotObject);
            previousInfo.SoftDeleteSnapshot = (string)softDeletedSnapshotObject;

            previousInfoDictionary.TryGetValue(Constants.ChangeFeed.EventData.WasBlobSoftDeleted, out object wasBlobSoftDeletedObject);
            if (wasBlobSoftDeletedObject != null)
            {
                previousInfo.WasBlobSoftDeleted = bool.Parse((string)wasBlobSoftDeletedObject);
            }

            previousInfoDictionary.TryGetValue(Constants.ChangeFeed.EventData.BlobVersion, out object blobVersionObject);
            previousInfo.NewBlobVersion = (string)blobVersionObject;

            previousInfoDictionary.TryGetValue(Constants.ChangeFeed.EventData.LastVersion, out object lastVersionObject);
            previousInfo.OldBlobVersion = (string)lastVersionObject;

            previousInfoDictionary.TryGetValue(Constants.ChangeFeed.EventData.PreviousTier, out object previousTierObject);
            if (previousTierObject != null)
            {
                previousInfo.PreviousTier = new AccessTier((string)previousTierObject);
            }

            return previousInfo;
        }

        private static Dictionary<string, BlobPropertyChange> ExtractBlobProperties(
            Dictionary<string, object> recordDictionary)
        {
            // Note that these property keys may be present in the dictionary, but with a value of null.
            // This is why we need to do the null check, instead of if(Dictionary.TryGetValue()).
            recordDictionary.TryGetValue(Constants.ChangeFeed.EventData.BlobPropertiesUpdated, out object blobPropertiesUpdatedObject);
            if (blobPropertiesUpdatedObject == null)
            {
                return null;
            }

            Dictionary<string, object> updatedPropertiesDictionary = (Dictionary<string, object>)blobPropertiesUpdatedObject;

            Dictionary<string, BlobPropertyChange> result = new Dictionary<string, BlobPropertyChange>();

            foreach (KeyValuePair<string, object> kvp in updatedPropertiesDictionary)
            {
                Dictionary<string, object> propertyMap = (Dictionary<string, object>)kvp.Value;
                result.Add(
                    kvp.Key,
                    new BlobPropertyChange
                    {
                        PropertyName = kvp.Key,
                        OldValue = (string)propertyMap[Constants.ChangeFeed.EventData.Previous],
                        NewValue = (string)propertyMap[Constants.ChangeFeed.EventData.Current]
                    });
            }

            return result;
        }

        private static BlobOperationResult ExtractAsyncOperationInfo(Dictionary<string, object> recordDictionary)
        {
            // Note that these property keys may be present in the dictionary, but with a value of null.
            // This is why we need to do the null check, instead of if(Dictionary.TryGetValue()).
            recordDictionary.TryGetValue(Constants.ChangeFeed.EventData.AsyncOperationInfo, out object asyncOperationInfoObject);
            if (asyncOperationInfoObject == null)
            {
                return null;
            }

            Dictionary<string, object> asyncOperationInfoDictionary = (Dictionary<string, object>)asyncOperationInfoObject;

            BlobOperationResult asyncOperationInfo = new BlobOperationResult();

            asyncOperationInfoDictionary.TryGetValue(Constants.ChangeFeed.EventData.DestinationTier, out object destinationTierObject);
            if (destinationTierObject != null)
            {
                asyncOperationInfo.DestinationAccessTier = new AccessTier((string)destinationTierObject);
            }

            asyncOperationInfoDictionary.TryGetValue(Constants.ChangeFeed.EventData.WasAsyncOperation, out object wasAsyncOperationObject);
            if (wasAsyncOperationObject != null)
            {
                asyncOperationInfo.IsAsync = bool.Parse((string)wasAsyncOperationObject);
            }

            asyncOperationInfoDictionary.TryGetValue(Constants.ChangeFeed.EventData.CopyId, out object copyIdObject);
            asyncOperationInfo.CopyId = (string)copyIdObject;

            return asyncOperationInfo;
        }

        private static BlobTagsChange ExtractUpdatedBlobTags(Dictionary<string, object> recordDictionary)
        {
            // Note that these property keys may be present in the dictionary, but with a value of null.
            // This is why we need to do the null check, instead of if(Dictionary.TryGetValue()).
            recordDictionary.TryGetValue(Constants.ChangeFeed.EventData.BlobTagsUpdated, out object blobTagsUpdatedObject);
            if (blobTagsUpdatedObject == null)
            {
                return null;
            }

            Dictionary<string, object> blobTagsUpdatedDictionary = (Dictionary<string, object>)blobTagsUpdatedObject;

            Dictionary<string, object> previousTags
                = (Dictionary<string, object>)blobTagsUpdatedDictionary[Constants.ChangeFeed.EventData.Previous];
            Dictionary<string, object> newTags
                = (Dictionary<string, object>)blobTagsUpdatedDictionary[Constants.ChangeFeed.EventData.Current];

            BlobTagsChange updatedBlobTags = new BlobTagsChange();

            updatedBlobTags.OldTags = new Dictionary<string, string>();
            updatedBlobTags.NewTags = new Dictionary<string, string>();

            foreach (KeyValuePair<string, object> kv in previousTags)
            {
                updatedBlobTags.OldTags.Add(kv.Key, (string)kv.Value);
            }

            foreach (KeyValuePair <string, object> kv in newTags)
            {
                updatedBlobTags.NewTags.Add(kv.Key, (string)kv.Value);
            }

            return updatedBlobTags;
        }
    }
}
