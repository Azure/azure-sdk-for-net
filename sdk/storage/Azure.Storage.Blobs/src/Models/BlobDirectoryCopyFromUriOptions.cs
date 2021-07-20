// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for BlobDirectoryClient.StartCopyFromUri
    /// and BlobDirectoryClient.SyncCopyFromUri.
    ///
    /// TODO: add back in see cref for the respective methods that use this
    /// options bag
    /// </summary>
    public class BlobDirectoryCopyFromUriOptions
    {
        /// <summary>
        /// Optional custom metadata to set for the blobs to upload to the directory.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Metadata Metadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob within the directory.
        /// </summary>
        public AccessTier? AccessTier { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the copying of data from this source directory blob.
        /// </summary>
        public BlobDirectoryRequestConditions SourceConditions { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// the copying of data to this destination blob directory.
        /// </summary>
        public BlobDirectoryRequestConditions DestinationConditions { get; set; }

        /// <summary>
        /// Optional <see cref="RehydratePriority"/>
        /// Indicates the priority with which to rehydrate an archived blob.
        ///
        /// This parameter is not valid for synchronous copies.
        /// </summary>
        public RehydratePriority? RehydratePriority { get; set; }

        /// <summary>
        /// Optional. <see cref="Progress{AccessControlChanges}"/> callback where caller can track progress of the operation
        /// as well as collect paths that failed to change Access Control.
        /// </summary>
        public IProgress<Response<BlobCopyInfo>> ProgressHandler { get; set; }
    }
}
