// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Text;
using Azure.Storage.Files.DataLake.Sas;

namespace Azure.Storage.Files.DataLake.Sas
{
    /// <summary>
    /// <see cref="DataLakeSasPermissions"/> contains the list of
    /// permissions that can be set for a blob's access policy.  Use
    /// <see cref="DataLakeSasBuilder.SetPermissions(DataLakeSasPermissions)"/>
    /// to set the permissions on the <see cref="DataLakeSasBuilder"/>.
    /// </summary>
    [Flags]
    public enum DataLakeSasPermissions
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
        internal static string ToPermissionsString(this DataLakeSasPermissions permissions)
        {
            var sb = new StringBuilder();
            if ((permissions & DataLakeSasPermissions.Read) == DataLakeSasPermissions.Read)
            {
                sb.Append(Constants.Sas.Permissions.Read);
            }
            if ((permissions & DataLakeSasPermissions.Add) == DataLakeSasPermissions.Add)
            {
                sb.Append(Constants.Sas.Permissions.Add);
            }
            if ((permissions & DataLakeSasPermissions.Create) == DataLakeSasPermissions.Create)
            {
                sb.Append(Constants.Sas.Permissions.Create);
            }
            if ((permissions & DataLakeSasPermissions.Write) == DataLakeSasPermissions.Write)
            {
                sb.Append(Constants.Sas.Permissions.Write);
            }
            if ((permissions & DataLakeSasPermissions.Delete) == DataLakeSasPermissions.Delete)
            {
                sb.Append(Constants.Sas.Permissions.Delete);
            }
            return sb.ToString();
        }
    }
}
