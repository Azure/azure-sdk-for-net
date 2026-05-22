// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.AlertsManagement.Models
{
    // Backward compatibility: the old SDK (AutoRest-based, v1.1.1) provided this options class
    // for the Alerts_GetSummary operation on SubscriptionResource. It groups the required groupby
    // parameter and 11 optional filter parameters into a single object. The new TypeSpec generator
    // does not produce this wrapper class.
    /// <summary> Options for the Alerts_GetSummary operation on a subscription. Groups the required <c>groupby</c> parameter together with the optional filter parameters into a single object. Provided for backward compatibility with the AutoRest-based v1.1.1 SDK. </summary>
    public partial class SubscriptionResourceGetServiceAlertSummaryOptions
    {
        /// <summary> Initializes a new instance of <see cref="SubscriptionResourceGetServiceAlertSummaryOptions"/>. </summary>
        /// <param name="groupby"> This parameter allows the result set to be grouped by input fields. For example, <c>groupby=severity,alertstate</c>. </param>
        public SubscriptionResourceGetServiceAlertSummaryOptions(AlertsSummaryGroupByField groupby)
        {
            Groupby = groupby;
        }

        /// <summary> This parameter allows the result set to be grouped by input fields. For example, <c>groupby=severity,alertstate</c>. </summary>
        public AlertsSummaryGroupByField Groupby { get; }
        /// <summary> Include count of the SmartGroups as part of the summary. Default value is 'false'. </summary>
        public bool? IncludeSmartGroupsCount { get; set; }
        /// <summary> Filter by target resource (which is full ARM ID). Default value is select all. </summary>
        public string TargetResource { get; set; }
        /// <summary> Filter by target resource type. Default value is select all. </summary>
        public string TargetResourceType { get; set; }
        /// <summary> Filter by target resource group name. Default value is select all. </summary>
        public string TargetResourceGroup { get; set; }
        /// <summary> Filter by monitor service which generates the alert instance. Default value is select all. </summary>
        public MonitorServiceSourceForAlert? MonitorService { get; set; }
        /// <summary> Filter by monitor condition which is either 'Fired' or 'Resolved'. Default value is to select all. </summary>
        public MonitorCondition? MonitorCondition { get; set; }
        /// <summary> Filter by severity. Default value is select all. </summary>
        public ServiceAlertSeverity? Severity { get; set; }
        /// <summary> Filter by state of the alert instance. Default value is to select all. </summary>
        public ServiceAlertState? AlertState { get; set; }
        /// <summary> Filter by specific alert rule. Default value is to select all. </summary>
        public string AlertRule { get; set; }
        /// <summary> Filter by time range. Default value is 1 day. </summary>
        public TimeRangeFilter? TimeRange { get; set; }
        /// <summary> Filter by custom time range in the format &lt;start-time&gt;/&lt;end-time&gt; where time is in (ISO-8601 format). Permissible values are within 30 days from query time. Either TimeRange or CustomTimeRange may be used, but not both. Default is none. </summary>
        public string CustomTimeRange { get; set; }
    }
}
