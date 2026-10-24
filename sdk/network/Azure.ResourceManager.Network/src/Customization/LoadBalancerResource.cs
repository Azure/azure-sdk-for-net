// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class LoadBalancerResource
    {
        // Preserve the 1.15.0 signature; the native Get operation adds an optional detailLevel parameter.
        /// <summary> Gets this load balancer. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<LoadBalancerResource> Get(string expand, CancellationToken cancellationToken)
            => Get(expand, null, cancellationToken);

        // Preserve the 1.15.0 async signature without changing native expansion or cancellation handling.
        /// <summary> Gets this load balancer. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<LoadBalancerResource>> GetAsync(string expand, CancellationToken cancellationToken)
            => GetAsync(expand, null, cancellationToken);

        // The same endpoint now generates as GetAllAsync returning data; 1.15.0 returned resource wrappers.
        /// <summary> Gets the network interfaces associated with this load balancer. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual AsyncPageable<NetworkInterfaceResource> GetLoadBalancerNetworkInterfacesAsync(CancellationToken cancellationToken = default)
            => new AsyncPageableWrapper<NetworkInterfaceData, NetworkInterfaceResource>(GetAllAsync(cancellationToken), data => new NetworkInterfaceResource(Client, data));

        // Preserve the 1.15.0 resource-valued pages and continuation tokens over native data-valued listing.
        /// <summary> Gets the network interfaces associated with this load balancer. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Pageable<NetworkInterfaceResource> GetLoadBalancerNetworkInterfaces(CancellationToken cancellationToken = default)
            => new PageableWrapper<NetworkInterfaceData, NetworkInterfaceResource>(GetAll(cancellationToken), data => new NetworkInterfaceResource(Client, data));
    }
}
