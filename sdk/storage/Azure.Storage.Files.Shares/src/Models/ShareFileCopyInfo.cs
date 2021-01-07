// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// A listed Azure Storage handle item.
    /// </summary>
    public class ShareFileCopyInfo
    {
        /// <summary>
        /// XSMB service handle ID
        /// </summary>
        public string HandleId { get; internal set; }

        /// <summary>
        /// File or directory name including full path starting from share root
        /// </summary>
        public string Path { get; internal set; }

        /// <summary>
        /// FileId uniquely identifies the file or directory.
        /// </summary>
        public string FileId { get; internal set; }

        /// <summary>
        /// ParentId uniquely identifies the parent directory of the object.
        /// </summary>
        public string ParentId { get; internal set; }

        /// <summary>
        /// SMB session ID in context of which the file handle was opened
        /// </summary>
        public string SessionId { get; internal set; }

        /// <summary>
        /// Client IP that opened the handle
        /// </summary>
        public string ClientIp { get; internal set; }

        /// <summary>
        /// Time when the session that previously opened the handle has last been reconnected. (UTC)
        /// </summary>
        public DateTimeOffset? OpenedOn { get; internal set; }

        /// <summary>
        /// Time handle was last connected to (UTC)
        /// </summary>
        public DateTimeOffset? LastReconnectedOn { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of ShareFileHandle instances.
        /// You can use ShareModelFactory.ShareFileHandle instead.
        /// </summary>
        internal ShareFileCopyInfo() { }
    }
}
