// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network.PublicIpAddress.Update
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.Resource.Update;
    using Microsoft.Azure.Management.Fluent.Network;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
    /// <summary>
    /// A public IP address update allowing to change the IP allocation method (static or dynamic).
    /// </summary>
    public interface IWithIpAddress 
    {
        /// <summary>
        /// Enables static IP address allocation.
        /// <p>
        /// Use {@link PublicIpAddress#ipAddress()} after the public IP address is updated to
        /// obtain the actual IP address allocated for this resource by Azure
        /// </summary>
        /// <returns>the next stage of the resource update</returns>
        IUpdate WithStaticIp ();

        /// <summary>
        /// Enables dynamic IP address allocation.
        /// </summary>
        /// <returns>the next stage of the resource update</returns>
        IUpdate WithDynamicIp ();

    }
    /// <summary>
    /// A public IP address update allowing the idle timeout to be changed.
    /// </summary>
    public interface IWithIdleTimout 
    {
        /// <summary>
        /// Specifies the timeout (in minutes) for an idle connection.
        /// </summary>
        /// <param name="minutes">minutes the length of the time out in minutes</param>
        /// <returns>the next stage of the resource update</returns>
        IUpdate WithIdleTimeoutInMinutes (int minutes);

    }
    /// <summary>
    /// A public IP address update allowing the reverse FQDN to be changed.
    /// </summary>
    public interface IWithReverseFQDN 
    {
        /// <summary>
        /// Specifies the reverse FQDN to assign to this public IP address.
        /// </summary>
        /// <param name="reverseFQDN">reverseFQDN the reverse FQDN to assign</param>
        /// <returns>the next stage of the resource update</returns>
        IUpdate WithReverseFqdn (string reverseFQDN);

        /// <summary>
        /// Ensures that no reverse FQDN will be used.
        /// </summary>
        /// <returns>The next stage of the resource update</returns>
        IUpdate WithoutReverseFqdn ();

    }
    /// <summary>
    /// A public IP address update allowing to change the leaf domain label, if any.
    /// </summary>
    public interface IWithLeafDomainLabel 
    {
        /// <summary>
        /// Specifies the leaf domain label to associate with this public IP address.
        /// <p>
        /// The fully qualified domain name (FQDN)
        /// will be constructed automatically by appending the rest of the domain to this label.
        /// </summary>
        /// <param name="dnsName">dnsName the leaf domain label to use. This must follow the required naming convention for leaf domain names.</param>
        /// <returns>the next stage of the resource update</returns>
        IUpdate WithLeafDomainLabel (string dnsName);

        /// <summary>
        /// Ensures that no leaf domain label will be used.
        /// <p>
        /// This means that this public IP address will not be associated with a domain name.
        /// </summary>
        /// <returns>the next stage of the resource update</returns>
        IUpdate WithoutLeafDomainLabel ();

    }
    /// <summary>
    /// Container interface for all the updates.
    /// <p>
    /// Use {@link Update#apply()} to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.Fluent.Network.IPublicIpAddress>,
        IWithIpAddress,
        IWithLeafDomainLabel,
        IWithReverseFQDN,
        IWithIdleTimout,
        IUpdateWithTags<Microsoft.Azure.Management.Fluent.Network.PublicIpAddress.Update.IUpdate>
    {
    }
}