// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.EventGrid
{
    // 1.1.0 back-compat: shipping versions exposed ResourceGroupResource-scoped extension
    // helpers under the legacy EventSubscription-flavored method names. The TypeSpec generator
    // now emits them on MockableEventGridResourceGroupResource under the operation-default
    // names (see neighboring partial in Mocking namespace). These extension overloads call
    // through to the legacy-named partial methods so that callers using the previous names
    // continue to compile against the new SDK.
    public static partial class EventGridExtensions
    {
        /// <summary> [Back-compat] List all global event subscriptions under a resource group for a specific topic type. </summary>
        /// <param name="resourceGroupResource"> The resource group resource to act on. </param>
        /// <param name="topicTypeName"> Name of the topic type. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Page size. </param>
        /// <param name="cancellationToken"> Token to cancel the operation. </param>
        public static AsyncPageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(this ResourceGroupResource resourceGroupResource, string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (resourceGroupResource is null) throw new ArgumentNullException(nameof(resourceGroupResource));
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetGlobalEventSubscriptionsDataForTopicTypeAsync(topicTypeName, filter, top, cancellationToken);
        }

        /// <summary> [Back-compat] List all global event subscriptions under a resource group for a specific topic type. </summary>
        /// <param name="resourceGroupResource"> The resource group resource to act on. </param>
        /// <param name="topicTypeName"> Name of the topic type. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Page size. </param>
        /// <param name="cancellationToken"> Token to cancel the operation. </param>
        public static Pageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(this ResourceGroupResource resourceGroupResource, string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (resourceGroupResource is null) throw new ArgumentNullException(nameof(resourceGroupResource));
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetGlobalEventSubscriptionsDataForTopicType(topicTypeName, filter, top, cancellationToken);
        }

        /// <summary> [Back-compat] List regional event subscriptions under a resource group. </summary>
        /// <param name="resourceGroupResource"> The resource group resource to act on. </param>
        /// <param name="location"> The location. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Page size. </param>
        /// <param name="cancellationToken"> Token to cancel the operation. </param>
        public static AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (resourceGroupResource is null) throw new ArgumentNullException(nameof(resourceGroupResource));
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetRegionalEventSubscriptionsDataAsync(location, filter, top, cancellationToken);
        }

        /// <summary> [Back-compat] List regional event subscriptions under a resource group. </summary>
        /// <param name="resourceGroupResource"> The resource group resource to act on. </param>
        /// <param name="location"> The location. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Page size. </param>
        /// <param name="cancellationToken"> Token to cancel the operation. </param>
        public static Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsData(this ResourceGroupResource resourceGroupResource, AzureLocation location, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (resourceGroupResource is null) throw new ArgumentNullException(nameof(resourceGroupResource));
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetRegionalEventSubscriptionsData(location, filter, top, cancellationToken);
        }

        /// <summary> [Back-compat] List regional event subscriptions under a resource group for a specific topic type. </summary>
        /// <param name="resourceGroupResource"> The resource group resource to act on. </param>
        /// <param name="location"> The location. </param>
        /// <param name="topicTypeName"> Name of the topic type. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Page size. </param>
        /// <param name="cancellationToken"> Token to cancel the operation. </param>
        public static AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (resourceGroupResource is null) throw new ArgumentNullException(nameof(resourceGroupResource));
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetRegionalEventSubscriptionsDataForTopicTypeAsync(location, topicTypeName, filter, top, cancellationToken);
        }

        /// <summary> [Back-compat] List regional event subscriptions under a resource group for a specific topic type. </summary>
        /// <param name="resourceGroupResource"> The resource group resource to act on. </param>
        /// <param name="location"> The location. </param>
        /// <param name="topicTypeName"> Name of the topic type. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Page size. </param>
        /// <param name="cancellationToken"> Token to cancel the operation. </param>
        public static Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(this ResourceGroupResource resourceGroupResource, AzureLocation location, string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (resourceGroupResource is null) throw new ArgumentNullException(nameof(resourceGroupResource));
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetRegionalEventSubscriptionsDataForTopicType(location, topicTypeName, filter, top, cancellationToken);
        }
    }
}
