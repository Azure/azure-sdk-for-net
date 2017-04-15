// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// A public IP address definition allowing to specify the leaf domain label, if any.
    /// </summary>
    public interface IWithLeafDomainLabel 
    {
        /// <summary>
        /// Ensures that no leaf domain label will be used.
        /// This means that this public IP address will not be associated with a domain name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Definition.IWithCreate WithoutLeafDomainLabel();

        /// <summary>
        /// Specifies the leaf domain label to associate with this public IP address.
        /// The fully qualified domain name (FQDN)
        /// will be constructed automatically by appending the rest of the domain to this label.
        /// </summary>
        /// <param name="dnsName">The leaf domain label to use. This must follow the required naming convention for leaf domain names.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Definition.IWithCreate WithLeafDomainLabel(string dnsName);
    }

    /// <summary>
    /// The stage of the public IP address definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// Container interface for all the definitions.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Definition.IBlank,
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Definition.IWithGroup,
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Definition.IWithCreate
    {
    }

    /// <summary>
    /// A public IP address definition allowing to set the IP allocation method (static or dynamic).
    /// </summary>
    public interface IWithIPAddress 
    {
        /// <summary>
        /// Enables dynamic IP address allocation.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Definition.IWithCreate WithDynamicIP();

        /// <summary>
        /// Enables static IP address allocation.
        /// Use  PublicIPAddress.ipAddress() after the public IP address is created to obtain the
        /// actual IP address allocated for this resource by Azure.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Definition.IWithCreate WithStaticIP();
    }

    /// <summary>
    /// The stage of the public IP definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress>,
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Definition.IWithLeafDomainLabel,
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Definition.IWithIPAddress,
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Definition.IWithReverseFQDN,
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Definition.IWithIdleTimeout,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// A public IP address definition allowing the reverse FQDN to be specified.
    /// </summary>
    public interface IWithReverseFQDN 
    {
        /// <summary>
        /// Specifies the reverse FQDN to assign to this public IP address.
        /// </summary>
        /// <param name="reverseFQDN">The reverse FQDN to assign.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Definition.IWithCreate WithReverseFqdn(string reverseFQDN);

        /// <summary>
        /// Ensures that no reverse FQDN will be used.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Definition.IWithCreate WithoutReverseFqdn();
    }

    /// <summary>
    /// The first stage of a public IP address definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// A public IP address definition allowing the idle timeout to be specified.
    /// </summary>
    public interface IWithIdleTimeout 
    {
        /// <summary>
        /// Specifies the timeout (in minutes) for an idle connection.
        /// </summary>
        /// <param name="minutes">The length of the time out in minutes.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.PublicIPAddress.Definition.IWithCreate WithIdleTimeoutInMinutes(int minutes);
    }
}