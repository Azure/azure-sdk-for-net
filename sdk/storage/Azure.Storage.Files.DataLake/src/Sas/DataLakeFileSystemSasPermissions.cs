// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Text;
using Azure.Storage;
using Azure.Storage.Sas;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="DataLakeFileSystemSasPermissions"/> contains the list of
    /// permissions that can be set for a file systems's access policy.  Use
    /// <see cref="DataLakeSasBuilder.SetPermissions(DataLakeSasPermissions)"/>
    /// to set the permissions on the <see cref="DataLakeSasBuilder"/>.
    /// </summary>
    [Flags]
    public enum DataLakeFileSystemSasPermissions
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
    /// Data Lake enum extensions.
    /// </summary>
    internal static partial class DataLakeExtensions
    {
        /// <summary>
        /// Create a permissions string to provide
        /// <see cref="DataLakeSasBuilder.Permissions"/>.
        /// </summary>
        /// <returns>A permissions string.</returns>
        internal static string ToPermissionsString(this DataLakeFileSystemSasPermissions permissions)
        {
            var sb = new StringBuilder();
            if ((permissions & DataLakeFileSystemSasPermissions.Read) == DataLakeFileSystemSasPermissions.Read)
            {
                sb.Append(Constants.Sas.Permissions.Read);
            }
            if ((permissions & DataLakeFileSystemSasPermissions.Add) == DataLakeFileSystemSasPermissions.Add)
            {
                sb.Append(Constants.Sas.Permissions.Add);
            }
            if ((permissions & DataLakeFileSystemSasPermissions.Create) == DataLakeFileSystemSasPermissions.Create)
            {
                sb.Append(Constants.Sas.Permissions.Create);
            }
            if ((permissions & DataLakeFileSystemSasPermissions.Write) == DataLakeFileSystemSasPermissions.Write)
            {
                sb.Append(Constants.Sas.Permissions.Write);
            }
            if ((permissions & DataLakeFileSystemSasPermissions.Delete) == DataLakeFileSystemSasPermissions.Delete)
            {
                sb.Append(Constants.Sas.Permissions.Delete);
            }
            if ((permissions & DataLakeFileSystemSasPermissions.List) == DataLakeFileSystemSasPermissions.List)
            {
                sb.Append(Constants.Sas.Permissions.List);
            }
            // https://github.com/Azure/azure-sdk-for-net/issues/52168
            //if ((permissions & DataLakeFileSystemSasPermissions.Tag) == DataLakeFileSystemSasPermissions.Tag)
            //{
            //    sb.Append(Constants.Sas.Permissions.Tag);
            //}
            if ((permissions & DataLakeFileSystemSasPermissions.Move) == DataLakeFileSystemSasPermissions.Move)
            {
                sb.Append(Constants.Sas.Permissions.Move);
            }
            if ((permissions & DataLakeFileSystemSasPermissions.Execute) == DataLakeFileSystemSasPermissions.Execute)
            {
                sb.Append(Constants.Sas.Permissions.Execute);
            }
            if ((permissions & DataLakeFileSystemSasPermissions.ManageOwnership) == DataLakeFileSystemSasPermissions.ManageOwnership)
            {
                sb.Append(Constants.Sas.Permissions.ManageOwnership);
            }
            if ((permissions & DataLakeFileSystemSasPermissions.ManageAccessControl) == DataLakeFileSystemSasPermissions.ManageAccessControl)
            {
                sb.Append(Constants.Sas.Permissions.ManageAccessControl);
            }
            return sb.ToString();
        }
    }
}
