// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;

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
    }
}
