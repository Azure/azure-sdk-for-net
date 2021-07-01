// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Storage.Sas;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="BlobAccountSasPermissions"/> contains the list of
    /// permissions that can be set for a blob account's access policy.  Use
    /// <see cref="BlobSasBuilder.SetPermissions(BlobAccountSasPermissions)"/>
    /// to set the permissions on the <see cref="BlobSasBuilder"/>.
    /// </summary>
    [Flags]
    public enum BlobAccountSasPermissions
    {
        /// <summary>
        /// Indicates that Read is permitted.
        /// </summary>
        Read = 1,

        /// <summary>
        /// Indicates that Add is permitted.
        /// </summary>
        Add = 2,

        /// <summary>
        /// Indicates that Create is permitted.
        /// </summary>
        Create = 4,

        /// <summary>
        /// Indicates that Write is permitted.
        /// </summary>
        Write = 8,

        /// <summary>
        /// Indicates that Delete is permitted.
        /// </summary>
        Delete = 16,

        /// <summary>
        /// Indicates that List is permitted.
        /// </summary>
        List = 32,

        /// <summary>
        /// Indicates that all permissions are set.
        /// </summary>
        All = ~0
    }
}

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Blob enum extensions
    /// </summary>
    internal static partial class BlobExtensions
    {
        /// <summary>
        /// Create a permissions string to provide
        /// <see cref="BlobSasBuilder.Permissions"/>.
        /// </summary>
        /// <returns>A permissions string.</returns>
        internal static string ToPermissionsString(this BlobAccountSasPermissions permissions)
        {
            var sb = new StringBuilder();
            if ((permissions & BlobAccountSasPermissions.Read) == BlobAccountSasPermissions.Read)
            {
                sb.Append(Constants.Sas.Permissions.Read);
            }
            if ((permissions & BlobAccountSasPermissions.Add) == BlobAccountSasPermissions.Add)
            {
                sb.Append(Constants.Sas.Permissions.Add);
            }
            if ((permissions & BlobAccountSasPermissions.Create) == BlobAccountSasPermissions.Create)
            {
                sb.Append(Constants.Sas.Permissions.Create);
            }
            if ((permissions & BlobAccountSasPermissions.Write) == BlobAccountSasPermissions.Write)
            {
                sb.Append(Constants.Sas.Permissions.Write);
            }
            if ((permissions & BlobAccountSasPermissions.Delete) == BlobAccountSasPermissions.Delete)
            {
                sb.Append(Constants.Sas.Permissions.Delete);
            }
            if ((permissions & BlobAccountSasPermissions.List) == BlobAccountSasPermissions.List)
            {
                sb.Append(Constants.Sas.Permissions.List);
            }
            return sb.ToString();
        }
    }
}
