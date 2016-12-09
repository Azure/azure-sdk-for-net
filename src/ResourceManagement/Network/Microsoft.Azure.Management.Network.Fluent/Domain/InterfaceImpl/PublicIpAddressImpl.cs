// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using PublicIpAddress.Definition;
    using PublicIpAddress.Update;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    public partial class PublicIpAddressImpl
    {
        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress;
        }

        string Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.ReverseFqdn
        {
            get
            {
                return this.ReverseFqdn();
            }
        }

        bool Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.HasAssignedNetworkInterface
        {
            get
            {
                return this.HasAssignedNetworkInterface();
            }
        }

        string Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.Version
        {
            get
            {
                return this.Version();
            }
        }

        string Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.LeafDomainLabel
        {
            get
            {
                return this.LeafDomainLabel();
            }
        }

        string Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.Fqdn
        {
            get
            {
                return this.Fqdn();
            }
        }

        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPublicFrontend Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.GetAssignedLoadBalancerFrontend()
        {
            return this.GetAssignedLoadBalancerFrontend() as Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPublicFrontend;
        }

        bool Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.HasAssignedLoadBalancer
        {
            get
            {
                return this.HasAssignedLoadBalancer();
            }
        }

        int Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.IdleTimeoutInMinutes
        {
            get
            {
                return this.IdleTimeoutInMinutes();
            }
        }

        Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.GetAssignedNetworkInterfaceIpConfiguration()
        {
            return this.GetAssignedNetworkInterfaceIpConfiguration() as Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration;
        }

        string Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.IpAddress
        {
            get
            {
                return this.IpAddress();
            }
        }

        string Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.IpAllocationMethod
        {
            get
            {
                return this.IpAllocationMethod();
            }
        }

        /// <summary>
        /// Specifies the reverse FQDN to assign to this public IP address.
        /// </summary>
        /// <param name="reverseFQDN">The reverse FQDN to assign.</param>
        PublicIpAddress.Update.IUpdate PublicIpAddress.Update.IWithReverseFQDN.WithReverseFqdn(string reverseFQDN)
        {
            return this.WithReverseFqdn(reverseFQDN) as PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Ensures that no reverse FQDN will be used.
        /// </summary>
        PublicIpAddress.Update.IUpdate PublicIpAddress.Update.IWithReverseFQDN.WithoutReverseFqdn()
        {
            return this.WithoutReverseFqdn() as PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the reverse FQDN to assign to this public IP address.
        /// <p>.
        /// </summary>
        /// <param name="reverseFQDN">The reverse FQDN to assign.</param>
        PublicIpAddress.Definition.IWithCreate PublicIpAddress.Definition.IWithReverseFQDN.WithReverseFqdn(string reverseFQDN)
        {
            return this.WithReverseFqdn(reverseFQDN) as PublicIpAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Ensures that no reverse FQDN will be used.
        /// </summary>
        PublicIpAddress.Definition.IWithCreate PublicIpAddress.Definition.IWithReverseFQDN.WithoutReverseFqdn()
        {
            return this.WithoutReverseFqdn() as PublicIpAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the timeout (in minutes) for an idle connection.
        /// </summary>
        /// <param name="minutes">The length of the time out in minutes.</param>
        PublicIpAddress.Update.IUpdate PublicIpAddress.Update.IWithIdleTimout.WithIdleTimeoutInMinutes(int minutes)
        {
            return this.WithIdleTimeoutInMinutes(minutes) as PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Ensures that no leaf domain label will be used.
        /// <p>
        /// This means that this public IP address will not be associated with a domain name.
        /// </summary>
        PublicIpAddress.Update.IUpdate PublicIpAddress.Update.IWithLeafDomainLabel.WithoutLeafDomainLabel()
        {
            return this.WithoutLeafDomainLabel() as PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the leaf domain label to associate with this public IP address.
        /// <p>
        /// The fully qualified domain name (FQDN)
        /// will be constructed automatically by appending the rest of the domain to this label.
        /// </summary>
        /// <param name="dnsName">The leaf domain label to use. This must follow the required naming convention for leaf domain names.</param>
        PublicIpAddress.Update.IUpdate PublicIpAddress.Update.IWithLeafDomainLabel.WithLeafDomainLabel(string dnsName)
        {
            return this.WithLeafDomainLabel(dnsName) as PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Ensures that no leaf domain label will be used.
        /// <p>
        /// This means that this public IP address will not be associated with a domain name.
        /// </summary>
        PublicIpAddress.Definition.IWithCreate PublicIpAddress.Definition.IWithLeafDomainLabel.WithoutLeafDomainLabel()
        {
            return this.WithoutLeafDomainLabel() as PublicIpAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the leaf domain label to associate with this public IP address.
        /// <p>
        /// The fully qualified domain name (FQDN)
        /// will be constructed automatically by appending the rest of the domain to this label.
        /// </summary>
        /// <param name="dnsName">The leaf domain label to use. This must follow the required naming convention for leaf domain names.</param>
        PublicIpAddress.Definition.IWithCreate PublicIpAddress.Definition.IWithLeafDomainLabel.WithLeafDomainLabel(string dnsName)
        {
            return this.WithLeafDomainLabel(dnsName) as PublicIpAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables static IP address allocation.
        /// <p>
        /// Use PublicIpAddress.ipAddress() after the public IP address is updated to
        /// obtain the actual IP address allocated for this resource by Azure.
        /// </summary>
        PublicIpAddress.Update.IUpdate PublicIpAddress.Update.IWithIpAddress.WithStaticIp()
        {
            return this.WithStaticIp() as PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Enables dynamic IP address allocation.
        /// </summary>
        PublicIpAddress.Update.IUpdate PublicIpAddress.Update.IWithIpAddress.WithDynamicIp()
        {
            return this.WithDynamicIp() as PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Enables static IP address allocation.
        /// <p>
        /// Use PublicIpAddress.ipAddress() after the public IP address is created to obtain the
        /// actual IP address allocated for this resource by Azure.
        /// </summary>
        PublicIpAddress.Definition.IWithCreate PublicIpAddress.Definition.IWithIpAddress.WithStaticIp()
        {
            return this.WithStaticIp() as PublicIpAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables dynamic IP address allocation.
        /// </summary>
        PublicIpAddress.Definition.IWithCreate PublicIpAddress.Definition.IWithIpAddress.WithDynamicIp()
        {
            return this.WithDynamicIp() as PublicIpAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the timeout (in minutes) for an idle connection.
        /// </summary>
        /// <param name="minutes">The length of the time out in minutes.</param>
        PublicIpAddress.Definition.IWithCreate PublicIpAddress.Definition.IWithIdleTimeout.WithIdleTimeoutInMinutes(int minutes)
        {
            return this.WithIdleTimeoutInMinutes(minutes) as PublicIpAddress.Definition.IWithCreate;
        }
    }
}