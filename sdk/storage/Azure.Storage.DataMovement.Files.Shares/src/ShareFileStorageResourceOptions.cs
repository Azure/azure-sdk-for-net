// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        /// Optional. Sets the Cache Control header which
        /// specifies directives for caching mechanisms.
        ///
        /// By default preserves the Cache Control from the source.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public DataTransferProperty<string> CacheControl { get; set; }

        /// <summary>
        /// Optional. Sets the Content Disposition header which
        /// conveys additional information about how to process the response
        /// payload, and also can be used to attach additional metadata.  For
        /// example, if set to attachment, it indicates that the user-agent
        /// should not display the response, but instead show a Save As dialog
        /// with a filename other than the blob name specified.
        ///
        /// By default preserves the Content Disposition from the source.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public DataTransferProperty<string> ContentDisposition { get; set; }

        /// <summary>
        /// Optional. Sets the Content Encoding header which
        /// specifies which content encodings have been applied to the blob.
        /// This value is returned to the client when the Get Blob operation
        /// is performed on the blob resource. The client can use this value
        /// when returned to decode the blob content.
        ///
        /// By default preserves the Content Encoding from the source.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public DataTransferProperty<string[]> ContentEncoding { get; set; }

        /// <summary>
        /// Optional. Sets the Content Language header which
        /// specifies the natural languages used by this resource.
        ///
        /// By default preserves the Content Language from the source.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public DataTransferProperty<string[]> ContentLanguage { get; set; }

        /// <summary>
        /// Optional. Sets the Content Type header which
        /// specifies the MIME content type of the blob.
        ///
        /// By default preserves the Content Type from the source.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public DataTransferProperty<string> ContentType { get; set; }

        /// <summary>
        /// The file system attributes for this file.
        ///
        /// By default preserves the File Attributes from the source.
        /// </summary>
        public DataTransferProperty<NtfsFileAttributes?> FileAttributes { get; set; }

        /// <summary>
        /// The key of the file permission.
        ///
        /// By default the permission key will not be preserved from the source Share to the destination Share.
        /// </summary>
        public DataTransferProperty FilePermissions { get; set; }

        /// <summary>
        /// The creation time of the file.
        ///
        /// By default preserves the File Created On Time from the source.
        /// </summary>
        public DataTransferProperty<DateTimeOffset?> FileCreatedOn { get; set; }

        /// <summary>
        /// The last write time of the file.
        ///
        /// By default preserves the File Last Written On Time from the source.
        /// </summary>
        public DataTransferProperty<DateTimeOffset?> FileLastWrittenOn { get; set; }

        /// <summary>
        /// The change time of the file.
        ///
        /// By default preserves the File Changed On Time from the source.
        /// </summary>
        public DataTransferProperty<DateTimeOffset?> FileChangedOn { get; set; }

        /// <summary>
        /// Optional. Defines custom metadata to set on the destination resource.
        ///
        /// Applies to upload and copy transfers.
        ///
        /// Preserves Metadata from the source by default.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public DataTransferProperty<Metadata> DirectoryMetadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Optional. Defines custom metadata to set on the destination resource.
        ///
        /// Applies to upload and copy transfers.
        ///
        /// Preserves Metdata from the source by default.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public DataTransferProperty<Metadata> FileMetadata { get; set; }

        /// <summary>
        /// Constructor for ShareFileStorageResourceOptions.
        /// </summary>
        public ShareFileStorageResourceOptions()
        {
        }

        internal ShareFileStorageResourceOptions(ShareFileStorageResourceOptions options)
        {
            SourceConditions = options?.SourceConditions;
            DestinationConditions = options?.DestinationConditions;
            CacheControl = options?.CacheControl;
            ContentDisposition = options?.ContentDisposition;
            ContentEncoding = options?.ContentEncoding;
            ContentLanguage = options?.ContentLanguage;
            ContentType = options?.ContentType;
            FileAttributes = options?.FileAttributes;
            FilePermissions = options?.FilePermissions;
            FileCreatedOn = options?.FileCreatedOn;
            FileLastWrittenOn = options?.FileLastWrittenOn;
            FileChangedOn = options?.FileChangedOn;
            DirectoryMetadata = options?.DirectoryMetadata;
            FileMetadata = options?.FileMetadata;
        }
    }
}
