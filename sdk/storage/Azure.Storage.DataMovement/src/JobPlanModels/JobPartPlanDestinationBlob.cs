// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
namespace Azure.Storage.DataMovement
{
    internal class JobPartPlanDestinationBlob
    {
        /// <summary>
        /// Blob Type
        /// </summary>
        public JobPlanBlobType BlobType { get; internal set; }

        /// <summary>
        /// Represents user decision to interpret the content-encoding from source file
        /// </summary>
        public bool NoGuessMimeType { get; internal set; }

        /// <summary>
        /// Specifies the length of MIME content type of the blob
        ///
        /// TODO: make a type for this?
        /// </summary>
        public ushort ContentTypeLength { get; internal set; }

        /// <summary>
        /// Specifies the MIME content type of the blob. The default type is application/octet-stream
        ///
        /// 256 byte array
        /// TODO: force the size of this array onto this parameter. We need to constrain the 256 bytes parititon in the plan file
        /// </summary>
        public byte[] ContentType { get; internal set; }

        /// <summary>
        /// Specifies length of content encoding which have been applied to the blob.
        ///
        /// TODO: make a type for this?
        /// </summary>
        public ushort ContentEncodingLength { get; internal set; }

        /// <summary>
        /// Specifies the MIME content type of the blob. The default type is application/octet-stream
        ///
        /// 256 byte array
        /// TODO: force the size of this array onto this parameter. We need to constrain the 256 bytes parititon in the plan file
        /// </summary>
        public byte[] ContentEncoding { get; internal set; }

        /// <summary>
        /// Specifies length of content language which has been applied to the blob.
        ///
        /// </summary>
        public ushort ContentLanguageLength { get; internal set; }

        /// <summary>
        /// Specifies which content language has been applied to the blob.
        ///
        /// 256 byte array
        /// TODO: force the size of this array onto this parameter. We need to constrain the 256 bytes parititon in the plan file
        /// </summary>
        public byte[] ContentLanguage { get; internal set; }

        /// <summary>
        /// Specifies length of content disposition which has been applied to the blob.
        /// </summary>
        public ushort ContentDispositionLength { get; internal set; }

        /// <summary>
        /// Specifies the content disposition of the blob
        ///
        /// 256 byte array
        /// TODO: force the size of this array onto this parameter. We need to constrain the 256 bytes parititon in the plan file
        /// </summary>
        public byte[] ContentDisposition { get; internal set; }

        /// <summary>
        /// Specifies the length of the cache control which has been applied to the blob.
        /// </summary>
        public ushort CacheControlLength { get; internal set; }

        /// <summary>
        /// Specifies the cache control of the blob
        /// </summary>
        public byte[] CacheControl { get; internal set; }

        /// <summary>
        /// Specifies the tier if this is a block or page blob respectfully. Only one or none can be specified at a time.
        /// </summary>
        public JobPartPlanBlockBlobTier BlockBlobTier { get; internal set; }
        public PageBlobTier PageBlobTier { get; internal set; }

        /// <summary>
        /// Controls uploading of MD5 hashes
        /// </summary>
        public bool PutMd5 { get; internal set; }

        /// <summary>
        /// Length of metadata
        /// </summary>
        public ushort MetadataLength { get; internal set; }

        /// <summary>
        /// Metadata
        /// </summary>
        public byte[] Metadata { get; internal set; }

        /// <summary>
        /// Length of blob tags
        /// </summary>
        public ushort BlobTagsLength { get; internal set; }

        /// <summary>
        /// Blob Tags
        /// </summary>
        public byte[] BlobTags { get; internal set; }

        /// <summary>
        /// Client Provided Key information
        /// </summary>
        public bool CpkInfo { get; internal set; }

        /// <summary>
        /// Is source encrypted?
        /// </summary>
        public bool IsSourceEncrypted { get; internal set; }

        /// <summary>
        /// Length of CPK encryption scope.
        /// </summary>
        public byte[] CpkScopeInfo { get; internal set; }

        /// <summary>
        /// CPK encryption scope.
        /// </summary>
        public ushort CpkScopeInfoLength { get; internal set; }

        /// <summary>
        /// Specifies the maximum size of block which determines the number of chunks and chunk size of a transfer
        /// </summary>
        public long BlockSize { get; internal set; }
    }
}
