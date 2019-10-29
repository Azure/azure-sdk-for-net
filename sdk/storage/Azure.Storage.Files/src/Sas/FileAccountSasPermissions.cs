// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Storage.Sas;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="FileAccountSasPermissions"/> contains the list of
    /// permissions that can be set for a file account's access policy.  Use
    /// <see cref="FileSasBuilder.SetPermissions(FileAccountSasPermissions)"/>
    /// to set the permissions on the <see cref="FileSasBuilder"/>.
    /// </summary>
    [Flags]
    public enum FileAccountSasPermissions
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
        internal static string ToPermissionsString(this FileAccountSasPermissions permissions)
        {
            var sb = new StringBuilder();
            if ((permissions & FileAccountSasPermissions.Read) == FileAccountSasPermissions.Read)
            {
                sb.Append(Constants.Sas.Permissions.Read);
            }
            if ((permissions & FileAccountSasPermissions.Add) == FileAccountSasPermissions.Add)
            {
                sb.Append(Constants.Sas.Permissions.Add);
            }
            if ((permissions & FileAccountSasPermissions.Create) == FileAccountSasPermissions.Create)
            {
                sb.Append(Constants.Sas.Permissions.Create);
            }
            if ((permissions & FileAccountSasPermissions.Write) == FileAccountSasPermissions.Write)
            {
                sb.Append(Constants.Sas.Permissions.Write);
            }
            if ((permissions & FileAccountSasPermissions.Delete) == FileAccountSasPermissions.Delete)
            {
                sb.Append(Constants.Sas.Permissions.Delete);
            }
            if ((permissions & FileAccountSasPermissions.List) == FileAccountSasPermissions.List)
            {
                sb.Append(Constants.Sas.Permissions.List);
            }
            return sb.ToString();
        }
    }
}
