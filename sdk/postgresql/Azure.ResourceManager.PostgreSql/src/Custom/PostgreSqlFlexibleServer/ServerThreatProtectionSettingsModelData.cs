// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    // Preserves the previous flattened threat-protection State property.
    public partial class ServerThreatProtectionSettingsModelData
    {
        /// <summary> Specifies the state of the advanced threat protection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.state")]
        public ThreatProtectionState? State
        {
            get => Properties is null ? default(ThreatProtectionState?) : Properties.State;
            set
            {
                if (value.HasValue)
                {
                    if (Properties is null)
                    {
                        Properties = new AdvancedThreatProtectionSettingsProperties();
                    }
                    Properties.State = value.Value;
                }
            }
        }
    }
}
