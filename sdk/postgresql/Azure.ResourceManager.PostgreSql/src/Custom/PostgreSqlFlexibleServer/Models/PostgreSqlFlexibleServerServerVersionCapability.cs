// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.PostgreSql.FlexibleServers;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Required by generated capability serialization and preserves legacy SupportedVCores.
    /// <summary> Server version capabilities. </summary>
    public partial class PostgreSqlFlexibleServerServerVersionCapability : PostgreSqlBaseCapability
    {
        /// <summary> Gets the supported v cores. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("supportedVcores")]
        public IReadOnlyList<PostgreSqlFlexibleServerVCoreCapability> SupportedVCores => SupportedVCoresInternal;
        internal List<PostgreSqlFlexibleServerVCoreCapability> SupportedVCoresInternal { get; set; }
    }
}
