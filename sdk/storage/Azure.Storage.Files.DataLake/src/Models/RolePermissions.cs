// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Represents file permissions for a specific role.
    /// </summary>
    [Flags]
    public enum RolePermissions
    {
        /// <summary>
        /// The read permission.
        /// </summary>
        Read = 1,

        /// <summary>
        /// The write permission.
        /// </summary>
        Write = 2,

        /// <summary>
        /// The execute permission.
        /// </summary>
        Execute = 4,

        /// <summary>
        /// All permissions.
        /// </summary>
        All = ~0
    }
}
