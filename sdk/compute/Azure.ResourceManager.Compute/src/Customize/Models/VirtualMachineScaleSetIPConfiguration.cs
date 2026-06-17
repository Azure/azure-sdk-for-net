// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute.Models
{
    // Backward compatibility: this model previously inherited ComputeWriteableSubResourceData and its virtual Id property.
    // Without this base type, ApiCompat reports the removed base class and missing inherited Id accessors.
    public partial class VirtualMachineScaleSetIPConfiguration : ComputeWriteableSubResourceData
    {
        // Backward compatibility: the generated Compute-local property is named ApplicationGatewayBackendAddressPoolResources
        // and uses ComputeWriteableSubResourceData. Restore the old property with ARM common WritableSubResource.
        /// <summary> Specifies an array of references to backend address pools of application gateways. </summary>
        [Obsolete("This property is obsolete and no longer works. Use ApplicationGatewayBackendAddressPoolResources instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<WritableSubResource> ApplicationGatewayBackendAddressPools { get; set; }

        // Backward compatibility: the generated Compute-local property is named ApplicationSecurityGroupResources
        // and uses ComputeWriteableSubResourceData. Restore the old property with ARM common WritableSubResource.
        /// <summary> Specifies an array of references to application security group. </summary>
        [Obsolete("This property is obsolete and no longer works. Use ApplicationSecurityGroupResources instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<WritableSubResource> ApplicationSecurityGroups { get; set; }

        // Backward compatibility: the generated Compute-local property is named LoadBalancerBackendAddressPoolResources
        // and uses ComputeWriteableSubResourceData. Restore the old property with ARM common WritableSubResource.
        /// <summary> Specifies an array of references to backend address pools of load balancers. </summary>
        [Obsolete("This property is obsolete and no longer works. Use LoadBalancerBackendAddressPoolResources instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<WritableSubResource> LoadBalancerBackendAddressPools { get; set; }

        // Backward compatibility: the generated Compute-local property is named LoadBalancerInboundNatPoolResources
        // and uses ComputeWriteableSubResourceData. Restore the old property with ARM common WritableSubResource.
        /// <summary> Specifies an array of references to inbound Nat pools of the load balancers. </summary>
        [Obsolete("This property is obsolete and no longer works. Use LoadBalancerInboundNatPoolResources instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<WritableSubResource> LoadBalancerInboundNatPools { get; set; }
    }
}
