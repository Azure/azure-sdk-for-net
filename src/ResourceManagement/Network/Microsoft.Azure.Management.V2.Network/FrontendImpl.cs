// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{
    using System.Collections.Generic;
    using Resource.Core.ChildResourceActions;
    using Management.Network.Models;
    using Resource.Core;
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
        internal  FrontendImpl (FrontendIPConfigurationInner inner, LoadBalancerImpl parent)
            : base(inner.Name, inner, parent)
        {
        }

        public string NetworkId
        {
            get
            {
                var subnetRef = Inner.Subnet;
                return (subnetRef != null) ? ResourceUtils.ParentResourcePathFromResourceId(subnetRef.Id) : null;
            }
        }

        public string SubnetName
        {
            get
            {
                var subnetRef = Inner.Subnet;
                return (subnetRef != null) ? ResourceUtils.NameFromResourceId(subnetRef.Id) : null;
            }
        }

        public string PrivateIpAddress
        {
            get
            {
                return this.Inner.PrivateIPAddress;
            }
        }

        public string PrivateIpAllocationMethod
        {
            get
            {
                return Inner.PrivateIPAllocationMethod;
            }
        }

        override public string Name
        {
            get
            {
                return Inner.Name;
            }
        }

        public string PublicIpAddressId
        {
            get
            {
                return Inner.PublicIPAddress.Id;
            }
        }

        public bool IsPublic
        {
            get
            {
                return Inner.PublicIPAddress != null;
            }
        }

        public IDictionary<string,Microsoft.Azure.Management.V2.Network.ILoadBalancingRule> LoadBalancingRules ()
        {
            IDictionary<string, ILoadBalancingRule> rules = new SortedDictionary<string, ILoadBalancingRule>();
            if(Inner.LoadBalancingRules != null)
            {
                foreach(var innerRef in Inner.LoadBalancingRules)
                {
                    string name = ResourceUtils.NameFromResourceId(innerRef.Id);
                    ILoadBalancingRule rule;
                    Parent.LoadBalancingRules().TryGetValue(name, out rule);
                    if(rule != null)
                    {
                        rules[name] = rule;
                    }
                }
            }

            return rules;
        }

        public IDictionary<string, IInboundNatPool> InboundNatPools ()
        {
            IDictionary<string, IInboundNatPool> pools = new SortedDictionary<string, IInboundNatPool>();
            if (Inner.InboundNatPools != null)
            {
                foreach (var innerRef in Inner.InboundNatPools)
                {
                    string name = ResourceUtils.NameFromResourceId(innerRef.Id);
                    IInboundNatPool pool;
                    Parent.InboundNatPools().TryGetValue(name, out pool);
                    if (pool != null)
                    {
                        pools[name] = pool;
                    }
                }
            }

            return pools;
        }

        public IDictionary<string, IInboundNatRule> InboundNatRules ()
        {
            IDictionary<string, IInboundNatRule> rules = new SortedDictionary<string, IInboundNatRule>();
            if (Inner.InboundNatRules != null)
            {
                foreach (var innerRef in Inner.InboundNatRules)
                {
                    string name = ResourceUtils.NameFromResourceId(innerRef.Id);
                    IInboundNatRule rule;
                    Parent.InboundNatRules().TryGetValue(name, out rule);
                    if (rule != null)
                    {
                        rules[name] = rule;
                    }
                }
            }

            return rules;
        }

        public FrontendImpl WithExistingSubnet (INetwork network, string subnetName)
        {
            return this.WithExistingSubnet(network.Id, subnetName);
        }

        public FrontendImpl WithExistingSubnet (string parentNetworkResourceId, string subnetName)
        {
            var subnetRef = new SubnetInner();
            subnetRef.Id = parentNetworkResourceId + "/subnets/" + subnetName;
            Inner.Subnet = subnetRef;
            Inner.PublicIPAddress = null; // Ensure no conflicting public and private settings
            return this;
        }

        public FrontendImpl WithExistingPublicIpAddress (IPublicIpAddress pip)
        {
            return WithExistingPublicIpAddress(pip.Id);
        }

        public FrontendImpl WithExistingPublicIpAddress (string resourceId)
        {
            var pipRef = new PublicIPAddressInner(id: resourceId);
            Inner.PublicIPAddress = pipRef;

            // Ensure no conflicting public and private settings
            Inner.Subnet = null;
            Inner.PrivateIPAddress = null;
            Inner.PrivateIPAllocationMethod = null;
            return this;
        }

        public FrontendImpl WithoutPublicIpAddress ()
        {
            Inner.PublicIPAddress = null;
            return this;
        }

        public FrontendImpl WithPrivateIpAddressDynamic ()
        {
            Inner.PrivateIPAddress = null;
            Inner.PrivateIPAllocationMethod = IPAllocationMethod.Dynamic;

            // Ensure no conflicting public and private settings
            Inner.PublicIPAddress = null;
            return this;
        }

        public FrontendImpl WithPrivateIpAddressStatic (string ipAddress)
        {
            Inner.PrivateIPAddress = ipAddress;
            Inner.PrivateIPAllocationMethod = IPAllocationMethod.Static;

            // Ensure no conflicting public and private settings
            Inner.PublicIPAddress = null;
            return this;
        }

        public LoadBalancerImpl Attach ()
        {
            return Parent.WithFrontend(this);
        }

        public IPublicIpAddress GetPublicIpAddress ()
        {
            string pipId = PublicIpAddressId;
            return (pipId != null) ? Parent.Manager.PublicIpAddresses.GetById(pipId) : null;
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}