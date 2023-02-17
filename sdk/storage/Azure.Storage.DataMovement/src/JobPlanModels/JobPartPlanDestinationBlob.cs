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
    [StructLayout(LayoutKind.Sequential)]
    internal struct JobPartPlanDestinationBlob
    {
        private const string blobTypeName = "blobType";
        private const string noGuessMimeTypeName = "noGuessMimeType";
        private const string contentTypeName = "contentType";
        private const string contentEncodingName = "contentEncoding";
        private const string contentLanguageName = "contentLanguage";
        private const string contentDispositionName = "contentDisposition";
        private const string cacheControlName = "cacheControl";
        private const string blockBlobTierName = "blockBlobTier";
        private const string pageBlobTierName = "pageBlobTier";
        private const string putMd5Name = "putMd5";
        private const string metadataName = "metadata";
        private const string blobTagsName = "blobTags";
        private const string cpkInfoName = "cpkInfo";
        private const string isSourceEncryptedName = "isSourceEncrypted";
        private const string cpkScopeInfoName = "cpkScopeInfo";
        private const string blockSizeName = "blockSize";

        private static readonly JsonEncodedText s_blobTypeNameBytes = JsonEncodedText.Encode(blobTypeName);
        private static readonly JsonEncodedText s_noGuessMimeTypeNameBytes = JsonEncodedText.Encode(noGuessMimeTypeName);
        private static readonly JsonEncodedText s_contentTypeNameBytes = JsonEncodedText.Encode(contentTypeName);
        private static readonly JsonEncodedText s_contentEncodingNameBytes = JsonEncodedText.Encode(contentEncodingName);
        private static readonly JsonEncodedText s_contentLanguageNameBytes = JsonEncodedText.Encode(contentLanguageName);
        private static readonly JsonEncodedText s_contentDispositionNameBytes = JsonEncodedText.Encode(contentDispositionName);
        private static readonly JsonEncodedText s_cacheControlNameBytes = JsonEncodedText.Encode(cacheControlName);
        private static readonly JsonEncodedText s_blockBlobTierNameBytes = JsonEncodedText.Encode(blockBlobTierName);
        private static readonly JsonEncodedText s_pageBlobTierNameBytes = JsonEncodedText.Encode(pageBlobTierName);
        private static readonly JsonEncodedText s_putMd5NameBytes = JsonEncodedText.Encode(putMd5Name);
        private static readonly JsonEncodedText s_metadataNameBytes = JsonEncodedText.Encode(metadataName);
        private static readonly JsonEncodedText s_blobTagsNameBytes = JsonEncodedText.Encode(blobTagsName);
        private static readonly JsonEncodedText s_cpkInfoNameBytes = JsonEncodedText.Encode(cpkInfoName);
        private static readonly JsonEncodedText s_isSourceEncryptedNameBytes = JsonEncodedText.Encode(isSourceEncryptedName);
        private static readonly JsonEncodedText s_cpkScopeInfoNameBytes = JsonEncodedText.Encode(cpkScopeInfoName);
        private static readonly JsonEncodedText s_blockSizeNameBytes = JsonEncodedText.Encode(blockSizeName);

        /// <summary>
        /// Blob Type
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        public JobPlanBlobType BlobType;

        /// <summary>
        /// Represents user decision to interpret the content-encoding from source file
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool NoGuessMimeType;

        /// <summary>
        /// Specifies the length of MIME content type of the blob
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
        public ushort ContentTypeLength;

        /// <summary>
        /// Specifies the MIME content type of the blob. The default type is application/octet-stream
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] ContentType;

        /// <summary>
        /// Specifies length of content encoding which have been applied to the blob.
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
        public ushort ContentEncodingLength;

        /// <summary>
        /// Specifies the MIME content type of the blob. The default type is application/octet-stream
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] ContentEncoding;

        /// <summary>
        /// Specifies length of content language which has been applied to the blob.
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
        public ushort ContentLanguageLength;

        /// <summary>
        /// Specifies which content language has been applied to the blob.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] ContentLanguage;

        /// <summary>
        /// Specifies length of content disposition which has been applied to the blob.
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
        public ushort ContentDispositionLength;

        /// <summary>
        /// Specifies the content disposition of the blob
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] ContentDisposition;

        /// <summary>
        /// Specifies the length of the cache control which has been applied to the blob.
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
        public ushort CacheControlLength;

        /// <summary>
        /// Specifies the cache control of the blob
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] CacheControl;

        /// <summary>
        /// Specifies the tier if this is a block or page blob respectfully. Only one or none can be specified at a time.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        public JobPartPlanBlockBlobTier BlockBlobTier;
        [MarshalAs(UnmanagedType.U4)]
        public JobPartPlanPageBlobTier PageBlobTier;

        /// <summary>
        /// Controls uploading of MD5 hashes
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool PutMd5;

        /// <summary>
        /// Length of metadata
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
        public ushort MetadataLength;

        /// <summary>
        /// Metadata
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1000)]
        public byte[] Metadata;

        /// <summary>
        /// Length of blob tags
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
        public ushort BlobTagsLength;

        /// <summary>
        /// Blob Tags
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4000)]
        public byte[] BlobTags;

        /// <summary>
        /// Client Provided Key information
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool CpkInfo;

        /// <summary>
        /// Is source encrypted?
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool IsSourceEncrypted;

        /// <summary>
        /// Length of CPK encryption scope.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] CpkScopeInfo;

        /// <summary>
        /// CPK encryption scope.
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
        public ushort CpkScopeInfoLength;

        /// <summary>
        /// Specifies the maximum size of block which determines the number of chunks and chunk size of a transfer
        /// </summary>
        [MarshalAs(UnmanagedType.U8)]
        public long BlockSize;
    }
}
