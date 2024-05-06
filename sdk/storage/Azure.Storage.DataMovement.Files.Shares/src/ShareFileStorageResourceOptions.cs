// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Files.Shares.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Files.Shares
{
    /// <summary>
    /// Optional parameters for all File Share Storage resource types.
    /// </summary>
    public class ShareFileStorageResourceOptions
    {
        /// <summary>
        /// Optional SMB properties to set for the directory and/or file resource.
        /// </summary>
        public FileSmbProperties SmbProperties { get; set; }

        /// <summary>
        /// Optional. The file permission to set on the destination directory and/or file.
        ///
        /// Applies to copy and upload transfers.
        /// TODO: determine whether this is something we want to apply and override
        /// the potential default of copying over permissions when we go to do
        /// file share to file share copy transfer.
        /// </summary>
        public string FilePermissions { get; set; }

        /// <summary>
        /// Optional SMB properties to set for the directory and/or file.
        /// </summary>
        public ShareFileHttpHeaders HttpHeaders { get; set; }

        /// <summary>
        /// Optional. See <see cref="ShareFileRequestConditions"/>.
        /// Access conditions on the copying of data from this source storage resource share file.
        ///
        /// Applies to copy and download transfers.
        /// </summary>
        public ShareFileRequestConditions SourceConditions { get; set; }

        /// <summary>
        /// Optional. See <see cref="ShareFileRequestConditions"/>.
        /// Access conditions on the copying of data to this share file.
        ///
        /// Applies to copy and upload transfers.
        /// </summary>
        public ShareFileRequestConditions DestinationConditions { get; set; }

        /// <summary>
        /// Optional. Defines custom metadata to set on the destination resource.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Metadata DirectoryMetadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Optional. Defines custom metadata to set on the destination resource.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Metadata FileMetadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly
    }
}
