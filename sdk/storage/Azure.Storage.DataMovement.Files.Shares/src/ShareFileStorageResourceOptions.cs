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
        private string _cacheControl = default;
        internal bool _isCacheControlSet = false;

        private string _contentDisposition = default;
        internal bool _isContentDispositionSet = false;

        private string[] _contentEncoding = default;
        internal bool _isContentEncodingSet = false;

        private string[] _contentLanguage = default;
        internal bool _isContentLanguageSet = false;

        private string _contentType = default;
        internal bool _isContentTypeSet = false;

        private NtfsFileAttributes? _fileAttributes = default;
        internal bool _isFileAttributesSet = false;

        private DateTimeOffset? _fileCreatedOn = default;
        internal bool _isFileCreatedOnSet = false;

        private DateTimeOffset? _fileLastModifiedOn = default;
        internal bool _isFileLastModifiedOnSet = false;

        private DateTimeOffset? _fileChangedOn = default;
        internal bool _isFileChangedOnSet = false;

        private Metadata _directoryMetadata = default;
        internal bool _isDirectoryMetadataSet = false;

        private Metadata _fileMetadata = default;
        internal bool _isFileMetadataSet = false;

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
        public string CacheControl
        {
            get => _cacheControl;
            set
            {
                _cacheControl = value;
                _isCacheControlSet = true;
            }
        }

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
        public string ContentDisposition
        {
            get => _contentDisposition;
            set
            {
                _contentDisposition = value;
                _isContentDispositionSet = true;
            }
        }

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
        public string[] ContentEncoding
        {
            get => _contentEncoding;
            set
            {
                _contentEncoding = value;
                _isContentEncodingSet = true;
            }
        }

        /// <summary>
        /// Optional. Sets the Content Language header which
        /// specifies the natural languages used by this resource.
        ///
        /// By default preserves the Content Language from the source.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public string[] ContentLanguage
        {
            get => _contentLanguage;
            set
            {
                _contentLanguage = value;
                _isContentLanguageSet = true;
            }
        }

        /// <summary>
        /// Optional. Sets the Content Type header which
        /// specifies the MIME content type of the blob.
        ///
        /// By default preserves the Content Type from the source.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public string ContentType
        {
            get => _contentType;
            set
            {
                _contentType = value;
                _isContentTypeSet = true;
            }
        }

        /// <summary>
        /// The file system attributes for this file.
        ///
        /// By default preserves the File Attributes from the source.
        /// </summary>
        public NtfsFileAttributes? FileAttributes
        {
            get => _fileAttributes;
            set
            {
                _fileAttributes = value;
                _isFileAttributesSet = true;
            }
        }

        /// <summary>
        /// To preserve the key of the file permission.
        ///
        /// By default the permission key will not be preserved from the source Share to the destination Share.
        /// </summary>
        public bool? FilePermissions { get; set; }

        /// <summary>
        /// The creation time of the file.
        ///
        /// By default preserves the File Created On Time from the source.
        /// </summary>
        public DateTimeOffset? FileCreatedOn
        {
            get => _fileCreatedOn;
            set
            {
                _fileCreatedOn = value;
                _isFileCreatedOnSet = true;
            }
        }

        /// <summary>
        /// The last write time of the file.
        ///
        /// By default preserves the File Last Written On Time from the source.
        /// </summary>
        public DateTimeOffset? FileLastWrittenOn
        {
            get => _fileLastModifiedOn;
            set
            {
                _fileLastModifiedOn = value;
                _isFileLastModifiedOnSet = true;
            }
        }

        /// <summary>
        /// The change time of the file.
        ///
        /// By default preserves the File Changed On Time from the source.
        /// </summary>
        public DateTimeOffset? FileChangedOn
        {
            get => _fileChangedOn;
            set
            {
                _fileChangedOn = value;
                _isFileChangedOnSet = true;
            }
        }

        /// <summary>
        /// Optional. Defines custom metadata to set on the destination resource.
        ///
        /// Applies to upload and copy transfers.
        ///
        /// Preserves Metadata from the source by default.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Metadata DirectoryMetadata
        {
            get => _directoryMetadata;
            set
            {
                _directoryMetadata = value;
                _isDirectoryMetadataSet = true;
            }
        }
#pragma warning restore CA2227 // Collection properties should be readonly

            /// <summary>
            /// Optional. Defines custom metadata to set on the destination resource.
            ///
            /// Applies to upload and copy transfers.
            ///
            /// Preserves Metdata from the source by default.
            /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Metadata FileMetadata
        {
            get => _fileMetadata;
            set
            {
                _fileMetadata = value;
                _isFileMetadataSet = true;
            }
        }

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
