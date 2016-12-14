// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Update
{
    using Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;
    using Models;

    /// <summary>
    /// The stage of an inbound NAT rule update allowing to specify the frontend port.
    /// </summary>
    public interface IWithFrontendPort  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.Update.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of an inbound NAT rule update allowing to specify the transport protocol for the rule to apply to.
    /// </summary>
    public interface IWithProtocol  :
        Microsoft.Azure.Management.Network.Fluent.HasProtocol.Update.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Update.IUpdate, TransportProtocol>
    {
    }

    /// <summary>
    /// The stage of an inbound NAT rule update allowing to specify the backend port.
    /// </summary>
    public interface IWithBackendPort  :
        Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Update.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of an inbound NAT rule update allowing to specify whether floating IP should be enabled.
    /// </summary>
    public interface IWithFloatingIp  :
        Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Update.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of an inbound NAT rule update allowing to specify a frontend for the rule to apply to.
    /// </summary>
    public interface IWithFrontend  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontend.Update.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of an inbound NAT rule update allowing to specify the idle connection timeout for this inbound NAT rule.
    /// </summary>
    public interface IWithIdleTimeout 
    {
        /// <summary>
        /// Specifies the idle connection timeout in minutes.
        /// </summary>
        /// <param name="minutes">A number of minutes.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Update.IUpdate WithIdleTimeoutInMinutes(int minutes);
    }

    /// <summary>
    /// The entirety of an inbound NAT rule update as part of a load balancer update.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Update.IWithBackendPort,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Update.IWithFloatingIp,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Update.IWithFrontend,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Update.IWithFrontendPort,
        IWithIdleTimeout,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Update.IWithProtocol
    {
    }
}