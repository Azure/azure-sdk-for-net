// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Storage.Sas;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="SnapshotSasPermissions"/> contains the list of
    /// permissions that can be set for a blob's access policy.  Use
    /// <see cref="BlobSasBuilder.SetPermissions(SnapshotSasPermissions)"/>
    /// to set the permissions on the <see cref="BlobSasBuilder"/>.
    /// </summary>
    [Flags]
    public enum SnapshotSasPermissions
    {
        /// <summary>
        /// Indicates that Read is permitted.
        /// </summary>
        Read = 1,

        /// <summary>
        /// Indicates that Write is permitted.
        /// </summary>
        Write = 2,

        /// <summary>
        /// Indicates that Delete is permitted.
        /// </summary>
        Delete = 4,

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
        internal static string ToPermissionsString(this SnapshotSasPermissions permissions)
        {
            var sb = new StringBuilder();
            if ((permissions & SnapshotSasPermissions.Read) == SnapshotSasPermissions.Read)
            {
                sb.Append(Constants.Sas.Permissions.Read);
            }
            if ((permissions & SnapshotSasPermissions.Write) == SnapshotSasPermissions.Write)
            {
                sb.Append(Constants.Sas.Permissions.Write);
            }
            if ((permissions & SnapshotSasPermissions.Delete) == SnapshotSasPermissions.Delete)
            {
                sb.Append(Constants.Sas.Permissions.Delete);
            }
            return sb.ToString();
        }
    }
}
