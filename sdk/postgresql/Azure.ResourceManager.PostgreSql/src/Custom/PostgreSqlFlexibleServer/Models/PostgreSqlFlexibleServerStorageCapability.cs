// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> storage size in MB capability. </summary>
    public partial class PostgreSqlFlexibleServerStorageCapability : PostgreSqlBaseCapability
    {
        /// <summary> storage MB name. </summary>
        [WirePath("name")]
        public string Name { get; }
        /// <summary> Gets the supported upgradable tier list. </summary>
        [WirePath("supportedUpgradableTierList")]
        public IReadOnlyList<PostgreSqlFlexibleServerStorageTierCapability> SupportedUpgradableTierList { get; }
    }
}
