// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.AlertsManagement.Models
{
    // Backward-compatible wrapper over the generated summary parameter overload.
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
