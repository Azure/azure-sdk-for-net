// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.EventGrid.Mocking
{
    public partial class MockableEventGridResourceGroupResource
    {
        /// <summary> List global event subscriptions under a resource group for a topic type. </summary>
        public virtual Pageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
            => GetGlobalByResourceGroupForTopicType(topicTypeName, filter, top, cancellationToken);

        /// <summary> List global event subscriptions under a resource group for a topic type. </summary>
        public virtual AsyncPageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
            => GetGlobalByResourceGroupForTopicTypeAsync(topicTypeName, filter, top, cancellationToken);

        /// <summary> List regional event subscriptions under a resource group. </summary>
        public virtual Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsData(AzureLocation location, string filter = null, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalByResourceGroup(location.ToString(), filter, top, cancellationToken);

        /// <summary> List regional event subscriptions under a resource group. </summary>
        public virtual AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(AzureLocation location, string filter = null, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalByResourceGroupAsync(location.ToString(), filter, top, cancellationToken);

        /// <summary> List regional event subscriptions under a resource group for a topic type. </summary>
        public virtual Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(AzureLocation location, string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalByResourceGroupForTopicType(location.ToString(), topicTypeName, filter, top, cancellationToken);

        /// <summary> List regional event subscriptions under a resource group for a topic type. </summary>
        public virtual AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(AzureLocation location, string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
            => GetRegionalByResourceGroupForTopicTypeAsync(location.ToString(), topicTypeName, filter, top, cancellationToken);
    }
}
