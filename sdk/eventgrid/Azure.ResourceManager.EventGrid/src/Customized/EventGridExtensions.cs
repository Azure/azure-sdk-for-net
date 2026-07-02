// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid
{
    // The generator emits these extension methods under names/shapes that differ from main's GA surface
    // (GetByResource / GetEventSubscriptions / GetAll / Reconcile). They are suppressed and re-exposed under
    // the GA method names, including the data-returning (...Data) list variants the generator does not produce.
    [CodeGenSuppress("GetByResource", typeof(ArmClient), typeof(ResourceIdentifier), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetByResourceAsync", typeof(ArmClient), typeof(ResourceIdentifier), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("Get", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAsync", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetByResource", typeof(ResourceGroupResource), typeof(PrivateEndpointConnectionsParentTypeCsharp), typeof(string), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetByResourceAsync", typeof(ResourceGroupResource), typeof(PrivateEndpointConnectionsParentTypeCsharp), typeof(string), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetByResource", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetByResourceAsync", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetEventSubscriptions", typeof(ResourceGroupResource), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetEventSubscriptionsAsync", typeof(ResourceGroupResource), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetEventSubscriptions", typeof(SubscriptionResource), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetEventSubscriptionsAsync", typeof(SubscriptionResource), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetAll", typeof(ResourceGroupResource), typeof(NetworkSecurityPerimeterResourceType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAllAsync", typeof(ResourceGroupResource), typeof(NetworkSecurityPerimeterResourceType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Reconcile", typeof(ResourceGroupResource), typeof(WaitUntil), typeof(NetworkSecurityPerimeterResourceType), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ReconcileAsync", typeof(ResourceGroupResource), typeof(WaitUntil), typeof(NetworkSecurityPerimeterResourceType), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    public static partial class EventGridExtensions
    {
        /// <summary> List global event subscriptions under a resource group for a topic type. </summary>
        public static Pageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(this ResourceGroupResource resourceGroupResource, string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetGlobalEventSubscriptionsDataForTopicType(topicTypeName, filter, top, cancellationToken);
        }

        /// <summary> List global event subscriptions under a resource group for a topic type. </summary>
        public static AsyncPageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(this ResourceGroupResource resourceGroupResource, string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetGlobalEventSubscriptionsDataForTopicTypeAsync(topicTypeName, filter, top, cancellationToken);
        }

        /// <summary> List global event subscriptions under a subscription for a topic type. </summary>
        public static Pageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(this SubscriptionResource subscriptionResource, string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridSubscriptionResource(subscriptionResource).GetGlobalEventSubscriptionsDataForTopicType(topicTypeName, filter, top, cancellationToken);
        }

        /// <summary> List global event subscriptions under a subscription for a topic type. </summary>
        public static AsyncPageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(this SubscriptionResource subscriptionResource, string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridSubscriptionResource(subscriptionResource).GetGlobalEventSubscriptionsDataForTopicTypeAsync(topicTypeName, filter, top, cancellationToken);
        }

        /// <summary> List regional event subscriptions under a resource group. </summary>
        public static Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsData(this ResourceGroupResource resourceGroupResource, AzureLocation location, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetRegionalEventSubscriptionsData(location, filter, top, cancellationToken);
        }

        /// <summary> List regional event subscriptions under a resource group. </summary>
        public static AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetRegionalEventSubscriptionsDataAsync(location, filter, top, cancellationToken);
        }

        /// <summary> List regional event subscriptions under a subscription. </summary>
        public static Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsData(this SubscriptionResource subscriptionResource, AzureLocation location, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridSubscriptionResource(subscriptionResource).GetRegionalEventSubscriptionsData(location, filter, top, cancellationToken);
        }

        /// <summary> List regional event subscriptions under a subscription. </summary>
        public static AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridSubscriptionResource(subscriptionResource).GetRegionalEventSubscriptionsDataAsync(location, filter, top, cancellationToken);
        }

        /// <summary> List regional event subscriptions under a resource group for a topic type. </summary>
        public static Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(this ResourceGroupResource resourceGroupResource, AzureLocation location, string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetRegionalEventSubscriptionsDataForTopicType(location, topicTypeName, filter, top, cancellationToken);
        }

        /// <summary> List regional event subscriptions under a resource group for a topic type. </summary>
        public static AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetRegionalEventSubscriptionsDataForTopicTypeAsync(location, topicTypeName, filter, top, cancellationToken);
        }

        /// <summary> List regional event subscriptions under a subscription for a topic type. </summary>
        public static Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(this SubscriptionResource subscriptionResource, AzureLocation location, string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridSubscriptionResource(subscriptionResource).GetRegionalEventSubscriptionsDataForTopicType(location, topicTypeName, filter, top, cancellationToken);
        }

        /// <summary> List regional event subscriptions under a subscription for a topic type. </summary>
        public static AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string topicTypeName, string filter = null, int? top = default, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridSubscriptionResource(subscriptionResource).GetRegionalEventSubscriptionsDataForTopicTypeAsync(location, topicTypeName, filter, top, cancellationToken);
        }
    }
}
