// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an application gateway request routing rule.
    /// </summary>
    public interface IApplicationGatewayRequestRoutingRule  :
        IWrapper<Models.ApplicationGatewayRequestRoutingRuleInner>,
        IChildResource<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        IHasPublicIpAddress,
        IHasSslCertificate<Microsoft.Azure.Management.Network.Fluent.IApplicationGatewaySslCertificate>,
        IHasFrontendPort,
        IHasBackendPort,
        IHasHostName,
        IHasCookieBasedAffinity,
        IHasServerNameIndication
    {
        /// <summary>
        /// Gets the associated backend HTTP settings configuration.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfiguration BackendHttpConfiguration { get; }

        /// <summary>
        /// Gets rule type.
        /// </summary>
        Models.ApplicationGatewayRequestRoutingRuleType RuleType { get; }

        /// <return>The associated frontend HTTP listener.</return>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener Listener();

        /// <summary>
        /// Gets the frontend protocol.
        /// </summary>
        Models.ApplicationGatewayProtocol FrontendProtocol { get; }

        /// <summary>
        /// Gets the associated backend address pool.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackend Backend { get; }

        /// <summary>
        /// Gets the addresses assigned to the associated backend.
        /// </summary>
        System.Collections.Generic.IList<Models.ApplicationGatewayBackendAddress> BackendAddresses { get; }
    }
}