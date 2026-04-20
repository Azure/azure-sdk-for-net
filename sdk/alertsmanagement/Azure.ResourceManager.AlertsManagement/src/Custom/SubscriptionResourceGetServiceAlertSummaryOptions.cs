// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.AlertsManagement.Models
{
    // Backward compatibility: the old SDK (AutoRest-based, v1.1.1) provided this options class
    // for the Alerts_GetSummary operation on SubscriptionResource. It groups the required groupby
    // parameter and 11 optional filter parameters into a single object. The new TypeSpec generator
    // does not produce this wrapper class.
    public partial class SubscriptionResourceGetServiceAlertSummaryOptions
    {
        public SubscriptionResourceGetServiceAlertSummaryOptions(AlertsSummaryGroupByField groupby)
        {
            Groupby = groupby;
        }

        public AlertsSummaryGroupByField Groupby { get; }
        public bool? IncludeSmartGroupsCount { get; set; }
        public string TargetResource { get; set; }
        public string TargetResourceType { get; set; }
        public string TargetResourceGroup { get; set; }
        public MonitorServiceSourceForAlert? MonitorService { get; set; }
        public MonitorCondition? MonitorCondition { get; set; }
        public ServiceAlertSeverity? Severity { get; set; }
        public ServiceAlertState? AlertState { get; set; }
        public string AlertRule { get; set; }
        public TimeRangeFilter? TimeRange { get; set; }
        public string CustomTimeRange { get; set; }
    }
}
