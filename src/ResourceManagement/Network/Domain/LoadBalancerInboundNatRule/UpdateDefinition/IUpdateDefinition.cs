// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition
{
    using Microsoft.Azure.Management.Network.Fluent.HasFloatingIP.UpdateDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition;

    /// <summary>
    /// The stage of an inbound NAT rule definition allowing to specify whether floating IP should be enabled.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithFloatingIP<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFloatingIP.UpdateDefinition.IWithFloatingIP<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>
    {
    }

    /// <summary>
    /// The final stage of the inbound NAT rule definition.
    /// At this stage, any remaining optional settings can be specified, or the inbound NAT rule definition
    /// can be attached to the parent load balancer definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition.IWithBackendPort<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition.IWithFloatingIP<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition.IWithIdleTimeout<ParentT>
    {
    }

    /// <summary>
    /// The entirety of an inbound NAT rule definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition.IBlank<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition.IWithProtocol<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition.IWithFrontend<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition.IWithFrontendPort<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of an inbound NAT rule definition allowing to specify the backend port.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithBackendPort<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasBackendPort.UpdateDefinition.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>
    {
    }

    /// <summary>
    /// The stage of an inbound NAT rule definition allowing to specify the idle connection timeout for this inbound NAT rule.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithIdleTimeout<ParentT> 
    {
        /// <summary>
        /// Specifies the idle connection timeout in minutes.
        /// </summary>
        /// <param name="minutes">A number of minutes.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<ParentT> WithIdleTimeoutInMinutes(int minutes);
    }

    /// <summary>
    /// The stage of an inbound NAT rule definition allowing to specify the frontend port.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithFrontendPort<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>
    {
    }

    /// <summary>
    /// The stage of an inbound NAT rule definition allowing to specify a frontend for the rule to apply to.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithFrontend<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontend.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>
    {
    }

    /// <summary>
    /// The first stage of the inbound NAT rule definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition.IWithProtocol<ParentT>
    {
    }

    /// <summary>
    /// The stage of an inbound NAT rule definition allowing to specify the transport protocol.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithProtocol<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>,Microsoft.Azure.Management.Network.Fluent.Models.TransportProtocol>
    {
    }
}