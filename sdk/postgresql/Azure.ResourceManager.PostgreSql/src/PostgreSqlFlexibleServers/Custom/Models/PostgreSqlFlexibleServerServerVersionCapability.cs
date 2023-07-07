// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> Server version capabilities. </summary>
    public partial class PostgreSqlFlexibleServerServerVersionCapability : CapabilityBase
    {
        /// <summary> The status of the capability. </summary>
        public new string Status { get; }
    }
}
