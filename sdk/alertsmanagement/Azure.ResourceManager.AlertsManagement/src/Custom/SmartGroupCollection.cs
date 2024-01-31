// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.ResourceManager.AlertsManagement.Models;

namespace Azure.ResourceManager.AlertsManagement
{
    public partial class SmartGroupCollection
    {
        /// <summary>
        /// List all the Smart Groups within a specified subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.AlertsManagement/smartGroups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SmartGroups_GetAll</description>
        /// </item>
        /// </list>
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
            SmartGroupCollectionGetAllOptions options = new SmartGroupCollectionGetAllOptions();
            options.TargetResource = targetResource;
            options.TargetResourceGroup = targetResourceGroup;
            options.TargetResourceType = targetResourceType;
            options.MonitorService = monitorService;
            options.MonitorCondition = monitorCondition;
            options.Severity = severity;
            options.SmartGroupState = smartGroupState;
            options.TimeRange = timeRange;
            options.PageCount = pageCount;
            options.SortBy = sortBy;
            options.SortOrder = sortOrder;
            return GetAllAsync(options, cancellationToken);
        }

        /// <summary>
        /// List all the Smart Groups within a specified subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.AlertsManagement/smartGroups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SmartGroups_GetAll</description>
        /// </item>
        /// </list>
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
            SmartGroupCollectionGetAllOptions options = new SmartGroupCollectionGetAllOptions();
            options.TargetResource = targetResource;
            options.TargetResourceGroup = targetResourceGroup;
            options.TargetResourceType = targetResourceType;
            options.MonitorService = monitorService;
            options.MonitorCondition = monitorCondition;
            options.Severity = severity;
            options.SmartGroupState = smartGroupState;
            options.TimeRange = timeRange;
            options.PageCount = pageCount;
            options.SortBy = sortBy;
            options.SortOrder = sortOrder;
            return GetAll(options, cancellationToken);
        }
    }
}
