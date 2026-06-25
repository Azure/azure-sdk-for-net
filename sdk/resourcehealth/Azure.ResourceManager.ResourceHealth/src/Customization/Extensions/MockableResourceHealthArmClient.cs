// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceHealth.Mocking
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/60100: for this extension-scoped
    // (arbitrary resourceUri) list the generator wraps each page item into ResourceHealthEventResource, but
    // the GA surface returns the ResourceHealthEventData model (events listed at an arbitrary scope are not
    // addressable as the events resource). Re-emit over the generated data-typed collection results to
    // preserve the GA API.
    // TODO: Remove once the emitter stops wrapping extension-scoped resource list results into the resource type.
    [CodeGenSuppress("GetHealthEventsOfSingleResourceAsync", typeof(ResourceIdentifier), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetHealthEventsOfSingleResource", typeof(ResourceIdentifier), typeof(string), typeof(CancellationToken))]
    public partial class MockableResourceHealthArmClient
    {
        /// <summary> Lists current service health events for given resource. </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> The filter to apply on the operation. For more information please see https://docs.microsoft.com/en-us/rest/api/apimanagement/apis?redirectedfrom=MSDN. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        /// <returns> A collection of <see cref="ResourceHealthEventData"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResourceHealthEventData> GetHealthEventsOfSingleResourceAsync(ResourceIdentifier scope, string filter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));

            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new EventsGetHealthEventsOfSingleResourceAsyncCollectionResultOfT(EventsRestClient, scope.ToString(), filter, context, "MockableResourceHealthArmClient.GetHealthEventsOfSingleResource");
        }

        /// <summary> Lists current service health events for given resource. </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> The filter to apply on the operation. For more information please see https://docs.microsoft.com/en-us/rest/api/apimanagement/apis?redirectedfrom=MSDN. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        /// <returns> A collection of <see cref="ResourceHealthEventData"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResourceHealthEventData> GetHealthEventsOfSingleResource(ResourceIdentifier scope, string filter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));

            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new EventsGetHealthEventsOfSingleResourceCollectionResultOfT(EventsRestClient, scope.ToString(), filter, context, "MockableResourceHealthArmClient.GetHealthEventsOfSingleResource");
        }
    }
}
