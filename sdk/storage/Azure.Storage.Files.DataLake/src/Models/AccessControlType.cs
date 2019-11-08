// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Specifies the type of the <see cref="PathAccessControlEntry"/>.
    /// </summary>
    public enum AccessControlType
    {
        /// <summary>
        /// Specifies the <see cref="PathAccessControlEntry"/> applies to the owner or a named user.
        /// </summary>
        User = 1,

        /// <summary>
        /// Specifies the <see cref="PathAccessControlEntry"/> applies to the owning group or a named group.
        /// </summary>
        Group = 2,

        /// <summary>
        /// Specifies the <see cref="PathAccessControlEntry"/> sets a mask that restricts access to named users and member of groups.
        /// </summary>
        Mask = 4,

        /// <summary>
        /// Specifies the <see cref="PathAccessControlEntry"/> applies to all users not found in other entries.
        /// </summary>
        Other = ~0
    }
}
