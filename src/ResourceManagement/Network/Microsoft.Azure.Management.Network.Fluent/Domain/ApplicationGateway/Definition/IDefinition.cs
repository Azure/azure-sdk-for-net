// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition
{
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIpAddress.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIpAddress.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of an application gateway definition allowing to define one or more public, or Internet-facing, frontends.
    /// </summary>
    public interface IWithPublicFrontend  :
        IWithPublicIpAddress
    {
        /// <summary>
        /// Specifies that the application gateway should not be Internet-facing.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithoutPublicFrontend();
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to add a request routing rule.
    /// </summary>
    public interface IWithRequestRoutingRule 
    {
        /// <summary>
        /// Begins the definition of a request routing rule for this application gateway.
        /// </summary>
        /// <param name="name">A unique name for the request routing rule.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> DefineRequestRoutingRule(string name);
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to add a new Internet-facing frontend with a public IP address.
    /// </summary>
    public interface IWithPublicIpAddress  :
        IWithPublicIpAddressNoDnsLabel<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage of an internal application gateway definition allowing to make the application gateway accessible to its
    /// virtual network.
    /// </summary>
    public interface IWithPrivateFrontend 
    {
        /// <summary>
        /// Enables a private (internal) default frontend in the subnet containing the application gateway.
        /// <p>
        /// A frontend with the name "default" will be created if needed.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithPrivateFrontend();

        /// <summary>
        /// Specifies that no private (internal) frontend should be enabled.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithoutPrivateFrontend();
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to specify the default IP address the app gateway will be internally available at,
    /// if the default private frontend has been enabled.
    /// </summary>
    public interface IWithPrivateIpAddress  :
        Microsoft.Azure.Management.Network.Fluent.HasPrivateIpAddress.Definition.IWithPrivateIpAddress<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithRequestRoutingRule>
    {
    }

    /// <summary>
    /// The stage of an application gateway update allowing to specify the size.
    /// </summary>
    public interface IWithSize 
    {
        /// <summary>
        /// Specifies the size of the application gateway to create within the context of the selected tier.
        /// <p>
        /// By default, the smallest size is used.
        /// </summary>
        /// <param name="size">An application gateway SKU name.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithSize(ApplicationGatewaySkuName size);
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to specify the subnet the app gateway is getting
    /// its private IP address from.
    /// </summary>
    public interface IWithExistingSubnet  :
        IWithSubnet<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate>
    {
        /// <summary>
        /// Specifies the subnet the application gateway gets its private IP address from.
        /// <p>
        /// This will create a new IP configuration, if it does not already exist.
        /// <p>
        /// Private (internal) frontends, if any have been enabled, will be configured to use this subnet as well.
        /// </summary>
        /// <param name="subnet">An existing subnet.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithExistingSubnet(ISubnet subnet);

        /// <summary>
        /// Specifies the subnet the application gateway gets its private IP address from.
        /// <p>
        /// This will create a new IP configuration, if it does not already exist.
        /// <p>
        /// Private (internal) frontends, if any have been enabled, will be configured to use this subnet as well.
        /// </summary>
        /// <param name="network">The virtual network the subnet is part of.</param>
        /// <param name="subnetName">The name of a subnet within the selected network.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithExistingSubnet(INetwork network, string subnetName);
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to add a backend.
    /// </summary>
    public interface IWithBackend 
    {
        /// <summary>
        /// Begins the definition of a new application gateway backend to be attached to the gateway.
        /// </summary>
        /// <param name="name">A unique name for the backend.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate> DefineBackend(string name);
    }

    /// <summary>
    /// The first stage of an application gateway definition.
    /// </summary>
    public interface IBlank  :
        IDefinitionWithRegion<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to add an SSL certificate to be used by HTTPS listeners.
    /// </summary>
    public interface IWithSslCert 
    {
        /// <summary>
        /// Begins the definition of a new application gateway SSL certificate to be attached to the gateway for use in HTTPS listeners.
        /// </summary>
        /// <param name="name">A unique name for the certificate.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate> DefineSslCertificate(string name);
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to specify the capacity (number of instances) of the application gateway.
    /// </summary>
    public interface IWithInstanceCount 
    {
        /// <summary>
        /// Specifies the capacity (number of instances) for the application gateway.
        /// <p>
        /// By default, 1 instance is used.
        /// </summary>
        /// <param name="instanceCount">The capacity as a number between 1 and 10 but also based on the limits imposed by the selected applicatiob gateway size.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithInstanceCount(int instanceCount);
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to add a listener.
    /// </summary>
    public interface IWithListener 
    {
        /// <summary>
        /// Begins the definition of a new application gateway listener to be attached to the gateway.
        /// </summary>
        /// <param name="name">A unique name for the listener.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate> DefineListener(string name);
    }

    /// <summary>
    /// The entirety of the application gateway definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IBlank,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithGroup,
        IWithCreate,
        IWithRequestRoutingRule,
        IWithRequestRoutingRuleOrCreate
    {
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to continue adding more request routing rules,
    /// or start specifying optional settings, or create the application gateway.
    /// </summary>
    public interface IWithRequestRoutingRuleOrCreate  :
        IWithRequestRoutingRule,
        IWithCreate
    {
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to add a backend HTTP configuration.
    /// </summary>
    public interface IWithBackendHttpConfig 
    {
        /// <summary>
        /// Begins the definition of a new application gateway backend HTTP configuration to be attached to the gateway.
        /// </summary>
        /// <param name="name">A unique name for the backend HTTP configuration.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Definition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate> DefineBackendHttpConfiguration(string name);
    }

    /// <summary>
    /// The stage of an application gateway definition containing all the required inputs for
    /// the resource to be created (via WithCreate.create()), but also allowing
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        IDefinitionWithTags<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate>,
        IWithSize,
        IWithInstanceCount,
        IWithSslCert,
        IWithFrontendPort,
        IWithListener,
        IWithBackendHttpConfig,
        IWithBackend,
        IWithExistingSubnet,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithPrivateIpAddress,
        IWithPrivateFrontend,
        IWithPublicFrontend,
        IWithPublicIpAddress
    {
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to add a frontend port.
    /// </summary>
    public interface IWithFrontendPort 
    {
        /// <summary>
        /// Creates a frontend port with an auto-generated name and the specified port number, unless one already exists.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithFrontendPort(int portNumber);

        /// <summary>
        /// Creates a frontend port with the specified name and port number, unless a port matching this name and/or number already exists.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <param name="name">The name to assign to the port.</param>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition.IWithCreate WithFrontendPort(int portNumber, string name);
    }
}