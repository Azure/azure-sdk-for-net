// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.HybridConnectivity.Models;

namespace Azure.ResourceManager.HybridConnectivity
{
    // these customization code is added to maintain backward compatibility for the method GetIngressGatewayCredentials and GetIngressGatewayCredentialsAsync,
    // which have added new optional parameters.
    public partial class HybridConnectivityEndpointResource : ArmResource
    {
        /// <summary>
        /// Gets the ingress gateway endpoint credentials.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{resourceUri}/providers/Microsoft.HybridConnectivity/endpoints/{endpointName}/listIngressGatewayCredentials</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EndpointResources_ListIngressGatewayCredentials</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="HybridConnectivityEndpointResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expiresin"> The is how long the endpoint access token is valid (in seconds). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IngressGatewayAsset>> GetIngressGatewayCredentialsAsync(long? expiresin, CancellationToken cancellationToken)
        {
            return await GetIngressGatewayCredentialsAsync(null, expiresin, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the ingress gateway endpoint credentials.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{resourceUri}/providers/Microsoft.HybridConnectivity/endpoints/{endpointName}/listIngressGatewayCredentials</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EndpointResources_ListIngressGatewayCredentials</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="HybridConnectivityEndpointResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expiresin"> The is how long the endpoint access token is valid (in seconds). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IngressGatewayAsset> GetIngressGatewayCredentials(long? expiresin, CancellationToken cancellationToken)
        {
            return GetIngressGatewayCredentials(null, expiresin, cancellationToken);
        }
    }
}
