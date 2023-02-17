// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.ResourceManager.AlertsManagement.Models;

namespace Azure.ResourceManager.AlertsManagement
{
    public partial class ServiceAlertCollection
    {
        /// <summary>
        /// List all existing alerts, where the results can be filtered on the basis of multiple parameters (e.g. time range). The results can then be sorted on the basis specific fields, with the default being lastModifiedDateTime.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.AlertsManagement/alerts</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Alerts_GetAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="targetResource"> Filter by target resource( which is full ARM ID) Default value is select all. </param>
        /// <param name="targetResourceType"> Filter by target resource type. Default value is select all. </param>
        /// <param name="targetResourceGroup"> Filter by target resource group name. Default value is select all. </param>
        /// <param name="monitorService"> Filter by monitor service which generates the alert instance. Default value is select all. </param>
        /// <param name="monitorCondition"> Filter by monitor condition which is either &apos;Fired&apos; or &apos;Resolved&apos;. Default value is to select all. </param>
        /// <param name="severity"> Filter by severity.  Default value is select all. </param>
        /// <param name="alertState"> Filter by state of the alert instance. Default value is to select all. </param>
        /// <param name="alertRule"> Filter by specific alert rule.  Default value is to select all. </param>
        /// <param name="smartGroupId"> Filter the alerts list by the Smart Group Id. Default value is none. </param>
        /// <param name="includeContext"> Include context which has contextual data specific to the monitor service. Default value is false&apos;. </param>
        /// <param name="includeEgressConfig"> Include egress config which would be used for displaying the content in portal.  Default value is &apos;false&apos;. </param>
        /// <param name="pageCount"> Determines number of alerts returned per page in response. Permissible value is between 1 to 250. When the &quot;includeContent&quot;  filter is selected, maximum value allowed is 25. Default value is 25. </param>
        /// <param name="sortBy"> Sort the query results by input field,  Default value is &apos;lastModifiedDateTime&apos;. </param>
        /// <param name="sortOrder"> Sort the query results order in either ascending or descending.  Default value is &apos;desc&apos; for time fields and &apos;asc&apos; for others. </param>
        /// <param name="select"> This filter allows to selection of the fields(comma separated) which would  be part of the essential section. This would allow to project only the  required fields rather than getting entire content.  Default is to fetch all the fields in the essentials section. </param>
        /// <param name="timeRange"> Filter by time range by below listed values. Default value is 1 day. </param>
        /// <param name="customTimeRange"> Filter by custom time range in the format &lt;start-time&gt;/&lt;end-time&gt;  where time is in (ISO-8601 format)&apos;. Permissible values is within 30 days from  query time. Either timeRange or customTimeRange could be used but not both. Default is none. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ServiceAlertResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ServiceAlertResource> GetAllAsync(string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, MonitorServiceSourceForAlert? monitorService = null, MonitorCondition? monitorCondition = null, ServiceAlertSeverity? severity = null, ServiceAlertState? alertState = null, string alertRule = null, string smartGroupId = null, bool? includeContext = null, bool? includeEgressConfig = null, long? pageCount = null, ListServiceAlertsSortByField? sortBy = null, AlertsManagementQuerySortOrder? sortOrder = null, string select = null, TimeRangeFilter? timeRange = null, string customTimeRange = null, CancellationToken cancellationToken = default)
        {
            ServiceAlertCollectionGetAllOptions options = new ServiceAlertCollectionGetAllOptions();
            options.TargetResource = targetResource;
            options.TargetResourceType = targetResourceType;
            options.TargetResourceGroup = targetResourceGroup;
            options.MonitorService = monitorService;
            options.MonitorCondition = monitorCondition;
            options.Severity = severity;
            options.AlertState = alertState;
            options.AlertRule = alertRule;
            options.SmartGroupId = smartGroupId;
            options.IncludeContext = includeContext;
            options.IncludeEgressConfig = includeEgressConfig;
            options.PageCount = pageCount;
            options.SortBy = sortBy;
            options.SortOrder = sortOrder;
            options.Select = select;
            options.TimeRange = timeRange;
            options.CustomTimeRange = customTimeRange;
            return GetAllAsync(options, cancellationToken);
        }

        /// <summary>
        /// List all existing alerts, where the results can be filtered on the basis of multiple parameters (e.g. time range). The results can then be sorted on the basis specific fields, with the default being lastModifiedDateTime.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.AlertsManagement/alerts</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Alerts_GetAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="targetResource"> Filter by target resource( which is full ARM ID) Default value is select all. </param>
        /// <param name="targetResourceType"> Filter by target resource type. Default value is select all. </param>
        /// <param name="targetResourceGroup"> Filter by target resource group name. Default value is select all. </param>
        /// <param name="monitorService"> Filter by monitor service which generates the alert instance. Default value is select all. </param>
        /// <param name="monitorCondition"> Filter by monitor condition which is either &apos;Fired&apos; or &apos;Resolved&apos;. Default value is to select all. </param>
        /// <param name="severity"> Filter by severity.  Default value is select all. </param>
        /// <param name="alertState"> Filter by state of the alert instance. Default value is to select all. </param>
        /// <param name="alertRule"> Filter by specific alert rule.  Default value is to select all. </param>
        /// <param name="smartGroupId"> Filter the alerts list by the Smart Group Id. Default value is none. </param>
        /// <param name="includeContext"> Include context which has contextual data specific to the monitor service. Default value is false&apos;. </param>
        /// <param name="includeEgressConfig"> Include egress config which would be used for displaying the content in portal.  Default value is &apos;false&apos;. </param>
        /// <param name="pageCount"> Determines number of alerts returned per page in response. Permissible value is between 1 to 250. When the &quot;includeContent&quot;  filter is selected, maximum value allowed is 25. Default value is 25. </param>
        /// <param name="sortBy"> Sort the query results by input field,  Default value is &apos;lastModifiedDateTime&apos;. </param>
        /// <param name="sortOrder"> Sort the query results order in either ascending or descending.  Default value is &apos;desc&apos; for time fields and &apos;asc&apos; for others. </param>
        /// <param name="select"> This filter allows to selection of the fields(comma separated) which would  be part of the essential section. This would allow to project only the  required fields rather than getting entire content.  Default is to fetch all the fields in the essentials section. </param>
        /// <param name="timeRange"> Filter by time range by below listed values. Default value is 1 day. </param>
        /// <param name="customTimeRange"> Filter by custom time range in the format &lt;start-time&gt;/&lt;end-time&gt;  where time is in (ISO-8601 format)&apos;. Permissible values is within 30 days from  query time. Either timeRange or customTimeRange could be used but not both. Default is none. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ServiceAlertResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ServiceAlertResource> GetAll(string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, MonitorServiceSourceForAlert? monitorService = null, MonitorCondition? monitorCondition = null, ServiceAlertSeverity? severity = null, ServiceAlertState? alertState = null, string alertRule = null, string smartGroupId = null, bool? includeContext = null, bool? includeEgressConfig = null, long? pageCount = null, ListServiceAlertsSortByField? sortBy = null, AlertsManagementQuerySortOrder? sortOrder = null, string select = null, TimeRangeFilter? timeRange = null, string customTimeRange = null, CancellationToken cancellationToken = default)
        {
            ServiceAlertCollectionGetAllOptions options = new ServiceAlertCollectionGetAllOptions();
            options.TargetResource = targetResource;
            options.TargetResourceType = targetResourceType;
            options.TargetResourceGroup = targetResourceGroup;
            options.MonitorService = monitorService;
            options.MonitorCondition = monitorCondition;
            options.Severity = severity;
            options.AlertState = alertState;
            options.AlertRule = alertRule;
            options.SmartGroupId = smartGroupId;
            options.IncludeContext = includeContext;
            options.IncludeEgressConfig = includeEgressConfig;
            options.PageCount = pageCount;
            options.SortBy = sortBy;
            options.SortOrder = sortOrder;
            options.Select = select;
            options.TimeRange = timeRange;
            options.CustomTimeRange = customTimeRange;
            return GetAll(options, cancellationToken);
        }
    }
}
