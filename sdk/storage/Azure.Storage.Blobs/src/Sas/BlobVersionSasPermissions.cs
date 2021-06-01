// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Sas;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="BlobVersionSasPermissions"/> contains the list of
    /// permissions that can be set for a blob bersion.  Use
    /// <see cref="BlobSasBuilder.SetPermissions(BlobVersionSasPermissions)"/>
    /// to set the permissions on the <see cref="BlobSasBuilder"/>.
    /// </summary>
    [Flags]
    public enum BlobVersionSasPermissions
    {
        /// <summary>
        /// Indicates that Delete is permitted.
        /// </summary>
        Delete = 1,

        /// <summary>
        /// Indicates that all permissions are set.
        /// </summary>
        All = ~0
    }
}

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Blob enum extensions.
    /// </summary>
    internal static partial class BlobExtensions
    {
        /// <summary>
        /// Create a permissions string to provide
        /// <see cref="BlobSasBuilder.Permissions"/>.
        /// </summary>
        /// <returns>A permissions string.</returns>
        internal static string ToPermissionsString(this BlobVersionSasPermissions permissions)
        {
            var sb = new StringBuilder();
            if ((permissions & BlobVersionSasPermissions.Delete) == BlobVersionSasPermissions.Delete)
            {
                sb.Append(Constants.Sas.Permissions.DeleteBlobVersion);
            }
            return sb.ToString();
        }
    }
}
