// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition
{
    using Microsoft.Azure.Management.Network.Fluent.HasFloatingIP.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Definition;

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
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition.IWithAttach<ParentT> WithIdleTimeoutInMinutes(int minutes);
    }

    /// <summary>
    /// The entirety of an inbound NAT rule definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition.IWithProtocol<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition.IWithFrontend<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition.IWithFrontendPort<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The first stage of the inbound NAT rule definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition.IWithProtocol<ParentT>
    {
    }

    /// <summary>
    /// The stage of an inbound NAT rule definition allowing to specify whether floating IP should be enabled.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithFloatingIP<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFloatingIP.Definition.IWithFloatingIP<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>>
    {
    }

    /// <summary>
    /// The final stage of the inbound NAT rule definition.
    /// At this stage, any remaining optional settings can be specified, or the inbound NAT rule definition
    /// can be attached to the parent load balancer definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition.IWithBackendPort<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition.IWithFloatingIP<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition.IWithIdleTimeout<ParentT>
    {
    }

    /// <summary>
    /// The stage of an inbound NAT rule definition allowing to specify a frontend for the rule to apply to.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithFrontend<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontend.Definition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>>
    {
    }

    /// <summary>
    /// The stage of an inbound NAT rule definition allowing to specify the transport protocol.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithProtocol<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>,Microsoft.Azure.Management.Network.Fluent.Models.TransportProtocol>
    {
    }

    /// <summary>
    /// The stage of an inbound NAT rule definition allowing to specify the frontend port.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithFrontendPort<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.Definition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>>
    {
    }

    /// <summary>
    /// The stage of an inbound NAT rule definition allowing to specify the backend port.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithBackendPort<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Definition.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule>>
    {
    }
}