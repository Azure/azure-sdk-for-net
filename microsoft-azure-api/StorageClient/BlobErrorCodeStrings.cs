//-----------------------------------------------------------------------
// <copyright file="BlobErrorCodeStrings.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
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