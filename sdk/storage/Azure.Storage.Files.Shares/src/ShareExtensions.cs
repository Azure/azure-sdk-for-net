﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Azure.Core;
using Azure.Storage.Files.Shares.Models;

namespace Azure.Storage.Files.Shares
{
    internal static partial class ShareExtensions
    {
        internal static void AssertValidFilePermissionAndKey(string filePermission, string filePermissionKey)
        {
            if (filePermission != null && filePermissionKey != null)
            {
                throw Errors.CannotBothBeNotNull(nameof(filePermission), nameof(filePermissionKey));
            }

            if (filePermission != null && Encoding.UTF8.GetByteCount(filePermission) > Constants.File.MaxFilePermissionHeaderSize)
            {
                throw Errors.MustBeLessThanOrEqualTo(nameof(filePermission), Constants.File.MaxFilePermissionHeaderSize);
            }
        }

        internal static string ToFileDateTimeString(this DateTimeOffset? dateTimeOffset)
            => dateTimeOffset.HasValue ? ToFileDateTimeString(dateTimeOffset.Value) : null;

        private static string ToFileDateTimeString(this DateTimeOffset dateTimeOffset)
            => dateTimeOffset.UtcDateTime.ToString(Constants.File.FileTimeFormat, CultureInfo.InvariantCulture);

        internal static string ToShareEnableProtocolsString(this ShareProtocols? shareEnabledProtocols)
        {
            if (shareEnabledProtocols == null)
            {
                return null;
            }

            return shareEnabledProtocols switch
                {
                    ShareProtocols.Smb => Constants.File.SmbProtocol,
                    ShareProtocols.Nfs => Constants.File.NfsProtocol,
                    _ => throw new ArgumentException($"Unknown share protocol: {shareEnabledProtocols}"),
                };
        }

        internal static DeleteSnapshotsOptionType? ToShareSnapshotsDeleteOptionInternal(this ShareSnapshotsDeleteOption? option)
        {
            if (option == null)
            {
                return null;
            }
            return option switch
            {
                ShareSnapshotsDeleteOption.Include => DeleteSnapshotsOptionType.Include,
                ShareSnapshotsDeleteOption.IncludeWithLeased => DeleteSnapshotsOptionType.IncludeLeased,
                _ => throw new ArgumentException($"Invalid {nameof(ShareSnapshotsDeleteOption)}: {option}"),
            };
        }

        internal static ShareProtocols? ToShareEnabledProtocols(string rawProtocols)
        {
            if (rawProtocols == null)
            {
                return null;
            }

            string[] split = rawProtocols.Split(',');

            int result = 0;

            foreach (string s in split)
            {
                switch (s)
                {
                    case Constants.File.SmbProtocol:
                        result |= (int)ShareProtocols.Smb;
                        break;
                    case Constants.File.NfsProtocol:
                        result |= (int)ShareProtocols.Nfs;
                        break;
                }
            }

            if (result == 0)
            {
                return null;
            }

            return (ShareProtocols)result;
        }

        internal static ShareDirectoryInfo ToShareDirectoryInfo(this ResponseWithHeaders<DirectoryCreateHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new ShareDirectoryInfo
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                SmbProperties = new FileSmbProperties
                {
                    FileAttributes = ToFileAttributes(response.Headers.FileAttributes),
                    FilePermissionKey = response.Headers.FilePermissionKey,
                    FileCreatedOn = response.Headers.FileCreationTime,
                    FileLastWrittenOn = response.Headers.FileLastWriteTime,
                    FileChangedOn = response.Headers.FileCreationTime,
                    FileId = response.Headers.FileId,
                    ParentId = response.Headers.FileParentId
                }
            };
        }

        internal static ShareDirectoryProperties ToShareDirectoryProperties(this ResponseWithHeaders<DirectoryGetPropertiesHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new ShareDirectoryProperties()
            {
                Metadata = response.Headers.Metadata,
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                IsServerEncrypted = response.Headers.IsServerEncrypted.GetValueOrDefault(),
                SmbProperties = new FileSmbProperties()
                {
                    FileAttributes = ToFileAttributes(response.Headers.FileAttributes),
                    FilePermissionKey = response.Headers.FilePermissionKey,
                    FileCreatedOn = response.Headers.FileCreationTime,
                    FileLastWrittenOn = response.Headers.FileLastWriteTime,
                    FileChangedOn = response.Headers.FileChangeTime,
                    FileId = response.Headers.FileId,
                    ParentId = response.Headers.FileParentId
                }
            };
        }

        internal static ShareDirectoryInfo ToShareDirectoryInfo(this ResponseWithHeaders<DirectorySetPropertiesHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new ShareDirectoryInfo
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                SmbProperties = new FileSmbProperties
                {
                    FileAttributes = ToFileAttributes(response.Headers.FileAttributes),
                    FilePermissionKey = response.Headers.FilePermissionKey,
                    FileCreatedOn = response.Headers.FileCreationTime,
                    FileLastWrittenOn = response.Headers.FileLastWriteTime,
                    FileChangedOn = response.Headers.FileChangeTime,
                    FileId = response.Headers.FileId,
                    ParentId = response.Headers.FileParentId
                }
            };
        }

        internal static ShareDirectoryInfo ToShareDirectoryInfo(this ResponseWithHeaders<DirectorySetMetadataHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            // Set Directory metadata returns limited resposne headers - https://docs.microsoft.com/en-us/rest/api/storageservices/set-directory-metadata.
            return new ShareDirectoryInfo
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                SmbProperties = new FileSmbProperties()
            };
        }

        internal static StorageHandlesSegment ToStorageHandlesSegment(this ListHandlesResponse listHandlesResponse)
        {
            if (listHandlesResponse == null)
            {
                return null;
            }

            return new StorageHandlesSegment()
            {
                NextMarker = listHandlesResponse.NextMarker,
                Handles = listHandlesResponse.HandleList.ToList()
            };
        }

        internal static StorageClosedHandlesSegment ToStorageClosedHandlesSegment(this ResponseWithHeaders<DirectoryForceCloseHandlesHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new StorageClosedHandlesSegment
            {
                Marker = response.Headers.Marker,
                NumberOfHandlesClosed = response.Headers.NumberOfHandlesClosed.GetValueOrDefault(),
                NumberOfHandlesFailedToClose = response.Headers.NumberOfHandlesFailedToClose.GetValueOrDefault()
            };
        }

        internal static ShareFileInfo ToShareFileInfo(this ResponseWithHeaders<FileCreateHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new ShareFileInfo
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                IsServerEncrypted = response.Headers.IsServerEncrypted.GetValueOrDefault(),
                SmbProperties = new FileSmbProperties()
                {
                    FileAttributes = ToFileAttributes(response.Headers.FileAttributes),
                    FilePermissionKey = response.Headers.FilePermissionKey,
                    FileCreatedOn = response.Headers.FileCreationTime,
                    FileLastWrittenOn = response.Headers.FileLastWriteTime,
                    FileChangedOn = response.Headers.FileLastWriteTime,
                    FileId = response.Headers.FileId,
                    ParentId = response.Headers.FileParentId
                }
            };
        }

        internal static ShareFileCopyInfo ToShareFileCopyInfo(this ResponseWithHeaders<FileStartCopyHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new ShareFileCopyInfo
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                CopyId = response.Headers.CopyId,
                CopyStatus = response.Headers.CopyStatus.GetValueOrDefault()
            };
        }

        internal static ShareFileProperties ToShareFileProperties(this ResponseWithHeaders<FileGetPropertiesHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            ShareFileProperties shareFileProperties = new ShareFileProperties
            {
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                Metadata = response.Headers.Metadata,
                ContentLength = response.Headers.ContentLength.GetValueOrDefault(),
                ContentType = response.Headers.ContentType,
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                ContentHash = response.Headers.ContentMD5,
                CacheControl = response.Headers.CacheControl,
                ContentDisposition = response.Headers.ContentDisposition,
                CopyCompletedOn = response.Headers.CopyCompletionTime.GetValueOrDefault(),
                CopyStatusDescription = response.Headers.CopyStatusDescription,
                CopyId = response.Headers.CopyId,
                CopyProgress = response.Headers.CopyProgress,
                CopySource = response.Headers.CopySource,
                CopyStatus = response.Headers.CopyStatus.GetValueOrDefault(),
                IsServerEncrypted = response.Headers.IsServerEncrypted.GetValueOrDefault(),
                SmbProperties = new FileSmbProperties
                {
                    FileAttributes = ToFileAttributes(response.Headers.FileAttributes),
                    FilePermissionKey = response.Headers.FilePermissionKey,
                    FileCreatedOn = response.Headers.FileCreationTime,
                    FileLastWrittenOn = response.Headers.FileLastWriteTime,
                    FileChangedOn = response.Headers.FileChangeTime,
                    FileId = response.Headers.FileId,
                    ParentId = response.Headers.FileParentId
                },
                LeaseDuration = response.Headers.LeaseDuration.GetValueOrDefault(),
                LeaseState = response.Headers.LeaseState.GetValueOrDefault(),
                LeaseStatus = response.Headers.LeaseStatus.GetValueOrDefault()
            };

            if (response.Headers.ContentEncoding != null)
            {
                shareFileProperties.ContentEncoding = response.Headers.ContentEncoding.Split(Constants.CommaChar);
            }

            if (response.Headers.ContentLanguage != null)
            {
                shareFileProperties.ContentLanguage = response.Headers.ContentLanguage.Split(Constants.CommaChar);
            }

            return shareFileProperties;
        }

        internal static ShareFileInfo ToShareFileInfo(this ResponseWithHeaders<FileSetHttpHeadersHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new ShareFileInfo
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                IsServerEncrypted = response.Headers.IsServerEncrypted.GetValueOrDefault(),
                SmbProperties = new FileSmbProperties
                {
                    FileAttributes = ToFileAttributes(response.Headers.FileAttributes),
                    FilePermissionKey = response.Headers.FilePermissionKey,
                    FileCreatedOn = response.Headers.FileCreationTime,
                    FileLastWrittenOn = response.Headers.FileLastWriteTime,
                    FileChangedOn = response.Headers.FileChangeTime,
                    FileId = response.Headers.FileId,
                    ParentId = response.Headers.FileParentId
                }
            };
        }

        internal static ShareFileInfo ToShareFileInfo(this ResponseWithHeaders<FileSetMetadataHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new ShareFileInfo
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                IsServerEncrypted = response.Headers.IsServerEncrypted.GetValueOrDefault(),
                SmbProperties = new FileSmbProperties {}
            };
        }

        internal static ShareFileUploadInfo ToShareFileUploadInfo(this ResponseWithHeaders<FileUploadRangeHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new ShareFileUploadInfo()
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                ContentHash = response.Headers.ContentMD5,
                IsServerEncrypted = response.Headers.IsServerEncrypted.GetValueOrDefault()
            };
        }

        internal static ShareFileUploadInfo ToShareFileUploadInfo(this ResponseWithHeaders<FileUploadRangeFromURLHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new ShareFileUploadInfo
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                ContentHash = response.Headers.ContentMD5,
                IsServerEncrypted = response.Headers.IsServerEncrypted.GetValueOrDefault(),
            };
        }

        internal static ShareFileRangeInfo ToShareFileRangeInfo(this ResponseWithHeaders<ShareFileRangeList, FileGetRangeListHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new ShareFileRangeInfo
            {
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                FileContentLength = response.Headers.FileContentLength.GetValueOrDefault(),
                Ranges = response.Value.Ranges.Select(r => r.ToHttpRange()).ToList(),
                ClearRanges = response.Value.ClearRanges.Select(r => r.ToHttpRange()).ToList(),
            };
        }

        internal static HttpRange ToHttpRange(this FileRange fileRange)
            => new HttpRange(fileRange.Start, fileRange.End - fileRange.Start + 1);

        internal static HttpRange ToHttpRange(this ClearRange clearRange)
            => new HttpRange(clearRange.Start, clearRange.End - clearRange.Start + 1);

        internal static StorageClosedHandlesSegment ToStorageClosedHandlesSegment(this ResponseWithHeaders<FileForceCloseHandlesHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new StorageClosedHandlesSegment
            {
                Marker = response.Headers.Marker,
                NumberOfHandlesClosed = response.Headers.NumberOfHandlesClosed.GetValueOrDefault(),
                NumberOfHandlesFailedToClose = response.Headers.NumberOfHandlesFailedToClose.GetValueOrDefault()
            };
        }

        internal static ShareFileLease ToShareFileLease(this ResponseWithHeaders<FileAcquireLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            int? leaseTime = null;

            if (response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.LeaseTime, out string leaseTimeString))
            {
                leaseTime = int.Parse(leaseTimeString, CultureInfo.InvariantCulture);
            }

            return new ShareFileLease()
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                LeaseId = response.Headers.LeaseId,
                LeaseTime = leaseTime
            };
        }

        internal static ShareFileLease ToShareFileLease(this ResponseWithHeaders<ShareAcquireLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new ShareFileLease
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                LeaseId = response.Headers.LeaseId,
                // File Aquire Lease does not return LeastTime.
            };
        }

        internal static FileLeaseReleaseInfo ToFileLeaseReleaseInfo(this ResponseWithHeaders<FileReleaseLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new FileLeaseReleaseInfo
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault()
            };
        }

        internal static FileLeaseReleaseInfo ToFileLeaseReleaseInfo(this ResponseWithHeaders<ShareReleaseLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new FileLeaseReleaseInfo
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
            };
        }

        internal static ShareFileLease ToShareFileLease(this ResponseWithHeaders<FileChangeLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            int? leaseTime = null;

            if (response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.LeaseTime, out string leaseTimeString))
            {
                leaseTime = int.Parse(leaseTimeString, CultureInfo.InvariantCulture);
            }

            return new ShareFileLease
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                LeaseId = response.Headers.LeaseId,
                LeaseTime = leaseTime,
            };
        }

        internal static ShareFileLease ToShareFileLease(this ResponseWithHeaders<ShareRenewLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            int? leaseTime = null;

            if (response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.LeaseTime, out string leaseTimeString))
            {
                leaseTime = int.Parse(leaseTimeString, CultureInfo.InvariantCulture);
            }

            return new ShareFileLease
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                LeaseId = response.Headers.LeaseId,
                LeaseTime = leaseTime
            };
        }

        internal static ShareFileLease ToShareFileLease(this ResponseWithHeaders<ShareChangeLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            int? leaseTime = null;

            if (response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.LeaseTime, out string leaseTimeString))
            {
                leaseTime = int.Parse(leaseTimeString, CultureInfo.InvariantCulture);
            }

            return new ShareFileLease
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                LeaseId = response.Headers.LeaseId,
                LeaseTime = leaseTime,
            };
        }

        internal static ShareFileLease ToShareFileLease(this ResponseWithHeaders<FileBreakLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            int? leaseTime = null;

            if (response.GetRawResponse().Headers.TryGetValue(Constants.HeaderNames.LeaseTime, out string leaseTimeString))
            {
                leaseTime = int.Parse(leaseTimeString, CultureInfo.InvariantCulture);
            }

            return new ShareFileLease
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                // Break lease does not return lease Id.
                LeaseId = null,
                LeaseTime = leaseTime
            };
        }

        internal static ShareFileLease ToShareFileLease(this ResponseWithHeaders<ShareBreakLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new ShareFileLease
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                LeaseId = response.Headers.LeaseId,
                LeaseTime = response.Headers.LeaseTime
            };
        }

        internal static ShareFileLease ToShareFileLease(this ResponseWithHeaders<FileReleaseLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new ShareFileLease
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                // File Release Lease does not return LeaseId or LeaseTime
            };
        }

        internal static ShareInfo ToShareInfo(this ResponseWithHeaders<ShareCreateHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new ShareInfo
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault()
            };
        }

        internal static ShareSnapshotInfo ToShareSnapshotInfo(this ResponseWithHeaders<ShareCreateSnapshotHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new ShareSnapshotInfo
            {
                Snapshot = response.Headers.Snapshot,
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault()
            };
        }

        internal static ShareProperties ToShareProperties(this ResponseWithHeaders<ShareGetPropertiesHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new ShareProperties
            {
                LastModified = response.Headers.LastModified,
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                ProvisionedIops = response.Headers.ProvisionedIops,
                ProvisionedIngressMBps = response.Headers.ProvisionedIngressMBps,
                ProvisionedEgressMBps = response.Headers.ProvisionedEgressMBps,
                NextAllowedQuotaDowngradeTime = response.Headers.NextAllowedQuotaDowngradeTime,
                DeletedOn = null,
                RemainingRetentionDays = null,
                AccessTier = response.Headers.AccessTier,
                AccessTierChangeTime = response.Headers.AccessTierChangeTime,
                AccessTierTransitionState = response.Headers.AccessTierTransitionState,
                LeaseStatus = response.Headers.LeaseStatus,
                LeaseState = response.Headers.LeaseState,
                LeaseDuration = response.Headers.LeaseDuration,
                Protocols =  ToShareEnabledProtocols(response.Headers.EnabledProtocols),
                RootSquash = response.Headers.RootSquash,
                QuotaInGB = response.Headers.Quota,
                Metadata = response.Headers.Metadata
            };
        }

        internal static ShareInfo ToShareInfo(this ResponseWithHeaders<ShareSetPropertiesHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new ShareInfo
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault()
            };
        }

        internal static ShareInfo ToShareInfo(this ResponseWithHeaders<ShareSetMetadataHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new ShareInfo
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault()
            };
        }

        internal static ShareInfo ToShareInfo(this ResponseWithHeaders<ShareSetAccessPolicyHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            return new ShareInfo
            {
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault()
            };
        }

        internal static PermissionInfo ToPermissionInfo(this ResponseWithHeaders<ShareCreatePermissionHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new PermissionInfo
            {
                FilePermissionKey = response.Headers.FilePermissionKey
            };
        }

        internal static IEnumerable<ShareItem> ToShareItems(this IReadOnlyList<ShareItemInternal> shareItemInternals)
        {
            if (shareItemInternals == null)
            {
                return null;
            }

            return shareItemInternals.Select(r => r.ToShareItem());
        }

        internal static ShareItem ToShareItem(this ShareItemInternal shareItemInternal)
        {
            if (shareItemInternal == null)
            {
                return null;
            }

            return new ShareItem
            {
                Name = shareItemInternal.Name,
                Snapshot = shareItemInternal.Snapshot,
                IsDeleted = shareItemInternal.Deleted,
                VersionId = shareItemInternal.Version,
                Properties = ToShareProperties(shareItemInternal.Properties, shareItemInternal.Metadata),
            };
        }

        internal static ShareProperties ToShareProperties(SharePropertiesInternal sharePropertiesInternal, IReadOnlyDictionary<string, string> rawMetadata)
        {
            if (sharePropertiesInternal == null)
            {
                return null;
            }

            IDictionary<string, string> metadata = rawMetadata?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            return new ShareProperties
            {
                LastModified = sharePropertiesInternal.LastModified,
                ETag = new ETag(sharePropertiesInternal.Etag),
                ProvisionedIops = sharePropertiesInternal.ProvisionedIops,
                ProvisionedIngressMBps = sharePropertiesInternal.ProvisionedIngressMBps,
                ProvisionedEgressMBps = sharePropertiesInternal.ProvisionedEgressMBps,
                NextAllowedQuotaDowngradeTime = sharePropertiesInternal.NextAllowedQuotaDowngradeTime,
                DeletedOn = sharePropertiesInternal.DeletedTime,
                RemainingRetentionDays = sharePropertiesInternal.RemainingRetentionDays,
                AccessTier = sharePropertiesInternal.AccessTier,
                AccessTierChangeTime = sharePropertiesInternal.AccessTierChangeTime,
                AccessTierTransitionState = sharePropertiesInternal.AccessTierTransitionState,
                LeaseStatus = sharePropertiesInternal.LeaseStatus,
                LeaseState = sharePropertiesInternal.LeaseState,
                LeaseDuration = sharePropertiesInternal.LeaseDuration,
                Protocols = ToShareEnabledProtocols(sharePropertiesInternal.EnabledProtocols),
                RootSquash = sharePropertiesInternal.RootSquash,
                QuotaInGB = sharePropertiesInternal.Quota,
                Metadata = metadata
            };
        }

        internal static ShareFileDownloadInfo ToShareFileDownloadInfo(this ResponseWithHeaders<Stream, FileDownloadHeaders> response)
        {
            if (response == null)
            {
                return null;
            }
            ShareFileDownloadInfo shareFileDownloadInfo = new ShareFileDownloadInfo
            {
                ContentLength = response.Headers.ContentLength.GetValueOrDefault(),
                Content = response.Value,
                ContentType = response.Headers.ContentType,
                ContentHash = response.Headers.ContentMD5,
                Details = new ShareFileDownloadDetails
                {
                    LastModified = response.Headers.LastModified.GetValueOrDefault(),
                    Metadata = response.Headers.Metadata,
                    ContentRange = response.Headers.ContentRange,
                    ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                    CacheControl = response.Headers.CacheControl,
                    ContentDisposition = response.Headers.ContentDisposition,
                    AcceptRanges = response.Headers.AcceptRanges,
                    CopyCompletedOn = response.Headers.CopyCompletionTime.GetValueOrDefault(),
                    CopyStatusDescription = response.Headers.CopyStatusDescription,
                    CopyId = response.Headers.CopyId,
                    CopyProgress = response.Headers.CopyProgress,
                    CopySource = response.Headers.CopySource == null ? null : new Uri(response.Headers.CopySource),
                    CopyStatus = response.Headers.CopyStatus.GetValueOrDefault(),
                    FileContentHash = response.Headers.FileContentMD5,
                    IsServerEncrypted = response.Headers.IsServerEncrypted.GetValueOrDefault(),
                    LeaseDuration = response.Headers.LeaseDuration.GetValueOrDefault(),
                    LeaseState = response.Headers.LeaseState.GetValueOrDefault(),
                    LeaseStatus = response.Headers.LeaseStatus.GetValueOrDefault(),
                    SmbProperties = new FileSmbProperties
                    {
                        FileAttributes = ToFileAttributes(response.Headers.FileAttributes),
                        FilePermissionKey = response.Headers.FilePermissionKey,
                        FileCreatedOn = response.Headers.FileCreationTime,
                        FileLastWrittenOn = response.Headers.FileLastWriteTime,
                        FileChangedOn = response.Headers.FileChangeTime,
                        FileId = response.Headers.FileId,
                        ParentId = response.Headers.FileParentId
                    }
                }
            };

            if (response.Headers.ContentEncoding != null)
            {
                shareFileDownloadInfo.Details.ContentEncoding = response.Headers.ContentEncoding.Split(Constants.CommaChar);
            }

            if (response.Headers.ContentLanguage != null)
            {
                shareFileDownloadInfo.Details.ContentLanguage = response.Headers.ContentLanguage.Split(Constants.CommaChar);
            }

            return shareFileDownloadInfo;
        }

        internal static FileHttpHeaders ToFileHttpHeaders(this ShareFileHttpHeaders shareFileHttpHeaders)
        {
            if (shareFileHttpHeaders == null)
            {
                return null;
            }
            FileHttpHeaders httpHeaders = new FileHttpHeaders
            {
                FileContentType = shareFileHttpHeaders.ContentType,
                FileContentDisposition = shareFileHttpHeaders.ContentDisposition,
                FileCacheControl = shareFileHttpHeaders.CacheControl,
                FileContentMD5 = shareFileHttpHeaders.ContentHash
            };

            if (shareFileHttpHeaders.ContentEncoding != null)
            {
                httpHeaders.FileContentEncoding = string.Join(Constants.CommaString, shareFileHttpHeaders.ContentEncoding);
            }

            if (shareFileHttpHeaders.ContentLanguage != null)
            {
                httpHeaders.FileContentLanguage = string.Join(Constants.CommaString, shareFileHttpHeaders.ContentLanguage);
            }

            return httpHeaders;
        }

        internal static ShareFileItem ToShareFileItem(this DirectoryItem directoryItem)
        {
            if (directoryItem == null)
            {
                return null;
            }

            return new ShareFileItem(
                isDirectory: true,
                name: directoryItem.Name,
                id: directoryItem.FileId,
                properties: directoryItem.Properties.ToShareFileItemProperties(),
                fileAttributes: ToFileAttributes(directoryItem.Attributes),
                permissionKey: directoryItem.PermissionKey,
                fileSize: null);
        }

        internal static ShareFileItem ToShareFileItem(this FileItem fileItem)
        {
            if (fileItem == null)
            {
                return null;
            }

            return new ShareFileItem(
                isDirectory: false,
                name: fileItem.Name,
                id: fileItem.FileId,
                properties: fileItem.Properties.ToShareFileItemProperties(),
                fileAttributes: ToFileAttributes(fileItem.Attributes),
                permissionKey: fileItem.PermissionKey,
                fileSize: fileItem.Properties.ContentLength);
        }

        internal static ShareFileItemProperties ToShareFileItemProperties(this FileProperty fileProperty)
        {
            if (fileProperty == null)
            {
                return null;
            }

            return new ShareFileItemProperties(
                createdOn: fileProperty.CreationTime,
                lastAccessedOn: fileProperty.LastAccessTime,
                lastWrittenOn: fileProperty.LastWriteTime,
                changedOn: fileProperty.ChangeTime,
                lastModified: fileProperty.LastModified,
                eTag: fileProperty.Etag == null ? null : new ETag(fileProperty.Etag));
        }
    }
}
