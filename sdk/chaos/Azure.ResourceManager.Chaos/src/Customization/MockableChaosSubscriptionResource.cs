// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Chaos;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Chaos.Mocking
{
    // Customization: Suppresses the generator-emitted GetExperiments / GetExperimentsAsync names
    // and re-emits them under the shipped GetChaosExperiments / GetChaosExperimentsAsync names.
    // The generator now derives "GetExperiments" from the @@clientName(Experiments.listAll, "getExperiments")
    // override in the spec. The spec fix has been applied in azure-rest-api-specs#43122; this
    // customization can be removed (and the method body restored to generated form) once
    // tsp-location.yaml is bumped to a commit that contains the fix.
    [CodeGenSuppress("GetExperimentsAsync", typeof(bool?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetExperiments", typeof(bool?), typeof(string), typeof(CancellationToken))]
    public partial class MockableChaosSubscriptionResource
    {
        /// <summary> Gets a collection of ChaosTargetTypeResources in the SubscriptionResource. </summary>
        /// <param name="locationName"> String that represents a Location resource name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="locationName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="locationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> An object representing collection of ChaosTargetTypeResources and their operations over a ChaosTargetTypeResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method no longer works in all API versions.", false)]
        public virtual ChaosTargetTypeCollection GetChaosTargetTypes(string locationName)
        {
            return new ChaosTargetTypeCollection(Client, Id, locationName);
        }

        /// <summary>
        /// Get a Target Type resources for given location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Chaos/locations/{locationName}/targetTypes/{targetTypeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TargetTypes_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ChaosTargetTypeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationName"> String that represents a Location resource name. </param>
        /// <param name="targetTypeName"> String that represents a Target Type resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="locationName"/> or <paramref name="targetTypeName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="locationName"/> or <paramref name="targetTypeName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method no longer works in all API versions.", false)]
        public virtual Response<ChaosTargetTypeResource> GetChaosTargetType(string locationName, string targetTypeName, CancellationToken cancellationToken = default)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            return GetChaosTargetTypes(locationName).Get(targetTypeName, cancellationToken);
#pragma warning restore CS0618 // Type or member is obsolete
        }

        /// <summary>
        /// Get a Target Type resources for given location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Chaos/locations/{locationName}/targetTypes/{targetTypeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TargetTypes_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ChaosTargetTypeResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationName"> String that represents a Location resource name. </param>
        /// <param name="targetTypeName"> String that represents a Target Type resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="locationName"/> or <paramref name="targetTypeName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="locationName"/> or <paramref name="targetTypeName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method no longer works in all API versions.", false)]
        public virtual async Task<Response<ChaosTargetTypeResource>> GetChaosTargetTypeAsync(string locationName, string targetTypeName, CancellationToken cancellationToken = default)
        {
            return await GetChaosTargetTypes(locationName).GetAsync(targetTypeName, cancellationToken).ConfigureAwait(false);
        }

        // Customization: Preserves shipped GetChaosExperiments / GetChaosExperimentsAsync names.
        // The generator now emits these as GetExperiments / GetExperimentsAsync (due to the
        // @@clientName(Experiments.listAll, "getExperiments") override in the spec). The spec
        // fix has been applied in azure-rest-api-specs#43122; this customization can be removed
        // once tsp-location.yaml is bumped to a commit that contains the fix.
        /// <summary> Get a list of Experiment resources in a subscription. </summary>
        /// <param name="running"> Optional value that indicates whether to filter results based on if the Experiment is currently running. If null, then the results will not be filtered. </param>
        /// <param name="continuationToken"> String that sets the continuation token. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ChaosExperimentResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ChaosExperimentResource> GetChaosExperimentsAsync(bool? running = default, string continuationToken = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<ChaosExperimentData, ChaosExperimentResource>(new ExperimentsGetExperimentsAsyncCollectionResultOfT(
                ExperimentsRestClient,
                Guid.Parse(Id.SubscriptionId),
                running,
                continuationToken,
                context,
                "MockableChaosSubscriptionResource.GetChaosExperiments"), data => new ChaosExperimentResource(Client, data));
        }

        /// <summary> Get a list of Experiment resources in a subscription. </summary>
        /// <param name="running"> Optional value that indicates whether to filter results based on if the Experiment is currently running. If null, then the results will not be filtered. </param>
        /// <param name="continuationToken"> String that sets the continuation token. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ChaosExperimentResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ChaosExperimentResource> GetChaosExperiments(bool? running = default, string continuationToken = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<ChaosExperimentData, ChaosExperimentResource>(new ExperimentsGetExperimentsCollectionResultOfT(
                ExperimentsRestClient,
                Guid.Parse(Id.SubscriptionId),
                running,
                continuationToken,
                context,
                "MockableChaosSubscriptionResource.GetChaosExperiments"), data => new ChaosExperimentResource(Client, data));
        }

        /// <summary>
        /// Returns the current status of an async operation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Chaos/locations/{location}/operationStatuses/{operationId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>OperationStatuses_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location of the async operation. </param>
        /// <param name="operationId"> The ID of an ongoing async operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetChaosOperationStatusAsync(AzureLocation location, string operationId, CancellationToken cancellationToken = default)
        {
            return await GetChaosOperationStatusAsync(location.Name, operationId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns the current status of an async operation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Chaos/locations/{location}/operationStatuses/{operationId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>OperationStatuses_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location of the async operation. </param>
        /// <param name="operationId"> The ID of an ongoing async operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetChaosOperationStatus(AzureLocation location, string operationId, CancellationToken cancellationToken = default)
        {
            return GetChaosOperationStatus(location.Name, operationId, cancellationToken);
        }
    }
}
