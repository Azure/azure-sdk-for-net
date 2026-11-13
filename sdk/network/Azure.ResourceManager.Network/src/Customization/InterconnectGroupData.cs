// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    public partial class InterconnectGroupData
    {
        // Retain nested wire storage while exposing the consolidated spec's flattened members.
        [CodeGenMember("Properties")]
        internal InterconnectGroupPropertiesFormat Properties { get; set; }

        /// <summary> Scope of interconnect group resource. </summary>
        [WirePath("properties.scope")]
        public InterconnectGroupScope? Scope
        {
            get => Properties?.Scope;
            set
            {
                Properties ??= new InterconnectGroupPropertiesFormat(default, new ChangeTrackingList<InterconnectGroupSubgroupData>(), default, default, default, default);
                Properties.Scope = value;
            }
        }

        /// <summary> A list of subgroups of the interconnect group. </summary>
        [WirePath("properties.subgroups")]
        public IReadOnlyList<InterconnectGroupSubgroupData> Subgroups
        {
            get
            {
                Properties ??= new InterconnectGroupPropertiesFormat(default, new ChangeTrackingList<InterconnectGroupSubgroupData>(), default, default, default, default);
                return Properties.Subgroups;
            }
        }

        /// <summary> The provisioning state of the interconnect group resource. </summary>
        [WirePath("properties.provisioningState")]
        public NetworkProvisioningState? ProvisioningState => Properties?.ProvisioningState;

        /// <summary> The resource GUID property of the interconnect group resource. </summary>
        [WirePath("properties.resourceGuid")]
        public string ResourceGuid => Properties?.ResourceGuid;

        /// <summary> The subgroup profile of the interconnect group resource. </summary>
        [WirePath("properties.subgroupProfile")]
        public SubgroupProfile SubgroupProfile
        {
            get => Properties?.SubgroupProfile;
            set
            {
                Properties ??= new InterconnectGroupPropertiesFormat(default, new ChangeTrackingList<InterconnectGroupSubgroupData>(), default, default, default, default);
                Properties.SubgroupProfile = value;
            }
        }
    }
}
