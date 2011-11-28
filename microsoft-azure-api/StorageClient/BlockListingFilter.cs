//-----------------------------------------------------------------------
// <copyright file="BlockListingFilter.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the BlockListingFilter enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    /// <summary>
    /// Indicates whether to list only committed blocks, only uncommitted blocks, or all blocks.
    /// </summary>
    public enum BlockListingFilter
    {
        /// <summary>
        /// Committed blocks.
        /// </summary>
        Committed,

        /// <summary>
        /// Uncommitted blocks.
        /// </summary>
        Uncommitted,

        /// <summary>
        /// Both committed and uncommitted blocks.
        /// </summary>
        All
    }
}