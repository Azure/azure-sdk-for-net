﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> storage size in MB capability. </summary>
    public partial class PostgreSqlFlexibleServerStorageCapability : PostgreSqlBaseCapability
    {
        /// <summary> storage MB name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name { get; }
        /// <summary> Gets the supported upgradable tier list. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<PostgreSqlFlexibleServerStorageTierCapability> SupportedUpgradableTierList { get; }

        /// <summary> Supported IOPS. </summary>
        public long? SupportedIops { get; }
    }
}
