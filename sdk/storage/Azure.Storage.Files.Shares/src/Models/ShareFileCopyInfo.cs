// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ShareFileCopyInfo.
    /// </summary>
    public class ShareFileCopyInfo
    {
        /// <summary>
        /// If the copy is completed, contains the ETag of the destination file. If the copy is not complete, contains the ETag of the empty file created at the start of the copy.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date/time that the copy operation to the destination file completed.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// String identifier for this copy operation. Use with Get File or Get File Properties to check the status of this copy operation, or pass to Abort Copy File to abort a pending copy.
        /// </summary>
        public string CopyId { get; internal set; }

        /// <summary>
        /// State of the copy operation identified by x-ms-copy-id.
        /// </summary>
        public CopyStatus CopyStatus { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of ShareFileCopyInfo instances.
        /// You can use ShareModelFactory.ShareFileCopyInfo instead.
        /// </summary>
        internal ShareFileCopyInfo() { }
    }
}
