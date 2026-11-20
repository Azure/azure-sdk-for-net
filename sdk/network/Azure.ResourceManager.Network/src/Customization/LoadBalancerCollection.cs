// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class LoadBalancerCollection
    {
        // Preserve the 1.15.0 signature; the native operation adds an optional detailLevel parameter.
        /// <summary> Gets a load balancer if it exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual NullableResponse<LoadBalancerResource> GetIfExists(string loadBalancerName, string expand, CancellationToken cancellationToken)
            => GetIfExists(loadBalancerName, expand, null, cancellationToken);

        // Preserve the 1.15.0 signature while leaving response handling to the native Get operation.
        /// <summary> Gets the specified load balancer. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<LoadBalancerResource> Get(string loadBalancerName, string expand, CancellationToken cancellationToken)
            => Get(loadBalancerName, expand, null, cancellationToken);

        // Preserve the 1.15.0 signature while leaving not-found handling to the native Exists operation.
        /// <summary> Checks whether the specified load balancer exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<bool> Exists(string loadBalancerName, string expand, CancellationToken cancellationToken)
            => Exists(loadBalancerName, expand, null, cancellationToken);

        // Preserve the 1.15.0 async signature without changing the native detailLevel default.
        /// <summary> Gets a load balancer if it exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<NullableResponse<LoadBalancerResource>> GetIfExistsAsync(string loadBalancerName, string expand, CancellationToken cancellationToken)
            => GetIfExistsAsync(loadBalancerName, expand, null, cancellationToken);

        // Preserve the 1.15.0 async signature while forwarding the caller's expansion and cancellation.
        /// <summary> Gets the specified load balancer. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<LoadBalancerResource>> GetAsync(string loadBalancerName, string expand, CancellationToken cancellationToken)
            => GetAsync(loadBalancerName, expand, null, cancellationToken);

        // Preserve the 1.15.0 async signature while leaving not-found handling to the native operation.
        /// <summary> Checks whether the specified load balancer exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<bool>> ExistsAsync(string loadBalancerName, string expand, CancellationToken cancellationToken)
            => ExistsAsync(loadBalancerName, expand, null, cancellationToken);
    }
}
