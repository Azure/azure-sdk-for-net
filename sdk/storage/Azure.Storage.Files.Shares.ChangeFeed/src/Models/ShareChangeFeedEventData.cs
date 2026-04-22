// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Contains the detailed data payload of a <see cref="ShareChangeFeedEvent"/>,
    /// including file identifiers, paths, identity, and metadata about the affected resource.
    /// </summary>
    public class ShareChangeFeedEventData
    {
        /// <summary>
        /// The unique file ID of the affected file or directory within the share.
        /// </summary>
        public string FileId { get; internal set; }

        /// <summary>
        /// The unique file ID of the parent directory containing the affected file or directory.
        /// </summary>
        public string ParentFileId { get; internal set; }

        /// <summary>
        /// The ETag of the file or directory after the operation, if available.
        /// </summary>
        public ETag? ETag { get; internal set; }

        /// <summary>
        /// The name of the affected file or directory (without its parent path).
        /// </summary>
        public string FileName { get; internal set; }

        /// <summary>
        /// The full path of the affected file or directory relative to the share root.
        /// </summary>
        public string FullFilePath { get; internal set; }

        /// <summary>
        /// The identity of the caller who performed the operation, including Entra and SID information.
        /// </summary>
        public ShareChangeFeedEventIdentity Identity { get; internal set; }

        /// <summary>
        /// An optional human-readable description of the event.
        /// </summary>
        public string Description { get; internal set; }

        /// <summary>
        /// The initiator of the operation (e.g., the service or user agent).
        /// </summary>
        public string Initiator { get; internal set; }

        /// <summary>
        /// Indicates whether the affected resource is a directory (<c>true</c>) or a file (<c>false</c>).
        /// </summary>
        public bool IsDirectory { get; internal set; }

        /// <summary>
        /// Initializes a new <see cref="ShareChangeFeedEventData"/> from a deserialized Avro data dictionary.
        /// </summary>
        /// <param name="record">The dictionary containing event data fields.</param>
        internal ShareChangeFeedEventData(Dictionary<string, object> record)
        {
            if (record.TryGetValue(Constants.FilesChangeFeed.EventData.FileId, out object fileId))
                FileId = (string)fileId;
            if (record.TryGetValue(Constants.FilesChangeFeed.EventData.ParentFileId, out object parentFileId))
                ParentFileId = (string)parentFileId;
            if (record.TryGetValue(Constants.FilesChangeFeed.EventData.Etag, out object etag) && etag is string etagStr && !string.IsNullOrEmpty(etagStr))
                ETag = new ETag(etagStr);
            if (record.TryGetValue(Constants.FilesChangeFeed.EventData.FileName, out object fileName))
                FileName = (string)fileName;
            if (record.TryGetValue(Constants.FilesChangeFeed.EventData.FullFilePath, out object fullFilePath))
                FullFilePath = (string)fullFilePath;
            if (record.TryGetValue(Constants.FilesChangeFeed.EventData.Identity, out object identity) && identity is Dictionary<string, object> identityDict)
                Identity = new ShareChangeFeedEventIdentity(identityDict);
            if (record.TryGetValue(Constants.FilesChangeFeed.EventData.Description, out object description))
                Description = (string)description;
            if (record.TryGetValue(Constants.FilesChangeFeed.EventData.Initiator, out object initiator))
                Initiator = (string)initiator;
            if (record.TryGetValue(Constants.FilesChangeFeed.EventData.IsDirectory, out object isDirectory))
            {
                if (isDirectory is string isDirStr)
                    IsDirectory = isDirStr.Equals("true", StringComparison.OrdinalIgnoreCase);
                else if (isDirectory is bool isDirBool)
                    IsDirectory = isDirBool;
            }
        }

        /// <summary>
        /// Initializes a new <see cref="ShareChangeFeedEventData"/> for mocking purposes.
        /// </summary>
        internal ShareChangeFeedEventData() { }
    }
}
