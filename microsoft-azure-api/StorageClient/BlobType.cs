//-----------------------------------------------------------------------
// <copyright file="BlobType.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the BlobType enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    /// <summary>
    /// The type of a blob.
    /// </summary>
    public enum BlobType
    {
        /// <summary>
        /// Not specified.
        /// </summary>
        Unspecified,

        /// <summary>
        /// A page blob.
        /// </summary>
        PageBlob,

        /// <summary>
        /// A block blob.
        /// </summary>
        BlockBlob,
    }
}
