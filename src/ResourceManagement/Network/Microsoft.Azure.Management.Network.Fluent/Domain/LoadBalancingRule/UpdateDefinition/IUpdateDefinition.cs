// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition
{
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition;

    /// <summary>
    /// The first stage of the load balancing rule definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithProtocol<ParentT>
    {
    }

    /// <summary>
    /// The entirety of a load balancing rule definition as part of a load balancer update.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final UpdateDefinitionStages.WithAttach.attach().</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithProtocol<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithFrontendPort<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithFrontend<ParentT>,
        IWithProbe<ParentT>,
        IWithBackend<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithBackendPort<ParentT>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the backend port to send the load-balanced traffic to.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IWithBackendPort<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasBackendPort.UpdateDefinition.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the connection timeout for idle connections.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithIdleTimeoutInMinutes<ParentT> 
    {
        /// <summary>
        /// Specifies the number of minutes before an idle connection is closed.
        /// </summary>
        /// <param name="minutes">The desired number of minutes.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<ParentT> WithIdleTimeoutInMinutes(int minutes);
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the load distribution.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithLoadDistribution<ParentT> 
    {
        /// <summary>
        /// Specifies the load distribution mode.
        /// </summary>
        /// <param name="loadDistribution">A supported load distribution mode.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<ParentT> WithLoadDistribution(string loadDistribution);
    }

    /// <summary>
    /// The final stage of the load balancing rule definition.
    /// At this stage, any remaining optional settings can be specified, or the load balancing rule definition
    /// can be attached to the parent load balancer definition using WithAttach.attach().
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithFloatingIp<ParentT>,
        IWithIdleTimeoutInMinutes<ParentT>,
        IWithLoadDistribution<ParentT>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the backend to associate the rule with.
    /// </summary>
    /// <typeparam name="Parent">The parent load balancer type.</typeparam>
    public interface IWithBackend<ParentT> 
    {
        /// <summary>
        /// Associates the load balancing rule with the specified backend of this load balancer.
        /// A backedn with the specified name must already exist on this load balancer.
        /// </summary>
        /// <param name="backendName">The name of an existing backend.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithBackendPort<ParentT> WithBackend(string backendName);
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the frontend port to load balance.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IWithFrontendPort<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithProbe<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to enable the floating IP functionality.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithFloatingIp<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.UpdateDefinition.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the probe to associate with the rule.
    /// </summary>
    /// <typeparam name="Parent">The parent load balancer type.</typeparam>
    public interface IWithProbe<ParentT> 
    {
        /// <summary>
        /// Associates the specified existing HTTP or TCP probe of this load balancer with the load balancing rule.
        /// </summary>
        /// <param name="name">The name of an existing HTTP or TCP probe.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithBackend<ParentT> WithProbe(string name);
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the frontend to associate with the rule.
    /// </summary>
    /// <typeparam name="Parent">The parent load balancer type.</typeparam>
    public interface IWithFrontend<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontend.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the transport protocol to apply the rule to.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IWithProtocol<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>,string>
    {
    }
}