// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Storage.Sas;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// <see cref="QueueSasPermissions"/> contains the list of
    /// permissions that can be set for a file's access policy.  Use
    /// <see cref="QueueSasBuilder.SetPermissions(QueueSasPermissions)"/>
    /// to set the permissions on the <see cref="QueueSasBuilder"/>.
    /// </summary>
    [Flags]
    public enum QueueSasPermissions
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
        Process = 8,

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
        internal static string ToPermissionsString(this QueueSasPermissions permissions)
        {
            var sb = new StringBuilder();
            if ((permissions & QueueSasPermissions.Read) == QueueSasPermissions.Read)
            {
                sb.Append(Constants.Sas.Permissions.Read);
            }
            if ((permissions & QueueSasPermissions.Add) == QueueSasPermissions.Add)
            {
                sb.Append(Constants.Sas.Permissions.Add);
            }
            if ((permissions & QueueSasPermissions.Update) == QueueSasPermissions.Update)
            {
                sb.Append(Constants.Sas.Permissions.Update);
            }
            if ((permissions & QueueSasPermissions.Process) == QueueSasPermissions.Process)
            {
                sb.Append(Constants.Sas.Permissions.Process);
            }
            return sb.ToString();
        }
    }
}
