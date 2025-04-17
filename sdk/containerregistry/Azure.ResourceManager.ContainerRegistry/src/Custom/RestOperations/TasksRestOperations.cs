// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.ContainerRegistry.Models;

namespace Azure.ResourceManager.ContainerRegistry
{
    internal partial class TasksRestOperations
    {
        /// <summary> Updates a task with the specified parameters. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. The value must be an UUID. </param>
        /// <param name="resourceGroupName"> The name of the resource group to which the container registry belongs. </param>
        /// <param name="registryName"> The name of the container registry. </param>
        /// <param name="taskName"> The name of the container registry task. </param>
        /// <param name="patch"> The parameters for updating a task. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="registryName"/>, <paramref name="taskName"/> or <paramref name="patch"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="registryName"/> or <paramref name="taskName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> UpdateAsync_v2019_06(string subscriptionId, string resourceGroupName, string registryName, string taskName, ContainerRegistryTaskPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(registryName, nameof(registryName));
            Argument.AssertNotNullOrEmpty(taskName, nameof(taskName));
            Argument.AssertNotNull(patch, nameof(patch));

            using var message = CreateUpdateRequest(subscriptionId, resourceGroupName, registryName, taskName, patch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Updates a task with the specified parameters. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. The value must be an UUID. </param>
        /// <param name="resourceGroupName"> The name of the resource group to which the container registry belongs. </param>
        /// <param name="registryName"> The name of the container registry. </param>
        /// <param name="taskName"> The name of the container registry task. </param>
        /// <param name="patch"> The parameters for updating a task. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="registryName"/>, <paramref name="taskName"/> or <paramref name="patch"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="registryName"/> or <paramref name="taskName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response Update_v2019_06(string subscriptionId, string resourceGroupName, string registryName, string taskName, ContainerRegistryTaskPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(registryName, nameof(registryName));
            Argument.AssertNotNullOrEmpty(taskName, nameof(taskName));
            Argument.AssertNotNull(patch, nameof(patch));

            using var message = CreateUpdateRequest(subscriptionId, resourceGroupName, registryName, taskName, patch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
