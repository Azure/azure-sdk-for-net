// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Text;

namespace Azure.Storage.Files
{
    internal class ClientHelper
    {
        internal static void AssertValidFilePermissionAndKey(string filePermission, string filePermissionKey)
        {
            if (filePermission != null && filePermissionKey != null)
            {
                throw Errors.CannotBothBeNotNull(nameof(filePermission), nameof(filePermissionKey));
            }

            if (filePermission != null && Encoding.UTF8.GetByteCount(filePermission) > 8 * Constants.KB)
            {
                throw Errors.MustBeLessThanOrEqualTo(nameof(filePermission), 8 * Constants.KB);
            }
        }
    }
}
