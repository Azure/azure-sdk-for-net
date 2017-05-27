// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Members of applucation gateway backend HTTP configuration that are in beta.
    /// </summary>
    public interface IApplicationGatewayBackendHttpConfigurationBeta : IBeta
    {
        /// <summary>
        /// Gets the probe associated with this backend  
        /// </summary>
        IApplicationGatewayProbe Probe { get; }
    }
}