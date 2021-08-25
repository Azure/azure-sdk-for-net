// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// The BlockListType.
    /// </summary>
    internal enum BlockListType
    {
        /// <summary>
        /// committed.
        /// </summary>
        Committed,

        /// <summary>
        /// uncommitted.
        /// </summary>
        Uncommitted,

        ///<summary>
        ///all.
        ///</summary>
        All
    }
}
