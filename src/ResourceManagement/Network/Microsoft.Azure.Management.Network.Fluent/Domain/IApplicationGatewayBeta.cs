// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Members of ApplicationGateway that are in Beta.
    /// </summary>
    public interface IApplicationGatewayBeta : IBeta
    {
        /// <summary>
        /// Disabled SSL protocols.
        /// </summary>
        IReadOnlyCollection<ApplicationGatewaySslProtocol> DisabledSslProtocols {  get; }
    }
}