// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.Core;
using Azure.ResourceManager.EventGrid;

namespace Azure.ResourceManager.EventGrid.Mocking
{
    // 1.1.0 back-compat: the resource-group-scoped EventSubscription listings shipped under
    // EventSubscription-flavored names in the previous (autorest) generation. The TypeSpec
    // generator now emits them under the operation-default names
    // (GetGlobalByResourceGroupForTopicType, GetRegionalByResourceGroup,
    // GetRegionalByResourceGroupForTopicType). These thin delegating overloads keep the
    // legacy method names compiling. They are intentionally NOT marked obsolete because the
    // intent here is back-compat preservation, not deprecation.
    public partial class MockableEventGridResourceGroupResource
    {
        /// <summary> List all global event subscriptions under a resource group for a specific topic type. </summary>
        /// <param name="topicTypeName"> Name of the topic type. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Page size. </param>
        /// <param name="cancellationToken"> Token to cancel the operation. </param>
        public virtual AsyncPageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
            => GetGlobalByResourceGroupForTopicTypeAsync(topicTypeName, filter, top, cancellationToken);

        /// <summary> List all global event subscriptions under a resource group for a specific topic type. </summary>
        /// <param name="topicTypeName"> Name of the topic type. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Page size. </param>
        /// <param name="cancellationToken"> Token to cancel the operation. </param>
        public virtual Pageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
            => GetGlobalByResourceGroupForTopicType(topicTypeName, filter, top, cancellationToken);

        /// <summary> List event subscriptions in the given location under a resource group. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Page size. </param>
        /// <param name="cancellationToken"> Token to cancel the operation. </param>
        public virtual AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(AzureLocation location, string filter = null, int? top = null, CancellationToken cancellationToken = default)
            => GetRegionalByResourceGroupAsync(location, filter, top, cancellationToken);

        /// <summary> List event subscriptions in the given location under a resource group. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Page size. </param>
        /// <param name="cancellationToken"> Token to cancel the operation. </param>
        public virtual Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsData(AzureLocation location, string filter = null, int? top = null, CancellationToken cancellationToken = default)
            => GetRegionalByResourceGroup(location, filter, top, cancellationToken);

        /// <summary> List event subscriptions in the given location under a resource group for a specific topic type. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="topicTypeName"> Name of the topic type. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Page size. </param>
        /// <param name="cancellationToken"> Token to cancel the operation. </param>
        public virtual AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(AzureLocation location, string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
            => GetRegionalByResourceGroupForTopicTypeAsync(location, topicTypeName, filter, top, cancellationToken);

        /// <summary> List event subscriptions in the given location under a resource group for a specific topic type. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="topicTypeName"> Name of the topic type. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Page size. </param>
        /// <param name="cancellationToken"> Token to cancel the operation. </param>
        public virtual Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(AzureLocation location, string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
            => GetRegionalByResourceGroupForTopicType(location, topicTypeName, filter, top, cancellationToken);
    }
}
