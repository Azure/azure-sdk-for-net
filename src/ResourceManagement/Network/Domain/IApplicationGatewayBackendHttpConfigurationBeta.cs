// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// A client-side representation of an application gateway's backend HTTP configuration.
    /// </summary>
    public interface IApplicationGatewayBackendHttpConfigurationBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets the probe associated with this backend.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayProbe Probe { get; }
    }
}