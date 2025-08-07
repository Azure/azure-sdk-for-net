// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.EventGrid.Mocking
{
    [CodeGenSuppress("GetEventTypesAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetEventTypes", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    public partial class MockableEventGridResourceGroupResource : ArmResource
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

            async Task<Page<EventGridSubscriptionData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = EventSubscriptionClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetGlobalEventSubscriptionsDataForTopicType");
                scope.Start();
                try
                {
                    var response = await EventSubscriptionRestClient.ListGlobalByResourceGroupForTopicTypeAsync(Id.SubscriptionId, Id.ResourceGroupName, topicTypeName, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<EventGridSubscriptionData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = EventSubscriptionClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetGlobalEventSubscriptionsDataForTopicType");
                scope.Start();
                try
                {
                    var response = await EventSubscriptionRestClient.ListGlobalByResourceGroupForTopicTypeNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, topicTypeName, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
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

            Page<EventGridSubscriptionData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = EventSubscriptionClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetGlobalEventSubscriptionsDataForTopicType");
                scope.Start();
                try
                {
                    var response = EventSubscriptionRestClient.ListGlobalByResourceGroupForTopicType(Id.SubscriptionId, Id.ResourceGroupName, topicTypeName, filter, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<EventGridSubscriptionData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = EventSubscriptionClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetGlobalEventSubscriptionsDataForTopicType");
                scope.Start();
                try
                {
                    var response = EventSubscriptionRestClient.ListGlobalByResourceGroupForTopicTypeNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, topicTypeName, filter, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
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
            async Task<Page<EventGridSubscriptionData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = EventSubscriptionClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetRegionalEventSubscriptionsData");
                scope.Start();
                try
                {
                    var response = await EventSubscriptionRestClient.ListRegionalByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, location, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<EventGridSubscriptionData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = EventSubscriptionClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetRegionalEventSubscriptionsData");
                scope.Start();
                try
                {
                    var response = await EventSubscriptionRestClient.ListRegionalByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, location, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
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
            Page<EventGridSubscriptionData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = EventSubscriptionClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetRegionalEventSubscriptionsData");
                scope.Start();
                try
                {
                    var response = EventSubscriptionRestClient.ListRegionalByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, location, filter, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<EventGridSubscriptionData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = EventSubscriptionClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetRegionalEventSubscriptionsData");
                scope.Start();
                try
                {
                    var response = EventSubscriptionRestClient.ListRegionalByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, location, filter, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
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

            async Task<Page<EventGridSubscriptionData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = EventSubscriptionClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetRegionalEventSubscriptionsDataForTopicType");
                scope.Start();
                try
                {
                    var response = await EventSubscriptionRestClient.ListRegionalByResourceGroupForTopicTypeAsync(Id.SubscriptionId, Id.ResourceGroupName, location, topicTypeName, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<EventGridSubscriptionData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = EventSubscriptionClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetRegionalEventSubscriptionsDataForTopicType");
                scope.Start();
                try
                {
                    var response = await EventSubscriptionRestClient.ListRegionalByResourceGroupForTopicTypeNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, location, topicTypeName, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
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

            Page<EventGridSubscriptionData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = EventSubscriptionClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetRegionalEventSubscriptionsDataForTopicType");
                scope.Start();
                try
                {
                    var response = EventSubscriptionRestClient.ListRegionalByResourceGroupForTopicType(Id.SubscriptionId, Id.ResourceGroupName, location, topicTypeName, filter, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<EventGridSubscriptionData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = EventSubscriptionClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetRegionalEventSubscriptionsDataForTopicType");
                scope.Start();
                try
                {
                    var response = EventSubscriptionRestClient.ListRegionalByResourceGroupForTopicTypeNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, location, topicTypeName, filter, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
