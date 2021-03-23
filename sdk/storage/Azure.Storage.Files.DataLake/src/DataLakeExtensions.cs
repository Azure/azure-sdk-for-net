// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Azure.Core;
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
                IsDeleted = containerItem.IsDeleted,
                VersionId = containerItem.VersionId,
                Properties = containerItem.Properties.ToFileSystemProperties()
            };

        internal static FileSystemProperties ToFileSystemProperties(this BlobContainerProperties containerProperties) =>
                new FileSystemProperties()
                {
                    LastModified = containerProperties.LastModified,
                    LeaseStatus = containerProperties.LeaseStatus.HasValue
                        ? (Models.DataLakeLeaseStatus)containerProperties.LeaseStatus : default,
                    LeaseState = containerProperties.LeaseState.HasValue
                        ? (Models.DataLakeLeaseState)containerProperties.LeaseState : default,
                    LeaseDuration = containerProperties.LeaseDuration.HasValue
                        ? (Models.DataLakeLeaseDuration)containerProperties.LeaseDuration : default,
                    PublicAccess = containerProperties.PublicAccess.HasValue
                        ? (Models.PublicAccessType)containerProperties.PublicAccess : default,
                    HasImmutabilityPolicy = containerProperties.HasImmutabilityPolicy,
                    HasLegalHold = containerProperties.HasLegalHold,
                    ETag = containerProperties.ETag,
                    Metadata = containerProperties.Metadata,
                    DeletedOn = containerProperties.DeletedOn,
                    RemainingRetentionDays = containerProperties.RemainingRetentionDays
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
                LeaseDuration = (Models.DataLakeLeaseDuration)blobDownloadProperties.LeaseDuration,
                LeaseState = (Models.DataLakeLeaseState)blobDownloadProperties.LeaseState,
                LeaseStatus = (Models.DataLakeLeaseStatus)blobDownloadProperties.LeaseStatus,
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

        internal static FileDownloadInfo ToFileDownloadInfo(this BlobDownloadStreamingResult blobDownloadStreamingResult) =>
            new FileDownloadInfo()
            {
                ContentLength = blobDownloadStreamingResult.Details.ContentLength,
                Content = blobDownloadStreamingResult.Content,
                ContentHash = blobDownloadStreamingResult.Details.ContentHash,
                Properties = blobDownloadStreamingResult.Details.ToFileDownloadDetails()
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
                LeaseDuration = (Models.DataLakeLeaseDuration)blobProperties.LeaseDuration,
                LeaseStatus = (Models.DataLakeLeaseStatus)blobProperties.LeaseStatus,
                LeaseState = (Models.DataLakeLeaseState)blobProperties.LeaseState,
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
                AccessTierChangedOn = blobProperties.AccessTierChangedOn,
                ExpiresOn = blobProperties.ExpiresOn
            };

        internal static PathInfo ToPathInfo(this BlobInfo blobInfo) =>
            new PathInfo
            {
                ETag = blobInfo.ETag,
                LastModified = blobInfo.LastModified
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

        internal static FileSystemAccessPolicy ToFileSystemAccessPolicy(this BlobContainerAccessPolicy blobContainerAccessPolicy)
        {
            if (blobContainerAccessPolicy == null)
            {
                return null;
            }

            return new FileSystemAccessPolicy()
            {
                DataLakePublicAccess = (Models.PublicAccessType)blobContainerAccessPolicy.BlobPublicAccess,
                ETag = blobContainerAccessPolicy.ETag,
                LastModified = blobContainerAccessPolicy.LastModified,
                SignedIdentifiers = blobContainerAccessPolicy.SignedIdentifiers.ToDataLakeSignedIdentifiers()
            };
        }

        internal static IEnumerable<DataLakeSignedIdentifier> ToDataLakeSignedIdentifiers(this IEnumerable<BlobSignedIdentifier> blobSignedIdentifiers)
        {
            if (blobSignedIdentifiers == null)
            {
                return null;
            }

            return blobSignedIdentifiers.ToList().Select(r => r.ToDataLakeSignedIdentifier());
        }

        internal static DataLakeSignedIdentifier ToDataLakeSignedIdentifier(this BlobSignedIdentifier blobSignedIdentifier)
        {
            if (blobSignedIdentifier == null)
            {
                return null;
            }

            return new DataLakeSignedIdentifier()
            {
                AccessPolicy = blobSignedIdentifier.AccessPolicy.ToDataLakeAccessPolicy(),
                Id = blobSignedIdentifier.Id
            };
        }

        internal static DataLakeAccessPolicy ToDataLakeAccessPolicy(this BlobAccessPolicy blobAccessPolicy)
        {
            if (blobAccessPolicy == null)
            {
                return null;
            }

            return new DataLakeAccessPolicy()
            {
                PolicyStartsOn = blobAccessPolicy.PolicyStartsOn,
                PolicyExpiresOn = blobAccessPolicy.PolicyExpiresOn,
                Permissions = blobAccessPolicy.Permissions
            };
        }

        internal static IEnumerable<BlobSignedIdentifier> ToBlobSignedIdentifiers(this IEnumerable<DataLakeSignedIdentifier> dataLakeSignedIdentifiers)
        {
            if (dataLakeSignedIdentifiers == null)
            {
                return null;
            }

            return dataLakeSignedIdentifiers.ToList().Select(r => r.ToBlobSignedIdentifier());
        }

        internal static BlobSignedIdentifier ToBlobSignedIdentifier(this DataLakeSignedIdentifier dataLakeSignedIdentifier)
        {
            if (dataLakeSignedIdentifier == null)
            {
                return null;
            }

            return new BlobSignedIdentifier()
            {
                AccessPolicy = dataLakeSignedIdentifier.AccessPolicy.ToBlobAccessPolicy(),
                Id = dataLakeSignedIdentifier.Id
            };
        }

        internal static BlobAccessPolicy ToBlobAccessPolicy(this DataLakeAccessPolicy dataLakeAccessPolicy)
        {
            if (dataLakeAccessPolicy == null)
            {
                return null;
            }

            return new BlobAccessPolicy()
            {
                PolicyStartsOn = dataLakeAccessPolicy.PolicyStartsOn,
                PolicyExpiresOn = dataLakeAccessPolicy.PolicyExpiresOn,
                Permissions = dataLakeAccessPolicy.Permissions
            };
        }

        internal static BlobQueryOptions ToBlobQueryOptions(this DataLakeQueryOptions options)
        {
            if (options == null)
            {
                return null;
            }

            BlobQueryOptions blobQueryOptions = new BlobQueryOptions
            {
                InputTextConfiguration = options.InputTextConfiguration.ToBlobQueryTextConfiguration(isInput: true),
                OutputTextConfiguration = options.OutputTextConfiguration.ToBlobQueryTextConfiguration(isInput: false),
                Conditions = options.Conditions.ToBlobRequestConditions(),
                ProgressHandler = options.ProgressHandler
            };

            if (options._errorHandler != null)
            {
                blobQueryOptions.ErrorHandler += (BlobQueryError error) => { options._errorHandler(error.ToDataLakeQueryError()); };
            }

            return blobQueryOptions;
        }

        internal static BlobQueryTextOptions ToBlobQueryTextConfiguration(
            this DataLakeQueryTextOptions textConfiguration,
            bool isInput)
        {
            if (textConfiguration == null)
            {
                return null;
            }

            if (textConfiguration is DataLakeQueryJsonTextOptions dataLakeQueryJsonTexasOptions)
            {
                return dataLakeQueryJsonTexasOptions.ToBlobQueryJsonTextConfiguration();
            }

            if (textConfiguration is DataLakeQueryCsvTextOptions dataLakeQueryCsvTextOptions)
            {
                return dataLakeQueryCsvTextOptions.ToBlobQueryCsvTextConfiguration();
            }

            if (textConfiguration is DataLakeQueryArrowOptions dataLakeQueryArrowOptions)
            {
                if (isInput)
                {
                    throw new ArgumentException($"{nameof(DataLakeQueryArrowOptions)} can only be used for output serialization.");
                }

                return dataLakeQueryArrowOptions.ToBlobQueryArrowOptions();
            }

            throw new ArgumentException("Invalid text configuration type");
        }

        internal static BlobQueryJsonTextOptions ToBlobQueryJsonTextConfiguration(this DataLakeQueryJsonTextOptions options)
            => new BlobQueryJsonTextOptions
            {
                RecordSeparator = options.RecordSeparator
            };

        internal static BlobQueryCsvTextOptions ToBlobQueryCsvTextConfiguration(this DataLakeQueryCsvTextOptions options)
            => new BlobQueryCsvTextOptions
            {
                ColumnSeparator = options.ColumnSeparator,
                QuotationCharacter = options.QuotationCharacter,
                EscapeCharacter = options.EscapeCharacter,
                HasHeaders = options.HasHeaders
            };

        internal static BlobQueryArrowOptions ToBlobQueryArrowOptions(this DataLakeQueryArrowOptions options)
        {
            if (options == null)
            {
                return null;
            }

            return new BlobQueryArrowOptions
            {
                Schema = options.Schema.ToBlobQueryArrowFields()
            };
        }

        internal static IList<BlobQueryArrowField> ToBlobQueryArrowFields(this IList<DataLakeQueryArrowField> arrowFields)
        {
            if (arrowFields == null)
            {
                return null;
            }

            IList<BlobQueryArrowField> blobQueryArrowFields = new List<BlobQueryArrowField>();
            arrowFields.ToList().ForEach(r => blobQueryArrowFields.Add(r.ToBlobQueryArrowField()));

            return blobQueryArrowFields;
        }

        internal static BlobQueryArrowField ToBlobQueryArrowField(this DataLakeQueryArrowField arrowField)
        {
            if (arrowField == null)
            {
                return null;
            }

            return new BlobQueryArrowField
            {
                Type = arrowField.Type.ToBlobQueryArrowFieldType(),
                Name = arrowField.Name,
                Precision = arrowField.Precision,
                Scale = arrowField.Scale
            };
        }

        internal static BlobQueryArrowFieldType ToBlobQueryArrowFieldType(this DataLakeQueryArrowFieldType fieldType)
            => fieldType switch
            {
                DataLakeQueryArrowFieldType.Bool => BlobQueryArrowFieldType.Bool,
                DataLakeQueryArrowFieldType.Decimal => BlobQueryArrowFieldType.Decimal,
                DataLakeQueryArrowFieldType.Double => BlobQueryArrowFieldType.Double,
                DataLakeQueryArrowFieldType.Int64 => BlobQueryArrowFieldType.Int64,
                DataLakeQueryArrowFieldType.String => BlobQueryArrowFieldType.String,
                DataLakeQueryArrowFieldType.Timestamp => BlobQueryArrowFieldType.Timestamp,
                _ => default,
            };

        internal static DataLakeQueryError ToDataLakeQueryError(this BlobQueryError error)
        {
            if (error == null)
            {
                return null;
            }

            return new DataLakeQueryError
            {
                Name = error.Name,
                Description = error.Description,
                IsFatal = error.IsFatal,
                Position = error.Position
            };
        }

        internal static BlobOpenReadOptions ToBlobOpenReadOptions(this DataLakeOpenReadOptions options)
        {
            if (options == null)
            {
                return null;
            }

            return new BlobOpenReadOptions(options.Conditions == null)
            {
                BufferSize = options.BufferSize,
                Conditions = options.Conditions.ToBlobRequestConditions(),
                Position = options.Position
            };
        }

        internal static PathSegment ToPathSegment(this ResponseWithHeaders<PathList, FileSystemListPathsHeaders> response)
            => new PathSegment
            {
                Continuation = response.Headers.Continuation,
                Paths = response.Value.ToPathItems()
            };

        internal static IEnumerable<PathItem> ToPathItems(this PathList pathList)
        {
            if (pathList == null)
            {
                return null;
            }

            return pathList.Paths.Select(path => path.ToPathItem());
        }

        internal static PathItem ToPathItem(this Path path)
        {
            if (path == null)
            {
                return null;
            }

            return new PathItem
            {
                Name = path.Name,
                IsDirectory = path.IsDirectory != null && bool.Parse(path.IsDirectory),
                LastModified = path.LastModified.GetValueOrDefault(),
                ETag = new ETag(path.ETag),
                ContentLength = path.ContentLength == null ? 0 : long.Parse(path.ContentLength, CultureInfo.InvariantCulture),
                Owner = path.Owner,
                Group = path.Group,
                Permissions = path.Permissions
            };
        }

        internal static PathInfo ToPathInfo(this ResponseWithHeaders<PathCreateHeaders> response)
            => new PathInfo
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault()
            };

        internal static PathAccessControl ToPathAccessControl(this ResponseWithHeaders<PathGetPropertiesHeaders> response)
            => new PathAccessControl
            {
                Owner = response.Headers.Owner,
                Group = response.Headers.Group,
                Permissions = PathPermissions.ParseSymbolicPermissions(response.Headers.Permissions),
                AccessControlList = PathAccessControlExtensions.ParseAccessControlList(response.Headers.ACL)
            };

        internal static PathInfo ToPathInfo(this ResponseWithHeaders<PathSetAccessControlHeaders> response)
            => new PathInfo
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault()
            };

        internal static PathInfo ToPathInfo(this ResponseWithHeaders<PathFlushDataHeaders> response)
            => new PathInfo
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault()
            };

        internal static PathInfo ToPathInfo(this ResponseWithHeaders<PathSetExpiryHeaders> response)
            => new PathInfo
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault()
            };
    }
}
