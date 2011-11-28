//-----------------------------------------------------------------------
// <copyright file="BlobErrorCodeStrings.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the BlobErrorCodeStrings class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    /// <summary>
    /// Provides error code strings that are specific to the Blob service.
    /// </summary>
    public static class BlobErrorCodeStrings
    {
        /// <summary>
        /// Error code that may be returned when a block ID is invalid.
        /// </summary>
        public const string InvalidBlockId = "InvalidBlockId";

        /// <summary>
        /// Error code that may be returned when a blob with the specified address cannot be found.
        /// </summary>
        public const string BlobNotFound = "BlobNotFound";

        /// <summary>
        /// Error code that may be returned when a client attempts to create a blob that already exists.
        /// </summary>
        public const string BlobAlreadyExists = "BlobAlreadyExists";

        /// <summary>
        /// Error code that may be returned when the specified block or blob is invalid.
        /// </summary>
        public const string InvalidBlobOrBlock = "InvalidBlobOrBlock";

        /// <summary>
        /// Error code that may be returned when a block list is invalid.
        /// </summary>
        public const string InvalidBlockList = "InvalidBlockList";
    }
}