// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.EventGrid
{
    public static partial class EventGridExtensions
    {
        /// <summary> List global event subscriptions under a resource group for a topic type. </summary>
        public static Pageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(this ResourceGroupResource resourceGroupResource, string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetGlobalByResourceGroupForTopicType(topicTypeName, filter, top, cancellationToken);
        }

        /// <summary> List global event subscriptions under a resource group for a topic type. </summary>
        public static AsyncPageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(this ResourceGroupResource resourceGroupResource, string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetGlobalByResourceGroupForTopicTypeAsync(topicTypeName, filter, top, cancellationToken);
        }

        /// <summary> List global event subscriptions under a subscription for a topic type. </summary>
        public static Pageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(this SubscriptionResource subscriptionResource, string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridSubscriptionResource(subscriptionResource).GetGlobalBySubscriptionForTopicType(topicTypeName, filter, top, cancellationToken);
        }

        /// <summary> List global event subscriptions under a subscription for a topic type. </summary>
        public static AsyncPageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(this SubscriptionResource subscriptionResource, string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridSubscriptionResource(subscriptionResource).GetGlobalBySubscriptionForTopicTypeAsync(topicTypeName, filter, top, cancellationToken);
        }

        /// <summary> List regional event subscriptions under a resource group. </summary>
        public static Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsData(this ResourceGroupResource resourceGroupResource, AzureLocation location, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetRegionalByResourceGroup(location.ToString(), filter, top, cancellationToken);
        }

        /// <summary> List regional event subscriptions under a resource group. </summary>
        public static AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetRegionalByResourceGroupAsync(location.ToString(), filter, top, cancellationToken);
        }

        /// <summary> List regional event subscriptions under a subscription. </summary>
        public static Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsData(this SubscriptionResource subscriptionResource, AzureLocation location, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridSubscriptionResource(subscriptionResource).GetRegionalBySubscription(location.ToString(), filter, top, cancellationToken);
        }

        /// <summary> List regional event subscriptions under a subscription. </summary>
        public static AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridSubscriptionResource(subscriptionResource).GetRegionalBySubscriptionAsync(location.ToString(), filter, top, cancellationToken);
        }

        /// <summary> List regional event subscriptions under a resource group for a topic type. </summary>
        public static Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(this ResourceGroupResource resourceGroupResource, AzureLocation location, string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetRegionalByResourceGroupForTopicType(location.ToString(), topicTypeName, filter, top, cancellationToken);
        }

        /// <summary> List regional event subscriptions under a resource group for a topic type. </summary>
        public static AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetRegionalByResourceGroupForTopicTypeAsync(location.ToString(), topicTypeName, filter, top, cancellationToken);
        }

        /// <summary> List regional event subscriptions under a subscription for a topic type. </summary>
        public static Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(this SubscriptionResource subscriptionResource, AzureLocation location, string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridSubscriptionResource(subscriptionResource).GetRegionalBySubscriptionForTopicType(location.ToString(), topicTypeName, filter, top, cancellationToken);
        }

        /// <summary> List regional event subscriptions under a subscription for a topic type. </summary>
        public static AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridSubscriptionResource(subscriptionResource).GetRegionalBySubscriptionForTopicTypeAsync(location.ToString(), topicTypeName, filter, top, cancellationToken);
        }
    }
}
