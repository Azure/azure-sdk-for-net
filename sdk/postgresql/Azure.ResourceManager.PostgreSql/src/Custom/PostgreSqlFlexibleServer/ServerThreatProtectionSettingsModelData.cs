// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    [CodeGenSuppress("State")]
    public partial class ServerThreatProtectionSettingsModelData
    {
        /// <summary> Specifies the state of the advanced threat protection, whether it is enabled, disabled, or a state has not been applied yet on the server. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.state")]
        public ThreatProtectionState? State
        {
            get => Properties is null ? default(ThreatProtectionState?) : Properties.State;
            set
            {
                if (Properties is null)
                    Properties = new AdvancedThreatProtectionSettingsProperties();
                if (value.HasValue)
                    Properties.State = value.Value;
            }
        }
    }
}
