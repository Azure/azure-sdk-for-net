// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.AlertsManagement.Models;

namespace Azure.ResourceManager.AlertsManagement.Mocking
{
    public partial class MockableAlertsManagementSubscriptionResource : ArmResource
    {
        /// <summary>
        /// Get a summarized count of your alerts grouped by various parameters (e.g. grouping by &apos;Severity&apos; returns the count of alerts for each severity).
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.AlertsManagement/alertsSummary</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Alerts_GetSummary</description>
        /// </item>
        /// </list>
        /// </summary>
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
        public virtual async Task<Response<ServiceAlertSummary>> GetServiceAlertSummaryAsync(AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = null, string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, MonitorServiceSourceForAlert? monitorService = null, MonitorCondition? monitorCondition = null, ServiceAlertSeverity? severity = null, ServiceAlertState? alertState = null, string alertRule = null, TimeRangeFilter? timeRange = null, string customTimeRange = null, CancellationToken cancellationToken = default)
        {
            SubscriptionResourceGetServiceAlertSummaryOptions options = new SubscriptionResourceGetServiceAlertSummaryOptions(groupby);
            options.IncludeSmartGroupsCount = includeSmartGroupsCount;
            options.TargetResource = targetResource;
            options.TargetResourceType = targetResourceType;
            options.TargetResourceGroup = targetResourceGroup;
            options.MonitorService = monitorService;
            options.MonitorCondition = monitorCondition;
            options.Severity = severity;
            options.AlertState = alertState;
            options.AlertRule = alertRule;
            options.TimeRange = timeRange;
            options.CustomTimeRange = customTimeRange;
            return await GetServiceAlertSummaryAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a summarized count of your alerts grouped by various parameters (e.g. grouping by &apos;Severity&apos; returns the count of alerts for each severity).
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.AlertsManagement/alertsSummary</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Alerts_GetSummary</description>
        /// </item>
        /// </list>
        /// </summary>
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
        public virtual Response<ServiceAlertSummary> GetServiceAlertSummary(AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = null, string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, MonitorServiceSourceForAlert? monitorService = null, MonitorCondition? monitorCondition = null, ServiceAlertSeverity? severity = null, ServiceAlertState? alertState = null, string alertRule = null, TimeRangeFilter? timeRange = null, string customTimeRange = null, CancellationToken cancellationToken = default)
        {
            SubscriptionResourceGetServiceAlertSummaryOptions options = new SubscriptionResourceGetServiceAlertSummaryOptions(groupby);
            options.IncludeSmartGroupsCount = includeSmartGroupsCount;
            options.TargetResource = targetResource;
            options.TargetResourceType = targetResourceType;
            options.TargetResourceGroup = targetResourceGroup;
            options.MonitorService = monitorService;
            options.MonitorCondition = monitorCondition;
            options.Severity = severity;
            options.AlertState = alertState;
            options.AlertRule = alertRule;
            options.TimeRange = timeRange;
            options.CustomTimeRange = customTimeRange;
            return GetServiceAlertSummary(options, cancellationToken);
        }
    }
}
