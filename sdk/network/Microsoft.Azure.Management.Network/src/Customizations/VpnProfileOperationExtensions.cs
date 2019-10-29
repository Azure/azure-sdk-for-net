using System;

namespace Microsoft.Azure.Management.Network
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Serialization;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public static partial class VirtualNetworkGatewaysOperationsExtensions
    {
        /// <summary>
        /// Generates VPN profile for P2S client of the virtual network gateway in the
        /// specified resource group. Used for IKEV2 and radius based authentication.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkGatewayName'>
        /// The name of the virtual network gateway.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the generate virtual network gateway VPN client
        /// package operation.
        /// </param>
        public static string GenerateGatewayVpnProfile(this IVirtualNetworkGatewaysOperations operations, string resourceGroupName, string virtualNetworkGatewayName, VpnClientParameters parameters)
        {
            return GenerateGatewayVpnProfileAsync(operations, resourceGroupName, virtualNetworkGatewayName, parameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Generates VPN profile for P2S client of the virtual network gateway in the
        /// specified resource group. Used for IKEV2 and radius based authentication.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkGatewayName'>
        /// The name of the virtual network gateway.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the generate virtual network gateway VPN client
        /// package operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<string> GenerateGatewayVpnProfileAsync(this IVirtualNetworkGatewaysOperations operations,
            string resourceGroupName, string virtualNetworkGatewayName, VpnClientParameters parameters,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<string> result = await operations.GenerateGatewayVpnProfileWithHttpMessagesAsync(
                resourceGroupName,
                virtualNetworkGatewayName,
                parameters,
                null,
                cancellationToken).ConfigureAwait(false);

            return result.Body;
        }

        /// <summary>
        /// Gets pre-generated VPN profile for P2S client of the virtual network
        /// gateway in the specified resource group. The profile needs to be generated
        /// first using generateVpnProfile.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkGatewayName'>
        /// The name of the virtual network gateway.
        /// </param>
        public static string GetGatewayVpnProfile(this IVirtualNetworkGatewaysOperations operations, string resourceGroupName, string virtualNetworkGatewayName)
        {
            return GetGatewayVpnProfileAsync(operations, resourceGroupName, virtualNetworkGatewayName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets pre-generated VPN profile for P2S client of the virtual network
        /// gateway in the specified resource group. The profile needs to be generated
        /// first using generateVpnProfile.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkGatewayName'>
        /// The name of the virtual network gateway.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<string> GetGatewayVpnProfileAsync(this IVirtualNetworkGatewaysOperations operations,
            string resourceGroupName, 
            string virtualNetworkGatewayName,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<string> result = await operations.GetGatewayVpnProfileWithHttpMessagesAsync(
                resourceGroupName,
                virtualNetworkGatewayName,
                null,
                cancellationToken).ConfigureAwait(false);

            return result.Body;
        }
    }

    internal partial class VirtualNetworkGatewaysOperations : IServiceOperations<NetworkManagementClient>, IVirtualNetworkGatewaysOperations
    {
        /// <summary>
        /// Generates VPN profile for P2S client of the virtual network gateway
        /// in the specified resource group. Used for IKEV2 and radius based
        /// authentication.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkGatewayName'>
        /// The name of the virtual network gateway.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the generate virtual network gateway VPN
        /// client package operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        public async Task<AzureOperationResponse<string>> GenerateGatewayVpnProfileWithHttpMessagesAsync(
            string resourceGroupName, 
            string virtualNetworkGatewayName, 
            VpnClientParameters parameters,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.GenerateVpnProfileWithHttpMessagesAsync(resourceGroupName, virtualNetworkGatewayName, parameters, customHeaders, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets pre-generated VPN profile for P2S client of the virtual
        /// network gateway in the specified resource group. The profile needs
        /// to be generated first using generateVpnProfile.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkGatewayName'>
        /// The name of the virtual network gateway.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        public async Task<AzureOperationResponse<string>> GetGatewayVpnProfileWithHttpMessagesAsync(
            string resourceGroupName,
            string virtualNetworkGatewayName,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.GetVpnProfilePackageUrlWithHttpMessagesAsync(resourceGroupName, virtualNetworkGatewayName, customHeaders, cancellationToken).ConfigureAwait(false);
        }
    }
}
