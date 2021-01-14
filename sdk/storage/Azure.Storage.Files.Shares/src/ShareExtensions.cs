// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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

        // TODO
        internal static ShareDirectoryInfo ToShareDirectoryInfo(this ResponseWithHeaders<DirectoryCreateHeaders> response)
        {
            return null;
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
                // TODO
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                IsServerEncrypted = response.Headers.IsServerEncrypted.GetValueOrDefault(),
                SmbProperties = new FileSmbProperties()
                {
                    // TODO
                    //FileAttributes = directoryGetPropertiesHeaders.FileAttributes,
                    FilePermissionKey = response.Headers.FilePermissionKey,
                    FileCreatedOn = response.Headers.FileCreationTime,
                    FileLastWrittenOn = response.Headers.FileLastWriteTime,
                    FileChangedOn = response.Headers.FileChangeTime,
                    FileId = response.Headers.FileId,
                    ParentId = response.Headers.FileParentId
                }
            };
        }

        // TODO
        internal static ShareDirectoryInfo ToShareDirectoryInfo(this ResponseWithHeaders<DirectorySetPropertiesHeaders> response)
        {
            return null;
        }

        // TODO
        internal static ShareDirectoryInfo ToShareDirectoryInfo(this ResponseWithHeaders<DirectorySetMetadataHeaders> response)
        {
            return null;
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

        // TODO
        internal static StorageClosedHandlesSegment ToStorageClosedHandlesSegment(this ResponseWithHeaders<DirectoryForceCloseHandlesHeaders> response)
        {
            return null;
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
                    // TODO
                    //FileAttributes = fileCreateHeaders.FileAttributes
                    FilePermissionKey = response.Headers.FilePermissionKey,
                    FileCreatedOn = response.Headers.FileCreationTime,
                    FileLastWrittenOn = response.Headers.FileLastWriteTime,
                    FileChangedOn = response.Headers.FileLastWriteTime,
                    FileId = response.Headers.FileId,
                    ParentId = response.Headers.FileParentId
                }
            };
        }

        // TODO
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
            return new ShareFileProperties
            {
                LastModified = response.Headers.LastModified.GetValueOrDefault(),
                Metadata = response.Headers.Metadata,
                ContentLength = response.Headers.ContentLength.GetValueOrDefault(),
                ContentType = response.Headers.ContentType,
                ETag = response.GetRawResponse().Headers.ETag.GetValueOrDefault(),
                ContentHash = response.Headers.ContentMD5,
                // TODO
                //ContentEncoding = response.Headers.ContentEncoding,
                CacheControl = response.Headers.CacheControl,
                ContentDisposition = response.Headers.ContentDisposition,
                // TODO
                //ContentLanguage = response.Headers.ContentLanguage,
                CopyCompletedOn = response.Headers.CopyCompletionTime.GetValueOrDefault(),
                CopyStatusDescription = response.Headers.CopyStatusDescription,
                CopyId = response.Headers.CopyId,
                CopyProgress = response.Headers.CopyProgress,
                CopySource = response.Headers.CopySource,
                CopyStatus = response.Headers.CopyStatus.GetValueOrDefault(),
                IsServerEncrypted = response.Headers.IsServerEncrypted.GetValueOrDefault(),
                SmbProperties = new FileSmbProperties
                {
                    // TODO
                    //FileAttributes = response.Headers.FileAttributes,
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
        }

        // TODO
        internal static ShareFileInfo ToShareFileInfo(this ResponseWithHeaders<FileSetHttpHeadersHeaders> response)
        {
            return null;
        }

        // TODO
        internal static ShareFileInfo ToShareFileInfo(this ResponseWithHeaders<FileSetMetadataHeaders> response)
        {
            return null;
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

        // TODO
        internal static ShareFileUploadInfo ToShareFileUploadInfo(this ResponseWithHeaders<FileUploadRangeFromURLHeaders> response)
        {
            return null;
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
                Ranges = (IEnumerable<HttpRange>)response.Value.Ranges.ToList(),
                ClearRanges = (IEnumerable<HttpRange>)response.Value.ClearRanges.ToList(),
            };
        }

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

            // TODO make this a constant.
            if (response.GetRawResponse().Headers.TryGetValue("x-ms-lease-time", out string leaseTimeString))
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

        // TODO
        internal static ShareFileLease ToShareFileLease(this ResponseWithHeaders<ShareAcquireLeaseHeaders> response)
        {
            return null;
        }

        // TODO
        internal static FileLeaseReleaseInfo ToFileLeaseReleaseInfo(this ResponseWithHeaders<FileReleaseLeaseHeaders> response)
        {
            return null;
        }

        // TODO
        internal static FileLeaseReleaseInfo ToFileLeaseReleaseInfo(this ResponseWithHeaders<ShareReleaseLeaseHeaders> response)
        {
            return null;
        }

        internal static ShareFileLease ToShareFileLease(this ResponseWithHeaders<FileChangeLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            int? leaseTime = null;

            // TODO make this a constant
            if (response.GetRawResponse().Headers.TryGetValue("x-ms-lease-time", out string leaseTimeString))
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

        internal static ShareFileLease ToShareFileLease(this ResponseWithHeaders<ShareChangeLeaseHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            int? leaseTime = null;

            // TODO make this a constant
            if (response.GetRawResponse().Headers.TryGetValue("x-ms-lease-time", out string leaseTimeString))
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

            // TODO make this a constant
            if (response.GetRawResponse().Headers.TryGetValue("x-ms-lease-time", out string leaseTimeString))
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
            return null;
        }

        // TODO
        internal static ShareFileLease ToShareFileLease(this ResponseWithHeaders<FileReleaseLeaseHeaders> response)
        {
            return null;
        }

        // TODO
        internal static ShareInfo ToShareInfo(this ResponseWithHeaders<ShareCreateHeaders> response)
        {
            return null;
        }

        // TODO
        internal static ShareSnapshotInfo ToShareSnapshotInfo(this ResponseWithHeaders<ShareCreateSnapshotHeaders> response)
        {
            return null;
        }

        // TODO
        internal static ShareProperties ToShareProperties(this ResponseWithHeaders<ShareGetPropertiesHeaders> response)
        {
            if (response == null)
            {
                return null;
            }

            return new ShareProperties
            {
                LastModified = response.Headers.LastModified,
                // TODO fix this.
                ETag = new ETag(""),
                ProvisionedIops = response.Headers.ProvisionedIops,
                ProvisionedIngressMBps = response.Headers.ProvisionedIngressMBps,
                ProvisionedEgressMBps = response.Headers.ProvisionedEgressMBps,
                NextAllowedQuotaDowngradeTime = response.Headers.NextAllowedQuotaDowngradeTime,
                // TODO fix this.
                DeletedOn = null,
                // TODO fix this.
                RemainingRetentionDays = null,
                AccessTier = response.Headers.AccessTier,
                AccessTierChangeTime = response.Headers.AccessTierChangeTime,
                AccessTierTransitionState = response.Headers.AccessTierTransitionState,
                // TODO fix this
                //LeaseStatus = shareGetPropertiesHeaders.LeaseStatus,
                //LeaseState = shareGetPropertiesHeaders.LeaseState,
                //LeaseDuration = shareGetPropertiesHeaders.LeaseDuration,
                //Protocols = shareGetPropertiesHeaders.EnabledProtocols,
                RootSquash = response.Headers.RootSquash,
                QuotaInGB = response.Headers.Quota,
                Metadata = response.Headers.Metadata
            };
        }

        // TODO
        internal static ShareInfo ToShareInfo(this ResponseWithHeaders<ShareSetPropertiesHeaders> response)
        {
            return null;
        }

        // TODO
        internal static ShareInfo ToShareInfo(this ResponseWithHeaders<ShareSetMetadataHeaders> response)
        {
            return null;
        }

        // TODO
        internal static ShareInfo ToShareInfo(this ResponseWithHeaders<ShareSetAccessPolicyHeaders> response)
        {
            return null;
        }

        // TODO
        internal static PermissionInfo ToPermissionInfo(this ResponseWithHeaders<ShareCreatePermissionHeaders> response)
        {
            return null;
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

            // TODO there has to be a better way to do this.
            IDictionary<string, string> metadata = null;

            if (rawMetadata != null)
            {
                metadata = new Dictionary<string, string>();
                rawMetadata.AsEnumerable().ToList().ForEach(r => metadata.Add(r));
            }

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
            return new ShareFileDownloadInfo
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
                    // TODO
                    //ETag = fileDownloadHeaders.Etag
                    // TODO
                    //ContentEncoding = fileDownloadHeaders.ContentEncoding,
                    CacheControl = response.Headers.CacheControl,
                    ContentDisposition = response.Headers.ContentDisposition,
                    // TODO
                    //ContentLanguage = fileDownloadHeaders.ContentLanguage,
                    AcceptRanges = response.Headers.AcceptRanges,
                    CopyCompletedOn = response.Headers.CopyCompletionTime.GetValueOrDefault(),
                    CopyStatusDescription = response.Headers.CopyStatusDescription,
                    CopyId = response.Headers.CopyId,
                    CopyProgress = response.Headers.CopyProgress,
                    // TODO
                    //CopySource = fileDownloadHeaders.CopySource,
                    // TODO
                    //CopyStatus = fileDownloadHeaders.CopyStatus,
                    FileContentHash = response.Headers.FileContentMD5,
                    IsServerEncrypted = response.Headers.IsServerEncrypted.GetValueOrDefault(),
                    LeaseDuration = response.Headers.LeaseDuration.GetValueOrDefault(),
                    LeaseState = response.Headers.LeaseState.GetValueOrDefault(),
                    LeaseStatus = response.Headers.LeaseStatus.GetValueOrDefault(),
                    SmbProperties = new FileSmbProperties
                    {
                        // TODO
                        //FileAttributes = fileDownloadHeaders.FileAttributes,
                        FilePermissionKey = response.Headers.FilePermissionKey,
                        FileCreatedOn = response.Headers.FileCreationTime,
                        FileLastWrittenOn = response.Headers.FileLastWriteTime,
                        FileChangedOn = response.Headers.FileChangeTime,
                        FileId = response.Headers.FileId,
                        ParentId = response.Headers.FileParentId
                    }
                }
            };
        }
    }
}
