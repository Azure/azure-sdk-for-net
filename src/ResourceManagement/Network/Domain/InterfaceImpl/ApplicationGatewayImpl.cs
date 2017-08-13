// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIPConfiguration.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIPConfiguration.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasPrivateIPAddress.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.HasSubnet.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.HasSubnet.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    internal partial class ApplicationGatewayImpl 
    {
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
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithBackend.WithoutBackendIPAddress(string ipAddress)
        {
            return this.WithoutBackendIPAddress(ipAddress) as ApplicationGateway.Update.IUpdate;
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
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasSubnet.SubnetName
        {
            get
            {
                return this.SubnetName();
            }
        }

        /// <summary>
        /// Gets the resource ID of the virtual network whose subnet is associated with this resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasSubnet.NetworkId
        {
            get
            {
                return this.NetworkId();
            }
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken) as Microsoft.Azure.Management.Network.Fluent.IApplicationGateway;
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
        /// Private (internal) front ends, if any have been enabled, will be configured to use this subnet as well.
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
        /// <param name="instanceCount">The capacity as a number between 1 and 10 but also based on the limits imposed by the selected application gateway size.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate ApplicationGateway.Definition.IWithInstanceCount.WithInstanceCount(int instanceCount)
        {
            return this.WithInstanceCount(instanceCount) as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Gets the private IP address allocation method within the associated subnet.
        /// </summary>
        Models.IPAllocationMethod Microsoft.Azure.Management.Network.Fluent.IHasPrivateIPAddress.PrivateIPAllocationMethod
        {
            get
            {
                return this.PrivateIPAllocationMethod() as Models.IPAllocationMethod;
            }
        }

        /// <summary>
        /// Gets the private IP address associated with this resource.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IHasPrivateIPAddress.PrivateIPAddress
        {
            get
            {
                return this.PrivateIPAddress();
            }
        }

        /// <summary>
        /// Gets frontend IP configurations with a private IP address within a subnet, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend> Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.PrivateFrontends
        {
            get
            {
                return this.PrivateFrontends() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend>;
            }
        }

        /// <summary>
        /// Gets disabled SSL protocols.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<Models.ApplicationGatewaySslProtocol> Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBeta.DisabledSslProtocols
        {
            get
            {
                return this.DisabledSslProtocols() as System.Collections.Generic.IReadOnlyCollection<Models.ApplicationGatewaySslProtocol>;
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
        /// Gets the existing IP configurations if only one exists, else null.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayIPConfiguration Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.DefaultIPConfiguration
        {
            get
            {
                return this.DefaultIPConfiguration() as Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayIPConfiguration;
            }
        }

        /// <summary>
        /// Starts the application gateway.
        /// </summary>
        void Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.Start()
        {
 
            this.Start();
        }

        /// <summary>
        /// Finds a front end listener associated with the specified front end port number, if any.
        /// </summary>
        /// <param name="portNumber">A used port number.</param>
        /// <return>A front end listener, or null if none found.</return>
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
        /// Stops the application gateway asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.StopAsync(CancellationToken cancellationToken)
        {
 
            await this.StopAsync(cancellationToken);
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
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayIPConfiguration> Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.IPConfigurations
        {
            get
            {
                return this.IPConfigurations() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayIPConfiguration>;
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
        /// Gets frontend listeners, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener> Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.Listeners
        {
            get
            {
                return this.Listeners() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener>;
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

        /// <summary>
        /// Stops the application gateway.
        /// </summary>
        void Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.Stop()
        {
 
            this.Stop();
        }

        /// <summary>
        /// Starts the application gateway asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.StartAsync(CancellationToken cancellationToken)
        {
 
            await this.StartAsync(cancellationToken);
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
        /// Gets probes of this application gateway, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayProbe> Microsoft.Azure.Management.Network.Fluent.IApplicationGateway.Probes
        {
            get
            {
                return this.Probes() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayProbe>;
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
        /// Enables the specified SSL protocols, if previously disabled.
        /// </summary>
        /// <param name="protocols">SSL protocols.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithDisabledSslProtocolBeta.WithoutDisabledSslProtocols(params ApplicationGatewaySslProtocol[] protocols)
        {
            return this.WithoutDisabledSslProtocols(protocols) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Enables all SSL protocols, if previously disabled.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithDisabledSslProtocolBeta.WithoutAnyDisabledSslProtocols()
        {
            return this.WithoutAnyDisabledSslProtocols() as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Disables the specified SSL protocol.
        /// </summary>
        /// <param name="protocol">An SSL protocol.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithDisabledSslProtocolBeta.WithDisabledSslProtocol(ApplicationGatewaySslProtocol protocol)
        {
            return this.WithDisabledSslProtocol(protocol) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Disables the specified SSL protocols.
        /// </summary>
        /// <param name="protocols">SSL protocols.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithDisabledSslProtocolBeta.WithDisabledSslProtocols(params ApplicationGatewaySslProtocol[] protocols)
        {
            return this.WithDisabledSslProtocols(protocols) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Enables the specified SSL protocol, if previously disabled.
        /// </summary>
        /// <param name="protocol">An SSL protocol.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithDisabledSslProtocolBeta.WithoutDisabledSslProtocol(ApplicationGatewaySslProtocol protocol)
        {
            return this.WithoutDisabledSslProtocol(protocol) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Disables the specified SSL protocol.
        /// </summary>
        /// <param name="protocol">An SSL protocol.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate ApplicationGateway.Definition.IWithDisabledSslProtocolBeta.WithDisabledSslProtocol(ApplicationGatewaySslProtocol protocol)
        {
            return this.WithDisabledSslProtocol(protocol) as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Disables the specified SSL protocols.
        /// </summary>
        /// <param name="protocols">SSL protocols.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate ApplicationGateway.Definition.IWithDisabledSslProtocolBeta.WithDisabledSslProtocols(params ApplicationGatewaySslProtocol[] protocols)
        {
            return this.WithDisabledSslProtocols(protocols) as ApplicationGateway.Definition.IWithCreate;
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
        /// Removes the existing reference to a public IP address.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate HasPublicIPAddress.Update.IWithExistingPublicIPAddress<ApplicationGateway.Update.IUpdate>.WithoutPublicIPAddress()
        {
            return this.WithoutPublicIPAddress() as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate HasPublicIPAddress.Update.IWithExistingPublicIPAddress<ApplicationGateway.Update.IUpdate>.WithExistingPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return this.WithExistingPublicIPAddress(publicIPAddress) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Update.IUpdate HasPublicIPAddress.Update.IWithExistingPublicIPAddress<ApplicationGateway.Update.IUpdate>.WithExistingPublicIPAddress(string resourceId)
        {
            return this.WithExistingPublicIPAddress(resourceId) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="publicIPAddress">An existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate HasPublicIPAddress.Definition.IWithExistingPublicIPAddress<ApplicationGateway.Definition.IWithCreate>.WithExistingPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            return this.WithExistingPublicIPAddress(publicIPAddress) as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Associates an existing public IP address with the resource.
        /// </summary>
        /// <param name="resourceId">The resource ID of an existing public IP address.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate HasPublicIPAddress.Definition.IWithExistingPublicIPAddress<ApplicationGateway.Definition.IWithCreate>.WithExistingPublicIPAddress(string resourceId)
        {
            return this.WithExistingPublicIPAddress(resourceId) as ApplicationGateway.Definition.IWithCreate;
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
        /// Specifies that the application gateway should not be Internet-facing.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate ApplicationGateway.Definition.IWithPublicFrontend.WithoutPublicFrontend()
        {
            return this.WithoutPublicFrontend() as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a new public IP address to associate with the resource.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Update.IUpdate HasPublicIPAddress.Update.IWithNewPublicIPAddressNoDnsLabel<ApplicationGateway.Update.IUpdate>.WithNewPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> creatable)
        {
            return this.WithNewPublicIPAddress(creatable) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Update.IUpdate HasPublicIPAddress.Update.IWithNewPublicIPAddressNoDnsLabel<ApplicationGateway.Update.IUpdate>.WithNewPublicIPAddress()
        {
            return this.WithNewPublicIPAddress() as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Creates a new public IP address to associate with the resource.
        /// </summary>
        /// <param name="creatable">A creatable definition for a new public IP.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate HasPublicIPAddress.Definition.IWithNewPublicIPAddressNoDnsLabel<ApplicationGateway.Definition.IWithCreate>.WithNewPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> creatable)
        {
            return this.WithNewPublicIPAddress(creatable) as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a new public IP address in the same region and group as the resource and associates it with the resource.
        /// The internal name and DNS label for the public IP address will be derived from the resource's name.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate HasPublicIPAddress.Definition.IWithNewPublicIPAddressNoDnsLabel<ApplicationGateway.Definition.IWithCreate>.WithNewPublicIPAddress()
        {
            return this.WithNewPublicIPAddress() as ApplicationGateway.Definition.IWithCreate;
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
        /// Creates a front end port with an auto-generated name and the specified port number, unless one already exists.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithFrontendPort.WithFrontendPort(int portNumber)
        {
            return this.WithFrontendPort(portNumber) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Creates a front end port with the specified name and port number, unless a port matching this name and/or number already exists.
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
        /// Assigns the specified static private IP address within the associated subnet.
        /// </summary>
        /// <param name="ipAddress">A static IP address within the associated private IP range.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate HasPrivateIPAddress.Definition.IWithPrivateIPAddress<ApplicationGateway.Definition.IWithCreate>.WithPrivateIPAddressStatic(string ipAddress)
        {
            return this.WithPrivateIPAddressStatic(ipAddress) as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Enables dynamic private IP address allocation within the associated subnet.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate HasPrivateIPAddress.Definition.IWithPrivateIPAddress<ApplicationGateway.Definition.IWithCreate>.WithPrivateIPAddressDynamic()
        {
            return this.WithPrivateIPAddressDynamic() as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Begins the definition of the default public front end IP configuration, creating one if it does not already exist.
        /// </summary>
        /// <return>The first stage of a front end definition.</return>
        ApplicationGatewayFrontend.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate> ApplicationGateway.Update.IWithFrontend.DefinePublicFrontend()
        {
            return this.DefinePublicFrontend() as ApplicationGatewayFrontend.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies that the application gateway should not be Internet-facing.
        /// Note that if there are any other settings referencing the public front end, removing it may break the application gateway.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithFrontend.WithoutPublicFrontend()
        {
            return this.WithoutPublicFrontend() as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Begins the update of the public front end IP configuration, if it exists.
        /// </summary>
        /// <return>The first stage of a front end update or null if no public front end exists.</return>
        ApplicationGatewayFrontend.Update.IUpdate ApplicationGateway.Update.IWithFrontend.UpdatePublicFrontend()
        {
            return this.UpdatePublicFrontend() as ApplicationGatewayFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of the default private front end IP configuration, creating one if it does not already exist.
        /// </summary>
        /// <return>The first stage of a front end definition.</return>
        ApplicationGatewayFrontend.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate> ApplicationGateway.Update.IWithFrontend.DefinePrivateFrontend()
        {
            return this.DefinePrivateFrontend() as ApplicationGatewayFrontend.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies that the application gateway should not be private, i.e. its endpoints should not be internally accessible
        /// from within the virtual network.
        /// Note that if there are any other settings referencing the private front end, removing it may break the application gateway.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithFrontend.WithoutPrivateFrontend()
        {
            return this.WithoutPrivateFrontend() as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Removes the specified front end IP configuration.
        /// Note that removing a front end referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="frontendName">The name of the front end IP configuration to remove.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithFrontend.WithoutFrontend(string frontendName)
        {
            return this.WithoutFrontend(frontendName) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Begins the update of an existing front end IP configuration.
        /// </summary>
        /// <param name="frontendName">The name of an existing front end IP configuration.</param>
        /// <return>The first stage of the front end IP configuration update.</return>
        ApplicationGatewayFrontend.Update.IUpdate ApplicationGateway.Update.IWithFrontend.UpdateFrontend(string frontendName)
        {
            return this.UpdateFrontend(frontendName) as ApplicationGatewayFrontend.Update.IUpdate;
        }

        /// <summary>
        /// Begins the update of an existing IP configuration.
        /// </summary>
        /// <param name="ipConfigurationName">The name of an existing IP configuration.</param>
        /// <return>The first stage of an IP configuration update.</return>
        ApplicationGatewayIPConfiguration.Update.IUpdate ApplicationGateway.Update.IWithIPConfig.UpdateIPConfiguration(string ipConfigurationName)
        {
            return this.UpdateIPConfiguration(ipConfigurationName) as ApplicationGatewayIPConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of the default IP configuration.
        /// If a default IP configuration already exists, it will be this is equivalent to <code>updateDefaultIPConfiguration()</code>.
        /// </summary>
        /// <return>The first stage of an IP configuration update.</return>
        ApplicationGatewayIPConfiguration.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate> ApplicationGateway.Update.IWithIPConfig.DefineDefaultIPConfiguration()
        {
            return this.DefineDefaultIPConfiguration() as ApplicationGatewayIPConfiguration.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Removes the specified IP configuration.
        /// Note that removing an IP configuration referenced by other settings may break the application gateway.
        /// Also, there must be at least one IP configuration for the application gateway to function.
        /// </summary>
        /// <param name="ipConfigurationName">The name of the IP configuration to remove.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithIPConfig.WithoutIPConfiguration(string ipConfigurationName)
        {
            return this.WithoutIPConfiguration(ipConfigurationName) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Begins the update of the default IP configuration i.e. the only one IP configuration that exists, assuming only one exists.
        /// </summary>
        /// <return>The first stage of an IP configuration update.</return>
        ApplicationGatewayIPConfiguration.Update.IUpdate ApplicationGateway.Update.IWithIPConfig.UpdateDefaultIPConfiguration()
        {
            return this.UpdateDefaultIPConfiguration() as ApplicationGatewayIPConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Begins the update of an existing probe.
        /// </summary>
        /// <param name="name">The name of an existing probe.</param>
        /// <return>The first stage of a probe update.</return>
        ApplicationGatewayProbe.Update.IUpdate ApplicationGateway.Update.IWithProbe.UpdateProbe(string name)
        {
            return this.UpdateProbe(name) as ApplicationGatewayProbe.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new probe.
        /// </summary>
        /// <param name="name">A unique name for the probe.</param>
        /// <return>The first stage of a probe definition.</return>
        ApplicationGatewayProbe.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate> ApplicationGateway.Update.IWithProbe.DefineProbe(string name)
        {
            return this.DefineProbe(name) as ApplicationGatewayProbe.UpdateDefinition.IBlank<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Removes a probe from the application gateway.
        /// Any references to this probe from backend HTTP configurations will be automatically removed.
        /// </summary>
        /// <param name="name">The name of an existing probe.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGateway.Update.IUpdate ApplicationGateway.Update.IWithProbe.WithoutProbe(string name)
        {
            return this.WithoutProbe(name) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Begins the definition of a new probe.
        /// </summary>
        /// <param name="name">A unique name for the probe.</param>
        /// <return>The first stage of a probe definition.</return>
        ApplicationGatewayProbe.Definition.IBlank<ApplicationGateway.Definition.IWithCreate> ApplicationGateway.Definition.IWithProbe.DefineProbe(string name)
        {
            return this.DefineProbe(name) as ApplicationGatewayProbe.Definition.IBlank<ApplicationGateway.Definition.IWithCreate>;
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
        /// Enables a private (internal) default frontend within the subnet containing the application gateway.
        /// A frontend with an automatically generated name will be created if none exists.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate ApplicationGateway.Definition.IWithPrivateFrontend.WithPrivateFrontend()
        {
            return this.WithPrivateFrontend() as ApplicationGateway.Definition.IWithCreate;
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
        /// Assigns the specified subnet to this resource.
        /// </summary>
        /// <param name="parentNetworkResourceId">The resource ID of the virtual network the subnet is part of.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.HasSubnet.Update.IWithSubnet<ApplicationGateway.Update.IUpdate>.WithExistingSubnet(string parentNetworkResourceId, string subnetName)
        {
            return this.WithExistingSubnet(parentNetworkResourceId, subnetName) as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Assigns the specified subnet to this resource.
        /// </summary>
        /// <param name="parentNetworkResourceId">The resource ID of the virtual network the subnet is part of.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGateway.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.HasSubnet.Definition.IWithSubnet<ApplicationGateway.Definition.IWithCreate>.WithExistingSubnet(string parentNetworkResourceId, string subnetName)
        {
            return this.WithExistingSubnet(parentNetworkResourceId, subnetName) as ApplicationGateway.Definition.IWithCreate;
        }
    }
}