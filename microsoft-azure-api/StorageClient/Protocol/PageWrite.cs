//-----------------------------------------------------------------------
// <copyright file="PageWrite.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the PageWrite enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    /// <summary>
    /// Describes actions that may be used for writing to a page blob or clearing a set of pages.
    /// </summary>
    public enum PageWrite
    {
        /// <summary>
        /// Update the page with new data.
        /// </summary>
        Update,

        /// <summary>
        /// Clear the page.
        /// </summary>
        Clear
    }
}