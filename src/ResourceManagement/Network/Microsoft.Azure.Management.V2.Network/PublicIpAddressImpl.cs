// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition;
    using Microsoft.Azure.Management.Network.Models;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Resource;
    using Management.Network;

    /// <summary>
    /// Implementation for {@link PublicIpAddress} and its create and update interfaces.
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
            IUpdate>,
        IPublicIpAddress,
        IDefinition,
        IUpdate
    {
        private IPublicIPAddressesOperations client;
        internal  PublicIpAddressImpl(
            string name,
            PublicIPAddressInner innerModel,
            IPublicIPAddressesOperations client,
            NetworkManager networkManager) : base(name, innerModel, networkManager)
        {

            //$ PublicIPAddressInner innerModel,
            //$ final PublicIPAddressesInner client,
            //$ final NetworkManager networkManager) {
            //$ super(name, innerModel, networkManager);
            //$ this.client = client;
            //$ }

        }

        public PublicIpAddressImpl WithIdleTimeoutInMinutes (int minutes)
        {

            //$ this.inner().withIdleTimeoutInMinutes(minutes);
            //$ return this;

            return this;
        }

        public PublicIpAddressImpl WithStaticIp ()
        {

            //$ this.inner().withPublicIPAllocationMethod(IPAllocationMethod.STATIC);
            //$ return this;

            return this;
        }

        public PublicIpAddressImpl WithDynamicIp ()
        {

            //$ this.inner().withPublicIPAllocationMethod(IPAllocationMethod.DYNAMIC);
            //$ return this;

            return this;
        }

        public PublicIpAddressImpl WithLeafDomainLabel (string dnsName)
        {

            //$ this.inner().dnsSettings().withDomainNameLabel(dnsName.toLowerCase());
            //$ return this;

            return this;
        }

        public PublicIpAddressImpl WithoutLeafDomainLabel ()
        {

            //$ return this.withLeafDomainLabel(null);

            return this;
        }

        public PublicIpAddressImpl WithReverseFqdn (string reverseFqdn)
        {

            //$ this.inner().dnsSettings().withReverseFqdn(reverseFqdn.toLowerCase());
            //$ return this;

            return this;
        }

        public PublicIpAddressImpl WithoutReverseFqdn ()
        {

            //$ return this.withReverseFqdn(null);

            return this;
        }

        public int? IdleTimeoutInMinutes
        {
            get
            {
            //$ return this.inner().idleTimeoutInMinutes();


                return null;
            }
        }
        public string IpAllocationMethod
        {
            get
            {
            //$ return this.inner().publicIPAllocationMethod();


                return null;
            }
        }
        public string Version
        {
            get
            {
            //$ return this.inner().publicIPAddressVersion();


                return null;
            }
        }
        public string Fqdn
        {
            get
            {
            //$ if (this.inner().dnsSettings() != null) {
            //$ return this.inner().dnsSettings().fqdn();
            //$ } else {
            //$ return null;
            //$ }


                return null;
            }
        }
        public string ReverseFqdn
        {
            get
            {
            //$ if (this.inner().dnsSettings() != null) {
            //$ return this.inner().dnsSettings().reverseFqdn();
            //$ } else {
            //$ return null;
            //$ }


                return null;
            }
        }
        public string IpAddress
        {
            get
            {
            //$ return this.inner().ipAddress();


                return null;
            }
        }
        public string LeafDomainLabel
        {
            get
            {
            //$ if (this.inner().dnsSettings() == null) {
            //$ return null;
            //$ } else {
            //$ return this.inner().dnsSettings().domainNameLabel();
            //$ }


                return null;
            }
        }
        override public async Task<IPublicIpAddress> CreateResourceAsync (
            CancellationToken cancellationToken = default(CancellationToken))
        {

            //$ // Clean up empty DNS settings
            //$ final PublicIPAddressDnsSettings dnsSettings = this.inner().dnsSettings();
            //$ if (dnsSettings != null) {
            //$ if ((dnsSettings.domainNameLabel() == null || dnsSettings.domainNameLabel().isEmpty())
            //$ && (dnsSettings.fqdn() == null || dnsSettings.fqdn().isEmpty())
            //$ && (dnsSettings.reverseFqdn() == null || dnsSettings.reverseFqdn().isEmpty())) {
            //$ this.inner().withDnsSettings(null);
            //$ }
            //$ }
            //$ 
            //$ return this.client.createOrUpdateAsync(this.resourceGroupName(), this.name(), this.inner())
            //$ .map(innerToFluentMap(this));

            return null;
        }

        private bool? EqualsResourceType (string resourceType)
        {

            //$ IPConfigurationInner ipConfig = this.inner().ipConfiguration();
            //$ if (ipConfig == null || resourceType == null) {
            //$ return false;
            //$ } else {
            //$ final String refId = this.inner().ipConfiguration().id();
            //$ final String resourceType2 = ResourceUtils.resourceTypeFromResourceId(refId);
            //$ return resourceType.equalsIgnoreCase(resourceType2);
            //$ }
            //$ }

            return false;
        }

        public bool? HasAssignedLoadBalancer
        {
            get
            {
            //$ return equalsResourceType("frontendIPConfigurations");


                return null;
            }
        }

        public IPublicFrontend GetAssignedLoadBalancerFrontend()
        {

            //$ if (this.hasAssignedLoadBalancer()) {
            //$ final String refId = this.inner().ipConfiguration().id();
            //$ final String loadBalancerId = ResourceUtils.parentResourcePathFromResourceId(refId);
            //$ final LoadBalancer lb = this.myManager.loadBalancers().getById(loadBalancerId);
            //$ final String frontendName = ResourceUtils.nameFromResourceId(refId);
            //$ return (PublicFrontend) lb.frontends().get(frontendName);
            //$ } else {
            //$ return null;
            //$ }

            return null;
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
            //$ return equalsResourceType("ipConfigurations");


                return null;
            }
        }
        public INicIpConfiguration GetAssignedNetworkInterfaceIpConfiguration ()
        {

            //$ if (this.hasAssignedNetworkInterface()) {
            //$ final String refId = this.inner().ipConfiguration().id();
            //$ final String parentId = ResourceUtils.parentResourcePathFromResourceId(refId);
            //$ final NetworkInterface nic = this.myManager.networkInterfaces().getById(parentId);
            //$ final String childName = ResourceUtils.nameFromResourceId(refId);
            //$ return nic.ipConfigurations().get(childName);
            //$ } else {
            //$ return null;
            //$ }

            return null;
        }

    }
}