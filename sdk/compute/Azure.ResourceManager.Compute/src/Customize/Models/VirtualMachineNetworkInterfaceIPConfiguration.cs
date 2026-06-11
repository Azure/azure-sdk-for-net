// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class VirtualMachineNetworkInterfaceIPConfiguration
    {
        // Backward compatibility: the generated Compute-local property is named ApplicationGatewayBackendAddressPoolResources
        // and uses ComputeWriteableSubResourceData. Restore the old property with ARM common WritableSubResource.
        /// <summary> Specifies an array of references to backend address pools of application gateways. </summary>
        public IList<WritableSubResource> ApplicationGatewayBackendAddressPools => ApplicationGatewayBackendAddressPoolResources.ToWritableSubResources();

        // Backward compatibility: the generated Compute-local property is named ApplicationSecurityGroupResources
        // and uses ComputeWriteableSubResourceData. Restore the old property with ARM common WritableSubResource.
        /// <summary> Specifies an array of references to application security group. </summary>
        public IList<WritableSubResource> ApplicationSecurityGroups => ApplicationSecurityGroupResources.ToWritableSubResources();

        // Backward compatibility: the generated Compute-local property is named LoadBalancerBackendAddressPoolResources
        // and uses ComputeWriteableSubResourceData. Restore the old property with ARM common WritableSubResource.
        /// <summary> Specifies an array of references to backend address pools of load balancers. </summary>
        public IList<WritableSubResource> LoadBalancerBackendAddressPools => LoadBalancerBackendAddressPoolResources.ToWritableSubResources();
    }
}
