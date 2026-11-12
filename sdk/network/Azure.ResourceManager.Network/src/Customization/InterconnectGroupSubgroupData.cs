// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    public partial class InterconnectGroupSubgroupData
    {
        // Retain nested wire storage while exposing the consolidated spec's flattened members.
        [CodeGenMember("Properties")]
        internal SubgroupProperties Properties { get; }

        /// <summary> The unique identifier of the subgroup. </summary>
        [WirePath("properties.internalSubgroupId")]
        public string InternalSubgroupId => Properties?.InternalSubgroupId;

        /// <summary> A list of virtual machine references. </summary>
        [WirePath("properties.virtualMachines")]
        public IReadOnlyList<NetworkSubResource> VirtualMachines => Properties?.VirtualMachines;

        /// <summary> The provisioning state of the subgroup. </summary>
        [WirePath("properties.provisioningState")]
        public NetworkProvisioningState? ProvisioningState => Properties?.ProvisioningState;

        /// <summary> Resource ID. </summary>
        [WirePath("properties.interconnectBlock.id")]
        public ResourceIdentifier InterconnectBlockId => Properties?.InterconnectBlockId;
    }
}
