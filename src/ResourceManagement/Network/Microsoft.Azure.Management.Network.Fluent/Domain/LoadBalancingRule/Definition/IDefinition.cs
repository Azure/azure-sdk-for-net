// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition
{
    using Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasFrontend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition;

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
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<ParentT> WithLoadDistribution(string loadDistribution);
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
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithBackendPort<ParentT> WithBackend(string backendName);
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the frontend port to load balance.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IWithFrontendPort<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontendPort.Definition.IWithFrontendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithProbe<ParentT>>
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
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithBackend<ParentT> WithProbe(string name);
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to enable the floating IP functionality.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithFloatingIp<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Definition.IWithFloatingIp<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<ParentT>>
    {
    }

    /// <summary>
    /// The final stage of the load balancing rule definition.
    /// At this stage, any remaining optional settings can be specified, or the load balancing rule definition
    /// can be attached to the parent load balancer definition using WithAttach.attach().
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        IInDefinition<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithFloatingIp<ParentT>,
        IWithIdleTimeoutInMinutes<ParentT>,
        IWithLoadDistribution<ParentT>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the backend port to send the load-balanced traffic to.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IWithBackendPort<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasBackendPort.Definition.IWithBackendPort<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<ParentT>>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The entirety of a load balancing rule definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final DefinitionStages.WithAttach.attach().</typeparam>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithProtocol<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithFrontendPort<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithFrontend<ParentT>,
        IWithProbe<ParentT>,
        IWithBackend<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithBackendPort<ParentT>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the frontend to associate with the rule.
    /// </summary>
    /// <typeparam name="Parent">The parent load balancer type.</typeparam>
    public interface IWithFrontend<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasFrontend.Definition.IWithFrontend<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithFrontendPort<ParentT>>
    {
    }

    /// <summary>
    /// The first stage of the load balancing rule definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithProtocol<ParentT>
    {
    }

    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the transport protocol to apply the rule to.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final WithAttach.attach().</typeparam>
    public interface IWithProtocol<ParentT>  :
        Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithFrontend<ParentT>,string>
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
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IWithAttach<ParentT> WithIdleTimeoutInMinutes(int minutes);
    }
}