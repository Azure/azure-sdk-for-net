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
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfiguration BackendHttpConfiguration { get; }

        Models.ApplicationGatewayRequestRoutingRuleType RuleType { get; }

        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener Listener();

        Models.ApplicationGatewayProtocol FrontendProtocol { get; }

        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackend Backend { get; }

        System.Collections.Generic.IList<Models.ApplicationGatewayBackendAddress> BackendAddresses { get; }
    }
}