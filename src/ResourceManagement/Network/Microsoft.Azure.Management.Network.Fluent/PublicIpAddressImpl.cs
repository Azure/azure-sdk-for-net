// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uUHVibGljSXBBZGRyZXNzSW1wbA==
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;
    using Resource.Fluent;
    using Resource.Fluent.Core;

    /// <summary>
    /// Implementation for PublicIpAddress.
    /// </summary>
    internal partial class PublicIpAddressImpl :
        GroupableResource<IPublicIpAddress,
            PublicIPAddressInner,
            PublicIpAddressImpl,
            INetworkManager,
            PublicIpAddress.Definition.IWithGroup,
            PublicIpAddress.Definition.IWithCreate,
            PublicIpAddress.Definition.IWithCreate,
            PublicIpAddress.Update.IUpdate>,
        IPublicIpAddress,
        PublicIpAddress.Definition.IDefinition,
        PublicIpAddress.Update.IUpdate
    {
        private IPublicIPAddressesOperations client;
        internal PublicIpAddressImpl(
            string name,
            PublicIPAddressInner innerModel,
            IPublicIPAddressesOperations client,
            NetworkManager networkManager) : base(name, innerModel, networkManager)
        {
            this.client = client;
        }

        ///GENMHASH:0268D4A22C553236F2D086625BC961C0:99F3B859668CAC9A1F4A84E29AE2E9C5
        internal PublicIpAddressImpl WithIdleTimeoutInMinutes(int minutes)
        {
            Inner.IdleTimeoutInMinutes = minutes;
            return this;
        }

        ///GENMHASH:0CD165038F68A3526E6D9EB01A127EC0:5DAA827087A429B57970263E396335D1
        internal PublicIpAddressImpl WithStaticIp()
        {

            Inner.PublicIPAllocationMethod = IPAllocationMethod.Static.ToString();
            return this;
        }

        ///GENMHASH:8E7AD9E07B7DB377EA99B37CAD1C93C0:6F94222AD7A6FAA5BDB1F4A8C2336D54
        internal PublicIpAddressImpl WithDynamicIp()
        {
            Inner.PublicIPAllocationMethod = IPAllocationMethod.Dynamic.ToString();
            return this;
        }

        ///GENMHASH:4FD71958F542A872CEE597B1CEA332F8:AB2BC7CCCA80EFA2219ABEAE56789805
        internal PublicIpAddressImpl WithLeafDomainLabel(string dnsName)
        {
            Inner.DnsSettings.DomainNameLabel = dnsName.ToLower();
            return this;
        }

        ///GENMHASH:D0C9704935325DA53D3E18EA383CD798:3A3B2F00929ADB2E5CB95C1ABC9DB961
        internal PublicIpAddressImpl WithoutLeafDomainLabel()
        {
            return WithLeafDomainLabel(null);
        }

        ///GENMHASH:0A9A497E14DD1A2758E52AC9D42D71E4:D54DE8ED5EB6D0455BCE0CD34D01FF08
        internal PublicIpAddressImpl WithReverseFqdn(string reverseFqdn)
        {
            Inner.DnsSettings.ReverseFqdn = reverseFqdn.ToLower();
            return this;
        }

        ///GENMHASH:CC17160998D6B4E37C903F79D511BFF8:41B40BEF775E8DC82AB66ADC6601D69B
        internal PublicIpAddressImpl WithoutReverseFqdn()
        {
            return WithReverseFqdn(null);
        }

        ///GENMHASH:D4505189DA8BE6159A0773DFA0AC5132:069B15B5D06A9F46C25E0C4E96ABB8F0
        internal int IdleTimeoutInMinutes()
        {
            return (Inner.IdleTimeoutInMinutes.HasValue) ? Inner.IdleTimeoutInMinutes.Value : 0;
        }

        ///GENMHASH:7248510394946B110C799F104E023F9D:00D88D2717A616B24525A5934BEBB4F1
        internal string IpAllocationMethod()
        {
            return Inner.PublicIPAllocationMethod;
        }

        ///GENMHASH:493B1EDB88EACA3A476D936362A5B14C:FCE799745FA15D3EA39692B492C8E747
        internal string Version()
        {
            return Inner.PublicIPAddressVersion;
        }

        ///GENMHASH:577F8437932AEC6E08E1A137969BDB4A:DF24BB824B6120C47B7D78874CC08BE4
        internal string Fqdn()
        {
            return (Inner.DnsSettings != null) ? Inner.DnsSettings.Fqdn : null;
        }

        ///GENMHASH:F7F6CD29C046FFE5CC8019B6D29D4C49:00BEC0361DBB94C8C1961479021B2DB0
        internal string ReverseFqdn()
        {
            return (Inner.DnsSettings != null) ? Inner.DnsSettings.ReverseFqdn : null;
        }

        ///GENMHASH:EB9638E8F65D17F5F594E27D773A247D:1F3289A2A9DF010E78AD3BD5B49AA422
        internal string IpAddress()
        {
            return Inner.IpAddress;
        }

        ///GENMHASH:D8227AFFBD25C58BB7DEDE4EE7B555B2:C767F9B041C82EFD9866C5FFB21D93D6
        internal string LeafDomainLabel()
        {
            return (Inner.DnsSettings != null) ? Inner.DnsSettings.DomainNameLabel : null;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:98A779206BCFA2972058346E46E12590
        override public async Task<IPublicIpAddress> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            PublicIPAddressDnsSettings dnsSettings = Inner.DnsSettings;
            if (dnsSettings != null)
            {
                if (string.IsNullOrWhiteSpace(dnsSettings.DomainNameLabel)
                   && string.IsNullOrWhiteSpace(dnsSettings.Fqdn)
                   && string.IsNullOrWhiteSpace(dnsSettings.ReverseFqdn))
                {
                    Inner.DnsSettings = null;
                }
            }

            SetInner(await client.CreateOrUpdateAsync(ResourceGroupName, Name, Inner));
            return this;
        }

        ///GENMHASH:6F4C8A6809867E6F20C204CD3308DA84:5200E97FCE5138CD9DD63AD78E39C256
        private bool EqualsResourceType(string resourceType)
        {

            IPConfigurationInner ipConfig = Inner.IpConfiguration;
            if (ipConfig == null || resourceType == null)
            {
                return false;
            }
            else
            {
                string refId = Inner.IpConfiguration.Id;
                string resourceType2 = ResourceUtils.ResourceTypeFromResourceId(refId);
                return resourceType.Equals(resourceType2, System.StringComparison.OrdinalIgnoreCase);
            }
        }

        ///GENMHASH:CD5A0A8CF5779E1E813F20D0B3CD83F7:EB6216948B7FDAD24F133B42C68DFB59
        internal bool HasAssignedLoadBalancer()
        {
            return EqualsResourceType("frontendIPConfigurations");
        }

        ///GENMHASH:3D00D26E72F1900D476D1ACE8411DAF6:AE59E633CCAEB90CB357B5CFDA9A8D39
        internal ILoadBalancerPublicFrontend GetAssignedLoadBalancerFrontend()
        {
            if (HasAssignedLoadBalancer() == true)
            {
                string refId = Inner.IpConfiguration.Id;
                string loadBalancerId = ResourceUtils.ParentResourcePathFromResourceId(refId);
                ILoadBalancer lb = Manager.LoadBalancers.GetById(loadBalancerId);
                string frontendName = ResourceUtils.NameFromResourceId(refId);
                return (ILoadBalancerPublicFrontend)lb.Frontends[frontendName];
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:46083B525E2D28949C602FA14CD8C6BB
        public override IPublicIpAddress Refresh()
        {
            var response = client.Get(ResourceGroupName, Inner.Name);
            SetInner(response);
            return this;
        }

        ///GENMHASH:7D4EDB8798720C21E834ABC3BEB6E503:C11A523B66806B5E409AF440EE4B612E
        internal bool HasAssignedNetworkInterface()
        {
            return EqualsResourceType("ipConfigurations");
        }

        ///GENMHASH:1DE7D105C62AE4172B59AD39FB7ED47D:71FB3A052B839706E2B1CB9C30A82790
        internal INicIpConfiguration GetAssignedNetworkInterfaceIpConfiguration()
        {
            if (HasAssignedNetworkInterface())
            {
                string refId = Inner.IpConfiguration.Id;
                string parentId = ResourceUtils.ParentResourcePathFromResourceId(refId);
                INetworkInterface nic = Manager.NetworkInterfaces.GetById(parentId);
                string childName = ResourceUtils.NameFromResourceId(refId);
                return nic.IpConfigurations[childName];
            }
            else
            {
                return null;
            }
        }
    }
}
