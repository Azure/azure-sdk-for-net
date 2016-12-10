// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update
{
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIpAddress.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIpConfiguration.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIpConfiguration.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;

    /// <summary>
    /// The stage of an application gateway update allowing to modify backends.
    /// </summary>
    public interface IWithBackend 
    {
        /// <summary>
        /// Begins the definition of a new application gateway backend to be attached to the gateway.
        /// </summary>
        /// <param name="name">A unique name for the backend.</param>
        /// <return>The first stage of the backend definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate> DefineBackend(string name);

        /// <summary>
        /// Ensures the specified IP address is not associated with any backend.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutBackendIpAddress(string ipAddress);

        /// <summary>
        /// Removes the specified backend.
        /// Note that removing a backend referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="backendName">The name of an existing backend on this application gateway.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutBackend(string backendName);

        /// <summary>
        /// Begins the update of an existing backend on this application gateway.
        /// </summary>
        /// <param name="name">The name of the backend.</param>
        /// <return>The first stage of an update of the backend.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Update.IUpdate UpdateBackend(string name);

        /// <summary>
        /// Ensures the specified fully qualified domain name (FQDN) is not associated with any backend.
        /// </summary>
        /// <param name="fqdn">A fully qualified domain name (FQDN).</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutBackendFqdn(string fqdn);
    }

    /// <summary>
    /// The stage of an application gateway update allowing to modify SSL certificates.
    /// </summary>
    public interface IWithSslCert 
    {
        /// <summary>
        /// Removes the specified SSL certificate from the application gateway.
        /// Note that removing a certificate referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="name">The name of the certificate to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutCertificate(string name);

        /// <summary>
        /// Begins the definition of a new application gateway SSL certificate to be attached to the gateway for use in frontend HTTPS listeners.
        /// </summary>
        /// <param name="name">A unique name for the certificate.</param>
        /// <return>The first stage of the certificate definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate> DefineSslCertificate(string name);
    }

    /// <summary>
    /// The template for an application gateway update operation, containing all the settings that
    /// can be modified.
    /// Call {.
    /// </summary>
    /// <code>Apply()} to apply the changes to the resource in Azure.</code>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        IUpdateWithTags<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>,
        IWithSize,
        IWithInstanceCount,
        IWithBackend,
        IWithBackendHttpConfig,
        IWithIpConfig,
        IWithFrontend,
        IWithPublicIpAddress,
        IWithFrontendPort,
        IWithSslCert,
        IWithListener,
        IWithRequestRoutingRule,
        IWithExistingSubnet
    {
    }

    /// <summary>
    /// The stage of an application gateway update allowing to modify backend HTTP configurations.
    /// </summary>
    public interface IWithBackendHttpConfig 
    {
        /// <summary>
        /// Removes the specified backend HTTP configuration from this application gateway.
        /// Note that removing a backend HTTP configuration referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="name">The name of an existing backend HTTP configuration on this application gateway.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutBackendHttpConfiguration(string name);

        /// <summary>
        /// Begins the update of a backend HTTP configuration.
        /// </summary>
        /// <param name="name">The name of an existing backend HTTP configuration on this application gateway.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate UpdateBackendHttpConfiguration(string name);

        /// <summary>
        /// Begins the definition of a new application gateway backend HTTP configuration to be attached to the gateway.
        /// </summary>
        /// <param name="name">A unique name for the backend HTTP configuration.</param>
        /// <return>The first stage of the backend HTTP configuration definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate> DefineBackendHttpConfiguration(string name);
    }

    /// <summary>
    /// The stage of an application gateway update allowing to modify request routing rules.
    /// </summary>
    public interface IWithRequestRoutingRule 
    {
        /// <summary>
        /// Begins the update of a request routing rule.
        /// </summary>
        /// <param name="name">The name of an existing request routing rule.</param>
        /// <return>The first stage of a request routing rule update or null if the requested rule does not exist.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update.IUpdate UpdateRequestRoutingRule(string name);

        /// <summary>
        /// Begins the definition of a request routing rule for this application gateway.
        /// </summary>
        /// <param name="name">A unique name for the request routing rule.</param>
        /// <return>The first stage of the request routing rule.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate> DefineRequestRoutingRule(string name);

        /// <summary>
        /// Removes a request routing rule from the application gateway.
        /// </summary>
        /// <param name="name">The name of the request routing rule to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutRequestRoutingRule(string name);
    }

    /// <summary>
    /// The stage of an application gateway update allowing to modify frontend ports.
    /// </summary>
    public interface IWithFrontendPort 
    {
        /// <summary>
        /// Creates a frontend port with an auto-generated name and the specified port number, unless one already exists.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithFrontendPort(int portNumber);

        /// <summary>
        /// Creates a frontend port with the specified name and port number, unless a port matching this name and/or number already exists.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <param name="name">The name to assign to the port.</param>
        /// <return>The next stage of the definition, or null if a port matching either the name or the number, but not both, already exists.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithFrontendPort(int portNumber, string name);

        /// <summary>
        /// Removes the specified frontend port.
        /// Note that removing a frontend port referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="name">The name of the frontend port to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutFrontendPort(string name);

        /// <summary>
        /// Removes the specified frontend port.
        /// Note that removing a frontend port referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="portNumber">The port number of the frontend port to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutFrontendPort(int portNumber);
    }

    /// <summary>
    /// The stage of an application gateway update allowing to modify frontend listeners.
    /// </summary>
    public interface IWithListener 
    {
        /// <summary>
        /// Begins the definition of a new application gateway listener to be attached to the gateway.
        /// </summary>
        /// <param name="name">A unique name for the listener.</param>
        /// <return>The first stage of the listener definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate> DefineListener(string name);

        /// <summary>
        /// Begins the update of a listener.
        /// </summary>
        /// <param name="name">The name of an existing listener to update.</param>
        /// <return>The next stage of the definition or null if the requested listener does not exist.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Update.IUpdate UpdateListener(string name);

        /// <summary>
        /// Removes a frontend listener from the application gateway.
        /// Note that removing a listener referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="name">The name of the listener to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutListener(string name);
    }

    /// <summary>
    /// The stage of an application gateway update allowing to modify frontend IP configurations.
    /// </summary>
    public interface IWithFrontend 
    {
        /// <summary>
        /// Begins the update of an existing frontend IP configuration.
        /// </summary>
        /// <param name="frontendName">The name of an existing frontend IP configuration.</param>
        /// <return>The first stage of the frontend IP configuration update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.Update.IUpdate UpdateFrontend(string frontendName);

        /// <summary>
        /// Begins the definition of the default public frontend IP configuration, creating one if it does not already exist.
        /// </summary>
        /// <return>The first stage of a frontend definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate> DefinePublicFrontend();

        /// <summary>
        /// Specifies that the application gateway should not be private, i.e. its endponts should not be internally accessible
        /// from within the virtual network.
        /// Note that if there are any other settings referencing the private frontend, removing it may break the application gateway.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutPrivateFrontend();

        /// <summary>
        /// Specifies that the application gateway should not be Internet-facing.
        /// Note that if there are any other settings referencing the public frontend, removing it may break the application gateway.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutPublicFrontend();

        /// <summary>
        /// Removes the specified frontend IP configuration.
        /// Note that removing a frontend referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="frontendName">The name of the frontend IP configuration to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutFrontend(string frontendName);

        /// <summary>
        /// Begins the update of the public frontend IP configuration, if it exists.
        /// </summary>
        /// <return>The first stage of a frontend update or null if no public frontend exists.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.Update.IUpdate UpdatePublicFrontend();

        /// <summary>
        /// Begins the definition of the default private frontend IP configuration, creating one if it does not already exist.
        /// </summary>
        /// <return>The first stage of a frontend definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate> DefinePrivateFrontend();
    }

    /// <summary>
    /// The stage of an application gateway update allowing to specify a public IP address for the public frontend.
    /// </summary>
    public interface IWithPublicIpAddress  :
        IWithPublicIpAddressNoDnsLabel<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of an internal application gateway update allowing to make the application gateway accessible to its
    /// virtual network.
    /// </summary>
    public interface IWithPrivateFrontend 
    {
        /// <summary>
        /// Enables a private (internal) default frontend in the subnet containing the application gateway.
        /// A frontend with the name "default" will be created if needed.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithPrivateFrontend();

        /// <summary>
        /// Specifies that no private, or internal, frontend should be enabled.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutPrivateFrontend();
    }

    /// <summary>
    /// The stage of an application gateway update allowing to specify the subnet the app gateway is getting
    /// its private IP address from.
    /// </summary>
    public interface IWithExistingSubnet  :
        IWithSubnet<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>
    {
        /// <summary>
        /// Specifies the subnet the application gateway gets its private IP address from.
        /// This will create a new IP configuration, if it does not already exist.
        /// Private (internal) frontends, if any have been enabled, will be configured to use this subnet as well.
        /// </summary>
        /// <param name="subnet">An existing subnet.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithExistingSubnet(ISubnet subnet);

        /// <summary>
        /// Specifies the subnet the application gateway gets its private IP address from.
        /// This will create a new IP configuration, if it does not already exist.
        /// Private (internal) frontends, if any have been enabled, will be configured to use this subnet as well.
        /// </summary>
        /// <param name="network">The virtual network the subnet is part of.</param>
        /// <param name="subnetName">The name of a subnet within the selected network.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithExistingSubnet(INetwork network, string subnetName);
    }

    /// <summary>
    /// The stage of an application gateway update allowing to modify IP configurations.
    /// </summary>
    public interface IWithIpConfig 
    {
        /// <summary>
        /// Begins the definition of the default IP configuration.
        /// If a default IP configuration already exists, it will be this is equivalent to {.
        /// </summary>
        /// <code>UpdateDefaultIpConfiguration()}.</code>
        /// <return>The first stage of an IP configuration update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIpConfiguration.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate> DefineDefaultIpConfiguration();

        /// <summary>
        /// Begins the update of an existing IP configuration.
        /// </summary>
        /// <param name="ipConfigurationName">The name of an existing IP configuration.</param>
        /// <return>The first stage of an IP configuration update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIpConfiguration.Update.IUpdate UpdateIpConfiguration(string ipConfigurationName);

        /// <summary>
        /// Removes the specified IP configuration.
        /// Note that removing an IP configuration referenced by other settings may break the application gateway.
        /// Also, there must be at least one IP configuration for the application gateway to function.
        /// </summary>
        /// <param name="ipConfigurationName">The name of the IP configuration to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutIpConfiguration(string ipConfigurationName);

        /// <summary>
        /// Begins the update of the default IP configuration i.e. the only one IP configuration that exists, assuming only one exists.
        /// </summary>
        /// <return>The first stage of an IP configuration update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIpConfiguration.Update.IUpdate UpdateDefaultIpConfiguration();
    }

    /// <summary>
    /// The stage of an application gateway update allowing to specify the size.
    /// </summary>
    public interface IWithSize 
    {
        /// <summary>
        /// Specifies the size of the application gateway to use within the context of the selected tier.
        /// </summary>
        /// <param name="size">An application gateway size name.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithSize(ApplicationGatewaySkuName size);
    }

    /// <summary>
    /// The stage of an application gateway update allowing to specify the capacity (number of instances) of
    /// the application gateway.
    /// </summary>
    public interface IWithInstanceCount 
    {
        /// <summary>
        /// Specifies the capacity (number of instances) for the application gateway.
        /// </summary>
        /// <param name="instanceCount">The capacity as a number between 1 and 10 but also based on the limits imposed by the selected applicatiob gateway size.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithInstanceCount(int instanceCount);
    }
}