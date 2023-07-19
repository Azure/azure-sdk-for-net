// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> the types of identities associated with this resource; currently restricted to 'None and UserAssigned'. </summary>
    public readonly partial struct PostgreSqlFlexibleServerIdentityType : IEquatable<PostgreSqlFlexibleServerIdentityType>
    {
        private const string SystemAssignedValue = "SystemAssigned";

        /// <summary> SystemAssigned. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerIdentityType SystemAssigned { get; } = new PostgreSqlFlexibleServerIdentityType(SystemAssignedValue);
    }
}
