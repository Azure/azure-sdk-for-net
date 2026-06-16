// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class VirtualMachineNetworkInterfaceIPConfiguration
    {
        // Backward compatibility: the generated Compute-local property is named ApplicationGatewayBackendAddressPoolResources
        // and uses ComputeWriteableSubResourceData. Restore the old property with ARM common WritableSubResource.
        /// <summary> Specifies an array of references to backend address pools of application gateways. </summary>
        [Obsolete("Use ApplicationGatewayBackendAddressPoolResources instead. This compatibility property cannot be used for mutation.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<WritableSubResource> ApplicationGatewayBackendAddressPools => throw new NotSupportedException("Use ApplicationGatewayBackendAddressPoolResources instead.");

        // Backward compatibility: the generated Compute-local property is named ApplicationSecurityGroupResources
        // and uses ComputeWriteableSubResourceData. Restore the old property with ARM common WritableSubResource.
        /// <summary> Specifies an array of references to application security group. </summary>
        [Obsolete("Use ApplicationSecurityGroupResources instead. This compatibility property cannot be used for mutation.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<WritableSubResource> ApplicationSecurityGroups => throw new NotSupportedException("Use ApplicationSecurityGroupResources instead.");

        // Backward compatibility: the generated Compute-local property is named LoadBalancerBackendAddressPoolResources
        // and uses ComputeWriteableSubResourceData. Restore the old property with ARM common WritableSubResource.
        /// <summary> Specifies an array of references to backend address pools of load balancers. </summary>
        [Obsolete("Use LoadBalancerBackendAddressPoolResources instead. This compatibility property cannot be used for mutation.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<WritableSubResource> LoadBalancerBackendAddressPools => throw new NotSupportedException("Use LoadBalancerBackendAddressPoolResources instead.");
    }
}
