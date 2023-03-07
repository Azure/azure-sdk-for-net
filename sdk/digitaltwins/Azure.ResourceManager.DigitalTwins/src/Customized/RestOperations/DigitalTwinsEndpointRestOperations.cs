// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using System.Threading.Tasks;
using System.Threading;

namespace Azure.ResourceManager.DigitalTwins
{
    internal partial class DigitalTwinsEndpointRestOperations
    {
        /// <summary> Delete a DigitalTwinsInstance endpoint. </summary>
        /// <param name="subscriptionId"> The subscription identifier. </param>
        /// <param name="resourceGroupName"> The name of the resource group that contains the DigitalTwinsInstance. </param>
        /// <param name="resourceName"> The name of the DigitalTwinsInstance. </param>
        /// <param name="endpointName"> Name of Endpoint Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="resourceName"/> or <paramref name="endpointName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="resourceName"/> or <paramref name="endpointName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<DigitalTwinsEndpointResourceData>> DeleteAsync(string subscriptionId, string resourceGroupName, string resourceName, string endpointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(endpointName, nameof(endpointName));

            DigitalTwinsEndpointResourceData data = Get(subscriptionId, resourceGroupName, resourceName, endpointName, cancellationToken).Value;

            using var message = CreateDeleteRequest(subscriptionId, resourceGroupName, resourceName, endpointName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return Response.FromValue(data, message.Response);
                case 202:
                    return Response.FromValue(data, message.Response);
                case 204:
                    return Response.FromValue(data, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Delete a DigitalTwinsInstance endpoint. </summary>
        /// <param name="subscriptionId"> The subscription identifier. </param>
        /// <param name="resourceGroupName"> The name of the resource group that contains the DigitalTwinsInstance. </param>
        /// <param name="resourceName"> The name of the DigitalTwinsInstance. </param>
        /// <param name="endpointName"> Name of Endpoint Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="resourceName"/> or <paramref name="endpointName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="resourceName"/> or <paramref name="endpointName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<DigitalTwinsEndpointResourceData> Delete(string subscriptionId, string resourceGroupName, string resourceName, string endpointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(endpointName, nameof(endpointName));

            DigitalTwinsEndpointResourceData data = Get(subscriptionId, resourceGroupName, resourceName, endpointName, cancellationToken).Value;

            using var message = CreateDeleteRequest(subscriptionId, resourceGroupName, resourceName, endpointName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return Response.FromValue(data, message.Response);
                case 202:
                    return Response.FromValue(data, message.Response);
                case 204:
                    return Response.FromValue(data, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
