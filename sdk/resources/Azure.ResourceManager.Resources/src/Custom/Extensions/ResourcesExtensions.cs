// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.Resources. </summary>
    public static partial class ResourcesExtensions
    {
        /// <summary>
        /// Retrieves all JIT requests within the subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Solutions/jitRequests
        /// Operation Id: JitRequests_ListBySubscription
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="JitRequestResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<JitRequestResource> GetJitRequestDefinitionsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetJitRequestsAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves all JIT requests within the subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Solutions/jitRequests
        /// Operation Id: JitRequests_ListBySubscription
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="JitRequestResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<JitRequestResource> GetJitRequestDefinitions(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetJitRequests(cancellationToken);
        }
    }
}
