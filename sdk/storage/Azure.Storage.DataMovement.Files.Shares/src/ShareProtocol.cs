// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement.Files.Shares
{
    /// <summary>
    /// Protocol that can be set on a Share.
    /// </summary>
    public enum ShareProtocol : byte
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
