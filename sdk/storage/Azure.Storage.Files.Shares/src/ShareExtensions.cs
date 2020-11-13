// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
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

        internal static Response<ShareFileLease> ToLease(this Response<BrokenLease> response)
            => Response.FromValue(
                new ShareFileLease
                {
                    ETag = response.Value.ETag,
                    LastModified = response.Value.LastModified,
                    LeaseId = response.Value.LeaseId,
                    LeaseTime = response.Value.LeaseTime
                }, response.GetRawResponse());

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

        internal static ShareSnapshotsDeleteOptionInternal? ToShareSnapshotsDeleteOptionInternal(this ShareSnapshotsDeleteOption? option)
        {
            if (option == null)
            {
                return null;
            }
            return option switch
            {
                ShareSnapshotsDeleteOption.Include => ShareSnapshotsDeleteOptionInternal.Include,
                ShareSnapshotsDeleteOption.IncludeWithLeased => ShareSnapshotsDeleteOptionInternal.IncludeLeased,
                _ => throw new ArgumentException($"Invalid {nameof(ShareSnapshotsDeleteOption)}: {option}"),
            };
        }

        internal static IEnumerable<ShareItem> ToShareItems(this IEnumerable<ShareItemInternal> shareItemInternals)
        {
            if (shareItemInternals == null)
            {
                return null;
            }

            List<ShareItem> result = new List<ShareItem>();
            foreach (ShareItemInternal shareItemInternal in shareItemInternals)
            {
                result.Add(shareItemInternal.ToShareItem());
            }
            return result;
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
                IsDeleted = shareItemInternal.IsDeleted,
                VersionId = shareItemInternal.VersionId,
                Properties = shareItemInternal.Properties.ToShareProperties()
            };
        }

        internal static ShareProperties ToShareProperties(this SharePropertiesInternal sharePropertiesInternal)
        {
            if (sharePropertiesInternal == null)
            {
                return null;
            }

            return new ShareProperties
            {
                LastModified = sharePropertiesInternal.LastModified,
                ETag = sharePropertiesInternal.ETag,
                ProvisionedIops = sharePropertiesInternal.ProvisionedIops,
                ProvisionedIngressMBps = sharePropertiesInternal.ProvisionedIngressMBps,
                ProvisionedEgressMBps = sharePropertiesInternal.ProvisionedEgressMBps,
                NextAllowedQuotaDowngradeTime = sharePropertiesInternal.NextAllowedQuotaDowngradeTime,
                DeletedOn = sharePropertiesInternal.DeletedOn,
                RemainingRetentionDays = sharePropertiesInternal.RemainingRetentionDays,
                AccessTier = sharePropertiesInternal.AccessTier,
                AccessTierChangeTime = sharePropertiesInternal.AccessTierChangeTime,
                AccessTierTransitionState = sharePropertiesInternal.AccessTierTransitionState,
                LeaseStatus = sharePropertiesInternal.LeaseStatus,
                LeaseState = sharePropertiesInternal.LeaseState,
                LeaseDuration = sharePropertiesInternal.LeaseDuration,
                Protocols = ToShareEnabledProtocols(sharePropertiesInternal.EnabledProtocols),
                RootSquash = sharePropertiesInternal.RootSquash,
                QuotaInGB = sharePropertiesInternal.QuotaInGB,
                Metadata = sharePropertiesInternal.Metadata
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
    }
}
