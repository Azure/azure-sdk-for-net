// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Storage.Sas;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="ShareAccountSasPermissions"/> contains the list of
    /// permissions that can be set for a file account's access policy.  Use
    /// <see cref="ShareSasBuilder.SetPermissions(ShareAccountSasPermissions)"/>
    /// to set the permissions on the <see cref="ShareSasBuilder"/>.
    /// </summary>
    [Flags]
    public enum ShareAccountSasPermissions
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

namespace Azure.Storage.Files.Shares
{
    /// <summary>
    /// File enum extensions.
    /// </summary>
    internal static partial class ShareExtensions
    {
        /// <summary>
        /// Create a permissions string to provide
        /// <see cref="ShareSasBuilder.Permissions"/>.
        /// </summary>
        /// <returns>A permissions string.</returns>
        internal static string ToPermissionsString(this ShareAccountSasPermissions permissions)
        {
            var sb = new StringBuilder();
            if ((permissions & ShareAccountSasPermissions.Read) == ShareAccountSasPermissions.Read)
            {
                sb.Append(Constants.Sas.Permissions.Read);
            }
            if ((permissions & ShareAccountSasPermissions.Add) == ShareAccountSasPermissions.Add)
            {
                sb.Append(Constants.Sas.Permissions.Add);
            }
            if ((permissions & ShareAccountSasPermissions.Create) == ShareAccountSasPermissions.Create)
            {
                sb.Append(Constants.Sas.Permissions.Create);
            }
            if ((permissions & ShareAccountSasPermissions.Write) == ShareAccountSasPermissions.Write)
            {
                sb.Append(Constants.Sas.Permissions.Write);
            }
            if ((permissions & ShareAccountSasPermissions.Delete) == ShareAccountSasPermissions.Delete)
            {
                sb.Append(Constants.Sas.Permissions.Delete);
            }
            if ((permissions & ShareAccountSasPermissions.List) == ShareAccountSasPermissions.List)
            {
                sb.Append(Constants.Sas.Permissions.List);
            }
            return sb.ToString();
        }
    }
}
