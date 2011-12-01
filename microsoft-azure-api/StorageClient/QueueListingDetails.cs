//-----------------------------------------------------------------------
// <copyright file="QueueListingDetails.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the QueueListingDetails enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;

    /// <summary>
    /// Specifies which details to include when listing queues in this storage account.
    /// </summary>
    [Flags]
    public enum QueueListingDetails
    {
        /// <summary>
        /// No additional details.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Retrieve queue metadata.
        /// </summary>
        Metadata = 0x1,

        /// <summary>
        /// Retrieve all available details.
        /// </summary>
        All = 0x1
    }
}
