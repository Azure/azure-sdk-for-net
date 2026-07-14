// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceHealth
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/60100: the generator wraps this
    // extension-scoped (arbitrary resourceUri) list into ResourceHealthEventResource, but the GA surface
    // returns the ResourceHealthEventData model. Forward to the mockable implementation to preserve the GA API.
    // TODO: Remove once the emitter stops wrapping extension-scoped resource list results into the resource type.
    [CodeGenSuppress("GetHealthEventsOfSingleResourceAsync", typeof(ArmClient), typeof(ResourceIdentifier), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetHealthEventsOfSingleResource", typeof(ArmClient), typeof(ResourceIdentifier), typeof(string), typeof(CancellationToken))]
    public static partial class ResourceHealthExtensions
    {
        /// <summary> Lists current service health events for given resource. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> The filter to apply on the operation. For more information please see https://docs.microsoft.com/en-us/rest/api/apimanagement/apis?redirectedfrom=MSDN. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> A collection of <see cref="ResourceHealthEventData"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public static AsyncPageable<ResourceHealthEventData> GetHealthEventsOfSingleResourceAsync(this ArmClient client, ResourceIdentifier scope, string filter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableResourceHealthArmClient(client).GetHealthEventsOfSingleResourceAsync(scope, filter, cancellationToken);
        }

        /// <summary> Lists current service health events for given resource. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> The filter to apply on the operation. For more information please see https://docs.microsoft.com/en-us/rest/api/apimanagement/apis?redirectedfrom=MSDN. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> A collection of <see cref="ResourceHealthEventData"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public static Pageable<ResourceHealthEventData> GetHealthEventsOfSingleResource(this ArmClient client, ResourceIdentifier scope, string filter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableResourceHealthArmClient(client).GetHealthEventsOfSingleResource(scope, filter, cancellationToken);
        }
    }
}
