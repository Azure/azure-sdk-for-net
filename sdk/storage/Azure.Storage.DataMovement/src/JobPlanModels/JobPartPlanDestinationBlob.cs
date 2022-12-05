// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Runtime.InteropServices;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Describes the structure of a destination blob.
    ///
    /// Comes to a total of 6311 bytes
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct JobPartPlanDestinationBlob
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
        ///
        /// TODO: make a type for this?
        /// </summary>
        public ushort ContentTypeLength;

        /// <summary>
        /// Specifies the MIME content type of the blob. The default type is application/octet-stream
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public byte[] ContentType;

        /// <summary>
        /// Specifies length of content encoding which have been applied to the blob.
        ///
        /// TODO: make a type for this?
        /// </summary>
        public ushort ContentEncodingLength;

        /// <summary>
        /// Specifies the MIME content type of the blob. The default type is application/octet-stream
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public byte[] ContentEncoding;

        /// <summary>
        /// Specifies length of content language which has been applied to the blob.
        /// </summary>
        public ushort ContentLanguageLength;

        /// <summary>
        /// Specifies which content language has been applied to the blob.
        ///
        /// 256 byte array
        /// TODO: force the size of this array onto this parameter. We need to constrain the 256 bytes parititon in the plan file
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public byte[] ContentLanguage;

        /// <summary>
        /// Specifies length of content disposition which has been applied to the blob.
        /// </summary>
        public ushort ContentDispositionLength;

        /// <summary>
        /// Specifies the content disposition of the blob
        ///
        /// 256 byte array
        /// TODO: force the size of this array onto this parameter. We need to constrain the 256 bytes parititon in the plan file
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public byte[] ContentDisposition;

        /// <summary>
        /// Specifies the length of the cache control which has been applied to the blob.
        /// </summary>
        public ushort CacheControlLength;

        /// <summary>
        /// Specifies the cache control of the blob
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public byte[] CacheControl;

        /// <summary>
        /// Specifies the tier if this is a block or page blob respectfully. Only one or none can be specified at a time.
        /// </summary>
        public JobPartPlanBlockBlobTier BlockBlobTier;
        public PageBlobTier PageBlobTier;

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
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1000)]
        public byte[] Metadata;

        /// <summary>
        /// Length of blob tags
        /// </summary>
        public ushort BlobTagsLength;

        /// <summary>
        /// Blob Tags
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4000)]
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
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
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
