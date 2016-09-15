/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Network
{

    using Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition;
    using Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Models;
    using System.Threading;
    using Microsoft.Azure.Management.V2.Resource;
    using Microsoft.Rest;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Resource.Core;
    public partial class PublicIpAddressImpl 
    {
        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <returns>the refreshed resource</returns>
        Microsoft.Azure.Management.V2.Network.IPublicIpAddress Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.V2.Network.IPublicIpAddress>.Refresh () {
            return this.Refresh() as Microsoft.Azure.Management.V2.Network.IPublicIpAddress;
        }

        /// <returns>the assigned reverse FQDN, if any</returns>
        string Microsoft.Azure.Management.V2.Network.IPublicIpAddress.ReverseFqdn
        {
            get
            {
                return this.ReverseFqdn as string;
            }
        }
        /// <returns>the assigned leaf domain label</returns>
        string Microsoft.Azure.Management.V2.Network.IPublicIpAddress.LeafDomainLabel
        {
            get
            {
                return this.LeafDomainLabel as string;
            }
        }
        /// <returns>the assigned FQDN (fully qualified domain name)</returns>
        string Microsoft.Azure.Management.V2.Network.IPublicIpAddress.Fqdn
        {
            get
            {
                return this.Fqdn as string;
            }
        }
        /// <returns>the idle connection timeout setting (in minutes)</returns>
        int? Microsoft.Azure.Management.V2.Network.IPublicIpAddress.IdleTimeoutInMinutes
        {
            get
            {
                return this.IdleTimeoutInMinutes;
            }
        }
        /// <returns>the assigned IP address</returns>
        string Microsoft.Azure.Management.V2.Network.IPublicIpAddress.IpAddress
        {
            get
            {
                return this.IpAddress as string;
            }
        }
        /// <returns>the IP address allocation method (Static/Dynamic)</returns>
        string Microsoft.Azure.Management.V2.Network.IPublicIpAddress.IpAllocationMethod
        {
            get
            {
                return this.IpAllocationMethod as string;
            }
        }
        /// <summary>
        /// Execute the update request asynchronously.
        /// </summary>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <returns>the handle to the REST call</returns>
        async Task<Microsoft.Azure.Management.V2.Network.IPublicIpAddress> Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.V2.Network.IPublicIpAddress>.ApplyAsync (CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true) {
            return await this.ApplyAsync() as IPublicIpAddress;
        }

        /// <summary>
        /// Execute the update request.
        /// </summary>
        /// <returns>the updated resource</returns>
        Microsoft.Azure.Management.V2.Network.IPublicIpAddress Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.V2.Network.IPublicIpAddress>.Apply () {
            return this.Apply() as Microsoft.Azure.Management.V2.Network.IPublicIpAddress;
        }

        /// <summary>
        /// Specifies the reverse FQDN to assign to this public IP address.
        /// </summary>
        /// <param name="reverseFQDN">reverseFQDN the reverse FQDN to assign</param>
        /// <returns>the next stage of the resource update</returns>
        Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IUpdate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IWithReverseFQDN.WithReverseFqdn (string reverseFQDN) {
            return this.WithReverseFqdn( reverseFQDN) as Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Ensures that no reverse FQDN will be used.
        /// </summary>
        /// <returns>The next stage of the resource update</returns>
        Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IUpdate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IWithReverseFQDN.WithoutReverseFqdn () {
            return this.WithoutReverseFqdn() as Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the reverse FQDN to assign to this public IP address.
        /// <p>
        /// </summary>
        /// <param name="reverseFQDN">reverseFQDN the reverse FQDN to assign</param>
        /// <returns>the next stage of the resource definition</returns>
        Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithReverseFQDN.WithReverseFqdn (string reverseFQDN) {
            return this.WithReverseFqdn( reverseFQDN) as Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Ensures that no reverse FQDN will be used.
        /// </summary>
        /// <returns>the next stage of the resource definition</returns>
        Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithReverseFQDN.WithoutReverseFqdn () {
            return this.WithoutReverseFqdn() as Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the timeout (in minutes) for an idle connection.
        /// </summary>
        /// <param name="minutes">minutes the length of the time out in minutes</param>
        /// <returns>the next stage of the resource update</returns>
        Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IUpdate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IWithIdleTimout.WithIdleTimeoutInMinutes (int minutes) {
            return this.WithIdleTimeoutInMinutes( minutes) as Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Ensures that no leaf domain label will be used.
        /// <p>
        /// This means that this public IP address will not be associated with a domain name.
        /// </summary>
        /// <returns>the next stage of the resource update</returns>
        Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IUpdate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IWithLeafDomainLabel.WithoutLeafDomainLabel () {
            return this.WithoutLeafDomainLabel() as Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the leaf domain label to associate with this public IP address.
        /// <p>
        /// The fully qualified domain name (FQDN)
        /// will be constructed automatically by appending the rest of the domain to this label.
        /// </summary>
        /// <param name="dnsName">dnsName the leaf domain label to use. This must follow the required naming convention for leaf domain names.</param>
        /// <returns>the next stage of the resource update</returns>
        Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IUpdate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IWithLeafDomainLabel.WithLeafDomainLabel (string dnsName) {
            return this.WithLeafDomainLabel( dnsName) as Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Ensures that no leaf domain label will be used.
        /// <p>
        /// This means that this public IP address will not be associated with a domain name.
        /// </summary>
        /// <returns>the next stage of the public IP address definition</returns>
        Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithLeafDomainLabel.WithoutLeafDomainLabel () {
            return this.WithoutLeafDomainLabel() as Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the leaf domain label to associate with this public IP address.
        /// <p>
        /// The fully qualified domain name (FQDN)
        /// will be constructed automatically by appending the rest of the domain to this label.
        /// </summary>
        /// <param name="dnsName">dnsName the leaf domain label to use. This must follow the required naming convention for leaf domain names.</param>
        /// <returns>the next stage of the public IP address definition</returns>
        Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithLeafDomainLabel.WithLeafDomainLabel (string dnsName) {
            return this.WithLeafDomainLabel( dnsName) as Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables static IP address allocation.
        /// <p>
        /// Use {@link PublicIpAddress#ipAddress()} after the public IP address is updated to
        /// obtain the actual IP address allocated for this resource by Azure
        /// </summary>
        /// <returns>the next stage of the resource update</returns>
        Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IUpdate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IWithIpAddress.WithStaticIp () {
            return this.WithStaticIp() as Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Enables dynamic IP address allocation.
        /// </summary>
        /// <returns>the next stage of the resource update</returns>
        Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IUpdate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IWithIpAddress.WithDynamicIp () {
            return this.WithDynamicIp() as Microsoft.Azure.Management.V2.Network.PublicIpAddress.Update.IUpdate;
        }

        /// <summary>
        /// Enables static IP address allocation.
        /// <p>
        /// Use {@link PublicIpAddress#ipAddress()} after the public IP address is created to obtain the
        /// actual IP address allocated for this resource by Azure
        /// </summary>
        /// <returns>the next stage of the public IP address definition</returns>
        Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithIpAddress.WithStaticIp () {
            return this.WithStaticIp() as Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables dynamic IP address allocation.
        /// </summary>
        /// <returns>the next stage of the public IP address definition</returns>
        Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithIpAddress.WithDynamicIp () {
            return this.WithDynamicIp() as Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the timeout (in minutes) for an idle connection.
        /// </summary>
        /// <param name="minutes">minutes the length of the time out in minutes</param>
        /// <returns>the next stage of the resource definition</returns>
        Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithCreate Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithIdleTimeout.WithIdleTimeoutInMinutes (int minutes) {
            return this.WithIdleTimeoutInMinutes( minutes) as Microsoft.Azure.Management.V2.Network.PublicIpAddress.Definition.IWithCreate;
        }

    }
}