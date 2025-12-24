// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
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
