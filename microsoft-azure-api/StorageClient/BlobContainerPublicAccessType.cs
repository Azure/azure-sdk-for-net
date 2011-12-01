//-----------------------------------------------------------------------
// <copyright file="BlobContainerPublicAccessType.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the BlobContainerPublicAccessType enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    /// <summary>
    /// Specifies the level of public access that is allowed on the container.
    /// </summary>
    public enum BlobContainerPublicAccessType
    {
        /// <summary>
        /// No public access. Only the account owner can read resources in this container.
        /// </summary>
        Off,

        /// <summary>
        /// Container-level public access. Anonymous clients can read container and blob data.
        /// </summary>
        Container,

        /// <summary>
        /// Blob-level public access. Anonymous clients can read only blob data within this container.
        /// </summary>
        Blob
    }
}
