// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.UpdateDefinition
{
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition;
    using Models;

    /// <summary>
    /// The stage of an inbound NAT pool definition allowing to specify the backend port.
    /// </summary>
    /// <typeparam name="Parent">The parent load balancer type.</typeparam>
    public interface IWithBackendPort<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasBackendPort.UpdateDefinition.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>
    {
    }

    /// <summary>
    /// The first stage of the inbound NAT pool definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.UpdateDefinition.IWithProtocol<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the inbound NAT pool definition.
    /// At this stage, any remaining optional settings can be specified, or the inbound NAT pool
    /// definition can be attached to the parent load balancer definition using WithAttach.attach().
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>
    {
    }

    /// <summary>
    /// The stage of an inbound NAT pool definition allowing to specify the frontend for the inbound NAT rules in the pool to apply to.
    /// </summary>
    /// <typeparam name="Parent">The parent load balancer type.</typeparam>
    public interface IWithFrontend<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontend.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>
    {
    }

    /// <summary>
    /// The stage of an inbound NAT pool definition allowing to specify the frontend port range.
    /// </summary>
    /// <typeparam name="Parent">The parent load balancer type.</typeparam>
    public interface IWithFrontendPortRange<ParentT> 
    {
        /// <summary>
        /// Specified the frontend port range.
        /// </summary>
        /// <param name="from">The starting port number, between 1 and 65534.</param>
        /// <param name="to">The ending port number, greater than the starting port number and no more than 65534.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<ParentT> WithFrontendPortRange(int from, int to);
    }

    /// <summary>
    /// The stage of an inbound NAT pool definition allowing to specify the transport protocol for the pool to apply to.
    /// </summary>
    /// <typeparam name="Parent">The parent load balancer type.</typeparam>
    public interface IWithProtocol<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>, TransportProtocol>
    {
    }

    /// <summary>
    /// The entirety of an inbound NAT pool definition as part of a load balancer update.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final UpdateDefinitionStages.WithAttach.attach().</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.UpdateDefinition.IWithProtocol<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.UpdateDefinition.IWithFrontend<ParentT>,
        IWithFrontendPortRange<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.UpdateDefinition.IWithBackendPort<ParentT>
    {
    }
}