// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ShareFileHandle.
    /// </summary>
    [CodeGenModel("HandleItem")]
    public partial class ShareFileHandle
    {
        internal ShareFileHandle() { }

        /// <summary>
        /// Time when the session that previously opened the handle has last been reconnected. (UTC).
        /// </summary>
        [CodeGenMember("OpenTime")]
        public System.DateTimeOffset? OpenedOn { get; internal set; }

        /// <summary>
        /// Time handle was last connected to (UTC).
        /// </summary>
        [CodeGenMember("LastReconnectTime")]
        public System.DateTimeOffset? LastReconnectedOn { get; internal set; }
    }
}
