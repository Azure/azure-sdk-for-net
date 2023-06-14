// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Specifies whether data in the container may be accessed publicly and the level of access. </summary>
    public enum StoragePublicAccessType
    {
        /// <summary> None. </summary>
        None,
        /// <summary> Container. </summary>
        Container,
        /// <summary> Blob. </summary>
        Blob
    }
}
