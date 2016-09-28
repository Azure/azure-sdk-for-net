// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Network.PublicFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.PrivateFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.LoadBalancer.Update;
    using Microsoft.Azure.Management.V2.Network.HasPrivateIpAddress.Definition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResourceActions;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Network.PrivateFrontend.Update;
    using Microsoft.Azure.Management.V2.Network.PrivateFrontend.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Network.PublicFrontend.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.HasSubnet.Definition;
    using Microsoft.Azure.Management.V2.Network.HasPublicIpAddress.Definition;
    using Microsoft.Azure.Management.V2.Network.HasPrivateIpAddress.Update;
    using Microsoft.Azure.Management.V2.Network.HasPublicIpAddress.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition;
    using Microsoft.Azure.Management.V2.Network.HasPrivateIpAddress.UpdateDefinition;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.V2.Network.PublicFrontend.Definition;
    using Microsoft.Azure.Management.V2.Network.HasPublicIpAddress.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update;
    using System;

    /// <summary>
    /// Implementation for {@link PublicFrontend}.
    /// </summary>
    public partial class FrontendImpl  :
        ChildResource<Microsoft.Azure.Management.Network.Models.FrontendIPConfigurationInner,Microsoft.Azure.Management.V2.Network.LoadBalancerImpl,Microsoft.Azure.Management.V2.Network.ILoadBalancer>,
        IFrontend,
        IPrivateFrontend,
        Microsoft.Azure.Management.V2.Network.PrivateFrontend.Definition.IDefinition<Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition.IWithPrivateFrontendOrBackend>,
        Microsoft.Azure.Management.V2.Network.PrivateFrontend.UpdateDefinition.IUpdateDefinition<Microsoft.Azure.Management.V2.Network.LoadBalancer.Update.IUpdate>,
        Microsoft.Azure.Management.V2.Network.PrivateFrontend.Update.IUpdate,
        IPublicFrontend,
        Microsoft.Azure.Management.V2.Network.PublicFrontend.Definition.IDefinition<Microsoft.Azure.Management.V2.Network.LoadBalancer.Definition.IWithPublicFrontendOrBackend>,
        Microsoft.Azure.Management.V2.Network.PublicFrontend.UpdateDefinition.IUpdateDefinition<Microsoft.Azure.Management.V2.Network.LoadBalancer.Update.IUpdate>,
        Microsoft.Azure.Management.V2.Network.PublicFrontend.Update.IUpdate
    {
        protected  FrontendImpl (FrontendIPConfigurationInner inner, LoadBalancerImpl parent) : base(inner.Name, inner, parent)
        {

            //$ super(inner, parent);
            //$ }

        }

        public string NetworkId
        {
            get
            {
            //$ SubResource subnetRef = this.inner().subnet();
            //$ if (subnetRef != null) {
            //$ return ResourceUtils.parentResourcePathFromResourceId(subnetRef.id());
            //$ } else {
            //$ return null;
            //$ }


                return null;
            }
        }
        public string SubnetName
        {
            get
            {
            //$ SubResource subnetRef = this.inner().subnet();
            //$ if (subnetRef != null) {
            //$ return ResourceUtils.nameFromResourceId(subnetRef.id());
            //$ } else {
            //$ return null;
            //$ }


                return null;
            }
        }
        public string PrivateIpAddress
        {
            get
            {
            //$ return this.inner().privateIPAddress();


                return null;
            }
        }
        public string PrivateIpAllocationMethod
        {
            get
            {
            //$ return this.inner().privateIPAllocationMethod();


                return null;
            }
        }
        override public string Name
        {
            get
            {
            //$ return this.inner().name();


                return null;
            }
        }
        public string PublicIpAddressId
        {
            get
            {
            //$ return this.inner().publicIPAddress().id();


                return null;
            }
        }
        public bool? IsPublic
        {
            get
            {
            //$ return (this.inner().publicIPAddress() != null);


                return null;
            }
        }
        public IDictionary<string,Microsoft.Azure.Management.V2.Network.ILoadBalancingRule> LoadBalancingRules ()
        {

            //$ final Map<String, LoadBalancingRule> rules = new TreeMap<>();
            //$ if (this.inner().loadBalancingRules() != null) {
            //$ for (SubResource innerRef : this.inner().loadBalancingRules()) {
            //$ String name = ResourceUtils.nameFromResourceId(innerRef.id());
            //$ LoadBalancingRule rule = this.parent().loadBalancingRules().get(name);
            //$ if (rule != null) {
            //$ rules.put(name, rule);
            //$ }
            //$ }
            //$ }
            //$ 
            //$ return Collections.unmodifiableMap(rules);

            return null;
        }

        public IDictionary<string,Microsoft.Azure.Management.V2.Network.IInboundNatPool> InboundNatPools ()
        {

            //$ final Map<String, InboundNatPool> pools = new TreeMap<>();
            //$ if (this.inner().inboundNatPools() != null) {
            //$ for (SubResource innerRef : this.inner().inboundNatPools()) {
            //$ String name = ResourceUtils.nameFromResourceId(innerRef.id());
            //$ InboundNatPool pool = this.parent().inboundNatPools().get(name);
            //$ if (pool != null) {
            //$ pools.put(name, pool);
            //$ }
            //$ }
            //$ }
            //$ 
            //$ return Collections.unmodifiableMap(pools);

            return null;
        }

        public IDictionary<string,Microsoft.Azure.Management.V2.Network.IInboundNatRule> InboundNatRules ()
        {

            //$ final Map<String, InboundNatRule> rules = new TreeMap<>();
            //$ if (this.inner().inboundNatRules() != null) {
            //$ for (SubResource innerRef : this.inner().inboundNatRules()) {
            //$ String name = ResourceUtils.nameFromResourceId(innerRef.id());
            //$ InboundNatRule rule = this.parent().inboundNatRules().get(name);
            //$ if (rule != null) {
            //$ rules.put(name, rule);
            //$ }
            //$ }
            //$ }
            //$ 
            //$ return Collections.unmodifiableMap(rules);

            return null;
        }

        public FrontendImpl WithExistingSubnet (INetwork network, string subnetName)
        {

            //$ return this.withExistingSubnet(network.id(), subnetName);

            return this;
        }

        public FrontendImpl WithExistingSubnet (string parentNetworkResourceId, string subnetName)
        {

            //$ SubResource subnetRef = new SubResource()
            //$ .withId(parentNetworkResourceId + "/subnets/" + subnetName);
            //$ this.inner()
            //$ .withSubnet(subnetRef)
            //$ .withPublicIPAddress(null); // Ensure no conflicting public and private settings
            //$ return this;

            return this;
        }

        public FrontendImpl WithExistingPublicIpAddress (IPublicIpAddress pip)
        {

            //$ return this.withExistingPublicIpAddress(pip.id());

            return this;
        }

        public FrontendImpl WithExistingPublicIpAddress (string resourceId)
        {

            //$ SubResource pipRef = new SubResource().withId(resourceId);
            //$ this.inner()
            //$ .withPublicIPAddress(pipRef)
            //$ 
            //$ // Ensure no conflicting public and private settings
            //$ .withSubnet(null)
            //$ .withPrivateIPAddress(null)
            //$ .withPrivateIPAllocationMethod(null);
            //$ return this;

            return this;
        }

        public FrontendImpl WithoutPublicIpAddress ()
        {

            //$ this.inner().withPublicIPAddress(null);
            //$ return this;

            return this;
        }

        public FrontendImpl WithPrivateIpAddressDynamic ()
        {

            //$ this.inner()
            //$ .withPrivateIPAddress(null)
            //$ .withPrivateIPAllocationMethod(IPAllocationMethod.DYNAMIC)
            //$ 
            //$ // Ensure no conflicting public and private settings
            //$ .withPublicIPAddress(null);
            //$ return this;

            return this;
        }

        public FrontendImpl WithPrivateIpAddressStatic (string ipAddress)
        {

            //$ this.inner()
            //$ .withPrivateIPAddress(ipAddress)
            //$ .withPrivateIPAllocationMethod(IPAllocationMethod.STATIC)
            //$ 
            //$ // Ensure no conflicting public and private settings
            //$ .withPublicIPAddress(null);
            //$ return this;

            return this;
        }

        public LoadBalancerImpl Attach ()
        {

            //$ return this.parent().withFrontend(this);

            return null;
        }

        public IPublicIpAddress GetPublicIpAddress ()
        {

            //$ final String pipId = this.publicIpAddressId();
            //$ if (pipId == null) {
            //$ return null;
            //$ } else {
            //$ return this.parent().manager().publicIpAddresses().getById(pipId);
            //$ }

            return null;
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            throw new NotImplementedException();
        }
    }
}