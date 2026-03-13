// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden enum aliases (Nfs->NFS, Smb->SMB) for casing changes.
// Could use @@clientName on enum values in spec.

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public readonly partial struct FileShareEnabledProtocol
    {
        /// <summary> NFS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FileShareEnabledProtocol Nfs => NFS;

        /// <summary> SMB. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FileShareEnabledProtocol Smb => SMB;
    }
}
