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
        public IReadOnlyList<PostgreSqlFlexibleServerVCoreCapability> SupportedVCores { get; }
    }
}
