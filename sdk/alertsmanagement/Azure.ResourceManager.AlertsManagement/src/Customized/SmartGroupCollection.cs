// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.AlertsManagement.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AlertsManagement
{
    /// <summary>
    /// A class representing a collection of <see cref="SmartGroupResource" /> and their operations.
    /// Each <see cref="SmartGroupResource" /> in the collection will belong to the same instance of <see cref="SubscriptionResource" />.
    /// To get a <see cref="SmartGroupCollection" /> instance call the GetSmartGroups method from an instance of <see cref="SubscriptionResource" />.
    /// </summary>
    public partial class SmartGroupCollection : ArmCollection, IEnumerable<SmartGroupResource>, IAsyncEnumerable<SmartGroupResource>
    {
        /// <summary>
        /// List all the Smart Groups within a specified subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.AlertsManagement/smartGroups
        /// Operation Id: SmartGroups_GetAll
        /// </summary>
        /// <param name="targetResource"> Filter by target resource( which is full ARM ID) Default value is select all. </param>
        /// <param name="targetResourceGroup"> Filter by target resource group name. Default value is select all. </param>
        /// <param name="targetResourceType"> Filter by target resource type. Default value is select all. </param>
        /// <param name="monitorService"> Filter by monitor service which generates the alert instance. Default value is select all. </param>
        /// <param name="monitorCondition"> Filter by monitor condition which is either &apos;Fired&apos; or &apos;Resolved&apos;. Default value is to select all. </param>
        /// <param name="severity"> Filter by severity.  Default value is select all. </param>
        /// <param name="smartGroupState"> Filter by state of the smart group. Default value is to select all. </param>
        /// <param name="timeRange"> Filter by time range by below listed values. Default value is 1 day. </param>
        /// <param name="pageCount"> Determines number of alerts returned per page in response. Permissible value is between 1 to 250. When the &quot;includeContent&quot;  filter is selected, maximum value allowed is 25. Default value is 25. </param>
        /// <param name="sortBy"> Sort the query results by input field. Default value is sort by &apos;lastModifiedDateTime&apos;. </param>
        /// <param name="sortOrder"> Sort the query results order in either ascending or descending.  Default value is &apos;desc&apos; for time fields and &apos;asc&apos; for others. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SmartGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SmartGroupResource> GetAllAsync(string targetResource = null, string targetResourceGroup = null, string targetResourceType = null, MonitorServiceSourceForAlert? monitorService = null, MonitorCondition? monitorCondition = null, ServiceAlertSeverity? severity = null, ServiceAlertState? smartGroupState = null, TimeRangeFilter? timeRange = null, long? pageCount = null, SmartGroupsSortByField? sortBy = null, AlertsManagementQuerySortOrder? sortOrder = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SmartGroupResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _smartGroupClientDiagnostics.CreateScope("SmartGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _smartGroupRestClient.GetAllAsync(Id.SubscriptionId, targetResource, targetResourceGroup, targetResourceType, monitorService, monitorCondition, severity, smartGroupState, timeRange, pageCount, sortBy, sortOrder, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SmartGroupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SmartGroupResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _smartGroupClientDiagnostics.CreateScope("SmartGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _smartGroupRestClient.GetAllNextPageAsync(nextLink, Id.SubscriptionId, targetResource, targetResourceGroup, targetResourceType, monitorService, monitorCondition, severity, smartGroupState, timeRange, pageCount, sortBy, sortOrder, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SmartGroupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List all the Smart Groups within a specified subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.AlertsManagement/smartGroups
        /// Operation Id: SmartGroups_GetAll
        /// </summary>
        /// <param name="targetResource"> Filter by target resource( which is full ARM ID) Default value is select all. </param>
        /// <param name="targetResourceGroup"> Filter by target resource group name. Default value is select all. </param>
        /// <param name="targetResourceType"> Filter by target resource type. Default value is select all. </param>
        /// <param name="monitorService"> Filter by monitor service which generates the alert instance. Default value is select all. </param>
        /// <param name="monitorCondition"> Filter by monitor condition which is either &apos;Fired&apos; or &apos;Resolved&apos;. Default value is to select all. </param>
        /// <param name="severity"> Filter by severity.  Default value is select all. </param>
        /// <param name="smartGroupState"> Filter by state of the smart group. Default value is to select all. </param>
        /// <param name="timeRange"> Filter by time range by below listed values. Default value is 1 day. </param>
        /// <param name="pageCount"> Determines number of alerts returned per page in response. Permissible value is between 1 to 250. When the &quot;includeContent&quot;  filter is selected, maximum value allowed is 25. Default value is 25. </param>
        /// <param name="sortBy"> Sort the query results by input field. Default value is sort by &apos;lastModifiedDateTime&apos;. </param>
        /// <param name="sortOrder"> Sort the query results order in either ascending or descending.  Default value is &apos;desc&apos; for time fields and &apos;asc&apos; for others. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SmartGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SmartGroupResource> GetAll(string targetResource = null, string targetResourceGroup = null, string targetResourceType = null, MonitorServiceSourceForAlert? monitorService = null, MonitorCondition? monitorCondition = null, ServiceAlertSeverity? severity = null, ServiceAlertState? smartGroupState = null, TimeRangeFilter? timeRange = null, long? pageCount = null, SmartGroupsSortByField? sortBy = null, AlertsManagementQuerySortOrder? sortOrder = null, CancellationToken cancellationToken = default)
        {
            Page<SmartGroupResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _smartGroupClientDiagnostics.CreateScope("SmartGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _smartGroupRestClient.GetAll(Id.SubscriptionId, targetResource, targetResourceGroup, targetResourceType, monitorService, monitorCondition, severity, smartGroupState, timeRange, pageCount, sortBy, sortOrder, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SmartGroupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SmartGroupResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _smartGroupClientDiagnostics.CreateScope("SmartGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _smartGroupRestClient.GetAllNextPage(nextLink, Id.SubscriptionId, targetResource, targetResourceGroup, targetResourceType, monitorService, monitorCondition, severity, smartGroupState, timeRange, pageCount, sortBy, sortOrder, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SmartGroupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
