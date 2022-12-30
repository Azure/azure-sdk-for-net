// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.AlertsManagement.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AlertsManagement
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.AlertsManagement. </summary>
    public static partial class AlertsManagementExtensions
    {
        /// <summary>
        /// Get a summarized count of your alerts grouped by various parameters (e.g. grouping by &apos;Severity&apos; returns the count of alerts for each severity).
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.AlertsManagement/alertsSummary
        /// Operation Id: Alerts_GetSummary
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="groupby"> This parameter allows the result set to be grouped by input fields (Maximum 2 comma separated fields supported). For example, groupby=severity or groupby=severity,alertstate. </param>
        /// <param name="includeSmartGroupsCount"> Include count of the SmartGroups as part of the summary. Default value is &apos;false&apos;. </param>
        /// <param name="targetResource"> Filter by target resource( which is full ARM ID) Default value is select all. </param>
        /// <param name="targetResourceType"> Filter by target resource type. Default value is select all. </param>
        /// <param name="targetResourceGroup"> Filter by target resource group name. Default value is select all. </param>
        /// <param name="monitorService"> Filter by monitor service which generates the alert instance. Default value is select all. </param>
        /// <param name="monitorCondition"> Filter by monitor condition which is either &apos;Fired&apos; or &apos;Resolved&apos;. Default value is to select all. </param>
        /// <param name="severity"> Filter by severity.  Default value is select all. </param>
        /// <param name="alertState"> Filter by state of the alert instance. Default value is to select all. </param>
        /// <param name="alertRule"> Filter by specific alert rule.  Default value is to select all. </param>
        /// <param name="timeRange"> Filter by time range by below listed values. Default value is 1 day. </param>
        /// <param name="customTimeRange"> Filter by custom time range in the format &lt;start-time&gt;/&lt;end-time&gt;  where time is in (ISO-8601 format)&apos;. Permissible values is within 30 days from  query time. Either timeRange or customTimeRange could be used but not both. Default is none. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static async Task<Response<ServiceAlertSummary>> GetServiceAlertSummaryAsync(this SubscriptionResource subscriptionResource, AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = null, string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, MonitorServiceSourceForAlert? monitorService = null, MonitorCondition? monitorCondition = null, ServiceAlertSeverity? severity = null, ServiceAlertState? alertState = null, string alertRule = null, TimeRangeFilter? timeRange = null, string customTimeRange = null, CancellationToken cancellationToken = default) =>
            await GetServiceAlertSummaryAsync(subscriptionResource, new AlertsManagementExtensionsGetServiceAlertSummaryOptions(groupby)
            {
                IncludeSmartGroupsCount = includeSmartGroupsCount,
                TargetResource = targetResource,
                TargetResourceType = targetResourceType,
                TargetResourceGroup = targetResourceGroup,
                MonitorService = monitorService,
                MonitorCondition = monitorCondition,
                Severity = severity,
                AlertState = alertState,
                AlertRule = alertRule,
                TimeRange = timeRange,
                CustomTimeRange = customTimeRange
            }, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get a summarized count of your alerts grouped by various parameters (e.g. grouping by &apos;Severity&apos; returns the count of alerts for each severity).
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.AlertsManagement/alertsSummary
        /// Operation Id: Alerts_GetSummary
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="groupby"> This parameter allows the result set to be grouped by input fields (Maximum 2 comma separated fields supported). For example, groupby=severity or groupby=severity,alertstate. </param>
        /// <param name="includeSmartGroupsCount"> Include count of the SmartGroups as part of the summary. Default value is &apos;false&apos;. </param>
        /// <param name="targetResource"> Filter by target resource( which is full ARM ID) Default value is select all. </param>
        /// <param name="targetResourceType"> Filter by target resource type. Default value is select all. </param>
        /// <param name="targetResourceGroup"> Filter by target resource group name. Default value is select all. </param>
        /// <param name="monitorService"> Filter by monitor service which generates the alert instance. Default value is select all. </param>
        /// <param name="monitorCondition"> Filter by monitor condition which is either &apos;Fired&apos; or &apos;Resolved&apos;. Default value is to select all. </param>
        /// <param name="severity"> Filter by severity.  Default value is select all. </param>
        /// <param name="alertState"> Filter by state of the alert instance. Default value is to select all. </param>
        /// <param name="alertRule"> Filter by specific alert rule.  Default value is to select all. </param>
        /// <param name="timeRange"> Filter by time range by below listed values. Default value is 1 day. </param>
        /// <param name="customTimeRange"> Filter by custom time range in the format &lt;start-time&gt;/&lt;end-time&gt;  where time is in (ISO-8601 format)&apos;. Permissible values is within 30 days from  query time. Either timeRange or customTimeRange could be used but not both. Default is none. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static Response<ServiceAlertSummary> GetServiceAlertSummary(this SubscriptionResource subscriptionResource, AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = null, string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, MonitorServiceSourceForAlert? monitorService = null, MonitorCondition? monitorCondition = null, ServiceAlertSeverity? severity = null, ServiceAlertState? alertState = null, string alertRule = null, TimeRangeFilter? timeRange = null, string customTimeRange = null, CancellationToken cancellationToken = default) =>
            GetServiceAlertSummary(subscriptionResource, new AlertsManagementExtensionsGetServiceAlertSummaryOptions(groupby)
            {
                IncludeSmartGroupsCount = includeSmartGroupsCount,
                TargetResource = targetResource,
                TargetResourceType = targetResourceType,
                TargetResourceGroup = targetResourceGroup,
                MonitorService = monitorService,
                MonitorCondition = monitorCondition,
                Severity = severity,
                AlertState = alertState,
                AlertRule = alertRule,
                TimeRange = timeRange,
                CustomTimeRange = customTimeRange
            }, cancellationToken);
    }
}
