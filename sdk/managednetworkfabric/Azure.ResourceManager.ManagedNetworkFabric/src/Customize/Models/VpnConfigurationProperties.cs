// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    [CodeGenType("VpnConfigurationProperties")]
    public partial class VpnConfigurationProperties
    {
        /// <summary> Initializes a new instance of <see cref="VpnConfigurationProperties"/>. </summary>
        /// <param name="peeringOption"> Peering option list. </param>
        public VpnConfigurationProperties(PeeringOption peeringOption)
        {
            PeeringOption = peeringOption;
        }

        internal VpnConfigurationProperties(ResourceIdentifier networkToNetworkInterconnectId, NetworkFabricAdministrativeState? administrativeState, PeeringOption peeringOption, OptionBProperties optionBProperties, VpnConfigurationOptionAProperties optionAProperties)
        {
            NetworkToNetworkInterconnectId = networkToNetworkInterconnectId;
            AdministrativeState = administrativeState;
            PeeringOption = peeringOption;
            OptionBProperties = optionBProperties;
            OptionAProperties = optionAProperties;
        }

        /// <summary> ARM resource ID of the Network to Network Interconnect resource. </summary>
        public ResourceIdentifier NetworkToNetworkInterconnectId { get; set; }
        /// <summary> Administrative state of the resource. </summary>
        public NetworkFabricAdministrativeState? AdministrativeState { get; internal set; }
        /// <summary> Peering option list. </summary>
        public PeeringOption PeeringOption { get; set; }
        /// <summary> Option B properties. </summary>
        public OptionBProperties OptionBProperties { get; set; }
        /// <summary> Option A properties. </summary>
        public VpnConfigurationOptionAProperties OptionAProperties { get; set; }
    }
}
