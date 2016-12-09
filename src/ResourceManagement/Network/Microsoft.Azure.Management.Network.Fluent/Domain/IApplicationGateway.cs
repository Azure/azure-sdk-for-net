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
        IHasManager<Microsoft.Azure.Management.Network.Fluent.NetworkManager>
    {
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend> Frontends { get; }

        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener> Listeners();

        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewaySslCertificate> SslCertificates { get; }

        Models.ApplicationGatewaySslPolicy SslPolicy { get; }

        /// <summary>
        /// Finds a frontend listener associated with the specified frontend port number, if any.
        /// </summary>
        /// <param name="portNumber">A used port number.</param>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener ListenerByPortNumber(int portNumber);

        bool IsPrivate { get; }

        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfiguration> BackendHttpConfigurations { get; }

        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend DefaultPrivateFrontend { get; }

        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackend> Backends { get; }

        System.Collections.Generic.IReadOnlyDictionary<string,int> FrontendPorts { get; }

        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule> RequestRoutingRules { get; }

        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayIpConfiguration> IpConfigurations { get; }

        Models.ApplicationGatewaySkuName Size { get; }

        Models.ApplicationGatewayTier Tier { get; }

        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayIpConfiguration DefaultIpConfiguration { get; }

        int InstanceCount { get; }

        bool IsPublic { get; }

        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend> PublicFrontends { get; }

        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend DefaultPublicFrontend { get; }

        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayFrontend> PrivateFrontends { get; }

        /// <summary>
        /// Returns the name of the existing port, if any, that is associated with the specified port number.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        string FrontendPortNameFromNumber(int portNumber);

        Models.ApplicationGatewayOperationalState OperationalState { get; }

        Models.ApplicationGatewaySku Sku { get; }
    }
}