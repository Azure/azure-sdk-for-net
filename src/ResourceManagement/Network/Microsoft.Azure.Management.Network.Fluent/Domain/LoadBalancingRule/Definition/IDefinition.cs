// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition
{

    using Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.Definition;
    using Microsoft.Azure.Management.Fluent.Network.HasBackendPort.Definition;
    using Microsoft.Azure.Management.Fluent.Network.HasFrontend.Definition;
    using Microsoft.Azure.Management.Fluent.Network.HasProtocol.Definition;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Definition;
    /// <summary>
    /// The stage of a load balancing rule definition allowing to enable the floating IP functionality.
    /// @param <ParentT> the return type of {@link WithAttach#attach()}
    /// </summary>
    public interface IWithFloatingIp<ParentT>  :
        Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.Definition.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithAttach<ParentT>>
    {
    }
    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the backend port to send the load-balanced traffic to.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IWithBackendPort<ParentT>  :
        Microsoft.Azure.Management.Fluent.Network.HasBackendPort.Definition.IWithBackendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithAttach<ParentT>>,
        IWithAttach<ParentT>
    {
    }
    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the connection timeout for idle connections.
    /// @param <ParentT> the return type of {@link WithAttach#attach()}
    /// </summary>
    public interface IWithIdleTimeoutInMinutes<ParentT> 
    {
        /// <summary>
        /// Specifies the number of minutes before an idle connection is closed.
        /// </summary>
        /// <param name="minutes">minutes the desired number of minutes</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithAttach<ParentT> WithIdleTimeoutInMinutes(int minutes);

    }
    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the frontend to associate with the rule.
    /// @param <ParentT> the parent load balancer type
    /// </summary>
    public interface IWithFrontend<ParentT>  :
        Microsoft.Azure.Management.Fluent.Network.HasFrontend.Definition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithFrontendPort<ParentT>>
    {
    }
    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the load distribution.
    /// @param <ParentT> the return type of {@link WithAttach#attach()}
    /// </summary>
    public interface IWithLoadDistribution<ParentT> 
    {
        /// <summary>
        /// Specifies the load distribution mode.
        /// </summary>
        /// <param name="loadDistribution">loadDistribution a supported load distribution mode</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithAttach<ParentT> WithLoadDistribution(string loadDistribution);

    }
    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the frontend port to load balance.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IWithFrontendPort<ParentT> 
    {
        /// <summary>
        /// Specifies the frontend port to load balance.
        /// </summary>
        /// <param name="port">port a port number</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithProbe<ParentT> WithFrontendPort(int port);

    }
    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the transport protocol to apply the rule to.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IWithProtocol<ParentT>  :
        Microsoft.Azure.Management.Fluent.Network.HasProtocol.Definition.IWithProtocol<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithFrontend<ParentT>,string>
    {
    }
    /// <summary>
    /// The final stage of the load balancing rule definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the load balancing rule definition
    /// can be attached to the parent load balancer definition using {@link WithAttach#attach()}.
    /// @param <ParentT> the return type of {@link WithAttach#attach()}
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInDefinition<ParentT>,
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithFloatingIp<ParentT>,
        IWithIdleTimeoutInMinutes<ParentT>,
        IWithLoadDistribution<ParentT>
    {
    }
    /// <summary>
    /// The first stage of the load balancing rule definition.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithProtocol<ParentT>
    {
    }
    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the backend to associate the rule with.
    /// @param <ParentT> the parent load balancer type
    /// </summary>
    public interface IWithBackend<ParentT> 
    {
        /// <summary>
        /// Associates the load balancing rule with the specified backend of this load balancer.
        /// <p>
        /// A backedn with the specified name must already exist on this load balancer.
        /// </summary>
        /// <param name="backendName">backendName the name of an existing backend</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithBackendPort<ParentT> WithBackend(string backendName);

    }
    /// <summary>
    /// The entirety of a load balancing rule definition.
    /// @param <ParentT> the return type of the final {@link DefinitionStages.WithAttach#attach()}
    /// </summary>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithProtocol<ParentT>,
        IWithFrontendPort<ParentT>,
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithFrontend<ParentT>,
        IWithProbe<ParentT>,
        IWithBackend<ParentT>,
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithBackendPort<ParentT>
    {
    }
    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the probe to associate with the rule.
    /// @param <ParentT> the parent load balancer type
    /// </summary>
    public interface IWithProbe<ParentT> 
    {
        /// <summary>
        /// Associates the specified existing HTTP or TCP probe of this load balancer with the load balancing rule.
        /// </summary>
        /// <param name="name">name the name of an existing HTTP or TCP probe</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.Definition.IWithBackend<ParentT> WithProbe(string name);

    }
}