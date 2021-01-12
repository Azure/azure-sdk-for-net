// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Storage.Sas;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="ShareFileSasPermissions"/> contains the list of
    /// permissions that can be set for a file's access policy.  Use
    /// <see cref="ShareSasBuilder.SetPermissions(ShareFileSasPermissions)"/>
    /// to set the permissions on the <see cref="ShareSasBuilder"/>.
    /// </summary>
    [Flags]
    public enum ShareFileSasPermissions
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
        internal static string ToPermissionsString(this ShareFileSasPermissions permissions)
        {
            var sb = new StringBuilder();
            if ((permissions & ShareFileSasPermissions.Read) == ShareFileSasPermissions.Read)
            {
                sb.Append(Constants.Sas.Permissions.Read);
            }
            if ((permissions & ShareFileSasPermissions.Create) == ShareFileSasPermissions.Create)
            {
                sb.Append(Constants.Sas.Permissions.Create);
            }
            if ((permissions & ShareFileSasPermissions.Write) == ShareFileSasPermissions.Write)
            {
                sb.Append(Constants.Sas.Permissions.Write);
            }
            if ((permissions & ShareFileSasPermissions.Delete) == ShareFileSasPermissions.Delete)
            {
                sb.Append(Constants.Sas.Permissions.Delete);
            }
            return sb.ToString();
        }
    }
}
