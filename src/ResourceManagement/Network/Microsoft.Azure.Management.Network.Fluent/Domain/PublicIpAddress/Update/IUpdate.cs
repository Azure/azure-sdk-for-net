// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Update
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// A public IP address update allowing to change the IP allocation method (static or dynamic).
    /// </summary>
    public interface IWithIPAddress 
    {
        /// <summary>
        /// Enables static IP address allocation.
        /// Use PublicIPAddress.ipAddress() after the public IP address is updated to
        /// obtain the actual IP address allocated for this resource by Azure.
        /// </summary>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Update.IUpdate WithStaticIP();

        /// <summary>
        /// Enables dynamic IP address allocation.
        /// </summary>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Update.IUpdate WithDynamicIP();
    }

    /// <summary>
    /// Container interface for all the updates.
    /// Use Update.apply() to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress>,
        IWithIPAddress,
        IWithLeafDomainLabel,
        IWithReverseFQDN,
        IWithIdleTimout,
        IUpdateWithTags<Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Update.IUpdate>
    {
    }

    /// <summary>
    /// A public IP address update allowing the reverse FQDN to be changed.
    /// </summary>
    public interface IWithReverseFQDN 
    {
        /// <summary>
        /// Specifies the reverse FQDN to assign to this public IP address.
        /// </summary>
        /// <param name="reverseFQDN">The reverse FQDN to assign.</param>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Update.IUpdate WithReverseFqdn(string reverseFQDN);

        /// <summary>
        /// Ensures that no reverse FQDN will be used.
        /// </summary>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Update.IUpdate WithoutReverseFqdn();
    }

    /// <summary>
    /// A public IP address update allowing to change the leaf domain label, if any.
    /// </summary>
    public interface IWithLeafDomainLabel 
    {
        /// <summary>
        /// Ensures that no leaf domain label will be used.
        /// This means that this public IP address will not be associated with a domain name.
        /// </summary>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Update.IUpdate WithoutLeafDomainLabel();

        /// <summary>
        /// Specifies the leaf domain label to associate with this public IP address.
        /// The fully qualified domain name (FQDN)
        /// will be constructed automatically by appending the rest of the domain to this label.
        /// </summary>
        /// <param name="dnsName">The leaf domain label to use. This must follow the required naming convention for leaf domain names.</param>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Update.IUpdate WithLeafDomainLabel(string dnsName);
    }

    /// <summary>
    /// A public IP address update allowing the idle timeout to be changed.
    /// </summary>
    public interface IWithIdleTimout 
    {
        /// <summary>
        /// Specifies the timeout (in minutes) for an idle connection.
        /// </summary>
        /// <param name="minutes">The length of the time out in minutes.</param>
        /// <return>The next stage of the resource update.</return>
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Update.IUpdate WithIdleTimeoutInMinutes(int minutes);
    }
}