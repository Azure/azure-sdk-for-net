// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Data.Tables.Sas;

namespace Azure.Data.Tables.Sas
{
    /// <summary>
    /// <see cref="TableSasPermissions"/> contains the list of
    /// permissions that can be set for a file's access policy.  Use
    /// <see cref="TableSasBuilder.SetPermissions(TableSasPermissions)"/>
    /// to set the permissions on the <see cref="TableSasBuilder"/>.
    /// </summary>
    [Flags]
    public enum TableSasPermissions
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
        /// Indicates that Update is permitted.
        /// </summary>
        Update = 4,

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

namespace Azure.Data.Tables
{
    /// <summary>
    /// Table enum extensions.
    /// </summary>
    internal static partial class TableExtensions
    {
        /// <summary>
        /// Create a permissions string to provide
        /// <see cref="TableSasBuilder.Permissions"/>.
        /// </summary>
        /// <returns>A permissions string.</returns>
        internal static string ToPermissionsString(this TableSasPermissions permissions)
        {
            var sb = new StringBuilder();
            if ((permissions & TableSasPermissions.Read) == TableSasPermissions.Read)
            {
                sb.Append(TableConstants.Sas.Permissions.Read);
            }
            if ((permissions & TableSasPermissions.Add) == TableSasPermissions.Add)
            {
                sb.Append(TableConstants.Sas.Permissions.Add);
            }
            if ((permissions & TableSasPermissions.Update) == TableSasPermissions.Update)
            {
                sb.Append(TableConstants.Sas.Permissions.Update);
            }
            if ((permissions & TableSasPermissions.Delete) == TableSasPermissions.Delete)
            {
                sb.Append(TableConstants.Sas.Permissions.Delete);
            }
            return sb.ToString();
        }
    }
}
