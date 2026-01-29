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
    /// <summary>
    /// A Class representing a HybridConnectivityEndpoint along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="HybridConnectivityEndpointResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetHybridConnectivityEndpointResource method.
    /// Otherwise you can get one from its parent resource <see cref="ArmResource"/> using the GetHybridConnectivityEndpoint method.
    /// </summary>
    public partial class HybridConnectivityEndpointResource : ArmResource
    {
        /// <summary>
        /// Gets the endpoint access credentials to the resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{resourceUri}/providers/Microsoft.HybridConnectivity/endpoints/{endpointName}/listCredentials</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EndpointResources_ListCredentials</description>
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
        /// <param name="content"> Object of type ListCredentialsRequest. </param>
        /// <param name="expiresin"> The is how long the endpoint access token is valid (in seconds). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TargetResourceEndpointAccess>> GetCredentialsAsync(ListCredentialsContent content = null, long? expiresin = null, CancellationToken cancellationToken = default)
        {
            return await GetCredentialsAsync(expiresin, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the endpoint access credentials to the resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{resourceUri}/providers/Microsoft.HybridConnectivity/endpoints/{endpointName}/listCredentials</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EndpointResources_ListCredentials</description>
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
        /// <param name="content"> Object of type ListCredentialsRequest. </param>
        /// <param name="expiresin"> The is how long the endpoint access token is valid (in seconds). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TargetResourceEndpointAccess> GetCredentials(ListCredentialsContent content = null, long? expiresin = null, CancellationToken cancellationToken = default)
        {
            return GetCredentials(expiresin, content, cancellationToken);
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
        /// <param name="content"> Object of type ListIngressGatewayCredentialsRequest. </param>
        /// <param name="expiresin"> The is how long the endpoint access token is valid (in seconds). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IngressGatewayAsset>> GetIngressGatewayCredentialsAsync(ListIngressGatewayCredentialsContent content = null, long? expiresin = null, CancellationToken cancellationToken = default)
        {
            return await GetIngressGatewayCredentialsAsync(expiresin, content, cancellationToken).ConfigureAwait(false);
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
        /// <param name="content"> Object of type ListIngressGatewayCredentialsRequest. </param>
        /// <param name="expiresin"> The is how long the endpoint access token is valid (in seconds). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IngressGatewayAsset> GetIngressGatewayCredentials(ListIngressGatewayCredentialsContent content = null, long? expiresin = null, CancellationToken cancellationToken = default)
        {
            return GetIngressGatewayCredentials(expiresin, content, cancellationToken);
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
        public virtual async Task<Response<IngressGatewayAsset>> GetIngressGatewayCredentialsAsync(long? expiresin, CancellationToken cancellationToken)
        {
            return await GetIngressGatewayCredentialsAsync(expiresin, null, cancellationToken).ConfigureAwait(false);
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
            return GetIngressGatewayCredentials(expiresin, null, cancellationToken);
        }
    }
}
