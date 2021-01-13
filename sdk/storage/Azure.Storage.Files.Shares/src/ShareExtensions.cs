// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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

        // TODO fix this.
        //internal static Response<ShareFileLease> ToLease(this Response<BrokenLease> response)
        //    => Response.FromValue(
        //        new ShareFileLease
        //        {
        //            ETag = response.Value.ETag,
        //            LastModified = response.Value.LastModified,
        //            LeaseId = response.Value.LeaseId,
        //            LeaseTime = response.Value.LeaseTime
        //        }, response.GetRawResponse());

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
        internal static ShareDirectoryInfo ToShareDirectoryInfo(this DirectoryCreateHeaders directoryCreateHeaders)
        {
            return null;
        }

        internal static ShareDirectoryProperties ToShareDirectoryProperties(this DirectoryGetPropertiesHeaders directoryGetPropertiesHeaders)
        {
            if (directoryGetPropertiesHeaders == null)
            {
                return null;
            }
            return new ShareDirectoryProperties()
            {
                Metadata = directoryGetPropertiesHeaders.Metadata,
                // TODO
                //ETag = directoryGetPropertiesHeaders.Etag;
                LastModified = directoryGetPropertiesHeaders.LastModified.GetValueOrDefault(),
                IsServerEncrypted = directoryGetPropertiesHeaders.IsServerEncrypted.GetValueOrDefault(),
                SmbProperties = new FileSmbProperties()
                {
                    // TODO
                    //FileAttributes = directoryGetPropertiesHeaders.FileAttributes,
                    FilePermissionKey = directoryGetPropertiesHeaders.FilePermissionKey,
                    FileCreatedOn = directoryGetPropertiesHeaders.FileCreationTime,
                    FileLastWrittenOn = directoryGetPropertiesHeaders.FileLastWriteTime,
                    FileChangedOn = directoryGetPropertiesHeaders.FileChangeTime,
                    FileId = directoryGetPropertiesHeaders.FileId,
                    ParentId = directoryGetPropertiesHeaders.FileParentId
                }
            };
        }

        // TODO
        internal static ShareDirectoryInfo ToShareDirectoryInfo(this DirectorySetPropertiesHeaders directorySetPropertiesHeaders)
        {
            return null;
        }

        // TODO
        internal static ShareDirectoryInfo ToShareDirectoryInfo(this DirectorySetMetadataHeaders directorySetMetadataHeaders)
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
        internal static StorageClosedHandlesSegment ToStorageClosedHandlesSegment(this DirectoryForceCloseHandlesHeaders directoryForceCloseHandlesHeaders)
        {
            return null;
        }

        internal static ShareFileInfo ToShareFileInfo(this FileCreateHeaders fileCreateHeaders)
        {
            if (fileCreateHeaders == null)
            {
                return null;
            }

            return new ShareFileInfo
            {
                // TODO
                //ETag = fileCreateHeaders.ETag
                LastModified = fileCreateHeaders.LastModified.GetValueOrDefault(),
                IsServerEncrypted = fileCreateHeaders.IsServerEncrypted.GetValueOrDefault(),
                SmbProperties = new FileSmbProperties()
                {
                    // TODO
                    //FileAttributes = fileCreateHeaders.FileAttributes
                    FilePermissionKey = fileCreateHeaders.FilePermissionKey,
                    FileCreatedOn = fileCreateHeaders.FileCreationTime,
                    FileLastWrittenOn = fileCreateHeaders.FileLastWriteTime,
                    FileChangedOn = fileCreateHeaders.FileLastWriteTime,
                    FileId = fileCreateHeaders.FileId,
                    ParentId = fileCreateHeaders.FileParentId
                }
            };
        }

        // TODO
        internal static ShareFileCopyInfo ToShareFileCopyInfo(this FileStartCopyHeaders fileStartCopyHeaders)
        {
            return null;
        }

        // TODO
        internal static ShareFileProperties ToShareFileProperties(this FileGetPropertiesHeaders fileGetPropertiesHeaders)
        {
            return null;
        }

        // TODO
        internal static ShareFileInfo ToShareFileInfo(this FileSetHttpHeadersHeaders fileSetHttpHeadersHeaders)
        {
            return null;
        }

        // TODO
        internal static ShareFileInfo ToShareFileInfo(this FileSetMetadataHeaders fileSetMetadataHeaders)
        {
            return null;
        }

        internal static ShareFileUploadInfo ToShareFileUploadInfo(this FileUploadRangeHeaders fileUploadRangeHeaders)
        {
            if (fileUploadRangeHeaders == null)
            {
                return null;
            }
            return new ShareFileUploadInfo()
            {
                // TODO
                //ETag = fileUploadRangeHeaders.Etag,
                LastModified = fileUploadRangeHeaders.LastModified.GetValueOrDefault(),
                ContentHash = fileUploadRangeHeaders.ContentMD5,
                IsServerEncrypted = fileUploadRangeHeaders.IsServerEncrypted.GetValueOrDefault()
            };
        }

        // TODO
        internal static ShareFileUploadInfo ToShareFileUploadInfo(this FileUploadRangeFromURLHeaders fileUploadRangeFromURLHeaders)
        {
            return null;
        }

        internal static ShareFileRangeInfo ToShareFileRangeInfo(ShareFileRangeList shareFileRangeList, FileGetRangeListHeaders fileGetRangeListHeaders)
        {
            if (shareFileRangeList == null)
            {
                return null;
            }
            return new ShareFileRangeInfo
            {
                LastModified = fileGetRangeListHeaders.LastModified.GetValueOrDefault(),
                // TODO
                //ETag = fileGetRangeListHeaders.ETag,
                FileContentLength = fileGetRangeListHeaders.FileContentLength.GetValueOrDefault(),
                Ranges = (IEnumerable<HttpRange>)shareFileRangeList.Ranges.ToList(),
                ClearRanges = (IEnumerable<HttpRange>)shareFileRangeList.ClearRanges.ToList(),
            };
        }

        internal static StorageClosedHandlesSegment ToStorageClosedHandlesSegment(this FileForceCloseHandlesHeaders fileForceCloseHandlesHeaders)
        {
            if (fileForceCloseHandlesHeaders == null)
            {
                return null;
            }
            return new StorageClosedHandlesSegment
            {
                Marker = fileForceCloseHandlesHeaders.Marker,
                NumberOfHandlesClosed = fileForceCloseHandlesHeaders.NumberOfHandlesClosed.GetValueOrDefault(),
                NumberOfHandlesFailedToClose = fileForceCloseHandlesHeaders.NumberOfHandlesFailedToClose.GetValueOrDefault()
            };
        }

        internal static ShareFileLease ToShareFileLease(this FileAcquireLeaseHeaders fileAcquireLeaseHeaders)
        {
            if (fileAcquireLeaseHeaders == null)
            {
                return null;
            }
            return new ShareFileLease()
            {
                // TODO
                //ETag = fileAcquireLeaseHeaders.Etag
                LastModified = fileAcquireLeaseHeaders.LastModified.GetValueOrDefault(),
                LeaseId = fileAcquireLeaseHeaders.LeaseId,
                // TODO
                //LeaseTime = fileAcquireLeaseHeaders.leaseTime,
            };
        }

        // TODO
        internal static ShareFileLease ToShareFileLease(this ShareAcquireLeaseHeaders shareAcquireLeaseHeaders)
        {
            return null;
        }

        // TODO
        internal static FileLeaseReleaseInfo ToFileLeaseReleaseInfo(this FileReleaseLeaseHeaders fileReleaseLeaseHeaders)
        {
            return null;
        }

        // TODO
        internal static FileLeaseReleaseInfo ToFileLeaseReleaseInfo(this ShareReleaseLeaseHeaders shareReleaseLeaseHeaders)
        {
            return null;
        }

        // TODO
        internal static ShareFileLease ToShareFileLease(this FileChangeLeaseHeaders fileChangeLeaseHeaders)
        {
            return null;
        }

        // TODO
        internal static ShareFileLease ToShareFileLease(this ShareChangeLeaseHeaders shareChangeLeaseHeaders)
        {
            return null;
        }

        // TODO
        internal static ShareFileLease ToShareFileLease(this FileBreakLeaseHeaders fileBreakLeaseHeaders)
        {
            return null;
        }

        // TODO
        internal static ShareFileLease ToShareFileLease(this ShareBreakLeaseHeaders fileBreakLeaseHeaders)
        {
            return null;
        }

        // TODO
        internal static ShareFileLease ToShareFileLease(this FileReleaseLeaseHeaders fileReleaseLeaseHeaders)
        {
            return null;
        }

        // TODO
        internal static ShareInfo ToShareInfo(this ShareCreateHeaders shareCreateHeaders)
        {
            return null;
        }

        // TODO
        internal static ShareSnapshotInfo ToShareSnapshotInfo(this ShareCreateSnapshotHeaders shareCreateSnapshotHeaders)
        {
            return null;
        }

        // TODO
        internal static ShareProperties ToShareProperties(this ShareGetPropertiesHeaders shareGetPropertiesHeaders)
        {
            if (shareGetPropertiesHeaders == null)
            {
                return null;
            }

            return new ShareProperties
            {
                LastModified = shareGetPropertiesHeaders.LastModified,
                // TODO fix this.
                ETag = new ETag(""),
                ProvisionedIops = shareGetPropertiesHeaders.ProvisionedIops,
                ProvisionedIngressMBps = shareGetPropertiesHeaders.ProvisionedIngressMBps,
                ProvisionedEgressMBps = shareGetPropertiesHeaders.ProvisionedEgressMBps,
                NextAllowedQuotaDowngradeTime = shareGetPropertiesHeaders.NextAllowedQuotaDowngradeTime,
                // TODO fix this.
                DeletedOn = null,
                // TODO fix this.
                RemainingRetentionDays = null,
                AccessTier = shareGetPropertiesHeaders.AccessTier,
                AccessTierChangeTime = shareGetPropertiesHeaders.AccessTierChangeTime,
                AccessTierTransitionState = shareGetPropertiesHeaders.AccessTierTransitionState,
                // TODO fix this
                //LeaseStatus = shareGetPropertiesHeaders.LeaseStatus,
                //LeaseState = shareGetPropertiesHeaders.LeaseState,
                //LeaseDuration = shareGetPropertiesHeaders.LeaseDuration,
                //Protocols = shareGetPropertiesHeaders.EnabledProtocols,
                RootSquash = shareGetPropertiesHeaders.RootSquash,
                QuotaInGB = shareGetPropertiesHeaders.Quota,
                Metadata = shareGetPropertiesHeaders.Metadata
            };
        }

        // TODO
        internal static ShareInfo ToShareInfo(this ShareSetPropertiesHeaders shareSetPropertiesHeaders)
        {
            return null;
        }

        // TODO
        internal static ShareInfo ToShareInfo(this ShareSetMetadataHeaders shareSetMetadataHeaders)
        {
            return null;
        }

        // TODO
        internal static ShareInfo ToShareInfo(this ShareSetAccessPolicyHeaders shareSetAccessPolicyHeaders)
        {
            return null;
        }

        // TODO
        internal static PermissionInfo ToPermissionInfo(this ShareCreatePermissionHeaders shareCreatePermissionHeaders)
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

        internal static ShareFileDownloadInfo ToShareFileDownloadInfo(FileDownloadHeaders fileDownloadHeaders, Stream content)
        {
            if (fileDownloadHeaders == null)
            {
                return null;
            }
            return new ShareFileDownloadInfo
            {
                ContentLength = fileDownloadHeaders.ContentLength.GetValueOrDefault(),
                Content = content,
                ContentType = fileDownloadHeaders.ContentType,
                ContentHash = fileDownloadHeaders.ContentMD5,
                Details = new ShareFileDownloadDetails
                {
                    LastModified = fileDownloadHeaders.LastModified.GetValueOrDefault(),
                    Metadata = fileDownloadHeaders.Metadata,
                    ContentRange = fileDownloadHeaders.ContentRange,
                    // TODO
                    //ETag = fileDownloadHeaders.Etag
                    // TODO
                    //ContentEncoding = fileDownloadHeaders.ContentEncoding,
                    CacheControl = fileDownloadHeaders.CacheControl,
                    ContentDisposition = fileDownloadHeaders.ContentDisposition,
                    // TODO
                    //ContentLanguage = fileDownloadHeaders.ContentLanguage,
                    AcceptRanges = fileDownloadHeaders.AcceptRanges,
                    CopyCompletedOn = fileDownloadHeaders.CopyCompletionTime.GetValueOrDefault(),
                    CopyStatusDescription = fileDownloadHeaders.CopyStatusDescription,
                    CopyId = fileDownloadHeaders.CopyId,
                    CopyProgress = fileDownloadHeaders.CopyProgress,
                    // TODO
                    //CopySource = fileDownloadHeaders.CopySource,
                    // TODO
                    //CopyStatus = fileDownloadHeaders.CopyStatus,
                    FileContentHash = fileDownloadHeaders.FileContentMD5,
                    IsServerEncrypted = fileDownloadHeaders.IsServerEncrypted.GetValueOrDefault(),
                    LeaseDuration = fileDownloadHeaders.LeaseDuration.GetValueOrDefault(),
                    LeaseState = fileDownloadHeaders.LeaseState.GetValueOrDefault(),
                    LeaseStatus = fileDownloadHeaders.LeaseStatus.GetValueOrDefault(),
                    SmbProperties = new FileSmbProperties
                    {
                        // TODO
                        //FileAttributes = fileDownloadHeaders.FileAttributes,
                        FilePermissionKey = fileDownloadHeaders.FilePermissionKey,
                        FileCreatedOn = fileDownloadHeaders.FileCreationTime,
                        FileLastWrittenOn = fileDownloadHeaders.FileLastWriteTime,
                        FileChangedOn = fileDownloadHeaders.FileChangeTime,
                        FileId = fileDownloadHeaders.FileId,
                        ParentId = fileDownloadHeaders.FileParentId
                    }
                }
            };
        }
    }
}
