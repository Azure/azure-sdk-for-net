// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility shims: map old GA 1.0.0 extension method names to new generated names.
// The generator derives extension method names from the resource class name (e.g. "Event" → GetEvents()).
// GA 1.0.0 used "GetResourceHealthEvents". @@clientName cannot rename extension methods on
// ResourceHealthExtensions — they are derived from the TypeSpec resource model name.
// Each extension method delegates through the corresponding Mockable* class to satisfy
// the ValidateMockingPattern test requirement.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ResourceHealth.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ResourceHealth
{
    public static partial class ResourceHealthExtensions
    {
        /// <summary> Gets the collection of ResourceHealthEvents for the subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <returns> An object representing collection of ResourceHealthEvents and their operations. </returns>
        // GA 1.0.0 backward compatibility shim: preserves the old name "GetResourceHealthEvents".
        // The new generated extension method is "GetEvents". Delegates through
        // MockableResourceHealthSubscriptionResource for mocking support.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceHealthEventCollection GetResourceHealthEvents(this SubscriptionResource subscriptionResource)
        {
            return GetMockableResourceHealthSubscriptionResource(subscriptionResource).GetResourceHealthEvents();
        }

        /// <summary> Gets a specific service health event in the subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <param name="eventTrackingId"> Event Id which uniquely identifies ServiceHealth event. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="queryStartTime"> Specifies from when to return events, based on the lastUpdateTime property. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // GA 1.0.0 backward compatibility shim: preserves the old name "GetResourceHealthEventAsync".
        // The new generated extension method is "GetEventAsync". Delegates through
        // MockableResourceHealthSubscriptionResource for mocking support.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static async Task<Response<ResourceHealthEventResource>> GetResourceHealthEventAsync(this SubscriptionResource subscriptionResource, string eventTrackingId, string filter = default, string queryStartTime = default, CancellationToken cancellationToken = default)
        {
            return await GetMockableResourceHealthSubscriptionResource(subscriptionResource).GetResourceHealthEventAsync(eventTrackingId, filter, queryStartTime, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a specific service health event in the subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <param name="eventTrackingId"> Event Id which uniquely identifies ServiceHealth event. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="queryStartTime"> Specifies from when to return events, based on the lastUpdateTime property. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        // GA 1.0.0 backward compatibility shim: preserves the old name "GetResourceHealthEvent".
        // The new generated extension method is "GetEvent". Delegates through
        // MockableResourceHealthSubscriptionResource for mocking support.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<ResourceHealthEventResource> GetResourceHealthEvent(this SubscriptionResource subscriptionResource, string eventTrackingId, string filter = default, string queryStartTime = default, CancellationToken cancellationToken = default)
        {
            return GetMockableResourceHealthSubscriptionResource(subscriptionResource).GetResourceHealthEvent(eventTrackingId, filter, queryStartTime, cancellationToken);
        }
    }
}