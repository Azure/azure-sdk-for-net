// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> Flexible server edition capabilities. </summary>
    public partial class PostgreSqlFlexibleServerEditionCapability : PostgreSqlBaseCapability
    {
        /// <summary> The list of server versions supported by this server edition. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("supportedServerVersions")]
        public IReadOnlyList<PostgreSqlFlexibleServerServerVersionCapability> SupportedServerVersions =>
            SupportedServerVersionsInternal;

        internal IReadOnlyList<PostgreSqlFlexibleServerServerVersionCapability> SupportedServerVersionsInternal { get; set; }
    }
}
