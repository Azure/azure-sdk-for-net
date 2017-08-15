// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancer.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerBackend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerHttpProbe.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatPool.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerInboundNatRule.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPrivateFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerPublicFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancerTcpProbe.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Definition;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.Update;
    using Microsoft.Azure.Management.Network.Fluent.LoadBalancingRule.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    internal partial class LoadBalancerImpl 
    {
        /// <summary>
        /// Begins the definition of a new inbount NAT pool to add to the load balancer.
        /// The definition must be completed with a call to  LoadBalancerInboundNatPool.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the inbound NAT pool.</param>
        /// <return>The first stage of the new inbound NAT pool definition.</return>
        LoadBalancerInboundNatPool.Definition.IBlank<LoadBalancer.Definition.IWithCreateAndInboundNatPool> LoadBalancer.Definition.IWithInboundNatPool.DefineInboundNatPool(string name)
        {
            return this.DefineInboundNatPool(name) as LoadBalancerInboundNatPool.Definition.IBlank<LoadBalancer.Definition.IWithCreateAndInboundNatPool>;
        }

        /// <summary>
        /// Begins the definition of a new inbound NAT pool.
        /// </summary>
        /// <param name="name">The name of the inbound NAT pool.</param>
        /// <return>The first stage of the new inbound NAT pool definition.</return>
        LoadBalancerInboundNatPool.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate> LoadBalancer.Update.IWithInboundNatPool.DefineInboundNatPool(string name)
        {
            return this.DefineInboundNatPool(name) as LoadBalancerInboundNatPool.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update to an existing inbound NAT pool.
        /// </summary>
        /// <param name="name">The name of the inbound NAT pool to update.</param>
        /// <return>The first stage of the inbound NAT pool update.</return>
        LoadBalancerInboundNatPool.Update.IUpdate LoadBalancer.Update.IWithInboundNatPool.UpdateInboundNatPool(string name)
        {
            return this.UpdateInboundNatPool(name) as LoadBalancerInboundNatPool.Update.IUpdate;
        }

        /// <summary>
        /// Removes the specified inbound NAT pool from the load balancer.
        /// </summary>
        /// <param name="name">The name of an existing inbound NAT pool on this load balancer.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancer.Update.IUpdate LoadBalancer.Update.IWithInboundNatPool.WithoutInboundNatPool(string name)
        {
            return this.WithoutInboundNatPool(name) as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new inbound NAT rule to add to the load balancer.
        /// </summary>
        /// <param name="name">The name of the inbound NAT rule.</param>
        /// <return>The first stage of the new inbound NAT rule definition.</return>
        LoadBalancerInboundNatRule.Definition.IBlank<LoadBalancer.Definition.IWithCreateAndInboundNatRule> LoadBalancer.Definition.IWithInboundNatRule.DefineInboundNatRule(string name)
        {
            return this.DefineInboundNatRule(name) as LoadBalancerInboundNatRule.Definition.IBlank<LoadBalancer.Definition.IWithCreateAndInboundNatRule>;
        }

        /// <summary>
        /// Begins the definition of a new inbound NAT rule.
        /// The definition must be completed with a call to  LoadBalancerInboundNatRule.UpdateDefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name for the inbound NAT rule.</param>
        /// <return>The first stage of the new inbound NAT rule definition.</return>
        LoadBalancerInboundNatRule.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate> LoadBalancer.Update.IWithInboundNatRule.DefineInboundNatRule(string name)
        {
            return this.DefineInboundNatRule(name) as LoadBalancerInboundNatRule.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update to an existing inbound NAT rule.
        /// </summary>
        /// <param name="name">The name of the inbound NAT rule to update.</param>
        /// <return>The first stage of the inbound NAT rule update.</return>
        LoadBalancerInboundNatRule.Update.IUpdate LoadBalancer.Update.IWithInboundNatRule.UpdateInboundNatRule(string name)
        {
            return this.UpdateInboundNatRule(name) as LoadBalancerInboundNatRule.Update.IUpdate;
        }

        /// <summary>
        /// Removes the specified inbound NAT rule from the load balancer.
        /// </summary>
        /// <param name="name">The name of an existing inbound NAT rule on this load balancer.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancer.Update.IUpdate LoadBalancer.Update.IWithInboundNatRule.WithoutInboundNatRule(string name)
        {
            return this.WithoutInboundNatRule(name) as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Begins an explicit definition of a new public (Internet-facing) load balancer frontend.
        /// (Note that frontends can also be created implicitly as part of a load balancing rule,
        /// inbound NAT rule or inbound NAT pool definition, by referencing an existing public IP address within those definitions.).
        /// </summary>
        /// <param name="name">The name for the frontend.</param>
        /// <return>The first stage of a new frontend definition.</return>
        LoadBalancerPublicFrontend.Definition.IBlank<LoadBalancer.Definition.IWithCreate> LoadBalancer.Definition.IWithPublicFrontend.DefinePublicFrontend(string name)
        {
            return this.DefinePublicFrontend(name) as LoadBalancerPublicFrontend.Definition.IBlank<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Begins the update of a load balancer frontend.
        /// The definition must be completed with a call to  LoadBalancerPublicFrontend.UpdateDefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name for the frontend.</param>
        /// <return>The first stage of the new frontend definition.</return>
        LoadBalancerPublicFrontend.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate> LoadBalancer.Update.IWithPublicFrontend.DefinePublicFrontend(string name)
        {
            return this.DefinePublicFrontend(name) as LoadBalancerPublicFrontend.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update to an existing Internet-facing frontend.
        /// </summary>
        /// <param name="name">The name of the frontend to update.</param>
        /// <return>The first stage of the frontend update.</return>
        LoadBalancerPublicFrontend.Update.IUpdate LoadBalancer.Update.IWithPublicFrontend.UpdatePublicFrontend(string name)
        {
            return this.UpdatePublicFrontend(name) as LoadBalancerPublicFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Removes the specified frontend from the load balancer.
        /// </summary>
        /// <param name="name">The name of an existing front end on this load balancer.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancer.Update.IUpdate LoadBalancer.Update.IWithPublicFrontend.WithoutFrontend(string name)
        {
            return this.WithoutFrontend(name) as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Begins an explicit definition of a new private (internal) load balancer frontend.
        /// (Note that private frontends can also be created implicitly as part of a load balancing rule,
        /// inbound NAT rule or inbound NAT pool definition, by referencing an existing subnet within those definitions.).
        /// </summary>
        /// <param name="name">The name for the frontend.</param>
        /// <return>The first stage of a new frontend definition.</return>
        LoadBalancerPrivateFrontend.Definition.IBlank<LoadBalancer.Definition.IWithCreate> LoadBalancer.Definition.IWithPrivateFrontend.DefinePrivateFrontend(string name)
        {
            return this.DefinePrivateFrontend(name) as LoadBalancerPrivateFrontend.Definition.IBlank<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Begins the update of an internal load balancer frontend.
        /// </summary>
        /// <param name="name">The name for the frontend.</param>
        /// <return>The first stage of the new frontend definition.</return>
        LoadBalancerPrivateFrontend.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate> LoadBalancer.Update.IWithPrivateFrontend.DefinePrivateFrontend(string name)
        {
            return this.DefinePrivateFrontend(name) as LoadBalancerPrivateFrontend.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update to an existing internal frontend.
        /// </summary>
        /// <param name="name">The name of an existing frontend from this load balancer.</param>
        /// <return>The first stage of the frontend update.</return>
        LoadBalancerPrivateFrontend.Update.IUpdate LoadBalancer.Update.IWithPrivateFrontend.UpdatePrivateFrontend(string name)
        {
            return this.UpdatePrivateFrontend(name) as LoadBalancerPrivateFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new TCP probe to add to the load balancer.
        /// </summary>
        /// <param name="name">The name of the probe.</param>
        /// <return>The first stage of the new probe definition.</return>
        LoadBalancerTcpProbe.Definition.IBlank<LoadBalancer.Definition.IWithCreate> LoadBalancer.Definition.IWithProbe.DefineTcpProbe(string name)
        {
            return this.DefineTcpProbe(name) as LoadBalancerTcpProbe.Definition.IBlank<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Begins the definition of a new HTTP probe to add to the load balancer.
        /// </summary>
        /// <param name="name">The name of the probe.</param>
        /// <return>The first stage of the new probe definition.</return>
        LoadBalancerHttpProbe.Definition.IBlank<LoadBalancer.Definition.IWithCreate> LoadBalancer.Definition.IWithProbe.DefineHttpProbe(string name)
        {
            return this.DefineHttpProbe(name) as LoadBalancerHttpProbe.Definition.IBlank<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Begins the definition of a new TCP probe to add to the load balancer.
        /// The definition must be completed with a call to  LoadBalancerHttpProbe.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the new probe.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerTcpProbe.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate> LoadBalancer.Update.IWithProbe.DefineTcpProbe(string name)
        {
            return this.DefineTcpProbe(name) as LoadBalancerTcpProbe.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update to an existing HTTP probe on this load balancer.
        /// </summary>
        /// <param name="name">The name of the probe to update.</param>
        /// <return>The first stage of the probe update.</return>
        LoadBalancerHttpProbe.Update.IUpdate LoadBalancer.Update.IWithProbe.UpdateHttpProbe(string name)
        {
            return this.UpdateHttpProbe(name) as LoadBalancerHttpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Removes the specified probe from the load balancer, if present.
        /// </summary>
        /// <param name="name">The name of the probe to remove.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancer.Update.IUpdate LoadBalancer.Update.IWithProbe.WithoutProbe(string name)
        {
            return this.WithoutProbe(name) as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new HTTP probe to add to the load balancer.
        /// The definition must be completed with a call to  LoadBalancerHttpProbe.DefinitionStages.WithAttach.attach().
        /// </summary>
        /// <param name="name">The name of the new probe.</param>
        /// <return>The next stage of the definition.</return>
        LoadBalancerHttpProbe.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate> LoadBalancer.Update.IWithProbe.DefineHttpProbe(string name)
        {
            return this.DefineHttpProbe(name) as LoadBalancerHttpProbe.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update to an existing TCP probe on this load balancer.
        /// </summary>
        /// <param name="name">The name of the probe to update.</param>
        /// <return>The first stage of the probe update.</return>
        LoadBalancerTcpProbe.Update.IUpdate LoadBalancer.Update.IWithProbe.UpdateTcpProbe(string name)
        {
            return this.UpdateTcpProbe(name) as LoadBalancerTcpProbe.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new load balancing rule to add to the load balancer.
        /// </summary>
        /// <param name="name">The name of the load balancing rule.</param>
        /// <return>The first stage of the new load balancing rule definition.</return>
        LoadBalancingRule.Definition.IBlank<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> LoadBalancer.Definition.IWithLoadBalancingRule.DefineLoadBalancingRule(string name)
        {
            return this.DefineLoadBalancingRule(name) as LoadBalancingRule.Definition.IBlank<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>;
        }

        /// <summary>
        /// Removes the specified load balancing rule from the load balancer, if present.
        /// </summary>
        /// <param name="name">The name of the load balancing rule to remove.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancer.Update.IUpdate LoadBalancer.Update.IWithLoadBalancingRule.WithoutLoadBalancingRule(string name)
        {
            return this.WithoutLoadBalancingRule(name) as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new load balancing rule to add to the load balancer.
        /// </summary>
        /// <param name="name">The name of the load balancing rule.</param>
        /// <return>The first stage of the new load balancing rule definition.</return>
        LoadBalancingRule.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate> LoadBalancer.Update.IWithLoadBalancingRule.DefineLoadBalancingRule(string name)
        {
            return this.DefineLoadBalancingRule(name) as LoadBalancingRule.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update to an existing load balancing rule on this load balancer.
        /// </summary>
        /// <param name="name">The name of the load balancing rule to update.</param>
        /// <return>The first stage of the load balancing rule update.</return>
        LoadBalancingRule.Update.IUpdate LoadBalancer.Update.IWithLoadBalancingRule.UpdateLoadBalancingRule(string name)
        {
            return this.UpdateLoadBalancingRule(name) as LoadBalancingRule.Update.IUpdate;
        }

        /// <summary>
        /// Searches for the public frontend that is associated with the provided public IP address, if one exists.
        /// </summary>
        /// <param name="publicIPAddressId">The resource ID of a public IP address to search by.</param>
        /// <return>A public frontend associated with the provided public IP address.</return>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPublicFrontend Microsoft.Azure.Management.Network.Fluent.ILoadBalancer.FindFrontendByPublicIPAddress(string publicIPAddressId)
        {
            return this.FindFrontendByPublicIPAddress(publicIPAddressId) as Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPublicFrontend;
        }

        /// <summary>
        /// Searches for the public frontend that is associated with the provided public IP address, if one exists.
        /// </summary>
        /// <param name="publicIPAddress">A public IP address to search by.</param>
        /// <return>A public frontend associated with the provided public IP address.</return>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPublicFrontend Microsoft.Azure.Management.Network.Fluent.ILoadBalancer.FindFrontendByPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return this.FindFrontendByPublicIPAddress(publicIPAddress) as Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPublicFrontend;
        }

        /// <summary>
        /// Gets inbound NAT pools, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> Microsoft.Azure.Management.Network.Fluent.ILoadBalancer.InboundNatPools
        {
            get
            {
                return this.InboundNatPools() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool>;
            }
        }

        /// <summary>
        /// Gets public (Internet-facing) frontends.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPublicFrontend> Microsoft.Azure.Management.Network.Fluent.ILoadBalancer.PublicFrontends
        {
            get
            {
                return this.PublicFrontends() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPublicFrontend>;
            }
        }

        /// <summary>
        /// Gets private (internal) frontends.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPrivateFrontend> Microsoft.Azure.Management.Network.Fluent.ILoadBalancer.PrivateFrontends
        {
            get
            {
                return this.PrivateFrontends() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPrivateFrontend>;
            }
        }

        /// <summary>
        /// Gets HTTP probes of this load balancer, indexed by the name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerHttpProbe> Microsoft.Azure.Management.Network.Fluent.ILoadBalancer.HttpProbes
        {
            get
            {
                return this.HttpProbes() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerHttpProbe>;
            }
        }

        /// <summary>
        /// Gets resource IDs of the public IP addresses assigned to the frontends of this load balancer.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Network.Fluent.ILoadBalancer.PublicIPAddressIds
        {
            get
            {
                return this.PublicIPAddressIds() as System.Collections.Generic.IReadOnlyList<string>;
            }
        }

        /// <summary>
        /// Gets frontends for this load balancer, for the incoming traffic to come from.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerFrontend> Microsoft.Azure.Management.Network.Fluent.ILoadBalancer.Frontends
        {
            get
            {
                return this.Frontends() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerFrontend>;
            }
        }

        /// <summary>
        /// Gets backends for this load balancer to load balance the incoming traffic among, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> Microsoft.Azure.Management.Network.Fluent.ILoadBalancer.Backends
        {
            get
            {
                return this.Backends() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend>;
            }
        }

        /// <summary>
        /// Gets TCP probes of this load balancer, indexed by the name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerTcpProbe> Microsoft.Azure.Management.Network.Fluent.ILoadBalancer.TcpProbes
        {
            get
            {
                return this.TcpProbes() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerTcpProbe>;
            }
        }

        /// <summary>
        /// Gets inbound NAT rules for this balancer.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatRule> Microsoft.Azure.Management.Network.Fluent.ILoadBalancer.InboundNatRules
        {
            get
            {
                return this.InboundNatRules() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatRule>;
            }
        }

        /// <summary>
        /// Gets the associated load balancing rules from this load balancer, indexed by their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule> Microsoft.Azure.Management.Network.Fluent.IHasLoadBalancingRules.LoadBalancingRules
        {
            get
            {
                return this.LoadBalancingRules() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule>;
            }
        }

        /// <summary>
        /// Starts the definition of a backend.
        /// </summary>
        /// <param name="name">The name to assign to the backend.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancerBackend.Definition.IBlank<LoadBalancer.Definition.IWithCreate> LoadBalancer.Definition.IWithBackend.DefineBackend(string name)
        {
            return this.DefineBackend(name) as LoadBalancerBackend.Definition.IBlank<LoadBalancer.Definition.IWithCreate>;
        }

        /// <summary>
        /// Begins the definition of a new backend as part of this load balancer update.
        /// </summary>
        /// <param name="name">The name for the new backend.</param>
        /// <return>The first stage of the backend definition.</return>
        LoadBalancerBackend.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate> LoadBalancer.Update.IWithBackend.DefineBackend(string name)
        {
            return this.DefineBackend(name) as LoadBalancerBackend.UpdateDefinition.IBlank<LoadBalancer.Update.IUpdate>;
        }

        /// <summary>
        /// Removes the specified backend from the load balancer.
        /// </summary>
        /// <param name="name">The name of the backend to remove.</param>
        /// <return>The next stage of the update.</return>
        LoadBalancer.Update.IUpdate LoadBalancer.Update.IWithBackend.WithoutBackend(string name)
        {
            return this.WithoutBackend(name) as LoadBalancer.Update.IUpdate;
        }

        /// <summary>
        /// Begins the description of an update to an existing backend of this load balancer.
        /// </summary>
        /// <param name="name">The name of the backend to update.</param>
        /// <return>The first stage of the update.</return>
        LoadBalancerBackend.Update.IUpdate LoadBalancer.Update.IWithBackend.UpdateBackend(string name)
        {
            return this.UpdateBackend(name) as LoadBalancerBackend.Update.IUpdate;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.ILoadBalancer>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken) as Microsoft.Azure.Management.Network.Fluent.ILoadBalancer;
        }
    }
}