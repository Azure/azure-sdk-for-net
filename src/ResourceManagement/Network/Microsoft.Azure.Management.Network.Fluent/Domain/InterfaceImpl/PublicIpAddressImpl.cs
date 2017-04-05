// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Definition;
    using Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Update;
    

    internal partial class PublicIPAddressImpl 
    {
        /// <summary>
        /// Gets the assigned reverse FQDN, if any.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress.ReverseFqdn
        {
            get
            {
                return this.ReverseFqdn();
            }
        }

        /// <summary>
        /// Gets true if this public IP address is assigned to a network interface.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress.HasAssignedNetworkInterface
        {
            get
            {
                return this.HasAssignedNetworkInterface();
            }
        }

        /// <summary>
        /// Gets the IP version of the public IP address.
        /// </summary>
        Models.IPVersion Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress.Version
        {
            get
            {
                return this.Version() as Models.IPVersion;
            }
        }

        /// <summary>
        /// Gets the assigned leaf domain label.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress.LeafDomainLabel
        {
            get
            {
                return this.LeafDomainLabel();
            }
        }

        /// <summary>
        /// Gets the assigned FQDN (fully qualified domain name).
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress.Fqdn
        {
            get
            {
                return this.Fqdn();
            }
        }

        /// <return>The load balancer public frontend that this public IP address is assigned to.</return>
        Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPublicFrontend Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress.GetAssignedLoadBalancerFrontend()
        {
            return this.GetAssignedLoadBalancerFrontend() as Microsoft.Azure.Management.Network.Fluent.ILoadBalancerPublicFrontend;
        }

        /// <summary>
        /// Gets true if this public IP address is assigned to a load balancer.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress.HasAssignedLoadBalancer
        {
            get
            {
                return this.HasAssignedLoadBalancer();
            }
        }

        /// <summary>
        /// Gets the idle connection timeout setting (in minutes).
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress.IdleTimeoutInMinutes
        {
            get
            {
                return this.IdleTimeoutInMinutes();
            }
        }

        /// <return>The network interface IP configuration that this public IP address is assigned to.</return>
        Microsoft.Azure.Management.Network.Fluent.INicIPConfiguration Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress.GetAssignedNetworkInterfaceIPConfiguration()
        {
            return this.GetAssignedNetworkInterfaceIPConfiguration() as Microsoft.Azure.Management.Network.Fluent.INicIPConfiguration;
        }

        /// <summary>
        /// Gets the assigned IP address.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress.IpAddress
        {
            get
            {
                return this.IPAddress();
            }
        }

        /// <summary>
        /// Gets the IP address allocation method (Static/Dynamic).
        /// </summary>
        Models.IPAllocationMethod Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress.IPAllocationMethod
        {
            get
            {
                return this.IPAllocationMethod() as Models.IPAllocationMethod;
            }
        }

        /// <summary>
        /// Specifies the timeout (in minutes) for an idle connection.
        /// </summary>
        /// <param name="minutes">The length of the time out in minutes.</param>
        /// <return>The next stage of the resource update.</return>
        PublicIPAddress.Update.IUpdate PublicIPAddress.Update.IWithIdleTimout.WithIdleTimeoutInMinutes(int minutes)
        {
            return this.WithIdleTimeoutInMinutes(minutes) as PublicIPAddress.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the reverse FQDN to assign to this public IP address.
        /// </summary>
        /// <param name="reverseFQDN">The reverse FQDN to assign.</param>
        /// <return>The next stage of the resource definition.</return>
        PublicIPAddress.Definition.IWithCreate PublicIPAddress.Definition.IWithReverseFQDN.WithReverseFqdn(string reverseFQDN)
        {
            return this.WithReverseFqdn(reverseFQDN) as PublicIPAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Ensures that no reverse FQDN will be used.
        /// </summary>
        /// <return>The next stage of the resource definition.</return>
        PublicIPAddress.Definition.IWithCreate PublicIPAddress.Definition.IWithReverseFQDN.WithoutReverseFqdn()
        {
            return this.WithoutReverseFqdn() as PublicIPAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the reverse FQDN to assign to this public IP address.
        /// </summary>
        /// <param name="reverseFQDN">The reverse FQDN to assign.</param>
        /// <return>The next stage of the resource update.</return>
        PublicIPAddress.Update.IUpdate PublicIPAddress.Update.IWithReverseFQDN.WithReverseFqdn(string reverseFQDN)
        {
            return this.WithReverseFqdn(reverseFQDN) as PublicIPAddress.Update.IUpdate;
        }

        /// <summary>
        /// Ensures that no reverse FQDN will be used.
        /// </summary>
        /// <return>The next stage of the resource update.</return>
        PublicIPAddress.Update.IUpdate PublicIPAddress.Update.IWithReverseFQDN.WithoutReverseFqdn()
        {
            return this.WithoutReverseFqdn() as PublicIPAddress.Update.IUpdate;
        }

        /// <summary>
        /// Ensures that no leaf domain label will be used.
        /// This means that this public IP address will not be associated with a domain name.
        /// </summary>
        /// <return>The next stage of the public IP address definition.</return>
        PublicIPAddress.Definition.IWithCreate PublicIPAddress.Definition.IWithLeafDomainLabel.WithoutLeafDomainLabel()
        {
            return this.WithoutLeafDomainLabel() as PublicIPAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the leaf domain label to associate with this public IP address.
        /// The fully qualified domain name (FQDN)
        /// will be constructed automatically by appending the rest of the domain to this label.
        /// </summary>
        /// <param name="dnsName">The leaf domain label to use. This must follow the required naming convention for leaf domain names.</param>
        /// <return>The next stage of the public IP address definition.</return>
        PublicIPAddress.Definition.IWithCreate PublicIPAddress.Definition.IWithLeafDomainLabel.WithLeafDomainLabel(string dnsName)
        {
            return this.WithLeafDomainLabel(dnsName) as PublicIPAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Ensures that no leaf domain label will be used.
        /// This means that this public IP address will not be associated with a domain name.
        /// </summary>
        /// <return>The next stage of the resource update.</return>
        PublicIPAddress.Update.IUpdate PublicIPAddress.Update.IWithLeafDomainLabel.WithoutLeafDomainLabel()
        {
            return this.WithoutLeafDomainLabel() as PublicIPAddress.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the leaf domain label to associate with this public IP address.
        /// The fully qualified domain name (FQDN)
        /// will be constructed automatically by appending the rest of the domain to this label.
        /// </summary>
        /// <param name="dnsName">The leaf domain label to use. This must follow the required naming convention for leaf domain names.</param>
        /// <return>The next stage of the resource update.</return>
        PublicIPAddress.Update.IUpdate PublicIPAddress.Update.IWithLeafDomainLabel.WithLeafDomainLabel(string dnsName)
        {
            return this.WithLeafDomainLabel(dnsName) as PublicIPAddress.Update.IUpdate;
        }

        /// <summary>
        /// Enables static IP address allocation.
        /// Use  PublicIPAddress.ipAddress() after the public IP address is created to obtain the
        /// actual IP address allocated for this resource by Azure.
        /// </summary>
        /// <return>The next stage of the public IP address definition.</return>
        PublicIPAddress.Definition.IWithCreate PublicIPAddress.Definition.IWithIPAddress.WithStaticIP()
        {
            return this.WithStaticIP() as PublicIPAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables dynamic IP address allocation.
        /// </summary>
        /// <return>The next stage of the public IP address definition.</return>
        PublicIPAddress.Definition.IWithCreate PublicIPAddress.Definition.IWithIPAddress.WithDynamicIP()
        {
            return this.WithDynamicIP() as PublicIPAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables static IP address allocation.
        /// Use  PublicIPAddress.ipAddress() after the public IP address is updated to
        /// obtain the actual IP address allocated for this resource by Azure.
        /// </summary>
        /// <return>The next stage of the resource update.</return>
        PublicIPAddress.Update.IUpdate PublicIPAddress.Update.IWithIPAddress.WithStaticIP()
        {
            return this.WithStaticIP() as PublicIPAddress.Update.IUpdate;
        }

        /// <summary>
        /// Enables dynamic IP address allocation.
        /// </summary>
        /// <return>The next stage of the resource update.</return>
        PublicIPAddress.Update.IUpdate PublicIPAddress.Update.IWithIPAddress.WithDynamicIP()
        {
            return this.WithDynamicIP() as PublicIPAddress.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the timeout (in minutes) for an idle connection.
        /// </summary>
        /// <param name="minutes">The length of the time out in minutes.</param>
        /// <return>The next stage of the resource definition.</return>
        PublicIPAddress.Definition.IWithCreate PublicIPAddress.Definition.IWithIdleTimeout.WithIdleTimeoutInMinutes(int minutes)
        {
            return this.WithIdleTimeoutInMinutes(minutes) as PublicIPAddress.Definition.IWithCreate;
        }
    }
}