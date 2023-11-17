// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ShareFileHandle.
    /// </summary>
    public class ShareFileHandle
    {
        internal ShareFileHandle() { }

        /// <summary>
        /// Time when the session that previously opened the handle has last been reconnected. (UTC).
        /// </summary>
        public DateTimeOffset? OpenedOn { get; internal set; }

        /// <summary>
        /// Time handle was last connected to (UTC).
        /// </summary>
        public DateTimeOffset? LastReconnectedOn { get; internal set; }

        /// <summary>
        /// XSMB service handle ID.
        /// </summary>
        public string HandleId { get; }

        /// <summary>
        /// File or directory name including full path starting from share root.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// FileId uniquely identifies the file or directory.
        /// </summary>
        public string FileId { get; }

        /// <summary>
        /// ParentId uniquely identifies the parent directory of the object.
        /// </summary>
        public string ParentId { get; }

        /// <summary>
        /// SMB session ID in context of which the file handle was opened.
        /// </summary>
        public string SessionId { get; }

        /// <summary>
        /// Client IP that opened the handle.
        /// </summary>
        public string ClientIp { get; }

        /// <summary>
        /// Client Name that opened the handle.
        /// </summary>
        private string ClientName { get; }

        /// <summary>
        /// Access rights of the handle.
        /// </summary>
        public ShareFileHandleAccessRights? AccessRights { get; }

        internal ShareFileHandle(
            string handleId,
            string path,
            string fileId,
            string parentId,
            string sessionId,
            string clientIp,
            string clientName,
            DateTimeOffset? openedOn,
            DateTimeOffset? lastReconnectedOn,
            ShareFileHandleAccessRights? accessRights)
        {
            HandleId = handleId;
            Path = path;
            FileId = fileId;
            ParentId = parentId;
            SessionId = sessionId;
            ClientIp = clientIp;
            ClientName = clientName;
            OpenedOn = openedOn;
            LastReconnectedOn = lastReconnectedOn;
            AccessRights = accessRights;
        }
    }
}
