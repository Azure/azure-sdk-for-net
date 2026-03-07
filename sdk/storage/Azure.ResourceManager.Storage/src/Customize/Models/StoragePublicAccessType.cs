// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Specifies whether data in the container may be accessed publicly and the level of access. </summary>
    public enum StoragePublicAccessType
    {
        /// <summary> None. </summary>
        None = 0,
        /// <summary> Container. </summary>
        Container = 1,
        /// <summary> Blob. </summary>
        Blob = 2,
    }
}
