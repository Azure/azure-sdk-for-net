// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;

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
        public long ContentTypeLength;

        /// <summary>
        /// Specifies the MIME content type of the blob. The default type is application/octet-stream
        /// </summary>
        public string ContentType;

        /// <summary>
        /// Specifies length of content encoding which have been applied to the blob.
        /// </summary>
        public long ContentEncodingLength;

        /// <summary>
        /// Specifies the MIME content type of the blob. The default type is application/octet-stream
        /// </summary>
        public string ContentEncoding;

        /// <summary>
        /// Specifies length of content language which has been applied to the blob.
        /// </summary>
        public long ContentLanguageLength;

        /// <summary>
        /// Specifies which content language has been applied to the blob.
        /// </summary>
        public string ContentLanguage;

        /// <summary>
        /// Specifies length of content disposition which has been applied to the blob.
        /// </summary>
        public long ContentDispositionLength;

        /// <summary>
        /// Specifies the content disposition of the blob
        /// </summary>
        public string ContentDisposition;

        /// <summary>
        /// Specifies the length of the cache control which has been applied to the blob.
        /// </summary>
        public long CacheControlLength;

        /// <summary>
        /// Specifies the cache control of the blob
        /// </summary>
        public string CacheControl;

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
        public long MetadataLength;

        /// <summary>
        /// Metadata
        /// </summary>
        public string Metadata;

        /// <summary>
        /// Length of blob tags
        /// </summary>
        public long BlobTagsLength;

        /// <summary>
        /// Blob Tags
        /// </summary>
        public string BlobTags;

        /// <summary>
        /// Client Provided Key information
        /// </summary>
        public long CpkInfoLength;

        /// <summary>
        /// Client Provided Key information
        /// </summary>
        public string CpkInfo;

        /// <summary>
        /// Is source encrypted?
        /// </summary>
        public bool IsSourceEncrypted;

        /// <summary>
        /// CPK encryption scope.
        /// </summary>
        public long CpkScopeInfoLength;

        /// <summary>
        /// Length of CPK encryption scope.
        /// </summary>
        public string CpkScopeInfo;

        /// <summary>
        /// Specifies the maximum size of block which determines the number of chunks and chunk size of a transfer
        /// </summary>
        public long BlockSize;

        public JobPartPlanDestinationBlob(
            JobPlanBlobType blobType,
            bool noGuessMimeType,
            string contentType,
            string contentEncoding,
            string contentLanguage,
            string contentDisposition,
            string cacheControl,
            JobPartPlanBlockBlobTier blockBlobTier,
            JobPartPlanPageBlobTier pageBlobTier,
            bool putMd5,
            string metadata,
            string blobTags,
            string cpkInfo,
            bool isSourceEncrypted,
            string cpkScopeInfo,
            long blockSize)
            : this(
                blobType: blobType,
                noGuessMimeType: noGuessMimeType,
                contentType: contentType,
                contentEncoding: contentEncoding,
                contentLanguage: contentLanguage,
                contentDisposition: contentDisposition,
                cacheControl: cacheControl,
                blockBlobTier: blockBlobTier,
                pageBlobTier: pageBlobTier,
                putMd5: putMd5,
                metadata: StringToDictionary(metadata, nameof(metadata)),
                blobTags: StringToDictionary(blobTags, nameof(blobTags)),
                cpkInfo: cpkInfo,
                isSourceEncrypted: isSourceEncrypted,
                cpkScopeInfo: cpkScopeInfo,
                blockSize: blockSize)
        {
        }

        public JobPartPlanDestinationBlob(
            JobPlanBlobType blobType,
            bool noGuessMimeType,
            string contentType,
            string contentEncoding,
            string contentLanguage,
            string contentDisposition,
            string cacheControl,
            JobPartPlanBlockBlobTier blockBlobTier,
            JobPartPlanPageBlobTier pageBlobTier,
            bool putMd5,
            IDictionary<string,string> metadata,
            IDictionary<string, string> blobTags,
            string cpkInfo,
            bool isSourceEncrypted,
            string cpkScopeInfo,
            long blockSize)
        {
            BlobType = blobType;
            NoGuessMimeType = noGuessMimeType;
            if (contentType.Length <= DataMovementConstants.PlanFile.HeaderValueMaxSize)
            {
                ContentType = contentType;
                ContentTypeLength = contentType.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(ContentType),
                    expectedSize: DataMovementConstants.PlanFile.HeaderValueMaxSize,
                    actualSize: contentType.Length);
            }
            if (contentEncoding.Length <= DataMovementConstants.PlanFile.HeaderValueMaxSize)
            {
                ContentEncoding = contentEncoding;
                ContentEncodingLength = contentEncoding.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(ContentEncoding),
                    expectedSize: DataMovementConstants.PlanFile.HeaderValueMaxSize,
                    actualSize: contentEncoding.Length);
            }
            if (contentLanguage.Length <= DataMovementConstants.PlanFile.HeaderValueMaxSize)
            {
                ContentLanguage = contentLanguage;
                ContentLanguageLength = contentLanguage.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(ContentLanguage),
                    expectedSize: DataMovementConstants.PlanFile.HeaderValueMaxSize,
                    actualSize: contentLanguage.Length);
            }
            if (contentDisposition.Length <= DataMovementConstants.PlanFile.HeaderValueMaxSize)
            {
                ContentDisposition = contentDisposition;
                ContentDispositionLength = contentDisposition.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(ContentDisposition),
                    expectedSize: DataMovementConstants.PlanFile.HeaderValueMaxSize,
                    actualSize: contentDisposition.Length);
            }
            if (cacheControl.Length <= DataMovementConstants.PlanFile.HeaderValueMaxSize)
            {
                CacheControl = cacheControl;
                CacheControlLength = cacheControl.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(CacheControl),
                    expectedSize: DataMovementConstants.PlanFile.HeaderValueMaxSize,
                    actualSize: cacheControl.Length);
            }
            BlockBlobTier = blockBlobTier;
            PageBlobTier = pageBlobTier;
            PutMd5 = putMd5;
            string metadataConvert = DictionaryToString(metadata);
            if (metadataConvert.Length <= DataMovementConstants.PlanFile.MetadataStrMaxSize)
            {
                Metadata = metadataConvert;
                MetadataLength = metadataConvert.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(Metadata),
                    expectedSize: DataMovementConstants.PlanFile.MetadataStrMaxSize,
                    actualSize: metadataConvert.Length);
            }
            string blobTagsConvert = DictionaryToString(blobTags);
            if (blobTagsConvert.Length <= DataMovementConstants.PlanFile.BlobTagsStrMaxSize)
            {
                BlobTags = blobTagsConvert;
                BlobTagsLength = blobTagsConvert.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(blobTags),
                    expectedSize: DataMovementConstants.PlanFile.BlobTagsStrMaxSize,
                    actualSize: blobTagsConvert.Length);
            }
            if (cpkInfo.Length <= DataMovementConstants.PlanFile.HeaderValueMaxSize)
            {
                CpkInfo = cpkInfo;
                CpkInfoLength = cpkInfo.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(CpkInfo),
                    expectedSize: DataMovementConstants.PlanFile.HeaderValueMaxSize,
                    actualSize: cpkInfo.Length);
            }
            IsSourceEncrypted = isSourceEncrypted;
            if (cpkScopeInfo.Length <= DataMovementConstants.PlanFile.HeaderValueMaxSize)
            {
                CpkScopeInfo = cpkScopeInfo;
                CpkScopeInfoLength = cpkScopeInfo.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(CpkScopeInfo),
                    expectedSize: DataMovementConstants.PlanFile.HeaderValueMaxSize,
                    actualSize: cpkScopeInfo.Length);
            }
            BlockSize = blockSize;
        }

        private static IDictionary<string, string> StringToDictionary(string str, string elementName)
        {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            string[] splitSemiColon = str.Split(';');
            foreach (string value in splitSemiColon)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    string[] splitEqual = value.Split('=');
                    if (splitEqual.Length != 2)
                    {
                        throw Errors.InvalidStringToDictionary(elementName, str);
                    }
                    dictionary.Add(splitEqual[0], splitEqual[1]);
                }
            }
            return dictionary;
        }

        private static string DictionaryToString(IDictionary<string, string> dict)
        {
            string concatStr = "";
            foreach (KeyValuePair<string, string> kv in dict)
            {
                // e.g. store like "header=value;"
                concatStr = string.Concat(concatStr,$"{kv.Key}={kv.Value};");
            }
            return concatStr;
        }
    }
}
