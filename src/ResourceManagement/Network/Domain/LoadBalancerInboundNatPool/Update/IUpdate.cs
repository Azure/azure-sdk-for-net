// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Update
{
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The stage of an inbound NAT pool update allowing to specify the frontend for the inbound NAT rules in the pool to apply to.
    /// </summary>
    public interface IWithFrontend  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontend.Update.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of an inbound NAT pool update allowing to specify the frontend port range.
    /// </summary>
    public interface IWithFrontendPortRange 
    {
        /// <summary>
        /// Specifies the frontend port range.
        /// </summary>
        /// <param name="from">The starting port number, between 1 and 65534.</param>
        /// <param name="to">The ending port number, greater than the starting port number and no more than 65534.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Update.IUpdate FromFrontendPortRange(int from, int to);
    }

    /// <summary>
    /// The stage of an inbound NAT pool update allowing to specify the transport protocol for the pool to apply to.
    /// </summary>
    public interface IWithProtocol  :
        Microsoft.Azure.Management.Network.Fluent.HasProtocol.Update.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Update.IUpdate,Microsoft.Azure.Management.Network.Fluent.Models.TransportProtocol>
    {
    }

    /// <summary>
    /// The stage of an inbound NAT pool update allowing to specify the backend port.
    /// </summary>
    public interface IWithBackendPort  :
        Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Update.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Update.IUpdate>
    {
    }

    /// <summary>
    /// The entirety of an inbound NAT pool update as part of a load balancer update.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Update.IWithProtocol,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Update.IWithFrontend,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Update.IWithBackendPort,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Update.IWithFrontendPortRange
    {
    }
}