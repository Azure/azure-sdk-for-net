// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
                    LeaseId = response.Value.LeaseId
                }, response.GetRawResponse());

        internal static string ToFileDateTimeString(this DateTimeOffset? dateTimeOffset)
            => dateTimeOffset.HasValue ? ToFileDateTimeString(dateTimeOffset.Value) : null;

        private static string ToFileDateTimeString(this DateTimeOffset dateTimeOffset)
            => dateTimeOffset.UtcDateTime.ToString(Constants.File.FileTimeFormat, CultureInfo.InvariantCulture);
    }
}
