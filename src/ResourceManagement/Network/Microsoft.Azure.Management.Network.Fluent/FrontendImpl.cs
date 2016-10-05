// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Collections.Generic;
    using Resource.Fluent.Core.ChildResourceActions;
    using Management.Network.Fluent.Models;
    using Resource.Fluent.Core;
    using System;

    /// <summary>
    /// Implementation for PublicFrontend.
    /// </summary>
    public partial class FrontendImpl  :
        ChildResource<FrontendIPConfigurationInner, LoadBalancerImpl, ILoadBalancer>,
        IFrontend,
        IPrivateFrontend,
        PrivateFrontend.Definition.IDefinition<LoadBalancer.Definition.IWithPrivateFrontendOrBackend>,
        PrivateFrontend.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        PrivateFrontend.Update.IUpdate,
        IPublicFrontend,
        PublicFrontend.Definition.IDefinition<LoadBalancer.Definition.IWithPublicFrontendOrBackend>,
        PublicFrontend.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        PublicFrontend.Update.IUpdate
    {
        //$TODO: For some reason the converter doesn't implement this on the auto-gen'd interface implementations so putting it here for the time being
        string IHasPrivateIpAddress.PrivateIpAllocationMethod
        {
            get
            {
                return PrivateIpAllocationMethod();
            }
        }

        internal FrontendImpl (FrontendIPConfigurationInner inner, LoadBalancerImpl parent)
            : base(inner, parent)
        {
        }

        internal string NetworkId()
        {
            var subnetRef = Inner.Subnet;
            return (subnetRef != null) ? ResourceUtils.ParentResourcePathFromResourceId(subnetRef.Id) : null;
        }

        internal string SubnetName()
        {
            var subnetRef = Inner.Subnet;
            return (subnetRef != null) ? ResourceUtils.NameFromResourceId(subnetRef.Id) : null;
        }

        internal string PrivateIpAddress()
        {
            return Inner.PrivateIPAddress;
        }

        internal string PrivateIpAllocationMethod()
        {
            return Inner.PrivateIPAllocationMethod;
        }

        public override string Name()
        {
            return Inner.Name;
        }

        internal string PublicIpAddressId()
        {
            return Inner.PublicIPAddress.Id;
        }

        internal bool IsPublic()
        {
            return Inner.PublicIPAddress != null;
        }

        internal IDictionary<string,Microsoft.Azure.Management.Network.Fluent.ILoadBalancingRule> LoadBalancingRules ()
        {
            IDictionary<string, ILoadBalancingRule> rules = new SortedDictionary<string, ILoadBalancingRule>();
            if(Inner.LoadBalancingRules != null)
            {
                foreach(var innerRef in Inner.LoadBalancingRules)
                {
                    string name = ResourceUtils.NameFromResourceId(innerRef.Id);
                    ILoadBalancingRule rule;
                    if(Parent.LoadBalancingRules().TryGetValue(name, out rule))
                        rules[name] = rule;
                }
            }

            return rules;
        }

        internal IDictionary<string, IInboundNatPool> InboundNatPools ()
        {
            IDictionary<string, IInboundNatPool> pools = new SortedDictionary<string, IInboundNatPool>();
            if (Inner.InboundNatPools != null)
            {
                foreach (var innerRef in Inner.InboundNatPools)
                {
                    string name = ResourceUtils.NameFromResourceId(innerRef.Id);
                    IInboundNatPool pool;
                    if (Parent.InboundNatPools().TryGetValue(name, out pool))
                    {
                        pools[name] = pool;
                    }
                }
            }

            return pools;
        }

        internal IDictionary<string, IInboundNatRule> InboundNatRules ()
        {
            IDictionary<string, IInboundNatRule> rules = new SortedDictionary<string, IInboundNatRule>();
            if (Inner.InboundNatRules != null)
            {
                foreach (var innerRef in Inner.InboundNatRules)
                {
                    string name = ResourceUtils.NameFromResourceId(innerRef.Id);
                    IInboundNatRule rule;
                    if (Parent.InboundNatRules().TryGetValue(name, out rule))
                    {
                        rules[name] = rule;
                    }
                }
            }

            return rules;
        }

        internal FrontendImpl WithExistingSubnet (INetwork network, string subnetName)
        {
            return this.WithExistingSubnet(network.Id, subnetName);
        }

        internal FrontendImpl WithExistingSubnet (string parentNetworkResourceId, string subnetName)
        {
            var subnetRef = new SubnetInner();
            subnetRef.Id = parentNetworkResourceId + "/subnets/" + subnetName;
            Inner.Subnet = subnetRef;
            Inner.PublicIPAddress = null; // Ensure no conflicting public and private settings
            return this;
        }

        internal FrontendImpl WithExistingPublicIpAddress (IPublicIpAddress pip)
        {
            return WithExistingPublicIpAddress(pip.Id);
        }

        internal FrontendImpl WithExistingPublicIpAddress (string resourceId)
        {
            var pipRef = new PublicIPAddressInner(id: resourceId);
            Inner.PublicIPAddress = pipRef;

            // Ensure no conflicting public and private settings
            Inner.Subnet = null;
            Inner.PrivateIPAddress = null;
            Inner.PrivateIPAllocationMethod = null;
            return this;
        }

        internal FrontendImpl WithoutPublicIpAddress ()
        {
            Inner.PublicIPAddress = null;
            return this;
        }

        internal FrontendImpl WithPrivateIpAddressDynamic ()
        {
            Inner.PrivateIPAddress = null;
            Inner.PrivateIPAllocationMethod = IPAllocationMethod.Dynamic;

            // Ensure no conflicting public and private settings
            Inner.PublicIPAddress = null;
            return this;
        }

        internal FrontendImpl WithPrivateIpAddressStatic (string ipAddress)
        {
            Inner.PrivateIPAddress = ipAddress;
            Inner.PrivateIPAllocationMethod = IPAllocationMethod.Static;

            // Ensure no conflicting public and private settings
            Inner.PublicIPAddress = null;
            return this;
        }

        internal LoadBalancerImpl Attach ()
        {
            return Parent.WithFrontend(this);
        }

        internal IPublicIpAddress GetPublicIpAddress ()
        {
            string pipId = PublicIpAddressId();
            return (pipId != null) ? Parent.Manager.PublicIpAddresses.GetById(pipId) : null;
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}