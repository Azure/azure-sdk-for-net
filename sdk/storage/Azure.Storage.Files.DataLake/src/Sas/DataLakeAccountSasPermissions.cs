// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Storage.Sas;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="DataLakeAccountSasPermissions"/> contains the list of
    /// permissions that can be set for a data lake account's access policy.  Use
    /// <see cref="DataLakeSasBuilder.SetPermissions(DataLakeAccountSasPermissions)"/>
    /// to set the permissions on the <see cref="DataLakeSasBuilder"/>.
    /// </summary>
    [Flags]
    public enum DataLakeAccountSasPermissions
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

namespace Azure.Storage.Files.DataLake
{
    /// <summary>
    /// Data Lake enum extensions
    /// </summary>
    internal static partial class DataLakeExtensions
    {
        /// <summary>
        /// Create a permissions string to provide
        /// <see cref="DataLakeSasBuilder.Permissions"/>.
        /// </summary>
        /// <returns>A permissions string.</returns>
        internal static string ToPermissionsString(this DataLakeAccountSasPermissions permissions)
        {
            var sb = new StringBuilder();
            if ((permissions & DataLakeAccountSasPermissions.Read) == DataLakeAccountSasPermissions.Read)
            {
                sb.Append(Constants.Sas.Permissions.Read);
            }
            if ((permissions & DataLakeAccountSasPermissions.Add) == DataLakeAccountSasPermissions.Add)
            {
                sb.Append(Constants.Sas.Permissions.Add);
            }
            if ((permissions & DataLakeAccountSasPermissions.Create) == DataLakeAccountSasPermissions.Create)
            {
                sb.Append(Constants.Sas.Permissions.Create);
            }
            if ((permissions & DataLakeAccountSasPermissions.Write) == DataLakeAccountSasPermissions.Write)
            {
                sb.Append(Constants.Sas.Permissions.Write);
            }
            if ((permissions & DataLakeAccountSasPermissions.Delete) == DataLakeAccountSasPermissions.Delete)
            {
                sb.Append(Constants.Sas.Permissions.Delete);
            }
            if ((permissions & DataLakeAccountSasPermissions.List) == DataLakeAccountSasPermissions.List)
            {
                sb.Append(Constants.Sas.Permissions.List);
            }
            return sb.ToString();
        }
    }
}
