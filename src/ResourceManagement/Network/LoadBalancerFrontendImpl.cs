// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Collections.Generic;
    using ResourceManager.Fluent.Core.ChildResourceActions;
    using Models;
    using ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Implementation for PublicFrontend.
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTG9hZEJhbGFuY2VyRnJvbnRlbmRJbXBs
    internal partial class LoadBalancerFrontendImpl :
        ChildResource<FrontendIPConfigurationInner, LoadBalancerImpl, ILoadBalancer>,
        ILoadBalancerFrontend,
        ILoadBalancerPrivateFrontend,
        LoadBalancerPrivateFrontend.Definition.IDefinition<LoadBalancer.Definition.IWithCreate>,
        LoadBalancerPrivateFrontend.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        LoadBalancerPrivateFrontend.Update.IUpdate,
        ILoadBalancerPublicFrontend,
        LoadBalancerPublicFrontend.Definition.IDefinition<LoadBalancer.Definition.IWithCreate>,
        LoadBalancerPublicFrontend.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        LoadBalancerPublicFrontend.Update.IUpdate
    {
        
        ///GENMHASH:32D1F31BA9FAB04B1476820FFBDE1B7F:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal LoadBalancerFrontendImpl (FrontendIPConfigurationInner inner, LoadBalancerImpl parent)
            : base(inner, parent)
        {
        }

        
        ///GENMHASH:1C444C90348D7064AB23705C542DDF18:7C10C7860B6E28E6D17CB999015864B9
        internal string NetworkId()
        {
            var subnetRef = Inner.Subnet;
            return (subnetRef != null) ? ResourceUtils.ParentResourcePathFromResourceId(subnetRef.Id) : null;
        }

        
        ///GENMHASH:C57133CD301470A479B3BA07CD283E86:AF6B5F15AE40A0AA08ADA331F3C75492
        internal string SubnetName()
        {
            var subnetRef = Inner.Subnet;
            return (subnetRef != null) ? ResourceUtils.NameFromResourceId(subnetRef.Id) : null;
        }

        
        ///GENMHASH:F4EEE08685E447AE7D2A8F7252EC223A:516B6A004CB15A757AC222DE49CEC6EC
        internal string PrivateIPAddress()
        {
            return Inner.PrivateIPAddress;
        }

        
        ///GENMHASH:FCB784E90DCC27EAC6AD4B4C988E2752:925E8594616C741FD699EF2269B3D731
        internal IPAllocationMethod PrivateIPAllocationMethod()
        {
            return IPAllocationMethod.Parse(Inner.PrivateIPAllocationMethod);
        }

        
        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        
        ///GENMHASH:5EF934D4E2CF202DF23C026435D9F6D6:ABB345FE511A4EDDE90556048D8E5C75
        internal string PublicIPAddressId()
        {
            return Inner.PublicIPAddress.Id;
        }

        
        ///GENMHASH:2911D7234EA1C2B2AC65B607D78B6E4A:38017BCE9C42CC6C34351378D14F8A09
        internal bool IsPublic()
        {
            return Inner.PublicIPAddress != null;
        }

        
        ///GENMHASH:4EDB057B59A7F7BB0C722F8A1399C004:239049AD1BE51FBFCA5EFE2D3D90D634
        internal IReadOnlyDictionary<string, ILoadBalancingRule> LoadBalancingRules ()
        {
            var rules = new Dictionary<string, ILoadBalancingRule>();
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

        
        ///GENMHASH:8A52CACDB59192E1D0B37583E7088612:E06C6AC8649C7D094661074B1621FE5E
        internal IReadOnlyDictionary<string, ILoadBalancerInboundNatPool> InboundNatPools ()
        {
            var pools = new Dictionary<string, ILoadBalancerInboundNatPool>();
            if (Inner.InboundNatPools != null)
            {
                foreach (var innerRef in Inner.InboundNatPools)
                {
                    string name = ResourceUtils.NameFromResourceId(innerRef.Id);
                    ILoadBalancerInboundNatPool pool;
                    if (Parent.InboundNatPools().TryGetValue(name, out pool))
                    {
                        pools[name] = pool;
                    }
                }
            }

            return pools;
        }

        
        ///GENMHASH:E8B1A4CD5F6DE0F12BD4A52F19DDADA3:D324027CACD9F0F14120E933769AE69D
        internal IReadOnlyDictionary<string, ILoadBalancerInboundNatRule> InboundNatRules ()
        {
            var rules = new Dictionary<string, ILoadBalancerInboundNatRule>();
            if (Inner.InboundNatRules != null)
            {
                foreach (var innerRef in Inner.InboundNatRules)
                {
                    string name = ResourceUtils.NameFromResourceId(innerRef.Id);
                    ILoadBalancerInboundNatRule rule;
                    if (Parent.InboundNatRules().TryGetValue(name, out rule))
                    {
                        rules[name] = rule;
                    }
                }
            }

            return rules;
        }

        
        ///GENMHASH:5647899224D30C7B5E1FDCD2D9AAB1DB:F08EFDCC8A8286B3C9226D19B2EA7889
        internal LoadBalancerFrontendImpl WithExistingSubnet (INetwork network, string subnetName)
        {
            return WithExistingSubnet(network.Id, subnetName);
        }

        
        ///GENMHASH:E8683B20FED733D23930E96CCD1EB0A2:E6CC43D15A29B0635E7C303E592E8569
        internal LoadBalancerFrontendImpl WithExistingSubnet (string parentNetworkResourceId, string subnetName)
        {
            Inner.Subnet = new SubResource(parentNetworkResourceId + "/subnets/" + subnetName);
            Inner.PublicIPAddress = null; // Ensure no conflicting public and private settings
            return this;
        }

        
        ///GENMHASH:BE684C4F4845D0C09A9399569DFB7A42:096D95C5168036459198B2B1F15EC515
        internal LoadBalancerFrontendImpl WithExistingPublicIPAddress (IPublicIPAddress pip)
        {
            return WithExistingPublicIPAddress(pip.Id);
        }

        
        ///GENMHASH:3C078CA3D79C59C878B566E6BDD55B86:488D62DEC18443445C34B6C753A0435A
        internal LoadBalancerFrontendImpl WithExistingPublicIPAddress (string resourceId)
        {
            var pipRef = new SubResource(id: resourceId);
            Inner.PublicIPAddress = pipRef;

            // Ensure no conflicting public and private settings
            Inner.Subnet = null;
            Inner.PrivateIPAddress = null;
            Inner.PrivateIPAllocationMethod = null;
            return this;
        }

        
        ///GENMHASH:C4684C8A47F80967DA864E1AB75147B5:2AADFAA8967336A82263A3FD701F270A
        internal LoadBalancerFrontendImpl WithoutPublicIPAddress ()
        {
            Inner.PublicIPAddress = null;
            return this;
        }

        
        ///GENMHASH:26224359DA104EABE1EDF7F491D110F7:75F72179E2B63A55332B5241A9093C17
        internal LoadBalancerFrontendImpl WithPrivateIPAddressDynamic ()
        {
            Inner.PrivateIPAddress = null;
            Inner.PrivateIPAllocationMethod = IPAllocationMethod.Dynamic.ToString();

            // Ensure no conflicting public and private settings
            Inner.PublicIPAddress = null;
            return this;
        }

        
        ///GENMHASH:9946B3475EBD5468D4462F188EEE86C2:C9B470E114F7550FEADF055B40E01B61
        internal LoadBalancerFrontendImpl WithPrivateIPAddressStatic (string ipAddress)
        {
            Inner.PrivateIPAddress = ipAddress;
            Inner.PrivateIPAllocationMethod = IPAllocationMethod.Static.ToString();

            // Ensure no conflicting public and private settings
            Inner.PublicIPAddress = null;
            return this;
        }

        
        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:FE436520410AAD95E2287867567BC278
        internal LoadBalancerImpl Attach ()
        {
            return Parent.WithFrontend(this);
        }

        
        ///GENMHASH:166583FE514624A3D800151836CD57C1:CC312A186A3A88FA6CF6445A4520AE59
        internal IPublicIPAddress GetPublicIPAddress ()
        {
            string pipId = PublicIPAddressId();
            return (pipId != null) ? Parent.Manager.PublicIPAddresses.GetById(pipId) : null;
        }

        
        ///GENMHASH:777AE9B7CB4EA1B471FA1957A07DF81F:447635D831A0A80A464ADA6413BED58F
        internal ISubnet GetSubnet()
        {
            return Parent.Manager.GetAssociatedSubnet(Inner.Subnet);
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            return Parent;
        }

        
        ///GENMHASH:1C505DCDEFCB5F029B7A60E2375286BF:BD825A25E67CC9C2CAF406B471E1375E
        internal LoadBalancerFrontendImpl WithNewPublicIPAddress()
        {
            string dnsLabel = SdkContext.RandomResourceName("fe", 20);
            WithNewPublicIPAddress(dnsLabel);
            return this;
        }

        
        ///GENMHASH:52541ED0C8AE1806DF3F2DF0DE092357:3931F4672B59B1D0BB7EFD5866F5EA54
        internal LoadBalancerFrontendImpl WithNewPublicIPAddress(ICreatable<IPublicIPAddress> creatable)
        {
            Parent.WithNewPublicIPAddress(creatable, Name());
            return this;
        }

        
        ///GENMHASH:233A62609A15DC3B8EB48DD8DB699DDC:D94CE62BB4248EAE4D0375A25DF4B749
        internal LoadBalancerFrontendImpl WithNewPublicIPAddress(string leafDnsLabel)
        {
            Parent.WithNewPublicIPAddress(leafDnsLabel, Name());
            return this;
        }
    }
}
