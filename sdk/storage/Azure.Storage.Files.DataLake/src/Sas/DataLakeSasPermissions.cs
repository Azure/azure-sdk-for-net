// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Text;
using Azure.Storage.Sas;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="DataLakeSasPermissions"/> contains the list of
    /// permissions that can be set for a path's access policy.  Use
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
        /// Indicates that List is permitted.
        /// </summary>
        List = 32,

        /// <summary>
        /// Indicates that Move is permitted.
        /// </summary>
        Move = 64,

        /// <summary>
        /// Indicates that Execute is permitted.
        /// </summary>
        Execute = 128,

        /// <summary>
        /// Indicates that Ownership is permitted.
        /// </summary>
        ManageOwnership = 256,

        /// <summary>
        /// Indicates that Permissions is permitted.
        /// </summary>
        ManageAccessControl = 512,

        // https://github.com/Azure/azure-sdk-for-net/issues/52168
        ///// <summary>
        ///// Indicates that reading and writing Tags are permitted.
        ///// </summary>
        //Tag = 1024,

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
            if ((permissions & DataLakeSasPermissions.List) == DataLakeSasPermissions.List)
            {
                sb.Append(Constants.Sas.Permissions.List);
            }
            // https://github.com/Azure/azure-sdk-for-net/issues/52168
            //if ((permissions & DataLakeSasPermissions.Tag) == DataLakeSasPermissions.Tag)
            //{
            //    sb.Append(Constants.Sas.Permissions.Tag);
            //}
            if ((permissions & DataLakeSasPermissions.Move) == DataLakeSasPermissions.Move)
            {
                sb.Append(Constants.Sas.Permissions.Move);
            }
            if ((permissions & DataLakeSasPermissions.Execute) == DataLakeSasPermissions.Execute)
            {
                sb.Append(Constants.Sas.Permissions.Execute);
            }
            if ((permissions & DataLakeSasPermissions.ManageOwnership) == DataLakeSasPermissions.ManageOwnership)
            {
                sb.Append(Constants.Sas.Permissions.ManageOwnership);
            }
            if ((permissions & DataLakeSasPermissions.ManageAccessControl) == DataLakeSasPermissions.ManageAccessControl)
            {
                sb.Append(Constants.Sas.Permissions.ManageAccessControl);
            }
            return sb.ToString();
        }
    }
}
