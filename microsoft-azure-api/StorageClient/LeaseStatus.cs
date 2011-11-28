//-----------------------------------------------------------------------
// <copyright file="LeaseStatus.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the LeaseStatus enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System.ComponentModel;

    /// <summary>
    /// The lease status of the blob.
    /// </summary>
    public enum LeaseStatus
    {
        /// <summary>
        /// The lease status is not specified.
        /// </summary>
        Unspecified,

        /// <summary>
        /// The blob is locked for exclusive-write access.
        /// </summary>
        Locked,

        /// <summary>
        /// The blob is available to be locked for exclusive write access.
        /// </summary>
        Unlocked
    }
}
