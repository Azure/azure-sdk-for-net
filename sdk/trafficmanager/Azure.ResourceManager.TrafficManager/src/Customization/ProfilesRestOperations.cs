// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.TrafficManager.Models;

namespace Azure.ResourceManager.TrafficManager
{
    /// <summary>
    /// The class introduced as a way to overcome situation when the rest delete request results with HTTP 200 but does not provide any json content in the response.
    /// </summary>
    internal partial class ProfilesRestOperations
    {
        /// <summary> Deletes a Traffic Manager profile. </summary>
        /// <param name="subscriptionId"> Gets subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group containing the Traffic Manager profile to be deleted. </param>
        /// <param name="profileName"> The name of the Traffic Manager profile to be deleted. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="profileName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="profileName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<DeleteOperationResult>> DeleteAsync(string subscriptionId, string resourceGroupName, string profileName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(profileName, nameof(profileName));

            using var message = CreateDeleteRequest(subscriptionId, resourceGroupName, profileName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DeleteOperationResult value = new DeleteOperationResult(operationResult: true);
                        return Response.FromValue(value, message.Response);
                    }
                case 204:
                    return Response.FromValue((DeleteOperationResult)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
