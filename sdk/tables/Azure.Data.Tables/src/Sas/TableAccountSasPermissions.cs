// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Data.Tables.Sas;

namespace Azure.Data.Tables.Sas
{
    /// <summary>
    /// <see cref="TableAccountSasPermissions"/> contains the list of
    /// permissions that can be set for a file's access policy.  Use
    /// <see cref="TableAccountSasBuilder.SetPermissions(TableAccountSasPermissions)"/>
    /// to set the permissions on the <see cref="TableAccountSasBuilder"/>.
    /// </summary>
    [Flags]
    public enum TableAccountSasPermissions
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
        /// Indicates that Update is permitted.
        /// </summary>
        Update = 64,

        /// <summary>
        /// Indicates that all permissions are set.
        /// </summary>
        All = ~0
    }
}

namespace Azure.Data.Tables
{
    /// <summary>
    /// Table enum extensions.
    /// </summary>
    internal static partial class TableExtensions
    {
        /// <summary>
        /// Create a permissions string to provide
        /// <see cref="TableAccountSasBuilder.Permissions"/>.
        /// </summary>
        /// <returns>A permissions string.</returns>
        internal static string ToPermissionsString(this TableAccountSasPermissions permissions)
        {
            var sb = new StringBuilder();
            if ((permissions & TableAccountSasPermissions.Read) == TableAccountSasPermissions.Read)
            {
                sb.Append(TableConstants.Sas.Permissions.Read);
            }
            if ((permissions & TableAccountSasPermissions.Write) == TableAccountSasPermissions.Write)
            {
                sb.Append(TableConstants.Sas.Permissions.Write);
            }
            if ((permissions & TableAccountSasPermissions.Delete) == TableAccountSasPermissions.Delete)
            {
                sb.Append(TableConstants.Sas.Permissions.Delete);
            }
            if ((permissions & TableAccountSasPermissions.List) == TableAccountSasPermissions.List)
            {
                sb.Append(TableConstants.Sas.Permissions.List);
            }
            if ((permissions & TableAccountSasPermissions.Add) == TableAccountSasPermissions.Add)
            {
                sb.Append(TableConstants.Sas.Permissions.Add);
            }
            if ((permissions & TableAccountSasPermissions.Update) == TableAccountSasPermissions.Update)
            {
                sb.Append(TableConstants.Sas.Permissions.Update);
            }
            return sb.ToString();
        }
    }
}
