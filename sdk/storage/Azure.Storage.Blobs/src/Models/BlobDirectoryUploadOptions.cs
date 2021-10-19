// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Common;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for uploading to a Blob Virtual Directory.
    /// </summary>
    public class BlobDirectoryUploadOptions
    {
        /// <summary>
        /// Optional standard HTTP header properties that can be set for the
        /// each blob that is uploaded.
        /// </summary>
        public BlobDirectoryHttpHeaders HttpHeaders { get; set; }

        /// <summary>
        /// Optional custom metadata to set for each blob uploaded.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Metadata Metadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Options tags to set for each blob uploaded.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Tags Tags { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Optional <see cref="AccessTier"/> to set on each blob uploaded.
        /// </summary>
        public AccessTier? AccessTier { get; set; }

        /// <summary>
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </summary>
        public StorageTransferOptions TransferOptions { get; set; }

        /// <summary>
        /// Progress handler
        /// </summary>
        public IProgress<StorageTransferStatus> ProgressHandler { get; set; }

        /// <summary>
        /// Setting to upload ONLY the contents of the directory. Default set to false.
        /// </summary>
        public bool ContentsOnly { get; set; }
    }
}
