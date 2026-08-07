// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridContainerService.Models
{
    // TypeSpec flattening adds containing-model prefixes that differ from the GA property names.
    public partial class ProvisionedClusterProperties
    {
        /// <summary> The list of SSH public keys used to authenticate with VMs. A maximum of 1 key may be specified. </summary>
        [CodeGenMember("LinuxSshPublicKeys")]
        public IList<LinuxSshPublicKey> SshPublicKeys { get; }

        /// <summary> List of ARM resource Ids for the infrastructure network object. </summary>
        [CodeGenMember("CloudProviderInfraNetworkVnetSubnetIds")]
        public IList<ResourceIdentifier> InfraNetworkVnetSubnetIds { get; }
    }
}
