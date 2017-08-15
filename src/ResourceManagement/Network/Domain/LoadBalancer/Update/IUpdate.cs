// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update
{
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.UpdateDefinition;

    /// <summary>
    /// The stage of a load balancer update allowing to create a new inbound NAT pool for a virtual machine scale set.
    /// </summary>
    public interface IWithInboundNatPool 
    {
        /// <summary>
        /// Begins the description of an update to an existing inbound NAT pool.
        /// </summary>
        /// <param name="name">The name of the inbound NAT pool to update.</param>
        /// <return>The first stage of the inbound NAT pool update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Update.IUpdate UpdateInboundNatPool(string name);

        /// <summary>
        /// Removes the specified inbound NAT pool from the load balancer.
        /// </summary>
        /// <param name="name">The name of an existing inbound NAT pool on this load balancer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithoutInboundNatPool(string name);

        /// <summary>
        /// Begins the definition of a new inbound NAT pool.
        /// </summary>
        /// <param name="name">The name of the inbound NAT pool.</param>
        /// <return>The first stage of the new inbound NAT pool definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> DefineInboundNatPool(string name);
    }

    /// <summary>
    /// The template for a load balancer update operation, containing all the settings that
    /// can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IWithProbe,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IWithBackend,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IWithLoadBalancingRule,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IWithPublicFrontend,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IWithPrivateFrontend,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IWithInboundNatRule,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IWithInboundNatPool
    {
    }

    /// <summary>
    /// The stage of the load balancer update allowing to add or remove backends.
    /// </summary>
    public interface IWithBackend 
    {
        /// <summary>
        /// Begins the definition of a new backend as part of this load balancer update.
        /// </summary>
        /// <param name="name">The name for the new backend.</param>
        /// <return>The first stage of the backend definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> DefineBackend(string name);

        /// <summary>
        /// Removes the specified backend from the load balancer.
        /// </summary>
        /// <param name="name">The name of the backend to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithoutBackend(string name);

        /// <summary>
        /// Begins the description of an update to an existing backend of this load balancer.
        /// </summary>
        /// <param name="name">The name of the backend to update.</param>
        /// <return>The first stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.Update.IUpdate UpdateBackend(string name);
    }

    /// <summary>
    /// The stage of the load balancer update allowing to add, remove or modify probes.
    /// </summary>
    public interface IWithProbe 
    {
        /// <summary>
        /// Begins the description of an update to an existing HTTP probe on this load balancer.
        /// </summary>
        /// <param name="name">The name of the probe to update.</param>
        /// <return>The first stage of the probe update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Update.IUpdate UpdateHttpProbe(string name);

        /// <summary>
        /// Begins the description of an update to an existing TCP probe on this load balancer.
        /// </summary>
        /// <param name="name">The name of the probe to update.</param>
        /// <return>The first stage of the probe update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.Update.IUpdate UpdateTcpProbe(string name);

        /// <summary>
        /// Begins the definition of a new TCP probe to add to the load balancer.
        /// The definition must be completed with a call to  LoadBalancerHttpProbe.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the new probe.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> DefineTcpProbe(string name);

        /// <summary>
        /// Begins the definition of a new HTTP probe to add to the load balancer.
        /// The definition must be completed with a call to  LoadBalancerHttpProbe.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the new probe.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> DefineHttpProbe(string name);

        /// <summary>
        /// Removes the specified probe from the load balancer, if present.
        /// </summary>
        /// <param name="name">The name of the probe to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithoutProbe(string name);
    }

    /// <summary>
    /// The stage of a load balancer update allowing to define, remove or edit inbound NAT rules.
    /// </summary>
    public interface IWithInboundNatRule 
    {
        /// <summary>
        /// Begins the description of an update to an existing inbound NAT rule.
        /// </summary>
        /// <param name="name">The name of the inbound NAT rule to update.</param>
        /// <return>The first stage of the inbound NAT rule update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Update.IUpdate UpdateInboundNatRule(string name);

        /// <summary>
        /// Removes the specified inbound NAT rule from the load balancer.
        /// </summary>
        /// <param name="name">The name of an existing inbound NAT rule on this load balancer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithoutInboundNatRule(string name);

        /// <summary>
        /// Begins the definition of a new inbound NAT rule.
        /// The definition must be completed with a call to  LoadBalancerInboundNatRule.UpdateDefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name for the inbound NAT rule.</param>
        /// <return>The first stage of the new inbound NAT rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> DefineInboundNatRule(string name);
    }

    /// <summary>
    /// The stage of the load balancer update allowing to add, remove or modify load balancing rules.
    /// </summary>
    public interface IWithLoadBalancingRule 
    {
        /// <summary>
        /// Begins the definition of a new load balancing rule to add to the load balancer.
        /// </summary>
        /// <param name="name">The name of the load balancing rule.</param>
        /// <return>The first stage of the new load balancing rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> DefineLoadBalancingRule(string name);

        /// <summary>
        /// Removes the specified load balancing rule from the load balancer, if present.
        /// </summary>
        /// <param name="name">The name of the load balancing rule to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithoutLoadBalancingRule(string name);

        /// <summary>
        /// Begins the description of an update to an existing load balancing rule on this load balancer.
        /// </summary>
        /// <param name="name">The name of the load balancing rule to update.</param>
        /// <return>The first stage of the load balancing rule update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update.IUpdate UpdateLoadBalancingRule(string name);
    }

    /// <summary>
    /// The stage of a load balancer update allowing to define, remove or edit Internet-facing frontends.
    /// </summary>
    public interface IWithPublicFrontend 
    {
        /// <summary>
        /// Begins the update of a load balancer frontend.
        /// The definition must be completed with a call to  LoadBalancerPublicFrontend.UpdateDefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name for the frontend.</param>
        /// <return>The first stage of the new frontend definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> DefinePublicFrontend(string name);

        /// <summary>
        /// Removes the specified frontend from the load balancer.
        /// </summary>
        /// <param name="name">The name of an existing front end on this load balancer.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate WithoutFrontend(string name);

        /// <summary>
        /// Begins the description of an update to an existing Internet-facing frontend.
        /// </summary>
        /// <param name="name">The name of the frontend to update.</param>
        /// <return>The first stage of the frontend update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Update.IUpdate UpdatePublicFrontend(string name);
    }

    /// <summary>
    /// The stage of a load balancer update allowing to define one or more private frontends.
    /// </summary>
    public interface IWithPrivateFrontend 
    {
        /// <summary>
        /// Begins the description of an update to an existing internal frontend.
        /// </summary>
        /// <param name="name">The name of an existing frontend from this load balancer.</param>
        /// <return>The first stage of the frontend update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Update.IUpdate UpdatePrivateFrontend(string name);

        /// <summary>
        /// Begins the update of an internal load balancer frontend.
        /// </summary>
        /// <param name="name">The name for the frontend.</param>
        /// <return>The first stage of the new frontend definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update.IUpdate> DefinePrivateFrontend(string name);
    }
}