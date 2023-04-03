// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.EventGrid.Mock
{
    public partial class EventSubscriptionResourceExtension
    {
        /// <summary>
        /// List all global event subscriptions under a resource group for a specific topic type.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topicTypes/{topicTypeName}/eventSubscriptions
        /// Operation Id: EventSubscriptions_ListGlobalByResourceGroupForTopicType
        /// </summary>
        /// <param name="topicTypeName"> Name of the topic type. </param>
        /// <param name="filter"> The query used to filter the search results using OData syntax. Filtering is permitted on the &apos;name&apos; property only and with limited number of OData operations. These operations are: the &apos;contains&apos; function as well as the following logical operations: not, and, or, eq (for equal), and ne (for not equal). No arithmetic operations are supported. The following is a valid filter example: $filter=contains(namE, &apos;PATTERN&apos;) and name ne &apos;PATTERN-1&apos;. The following is not a valid filter example: $filter=location eq &apos;westus&apos;. </param>
        /// <param name="top"> The number of results to return per page for the list operation. Valid range for top parameter is 1 to 100. If not specified, the default number of results to be returned is 20 items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="EventGridSubscriptionData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicTypeName, nameof(topicTypeName));

            if (Id.ResourceType == SubscriptionResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => EventSubscriptionRestClient.CreateListGlobalBySubscriptionForTopicTypeRequest(Id.SubscriptionId, topicTypeName, filter, top);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => EventSubscriptionRestClient.CreateListGlobalBySubscriptionForTopicTypeNextPageRequest(nextLink, Id.SubscriptionId, topicTypeName, filter, top);
                return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, EventGridSubscriptionData.DeserializeEventGridSubscriptionData, EventSubscriptionClientDiagnostics, Pipeline, "EventSubscriptionResourceExtension.GetGlobalEventSubscriptionsDataForTopicType", "value", "nextLink", cancellationToken);
            }
            else if (Id.ResourceType == ResourceGroupResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => EventSubscriptionRestClient.CreateListGlobalByResourceGroupForTopicTypeRequest(Id.SubscriptionId, Id.ResourceGroupName, topicTypeName, filter, top);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => EventSubscriptionRestClient.CreateListGlobalByResourceGroupForTopicTypeNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, topicTypeName, filter, top);
                return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, EventGridSubscriptionData.DeserializeEventGridSubscriptionData, EventSubscriptionClientDiagnostics, Pipeline, "EventSubscriptionResourceExtension.GetGlobalEventSubscriptionsDataForTopicType", "value", "nextLink", cancellationToken);
            }
            else
            {
                throw new InvalidOperationException($"{Id.ResourceType} is not supported here");
            }
        }

        /// <summary>
        /// List all global event subscriptions under a resource group for a specific topic type.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topicTypes/{topicTypeName}/eventSubscriptions
        /// Operation Id: EventSubscriptions_ListGlobalByResourceGroupForTopicType
        /// </summary>
        /// <param name="topicTypeName"> Name of the topic type. </param>
        /// <param name="filter"> The query used to filter the search results using OData syntax. Filtering is permitted on the &apos;name&apos; property only and with limited number of OData operations. These operations are: the &apos;contains&apos; function as well as the following logical operations: not, and, or, eq (for equal), and ne (for not equal). No arithmetic operations are supported. The following is a valid filter example: $filter=contains(namE, &apos;PATTERN&apos;) and name ne &apos;PATTERN-1&apos;. The following is not a valid filter example: $filter=location eq &apos;westus&apos;. </param>
        /// <param name="top"> The number of results to return per page for the list operation. Valid range for top parameter is 1 to 100. If not specified, the default number of results to be returned is 20 items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="EventGridSubscriptionData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicTypeName, nameof(topicTypeName));

            if (Id.ResourceType == SubscriptionResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => EventSubscriptionRestClient.CreateListGlobalBySubscriptionForTopicTypeRequest(Id.SubscriptionId, topicTypeName, filter, top);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => EventSubscriptionRestClient.CreateListGlobalBySubscriptionForTopicTypeNextPageRequest(nextLink, Id.SubscriptionId, topicTypeName, filter, top);
                return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, EventGridSubscriptionData.DeserializeEventGridSubscriptionData, EventSubscriptionClientDiagnostics, Pipeline, "EventSubscriptionResourceExtension.GetGlobalEventSubscriptionsDataForTopicType", "value", "nextLink", cancellationToken);
            }
            else if (Id.ResourceType == ResourceGroupResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => EventSubscriptionRestClient.CreateListGlobalByResourceGroupForTopicTypeRequest(Id.SubscriptionId, Id.ResourceGroupName, topicTypeName, filter, top);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => EventSubscriptionRestClient.CreateListGlobalByResourceGroupForTopicTypeNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, topicTypeName, filter, top);
                return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, EventGridSubscriptionData.DeserializeEventGridSubscriptionData, EventSubscriptionClientDiagnostics, Pipeline, "EventSubscriptionResourceExtension.GetGlobalEventSubscriptionsDataForTopicType", "value", "nextLink", cancellationToken);
            }
            else
            {
                throw new InvalidOperationException($"{Id.ResourceType} is not supported here");
            }
        }

        /// <summary>
        /// List all event subscriptions from the given location under a specific Azure subscription and resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/locations/{location}/eventSubscriptions
        /// Operation Id: EventSubscriptions_ListRegionalByResourceGroup
        /// </summary>
        /// <param name="location"> Name of the location. </param>
        /// <param name="filter"> The query used to filter the search results using OData syntax. Filtering is permitted on the &apos;name&apos; property only and with limited number of OData operations. These operations are: the &apos;contains&apos; function as well as the following logical operations: not, and, or, eq (for equal), and ne (for not equal). No arithmetic operations are supported. The following is a valid filter example: $filter=contains(namE, &apos;PATTERN&apos;) and name ne &apos;PATTERN-1&apos;. The following is not a valid filter example: $filter=location eq &apos;westus&apos;. </param>
        /// <param name="top"> The number of results to return per page for the list operation. Valid range for top parameter is 1 to 100. If not specified, the default number of results to be returned is 20 items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="EventGridSubscriptionData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(AzureLocation location, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (Id.ResourceType == SubscriptionResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => EventSubscriptionRestClient.CreateListRegionalBySubscriptionRequest(Id.SubscriptionId, location, filter, top);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => EventSubscriptionRestClient.CreateListRegionalBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId, location, filter, top);
                return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, EventGridSubscriptionData.DeserializeEventGridSubscriptionData, EventSubscriptionClientDiagnostics, Pipeline, "EventSubscriptionResourceExtension.GetRegionalEventSubscriptionsData", "value", "nextLink", cancellationToken);
            }
            else if (Id.ResourceType == ResourceGroupResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => EventSubscriptionRestClient.CreateListRegionalByResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName, location, filter, top);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => EventSubscriptionRestClient.CreateListRegionalByResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, location, filter, top);
                return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, EventGridSubscriptionData.DeserializeEventGridSubscriptionData, EventSubscriptionClientDiagnostics, Pipeline, "EventSubscriptionResourceExtension.GetRegionalEventSubscriptionsData", "value", "nextLink", cancellationToken);
            }
            else
            {
                throw new InvalidOperationException($"{Id.ResourceType} is not supported here");
            }
        }

        /// <summary>
        /// List all event subscriptions from the given location under a specific Azure subscription and resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/locations/{location}/eventSubscriptions
        /// Operation Id: EventSubscriptions_ListRegionalByResourceGroup
        /// </summary>
        /// <param name="location"> Name of the location. </param>
        /// <param name="filter"> The query used to filter the search results using OData syntax. Filtering is permitted on the &apos;name&apos; property only and with limited number of OData operations. These operations are: the &apos;contains&apos; function as well as the following logical operations: not, and, or, eq (for equal), and ne (for not equal). No arithmetic operations are supported. The following is a valid filter example: $filter=contains(namE, &apos;PATTERN&apos;) and name ne &apos;PATTERN-1&apos;. The following is not a valid filter example: $filter=location eq &apos;westus&apos;. </param>
        /// <param name="top"> The number of results to return per page for the list operation. Valid range for top parameter is 1 to 100. If not specified, the default number of results to be returned is 20 items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="EventGridSubscriptionData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsData(AzureLocation location, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (Id.ResourceType == SubscriptionResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => EventSubscriptionRestClient.CreateListRegionalBySubscriptionRequest(Id.SubscriptionId, location, filter, top);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => EventSubscriptionRestClient.CreateListRegionalBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId, location, filter, top);
                return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, EventGridSubscriptionData.DeserializeEventGridSubscriptionData, EventSubscriptionClientDiagnostics, Pipeline, "EventSubscriptionResourceExtension.GetRegionalEventSubscriptionsData", "value", "nextLink", cancellationToken);
            }
            else if (Id.ResourceType == ResourceGroupResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => EventSubscriptionRestClient.CreateListRegionalByResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName, location, filter, top);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => EventSubscriptionRestClient.CreateListRegionalByResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, location, filter, top);
                return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, EventGridSubscriptionData.DeserializeEventGridSubscriptionData, EventSubscriptionClientDiagnostics, Pipeline, "EventSubscriptionResourceExtension.GetRegionalEventSubscriptionsData", "value", "nextLink", cancellationToken);
            }
            else
            {
                throw new InvalidOperationException($"{Id.ResourceType} is not supported here");
            }
        }

        /// <summary>
        /// List all event subscriptions from the given location under a specific Azure subscription and resource group and topic type.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/locations/{location}/topicTypes/{topicTypeName}/eventSubscriptions
        /// Operation Id: EventSubscriptions_ListRegionalByResourceGroupForTopicType
        /// </summary>
        /// <param name="location"> Name of the location. </param>
        /// <param name="topicTypeName"> Name of the topic type. </param>
        /// <param name="filter"> The query used to filter the search results using OData syntax. Filtering is permitted on the &apos;name&apos; property only and with limited number of OData operations. These operations are: the &apos;contains&apos; function as well as the following logical operations: not, and, or, eq (for equal), and ne (for not equal). No arithmetic operations are supported. The following is a valid filter example: $filter=contains(namE, &apos;PATTERN&apos;) and name ne &apos;PATTERN-1&apos;. The following is not a valid filter example: $filter=location eq &apos;westus&apos;. </param>
        /// <param name="top"> The number of results to return per page for the list operation. Valid range for top parameter is 1 to 100. If not specified, the default number of results to be returned is 20 items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="EventGridSubscriptionData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(AzureLocation location, string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicTypeName, nameof(topicTypeName));

            if (Id.ResourceType == SubscriptionResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => EventSubscriptionRestClient.CreateListRegionalBySubscriptionForTopicTypeRequest(Id.SubscriptionId, location, topicTypeName, filter, top);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => EventSubscriptionRestClient.CreateListRegionalBySubscriptionForTopicTypeNextPageRequest(nextLink, Id.SubscriptionId, location, topicTypeName, filter, top);
                return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, EventGridSubscriptionData.DeserializeEventGridSubscriptionData, EventSubscriptionClientDiagnostics, Pipeline, "EventSubscriptionResourceExtension.GetRegionalEventSubscriptionsDataForTopicType", "value", "nextLink", cancellationToken);
            }
            else if (Id.ResourceType == ResourceGroupResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => EventSubscriptionRestClient.CreateListRegionalByResourceGroupForTopicTypeRequest(Id.SubscriptionId, Id.ResourceGroupName, location, topicTypeName, filter, top);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => EventSubscriptionRestClient.CreateListRegionalByResourceGroupForTopicTypeNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, location, topicTypeName, filter, top);
                return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, EventGridSubscriptionData.DeserializeEventGridSubscriptionData, EventSubscriptionClientDiagnostics, Pipeline, "EventSubscriptionResourceExtension.GetRegionalEventSubscriptionsDataForTopicType", "value", "nextLink", cancellationToken);
            }
            else
            {
                throw new InvalidOperationException($"{Id.ResourceType} is not supported here");
            }
        }

        /// <summary>
        /// List all event subscriptions from the given location under a specific Azure subscription and resource group and topic type.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/locations/{location}/topicTypes/{topicTypeName}/eventSubscriptions
        /// Operation Id: EventSubscriptions_ListRegionalByResourceGroupForTopicType
        /// </summary>
        /// <param name="location"> Name of the location. </param>
        /// <param name="topicTypeName"> Name of the topic type. </param>
        /// <param name="filter"> The query used to filter the search results using OData syntax. Filtering is permitted on the &apos;name&apos; property only and with limited number of OData operations. These operations are: the &apos;contains&apos; function as well as the following logical operations: not, and, or, eq (for equal), and ne (for not equal). No arithmetic operations are supported. The following is a valid filter example: $filter=contains(namE, &apos;PATTERN&apos;) and name ne &apos;PATTERN-1&apos;. The following is not a valid filter example: $filter=location eq &apos;westus&apos;. </param>
        /// <param name="top"> The number of results to return per page for the list operation. Valid range for top parameter is 1 to 100. If not specified, the default number of results to be returned is 20 items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="EventGridSubscriptionData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(AzureLocation location, string topicTypeName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicTypeName, nameof(topicTypeName));

            if (Id.ResourceType == SubscriptionResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => EventSubscriptionRestClient.CreateListRegionalBySubscriptionForTopicTypeRequest(Id.SubscriptionId, location, topicTypeName, filter, top);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => EventSubscriptionRestClient.CreateListRegionalBySubscriptionForTopicTypeNextPageRequest(nextLink, Id.SubscriptionId, location, topicTypeName, filter, top);
                return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, EventGridSubscriptionData.DeserializeEventGridSubscriptionData, EventSubscriptionClientDiagnostics, Pipeline, "EventSubscriptionResourceExtension.GetRegionalEventSubscriptionsDataForTopicType", "value", "nextLink", cancellationToken);
            }
            else if (Id.ResourceType == ResourceGroupResource.ResourceType)
            {
                HttpMessage FirstPageRequest(int? pageSizeHint) => EventSubscriptionRestClient.CreateListRegionalByResourceGroupForTopicTypeRequest(Id.SubscriptionId, Id.ResourceGroupName, location, topicTypeName, filter, top);
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => EventSubscriptionRestClient.CreateListRegionalByResourceGroupForTopicTypeNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, location, topicTypeName, filter, top);
                return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, EventGridSubscriptionData.DeserializeEventGridSubscriptionData, EventSubscriptionClientDiagnostics, Pipeline, "EventSubscriptionResourceExtension.GetRegionalEventSubscriptionsDataForTopicType", "value", "nextLink", cancellationToken);
            }
            else
            {
                throw new InvalidOperationException($"{Id.ResourceType} is not supported here");
            }
        }
    }
}
