// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Storage.Sas;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="AccountSasPermissions"/> contains the list of
    /// permissions that can be set for a blob's access policy.  Use
    /// <see cref="AccountSasBuilder.SetPermissions(AccountSasPermissions)"/>
    /// to set the permissions on the <see cref="AccountSasBuilder"/>.
    /// </summary>
    [Flags]
    public enum AccountSasPermissions
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
        /// Indicates that List is permitted.
        /// </summary>
        List = 8,

        /// <summary>
        /// Indicates that Add is permitted.
        /// </summary>
        Add = 16,

        /// <summary>
        /// Indicates that Create is permitted.
        /// </summary>
        Create = 32,

        /// <summary>
        /// Indicates that Update is permitted.
        /// </summary>
        Update = 64,

        /// <summary>
        /// Indicates that Delete is permitted.
        /// </summary>
        Process = 128,

        /// <summary>
        /// Indicates that all permissions are set.
        /// </summary>
        All = ~0
    }
}

namespace Azure.Storage
{
    /// <summary>
    /// Blob enum extensions.
    /// </summary>
    internal static partial class AccountExtensions
    {
        /// <summary>
        /// Create a permissions string to provide
        /// <see cref="AccountSasBuilder.Permissions"/>.
        /// </summary>
        /// <returns>A permissions string.</returns>
        internal static string ToPermissionsString(this AccountSasPermissions permissions)
        {
            var sb = new StringBuilder();
            if ((permissions & AccountSasPermissions.Read) == AccountSasPermissions.Read)
            {
                sb.Append(Constants.Sas.Permissions.Read);
            }
            if ((permissions & AccountSasPermissions.Write) == AccountSasPermissions.Write)
            {
                sb.Append(Constants.Sas.Permissions.Write);
            }
            if ((permissions & AccountSasPermissions.Delete) == AccountSasPermissions.Delete)
            {
                sb.Append(Constants.Sas.Permissions.Delete);
            }
            if ((permissions & AccountSasPermissions.List) == AccountSasPermissions.List)
            {
                sb.Append(Constants.Sas.Permissions.List);
            }
            if ((permissions & AccountSasPermissions.Add) == AccountSasPermissions.Add)
            {
                sb.Append(Constants.Sas.Permissions.Add);
            }
            if ((permissions & AccountSasPermissions.Create) == AccountSasPermissions.Create)
            {
                sb.Append(Constants.Sas.Permissions.Create);
            }
            if ((permissions & AccountSasPermissions.Update) == AccountSasPermissions.Update)
            {
                sb.Append(Constants.Sas.Permissions.Update);
            }
            if ((permissions & AccountSasPermissions.Process) == AccountSasPermissions.Process)
            {
                sb.Append(Constants.Sas.Permissions.Process);
            }
            return sb.ToString();
        }
    }
}
