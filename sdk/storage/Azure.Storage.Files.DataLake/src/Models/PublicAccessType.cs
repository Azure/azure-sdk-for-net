// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Specifies whether data in the file system may be accessed publicly and the level of access
    /// </summary>
    public enum PublicAccessType
    {
        /// <summary>
        /// none
        /// </summary>
        None,

        /// <summary>
        /// file system
        /// </summary>
        FileSystem,

        /// <summary>
        /// path
        /// </summary>
        Path
    }
}
