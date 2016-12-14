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

    internal partial class PublicIpAddressImpl 
    {
        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress;
        }

        /// <summary>
        /// Gets the assigned reverse FQDN, if any.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.ReverseFqdn
        {
            get
            {
                return this.ReverseFqdn();
            }
        }

        /// <summary>
        /// Gets true if this public IP address is assigned to a network interface.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.HasAssignedNetworkInterface
        {
            get
            {
                return this.HasAssignedNetworkInterface();
            }
        }

        /// <summary>
        /// Gets the IP version of the public IP address.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.Version
        {
            get
            {
                return this.Version();
            }
        }

        /// <summary>
        /// Gets the assigned leaf domain label.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.LeafDomainLabel
        {
            get
            {
                return this.LeafDomainLabel();
            }
        }

        /// <summary>
        /// Gets the assigned FQDN (fully qualified domain name).
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.Fqdn
        {
            get
            {
                return this.Fqdn();
            }
        }

        /// <return>The load balancer public frontend that this public IP address is assigned to.</return>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPublicFrontend Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.GetAssignedLoadBalancerFrontend()
        {
            return this.GetAssignedLoadBalancerFrontend() as Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPublicFrontend;
        }

        /// <summary>
        /// Gets true if this public IP address is assigned to a load balancer.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.HasAssignedLoadBalancer
        {
            get
            {
                return this.HasAssignedLoadBalancer();
            }
        }

        /// <summary>
        /// Gets the idle connection timeout setting (in minutes).
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.IdleTimeoutInMinutes
        {
            get
            {
                return this.IdleTimeoutInMinutes();
            }
        }

        /// <return>The network interface IP configuration that this public IP address is assigned to.</return>
        Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.GetAssignedNetworkInterfaceIpConfiguration()
        {
            return this.GetAssignedNetworkInterfaceIpConfiguration() as Microsoft.Azure.Management.Network.Fluent.INicIpConfiguration;
        }

        /// <summary>
        /// Gets the assigned IP address.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress.IpAddress
        {
            get
            {
                return this.IpAddress();
            }
        }

        /// <summary>
        /// Gets the IP address allocation method (Static/Dynamic).
        /// </summary>
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
        /// <return>The next stage of the resource update.</return>
        PublicIpAddress.Update.IUpdate PublicIpAddress.Update.IWithReverseFQDN.WithReverseFqdn(string reverseFQDN)
        {
            return this.WithReverseFqdn(reverseFQDN) as PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Ensures that no reverse FQDN will be used.
        /// </summary>
        /// <return>The next stage of the resource update.</return>
        PublicIpAddress.Update.IUpdate PublicIpAddress.Update.IWithReverseFQDN.WithoutReverseFqdn()
        {
            return this.WithoutReverseFqdn() as PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the reverse FQDN to assign to this public IP address.
        /// </summary>
        /// <param name="reverseFQDN">The reverse FQDN to assign.</param>
        /// <return>The next stage of the resource definition.</return>
        PublicIpAddress.Definition.IWithCreate PublicIpAddress.Definition.IWithReverseFQDN.WithReverseFqdn(string reverseFQDN)
        {
            return this.WithReverseFqdn(reverseFQDN) as PublicIpAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Ensures that no reverse FQDN will be used.
        /// </summary>
        /// <return>The next stage of the resource definition.</return>
        PublicIpAddress.Definition.IWithCreate PublicIpAddress.Definition.IWithReverseFQDN.WithoutReverseFqdn()
        {
            return this.WithoutReverseFqdn() as PublicIpAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the timeout (in minutes) for an idle connection.
        /// </summary>
        /// <param name="minutes">The length of the time out in minutes.</param>
        /// <return>The next stage of the resource update.</return>
        PublicIpAddress.Update.IUpdate PublicIpAddress.Update.IWithIdleTimout.WithIdleTimeoutInMinutes(int minutes)
        {
            return this.WithIdleTimeoutInMinutes(minutes) as PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Ensures that no leaf domain label will be used.
        /// This means that this public IP address will not be associated with a domain name.
        /// </summary>
        /// <return>The next stage of the resource update.</return>
        PublicIpAddress.Update.IUpdate PublicIpAddress.Update.IWithLeafDomainLabel.WithoutLeafDomainLabel()
        {
            return this.WithoutLeafDomainLabel() as PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the leaf domain label to associate with this public IP address.
        /// The fully qualified domain name (FQDN)
        /// will be constructed automatically by appending the rest of the domain to this label.
        /// </summary>
        /// <param name="dnsName">The leaf domain label to use. This must follow the required naming convention for leaf domain names.</param>
        /// <return>The next stage of the resource update.</return>
        PublicIpAddress.Update.IUpdate PublicIpAddress.Update.IWithLeafDomainLabel.WithLeafDomainLabel(string dnsName)
        {
            return this.WithLeafDomainLabel(dnsName) as PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Ensures that no leaf domain label will be used.
        /// This means that this public IP address will not be associated with a domain name.
        /// </summary>
        /// <return>The next stage of the public IP address definition.</return>
        PublicIpAddress.Definition.IWithCreate PublicIpAddress.Definition.IWithLeafDomainLabel.WithoutLeafDomainLabel()
        {
            return this.WithoutLeafDomainLabel() as PublicIpAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the leaf domain label to associate with this public IP address.
        /// The fully qualified domain name (FQDN)
        /// will be constructed automatically by appending the rest of the domain to this label.
        /// </summary>
        /// <param name="dnsName">The leaf domain label to use. This must follow the required naming convention for leaf domain names.</param>
        /// <return>The next stage of the public IP address definition.</return>
        PublicIpAddress.Definition.IWithCreate PublicIpAddress.Definition.IWithLeafDomainLabel.WithLeafDomainLabel(string dnsName)
        {
            return this.WithLeafDomainLabel(dnsName) as PublicIpAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables static IP address allocation.
        /// Use PublicIpAddress.ipAddress() after the public IP address is updated to
        /// obtain the actual IP address allocated for this resource by Azure.
        /// </summary>
        /// <return>The next stage of the resource update.</return>
        PublicIpAddress.Update.IUpdate PublicIpAddress.Update.IWithIpAddress.WithStaticIp()
        {
            return this.WithStaticIp() as PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Enables dynamic IP address allocation.
        /// </summary>
        /// <return>The next stage of the resource update.</return>
        PublicIpAddress.Update.IUpdate PublicIpAddress.Update.IWithIpAddress.WithDynamicIp()
        {
            return this.WithDynamicIp() as PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Enables static IP address allocation.
        /// Use PublicIpAddress.ipAddress() after the public IP address is created to obtain the
        /// actual IP address allocated for this resource by Azure.
        /// </summary>
        /// <return>The next stage of the public IP address definition.</return>
        PublicIpAddress.Definition.IWithCreate PublicIpAddress.Definition.IWithIpAddress.WithStaticIp()
        {
            return this.WithStaticIp() as PublicIpAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables dynamic IP address allocation.
        /// </summary>
        /// <return>The next stage of the public IP address definition.</return>
        PublicIpAddress.Definition.IWithCreate PublicIpAddress.Definition.IWithIpAddress.WithDynamicIp()
        {
            return this.WithDynamicIp() as PublicIpAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the timeout (in minutes) for an idle connection.
        /// </summary>
        /// <param name="minutes">The length of the time out in minutes.</param>
        /// <return>The next stage of the resource definition.</return>
        PublicIpAddress.Definition.IWithCreate PublicIpAddress.Definition.IWithIdleTimeout.WithIdleTimeoutInMinutes(int minutes)
        {
            return this.WithIdleTimeoutInMinutes(minutes) as PublicIpAddress.Definition.IWithCreate;
        }
    }
}