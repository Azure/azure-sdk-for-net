// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{
    using Management.Network.Models;
    using System.Threading;
    using System.Threading.Tasks;
    using Resource;
    using Management.Network;
    using Resource.Core;

    /// <summary>
    /// Implementation for PublicIpAddress.
    /// </summary>
    public partial class PublicIpAddressImpl :
        GroupableResource<IPublicIpAddress,
            PublicIPAddressInner,
            Rest.Azure.Resource,
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

        internal PublicIpAddressImpl WithIdleTimeoutInMinutes(int minutes)
        {
            this.Inner.IdleTimeoutInMinutes = minutes;
            return this;
        }

        internal PublicIpAddressImpl WithStaticIp()
        {

            this.Inner.PublicIPAllocationMethod = IPAllocationMethod.Static;
            return this;
        }

        internal PublicIpAddressImpl WithDynamicIp()
        {
            this.Inner.PublicIPAllocationMethod = IPAllocationMethod.Dynamic;
            return this;
        }

        internal PublicIpAddressImpl WithLeafDomainLabel(string dnsName)
        {
            this.Inner.DnsSettings.DomainNameLabel = dnsName.ToLower();
            return this;
        }

        internal PublicIpAddressImpl WithoutLeafDomainLabel()
        {
            return this.WithLeafDomainLabel(null);
        }

        internal PublicIpAddressImpl WithReverseFqdn(string reverseFqdn)
        {
            this.Inner.DnsSettings.ReverseFqdn = reverseFqdn.ToLower();
            return this;
        }

        internal PublicIpAddressImpl WithoutReverseFqdn()
        {
            return WithReverseFqdn(null);
        }

        internal int IdleTimeoutInMinutes()
        {
            return (Inner.IdleTimeoutInMinutes.HasValue) ? Inner.IdleTimeoutInMinutes.Value : 0;
        }

        internal string IpAllocationMethod()
        {
            return Inner.PublicIPAllocationMethod;
        }

        internal string Version()
        {
            return Inner.PublicIPAddressVersion;
        }

        internal string Fqdn()
        {
            return (Inner.DnsSettings != null) ? Inner.DnsSettings.Fqdn : null;
        }

        internal string ReverseFqdn()
        {
            return (Inner.DnsSettings != null) ? Inner.DnsSettings.ReverseFqdn : null;
        }

        internal string IpAddress()
        {
            return Inner.IpAddress;
        }

        internal string LeafDomainLabel()
        {
            return (Inner.DnsSettings != null) ? Inner.DnsSettings.DomainNameLabel : null;
        }

        override public async Task<IPublicIpAddress> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            PublicIPAddressDnsSettings dnsSettings = this.Inner.DnsSettings;
            if (dnsSettings != null)
            {
                if (string.IsNullOrWhiteSpace(dnsSettings.DomainNameLabel)
                   && string.IsNullOrWhiteSpace(dnsSettings.Fqdn)
                   && string.IsNullOrWhiteSpace(dnsSettings.ReverseFqdn))
                {
                    this.Inner.DnsSettings = null;
                }
            }

            SetInner(await this.client.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner));
            return this;
        }

        private bool EqualsResourceType(string resourceType)
        {

            IPConfigurationInner ipConfig = this.Inner.IpConfiguration;
            if (ipConfig == null || resourceType == null)
            {
                return false;
            }
            else
            {
                string refId = this.Inner.IpConfiguration.Id;
                string resourceType2 = ResourceUtils.ResourceTypeFromResourceId(refId);
                return resourceType.Equals(resourceType2, System.StringComparison.OrdinalIgnoreCase);
            }
        }

        internal bool HasAssignedLoadBalancer()
        {
            return EqualsResourceType("frontendIPConfigurations");
        }

        internal IPublicFrontend GetAssignedLoadBalancerFrontend()
        {

            if (this.HasAssignedLoadBalancer() == true)
            {
                string refId = this.Inner.IpConfiguration.Id;
                string loadBalancerId = ResourceUtils.ParentResourcePathFromResourceId(refId);
                ILoadBalancer lb = this.Manager.LoadBalancers.GetById(loadBalancerId);
                string frontendName = ResourceUtils.NameFromResourceId(refId);
                return (IPublicFrontend)lb.Frontends[frontendName];
            }
            else
            {
                return null;
            }
        }

        public override IPublicIpAddress Refresh()
        {
            var response = client.Get(this.ResourceGroupName,
                this.Inner.Name);
            SetInner(response);
            return this;
        }

        internal bool HasAssignedNetworkInterface()
        {
            return EqualsResourceType("ipConfigurations");
        }

        internal INicIpConfiguration GetAssignedNetworkInterfaceIpConfiguration()
        {

            if (HasAssignedNetworkInterface())
            {
                string refId = Inner.IpConfiguration.Id;
                string parentId = ResourceUtils.ParentResourcePathFromResourceId(refId);
                INetworkInterface nic = this.Manager.NetworkInterfaces.GetById(parentId);
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