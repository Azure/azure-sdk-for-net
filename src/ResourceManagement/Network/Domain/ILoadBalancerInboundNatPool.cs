// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// A client-side representation of an inbound NAT pool.
    /// </summary>
    public interface ILoadBalancerInboundNatPool  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Network.Fluent.IHasFrontend,
        Microsoft.Azure.Management.Network.Fluent.IHasBackendPort,
        Microsoft.Azure.Management.Network.Fluent.IHasProtocol<Models.TransportProtocol>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.InboundNatPoolInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>
    {
        /// <summary>
        /// Gets the starting frontend port number.
        /// </summary>
        int FrontendPortRangeStart { get; }

        /// <summary>
        /// Gets the ending frontend port number.
        /// </summary>
        int FrontendPortRangeEnd { get; }
    }
}