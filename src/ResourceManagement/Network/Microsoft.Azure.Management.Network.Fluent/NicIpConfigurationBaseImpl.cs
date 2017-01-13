// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Base class implementation for various network interface ip configurations.
    /// </summary>
    /// <typeparam name="ParentImplT">Parent implementation.</typeparam>
    /// <typeparam name="IParentT">Parent interface.</typeparam>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmljSXBDb25maWd1cmF0aW9uQmFzZUltcGw=
    internal partial class NicIpConfigurationBaseImpl<ParentImplT, IParentT> : 
        ChildResource<NetworkInterfaceIPConfigurationInner, ParentImplT, IParentT>
        where ParentImplT : IParentT
    {
        private INetworkManager networkManager;

        ///GENMHASH:32B027E501B0113C8198D01455D7FCE0:56B3D14E72AB91FEE453D95A27DD8E6C
        internal NicIpConfigurationBaseImpl(
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
            return this.Inner.Name;
        }

        ///GENMHASH:8AA9D9D4B919CCB8947405FAA41035E2:FF8C06269C32F184B39DCFD10D8279BF
        internal string PrivateIpAddress()
        {
            return Inner.PrivateIPAddress;
        }

        ///GENMHASH:26736A6ADD939D26955E1B3CFAB3B027:2C25BDFE4E41DBF371885298367C4492
        internal IPAllocationMethod PrivateIpAllocationMethod()
        {
            return IPAllocationMethod.Parse(Inner.PrivateIPAllocationMethod);
        }

        ///GENMHASH:EE78F7961283D288F33B68D99551BF42:2998B7C29D7594E92074D408F4F66760
        internal IPVersion PrivateIpAddressVersion()
        {
            return IPVersion.Parse(Inner.PrivateIPAddressVersion);
        }

        ///GENMHASH:1C444C90348D7064AB23705C542DDF18:AAA4FE3C44C931AA498D248FB062890E
        internal string NetworkId()
        {
            SubResource subnetRef = Inner.Subnet;
            if (subnetRef == null)
            {
                return null;
            }
            return ResourceUtils.ParentResourcePathFromResourceId(subnetRef.Id);
        }

        ///GENMHASH:09E2C45F8481740F588302FB0C7A7C68:EEA5AE07BF27BC623913227E0050ECA2
        internal INetwork GetNetwork()
        {
            string id = this.NetworkId();
            if (id == null)
            {
                return null;
            }
            return this.networkManager.Networks.GetById(id);
        }

        ///GENMHASH:C57133CD301470A479B3BA07CD283E86:CDB148CDC15BCCE466D60D90BEDEA616
        internal string SubnetName()
        {
            SubResource subnetRef = Inner.Subnet;
            if (subnetRef == null)
            {
                return null;
            }
            return ResourceUtils.NameFromResourceId(subnetRef.Id);
        }

        ///GENMHASH:744A3724C9A3248553B33B2939CE091A:47A4EFA20BF9EBE9F94B6AF74FC75F03
        internal IList<ILoadBalancerInboundNatRule> ListAssociatedLoadBalancerInboundNatRules()
        {
            IList<InboundNatRuleInner> inboundNatPoolRefs = Inner.LoadBalancerInboundNatRules;
            if (inboundNatPoolRefs == null)
            {
                return new List<ILoadBalancerInboundNatRule>();
            }

            Dictionary<string, ILoadBalancer> loadBalancers = new Dictionary<string, ILoadBalancer>();
            List<ILoadBalancerInboundNatRule> rules = new List<ILoadBalancerInboundNatRule>();
            foreach (var reference in inboundNatPoolRefs)
            {
                string loadBalancerId = ResourceUtils.ParentResourcePathFromResourceId(reference.Id);
                ILoadBalancer loadBalancer;
                if (!loadBalancers.TryGetValue(loadBalancerId, out loadBalancer))
                {
                    loadBalancer = this.networkManager.LoadBalancers.GetById(loadBalancerId);
                    loadBalancers[loadBalancerId] = loadBalancer;
                }
                string ruleName = ResourceUtils.NameFromResourceId(reference.Id);
                rules.Add(loadBalancer.InboundNatRules[ruleName]);
            }
            return rules;
        }

        ///GENMHASH:D5259819D030517B66106CDFA84D3219:3471F8356719EA5868DD7F34332B58E4
        internal IList<ILoadBalancerBackend> ListAssociatedLoadBalancerBackends()
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
                if (!loadBalancers.TryGetValue(loadBalancerId, out loadBalancer))
                {
                    loadBalancer = this.networkManager.LoadBalancers.GetById(loadBalancerId);
                    loadBalancers[loadBalancerId] = loadBalancer;
                }
                string backendName = ResourceUtils.NameFromResourceId(backendRef.Id);
                ILoadBalancerBackend backend;
                if (loadBalancer.Backends.TryGetValue(backendName, out backend))
                    backends.Add(backend);
            }
            return backends;
        }
    }
}
