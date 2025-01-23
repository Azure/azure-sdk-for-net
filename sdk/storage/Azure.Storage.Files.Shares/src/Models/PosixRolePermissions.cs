// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Represents file permissions for a specific role.
    /// </summary>
    [Flags]
    public enum PosixRolePermissions
    {
        /// <summary>
        /// No permissions.
        /// </summary>
        None = 0,

        /// <summary>
        /// The execute permission.
        /// </summary>
        Execute = 1,

        /// <summary>
        /// The write permission.
        /// </summary>
        Write = 2,

        /// <summary>
        /// The read permission.
        /// </summary>
        Read = 4,
    }
}
