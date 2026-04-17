namespace Azure.Provisioning.CostManagement
{
    public enum AccumulatedType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="true")]
        True = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="false")]
        False = 1,
    }
    public partial class CommonExportProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CommonExportProperties() { }
        public Azure.Provisioning.CostManagement.ExportDefinition Definition { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.ExportDeliveryDestination DeliveryInfoDestination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ExportFormatType> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NextRunTimeEstimate { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> PartitionData { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.ExportRun> RunHistoryValue { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ComparisonOperatorType
    {
        In = 0,
        Contains = 1,
    }
    public partial class CostManagementExport : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CostManagementExport(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.CostManagement.ExportDefinition Definition { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.ExportDeliveryDestination DeliveryInfoDestination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ExportFormatType> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NextRunTimeEstimate { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> PartitionData { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.ExportRun> RunHistoryValue { get { throw null; } }
        public Azure.Provisioning.CostManagement.ExportSchedule Schedule { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CostManagement.CostManagementExport FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_03_01;
        }
    }
    public enum CostManagementFunctionType
    {
        Sum = 0,
    }
    public partial class CostManagementScheduledAction : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CostManagementScheduledAction(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.ScheduledActionFileFormat> FileFormats { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ScheduledActionKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.NotificationProperties Notification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NotificationEmail { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.ScheduleProperties Schedule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ScheduledActionStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ViewId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CostManagement.CostManagementScheduledAction FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_03_01;
        }
    }
    public partial class CostManagementViews : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CostManagementViews(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.AccumulatedType> Accumulated { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ViewChartType> Chart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Currency { get { throw null; } }
        public Azure.Provisioning.CostManagement.ReportConfigDataset DataSet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DateRange { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IncludeMonetaryCommitment { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.ViewKpiProperties> Kpis { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ViewMetricType> Metric { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.ViewPivotProperties> Pivots { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ReportTimeframeType> Timeframe { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.ReportConfigTimePeriod TimePeriod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ViewReportType> TypePropertiesQueryType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CostManagement.CostManagementViews FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_03_01;
        }
    }
    public partial class ExportDataset : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExportDataset() { }
        public Azure.Provisioning.BicepList<string> Columns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.GranularityType> Granularity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExportDefinition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExportDefinition() { }
        public Azure.Provisioning.CostManagement.ExportDataset DataSet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ExportType> ExportType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.TimeframeType> Timeframe { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.ExportTimePeriod TimePeriod { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExportDeliveryDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExportDeliveryDestination() { }
        public Azure.Provisioning.BicepValue<string> Container { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RootFolderPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SasToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ExportFormatType
    {
        Csv = 0,
    }
    public partial class ExportRecurrencePeriod : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExportRecurrencePeriod() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> From { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> To { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExportRun : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExportRun() { }
        public Azure.Provisioning.CostManagement.ExportRunErrorDetails Error { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ExportRunExecutionType> ExecutionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProcessingEndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProcessingStartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.CostManagement.CommonExportProperties RunSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ExportRunExecutionStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubmittedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> SubmittedOn { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExportRunErrorDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExportRunErrorDetails() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ExportRunExecutionStatus
    {
        Queued = 0,
        InProgress = 1,
        Completed = 2,
        Failed = 3,
        Timeout = 4,
        NewDataNotAvailable = 5,
        DataNotAvailable = 6,
    }
    public enum ExportRunExecutionType
    {
        OnDemand = 0,
        Scheduled = 1,
    }
    public partial class ExportSchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExportSchedule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ExportScheduleRecurrenceType> Recurrence { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.ExportRecurrencePeriod RecurrencePeriod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ExportScheduleStatusType> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ExportScheduleRecurrenceType
    {
        Daily = 0,
        Weekly = 1,
        Monthly = 2,
        Annually = 3,
    }
    public enum ExportScheduleStatusType
    {
        Active = 0,
        Inactive = 1,
    }
    public partial class ExportTimePeriod : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExportTimePeriod() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> From { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> To { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ExportType
    {
        Usage = 0,
        ActualCost = 1,
        AmortizedCost = 2,
    }
    public enum GranularityType
    {
        Daily = 0,
    }
    public partial class NotificationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NotificationProperties() { }
        public Azure.Provisioning.BicepValue<string> Language { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RegionalFormat { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Subject { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> To { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum QueryColumnType
    {
        TagKey = 0,
        Dimension = 1,
    }
    public partial class ReportConfigAggregation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReportConfigAggregation() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.CostManagementFunctionType> Function { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ReportConfigComparisonExpression : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReportConfigComparisonExpression() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ComparisonOperatorType> Operator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ReportConfigDataset : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReportConfigDataset() { }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.CostManagement.ReportConfigAggregation> Aggregation { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Columns { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.ReportConfigFilter Filter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ReportGranularityType> Granularity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.ReportConfigGrouping> Grouping { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.ReportConfigSorting> Sorting { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ReportConfigFilter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReportConfigFilter() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.ReportConfigFilter> And { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.ReportConfigComparisonExpression Dimensions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.ReportConfigFilter> Or { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.ReportConfigComparisonExpression Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ReportConfigGrouping : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReportConfigGrouping() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.QueryColumnType> QueryColumnType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ReportConfigSorting : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReportConfigSorting() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ReportConfigSortingType> Direction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ReportConfigSortingType
    {
        Ascending = 0,
        Descending = 1,
    }
    public partial class ReportConfigTimePeriod : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReportConfigTimePeriod() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> From { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> To { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ReportGranularityType
    {
        Daily = 0,
        Monthly = 1,
    }
    public enum ReportTimeframeType
    {
        WeekToDate = 0,
        MonthToDate = 1,
        YearToDate = 2,
        Custom = 3,
    }
    public enum ScheduledActionDaysOfWeek
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6,
    }
    public enum ScheduledActionFileFormat
    {
        Csv = 0,
    }
    public enum ScheduledActionKind
    {
        Email = 0,
        InsightAlert = 1,
    }
    public enum ScheduledActionStatus
    {
        Disabled = 0,
        Enabled = 1,
        Expired = 2,
    }
    public enum ScheduledActionWeeksOfMonth
    {
        First = 0,
        Second = 1,
        Third = 2,
        Fourth = 3,
        Last = 4,
    }
    public enum ScheduleFrequency
    {
        Daily = 0,
        Weekly = 1,
        Monthly = 2,
    }
    public partial class ScheduleProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScheduleProperties() { }
        public Azure.Provisioning.BicepValue<int> DayOfMonth { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.ScheduledActionDaysOfWeek> DaysOfWeek { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ScheduleFrequency> Frequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HourOfDay { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.ScheduledActionWeeksOfMonth> WeeksOfMonth { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TenantCostManagementScheduledAction : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TenantCostManagementScheduledAction(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.ScheduledActionFileFormat> FileFormats { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ScheduledActionKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.NotificationProperties Notification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NotificationEmail { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.ScheduleProperties Schedule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ScheduledActionStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ViewId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CostManagement.TenantCostManagementScheduledAction FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_03_01;
        }
    }
    public partial class TenantsCostManagementViews : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TenantsCostManagementViews(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.AccumulatedType> Accumulated { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ViewChartType> Chart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Currency { get { throw null; } }
        public Azure.Provisioning.CostManagement.ReportConfigDataset DataSet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DateRange { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IncludeMonetaryCommitment { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.ViewKpiProperties> Kpis { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ViewMetricType> Metric { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.ViewPivotProperties> Pivots { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ReportTimeframeType> Timeframe { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.ReportConfigTimePeriod TimePeriod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ViewReportType> TypePropertiesQueryType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CostManagement.TenantsCostManagementViews FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_03_01;
        }
    }
    public enum TimeframeType
    {
        MonthToDate = 0,
        BillingMonthToDate = 1,
        TheLastMonth = 2,
        TheLastBillingMonth = 3,
        WeekToDate = 4,
        Custom = 5,
    }
    public enum ViewChartType
    {
        Area = 0,
        Line = 1,
        StackedColumn = 2,
        GroupedColumn = 3,
        Table = 4,
    }
    public partial class ViewKpiProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ViewKpiProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ViewKpiType> KpiType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ViewKpiType
    {
        Forecast = 0,
        Budget = 1,
    }
    public enum ViewMetricType
    {
        ActualCost = 0,
        AmortizedCost = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AHUB")]
        Ahub = 2,
    }
    public partial class ViewPivotProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ViewPivotProperties() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ViewPivotType> PivotType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ViewPivotType
    {
        Dimension = 0,
        TagKey = 1,
    }
    public enum ViewReportType
    {
        Usage = 0,
    }
}
