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

        public PublicIpAddressImpl WithIdleTimeoutInMinutes(int minutes)
        {
            this.Inner.IdleTimeoutInMinutes = minutes;
            return this;
        }

        public PublicIpAddressImpl WithStaticIp()
        {

            this.Inner.PublicIPAllocationMethod = IPAllocationMethod.Static;
            return this;
        }

        public PublicIpAddressImpl WithDynamicIp()
        {
            this.Inner.PublicIPAllocationMethod = IPAllocationMethod.Dynamic;
            return this;
        }

        public PublicIpAddressImpl WithLeafDomainLabel(string dnsName)
        {
            this.Inner.DnsSettings.DomainNameLabel = dnsName.ToLower();
            return this;
        }

        public PublicIpAddressImpl WithoutLeafDomainLabel()
        {
            return this.WithLeafDomainLabel(null);
        }

        public PublicIpAddressImpl WithReverseFqdn(string reverseFqdn)
        {
            this.Inner.DnsSettings.ReverseFqdn = reverseFqdn.ToLower();
            return this;
        }

        public PublicIpAddressImpl WithoutReverseFqdn()
        {
            return this.WithReverseFqdn(null);
        }

        public int? IdleTimeoutInMinutes
        {
            get
            {
                return this.Inner.IdleTimeoutInMinutes;
            }
        }

        public string IpAllocationMethod
        {
            get
            {
                return this.Inner.PublicIPAllocationMethod;
            }
        }

        public string Version
        {
            get
            {
                return this.Inner.PublicIPAddressVersion;
            }
        }

        public string Fqdn
        {
            get
            {
                if (this.Inner.DnsSettings != null)
                {
                    return this.Inner.DnsSettings.Fqdn;
                }
                else
                {
                    return null;
                }
            }
        }

        public string ReverseFqdn
        {
            get
            {
                if (this.Inner.DnsSettings != null)
                {
                    return this.Inner.DnsSettings.ReverseFqdn;
                }
                else
                {
                    return null;
                }
            }
        }
        public string IpAddress
        {
            get
            {
                return this.Inner.IpAddress;
            }
        }
        public string LeafDomainLabel
        {
            get
            {
                if (this.Inner.DnsSettings == null)
                {
                    return null;
                }
                else
                {
                    return this.Inner.DnsSettings.DomainNameLabel;
                }
            }
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

            this.SetInner(await this.client.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner));
            return this;
        }

        private bool? EqualsResourceType(string resourceType)
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

        public bool? HasAssignedLoadBalancer
        {
            get
            {
                return EqualsResourceType("frontendIPConfigurations");
            }
        }

        public IPublicFrontend GetAssignedLoadBalancerFrontend()
        {

            if (this.HasAssignedLoadBalancer == true)
            {
                string refId = this.Inner.IpConfiguration.Id;
                string loadBalancerId = ResourceUtils.ParentResourcePathFromResourceId(refId);
                ILoadBalancer lb = this.Manager.LoadBalancers.GetById(loadBalancerId);
                string frontendName = ResourceUtils.NameFromResourceId(refId);
                return (IPublicFrontend)lb.Frontends()[frontendName];
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

        public bool? HasAssignedNetworkInterface
        {
            get
            {
                return EqualsResourceType("ipConfigurations");
            }
        }

        public INicIpConfiguration GetAssignedNetworkInterfaceIpConfiguration()
        {

            if (this.HasAssignedNetworkInterface == true)
            {
                string refId = this.Inner.IpConfiguration.Id;
                string parentId = ResourceUtils.ParentResourcePathFromResourceId(refId);
                INetworkInterface nic = this.Manager.NetworkInterfaces.GetById(parentId);
                string childName = ResourceUtils.NameFromResourceId(refId);
                return nic.IpConfigurations()[childName];
            }
            else
            {
                return null;
            }
        }
    }
}