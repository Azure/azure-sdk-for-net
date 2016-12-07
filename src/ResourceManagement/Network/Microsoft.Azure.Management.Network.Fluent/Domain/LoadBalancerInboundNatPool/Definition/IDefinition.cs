// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Definition
{

    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    /// <summary>
    /// The stage of an inbound NAT pool definition allowing to specify the frontend port range.
    /// @param <ParentT> the parent load balancer type
    /// </summary>
    public interface IWithFrontendPortRange<ParentT> 
    {
        /// <summary>
        /// Specifies the frontend port range.
        /// </summary>
        /// <param name="from">from the starting port number, between 1 and 65534</param>
        /// <param name="to">to the ending port number, greater than the starting port number and no more than 65534</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Definition.IWithBackendPort<ParentT> WithFrontendPortRange(int from, int to);

    }
    /// <summary>
    /// The entirety of an inbound NAT pool definition.
    /// @param <ParentT> the return type of the final {@link DefinitionStages.WithAttach#attach()}
    /// </summary>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Definition.IWithProtocol<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Definition.IWithFrontend<ParentT>,
        IWithFrontendPortRange<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Definition.IWithBackendPort<ParentT>
    {
    }
    /// <summary>
    /// The stage of an inbound NAT pool definition allowing to specify the backend port.
    /// @param <ParentT> the parent load balancer type
    /// </summary>
    public interface IWithBackendPort<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Definition.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Definition.IWithAttach<ParentT>>
    {
    }
    /// <summary>
    /// The stage of an inbound NAT pool definition allowing to specify the frontend for the inbound NAT rules in the pool to apply to.
    /// @param <ParentT> the parent load balancer type
    /// </summary>
    public interface IWithFrontend<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontend.Definition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Definition.IWithFrontendPortRange<ParentT>>
    {
    }
    /// <summary>
    /// The stage of an inbound NAT pool definition allowing to specify the transport protocol for the pool to apply to.
    /// @param <ParentT> the parent load balancer type
    /// </summary>
    public interface IWithProtocol<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Definition.IWithFrontend<ParentT>,string>
    {
    }
    /// <summary>
    /// The first stage of the inbound NAT pool definition.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Definition.IWithProtocol<ParentT>
    {
    }
    /// <summary>
    /// The final stage of the inbound NAT pool definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the inbound NAT pool definition
    /// can be attached to the parent load balancer definition using {@link WithAttach#attach()}.
    /// @param <ParentT> the return type of {@link WithAttach#attach()}
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInDefinition<ParentT>
    {
    }
}