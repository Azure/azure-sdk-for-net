// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> storage size in MB capability. </summary>
    public partial class PostgreSqlFlexibleServerStorageCapability : CapabilityBase
    {
        /// <summary> storage MB name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name { get; }
        /// <summary> The status of the capability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new string Status { get; }
    }
}
