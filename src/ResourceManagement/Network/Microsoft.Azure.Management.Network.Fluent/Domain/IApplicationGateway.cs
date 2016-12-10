// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGateway.Update;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point for application gateway management API in Azure.
    /// </summary>
    public interface IApplicationGateway  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        IWrapper<Models.ApplicationGatewayInner>,
        IUpdatable<ApplicationGateway.Update.IUpdate>,
        IHasSubnet,
        IHasPrivateIpAddress,
        IHasManager<Models.NetworkManager>
    {
        /// <summary>
        /// Gets frontend IP configurations, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend> Frontends { get; }

        /// <return>Frontend listeners, indexed by name.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener> Listeners();

        /// <summary>
        /// Gets SSL certificates, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewaySslCertificate> SslCertificates { get; }

        /// <summary>
        /// Gets the SSL policy for the application gateway.
        /// </summary>
        Models.ApplicationGatewaySslPolicy SslPolicy { get; }

        /// <summary>
        /// Finds a frontend listener associated with the specified frontend port number, if any.
        /// </summary>
        /// <param name="portNumber">A used port number.</param>
        /// <return>A frontend listener, or null if none found.</return>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener ListenerByPortNumber(int portNumber);

        /// <summary>
        /// Gets true if the application gateway has at least one internally load balanced frontend accessible within the virtual network.
        /// </summary>
        bool IsPrivate { get; }

        /// <summary>
        /// Gets backend HTTP configurations of this application gateway, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfiguration> BackendHttpConfigurations { get; }

        /// <summary>
        /// Gets the frontend IP configuration associated with a private IP address, if any, that frontend listeners and request routing rules can reference implicitly.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend DefaultPrivateFrontend { get; }

        /// <summary>
        /// Gets backend address pools of this application gateway, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackend> Backends { get; }

        /// <summary>
        /// Gets named frontend ports of this application gateway, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,int> FrontendPorts { get; }

        /// <summary>
        /// Gets request routing rules, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule> RequestRoutingRules { get; }

        /// <summary>
        /// Gets IP configurations of this application gateway, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayIpConfiguration> IpConfigurations { get; }

        /// <summary>
        /// Gets the size of the application gateway.
        /// </summary>
        Models.ApplicationGatewaySkuName Size { get; }

        /// <summary>
        /// Gets the tier of the application gateway.
        /// </summary>
        Models.ApplicationGatewayTier Tier { get; }

        /// <summary>
        /// Gets the IP configuration named "default" if it exists, or the one existing IP configuration if only one exists, else null.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayIpConfiguration DefaultIpConfiguration { get; }

        /// <summary>
        /// Gets number of instances.
        /// </summary>
        int InstanceCount { get; }

        /// <summary>
        /// Gets true if the application gateway has at least one Internet-facing frontend.
        /// </summary>
        bool IsPublic { get; }

        /// <summary>
        /// Gets frontend IP configurations with a public IP address, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend> PublicFrontends { get; }

        /// <summary>
        /// Gets the frontend IP configuration associated with a public IP address, if any, that frontend listeners and request routing rules can reference implicitly.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend DefaultPublicFrontend { get; }

        /// <summary>
        /// Gets frontend IP configurations with a private IP address on a subnet, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend> PrivateFrontends { get; }

        /// <summary>
        /// Returns the name of the existing port, if any, that is associated with the specified port number.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The existing port name for that port number, or null if none found.</return>
        string FrontendPortNameFromNumber(int portNumber);

        /// <summary>
        /// Gets the operational state of the application gateway.
        /// </summary>
        Models.ApplicationGatewayOperationalState OperationalState { get; }

        /// <summary>
        /// Gets the SKU of this application gateway.
        /// </summary>
        Models.ApplicationGatewaySku Sku { get; }
    }
}