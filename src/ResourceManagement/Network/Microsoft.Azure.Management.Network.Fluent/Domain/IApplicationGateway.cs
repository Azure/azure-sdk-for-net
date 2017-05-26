// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point for application gateway management API in Azure.
    /// </summary>
    public interface IApplicationGateway  :
        IApplicationGatewayBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.Network.Fluent.INetworkManager,Models.ApplicationGatewayInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<ApplicationGateway.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasSubnet,
        Microsoft.Azure.Management.Network.Fluent.IHasPrivateIPAddress
    {
        /// <summary>
        /// Stops the application gateway.
        /// </summary>
        void Stop();

        /// <summary>
        /// Gets backend address pools of this application gateway, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackend> Backends { get; }

        /// <summary>
        /// Finds a frontend listener associated with the specified frontend port number, if any.
        /// </summary>
        /// <param name="portNumber">A used port number.</param>
        /// <return>A frontend listener, or null if none found.</return>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener ListenerByPortNumber(int portNumber);

        /// <summary>
        /// Gets the tier of the application gateway.
        /// </summary>
        Models.ApplicationGatewayTier Tier { get; }

        /// <summary>
        /// Gets the operational state of the application gateway.
        /// </summary>
        Models.ApplicationGatewayOperationalState OperationalState { get; }

        /// <summary>
        /// Gets frontend IP configurations with a private IP address on a subnet, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend> PrivateFrontends { get; }

        /// <summary>
        /// Gets named frontend ports of this application gateway, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,int> FrontendPorts { get; }

        /// <summary>
        /// Gets probes of this application gateway, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayProbe> Probes { get; }

        /// <summary>
        /// Gets frontend IP configurations with a public IP address, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend> PublicFrontends { get; }

        /// <summary>
        /// Starts the application gateway asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task StartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the IP configuration named "default" if it exists, or the one existing IP configuration if only one exists, else null.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayIPConfiguration DefaultIPConfiguration { get; }

        /// <summary>
        /// Gets the frontend IP configuration associated with a public IP address, if any, that frontend listeners and request routing rules can reference implicitly.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend DefaultPublicFrontend { get; }

        /// <summary>
        /// Gets true if the application gateway has at least one internally load balanced frontend accessible within the virtual network.
        /// </summary>
        bool IsPrivate { get; }

        /// <summary>
        /// Gets IP configurations of this application gateway, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayIPConfiguration> IPConfigurations { get; }

        /// <summary>
        /// Gets number of instances.
        /// </summary>
        int InstanceCount { get; }

        /// <summary>
        /// Gets SSL certificates, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewaySslCertificate> SslCertificates { get; }

        /// <summary>
        /// Gets Frontend listeners, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener> Listeners { get; }

        /// <summary>
        /// Stops the application gateway asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task StopAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets true if the application gateway has at least one Internet-facing frontend.
        /// </summary>
        bool IsPublic { get; }

        /// <summary>
        /// Gets the SKU of this application gateway.
        /// </summary>
        Models.ApplicationGatewaySku Sku { get; }

        /// <summary>
        /// Gets request routing rules, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule> RequestRoutingRules { get; }

        /// <summary>
        /// Gets the size of the application gateway.
        /// </summary>
        Models.ApplicationGatewaySkuName Size { get; }

        /// <summary>
        /// Gets the SSL policy for the application gateway.
        /// </summary>
        Models.ApplicationGatewaySslPolicy SslPolicy { get; }

        /// <summary>
        /// Gets the frontend IP configuration associated with a private IP address, if any, that frontend listeners and request routing rules can reference implicitly.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend DefaultPrivateFrontend { get; }

        /// <summary>
        /// Starts the application gateway.
        /// </summary>
        void Start();

        /// <summary>
        /// Gets backend HTTP configurations of this application gateway, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfiguration> BackendHttpConfigurations { get; }

        /// <summary>
        /// Returns the name of the existing port, if any, that is associated with the specified port number.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The existing port name for that port number, or null if none found.</return>
        string FrontendPortNameFromNumber(int portNumber);

        /// <summary>
        /// Gets frontend IP configurations, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend> Frontends { get; }
    }
}