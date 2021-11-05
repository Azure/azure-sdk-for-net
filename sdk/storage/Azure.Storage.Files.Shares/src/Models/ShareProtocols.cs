// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Protocols that can be set on a Share.
    /// </summary>
    [Flags]
    public enum ShareProtocols
    {
        /// <summary>
        /// SMB
        /// </summary>
        Smb = 1,

        /// <summary>
        /// NFS
        /// </summary>
        Nfs = 2
    }
}
