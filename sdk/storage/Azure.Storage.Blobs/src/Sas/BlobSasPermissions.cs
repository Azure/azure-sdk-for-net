// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Storage.Sas;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="BlobSasPermissions"/> contains the list of
    /// permissions that can be set for a blob's access policy.  Use
    /// <see cref="BlobSasBuilder.SetPermissions(BlobSasPermissions)"/>
    /// to set the permissions on the <see cref="BlobSasBuilder"/>.
    /// </summary>
    [Flags]
    public enum BlobSasPermissions
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
        /// Indicates that reading and writing Tags are permitted.
        /// </summary>
        Tag = 32,

        /// <summary>
        /// Indicates that deleting a Blob Version is permitted.
        /// </summary>
        DeleteBlobVersion = 64,

        /// <summary>
        /// Indicates that List is permitted.
        /// </summary>
        List = 128,

        /// <summary>
        /// Indicates that Move is permitted.
        /// </summary>
        Move = 256,

        /// <summary>
        /// Indicates that Execute is permitted.
        /// </summary>
        Execute = 512,

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
        internal static string ToPermissionsString(this BlobSasPermissions permissions)
        {
            var sb = new StringBuilder();
            if ((permissions & BlobSasPermissions.Read) == BlobSasPermissions.Read)
            {
                sb.Append(Constants.Sas.Permissions.Read);
            }
            if ((permissions & BlobSasPermissions.Add) == BlobSasPermissions.Add)
            {
                sb.Append(Constants.Sas.Permissions.Add);
            }
            if ((permissions & BlobSasPermissions.Create) == BlobSasPermissions.Create)
            {
                sb.Append(Constants.Sas.Permissions.Create);
            }
            if ((permissions & BlobSasPermissions.Write) == BlobSasPermissions.Write)
            {
                sb.Append(Constants.Sas.Permissions.Write);
            }
            if ((permissions & BlobSasPermissions.Delete) == BlobSasPermissions.Delete)
            {
                sb.Append(Constants.Sas.Permissions.Delete);
            }
            if ((permissions & BlobSasPermissions.DeleteBlobVersion) == BlobSasPermissions.DeleteBlobVersion)
            {
                sb.Append(Constants.Sas.Permissions.DeleteBlobVersion);
            }
            if ((permissions & BlobSasPermissions.List) == BlobSasPermissions.List)
            {
                sb.Append(Constants.Sas.Permissions.List);
            }
            if ((permissions & BlobSasPermissions.Tag) == BlobSasPermissions.Tag)
            {
                sb.Append(Constants.Sas.Permissions.Tag);
            }
            if ((permissions & BlobSasPermissions.Move) == BlobSasPermissions.Move)
            {
                sb.Append(Constants.Sas.Permissions.Move);
            }
            if ((permissions & BlobSasPermissions.Execute) == BlobSasPermissions.Execute)
            {
                sb.Append(Constants.Sas.Permissions.Execute);
            }
            return sb.ToString();
        }
    }
}
