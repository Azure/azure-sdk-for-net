// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;
    using ResourceManager.Fluent;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for PublicIPAddress.
    /// </summary>
    
    internal partial class PublicIPAddressImpl :
        GroupableResource<IPublicIPAddress,
            PublicIPAddressInner,
            PublicIPAddressImpl,
            INetworkManager,
            PublicIPAddress.Definition.IWithGroup,
            PublicIPAddress.Definition.IWithCreate,
            PublicIPAddress.Definition.IWithCreate,
            PublicIPAddress.Update.IUpdate>,
        IPublicIPAddress,
        PublicIPAddress.Definition.IDefinition,
        PublicIPAddress.Update.IUpdate
    {
        
        internal PublicIPAddressImpl(
            string name,
            PublicIPAddressInner innerModel,
            INetworkManager networkManager) : base(name, innerModel, networkManager)
        {
        }

        
        internal PublicIPAddressImpl WithIdleTimeoutInMinutes(int minutes)
        {
            Inner.IdleTimeoutInMinutes = minutes;
            return this;
        }

        
        internal PublicIPAddressImpl WithStaticIP()
        {

            Inner.PublicIPAllocationMethod = Models.IPAllocationMethod.Static.ToString();
            return this;
        }

        
        internal PublicIPAddressImpl WithDynamicIP()
        {
            Inner.PublicIPAllocationMethod = Models.IPAllocationMethod.Dynamic.ToString();
            return this;
        }

        
        internal PublicIPAddressImpl WithLeafDomainLabel(string dnsName)
        {
            Inner.DnsSettings.DomainNameLabel = dnsName.ToLower();
            return this;
        }

        
        internal PublicIPAddressImpl WithoutLeafDomainLabel()
        {
            return WithLeafDomainLabel(null);
        }

        
        internal PublicIPAddressImpl WithReverseFqdn(string reverseFqdn)
        {
            Inner.DnsSettings.ReverseFqdn = reverseFqdn.ToLower();
            return this;
        }

        
        internal PublicIPAddressImpl WithoutReverseFqdn()
        {
            return WithReverseFqdn(null);
        }

        
        internal int IdleTimeoutInMinutes()
        {
            return (Inner.IdleTimeoutInMinutes.HasValue) ? Inner.IdleTimeoutInMinutes.Value : 0;
        }

        
        internal IPAllocationMethod IPAllocationMethod()
        {
            return Models.IPAllocationMethod.Parse(Inner.PublicIPAllocationMethod);
        }

        
        internal IPVersion Version()
        {
            return IPVersion.Parse(Inner.PublicIPAddressVersion);
        }

        
        internal string Fqdn()
        {
            return (Inner.DnsSettings != null) ? Inner.DnsSettings.Fqdn : null;
        }

        
        internal string ReverseFqdn()
        {
            return (Inner.DnsSettings != null) ? Inner.DnsSettings.ReverseFqdn : null;
        }

        
        internal string IPAddress()
        {
            return Inner.IpAddress;
        }

        
        internal string LeafDomainLabel()
        {
            return (Inner.DnsSettings != null) ? Inner.DnsSettings.DomainNameLabel : null;
        }

        
        public async override Task<IPublicIPAddress> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
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

            SetInner(await Manager.Inner.PublicIPAddresses.CreateOrUpdateAsync(ResourceGroupName, Name, Inner, cancellationToken));
            return this;
        }

        
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

        
        internal bool HasAssignedLoadBalancer()
        {
            return EqualsResourceType("frontendIPConfigurations");
        }

        
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

        
        protected override async Task<PublicIPAddressInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.PublicIPAddresses.GetAsync(ResourceGroupName, Name, cancellationToken: cancellationToken);
        }

        
        internal bool HasAssignedNetworkInterface()
        {
            return EqualsResourceType("ipConfigurations");
        }

        
        internal INicIPConfiguration GetAssignedNetworkInterfaceIPConfiguration()
        {
            if (HasAssignedNetworkInterface())
            {
                string refId = Inner.IpConfiguration.Id;
                string parentId = ResourceUtils.ParentResourcePathFromResourceId(refId);
                INetworkInterface nic = Manager.NetworkInterfaces.GetById(parentId);
                string childName = ResourceUtils.NameFromResourceId(refId);
                return nic.IPConfigurations[childName];
            }
            else
            {
                return null;
            }
        }
    }
}
