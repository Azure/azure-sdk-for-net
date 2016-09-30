// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.HasFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.HasProtocol.UpdateDefinition;
    using Microsoft.Azure.Management.Fluent.Network.HasBackendPort.UpdateDefinition;
    /// <summary>
    /// The final stage of the load balancing rule definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the load balancing rule definition
    /// can be attached to the parent load balancer definition using {@link WithAttach#attach()}.
    /// @param <ParentT> the return type of {@link WithAttach#attach()}
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>,
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithFloatingIp<ParentT>,
        IWithIdleTimeoutInMinutes<ParentT>,
        IWithLoadDistribution<ParentT>
    {
    }
    /// <summary>
    /// The stage of a load balancing rule definition allowing to enable the floating IP functionality.
    /// @param <ParentT> the return type of {@link WithAttach#attach()}
    /// </summary>
    public interface IWithFloatingIp<ParentT>  :
        Microsoft.Azure.Management.Fluent.Network.HasFloatingIp.UpdateDefinition.IWithFloatingIp<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>>
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
        IWithBackend<ParentT> WithProbe (string name);

    }
    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the frontend to associate with the rule.
    /// @param <ParentT> the parent load balancer type
    /// </summary>
    public interface IWithFrontend<ParentT>  :
        Microsoft.Azure.Management.Fluent.Network.HasFrontend.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithFrontendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>>
    {
    }
    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the transport protocol to apply the rule to.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IWithProtocol<ParentT>  :
        Microsoft.Azure.Management.Fluent.Network.HasProtocol.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithFrontend<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>,string>
    {
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
        IWithProbe<ParentT> WithFrontendPort (int port);

    }
    /// <summary>
    /// The stage of a load balancing rule definition allowing to specify the backend port to send the load-balanced traffic to.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IWithBackendPort<ParentT>  :
        Microsoft.Azure.Management.Fluent.Network.HasBackendPort.UpdateDefinition.IWithBackendPort<Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithAttach<Microsoft.Azure.Management.Fluent.Network.LoadBalancer.Update.IUpdate>>,
        IWithAttach<ParentT>
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
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithBackendPort<ParentT> WithBackend (string backendName);

    }
    /// <summary>
    /// The first stage of the load balancing rule definition.
    /// @param <ParentT> the return type of the final {@link WithAttach#attach()}
    /// </summary>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithProtocol<ParentT>
    {
    }
    /// <summary>
    /// The entirety of a load balancing rule definition as part of a load balancer update.
    /// @param <ParentT> the return type of the final {@link UpdateDefinitionStages.WithAttach#attach()}
    /// </summary>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithProtocol<ParentT>,
        IWithFrontendPort<ParentT>,
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithFrontend<ParentT>,
        IWithProbe<ParentT>,
        IWithBackend<ParentT>,
        Microsoft.Azure.Management.Fluent.Network.LoadBalancingRule.UpdateDefinition.IWithBackendPort<ParentT>
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
        IWithAttach<ParentT> WithLoadDistribution (string loadDistribution);

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
        IWithAttach<ParentT> WithIdleTimeoutInMinutes (int minutes);

    }
}