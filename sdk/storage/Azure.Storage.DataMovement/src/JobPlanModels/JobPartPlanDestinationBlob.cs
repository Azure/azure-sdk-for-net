// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Describes the structure of a destination blob.
    ///
    /// Comes to a total of 6311 bytes
    /// </summary>
    internal class JobPartPlanDestinationBlob
    {
        /// <summary>
        /// Blob Type
        /// </summary>
        public JobPlanBlobType BlobType;

        /// <summary>
        /// Represents user decision to interpret the content-encoding from source file
        /// </summary>
        public bool NoGuessMimeType;

        /// <summary>
        /// Specifies the length of MIME content type of the blob
        /// </summary>
        public ushort ContentTypeLength;

        /// <summary>
        /// Specifies the MIME content type of the blob. The default type is application/octet-stream
        /// </summary>
        public byte[] ContentType;

        /// <summary>
        /// Specifies length of content encoding which have been applied to the blob.
        /// </summary>
        public ushort ContentEncodingLength;

        /// <summary>
        /// Specifies the MIME content type of the blob. The default type is application/octet-stream
        /// </summary>
        public byte[] ContentEncoding;

        /// <summary>
        /// Specifies length of content language which has been applied to the blob.
        /// </summary>
        public ushort ContentLanguageLength;

        /// <summary>
        /// Specifies which content language has been applied to the blob.
        /// </summary>
        public byte[] ContentLanguage;

        /// <summary>
        /// Specifies length of content disposition which has been applied to the blob.
        /// </summary>
        public ushort ContentDispositionLength;

        /// <summary>
        /// Specifies the content disposition of the blob
        /// </summary>
        public byte[] ContentDisposition;

        /// <summary>
        /// Specifies the length of the cache control which has been applied to the blob.
        /// </summary>
        public ushort CacheControlLength;

        /// <summary>
        /// Specifies the cache control of the blob
        /// </summary>
        public byte[] CacheControl;

        /// <summary>
        /// Specifies the tier if this is a block or page blob respectfully. Only one or none can be specified at a time.
        /// </summary>
        public JobPartPlanBlockBlobTier BlockBlobTier;
        public JobPartPlanPageBlobTier PageBlobTier;

        /// <summary>
        /// Controls uploading of MD5 hashes
        /// </summary>
        public bool PutMd5;

        /// <summary>
        /// Length of metadata
        /// </summary>
        public ushort MetadataLength;

        /// <summary>
        /// Metadata
        /// </summary>
        public byte[] Metadata;

        /// <summary>
        /// Length of blob tags
        /// </summary>
        public ushort BlobTagsLength;

        /// <summary>
        /// Blob Tags
        /// </summary>
        public byte[] BlobTags;

        /// <summary>
        /// Client Provided Key information
        /// </summary>
        public bool CpkInfo;

        /// <summary>
        /// Is source encrypted?
        /// </summary>
        public bool IsSourceEncrypted;

        /// <summary>
        /// Length of CPK encryption scope.
        /// </summary>
        public byte[] CpkScopeInfo;

        /// <summary>
        /// CPK encryption scope.
        /// </summary>
        public ushort CpkScopeInfoLength;

        /// <summary>
        /// Specifies the maximum size of block which determines the number of chunks and chunk size of a transfer
        /// </summary>
        public long BlockSize;
    }
}
