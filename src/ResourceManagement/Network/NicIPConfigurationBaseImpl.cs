// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmljSVBDb25maWd1cmF0aW9uQmFzZUltcGw=
    /// Base class implementation for various network interface ip configurations.
    /// </summary>
    /// <typeparam name="ParentImplT">Parent implementation.</typeparam>
    /// <typeparam name="IParentT">Parent interface.</typeparam>

    internal partial class NicIPConfigurationBaseImpl<ParentImplT, ParentT> : 
        ChildResource<NetworkInterfaceIPConfigurationInner, ParentImplT, ParentT>,
        INicIPConfigurationBase
        where ParentImplT : ParentT where ParentT : IHasManager<INetworkManager>
    {
        private INetworkManager networkManager;

        
        ///GENMHASH:23C49F051293E5877CB98C4B87F018C8:56B3D14E72AB91FEE453D95A27DD8E6C
        internal NicIPConfigurationBaseImpl(
            NetworkInterfaceIPConfigurationInner inner,
            ParentImplT parent,
            INetworkManager networkManager) : base(inner, parent)
        {
            this.networkManager = networkManager;
        }

        
        ///GENMHASH:492F1C99FDE7AED2307A308B9D148FE6:91EDC35A4F0FB7ED572A844DE6E566E8
        internal bool IsPrimary()
        {
            if (Inner.Primary.HasValue)
            {
                return Inner.Primary.Value;
            }
            return false;
        }

        
        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:A4568D5A538C2116779423E74A62442B
        public override string Name()
        {
            return Inner.Name;
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

        
        ///GENMHASH:572B5A1179A4B2EF64D68C0E25834020:D53CEB54EB83B4CD2AFB7B489DE5E4E6
        internal IPVersion PrivateIPAddressVersion()
        {
            return IPVersion.Parse(Inner.PrivateIPAddressVersion);
        }

        
        ///GENMHASH:09E2C45F8481740F588302FB0C7A7C68:EEA5AE07BF27BC623913227E0050ECA2
        internal INetwork GetNetwork()
        {
            string id = NetworkId();
            return (id != null) ? networkManager.Networks.GetById(id) : null;
        }

        
        ///GENMHASH:C57133CD301470A479B3BA07CD283E86:1F748ABB2BF391EB5FEEFD3546A4C7A8
        internal string SubnetName()
        {
            SubResource subnetRef = Inner.Subnet;
            return (subnetRef != null) ? ResourceUtils.NameFromResourceId(subnetRef.Id) : null;
        }

        
        ///GENMHASH:744A3724C9A3248553B33B2939CE091A:B91782240ED4E9E0E9CD0089AA8E08B6
        internal IReadOnlyList<ILoadBalancerInboundNatRule> ListAssociatedLoadBalancerInboundNatRules()
        {
            var inboundNatPoolRefs = Inner.LoadBalancerInboundNatRules;
            if (inboundNatPoolRefs == null)
            {
                return new List<ILoadBalancerInboundNatRule>();
            }

            var loadBalancers = new Dictionary<string, ILoadBalancer>();
            var rules = new List<ILoadBalancerInboundNatRule>();
            foreach (var reference in inboundNatPoolRefs)
            {
                string loadBalancerId = ResourceUtils.ParentResourcePathFromResourceId(reference.Id);
                ILoadBalancer loadBalancer;
                if (!loadBalancers.TryGetValue(loadBalancerId.ToLower(), out loadBalancer))
                {
                    loadBalancer = this.networkManager.LoadBalancers.GetById(loadBalancerId);
                    loadBalancers[loadBalancerId.ToLower()] = loadBalancer;
                }
                string ruleName = ResourceUtils.NameFromResourceId(reference.Id);
                rules.Add(loadBalancer.InboundNatRules[ruleName]);
            }
            return rules;
        }

        
        ///GENMHASH:D5259819D030517B66106CDFA84D3219:52A28D2529D3E09774E3F4F8685E67EC
        internal IReadOnlyList<ILoadBalancerBackend> ListAssociatedLoadBalancerBackends()
        {
            var backendRefs = Inner.LoadBalancerBackendAddressPools;
            if (backendRefs == null)
            {
                return new List<ILoadBalancerBackend>();
            }

            var loadBalancers = new Dictionary<string, ILoadBalancer>();
            var backends = new List<ILoadBalancerBackend>();
            foreach (BackendAddressPoolInner backendRef in backendRefs)
            {
                string loadBalancerId = ResourceUtils.ParentResourcePathFromResourceId(backendRef.Id);
                ILoadBalancer loadBalancer;
                if (!loadBalancers.TryGetValue(loadBalancerId.ToLower(), out loadBalancer))
                {
                    loadBalancer = networkManager.LoadBalancers.GetById(loadBalancerId);
                    loadBalancers[loadBalancerId.ToLower()] = loadBalancer;
                }
                string backendName = ResourceUtils.NameFromResourceId(backendRef.Id);
                ILoadBalancerBackend backend;
                if (loadBalancer.Backends.TryGetValue(backendName, out backend))
                    backends.Add(backend);
            }
            return backends;
        }

        
        ///GENMHASH:1C444C90348D7064AB23705C542DDF18:AAA4FE3C44C931AA498D248FB062890E
        internal string NetworkId()
        {
            SubResource subnetRef = Inner.Subnet;
            return (subnetRef != null) ? ResourceUtils.ParentResourcePathFromResourceId(subnetRef.Id) : null;
        }


        
        ///GENMHASH:2E4015B29759BBD97527EBAE809B083C:91A166D41391DA35AAD7B2223B2992C5
        public INetworkSecurityGroup GetNetworkSecurityGroup()
        {
            INetwork network = this.GetNetwork();
            if (network == null)
            {
                return null;
            }
            
            string subnetName = SubnetName();
            if (subnetName == null)
            {
                return null;
            }

            ISubnet subnet;
            if(network.Subnets.TryGetValue(subnetName, out subnet))
            {
                return subnet.GetNetworkSecurityGroup();
            }
            else
            {
                return null;
            }
        }

        
        ///GENMHASH:AB4065B8BA3CBEBBFE2194997931C513:9F5EC22819D02223DAAD78B94E1B5130
        public IReadOnlyList<IApplicationGatewayBackend> ListAssociatedApplicationGatewayBackends()
        {
            //return ((NetworkManager)Parent.Manager).ListAssociatedApplicationGatewayBackends(Inner.ApplicationGatewayBackendAddressPools);

            IDictionary<string, IApplicationGateway> appGateways = new Dictionary<string, IApplicationGateway>();
            List<IApplicationGatewayBackend> backends = new List<IApplicationGatewayBackend>();
            var backendRefs = Inner.ApplicationGatewayBackendAddressPools;
            if (backendRefs != null)
            {
                foreach (var backendRef in backendRefs)
                {
                    string appGatewayId = ResourceUtils.ParentResourcePathFromResourceId(backendRef.Id);
                    IApplicationGateway appGateway;
                    if (!appGateways.TryGetValue(appGatewayId.ToLower(), out appGateway))
                    {
                        appGateway = Parent.Manager.ApplicationGateways.GetById(appGatewayId);
                        appGateways[appGatewayId.ToLower()] = appGateway;
                    }

                    string backendName = ResourceUtils.NameFromResourceId(backendRef.Id);
                    IApplicationGatewayBackend backend = null;
                    if (appGateway.Backends.TryGetValue(backendName, out backend))
                    {
                        backends.Add(backend);
                    }
                }
            }
            return backends;
        }
    }
}
