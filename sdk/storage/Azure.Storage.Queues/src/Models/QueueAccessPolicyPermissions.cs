// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// <see cref="QueueAccessPolicyPermissions"/> contains the list of
    /// permissions that can be set for a queue's access policy.
    /// </summary>
    [Flags]
    public enum QueueAccessPolicyPermissions
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
        All = ~0,

        /// <summary>
        /// Indicates that none of the permissions are set.
        /// </summary>
        None = 0
    }
}

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// Queue enum extensions.
    /// </summary>
    internal static partial class QueueExtensions
    {
        /// <returns>A permissions string.</returns>
        internal static string ToPermissionsString(this QueueAccessPolicyPermissions? permissionsEnum)
        {
            if (permissionsEnum == null) return null;

            var sb = new StringBuilder();
            if ((permissionsEnum & QueueAccessPolicyPermissions.Read) == QueueAccessPolicyPermissions.Read)
            {
                sb.Append(Constants.Queue.Permissions.Read);
            }
            if ((permissionsEnum & QueueAccessPolicyPermissions.Add) == QueueAccessPolicyPermissions.Add)
            {
                sb.Append(Constants.Queue.Permissions.Add);
            }
            if ((permissionsEnum & QueueAccessPolicyPermissions.Update) == QueueAccessPolicyPermissions.Update)
            {
                sb.Append(Constants.Queue.Permissions.Update);
            }
            if ((permissionsEnum & QueueAccessPolicyPermissions.Process) == QueueAccessPolicyPermissions.Process)
            {
                sb.Append(Constants.Queue.Permissions.Process);
            }
            return sb.ToString();
        }

        /// <returns>A permissions enum.</returns>
        internal static QueueAccessPolicyPermissions? ToPermissionsEnum(this string permissionsString)
        {
            if (permissionsString == null) return null;

            QueueAccessPolicyPermissions permissionsEnum = QueueAccessPolicyPermissions.None;
            foreach (char permission in permissionsString)
            {
                if (permission.Equals(Constants.Queue.Permissions.Read))
                {
                    permissionsEnum |= QueueAccessPolicyPermissions.Read;
                }
                else if (permission.Equals(Constants.Queue.Permissions.Add))
                {
                    permissionsEnum |= QueueAccessPolicyPermissions.Add;
                }
                else if (permission.Equals(Constants.Queue.Permissions.Update))
                {
                    permissionsEnum |= QueueAccessPolicyPermissions.Update;
                }
                else if (permission.Equals(Constants.Queue.Permissions.Process))
                {
                    permissionsEnum |= QueueAccessPolicyPermissions.Process;
                }
            }
            return permissionsEnum;
        }
    }
}
