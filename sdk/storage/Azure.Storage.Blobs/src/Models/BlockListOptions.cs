// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies whether to return the list of committed blocks, the list of uncommitted blocks, or both lists together.
    /// </summary>
    [Flags]
    public enum BlockListOptions
    {
        /// <summary>
        /// Flag to specify returning both committed and uncommitted blocks.
        /// </summary>
        All = Committed | Uncommitted,

        /// <summary>
        /// Flag to specify returning the list of committed blocks.
        /// </summary>
        Committed = 1,

        /// <summary>
        /// Flag to specify returning the list of uncommitted blocks.
        /// </summary>
        Uncommitted = 2
    }
}

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// BlockListOptions extensions
    /// </summary>
    internal static partial class BlobExtensions
    {
        /// <summary>
        /// Convert the BlockListOptions into a BlockListType.
        /// </summary>
        /// <param name="options"></param>
        /// <returns>The BlockList response.</returns>
        internal static BlockListType ToBlockListType(this BlockListOptions options)
        {
            if (options.HasFlag(BlockListOptions.All) || options == default)
            { return BlockListType.All;  }
            else if (options.HasFlag(BlockListOptions.Committed))
            { return BlockListType.Committed; }
            else
            { return BlockListType.Uncommitted; }
        }
    }
}
