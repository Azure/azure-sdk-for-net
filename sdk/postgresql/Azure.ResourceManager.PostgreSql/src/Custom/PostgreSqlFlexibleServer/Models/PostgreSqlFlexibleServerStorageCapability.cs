// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.PostgreSql.FlexibleServers;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Preserves legacy storage capability property names that differ from generated members.
    /// <summary> storage size in MB capability. </summary>
    public partial class PostgreSqlFlexibleServerStorageCapability : PostgreSqlBaseCapability
    {
        /// <summary> storage MB name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("name")]
        public string Name { get; }
        /// <summary> Gets the supported upgradable tier list. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("supportedUpgradableTierList")]
        public IReadOnlyList<PostgreSqlFlexibleServerStorageTierCapability> SupportedUpgradableTierList { get; }
    }
}
