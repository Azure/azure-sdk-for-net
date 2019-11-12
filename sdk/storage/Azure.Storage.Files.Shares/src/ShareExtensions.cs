// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using Azure.Storage.Shared;
using Internals = Azure.Storage.Shared;

namespace Azure.Storage.Files.Shares
{
    internal static partial class ShareExtensions
    {
        internal static void AssertValidFilePermissionAndKey(string filePermission, string filePermissionKey)
        {
            if (filePermission != null && filePermissionKey != null)
            {
                throw Internals.Errors.CannotBothBeNotNull(nameof(filePermission), nameof(filePermissionKey));
            }

            if (filePermission != null && Encoding.UTF8.GetByteCount(filePermission) > Internals.Constants.File.MaxFilePermissionHeaderSize)
            {
                throw Internals.Errors.MustBeLessThanOrEqualTo(nameof(filePermission), Internals.Constants.File.MaxFilePermissionHeaderSize);
            }
        }
    }
}
