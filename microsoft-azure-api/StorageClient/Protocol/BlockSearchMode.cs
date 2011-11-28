//-----------------------------------------------------------------------
// <copyright file="BlockSearchMode.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the BlockSearchMode enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    /// <summary>
    /// Indicates which block lists should be searched to find a specified block. 
    /// </summary>
    public enum BlockSearchMode
    {
        /// <summary>
        /// Search the committed block list only.
        /// </summary>
        Committed,

        /// <summary>
        /// Search the uncommitted block list only.
        /// </summary>
        Uncommitted,

        /// <summary>
        /// Search the uncommitted block list first, and if the block is not found there, search 
        /// the committed block list.
        /// </summary>
        Latest
    }
}
