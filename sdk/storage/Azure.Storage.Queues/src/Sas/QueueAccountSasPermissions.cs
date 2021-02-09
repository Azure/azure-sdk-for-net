// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Storage.Sas;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="QueueAccountSasPermissions"/> contains the list of
    /// permissions that can be set for a file's access policy.  Use
    /// <see cref="QueueSasBuilder.SetPermissions(QueueAccountSasPermissions)"/>
    /// to set the permissions on the <see cref="QueueSasBuilder"/>.
    /// </summary>
    [Flags]
    public enum QueueAccountSasPermissions
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
        Update = 32,

        /// <summary>
        /// Indicates that Delete is permitted.
        /// </summary>
        Process = 64,

        /// <summary>
        /// Indicates that all permissions are set.
        /// </summary>
        All = ~0
    }
}

namespace Azure.Storage.Queues
{
    /// <summary>
    /// Queue enum extensions.
    /// </summary>
    internal static partial class QueueExtensions
    {
        /// <summary>
        /// Create a permissions string to provide
        /// <see cref="QueueSasBuilder.Permissions"/>.
        /// </summary>
        /// <returns>A permissions string.</returns>
        internal static string ToPermissionsString(this QueueAccountSasPermissions permissions)
        {
            var sb = new StringBuilder();
            if ((permissions & QueueAccountSasPermissions.Read) == QueueAccountSasPermissions.Read)
            {
                sb.Append(Constants.Sas.Permissions.Read);
            }
            if ((permissions & QueueAccountSasPermissions.Write) == QueueAccountSasPermissions.Write)
            {
                sb.Append(Constants.Sas.Permissions.Write);
            }
            if ((permissions & QueueAccountSasPermissions.Delete) == QueueAccountSasPermissions.Delete)
            {
                sb.Append(Constants.Sas.Permissions.Delete);
            }
            if ((permissions & QueueAccountSasPermissions.List) == QueueAccountSasPermissions.List)
            {
                sb.Append(Constants.Sas.Permissions.List);
            }
            if ((permissions & QueueAccountSasPermissions.Add) == QueueAccountSasPermissions.Add)
            {
                sb.Append(Constants.Sas.Permissions.Add);
            }
            if ((permissions & QueueAccountSasPermissions.Update) == QueueAccountSasPermissions.Update)
            {
                sb.Append(Constants.Sas.Permissions.Update);
            }
            if ((permissions & QueueAccountSasPermissions.Process) == QueueAccountSasPermissions.Process)
            {
                sb.Append(Constants.Sas.Permissions.Process);
            }
            return sb.ToString();
        }
    }
}
