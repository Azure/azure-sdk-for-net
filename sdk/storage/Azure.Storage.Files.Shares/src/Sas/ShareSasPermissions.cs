// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Storage.Sas;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="ShareSasPermissions"/> contains the list of
    /// permissions that can be set for a file's access policy.  Use
    /// <see cref="ShareSasBuilder.SetPermissions(ShareSasPermissions)"/>
    /// to set the permissions on the <see cref="ShareSasBuilder"/>.
    /// </summary>
    [Flags]
    public enum ShareSasPermissions
    {
        /// <summary>
        /// Indicates that Read is permitted.
        /// </summary>
        Read = 1,

        /// <summary>
        /// Indicates that Create is permitted.
        /// </summary>
        Create = 2,

        /// <summary>
        /// Indicates that Write is permitted.
        /// </summary>
        Write = 4,

        /// <summary>
        /// Indicates that Delete is permitted.
        /// </summary>
        Delete = 8,

        /// <summary>
        /// Indicates that List is permitted.
        /// </summary>
        List = 16,

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
        internal static string ToPermissionsString(this ShareSasPermissions permissions)
        {
            var sb = new StringBuilder();
            if ((permissions & ShareSasPermissions.Read) == ShareSasPermissions.Read)
            {
                sb.Append(Constants.Sas.Permissions.Read);
            }
            if ((permissions & ShareSasPermissions.Create) == ShareSasPermissions.Create)
            {
                sb.Append(Constants.Sas.Permissions.Create);
            }
            if ((permissions & ShareSasPermissions.Write) == ShareSasPermissions.Write)
            {
                sb.Append(Constants.Sas.Permissions.Write);
            }
            if ((permissions & ShareSasPermissions.Delete) == ShareSasPermissions.Delete)
            {
                sb.Append(Constants.Sas.Permissions.Delete);
            }
            if ((permissions & ShareSasPermissions.List) == ShareSasPermissions.List)
            {
                sb.Append(Constants.Sas.Permissions.List);
            }
            return sb.ToString();
        }
    }
}
