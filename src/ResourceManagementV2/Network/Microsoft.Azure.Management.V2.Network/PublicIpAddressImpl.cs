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
    public partial class PublicIpAddressImpl  :
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

        internal  PublicIpAddressImpl (string name, PublicIPAddressInner innerModel, IPublicIPAddressesOperations client, INetworkManager networkManager)
            : base(name, innerModel, networkManager)
        {
            this.client = client;
        }


        /// <returns>the assigned reverse FQDN, if any</returns>
        string ReverseFqdn
        {
            get
            {
                return this.Inner.DnsSettings.ReverseFqdn;
            }
        }

        /// <returns>the assigned leaf domain label</returns>
        string LeafDomainLabel
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
        
        /// <returns>the assigned FQDN (fully qualified domain name)</returns>
        string Fqdn
        {
            get
            {
                return this.Inner.DnsSettings.Fqdn;
            }
        }
        
        /// <returns>the idle connection timeout setting (in minutes)</returns>
        int? IdleTimeoutInMinutes
        {
            get
            {
                return this.Inner.IdleTimeoutInMinutes;
            }
        }
        
        /// <returns>the assigned IP address</returns>
        string IpAddress
        {
            get
            {
                return this.Inner.IpAddress;
            }
        }
        
        /// <returns>the IP address allocation method (Static/Dynamic)</returns>
        string IpAllocationMethod
        {
            get
            {
                return this.Inner.PublicIPAllocationMethod;
            }
        }

        /// <summary>
        /// Specifies the reverse FQDN to assign to this public IP address.
        /// </summary>
        /// <param name="reverseFQDN">reverseFQDN the reverse FQDN to assign</param>
        /// <returns>the next stage of the resource update</returns>
        IUpdate WithReverseFqdn(string reverseFQDN)
        {
            this.Inner.DnsSettings.ReverseFqdn = reverseFQDN.ToLower();
            return this;
        }

        /// <summary>
        /// Ensures that no reverse FQDN will be used.
        /// </summary>
        /// <returns>The next stage of the resource update</returns>
        IUpdate WithoutReverseFqdn()
        {
            return ((PublicIpAddress.Update.IWithReverseFQDN)this).WithReverseFqdn(null);
        }

        /// <summary>
        /// Specifies the timeout (in minutes) for an idle connection.
        /// </summary>
        /// <param name="minutes">minutes the length of the time out in minutes</param>
        /// <returns>the next stage of the resource update</returns>
        IUpdate WithIdleTimeoutInMinutes(int minutes)
        {

            this.Inner.IdleTimeoutInMinutes = minutes;
            return this;
        }

        /// <summary>
        /// Ensures that no leaf domain label will be used.
        /// <p>
        /// This means that this public IP address will not be associated with a domain name.
        /// </summary>
        /// <returns>the next stage of the resource update</returns>
        IUpdate WithoutLeafDomainLabel()
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
        IUpdate WithLeafDomainLabel(string dnsName)
        {
            this.Inner.DnsSettings.DomainNameLabel = dnsName.ToLower();
            return this;
        }

        /// <summary>
        /// Enables static IP address allocation.
        /// <p>
        /// Use {@link PublicIpAddress#ipAddress()} after the public IP address is updated to
        /// obtain the actual IP address allocated for this resource by Azure
        /// </summary>
        /// <returns>the next stage of the resource update</returns>
        IUpdate WithStaticIp()
        {
            this.Inner.PublicIPAllocationMethod = IPAllocationMethod.Static;
            return this;
        }

        /// <summary>
        /// Enables dynamic IP address allocation.
        /// </summary>
        /// <returns>the next stage of the resource update</returns>
        IUpdate WithDynamicIp()
        {
            this.Inner.PublicIPAllocationMethod = IPAllocationMethod.Dynamic;
            return this;
        }

        public override IUpdate Update()
        {
            return this;
        }

        public async override Task<IPublicIpAddress> Refresh()
        {
            var response = await client.GetWithHttpMessagesAsync(this.ResourceGroupName,
                this.Inner.Name);
            SetInner(response.Body);
            return this;
        }

        public override async Task<IPublicIpAddress> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // // Clean up empty DNS settings
            var dnsSettings = this.Inner.DnsSettings;
            if (dnsSettings != null)
            {
                if (string.IsNullOrWhiteSpace(dnsSettings.DomainNameLabel)
                && string.IsNullOrWhiteSpace(dnsSettings.Fqdn)
                && string.IsNullOrWhiteSpace(dnsSettings.ReverseFqdn))
                {
                    this.Inner.DnsSettings = null;
                }
            }

            var response = await this.client.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner);
            this.SetInner(response);
            return this;
        }
    }
}