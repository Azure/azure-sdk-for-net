// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Determines the behavior of the rename operation
    /// </summary>
    public enum PathRenameMode
    {
        /// <summary>
        /// legacy
        /// </summary>
        Legacy,

        /// <summary>
        /// posix
        /// </summary>
        Posix
    }
}
