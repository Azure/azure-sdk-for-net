// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an application gateway request routing rule.
    /// </summary>
    public interface IApplicationGatewayRequestRoutingRule  :
        IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ApplicationGatewayRequestRoutingRuleInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        Microsoft.Azure.Management.Network.Fluent.IHasPublicIPAddress,
        Microsoft.Azure.Management.Network.Fluent.IHasSslCertificate<Microsoft.Azure.Management.Network.Fluent.IApplicationGatewaySslCertificate>,
        Microsoft.Azure.Management.Network.Fluent.IHasFrontendPort,
        Microsoft.Azure.Management.Network.Fluent.IHasBackendPort,
        Microsoft.Azure.Management.Network.Fluent.IHasHostName,
        Microsoft.Azure.Management.Network.Fluent.IHasCookieBasedAffinity,
        Microsoft.Azure.Management.Network.Fluent.IHasServerNameIndication
    {
        /// <summary>
        /// Gets rule type.
        /// </summary>
        Models.ApplicationGatewayRequestRoutingRuleType RuleType { get; }

        /// <summary>
        /// Gets the associated backend address pool.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackend Backend { get; }

        /// <summary>
        /// Gets the associated frontend HTTP listener.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener Listener { get; }

        /// <summary>
        /// Gets the addresses assigned to the associated backend.
        /// </summary>
        System.Collections.Generic.IReadOnlyCollection<Models.ApplicationGatewayBackendAddress> BackendAddresses { get; }

        /// <summary>
        /// Gets the frontend protocol.
        /// </summary>
        Models.ApplicationGatewayProtocol FrontendProtocol { get; }

        /// <summary>
        /// Gets the associated backend HTTP settings configuration.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfiguration BackendHttpConfiguration { get; }
    }
}