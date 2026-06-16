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
    public partial class VirtualMachineScaleSetUpdateIPConfiguration : ComputeWriteableSubResourceData
    {
        // Backward compatibility: the generated Compute-local property is named ApplicationGatewayBackendAddressPoolResources
        // and uses ComputeWriteableSubResourceData. Restore the old property with ARM common WritableSubResource.
        /// <summary> The application gateway backend address pools. </summary>
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
        /// <summary> The load balancer backend address pools. </summary>
        [Obsolete("Use LoadBalancerBackendAddressPoolResources instead. This compatibility property cannot be used for mutation.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<WritableSubResource> LoadBalancerBackendAddressPools => throw new NotSupportedException("Use LoadBalancerBackendAddressPoolResources instead.");

        // Backward compatibility: the generated Compute-local property is named LoadBalancerInboundNatPoolResources
        // and uses ComputeWriteableSubResourceData. Restore the old property with ARM common WritableSubResource.
        /// <summary> The load balancer inbound nat pools. </summary>
        [Obsolete("Use LoadBalancerInboundNatPoolResources instead. This compatibility property cannot be used for mutation.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<WritableSubResource> LoadBalancerInboundNatPools => throw new NotSupportedException("Use LoadBalancerInboundNatPoolResources instead.");
    }
}
