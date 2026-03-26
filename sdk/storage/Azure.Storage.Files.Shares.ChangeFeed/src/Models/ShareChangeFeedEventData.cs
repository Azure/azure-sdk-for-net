// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    public class ShareChangeFeedEventData
    {
        public string FileId { get; internal set; }
        public string ParentFileId { get; internal set; }
        public ETag? ETag { get; internal set; }
        public string FileName { get; internal set; }
        public string FullFilePath { get; internal set; }
        public ShareChangeFeedEventIdentity Identity { get; internal set; }
        public string Description { get; internal set; }
        public string Initiator { get; internal set; }
        public bool IsDirectory { get; internal set; }

        internal ShareChangeFeedEventData(Dictionary<string, object> record)
        {
            if (record.TryGetValue("FileId", out object fileId))
                FileId = (string)fileId;
            if (record.TryGetValue("ParentFileId", out object parentFileId))
                ParentFileId = (string)parentFileId;
            if (record.TryGetValue("Etag", out object etag) && etag is string etagStr && !string.IsNullOrEmpty(etagStr))
                ETag = new ETag(etagStr);
            if (record.TryGetValue("FileName", out object fileName))
                FileName = (string)fileName;
            if (record.TryGetValue("FullFilePath", out object fullFilePath))
                FullFilePath = (string)fullFilePath;
            if (record.TryGetValue("Identity", out object identity) && identity is Dictionary<string, object> identityDict)
                Identity = new ShareChangeFeedEventIdentity(identityDict);
            if (record.TryGetValue("Description", out object description))
                Description = (string)description;
            if (record.TryGetValue("Initiator", out object initiator))
                Initiator = (string)initiator;
            if (record.TryGetValue("IsDirectory", out object isDirectory))
            {
                if (isDirectory is string isDirStr)
                    IsDirectory = isDirStr.Equals("true", StringComparison.OrdinalIgnoreCase);
                else if (isDirectory is bool isDirBool)
                    IsDirectory = isDirBool;
            }
        }

        internal ShareChangeFeedEventData() { }
    }
}
