// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.EventGrid.Mocking
{
    public partial class MockableEventGridSubscriptionResource
    {
        /// <summary> List global event subscriptions under a subscription for a topic type. </summary>
        public virtual Pageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
            => GetGlobalBySubscriptionForTopicType(topicTypeName, filter, top, cancellationToken);

        /// <summary> List global event subscriptions under a subscription for a topic type. </summary>
        public virtual AsyncPageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
            => GetGlobalBySubscriptionForTopicTypeAsync(topicTypeName, filter, top, cancellationToken);

        /// <summary> List regional event subscriptions under a subscription. </summary>
        public virtual Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsData(AzureLocation location, string filter = null, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalBySubscription(location.ToString(), filter, top, cancellationToken);

        /// <summary> List regional event subscriptions under a subscription. </summary>
        public virtual AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(AzureLocation location, string filter = null, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalBySubscriptionAsync(location.ToString(), filter, top, cancellationToken);

        /// <summary> List regional event subscriptions under a subscription for a topic type. </summary>
        public virtual Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(AzureLocation location, string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalBySubscriptionForTopicType(location.ToString(), topicTypeName, filter, top, cancellationToken);

        /// <summary> List regional event subscriptions under a subscription for a topic type. </summary>
        public virtual AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(AzureLocation location, string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalBySubscriptionForTopicTypeAsync(location.ToString(), topicTypeName, filter, top, cancellationToken);
    }
}
