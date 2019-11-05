// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    internal static partial class DataLakeExtensions
    {
        internal static FileSystemItem ToFileSystemItem(this BlobContainerItem containerItem) =>
            new FileSystemItem()
            {
                Name = containerItem.Name,
                Properties = containerItem.Properties.ToFileSystemProperties()
            };

        internal static FileSystemProperties ToFileSystemProperties(this BlobContainerProperties containerProperties) =>
                new FileSystemProperties()
                {
                    LastModified = containerProperties.LastModified,
                    LeaseStatus = containerProperties.LeaseStatus.HasValue
                        ? (Models.LeaseStatus)containerProperties.LeaseStatus : default,
                    LeaseState = containerProperties.LeaseState.HasValue
                        ? (Models.LeaseState)containerProperties.LeaseState : default,
                    LeaseDuration = containerProperties.LeaseDuration.HasValue
                        ? (Models.LeaseDurationType)containerProperties.LeaseDuration : default,
                    PublicAccess = containerProperties.PublicAccess.HasValue
                        ? (Models.PublicAccessType)containerProperties.PublicAccess : default,
                    HasImmutabilityPolicy = containerProperties.HasImmutabilityPolicy,
                    HasLegalHold = containerProperties.HasLegalHold,
                    ETag = containerProperties.ETag,
                    Metadata = containerProperties.Metadata
                };

        internal static FileDownloadDetails ToFileDownloadDetails(this BlobDownloadDetails blobDownloadProperties) =>
            new FileDownloadDetails()
            {
                LastModified = blobDownloadProperties.LastModified,
                Metadata = blobDownloadProperties.Metadata,
                ContentRange = blobDownloadProperties.ContentRange,
                ETag = blobDownloadProperties.ETag,
                ContentEncoding = blobDownloadProperties.ContentEncoding,
                ContentDisposition = blobDownloadProperties.ContentDisposition,
                ContentLanguage = blobDownloadProperties.ContentLanguage,
                CopyCompletedOn = blobDownloadProperties.CopyCompletedOn,
                CopyStatusDescription = blobDownloadProperties.CopyStatusDescription,
                CopyId = blobDownloadProperties.CopyId,
                CopyProgress = blobDownloadProperties.CopyProgress,
                CopyStatus = (Models.CopyStatus)blobDownloadProperties.CopyStatus,
                LeaseDuration = (Models.LeaseDurationType)blobDownloadProperties.LeaseDuration,
                LeaseState = (Models.LeaseState)blobDownloadProperties.LeaseState,
                LeaseStatus = (Models.LeaseStatus)blobDownloadProperties.LeaseStatus,
                AcceptRanges = blobDownloadProperties.AcceptRanges,
                IsServerEncrypted = blobDownloadProperties.IsServerEncrypted,
                EncryptionKeySha256 = blobDownloadProperties.EncryptionKeySha256,
                ContentHash = blobDownloadProperties.BlobContentHash
            };

        internal static FileDownloadInfo ToFileDownloadInfo(this BlobDownloadInfo blobDownloadInfo) =>
            new FileDownloadInfo()
            {
                ContentLength = blobDownloadInfo.ContentLength,
                Content = blobDownloadInfo.Content,
                ContentHash = blobDownloadInfo.ContentHash,
                Properties = blobDownloadInfo.Details.ToFileDownloadDetails()
            };

        internal static PathProperties ToPathProperties(this BlobProperties blobProperties) =>
            new PathProperties()
            {
                LastModified = blobProperties.LastModified,
                CreatedOn = blobProperties.CreatedOn,
                Metadata = blobProperties.Metadata,
                CopyCompletedOn = blobProperties.CopyCompletedOn,
                CopyStatusDescription = blobProperties.CopyStatusDescription,
                CopyId = blobProperties.CopyId,
                CopyProgress = blobProperties.CopyProgress,
                CopySource = blobProperties.CopySource,
                IsIncrementalCopy = blobProperties.IsIncrementalCopy,
                LeaseDuration = (Models.LeaseDurationType)blobProperties.LeaseDuration,
                LeaseStatus = (Models.LeaseStatus)blobProperties.LeaseStatus,
                LeaseState = (Models.LeaseState)blobProperties.LeaseState,
                ContentLength = blobProperties.ContentLength,
                ContentType = blobProperties.ContentType,
                ETag = blobProperties.ETag,
                ContentHash = blobProperties.ContentHash,
                ContentEncoding = blobProperties.ContentEncoding,
                ContentDisposition = blobProperties.ContentDisposition,
                ContentLanguage = blobProperties.ContentLanguage,
                CacheControl = blobProperties.CacheControl,
                AcceptRanges = blobProperties.AcceptRanges,
                IsServerEncrypted = blobProperties.IsServerEncrypted,
                EncryptionKeySha256 = blobProperties.EncryptionKeySha256,
                AccessTier = blobProperties.AccessTier,
                ArchiveStatus = blobProperties.ArchiveStatus,
                AccessTierChangedOn = blobProperties.AccessTierChangedOn
            };

        internal static DataLakeLease ToDataLakeLease(this BlobLease blobLease) =>
            new DataLakeLease()
            {
                ETag = blobLease.ETag,
                LastModified = blobLease.LastModified,
                LeaseId = blobLease.LeaseId,
                LeaseTime = blobLease.LeaseTime
            };

        internal static BlobHttpHeaders ToBlobHttpHeaders(this PathHttpHeaders pathHttpHeaders)
        {
            if (pathHttpHeaders == null)
            {
                return null;
            }

            return new BlobHttpHeaders()
            {
                ContentType = pathHttpHeaders.ContentType,
                ContentHash = pathHttpHeaders.ContentHash,
                ContentEncoding = pathHttpHeaders.ContentEncoding,
                ContentLanguage = pathHttpHeaders.ContentLanguage,
                ContentDisposition = pathHttpHeaders.ContentDisposition,
                CacheControl = pathHttpHeaders.CacheControl
            };
        }

        internal static BlobRequestConditions ToBlobRequestConditions(this DataLakeRequestConditions dataLakeRequestConditions)
        {
            if (dataLakeRequestConditions == null)
            {
                return null;
            }

            return new BlobRequestConditions()
            {
                IfMatch = dataLakeRequestConditions.IfMatch,
                IfNoneMatch = dataLakeRequestConditions.IfNoneMatch,
                IfModifiedSince = dataLakeRequestConditions.IfModifiedSince,
                IfUnmodifiedSince = dataLakeRequestConditions.IfUnmodifiedSince,
                LeaseId = dataLakeRequestConditions.LeaseId
            };
        }

        internal static PathItem ToPathItem(this Dictionary<string, string> dictionary)
        {
            dictionary.TryGetValue("name", out string name);
            dictionary.TryGetValue("isDirectory", out string isDirectoryString);
            dictionary.TryGetValue("lastModified", out string lastModifiedString);
            dictionary.TryGetValue("etag", out string etagString);
            dictionary.TryGetValue("contentLength", out string contentLengthString);
            dictionary.TryGetValue("owner", out string owner);
            dictionary.TryGetValue("group", out string group);
            dictionary.TryGetValue("permissions", out string permissions);

            bool isDirectory = false;
            if (isDirectoryString != null)
            {
                isDirectory = bool.Parse(isDirectoryString);
            }

            DateTimeOffset lastModified = new DateTimeOffset();
            if (lastModifiedString != null)
            {
                lastModified = DateTimeOffset.Parse(lastModifiedString, CultureInfo.InvariantCulture);
            }

            ETag eTag = new ETag();
            if (etagString != null)
            {
                eTag = new ETag(etagString);
            }

            long contentLength = 0;
            if (contentLengthString != null)
            {
                contentLength = long.Parse(contentLengthString, CultureInfo.InvariantCulture);
            }

            PathItem pathItem = new PathItem()
            {
                Name = name,
                IsDirectory = isDirectory,
                LastModified = lastModified,
                ETag = eTag,
                ContentLength = contentLength,
                Owner = owner,
                Group = group,
                Permissions = permissions
            };
            return pathItem;
        }

        internal static PathContentInfo ToPathContentInfo(this PathUpdateResult pathUpdateResult) =>
            new PathContentInfo()
            {
                ContentHash = pathUpdateResult.ContentMD5,
                ETag = pathUpdateResult.ETag,
                LastModified = pathUpdateResult.LastModified,
                AcceptRanges = pathUpdateResult.AcceptRanges,
                CacheControl = pathUpdateResult.CacheControl,
                ContentDisposition = pathUpdateResult.ContentDisposition,
                ContentEncoding = pathUpdateResult.ContentEncoding,
                ContentLanguage = pathUpdateResult.ContentLanguage,
                ContentLength = pathUpdateResult.ContentLength,
                ContentRange = pathUpdateResult.ContentRange,
                ContentType = pathUpdateResult.ContentType,
                Metadata = ToMetadata(pathUpdateResult.Properties)
            };

        private static IDictionary<string, string> ToMetadata(string rawMetdata)
        {
            if (rawMetdata == null)
            {
                return null;
            }

            IDictionary<string, string> metadataDictionary = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            string[] metadataArray = rawMetdata.Split(',');
            foreach (string entry in metadataArray)
            {
                string[] entryArray = entry.Split('=');
                if (entryArray.Length == 2)
                {
                    byte[] valueArray = Convert.FromBase64String(entryArray[1]);
                    metadataDictionary.Add(entryArray[0], Encoding.UTF8.GetString(valueArray));
                }
            }
            return metadataDictionary;
        }
    }
}
