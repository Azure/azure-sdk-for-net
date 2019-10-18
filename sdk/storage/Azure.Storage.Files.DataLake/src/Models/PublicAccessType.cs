// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{

    /// <summary>
    /// Specifies whether data in the container may be accessed publicly and the level of access
    /// </summary>
    public enum PublicAccessType
    {
        /// <summary>
        /// none
        /// </summary>
        None,

        /// <summary>
        /// container
        /// </summary>
        Container,

        /// <summary>
        /// blob
        /// </summary>
        Blob
    }
}
