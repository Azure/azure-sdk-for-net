// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition
{

    using Microsoft.Azure.Management.Fluent.Network.HasProtocol.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Fluent.Network.HasBackendPort.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.HasFrontend.UpdateDefinition;
    /// <summary>
    /// The stage of an inbound NAT rule definition allowing to specify the transport protocol.
    /// @param <ParentT> the parent load balancer type
    /// </summary>
    public interface IWithProtocol<ParentT>  :
        Microsoft.Azure.Management.Fluent.Network.HasProtocol.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>,string>
    {
    }
    /// <summary>
    /// The entirety of an inbound NAT rule definition.
    /// @param <ParentT> the return type of the final {@link DefinitionStages.WithAttach#attach()}
    /// </summary>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithProtocol<ParentT>,
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithFrontend<ParentT>,
        IWithFrontendPort<ParentT>,
        IWithAttach<ParentT>
    {
    }
    /// <summary>
    /// The final stage of the inbound NAT rule definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the inbound NAT rule definition
    /// can be attached to the parent load balancer definition using {@link WithAttach#attach()}.
    /// @param <ParentT> the return type of {@link WithAttach#attach()}
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>,
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithBackendPort<ParentT>,
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithFloatingIp<ParentT>,
        IWithIdleTimeout<ParentT>
    {
    }
    /// <summary>
    /// The stage of an inbound NAT rule definition allowing to specify the backend port.
    /// @param <ParentT> the parent load balancer type
    /// </summary>
    public interface IWithBackendPort<ParentT>  :
        Microsoft.Azure.Management.Fluent.Network.HasBackendPort.UpdateDefinition.IWithBackendPort<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>>
    {
    }
    /// <summary>
    /// The stage of an inbound NAT rule definition allowing to specify the frontend port.
    /// @param <ParentT> the parent load balancer type
    /// </summary>
    public interface IWithFrontendPort<ParentT> 
    {
        /// <summary>
        /// Specifies the frontend port.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        IWithAttach<ParentT> WithFrontendPort (int port);

    }
    /// <summary>
    /// The first stage of the inbound NAT rule definition.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithProtocol<ParentT>
    {
    }
    /// <summary>
    /// The stage of an inbound NAT rule definition allowing to specify whether floating IP should be enabled.
    /// @param <ParentT> the parent load balancer type
    /// </summary>
    public interface IWithFloatingIp<ParentT>  :
        Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.UpdateDefinition.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>>
    {
    }
    /// <summary>
    /// The stage of an inbound NAT rule definition allowing to specify the idle connection timeout for this inbound NAT rule.
    /// @param <ParentT> the parent load balancer type
    /// </summary>
    public interface IWithIdleTimeout<ParentT> 
    {
        /// <summary>
        /// Specifies the idle connection timeout in minutes.
        /// </summary>
        /// <param name="minutes">minutes a number of minutes</param>
        /// <returns>the next stage of the definition</returns>
        IWithAttach<ParentT> WithIdleTimeoutInMinutes (int minutes);

    }
    /// <summary>
    /// The stage of an inbound NAT rule definition allowing to specify a frontend for the rule to apply to.
    /// @param <ParentT> the parent load balancer type
    /// </summary>
    public interface IWithFrontend<ParentT>  :
        Microsoft.Azure.Management.Fluent.Network.HasFrontend.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.InboundNatRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>>
    {
    }
}