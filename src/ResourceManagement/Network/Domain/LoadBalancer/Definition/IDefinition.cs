// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition
{
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;

    /// <summary>
    /// The stage of a load balancer definition allowing to create a load balancing rule.
    /// </summary>
    public interface IWithLoadBalancingRule 
    {
        /// <summary>
        /// Begins the definition of a new load balancing rule to add to the load balancer.
        /// </summary>
        /// <param name="name">The name of the load balancing rule.</param>
        /// <return>The first stage of the new load balancing rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> DefineLoadBalancingRule(string name);
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to create the load balancer or start configuring optional inbound NAT rules or pools.
    /// </summary>
    public interface IWithCreateAndNatChoice  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreate,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithInboundNatRule,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithInboundNatPool
    {
    }

    /// <summary>
    /// The stage of an Internet-facing load balancer definition allowing to define one or more public frontends.
    /// </summary>
    public interface IWithPublicFrontend 
    {
        /// <summary>
        /// Begins an explicit definition of a new public (Internet-facing) load balancer frontend.
        /// (Note that frontends can also be created implicitly as part of a load balancing rule,
        /// inbound NAT rule or inbound NAT pool definition, by referencing an existing public IP address within those definitions.).
        /// </summary>
        /// <param name="name">The name for the frontend.</param>
        /// <return>The first stage of a new frontend definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreate> DefinePublicFrontend(string name);
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to add a load blanacing rule, or an inbound NAT rule or pool.
    /// </summary>
    public interface IWithLBRuleOrNat  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRule,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithInboundNatRule,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithInboundNatPool
    {
    }

    /// <summary>
    /// The entirety of the load balancer definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IBlank,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithGroup,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreate,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithBackend,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRule,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLBRuleOrNat,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLBRuleOrNatOrCreate,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatPool,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndNatChoice
    {
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to create the load balancer or add an inbound NAT pool.
    /// </summary>
    public interface IWithCreateAndInboundNatPool  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreate,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithInboundNatPool
    {
    }

    /// <summary>
    /// The stage of a load balancer definition describing the nature of the frontend of the load balancer: internal or Internet-facing.
    /// </summary>
    public interface IWithFrontend  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPublicFrontend,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithPrivateFrontend
    {
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to create a new inbound NAT pool for a virtual machine scale set.
    /// </summary>
    public interface IWithInboundNatPool 
    {
        /// <summary>
        /// Begins the definition of a new inbount NAT pool to add to the load balancer.
        /// The definition must be completed with a call to  LoadBalancerInboundNatPool.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the inbound NAT pool.</param>
        /// <return>The first stage of the new inbound NAT pool definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatPool> DefineInboundNatPool(string name);
    }

    /// <summary>
    /// The first stage of a load balancer definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of the load balancer definition allowing to add a load balancing probe.
    /// </summary>
    public interface IWithProbe 
    {
        /// <summary>
        /// Begins the definition of a new TCP probe to add to the load balancer.
        /// </summary>
        /// <param name="name">The name of the probe.</param>
        /// <return>The first stage of the new probe definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreate> DefineTcpProbe(string name);

        /// <summary>
        /// Begins the definition of a new HTTP probe to add to the load balancer.
        /// </summary>
        /// <param name="name">The name of the probe.</param>
        /// <return>The first stage of the new probe definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreate> DefineHttpProbe(string name);
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to add a backend.
    /// </summary>
    public interface IWithBackend 
    {
        /// <summary>
        /// Starts the definition of a backend.
        /// </summary>
        /// <param name="name">The name to assign to the backend.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreate> DefineBackend(string name);
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to create a load balancing rule or create the load balancer.
    /// </summary>
    public interface IWithLBRuleOrNatOrCreate  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLoadBalancingRule,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndNatChoice
    {
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to create the load balancer or add an inbound NAT rule.
    /// </summary>
    public interface IWithCreateAndInboundNatRule  :
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreate,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithInboundNatRule
    {
    }

    /// <summary>
    /// The stage of a load balancer definition allowing to create a new inbound NAT rule.
    /// </summary>
    public interface IWithInboundNatRule 
    {
        /// <summary>
        /// Begins the definition of a new inbound NAT rule to add to the load balancer.
        /// </summary>
        /// <param name="name">The name of the inbound NAT rule.</param>
        /// <return>The first stage of the new inbound NAT rule definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreateAndInboundNatRule> DefineInboundNatRule(string name);
    }

    /// <summary>
    /// The stage of a load balancer definition containing all the required inputs for
    /// the resource to be created, but also allowing
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreate>,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithBackend,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithFrontend,
        Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithProbe
    {
    }

    /// <summary>
    /// The stage of an internal load balancer definition allowing to define one or more private frontends.
    /// </summary>
    public interface IWithPrivateFrontend 
    {
        /// <summary>
        /// Begins an explicit definition of a new private (internal) load balancer frontend.
        /// (Note that private frontends can also be created implicitly as part of a load balancing rule,
        /// inbound NAT rule or inbound NAT pool definition, by referencing an existing subnet within those definitions.).
        /// </summary>
        /// <param name="name">The name for the frontend.</param>
        /// <return>The first stage of a new frontend definition.</return>
        Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithCreate> DefinePrivateFrontend(string name);
    }

    /// <summary>
    /// The stage of the load balancer definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition.IWithLBRuleOrNat>
    {
    }
}