// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Storage.Sas;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="FileSasPermissions"/> contains the list of
    /// permissions that can be set for a file's access policy.  Use
    /// <see cref="FileSasBuilder.SetPermissions(FileSasPermissions)"/>
    /// to set the permissions on the <see cref="FileSasBuilder"/>.
    /// </summary>
    [Flags]
    public enum FileSasPermissions
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

namespace Azure.Storage.Files
{
    /// <summary>
    /// File enum extensions.
    /// </summary>
    internal static partial class FileExtensions
    {

        /// <summary>
        /// Create a permissions string to provide
        /// <see cref="FileSasBuilder.Permissions"/>.
        /// </summary>
        /// <returns>A permissions string.</returns>
        internal static string ToPermissionsString(this FileSasPermissions permissions)
        {
            var sb = new StringBuilder();
            if ((permissions & FileSasPermissions.Read) == FileSasPermissions.Read)
            {
                sb.Append(Constants.Sas.Permissions.Read);
            }
            if ((permissions & FileSasPermissions.Create) == FileSasPermissions.Create)
            {
                sb.Append(Constants.Sas.Permissions.Create);
            }
            if ((permissions & FileSasPermissions.Write) == FileSasPermissions.Write)
            {
                sb.Append(Constants.Sas.Permissions.Write);
            }
            if ((permissions & FileSasPermissions.Delete) == FileSasPermissions.Delete)
            {
                sb.Append(Constants.Sas.Permissions.Delete);
            }
            return sb.ToString();
        }
    }
}
