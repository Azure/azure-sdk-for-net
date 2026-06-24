// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/60100: for this extension-scope
    // (arbitrary resourceUri) list, the generator emits only the low-level Events REST operation, not a
    // public ArmClient extension method. Preserve the GA API by forwarding to the mockable implementation.
    // TODO: Remove once the emitter ships the #60102 fix that emits this extension method directly.
    public static partial class ResourceHealthExtensions
    {
        /// <summary> Lists service health events for a single resource. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceHealthEventData"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public static AsyncPageable<ResourceHealthEventData> GetHealthEventsOfSingleResourceAsync(this ArmClient client, ResourceIdentifier scope, string filter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableResourceHealthArmClient(client).GetHealthEventsOfSingleResourceAsync(scope, filter, cancellationToken);
        }

        /// <summary> Lists service health events for a single resource. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceHealthEventData"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public static Pageable<ResourceHealthEventData> GetHealthEventsOfSingleResource(this ArmClient client, ResourceIdentifier scope, string filter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableResourceHealthArmClient(client).GetHealthEventsOfSingleResource(scope, filter, cancellationToken);
        }
    }
}
