/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update;
    using Microsoft.Rest;
    using System.Threading;
    using Microsoft.Azure.Management.V2.Resource;
    using System.Threading.Tasks;
    using Resource.Core.ResourceActions;
    using System;
    using Management.Network;
    using Resource.Core.Resource.Update;
    using System.Collections.Generic;
    using Resource.Core.GroupableResource.Definition;
    using Resource.Core.Resource.Definition;

    /// <summary>
    /// Implementation for {@link PublicIpAddress} and its create and update interfaces.
    /// </summary>
    /// 
    public class PublicIpAddressImpl  :
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
        private PublicIPAddressInner parameters;

        private string groupName;

        internal  PublicIpAddressImpl (string name, PublicIPAddressInner innerModel, IPublicIPAddressesOperations client, INetworkManager networkManager)
            : base(name, innerModel, networkManager)
        {
            this.client = client;
            this.parameters = new PublicIPAddressInner();
        }


        /// <returns>the assigned reverse FQDN, if any</returns>
        string Microsoft.Azure.Management.V2.Network.IPublicIpAddress.ReverseFqdn
        {
            get
            {
                return this.parameters.DnsSettings.ReverseFqdn;
            }
        }
        
        /// <returns>the assigned leaf domain label</returns>
        string Microsoft.Azure.Management.V2.Network.IPublicIpAddress.LeafDomainLabel
        {
            get
            {
                if (this.parameters.DnsSettings == null)
                {
                    return null;
                }
                else
                {
                    return this.parameters.DnsSettings.DomainNameLabel;
                }
            }
        }
        
        /// <returns>the assigned FQDN (fully qualified domain name)</returns>
        string Microsoft.Azure.Management.V2.Network.IPublicIpAddress.Fqdn
        {
            get
            {
                return this.parameters.DnsSettings.Fqdn;
            }
        }
        
        /// <returns>the idle connection timeout setting (in minutes)</returns>
        int? Microsoft.Azure.Management.V2.Network.IPublicIpAddress.IdleTimeoutInMinutes
        {
            get
            {
                return this.parameters.IdleTimeoutInMinutes;
            }
        }
        
        /// <returns>the assigned IP address</returns>
        string Microsoft.Azure.Management.V2.Network.IPublicIpAddress.IpAddress
        {
            get
            {
                return this.parameters.IpAddress;
            }
        }
        
        /// <returns>the IP address allocation method (Static/Dynamic)</returns>
        string Microsoft.Azure.Management.V2.Network.IPublicIpAddress.IpAllocationMethod
        {
            get
            {
                return this.parameters.PublicIPAllocationMethod;
            }
        }

        /// <summary>
        /// Specifies the reverse FQDN to assign to this public IP address.
        /// </summary>
        /// <param name="reverseFQDN">reverseFQDN the reverse FQDN to assign</param>
        /// <returns>the next stage of the resource update</returns>
        IUpdate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IWithReverseFQDN.WithReverseFqdn(string reverseFQDN)
        {
            this.parameters.DnsSettings.ReverseFqdn = reverseFQDN.ToLower();
            return this;
        }

        /// <summary>
        /// Ensures that no reverse FQDN will be used.
        /// </summary>
        /// <returns>The next stage of the resource update</returns>
        IUpdate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IWithReverseFQDN.WithoutReverseFqdn()
        {
            return ((PublicIpAddress.Update.IWithReverseFQDN)this).WithReverseFqdn(null);
        }

        /// <summary>
        /// Specifies the reverse FQDN to assign to this public IP address.
        /// <p>
        /// </summary>
        /// <param name="reverseFQDN">reverseFQDN the reverse FQDN to assign</param>
        /// <returns>the next stage of the resource definition</returns>
        IWithCreate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithReverseFQDN.WithReverseFqdn(string reverseFQDN)
        {
            this.parameters.DnsSettings.ReverseFqdn = reverseFQDN.ToLower();
            return null;
        }

        /// <summary>
        /// Ensures that no reverse FQDN will be used.
        /// </summary>
        /// <returns>the next stage of the resource definition</returns>
        IWithCreate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithReverseFQDN.WithoutReverseFqdn()
        {

            return ((PublicIpAddress.Definition.IWithReverseFQDN)this).WithReverseFqdn(null);
        }

        /// <summary>
        /// Specifies the timeout (in minutes) for an idle connection.
        /// </summary>
        /// <param name="minutes">minutes the length of the time out in minutes</param>
        /// <returns>the next stage of the resource update</returns>
        IUpdate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IWithIdleTimout.WithIdleTimeoutInMinutes(int minutes)
        {

            this.parameters.IdleTimeoutInMinutes = minutes;
            return this;
        }

        /// <summary>
        /// Ensures that no leaf domain label will be used.
        /// <p>
        /// This means that this public IP address will not be associated with a domain name.
        /// </summary>
        /// <returns>the next stage of the resource update</returns>
        IUpdate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IWithLeafDomainLabel.WithoutLeafDomainLabel()
        {

            return ((PublicIpAddress.Update.IWithLeafDomainLabel)this).WithLeafDomainLabel(null);
        }

        /// <summary>
        /// Specifies the leaf domain label to associate with this public IP address.
        /// <p>
        /// The fully qualified domain name (FQDN)
        /// will be constructed automatically by appending the rest of the domain to this label.
        /// </summary>
        /// <param name="dnsName">dnsName the leaf domain label to use. This must follow the required naming convention for leaf domain names.</param>
        /// <returns>the next stage of the resource update</returns>
        IUpdate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IWithLeafDomainLabel.WithLeafDomainLabel(string dnsName)
        {
            this.parameters.DnsSettings.DomainNameLabel = dnsName.ToLower();
            return this;
        }

        /// <summary>
        /// Ensures that no leaf domain label will be used.
        /// <p>
        /// This means that this public IP address will not be associated with a domain name.
        /// </summary>
        /// <returns>the next stage of the public IP address definition</returns>
        IWithCreate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithLeafDomainLabel.WithoutLeafDomainLabel()
        {
            return ((PublicIpAddress.Definition.IWithLeafDomainLabel)this).WithLeafDomainLabel(null);
        }

        /// <summary>
        /// Specifies the leaf domain label to associate with this public IP address.
        /// <p>
        /// The fully qualified domain name (FQDN)
        /// will be constructed automatically by appending the rest of the domain to this label.
        /// </summary>
        /// <param name="dnsName">dnsName the leaf domain label to use. This must follow the required naming convention for leaf domain names.</param>
        /// <returns>the next stage of the public IP address definition</returns>
        IWithCreate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithLeafDomainLabel.WithLeafDomainLabel(string dnsName)
        {
            this.parameters.DnsSettings.DomainNameLabel = dnsName.ToLower();
            return this;
        }

        /// <summary>
        /// Enables static IP address allocation.
        /// <p>
        /// Use {@link PublicIpAddress#ipAddress()} after the public IP address is updated to
        /// obtain the actual IP address allocated for this resource by Azure
        /// </summary>
        /// <returns>the next stage of the resource update</returns>
        IUpdate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IWithIpAddress.WithStaticIp()
        {
            this.parameters.PublicIPAllocationMethod = IPAllocationMethod.Static;
            return this;
        }

        /// <summary>
        /// Enables dynamic IP address allocation.
        /// </summary>
        /// <returns>the next stage of the resource update</returns>
        IUpdate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IWithIpAddress.WithDynamicIp()
        {
            this.parameters.PublicIPAllocationMethod = IPAllocationMethod.Dynamic;
            return this;
        }

        /// <summary>
        /// Enables static IP address allocation.
        /// <p>
        /// Use {@link PublicIpAddress#ipAddress()} after the public IP address is created to obtain the
        /// actual IP address allocated for this resource by Azure
        /// </summary>
        /// <returns>the next stage of the public IP address definition</returns>
        IWithCreate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithIpAddress.WithStaticIp()
        {
            this.parameters.PublicIPAllocationMethod = IPAllocationMethod.Static;
            return this;
        }

        /// <summary>
        /// Enables dynamic IP address allocation.
        /// </summary>
        /// <returns>the next stage of the public IP address definition</returns>
        IWithCreate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithIpAddress.WithDynamicIp()
        {
            this.parameters.PublicIPAllocationMethod = IPAllocationMethod.Dynamic;
            return this;
        }

        /// <summary>
        /// Specifies the timeout (in minutes) for an idle connection.
        /// </summary>
        /// <param name="minutes">minutes the length of the time out in minutes</param>
        /// <returns>the next stage of the resource definition</returns>
        IWithCreate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithIdleTimeout.WithIdleTimeoutInMinutes(int minutes)
        {
            this.parameters.IdleTimeoutInMinutes = minutes;
            return this;
        }

        public override IUpdate Update()
        {
            this.parameters = new PublicIPAddressInner();
            return this;
        }

        public async override Task<IPublicIpAddress> Refresh()
        {
            var response = await client.GetWithHttpMessagesAsync(this.ResourceGroupName,
                this.parameters.Name);
            SetInner(response.Body);
            return this;
        }

        public override async Task<IPublicIpAddress> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // // Clean up empty DNS settings
            var dnsSettings = this.parameters.DnsSettings;
            if (dnsSettings != null)
            {
                if (string.IsNullOrWhiteSpace(dnsSettings.DomainNameLabel)
                && string.IsNullOrWhiteSpace(dnsSettings.Fqdn)
                && string.IsNullOrWhiteSpace(dnsSettings.ReverseFqdn))
                {
                    this.parameters.DnsSettings = null;
                }
            }

            var response = await this.client.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.parameters);
            return this;
        }
    }
}