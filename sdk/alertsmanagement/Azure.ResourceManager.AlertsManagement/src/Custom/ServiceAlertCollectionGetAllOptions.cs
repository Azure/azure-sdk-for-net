// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.AlertsManagement.Models
{
    // Backward-compatible wrapper over the generated query parameter overload for listing alerts.
    public partial class ServiceAlertCollectionGetAllOptions
    {
        public string TargetResource { get; set; }
        public string TargetResourceType { get; set; }
        public string TargetResourceGroup { get; set; }
        public MonitorServiceSourceForAlert? MonitorService { get; set; }
        public MonitorCondition? MonitorCondition { get; set; }
        public ServiceAlertSeverity? Severity { get; set; }
        public ServiceAlertState? AlertState { get; set; }
        public string AlertRule { get; set; }
        public string SmartGroupId { get; set; }
        public bool? IncludeContext { get; set; }
        public bool? IncludeEgressConfig { get; set; }
        public long? PageCount { get; set; }
        public ListServiceAlertsSortByField? SortBy { get; set; }
        public AlertsManagementQuerySortOrder? SortOrder { get; set; }
        public string Select { get; set; }
        public TimeRangeFilter? TimeRange { get; set; }
        public string CustomTimeRange { get; set; }
    }
}
