// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// A client-side representation of an application gateway's backend HTTP configuration.
    /// </summary>
    public interface IApplicationGatewayBackendHttpConfiguration  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ApplicationGatewayBackendHttpSettingsInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        Microsoft.Azure.Management.Network.Fluent.IHasProtocol<Models.ApplicationGatewayProtocol>,
        Microsoft.Azure.Management.Network.Fluent.IHasPort,
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayBackendHttpConfigurationBeta
    {
        /// <summary>
        /// Gets true if cookie based affinity (sticky sessions) is enabled, else false.
        /// </summary>
        bool CookieBasedAffinity { get; }

        /// <summary>
        /// Gets HTTP request timeout in seconds. Requests will fail if no response is received within the specified time.
        /// </summary>
        int RequestTimeout { get; }

    }
}