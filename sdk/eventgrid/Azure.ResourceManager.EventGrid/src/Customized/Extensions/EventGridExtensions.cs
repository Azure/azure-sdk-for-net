// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.EventGrid
{
    [CodeGenSuppress("GetEventTypesAsync", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetEventTypes", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    public static partial class EventGridExtensions
    {
        /// <summary>
        /// List event types for a topic.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerNamespace}/{resourceTypeName}/{resourceName}/providers/Microsoft.EventGrid/eventTypes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Topics_ListEventTypes</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The resource identifier that the event types will be listed on. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        /// <returns> An async collection of <see cref="EventTypeUnderTopic" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<EventTypeUnderTopic> GetEventTypesAsync(this ArmClient client, ResourceIdentifier scope, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridArmClient(client).GetEventTypesAsync(scope, cancellationToken);
        }

        /// <summary>
        /// List event types for a topic.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerNamespace}/{resourceTypeName}/{resourceName}/providers/Microsoft.EventGrid/eventTypes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Topics_ListEventTypes</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The resource identifier that the event types will be listed on. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        /// <returns> An async collection of <see cref="EventTypeUnderTopic" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<EventTypeUnderTopic> GetEventTypes(this ArmClient client, ResourceIdentifier scope, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridArmClient(client).GetEventTypes(scope, cancellationToken);
        }

        /// <summary>
        /// List all global event subscriptions under an Azure subscription for a topic type.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.EventGrid/topicTypes/{topicTypeName}/eventSubscriptions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EventSubscriptions_ListGlobalBySubscriptionForTopicType</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="topicTypeName"> Name of the topic type. </param>
        /// <param name="filter"> The query used to filter the search results using OData syntax. Filtering is permitted on the &apos;name&apos; property only and with limited number of OData operations. These operations are: the &apos;contains&apos; function as well as the following logical operations: not, and, or, eq (for equal), and ne (for not equal). No arithmetic operations are supported. The following is a valid filter example: $filter=contains(namE, &apos;PATTERN&apos;) and name ne &apos;PATTERN-1&apos;. The following is not a valid filter example: $filter=location eq &apos;westus&apos;. </param>
        /// <param name="top"> The number of results to return per page for the list operation. Valid range for top parameter is 1 to 100. If not specified, the default number of results to be returned is 20 items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="topicTypeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="topicTypeName"/> is null. </exception>
        /// <returns> An async collection of <see cref="EventGridSubscriptionData" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(this SubscriptionResource subscriptionResource, string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridSubscriptionResource(subscriptionResource).GetGlobalEventSubscriptionsDataForTopicTypeAsync(topicTypeName, filter, top, cancellationToken);
        }

        /// <summary>
        /// List all global event subscriptions under an Azure subscription for a topic type.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.EventGrid/topicTypes/{topicTypeName}/eventSubscriptions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EventSubscriptions_ListGlobalBySubscriptionForTopicType</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="topicTypeName"> Name of the topic type. </param>
        /// <param name="filter"> The query used to filter the search results using OData syntax. Filtering is permitted on the &apos;name&apos; property only and with limited number of OData operations. These operations are: the &apos;contains&apos; function as well as the following logical operations: not, and, or, eq (for equal), and ne (for not equal). No arithmetic operations are supported. The following is a valid filter example: $filter=contains(namE, &apos;PATTERN&apos;) and name ne &apos;PATTERN-1&apos;. The following is not a valid filter example: $filter=location eq &apos;westus&apos;. </param>
        /// <param name="top"> The number of results to return per page for the list operation. Valid range for top parameter is 1 to 100. If not specified, the default number of results to be returned is 20 items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="topicTypeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="topicTypeName"/> is null. </exception>
        /// <returns> A collection of <see cref="EventGridSubscriptionData" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(this SubscriptionResource subscriptionResource, string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridSubscriptionResource(subscriptionResource).GetGlobalEventSubscriptionsDataForTopicType(topicTypeName, filter, top, cancellationToken);
        }

        /// <summary>
        /// List all event subscriptions from the given location under a specific Azure subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.EventGrid/locations/{location}/eventSubscriptions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EventSubscriptions_ListRegionalBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> Name of the location. </param>
        /// <param name="filter"> The query used to filter the search results using OData syntax. Filtering is permitted on the &apos;name&apos; property only and with limited number of OData operations. These operations are: the &apos;contains&apos; function as well as the following logical operations: not, and, or, eq (for equal), and ne (for not equal). No arithmetic operations are supported. The following is a valid filter example: $filter=contains(namE, &apos;PATTERN&apos;) and name ne &apos;PATTERN-1&apos;. The following is not a valid filter example: $filter=location eq &apos;westus&apos;. </param>
        /// <param name="top"> The number of results to return per page for the list operation. Valid range for top parameter is 1 to 100. If not specified, the default number of results to be returned is 20 items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="EventGridSubscriptionData" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridSubscriptionResource(subscriptionResource).GetRegionalEventSubscriptionsDataAsync(location, filter, top, cancellationToken);
        }

        /// <summary>
        /// List all event subscriptions from the given location under a specific Azure subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.EventGrid/locations/{location}/eventSubscriptions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EventSubscriptions_ListRegionalBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> Name of the location. </param>
        /// <param name="filter"> The query used to filter the search results using OData syntax. Filtering is permitted on the &apos;name&apos; property only and with limited number of OData operations. These operations are: the &apos;contains&apos; function as well as the following logical operations: not, and, or, eq (for equal), and ne (for not equal). No arithmetic operations are supported. The following is a valid filter example: $filter=contains(namE, &apos;PATTERN&apos;) and name ne &apos;PATTERN-1&apos;. The following is not a valid filter example: $filter=location eq &apos;westus&apos;. </param>
        /// <param name="top"> The number of results to return per page for the list operation. Valid range for top parameter is 1 to 100. If not specified, the default number of results to be returned is 20 items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="EventGridSubscriptionData" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsData(this SubscriptionResource subscriptionResource, AzureLocation location, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridSubscriptionResource(subscriptionResource).GetRegionalEventSubscriptionsData(location, filter, top, cancellationToken);
        }

        /// <summary>
        /// List all event subscriptions from the given location under a specific Azure subscription and topic type.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.EventGrid/locations/{location}/topicTypes/{topicTypeName}/eventSubscriptions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EventSubscriptions_ListRegionalBySubscriptionForTopicType</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> Name of the location. </param>
        /// <param name="topicTypeName"> Name of the topic type. </param>
        /// <param name="filter"> The query used to filter the search results using OData syntax. Filtering is permitted on the &apos;name&apos; property only and with limited number of OData operations. These operations are: the &apos;contains&apos; function as well as the following logical operations: not, and, or, eq (for equal), and ne (for not equal). No arithmetic operations are supported. The following is a valid filter example: $filter=contains(namE, &apos;PATTERN&apos;) and name ne &apos;PATTERN-1&apos;. The following is not a valid filter example: $filter=location eq &apos;westus&apos;. </param>
        /// <param name="top"> The number of results to return per page for the list operation. Valid range for top parameter is 1 to 100. If not specified, the default number of results to be returned is 20 items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="topicTypeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="topicTypeName"/> is null. </exception>
        /// <returns> An async collection of <see cref="EventGridSubscriptionData" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridSubscriptionResource(subscriptionResource).GetRegionalEventSubscriptionsDataForTopicTypeAsync(location, topicTypeName, filter, top, cancellationToken);
        }

        /// <summary>
        /// List all event subscriptions from the given location under a specific Azure subscription and topic type.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.EventGrid/locations/{location}/topicTypes/{topicTypeName}/eventSubscriptions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EventSubscriptions_ListRegionalBySubscriptionForTopicType</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> Name of the location. </param>
        /// <param name="topicTypeName"> Name of the topic type. </param>
        /// <param name="filter"> The query used to filter the search results using OData syntax. Filtering is permitted on the &apos;name&apos; property only and with limited number of OData operations. These operations are: the &apos;contains&apos; function as well as the following logical operations: not, and, or, eq (for equal), and ne (for not equal). No arithmetic operations are supported. The following is a valid filter example: $filter=contains(namE, &apos;PATTERN&apos;) and name ne &apos;PATTERN-1&apos;. The following is not a valid filter example: $filter=location eq &apos;westus&apos;. </param>
        /// <param name="top"> The number of results to return per page for the list operation. Valid range for top parameter is 1 to 100. If not specified, the default number of results to be returned is 20 items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="topicTypeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="topicTypeName"/> is null. </exception>
        /// <returns> A collection of <see cref="EventGridSubscriptionData" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(this SubscriptionResource subscriptionResource, AzureLocation location, string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridSubscriptionResource(subscriptionResource).GetRegionalEventSubscriptionsDataForTopicType(location, topicTypeName, filter, top, cancellationToken);
        }

        /// <summary>
        /// List all global event subscriptions under a resource group for a specific topic type.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topicTypes/{topicTypeName}/eventSubscriptions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EventSubscriptions_ListGlobalByResourceGroupForTopicType</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="topicTypeName"> Name of the topic type. </param>
        /// <param name="filter"> The query used to filter the search results using OData syntax. Filtering is permitted on the &apos;name&apos; property only and with limited number of OData operations. These operations are: the &apos;contains&apos; function as well as the following logical operations: not, and, or, eq (for equal), and ne (for not equal). No arithmetic operations are supported. The following is a valid filter example: $filter=contains(namE, &apos;PATTERN&apos;) and name ne &apos;PATTERN-1&apos;. The following is not a valid filter example: $filter=location eq &apos;westus&apos;. </param>
        /// <param name="top"> The number of results to return per page for the list operation. Valid range for top parameter is 1 to 100. If not specified, the default number of results to be returned is 20 items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="topicTypeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="topicTypeName"/> is null. </exception>
        /// <returns> An async collection of <see cref="EventGridSubscriptionData" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(this ResourceGroupResource resourceGroupResource, string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetGlobalEventSubscriptionsDataForTopicTypeAsync(topicTypeName, filter, top, cancellationToken);
        }

        /// <summary>
        /// List all global event subscriptions under a resource group for a specific topic type.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topicTypes/{topicTypeName}/eventSubscriptions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EventSubscriptions_ListGlobalByResourceGroupForTopicType</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="topicTypeName"> Name of the topic type. </param>
        /// <param name="filter"> The query used to filter the search results using OData syntax. Filtering is permitted on the &apos;name&apos; property only and with limited number of OData operations. These operations are: the &apos;contains&apos; function as well as the following logical operations: not, and, or, eq (for equal), and ne (for not equal). No arithmetic operations are supported. The following is a valid filter example: $filter=contains(namE, &apos;PATTERN&apos;) and name ne &apos;PATTERN-1&apos;. The following is not a valid filter example: $filter=location eq &apos;westus&apos;. </param>
        /// <param name="top"> The number of results to return per page for the list operation. Valid range for top parameter is 1 to 100. If not specified, the default number of results to be returned is 20 items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="topicTypeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="topicTypeName"/> is null. </exception>
        /// <returns> A collection of <see cref="EventGridSubscriptionData" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(this ResourceGroupResource resourceGroupResource, string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetGlobalEventSubscriptionsDataForTopicType(topicTypeName, filter, top, cancellationToken);
        }

        /// <summary>
        /// List all event subscriptions from the given location under a specific Azure subscription and resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/locations/{location}/eventSubscriptions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EventSubscriptions_ListRegionalByResourceGroup</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="location"> Name of the location. </param>
        /// <param name="filter"> The query used to filter the search results using OData syntax. Filtering is permitted on the &apos;name&apos; property only and with limited number of OData operations. These operations are: the &apos;contains&apos; function as well as the following logical operations: not, and, or, eq (for equal), and ne (for not equal). No arithmetic operations are supported. The following is a valid filter example: $filter=contains(namE, &apos;PATTERN&apos;) and name ne &apos;PATTERN-1&apos;. The following is not a valid filter example: $filter=location eq &apos;westus&apos;. </param>
        /// <param name="top"> The number of results to return per page for the list operation. Valid range for top parameter is 1 to 100. If not specified, the default number of results to be returned is 20 items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="EventGridSubscriptionData" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetRegionalEventSubscriptionsDataAsync(location, filter, top, cancellationToken);
        }

        /// <summary>
        /// List all event subscriptions from the given location under a specific Azure subscription and resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/locations/{location}/eventSubscriptions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EventSubscriptions_ListRegionalByResourceGroup</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="location"> Name of the location. </param>
        /// <param name="filter"> The query used to filter the search results using OData syntax. Filtering is permitted on the &apos;name&apos; property only and with limited number of OData operations. These operations are: the &apos;contains&apos; function as well as the following logical operations: not, and, or, eq (for equal), and ne (for not equal). No arithmetic operations are supported. The following is a valid filter example: $filter=contains(namE, &apos;PATTERN&apos;) and name ne &apos;PATTERN-1&apos;. The following is not a valid filter example: $filter=location eq &apos;westus&apos;. </param>
        /// <param name="top"> The number of results to return per page for the list operation. Valid range for top parameter is 1 to 100. If not specified, the default number of results to be returned is 20 items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="EventGridSubscriptionData" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsData(this ResourceGroupResource resourceGroupResource, AzureLocation location, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetRegionalEventSubscriptionsData(location, filter, top, cancellationToken);
        }

        /// <summary>
        /// List all event subscriptions from the given location under a specific Azure subscription and resource group and topic type.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/locations/{location}/topicTypes/{topicTypeName}/eventSubscriptions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EventSubscriptions_ListRegionalByResourceGroupForTopicType</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="location"> Name of the location. </param>
        /// <param name="topicTypeName"> Name of the topic type. </param>
        /// <param name="filter"> The query used to filter the search results using OData syntax. Filtering is permitted on the &apos;name&apos; property only and with limited number of OData operations. These operations are: the &apos;contains&apos; function as well as the following logical operations: not, and, or, eq (for equal), and ne (for not equal). No arithmetic operations are supported. The following is a valid filter example: $filter=contains(namE, &apos;PATTERN&apos;) and name ne &apos;PATTERN-1&apos;. The following is not a valid filter example: $filter=location eq &apos;westus&apos;. </param>
        /// <param name="top"> The number of results to return per page for the list operation. Valid range for top parameter is 1 to 100. If not specified, the default number of results to be returned is 20 items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="topicTypeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="topicTypeName"/> is null. </exception>
        /// <returns> An async collection of <see cref="EventGridSubscriptionData" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(this ResourceGroupResource resourceGroupResource, AzureLocation location, string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetRegionalEventSubscriptionsDataForTopicTypeAsync(location, topicTypeName, filter, top, cancellationToken);
        }

        /// <summary>
        /// List all event subscriptions from the given location under a specific Azure subscription and resource group and topic type.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/locations/{location}/topicTypes/{topicTypeName}/eventSubscriptions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EventSubscriptions_ListRegionalByResourceGroupForTopicType</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="location"> Name of the location. </param>
        /// <param name="topicTypeName"> Name of the topic type. </param>
        /// <param name="filter"> The query used to filter the search results using OData syntax. Filtering is permitted on the &apos;name&apos; property only and with limited number of OData operations. These operations are: the &apos;contains&apos; function as well as the following logical operations: not, and, or, eq (for equal), and ne (for not equal). No arithmetic operations are supported. The following is a valid filter example: $filter=contains(namE, &apos;PATTERN&apos;) and name ne &apos;PATTERN-1&apos;. The following is not a valid filter example: $filter=location eq &apos;westus&apos;. </param>
        /// <param name="top"> The number of results to return per page for the list operation. Valid range for top parameter is 1 to 100. If not specified, the default number of results to be returned is 20 items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="topicTypeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="topicTypeName"/> is null. </exception>
        /// <returns> A collection of <see cref="EventGridSubscriptionData" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(this ResourceGroupResource resourceGroupResource, AzureLocation location, string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetMockableEventGridResourceGroupResource(resourceGroupResource).GetRegionalEventSubscriptionsDataForTopicType(location, topicTypeName, filter, top, cancellationToken);
        }
    }
}
