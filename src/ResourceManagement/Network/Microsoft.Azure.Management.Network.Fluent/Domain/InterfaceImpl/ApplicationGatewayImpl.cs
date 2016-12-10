// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading.Tasks;
    using Microsoft.Azure;
    using ApplicationGateway.Definition;
    using ApplicationGateway.Update;
    using Models;
    using HasPrivateIpAddress.Definition;
    using HasPublicIpAddress.Definition;
    using HasPublicIpAddress.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    internal partial class ApplicationGatewayImpl 
    {
        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Models.NetworkManager Microsoft.Azure.Management.Resource.Fluent.Core.IHasManager<Models.NetworkManager>.Manager
        {
            get
            {
                return this.Manager() as Models.NetworkManager;
            }
        }

        /// <summary>
        /// Begins the update of an existing backend on this application gateway.
        /// </summary>
        /// <param name="name">The name of the backend.</param>
        /// <return>The first stage of an update of the backend.</return>
        ApplicationGatewayBackend.Update.IUpdate ApplicationGateway.Update.IWithBackend.UpdateBackend(string name)
        {
            return this.UpdateBackend(name) as ApplicationGatewayBackend.Update.IUpdate;
        }

        /// <summary>
        /// Ensures the specified IP address is not associated with any backend.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithBackend.WithoutBackendIpAddress(string ipAddress)
        {
            return this.WithoutBackendIpAddress(ipAddress) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Ensures the specified fully qualified domain name (FQDN) is not associated with any backend.
        /// </summary>
        /// <param name="fqdn">A fully qualified domain name (FQDN).</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithBackend.WithoutBackendFqdn(string fqdn)
        {
            return this.WithoutBackendFqdn(fqdn) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Removes the specified backend.
        /// Note that removing a backend referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="backendName">The name of an existing backend on this application gateway.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithBackend.WithoutBackend(string backendName)
        {
            return this.WithoutBackend(backendName) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new application gateway backend to be attached to the gateway.
        /// </summary>
        /// <param name="name">A unique name for the backend.</param>
        /// <return>The first stage of the backend definition.</return>
        ApplicationGatewayBackend.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate> ApplicationGateway.Update.IWithBackend.DefineBackend(string name)
        {
            return this.DefineBackend(name) as ApplicationGatewayBackend.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the definition of a new application gateway backend to be attached to the gateway.
        /// </summary>
        /// <param name="name">A unique name for the backend.</param>
        /// <return>The first stage of the backend definition.</return>
        ApplicationGatewayBackend.Definition.IBlank<ApplicationGateway.Definition.IWithCreate> ApplicationGateway.Definition.IWithBackend.DefineBackend(string name)
        {
            return this.DefineBackend(name) as ApplicationGatewayBackend.Definition.IBlank<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Gets the name of the subnet associated with this resource.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasSubnet.SubnetName
        {
            get
            {
                return this.SubnetName();
            }
        }

        /// <summary>
        /// Gets the resource ID of the virtual network whose subnet is associated with this resource.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasSubnet.NetworkId
        {
            get
            {
                return this.NetworkId();
            }
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGateway Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Network.Fluent.IApplicationGateway;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate HasPrivateIpAddress.Definition.IWithPrivateIpAddress<ApplicationGateway.Definition.IWithCreate>.WithPrivateIpAddressDynamic()
        {
            return this.WithPrivateIpAddressDynamic() as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">A static IP address within the associated private IP range.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate HasPrivateIpAddress.Definition.IWithPrivateIpAddress<ApplicationGateway.Definition.IWithCreate>.WithPrivateIpAddressStatic(string ipAddress)
        {
            return this.WithPrivateIpAddressStatic(ipAddress) as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the subnet the application gateway gets its private IP address from.
        /// This will create a new IP configuration, if it does not already exist.
        /// Private (internal) frontends, if any have been enabled, will be configured to use this subnet as well.
        /// </summary>
        /// <param name="subnet">An existing subnet.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithExistingSubnet.WithExistingSubnet(ISubnet subnet)
        {
            return this.WithExistingSubnet(subnet) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the subnet the application gateway gets its private IP address from.
        /// This will create a new IP configuration, if it does not already exist.
        /// Private (internal) frontends, if any have been enabled, will be configured to use this subnet as well.
        /// </summary>
        /// <param name="network">The virtual network the subnet is part of.</param>
        /// <param name="subnetName">The name of a subnet within the selected network.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithExistingSubnet.WithExistingSubnet(INetwork network, string subnetName)
        {
            return this.WithExistingSubnet(network, subnetName) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the subnet the application gateway gets its private IP address from.
        /// This will create a new IP configuration, if it does not already exist.
        /// Private (internal) frontends, if any have been enabled, will be configured to use this subnet as well.
        /// </summary>
        /// <param name="subnet">An existing subnet.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate ApplicationGateway.Definition.IWithExistingSubnet.WithExistingSubnet(ISubnet subnet)
        {
            return this.WithExistingSubnet(subnet) as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the subnet the application gateway gets its private IP address from.
        /// This will create a new IP configuration, if it does not already exist.
        /// Private (internal) frontends, if any have been enabled, will be configured to use this subnet as well.
        /// </summary>
        /// <param name="network">The virtual network the subnet is part of.</param>
        /// <param name="subnetName">The name of a subnet within the selected network.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate ApplicationGateway.Definition.IWithExistingSubnet.WithExistingSubnet(INetwork network, string subnetName)
        {
            return this.WithExistingSubnet(network, subnetName) as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the capacity (number of instances) for the application gateway.
        /// </summary>
        /// <param name="instanceCount">The capacity as a number between 1 and 10 but also based on the limits imposed by the selected applicatiob gateway size.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithInstanceCount.WithInstanceCount(int instanceCount)
        {
            return this.WithInstanceCount(instanceCount) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the capacity (number of instances) for the application gateway.
        /// By default, 1 instance is used.
        /// </summary>
        /// <param name="instanceCount">The capacity as a number between 1 and 10 but also based on the limits imposed by the selected applicatiob gateway size.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate ApplicationGateway.Definition.IWithInstanceCount.WithInstanceCount(int instanceCount)
        {
            return this.WithInstanceCount(instanceCount) as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Begins the update of the default IP configuration i.e. the only one IP configuration that exists, assuming only one exists.
        /// </summary>
        /// <return>The first stage of an IP configuration update.</return>
        ApplicationGatewayIpConfiguration.Update.IUpdate ApplicationGateway.Update.IWithIpConfig.UpdateDefaultIpConfiguration()
        {
            return this.UpdateDefaultIpConfiguration() as ApplicationGatewayIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Begins the update of an existing IP configuration.
        /// </summary>
        /// <param name="ipConfigurationName">The name of an existing IP configuration.</param>
        /// <return>The first stage of an IP configuration update.</return>
        ApplicationGatewayIpConfiguration.Update.IUpdate ApplicationGateway.Update.IWithIpConfig.UpdateIpConfiguration(string ipConfigurationName)
        {
            return this.UpdateIpConfiguration(ipConfigurationName) as ApplicationGatewayIpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of the default IP configuration.
        /// If a default IP configuration already exists, it will be this is equivalent to {.
        /// </summary>
        /// <code>UpdateDefaultIpConfiguration()}.</code>
        /// <return>The first stage of an IP configuration update.</return>
        ApplicationGatewayIpConfiguration.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate> ApplicationGateway.Update.IWithIpConfig.DefineDefaultIpConfiguration()
        {
            return this.DefineDefaultIpConfiguration() as ApplicationGatewayIpConfiguration.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Removes the specified IP configuration.
        /// Note that removing an IP configuration referenced by other settings may break the application gateway.
        /// Also, there must be at least one IP configuration for the application gateway to function.
        /// </summary>
        /// <param name="ipConfigurationName">The name of the IP configuration to remove.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithIpConfig.WithoutIpConfiguration(string ipConfigurationName)
        {
            return this.WithoutIpConfiguration(ipConfigurationName) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Gets the private IP address allocation method within the associated subnet.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IHasPrivateIpAddress.PrivateIpAllocationMethod
        {
            get
            {
                return this.PrivateIpAllocationMethod();
            }
        }

        /// <summary>
        /// Gets the private IP address associated with this resource.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IHasPrivateIpAddress.PrivateIpAddress
        {
            get
            {
                return this.PrivateIpAddress();
            }
        }

        /// <summary>
        /// Gets frontend IP configurations with a private IP address on a subnet, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend> Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.PrivateFrontends
        {
            get
            {
                return this.PrivateFrontends() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend>;
            }
        }

        /// <summary>
        /// Gets the frontend IP configuration associated with a private IP address, if any, that frontend listeners and request routing rules can reference implicitly.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.DefaultPrivateFrontend
        {
            get
            {
                return this.DefaultPrivateFrontend() as Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend;
            }
        }

        /// <summary>
        /// Gets backend address pools of this application gateway, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackend> Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.Backends
        {
            get
            {
                return this.Backends() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackend>;
            }
        }

        /// <summary>
        /// Finds a frontend listener associated with the specified frontend port number, if any.
        /// </summary>
        /// <param name="portNumber">A used port number.</param>
        /// <return>A frontend listener, or null if none found.</return>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.ListenerByPortNumber(int portNumber)
        {
            return this.ListenerByPortNumber(portNumber) as Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener;
        }

        /// <summary>
        /// Gets true if the application gateway has at least one internally load balanced frontend accessible within the virtual network.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.IsPrivate
        {
            get
            {
                return this.IsPrivate();
            }
        }

        /// <summary>
        /// Gets the size of the application gateway.
        /// </summary>
        Models.ApplicationGatewaySkuName Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.Size
        {
            get
            {
                return this.Size() as Models.ApplicationGatewaySkuName;
            }
        }

        /// <summary>
        /// Gets the SKU of this application gateway.
        /// </summary>
        Models.ApplicationGatewaySku Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.Sku
        {
            get
            {
                return this.Sku() as Models.ApplicationGatewaySku;
            }
        }

        /// <summary>
        /// Gets request routing rules, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule> Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.RequestRoutingRules
        {
            get
            {
                return this.RequestRoutingRules() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule>;
            }
        }

        /// <summary>
        /// Gets the operational state of the application gateway.
        /// </summary>
        Models.ApplicationGatewayOperationalState Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.OperationalState
        {
            get
            {
                return this.OperationalState() as Models.ApplicationGatewayOperationalState;
            }
        }

        /// <summary>
        /// Gets backend HTTP configurations of this application gateway, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfiguration> Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.BackendHttpConfigurations
        {
            get
            {
                return this.BackendHttpConfigurations() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfiguration>;
            }
        }

        /// <summary>
        /// Gets IP configurations of this application gateway, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayIpConfiguration> Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.IpConfigurations
        {
            get
            {
                return this.IpConfigurations() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayIpConfiguration>;
            }
        }

        /// <summary>
        /// Gets frontend IP configurations with a public IP address, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend> Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.PublicFrontends
        {
            get
            {
                return this.PublicFrontends() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend>;
            }
        }

        /// <summary>
        /// Gets number of instances.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.InstanceCount
        {
            get
            {
                return this.InstanceCount();
            }
        }

        /// <summary>
        /// Gets the IP configuration named "default" if it exists, or the one existing IP configuration if only one exists, else null.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayIpConfiguration Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.DefaultIpConfiguration
        {
            get
            {
                return this.DefaultIpConfiguration() as Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayIpConfiguration;
            }
        }

        /// <summary>
        /// Gets true if the application gateway has at least one Internet-facing frontend.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.IsPublic
        {
            get
            {
                return this.IsPublic();
            }
        }

        /// <summary>
        /// Gets the SSL policy for the application gateway.
        /// </summary>
        Models.ApplicationGatewaySslPolicy Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.SslPolicy
        {
            get
            {
                return this.SslPolicy() as Models.ApplicationGatewaySslPolicy;
            }
        }

        /// <summary>
        /// Gets the frontend IP configuration associated with a public IP address, if any, that frontend listeners and request routing rules can reference implicitly.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.DefaultPublicFrontend
        {
            get
            {
                return this.DefaultPublicFrontend() as Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend;
            }
        }

        /// <summary>
        /// Gets named frontend ports of this application gateway, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,int> Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.FrontendPorts
        {
            get
            {
                return this.FrontendPorts() as System.Collections.Generic.IReadOnlyDictionary<string,int>;
            }
        }

        /// <summary>
        /// Gets the tier of the application gateway.
        /// </summary>
        Models.ApplicationGatewayTier Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.Tier
        {
            get
            {
                return this.Tier() as Models.ApplicationGatewayTier;
            }
        }

        /// <return>Frontend listeners, indexed by name.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener> Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.Listeners()
        {
            return this.Listeners() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener>;
        }

        /// <summary>
        /// Gets frontend IP configurations, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend> Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.Frontends
        {
            get
            {
                return this.Frontends() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend>;
            }
        }

        /// <summary>
        /// Returns the name of the existing port, if any, that is associated with the specified port number.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The existing port name for that port number, or null if none found.</return>
        string Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.FrontendPortNameFromNumber(int portNumber)
        {
            return this.FrontendPortNameFromNumber(portNumber);
        }

        /// <summary>
        /// Gets SSL certificates, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewaySslCertificate> Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.SslCertificates
        {
            get
            {
                return this.SslCertificates() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewaySslCertificate>;
            }
        }

        /// <summary>
        /// Creates a new public IP address to associate with the resource.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Update.IUpdate HasPublicIpAddress.Update.IWithNewPublicIpAddressNoDnsLabel<ApplicationGateway.Update.IUpdate>.WithNewPublicIpAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress> creatable)
        {
            return this.WithNewPublicIpAddress(creatable) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Update.IUpdate HasPublicIpAddress.Update.IWithNewPublicIpAddressNoDnsLabel<ApplicationGateway.Update.IUpdate>.WithNewPublicIpAddress()
        {
            return this.WithNewPublicIpAddress() as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address to associate with the resource.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate HasPublicIpAddress.Definition.IWithNewPublicIpAddressNoDnsLabel<ApplicationGateway.Definition.IWithCreate>.WithNewPublicIpAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIpAddress> creatable)
        {
            return this.WithNewPublicIpAddress(creatable) as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate HasPublicIpAddress.Definition.IWithNewPublicIpAddressNoDnsLabel<ApplicationGateway.Definition.IWithCreate>.WithNewPublicIpAddress()
        {
            return this.WithNewPublicIpAddress() as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Removes the specified SSL certificate from the application gateway.
        /// Note that removing a certificate referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="name">The name of the certificate to remove.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithSslCert.WithoutCertificate(string name)
        {
            return this.WithoutCertificate(name) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new application gateway SSL certificate to be attached to the gateway for use in frontend HTTPS listeners.
        /// </summary>
        /// <param name="name">A unique name for the certificate.</param>
        /// <return>The first stage of the certificate definition.</return>
        ApplicationGatewaySslCertificate.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate> ApplicationGateway.Update.IWithSslCert.DefineSslCertificate(string name)
        {
            return this.DefineSslCertificate(name) as ApplicationGatewaySslCertificate.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the definition of a new application gateway SSL certificate to be attached to the gateway for use in HTTPS listeners.
        /// </summary>
        /// <param name="name">A unique name for the certificate.</param>
        /// <return>The first stage of the certificate definition.</return>
        ApplicationGatewaySslCertificate.Definition.IBlank<ApplicationGateway.Definition.IWithCreate> ApplicationGateway.Definition.IWithSslCert.DefineSslCertificate(string name)
        {
            return this.DefineSslCertificate(name) as ApplicationGatewaySslCertificate.Definition.IBlank<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Removes a frontend listener from the application gateway.
        /// Note that removing a listener referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="name">The name of the listener to remove.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithListener.WithoutListener(string name)
        {
            return this.WithoutListener(name) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new application gateway listener to be attached to the gateway.
        /// </summary>
        /// <param name="name">A unique name for the listener.</param>
        /// <return>The first stage of the listener definition.</return>
        ApplicationGatewayListener.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate> ApplicationGateway.Update.IWithListener.DefineListener(string name)
        {
            return this.DefineListener(name) as ApplicationGatewayListener.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the update of a listener.
        /// </summary>
        /// <param name="name">The name of an existing listener to update.</param>
        /// <return>The next stage of the definition or null if the requested listener does not exist.</return>
        ApplicationGatewayListener.Update.IUpdate ApplicationGateway.Update.IWithListener.UpdateListener(string name)
        {
            return this.UpdateListener(name) as ApplicationGatewayListener.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new application gateway listener to be attached to the gateway.
        /// </summary>
        /// <param name="name">A unique name for the listener.</param>
        /// <return>The first stage of the listener definition.</return>
        ApplicationGatewayListener.Definition.IBlank<ApplicationGateway.Definition.IWithCreate> ApplicationGateway.Definition.IWithListener.DefineListener(string name)
        {
            return this.DefineListener(name) as ApplicationGatewayListener.Definition.IBlank<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the size of the application gateway to use within the context of the selected tier.
        /// </summary>
        /// <param name="size">An application gateway size name.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithSize.WithSize(ApplicationGatewaySkuName size)
        {
            return this.WithSize(size) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the size of the application gateway to create within the context of the selected tier.
        /// By default, the smallest size is used.
        /// </summary>
        /// <param name="size">An application gateway SKU name.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate ApplicationGateway.Definition.IWithSize.WithSize(ApplicationGatewaySkuName size)
        {
            return this.WithSize(size) as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Removes the existing reference to a public IP address.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate HasPublicIpAddress.Update.IWithExistingPublicIpAddress<ApplicationGateway.Update.IUpdate>.WithoutPublicIpAddress()
        {
            return this.WithoutPublicIpAddress() as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIpAddress">An existing public IP address.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate HasPublicIpAddress.Update.IWithExistingPublicIpAddress<ApplicationGateway.Update.IUpdate>.WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            return this.WithExistingPublicIpAddress(publicIpAddress) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Update.IUpdate HasPublicIpAddress.Update.IWithExistingPublicIpAddress<ApplicationGateway.Update.IUpdate>.WithExistingPublicIpAddress(string resourceId)
        {
            return this.WithExistingPublicIpAddress(resourceId) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIpAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate HasPublicIpAddress.Definition.IWithExistingPublicIpAddress<ApplicationGateway.Definition.IWithCreate>.WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            return this.WithExistingPublicIpAddress(publicIpAddress) as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate HasPublicIpAddress.Definition.IWithExistingPublicIpAddress<ApplicationGateway.Definition.IWithCreate>.WithExistingPublicIpAddress(string resourceId)
        {
            return this.WithExistingPublicIpAddress(resourceId) as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that the application gateway should not be Internet-facing.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate ApplicationGateway.Definition.IWithPublicFrontend.WithoutPublicFrontend()
        {
            return this.WithoutPublicFrontend() as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Begins the update of a request routing rule.
        /// </summary>
        /// <param name="name">The name of an existing request routing rule.</param>
        /// <return>The first stage of a request routing rule update or null if the requested rule does not exist.</return>
        ApplicationGatewayRequestRoutingRule.Update.IUpdate ApplicationGateway.Update.IWithRequestRoutingRule.UpdateRequestRoutingRule(string name)
        {
            return this.UpdateRequestRoutingRule(name) as ApplicationGatewayRequestRoutingRule.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a request routing rule for this application gateway.
        /// </summary>
        /// <param name="name">A unique name for the request routing rule.</param>
        /// <return>The first stage of the request routing rule.</return>
        ApplicationGatewayRequestRoutingRule.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate> ApplicationGateway.Update.IWithRequestRoutingRule.DefineRequestRoutingRule(string name)
        {
            return this.DefineRequestRoutingRule(name) as ApplicationGatewayRequestRoutingRule.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Removes a request routing rule from the application gateway.
        /// </summary>
        /// <param name="name">The name of the request routing rule to remove.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithRequestRoutingRule.WithoutRequestRoutingRule(string name)
        {
            return this.WithoutRequestRoutingRule(name) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a request routing rule for this application gateway.
        /// </summary>
        /// <param name="name">A unique name for the request routing rule.</param>
        /// <return>The first stage of the request routing rule.</return>
        ApplicationGatewayRequestRoutingRule.Definition.IBlank<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate> ApplicationGateway.Definition.IWithRequestRoutingRule.DefineRequestRoutingRule(string name)
        {
            return this.DefineRequestRoutingRule(name) as ApplicationGatewayRequestRoutingRule.Definition.IBlank<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>;
        }

        /// <summary>
        /// Creates a frontend port with an auto-generated name and the specified port number, unless one already exists.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithFrontendPort.WithFrontendPort(int portNumber)
        {
            return this.WithFrontendPort(portNumber) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Creates a frontend port with the specified name and port number, unless a port matching this name and/or number already exists.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <param name="name">The name to assign to the port.</param>
        /// <return>The next stage of the definition, or null if a port matching either the name or the number, but not both, already exists.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithFrontendPort.WithFrontendPort(int portNumber, string name)
        {
            return this.WithFrontendPort(portNumber, name) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Removes the specified frontend port.
        /// Note that removing a frontend port referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="name">The name of the frontend port to remove.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithFrontendPort.WithoutFrontendPort(string name)
        {
            return this.WithoutFrontendPort(name) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Removes the specified frontend port.
        /// Note that removing a frontend port referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="portNumber">The port number of the frontend port to remove.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithFrontendPort.WithoutFrontendPort(int portNumber)
        {
            return this.WithoutFrontendPort(portNumber) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Creates a frontend port with an auto-generated name and the specified port number, unless one already exists.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate ApplicationGateway.Definition.IWithFrontendPort.WithFrontendPort(int portNumber)
        {
            return this.WithFrontendPort(portNumber) as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a frontend port with the specified name and port number, unless a port matching this name and/or number already exists.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <param name="name">The name to assign to the port.</param>
        /// <return>The next stage of the definition, or null if a port matching either the name or the number, but not both, already exists.</return>
        ApplicationGateway.Definition.IWithCreate ApplicationGateway.Definition.IWithFrontendPort.WithFrontendPort(int portNumber, string name)
        {
            return this.WithFrontendPort(portNumber, name) as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Begins the definition of the default public frontend IP configuration, creating one if it does not already exist.
        /// </summary>
        /// <return>The first stage of a frontend definition.</return>
        ApplicationGatewayFrontend.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate> ApplicationGateway.Update.IWithFrontend.DefinePublicFrontend()
        {
            return this.DefinePublicFrontend() as ApplicationGatewayFrontend.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies that the application gateway should not be Internet-facing.
        /// Note that if there are any other settings referencing the public frontend, removing it may break the application gateway.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithFrontend.WithoutPublicFrontend()
        {
            return this.WithoutPublicFrontend() as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Begins the update of the public frontend IP configuration, if it exists.
        /// </summary>
        /// <return>The first stage of a frontend update or null if no public frontend exists.</return>
        ApplicationGatewayFrontend.Update.IUpdate ApplicationGateway.Update.IWithFrontend.UpdatePublicFrontend()
        {
            return this.UpdatePublicFrontend() as ApplicationGatewayFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of the default private frontend IP configuration, creating one if it does not already exist.
        /// </summary>
        /// <return>The first stage of a frontend definition.</return>
        ApplicationGatewayFrontend.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate> ApplicationGateway.Update.IWithFrontend.DefinePrivateFrontend()
        {
            return this.DefinePrivateFrontend() as ApplicationGatewayFrontend.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies that the application gateway should not be private, i.e. its endponts should not be internally accessible
        /// from within the virtual network.
        /// Note that if there are any other settings referencing the private frontend, removing it may break the application gateway.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithFrontend.WithoutPrivateFrontend()
        {
            return this.WithoutPrivateFrontend() as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Removes the specified frontend IP configuration.
        /// Note that removing a frontend referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="frontendName">The name of the frontend IP configuration to remove.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithFrontend.WithoutFrontend(string frontendName)
        {
            return this.WithoutFrontend(frontendName) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Begins the update of an existing frontend IP configuration.
        /// </summary>
        /// <param name="frontendName">The name of an existing frontend IP configuration.</param>
        /// <return>The first stage of the frontend IP configuration update.</return>
        ApplicationGatewayFrontend.Update.IUpdate ApplicationGateway.Update.IWithFrontend.UpdateFrontend(string frontendName)
        {
            return this.UpdateFrontend(frontendName) as ApplicationGatewayFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Removes the specified backend HTTP configuration from this application gateway.
        /// Note that removing a backend HTTP configuration referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="name">The name of an existing backend HTTP configuration on this application gateway.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithBackendHttpConfig.WithoutBackendHttpConfiguration(string name)
        {
            return this.WithoutBackendHttpConfiguration(name) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Begins the update of a backend HTTP configuration.
        /// </summary>
        /// <param name="name">The name of an existing backend HTTP configuration on this application gateway.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate ApplicationGateway.Update.IWithBackendHttpConfig.UpdateBackendHttpConfiguration(string name)
        {
            return this.UpdateBackendHttpConfiguration(name) as ApplicationGatewayBackendHttpConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new application gateway backend HTTP configuration to be attached to the gateway.
        /// </summary>
        /// <param name="name">A unique name for the backend HTTP configuration.</param>
        /// <return>The first stage of the backend HTTP configuration definition.</return>
        ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate> ApplicationGateway.Update.IWithBackendHttpConfig.DefineBackendHttpConfiguration(string name)
        {
            return this.DefineBackendHttpConfiguration(name) as ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the definition of a new application gateway backend HTTP configuration to be attached to the gateway.
        /// </summary>
        /// <param name="name">A unique name for the backend HTTP configuration.</param>
        /// <return>The first stage of the backend HTTP configuration definition.</return>
        ApplicationGatewayBackendHttpConfiguration.Definition.IBlank<ApplicationGateway.Definition.IWithCreate> ApplicationGateway.Definition.IWithBackendHttpConfig.DefineBackendHttpConfiguration(string name)
        {
            return this.DefineBackendHttpConfiguration(name) as ApplicationGatewayBackendHttpConfiguration.Definition.IBlank<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies that no private (internal) frontend should be enabled.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate ApplicationGateway.Definition.IWithPrivateFrontend.WithoutPrivateFrontend()
        {
            return this.WithoutPrivateFrontend() as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables a private (internal) default frontend in the subnet containing the application gateway.
        /// A frontend with the name "default" will be created if needed.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate ApplicationGateway.Definition.IWithPrivateFrontend.WithPrivateFrontend()
        {
            return this.WithPrivateFrontend() as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Assigns the specified subnet to this resource.
        /// </summary>
        /// <param name="parentNetworkResourceId">The resource ID of the virtual network the subnet is part of.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Update.IWithSubnet<ApplicationGateway.Update.IUpdate>.WithExistingSubnet(string parentNetworkResourceId, string subnetName)
        {
            return this.WithExistingSubnet(parentNetworkResourceId, subnetName) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Assigns the specified subnet to this resource.
        /// </summary>
        /// <param name="parentNetworkResourceId">The resource ID of the virtual network the subnet is part of.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate Microsoft.Azure.Management.Resource.Fluent.Core.HasSubnet.Definition.IWithSubnet<ApplicationGateway.Definition.IWithCreate>.WithExistingSubnet(string parentNetworkResourceId, string subnetName)
        {
            return this.WithExistingSubnet(parentNetworkResourceId, subnetName) as ApplicationGateway.Definition.IWithCreate;
        }
    }
}