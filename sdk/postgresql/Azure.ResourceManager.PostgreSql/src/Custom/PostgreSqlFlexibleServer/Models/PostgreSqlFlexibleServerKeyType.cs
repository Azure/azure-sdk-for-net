// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> Data encryption type to depict if it is System Managed vs Azure Key vault. </summary>
    public readonly partial struct PostgreSqlFlexibleServerKeyType : IEquatable<PostgreSqlFlexibleServerKeyType>
    {
        private const string SystemAssignedValue = "SystemAssigned";

        /// <summary> SystemAssigned. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerKeyType SystemAssigned { get; } = new PostgreSqlFlexibleServerKeyType(SystemAssignedValue);
    }
}
