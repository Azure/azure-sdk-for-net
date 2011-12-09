//-----------------------------------------------------------------------
// <copyright file="BlobListingDetails.cs" company="Microsoft">
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
