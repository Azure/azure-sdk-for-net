//-----------------------------------------------------------------------
// <copyright file="DeleteSnapshotsOption.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the DeleteSnapshotsOption enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    /// <summary>
    /// The set of options describing delete operation.
    /// </summary>
    public enum DeleteSnapshotsOption
    {
        /// <summary>
        /// Delete blobs but not snapshots.
        /// </summary>
        None,

        /// <summary>
        /// Delete the blob and its snapshots.
        /// </summary>
        IncludeSnapshots,

        /// <summary>
        /// Delete the blob's snapshots only.
        /// </summary>
        DeleteSnapshotsOnly
    }
}
