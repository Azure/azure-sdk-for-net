// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the LoadBalancerResource type. </summary>
    public partial class LoadBalancerResource
    {
        /// <summary> Invokes the GetLoadBalancerNetworkInterfacesAsync compatibility operation. </summary>
        public virtual AsyncPageable<NetworkInterfaceResource> GetLoadBalancerNetworkInterfacesAsync(CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetLoadBalancerNetworkInterfaces compatibility operation. </summary>
        public virtual Pageable<NetworkInterfaceResource> GetLoadBalancerNetworkInterfaces(CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
