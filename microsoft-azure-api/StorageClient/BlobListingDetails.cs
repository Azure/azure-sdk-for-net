//-----------------------------------------------------------------------
// <copyright file="BlobListingDetails.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the BlobListingDetails enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;

    /// <summary>
    /// Specifies which items to include when listing a set of blobs.
    /// </summary>
    [Flags]
    public enum BlobListingDetails
    {
        /// <summary>
        /// List only committed blobs, and do not return blob metadata.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// List committed blobs and blob snapshots.
        /// </summary>
        Snapshots = 0x1,

        /// <summary>
        /// Retrieve blob metadata for each blob returned in the listing.
        /// </summary>
        Metadata = 0x2,

        /// <summary>
        /// List committed and uncommitted blobs.
        /// </summary>
        UncommittedBlobs = 0x4,

        /// <summary>
        /// List all available committed blobs, uncommitted blobs, and snapshots, and return all metadata for those blobs.
        /// </summary>
        All = 0x7
    }
}
