// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Model factory for building mock instances of Azure Files Change Feed models.
    /// </summary>
    public static class ShareChangeFeedModelFactory
    {
        /// <summary>
        /// Creates a new <see cref="ShareChangeFeedEvent"/> instance for mocking.
        /// </summary>
        public static ShareChangeFeedEvent ShareChangeFeedEvent(
            long schemaVersion = default,
            ShareChangeFeedReasonType reason = default,
            ShareChangeFeedProtocol protocol = default,
            DateTimeOffset eventTime = default,
            string id = default,
            long containerVersionNumber = default,
            ShareChangeFeedEventData eventData = default)
            => new ShareChangeFeedEvent
            {
                SchemaVersion = schemaVersion,
                Reason = reason,
                Protocol = protocol,
                EventTime = eventTime,
                Id = id,
                ContainerVersionNumber = containerVersionNumber,
                EventData = eventData,
            };

        /// <summary>
        /// Creates a new <see cref="ShareChangeFeedEventData"/> instance for mocking.
        /// </summary>
        public static ShareChangeFeedEventData ShareChangeFeedEventData(
            string fileId = default,
            string parentFileId = default,
            string newParentFileId = default,
            ETag? eTag = default,
            string fileName = default,
            string fullFilePath = default,
            string newFullFilePath = default,
            ShareChangeFeedEventIdentity identity = default,
            string description = default,
            string initiator = default,
            bool isDirectory = default)
            => new ShareChangeFeedEventData
            {
                FileId = fileId,
                ParentFileId = parentFileId,
                NewParentFileId = newParentFileId,
                ETag = eTag,
                FileName = fileName,
                FullFilePath = fullFilePath,
                NewFullFilePath = newFullFilePath,
                Identity = identity,
                Description = description,
                Initiator = initiator,
                IsDirectory = isDirectory,
            };

        /// <summary>
        /// Creates a new <see cref="ShareChangeFeedEventIdentity"/> instance for mocking.
        /// </summary>
        public static ShareChangeFeedEventIdentity ShareChangeFeedEventIdentity(
            string entraObjectId = default,
            string securityIdentifier = default)
            => new ShareChangeFeedEventIdentity
            {
                EntraObjectId = entraObjectId,
                SecurityIdentifier = securityIdentifier,
            };
    }
}
