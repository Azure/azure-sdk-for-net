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
                    RemainingRetentionDays = containerProperties.RemainingRetentionDays,
                    DefaultEncryptionScope = containerProperties.DefaultEncryptionScope,
                    PreventEncryptionScopeOverride = containerProperties.PreventEncryptionScopeOverride
                };

        internal static FileDownloadDetails ToFileDownloadDetails(this BlobDownloadDetails blobDownloadProperties, string encryptionContext, string accessControlList) =>
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
                ContentHash = blobDownloadProperties.BlobContentHash,
                CreatedOn = blobDownloadProperties.CreatedOn,
                EncryptionContext = encryptionContext,
                AccessControlList = PathAccessControlExtensions.ParseAccessControlList(accessControlList)
            };

        internal static FileDownloadInfo ToFileDownloadInfo(this Response<BlobDownloadInfo> blobDownloadInfoResponse)
        {
            blobDownloadInfoResponse.GetRawResponse().Headers.TryGetValue(Constants.DataLake.EncryptionContextHeaderName, out string encryptionContext);
            blobDownloadInfoResponse.GetRawResponse().Headers.TryGetValue(Constants.DataLake.AclHeaderName, out string accessControlList);
            FileDownloadInfo fileDownloadInfo = new FileDownloadInfo()
            {
                ContentLength = blobDownloadInfoResponse.Value.ContentLength,
                Content = blobDownloadInfoResponse.Value.Content,
                ContentHash = blobDownloadInfoResponse.Value.ContentHash,
                Properties = blobDownloadInfoResponse.Value.Details.ToFileDownloadDetails(encryptionContext, accessControlList)
            };
            return fileDownloadInfo;
        }

        internal static FileDownloadInfo ToFileDownloadInfo(this Response<BlobDownloadStreamingResult> blobDownloadStreamingResultResponse)
        {
            blobDownloadStreamingResultResponse.GetRawResponse().Headers.TryGetValue(Constants.DataLake.EncryptionContextHeaderName, out string encryptionContext);
            blobDownloadStreamingResultResponse.GetRawResponse().Headers.TryGetValue(Constants.DataLake.AclHeaderName, out string accessControlList);
            FileDownloadInfo fileDownloadInfo = new FileDownloadInfo()
            {
                ContentLength = blobDownloadStreamingResultResponse.Value.Details.ContentLength,
                Content = blobDownloadStreamingResultResponse.Value.Content,
                ContentHash = blobDownloadStreamingResultResponse.Value.Details.ContentHash,
                Properties = blobDownloadStreamingResultResponse.Value.Details.ToFileDownloadDetails(encryptionContext, accessControlList)
            };
            return fileDownloadInfo;
        }
        internal static DataLakeFileReadStreamingResult ToDataLakeFileReadStreamingResult(this Response<BlobDownloadStreamingResult> blobDownloadStreamingResultResponse)
        {
            blobDownloadStreamingResultResponse.GetRawResponse().Headers.TryGetValue(Constants.DataLake.EncryptionContextHeaderName, out string encryptionContext);
            blobDownloadStreamingResultResponse.GetRawResponse().Headers.TryGetValue(Constants.DataLake.AclHeaderName, out string accessControlList);
            DataLakeFileReadStreamingResult dataLakeFileReadStreamingResult = new DataLakeFileReadStreamingResult()
            {
                Content = blobDownloadStreamingResultResponse.Value.Content,
                Details = blobDownloadStreamingResultResponse.Value.Details.ToFileDownloadDetails(encryptionContext, accessControlList)
            };
            return dataLakeFileReadStreamingResult;
        }

        internal static DataLakeFileReadResult ToDataLakeFileReadResult(this Response<BlobDownloadResult> blobDownloadResult)
        {
            blobDownloadResult.GetRawResponse().Headers.TryGetValue(Constants.DataLake.EncryptionContextHeaderName, out string encryptionContext);
            blobDownloadResult.GetRawResponse().Headers.TryGetValue(Constants.DataLake.AclHeaderName, out string accessControlList);
            DataLakeFileReadResult dataLakeFileReadResult = new DataLakeFileReadResult()
            {
                Content = blobDownloadResult.Value.Content,
                Details = blobDownloadResult.Value.Details.ToFileDownloadDetails(encryptionContext, accessControlList)
            };
            return dataLakeFileReadResult;
        }

        internal static PathProperties ToPathProperties(this Response<BlobProperties> blobPropertiesResponse)
        {
            PathProperties pathProperties = new PathProperties()
            {
                LastModified = blobPropertiesResponse.Value.LastModified,
                CreatedOn = blobPropertiesResponse.Value.CreatedOn,
                Metadata = blobPropertiesResponse.Value.Metadata,
                CopyCompletedOn = blobPropertiesResponse.Value.CopyCompletedOn,
                CopyStatusDescription = blobPropertiesResponse.Value.CopyStatusDescription,
                CopyId = blobPropertiesResponse.Value.CopyId,
                CopyProgress = blobPropertiesResponse.Value.CopyProgress,
                CopySource = blobPropertiesResponse.Value.CopySource,
                IsIncrementalCopy = blobPropertiesResponse.Value.IsIncrementalCopy,
                LeaseDuration = (Models.DataLakeLeaseDuration)blobPropertiesResponse.Value.LeaseDuration,
                LeaseStatus = (Models.DataLakeLeaseStatus)blobPropertiesResponse.Value.LeaseStatus,
                LeaseState = (Models.DataLakeLeaseState)blobPropertiesResponse.Value.LeaseState,
                ContentLength = blobPropertiesResponse.Value.ContentLength,
                ContentType = blobPropertiesResponse.Value.ContentType,
                ETag = blobPropertiesResponse.Value.ETag,
                ContentHash = blobPropertiesResponse.Value.ContentHash,
                ContentEncoding = blobPropertiesResponse.Value.ContentEncoding,
                ContentDisposition = blobPropertiesResponse.Value.ContentDisposition,
                ContentLanguage = blobPropertiesResponse.Value.ContentLanguage,
                CacheControl = blobPropertiesResponse.Value.CacheControl,
                AcceptRanges = blobPropertiesResponse.Value.AcceptRanges,
                IsServerEncrypted = blobPropertiesResponse.Value.IsServerEncrypted,
                EncryptionKeySha256 = blobPropertiesResponse.Value.EncryptionKeySha256,
                AccessTier = blobPropertiesResponse.Value.AccessTier,
                ArchiveStatus = blobPropertiesResponse.Value.ArchiveStatus,
                AccessTierChangedOn = blobPropertiesResponse.Value.AccessTierChangedOn,
                ExpiresOn = blobPropertiesResponse.Value.ExpiresOn,
                EncryptionScope = blobPropertiesResponse.Value.EncryptionScope,
            };
            if (blobPropertiesResponse.GetRawResponse().Headers.TryGetValue(
                Constants.DataLake.EncryptionContextHeaderName,
                out string encryptionContext))
            {
                pathProperties.EncryptionContext = encryptionContext;
            }
            if (blobPropertiesResponse.GetRawResponse().Headers.TryGetValue(
                Constants.DataLake.OwnerHeaderName,
                out string owner))
            {
                pathProperties.Owner = owner;
            }
            if (blobPropertiesResponse.GetRawResponse().Headers.TryGetValue(
                Constants.DataLake.GroupHeaderName,
                out string group))
            {
                pathProperties.Group = group;
            }
            if (blobPropertiesResponse.GetRawResponse().Headers.TryGetValue(
                Constants.DataLake.PermissionsHeaderName,
                out string permissions))
            {
                pathProperties.Permissions = permissions;
            }
            if (blobPropertiesResponse.GetRawResponse().Headers.TryGetValue(
                Constants.DataLake.AclHeaderName,
                out string accessControlList))
            {
                pathProperties.AccessControlList = PathAccessControlExtensions.ParseAccessControlList(accessControlList);
            }
            return pathProperties;
        }

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

            if (textConfiguration is DataLakeQueryParquetTextOptions dataLakeQueryParquetOptions)
            {
                if (!isInput)
                {
                    throw new ArgumentException($"{nameof(DataLakeQueryParquetTextOptions)} can only be used for input serialization.");
                }

                return dataLakeQueryParquetOptions.ToBlobQueryParquetTextOptions();
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
                HasHeaders = options.HasHeaders,
                RecordSeparator = options.RecordSeparator,
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

        internal static BlobQueryParquetTextOptions ToBlobQueryParquetTextOptions(this DataLakeQueryParquetTextOptions options)
        {
            if (options == null)
            {
                return null;
            }

            return new BlobQueryParquetTextOptions();
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

            return new BlobOpenReadOptions(options.AllowModifications)
            {
                BufferSize = options.BufferSize,
                Conditions = options.Conditions.ToBlobRequestConditions(),
                Position = options.Position,
                TransferValidation = options.TransferValidation
            };
        }

        internal static BlobDownloadOptions ToBlobBaseDownloadOptions(this DataLakeFileReadOptions options)
        {
            if (options == null)
            {
                return null;
            }

            return new BlobDownloadOptions()
            {
                Range = options.Range,
                Conditions = options.Conditions.ToBlobRequestConditions(),
                TransferValidation = options.TransferValidation
            };
        }

        internal static BlobDownloadToOptions ToBlobBaseDownloadToOptions(this DataLakeFileReadToOptions options)
        {
            if (options == null)
            {
                return null;
            }
            return new BlobDownloadToOptions()
            {
                Conditions = options.Conditions.ToBlobRequestConditions(),
                TransferOptions = options.TransferOptions,
                TransferValidation = options.TransferValidation
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
                ETag = new ETag(path.Etag),
                ContentLength = path.ContentLength == null ? 0 : long.Parse(path.ContentLength, CultureInfo.InvariantCulture),
                Owner = path.Owner,
                Group = path.Group,
                Permissions = path.Permissions,
                CreatedOn = ParseFileTimeString(path.CreationTime),
                ExpiresOn = ParseFileTimeString(path.ExpiryTime),
                EncryptionScope = path.EncryptionScope,
                EncryptionContext = path.EncryptionContext,
            };
        }

        internal static DateTimeOffset? ParseFileTimeString(string fileTimeString)
        {
            if (string.IsNullOrEmpty(fileTimeString))
            {
                return null;
            }

            // fileTimeString can come back as either in ticks or in a proper readable format
            // If the service gives us the format in ticks
            if (long.TryParse(fileTimeString, NumberStyles.None, CultureInfo.InvariantCulture, out long fileTimeLong))
            {
                if (fileTimeLong == 0)
                {
                    return null;
                }
                return DateTimeOffset.FromFileTime(fileTimeLong).ToUniversalTime();
            }
            // If the service gives the format in DAYOFTHEWEEK, DD MMMM YYYY HH:MM:SS ZONE
            if (DateTimeOffset.TryParse(fileTimeString, default, DateTimeStyles.None, out DateTimeOffset parsedTime))
            {
                return parsedTime;
            }
            // Reaching here means we got a format from the service we did not expect
            // Even though we got a successful response from the service we should at least return what the service gave us
            Errors.InvalidFormat($"When parsing a File Time property of the PathItem, it return in an unexpected format: \"{fileTimeString}\"");
            return default;
        }

        internal static PathInfo ToPathInfo(this ResponseWithHeaders<PathCreateHeaders> response)
            => new PathInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
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
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault()
            };

        internal static PathInfo ToPathInfo(this ResponseWithHeaders<PathFlushDataHeaders> response)
            => new PathInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault()
            };

        internal static PathInfo ToPathInfo(this ResponseWithHeaders<PathSetExpiryHeaders> response)
            => new PathInfo
            {
                ETag = response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.ETag, out string value) ? new ETag(value) : default,
                LastModified = response.Headers.LastModified.GetValueOrDefault()
            };

        internal static PathDeletedSegment ToPathDeletedSegment(this ResponseWithHeaders<ListBlobsHierarchySegmentResponse, FileSystemListBlobHierarchySegmentHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new PathDeletedSegment
            {
                Continuation = response.Value.NextMarker,
                DeletedPaths = response.Value.Segment.BlobItems.Select(r => r.ToPathHierarchyDeletedItem())
            };
        }

        internal static PathHierarchyDeletedItem ToPathHierarchyDeletedItem(this BlobItemInternal blobItemInternal)
        {
            if (blobItemInternal == null)
            {
                return null;
            }

            return new PathHierarchyDeletedItem
            {
                Path = new PathDeletedItem
                {
                    Path = blobItemInternal.Name,
                    DeletionId = blobItemInternal.DeletionId,
                    DeletedOn = blobItemInternal.Properties.DeletedTime,
                    RemainingRetentionDays = blobItemInternal.Properties.RemainingRetentionDays
                }
            };
        }

        internal static DataLakeServiceProperties ToDataLakeServiceProperties(this BlobServiceProperties blobServiceProperties)
        {
            if (blobServiceProperties == null)
            {
                return null;
            }

            return new DataLakeServiceProperties
            {
                Logging = blobServiceProperties.Logging.ToDataLakeAnalyticsLogging(),
                HourMetrics = blobServiceProperties.HourMetrics.ToDataLakeMetrics(),
                MinuteMetrics = blobServiceProperties.MinuteMetrics.ToDataLakeMetrics(),
                Cors = blobServiceProperties.Cors.ToDataLakeCorsRules(),
                DefaultServiceVersion = blobServiceProperties.DefaultServiceVersion,
                DeleteRetentionPolicy = blobServiceProperties.DeleteRetentionPolicy.ToDataLakeRetentionPolicy(),
                StaticWebsite = blobServiceProperties.StaticWebsite.ToDataLakeStaticWebsite()
            };
        }

        internal static DataLakeAnalyticsLogging ToDataLakeAnalyticsLogging(this BlobAnalyticsLogging blobAnalyticsLogging)
        {
            if (blobAnalyticsLogging == null)
            {
                return null;
            }

            return new DataLakeAnalyticsLogging
            {
                Version = blobAnalyticsLogging.Version,
                Delete = blobAnalyticsLogging.Delete,
                Read = blobAnalyticsLogging.Read,
                Write = blobAnalyticsLogging.Write,
                RetentionPolicy = blobAnalyticsLogging.RetentionPolicy.ToDataLakeRetentionPolicy()
            };
        }

        internal static DataLakeMetrics ToDataLakeMetrics(this BlobMetrics blobMetrics)
        {
            if (blobMetrics == null)
            {
                return null;
            }

            return new DataLakeMetrics
            {
                Version = blobMetrics.Version,
                Enabled = blobMetrics.Enabled,
                RetentionPolicy = blobMetrics.RetentionPolicy.ToDataLakeRetentionPolicy(),
                IncludeApis = blobMetrics.IncludeApis
            };
        }

        internal static DataLakeRetentionPolicy ToDataLakeRetentionPolicy(this BlobRetentionPolicy blobRetentionPolicy)
        {
            if (blobRetentionPolicy == null)
            {
                return null;
            }

            return new DataLakeRetentionPolicy
            {
                Enabled = blobRetentionPolicy.Enabled,
                Days = blobRetentionPolicy.Days
            };
        }

        internal static IList<DataLakeCorsRule> ToDataLakeCorsRules(this IList<BlobCorsRule> blobCorsRules)
        {
            if (blobCorsRules == null)
            {
                return null;
            }

            return blobCorsRules.Select(blobCorsRule => blobCorsRule.ToDataLakeCorsRule()).ToList();
        }

        internal static DataLakeCorsRule ToDataLakeCorsRule(this BlobCorsRule blobCorsRule)
        {
            if (blobCorsRule == null)
            {
                return null;
            }

            return new DataLakeCorsRule
            {
                AllowedOrigins = blobCorsRule.AllowedOrigins,
                AllowedMethods = blobCorsRule.AllowedMethods,
                AllowedHeaders = blobCorsRule.AllowedHeaders,
                ExposedHeaders = blobCorsRule.ExposedHeaders,
                MaxAgeInSeconds = blobCorsRule.MaxAgeInSeconds
            };
        }

        internal static DataLakeStaticWebsite ToDataLakeStaticWebsite(this BlobStaticWebsite blobStaticWebsite)
        {
            if (blobStaticWebsite == null)
            {
                return null;
            }

            return new DataLakeStaticWebsite
            {
                Enabled = blobStaticWebsite.Enabled,
                IndexDocument = blobStaticWebsite.IndexDocument,
                ErrorDocument404Path = blobStaticWebsite.ErrorDocument404Path,
                DefaultIndexDocumentPath = blobStaticWebsite.DefaultIndexDocumentPath
            };
        }

        internal static BlobServiceProperties ToBlobServiceProperties(this DataLakeServiceProperties dataLakeServiceProperties)
        {
            if (dataLakeServiceProperties == null)
            {
                return null;
            }

            return new BlobServiceProperties
            {
                Logging = dataLakeServiceProperties.Logging.ToBlobAnalyticsLogging(),
                HourMetrics = dataLakeServiceProperties.HourMetrics.ToBlobMetrics(),
                MinuteMetrics = dataLakeServiceProperties.MinuteMetrics.ToBlobMetrics(),
                Cors = dataLakeServiceProperties.Cors.ToBlobCorsRules(),
                DefaultServiceVersion = dataLakeServiceProperties.DefaultServiceVersion,
                DeleteRetentionPolicy = dataLakeServiceProperties.DeleteRetentionPolicy.ToBlobRetentionPolicy(),
                StaticWebsite = dataLakeServiceProperties.StaticWebsite.ToBlobStaticWebsite()
            };
        }

        internal static BlobMetrics ToBlobMetrics(this DataLakeMetrics dataLakeMetrics)
        {
            if (dataLakeMetrics == null)
            {
                return null;
            }

            return new BlobMetrics
            {
                Version = dataLakeMetrics.Version,
                Enabled = dataLakeMetrics.Enabled,
                RetentionPolicy = dataLakeMetrics.RetentionPolicy.ToBlobRetentionPolicy(),
                IncludeApis = dataLakeMetrics.IncludeApis
            };
        }

        internal static BlobRetentionPolicy ToBlobRetentionPolicy(this DataLakeRetentionPolicy dataLakeRetentionPolicy)
        {
            if (dataLakeRetentionPolicy == null)
            {
                return null;
            }

            return new BlobRetentionPolicy
            {
                Enabled = dataLakeRetentionPolicy.Enabled,
                Days = dataLakeRetentionPolicy.Days
            };
        }

        internal static IList<BlobCorsRule> ToBlobCorsRules(this IList<DataLakeCorsRule> dataLakeCorsRules)
        {
            if (dataLakeCorsRules == null)
            {
                return null;
            }

            return dataLakeCorsRules.Select(dataLakeCorsRule => dataLakeCorsRule.ToBlobCorsRule()).ToList();
        }

        internal static BlobCorsRule ToBlobCorsRule(this DataLakeCorsRule dataLakeCorsRule)
        {
            if (dataLakeCorsRule == null)
            {
                return null;
            }

            return new BlobCorsRule
            {
                AllowedOrigins = dataLakeCorsRule.AllowedOrigins,
                AllowedMethods = dataLakeCorsRule.AllowedMethods,
                AllowedHeaders = dataLakeCorsRule.AllowedHeaders,
                ExposedHeaders = dataLakeCorsRule.ExposedHeaders,
                MaxAgeInSeconds = dataLakeCorsRule.MaxAgeInSeconds
            };
        }

        internal static BlobAnalyticsLogging ToBlobAnalyticsLogging(this DataLakeAnalyticsLogging dataLakeAnalyticsLogging)
        {
            if (dataLakeAnalyticsLogging == null)
            {
                return null;
            }

            return new BlobAnalyticsLogging
            {
                Version = dataLakeAnalyticsLogging.Version,
                Delete = dataLakeAnalyticsLogging.Delete,
                Read = dataLakeAnalyticsLogging.Read,
                Write = dataLakeAnalyticsLogging.Write,
                RetentionPolicy = dataLakeAnalyticsLogging.RetentionPolicy.ToBlobRetentionPolicy()
            };
        }

        internal static BlobStaticWebsite ToBlobStaticWebsite(this DataLakeStaticWebsite dataLakeStaticWebsite)
        {
            if (dataLakeStaticWebsite == null)
            {
                return null;
            }

            return new BlobStaticWebsite
            {
                Enabled = dataLakeStaticWebsite.Enabled,
                IndexDocument = dataLakeStaticWebsite.IndexDocument,
                ErrorDocument404Path = dataLakeStaticWebsite.ErrorDocument404Path,
                DefaultIndexDocumentPath = dataLakeStaticWebsite.DefaultIndexDocumentPath
            };
        }
        internal static BlobContainerEncryptionScopeOptions ToBlobContainerEncryptionScopeOptions(this DataLakeFileSystemEncryptionScopeOptions encryptionScopeOptions)
        {
            if (encryptionScopeOptions == null)
            {
                return null;
            }

            return new BlobContainerEncryptionScopeOptions
            {
                DefaultEncryptionScope = encryptionScopeOptions.DefaultEncryptionScope,
                PreventEncryptionScopeOverride = encryptionScopeOptions.PreventEncryptionScopeOverride
            };
        }

        internal static Blobs.Models.CustomerProvidedKey? ToBlobCustomerProvidedKey(this DataLake.Models.DataLakeCustomerProvidedKey? dataLakeCustomerProvidedKey)
        {
            if (dataLakeCustomerProvidedKey == null)
            {
                return null;
            }

            return new Blobs.Models.CustomerProvidedKey(dataLakeCustomerProvidedKey.Value.EncryptionKey);
        }

        internal static GetPathTagResult ToGetPathTagResult(this GetBlobTagResult blobTagResult)
        {
            return blobTagResult == null
                ? null
                : new GetPathTagResult { Tags = blobTagResult.Tags };
        }

        #region ValidateConditionsNotPresent
        internal static void ValidateConditionsNotPresent(
            this RequestConditions requestConditions,
            DataLakeRequestConditionProperty invalidConditions,
            string operationName,
            string parameterName)
        {
            if (CompatSwitches.DisableRequestConditionsValidation)
            {
                return;
            }

            if (requestConditions == null)
            {
                return;
            }

            List<string> invalidList = null;
            requestConditions.ValidateConditionsNotPresent(
                invalidConditions,
                ref invalidList);

            if (invalidList?.Count > 0)
            {
                string unsupportedString = string.Join(", ", invalidList);
                throw new ArgumentException(
                    $"{operationName} does not support the {unsupportedString} condition(s).",
                    parameterName);
            }
        }

        internal static void ValidateConditionsNotPresent(
            this DataLakeRequestConditions requestConditions,
            DataLakeRequestConditionProperty invalidConditions,
            string operationName,
            string parameterName)
        {
            if (CompatSwitches.DisableRequestConditionsValidation)
            {
                return;
            }

            if (requestConditions == null)
            {
                return;
            }

            List<string> invalidList = null;
            requestConditions.ValidateConditionsNotPresent(
                invalidConditions,
                ref invalidList);

            if (invalidList?.Count > 0)
            {
                string unsupportedString = string.Join(", ", invalidList);
                throw new ArgumentException(
                    $"{operationName} does not support the {unsupportedString} condition(s).",
                    parameterName);
            }
        }

        internal static void ValidateConditionsNotPresent(
            this RequestConditions requestConditions,
            DataLakeRequestConditionProperty invalidConditions,
            ref List<string> invalidList)
        {
            if (requestConditions == null)
            {
                return;
            }

            if ((invalidConditions & DataLakeRequestConditionProperty.IfModifiedSince) == DataLakeRequestConditionProperty.IfModifiedSince
                && requestConditions.IfModifiedSince != null)
            {
                invalidList ??= new List<string>();
                invalidList.Add(nameof(BlobRequestConditions.IfModifiedSince));
            }

            if ((invalidConditions & DataLakeRequestConditionProperty.IfUnmodifiedSince) == DataLakeRequestConditionProperty.IfUnmodifiedSince
                && requestConditions.IfUnmodifiedSince != null)
            {
                invalidList ??= new List<string>();
                invalidList.Add(nameof(BlobRequestConditions.IfUnmodifiedSince));
            }

            if ((invalidConditions & DataLakeRequestConditionProperty.IfMatch) == DataLakeRequestConditionProperty.IfMatch
                && requestConditions.IfMatch != null)
            {
                invalidList ??= new List<string>();
                invalidList.Add(nameof(BlobRequestConditions.IfMatch));
            }

            if ((invalidConditions & DataLakeRequestConditionProperty.IfNoneMatch) == DataLakeRequestConditionProperty.IfNoneMatch
                && requestConditions.IfNoneMatch != null)
            {
                invalidList ??= new List<string>();
                invalidList.Add(nameof(BlobRequestConditions.IfNoneMatch));
            }
        }

        internal static void ValidateConditionsNotPresent(
            this DataLakeRequestConditions requestConditions,
            DataLakeRequestConditionProperty invalidConditions,
            ref List<string> invalidList)
        {
            if (requestConditions == null)
            {
                return;
            }

            // Validate RequestConditions
            ((RequestConditions)requestConditions).ValidateConditionsNotPresent(
                invalidConditions, ref invalidList);

            // Validate BlobRequestConditions specific conditions.
            if ((invalidConditions & DataLakeRequestConditionProperty.LeaseId) == DataLakeRequestConditionProperty.LeaseId
                && requestConditions.LeaseId != null)
            {
                invalidList ??= new List<string>();
                invalidList.Add(nameof(BlobRequestConditions.LeaseId));
            }
        }
        #endregion
    }
}
