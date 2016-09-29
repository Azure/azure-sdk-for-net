// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update
{

    using Microsoft.Azure.Management.Fluent.Network.HasProtocol.Update;
    using Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.Update;
    using Microsoft.Azure.Management.Fluent.Network.HasBackendPort.Update;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResourceActions;
    using Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update;
    using Microsoft.Azure.Management.Fluent.Network.HasFrontend.Update;
    /// <summary>
    /// The stage of an inbound NAT rule update allowing to specify the frontend port.
    /// </summary>
    public interface IWithFrontendPort 
    {
        /// <summary>
        /// Specifies the frontend port.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate WithFrontendPort (int port);

    }
    /// <summary>
    /// The stage of an inbound NAT rule update allowing to specify the transport protocol for the rule to apply to.
    /// </summary>
    public interface IWithProtocol  :
        Microsoft.Azure.Management.Fluent.Network.HasProtocol.Update.IWithProtocol<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate,string>
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
        /// <param name="minutes">minutes a number of minutes</param>
        /// <returns>the next stage of the update</returns>
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate WithIdleTimeoutInMinutes (int minutes);

    }
    /// <summary>
    /// The stage of an inbound NAT rule update allowing to specify whether floating IP should be enabled.
    /// </summary>
    public interface IWithFloatingIp  :
        Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.Update.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate>
    {
    }
    /// <summary>
    /// The stage of an inbound NAT rule update allowing to specify the backend port.
    /// </summary>
    public interface IWithBackendPort  :
        Microsoft.Azure.Management.Fluent.Network.HasBackendPort.Update.IWithBackendPort<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate>
    {
    }
    /// <summary>
    /// The entirety of an inbound NAT rule update as part of a load balancer update.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>,
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IWithBackendPort,
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IWithFloatingIp,
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IWithFrontend,
        IWithFrontendPort,
        IWithIdleTimeout,
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IWithProtocol
    {
    }
    /// <summary>
    /// The stage of an inbound NAT rule update allowing to specify a frontend for the rule to apply to.
    /// </summary>
    public interface IWithFrontend  :
        Microsoft.Azure.Management.Fluent.Network.HasFrontend.Update.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.Update.IUpdate>
    {
    }
}