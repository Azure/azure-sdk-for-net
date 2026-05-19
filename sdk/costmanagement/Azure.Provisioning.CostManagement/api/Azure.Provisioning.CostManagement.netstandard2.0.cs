namespace Azure.Provisioning.CostManagement
{
    public enum AccumulatedType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="true")]
        True = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="false")]
        False = 1,
    }
    public enum AlertCriterion
    {
        CostThresholdExceeded = 0,
        UsageThresholdExceeded = 1,
        CreditThresholdApproaching = 2,
        CreditThresholdReached = 3,
        QuotaThresholdApproaching = 4,
        QuotaThresholdReached = 5,
        MultiCurrency = 6,
        ForecastCostThresholdExceeded = 7,
        ForecastUsageThresholdExceeded = 8,
        InvoiceDueDateApproaching = 9,
        InvoiceDueDateReached = 10,
        CrossCloudNewDataAvailable = 11,
        CrossCloudCollectionError = 12,
        GeneralThresholdError = 13,
    }
    public partial class AlertPropertiesDefinition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AlertPropertiesDefinition() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.CostManagementAlertType> AlertType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.CostManagementAlertCategory> Category { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.AlertCriterion> Criteria { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AlertPropertiesDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AlertPropertiesDetails() { }
        public Azure.Provisioning.BicepValue<decimal> Amount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CompanyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ContactEmails { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ContactGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ContactRoles { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<decimal> CurrentSpend { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DepartmentName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EnrollmentEndDate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EnrollmentNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EnrollmentStartDate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<decimal> InvoicingThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> MeterFilter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.CostManagementAlertOperator> Operator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OverridingAlert { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PeriodStartDate { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> ResourceFilter { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> ResourceGroupFilter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> TagFilter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<decimal> Threshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.AlertTimeGrainType> TimeGrainType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TriggeredBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Unit { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AlertTimeGrainType
    {
        None = 0,
        Monthly = 1,
        Quarterly = 2,
        Annually = 3,
        BillingMonth = 4,
        BillingQuarter = 5,
        BillingAnnual = 6,
    }
    public partial class BudgetComparisonExpression : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BudgetComparisonExpression() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.BudgetOperatorType> Operator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BudgetFilter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BudgetFilter() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.BudgetFilterProperties> And { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.BudgetComparisonExpression Dimensions { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.BudgetComparisonExpression Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BudgetFilterProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BudgetFilterProperties() { }
        public Azure.Provisioning.CostManagement.BudgetComparisonExpression Dimensions { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.BudgetComparisonExpression Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BudgetNotification : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BudgetNotification() { }
        public Azure.Provisioning.BicepList<string> ContactEmails { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ContactGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ContactRoles { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.Frequency> Frequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.CultureCode> Locale { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.BudgetNotificationOperatorType> Operator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> Threshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ThresholdType> ThresholdType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BudgetNotificationOperatorType
    {
        EqualTo = 0,
        GreaterThan = 1,
        GreaterThanOrEqualTo = 2,
        LessThan = 3,
    }
    public enum BudgetOperatorType
    {
        In = 0,
    }
    public partial class BudgetTimePeriod : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BudgetTimePeriod() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CategoryType
    {
        Cost = 0,
        ReservationUtilization = 1,
    }
    public partial class CommonExportProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CommonExportProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.CompressionModeType> CompressionMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.DataOverwriteBehaviorType> DataOverwriteBehavior { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.ExportDefinition Definition { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.ExportDeliveryDestination DeliveryInfoDestination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExportDescription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ExportFormatType> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NextRunTimeEstimate { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> PartitionData { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.ExportRun> RunHistoryValue { get { throw null; } }
        public Azure.Provisioning.CostManagement.ExportSuspensionContext SystemSuspensionContext { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ComparisonOperatorType
    {
        In = 0,
        Contains = 1,
    }
    public enum CompressionModeType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="gzip")]
        Gzip = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="snappy")]
        Snappy = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="none")]
        None = 2,
    }
    public enum CostAllocationPolicyType
    {
        FixedProportion = 0,
    }
    public partial class CostAllocationProportion : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CostAllocationProportion() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> Percentage { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CostAllocationResourceType
    {
        Dimension = 0,
        Tag = 1,
    }
    public partial class CostAllocationRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CostAllocationRule(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.CostAllocationRuleProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CostManagement.CostAllocationRule FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_03_01;
        }
    }
    public partial class CostAllocationRuleDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CostAllocationRuleDetails() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.SourceCostAllocationEntity> SourceResources { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.TargetCostAllocationEntity> TargetResources { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CostAllocationRuleProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CostAllocationRuleProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.CostAllocationRuleDetails Details { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.RuleStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CostManagementAlert : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CostManagementAlert(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CloseOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CostEntityId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.AlertPropertiesDefinition Definition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.AlertPropertiesDetails Details { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ModifiedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.CostManagementAlertSource> Source { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.CostManagementAlertStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StatusModificationUserName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StatusModifiedOn { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CostManagement.CostManagementAlert FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_03_01;
        }
    }
    public enum CostManagementAlertCategory
    {
        Cost = 0,
        Usage = 1,
        Billing = 2,
        System = 3,
    }
    public enum CostManagementAlertOperator
    {
        None = 0,
        EqualTo = 1,
        GreaterThan = 2,
        GreaterThanOrEqualTo = 3,
        LessThan = 4,
        LessThanOrEqualTo = 5,
    }
    public enum CostManagementAlertSource
    {
        Preset = 0,
        User = 1,
    }
    public enum CostManagementAlertStatus
    {
        None = 0,
        Active = 1,
        Overridden = 2,
        Resolved = 3,
        Dismissed = 4,
    }
    public enum CostManagementAlertType
    {
        Budget = 0,
        Invoice = 1,
        Credit = 2,
        Quota = 3,
        General = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="xCloud")]
        XCloud = 5,
        BudgetForecast = 6,
    }
    public partial class CostManagementBudget : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CostManagementBudget(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<float> Amount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.CategoryType> BudgetCategory { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.TimeGrainType> BudgetTimeGrain { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.CurrentSpend CurrentSpend { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.BudgetFilter Filter { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.ForecastSpend ForecastSpend { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.CostManagement.BudgetNotification> Notifications { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.CostManagement.BudgetTimePeriod TimePeriod { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CostManagement.CostManagementBudget FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_03_01;
        }
    }
    public partial class CostManagementExport : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CostManagementExport(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.CompressionModeType> CompressionMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.DataOverwriteBehaviorType> DataOverwriteBehavior { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.ExportDefinition Definition { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.ExportDeliveryDestination DeliveryInfoDestination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExportDescription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ExportFormatType> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NextRunTimeEstimate { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> PartitionData { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.ExportRun> RunHistoryValue { get { throw null; } }
        public Azure.Provisioning.CostManagement.ExportSchedule Schedule { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.CostManagement.ExportSuspensionContext SystemSuspensionContext { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CostManagement.CostManagementExport FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_03_01;
        }
    }
    public partial class CostManagementSetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CostManagementSetting(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CostManagement.CostManagementSetting FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_03_01;
        }
    }
    public partial class CostManagementViews : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CostManagementViews(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.AccumulatedType> Accumulated { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ViewChartType> Chart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Currency { get { throw null; } }
        public Azure.Provisioning.CostManagement.ReportConfigDataset DataSet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DateRange { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IncludeMonetaryCommitment { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.ViewKpiProperties> Kpis { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ViewMetricType> Metric { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ModifiedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.ViewPivotProperties> Pivots { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ReportTimeframeType> Timeframe { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.ReportConfigTimePeriod TimePeriod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ViewReportType> TypePropertiesQueryType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CostManagement.CostManagementViews FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_03_01;
        }
    }
    public enum CultureCode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="en-us")]
        EnUs = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ja-jp")]
        JaJp = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="zh-cn")]
        ZhCn = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="de-de")]
        DeDe = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="es-es")]
        EsEs = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="fr-fr")]
        FrFr = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="it-it")]
        ItIt = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ko-kr")]
        KoKr = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="pt-br")]
        PtBr = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ru-ru")]
        RuRu = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="zh-tw")]
        ZhTw = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="cs-cz")]
        CsCz = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="pl-pl")]
        PlPl = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="tr-tr")]
        TrTr = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="da-dk")]
        DaDk = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="en-gb")]
        EnGb = 15,
        [System.Runtime.Serialization.DataMemberAttribute(Name="hu-hu")]
        HuHu = 16,
        [System.Runtime.Serialization.DataMemberAttribute(Name="nb-no")]
        NbNo = 17,
        [System.Runtime.Serialization.DataMemberAttribute(Name="nl-nl")]
        NlNl = 18,
        [System.Runtime.Serialization.DataMemberAttribute(Name="pt-pt")]
        PtPt = 19,
        [System.Runtime.Serialization.DataMemberAttribute(Name="sv-se")]
        SvSe = 20,
    }
    public partial class CurrentSpend : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CurrentSpend() { }
        public Azure.Provisioning.BicepValue<float> Amount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Unit { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataOverwriteBehaviorType
    {
        OverwritePreviousReport = 0,
        CreateNewReport = 1,
    }
    public enum DestinationType
    {
        AzureBlob = 0,
    }
    public partial class ExportDataset : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExportDataset() { }
        public Azure.Provisioning.BicepList<string> Columns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DataVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.FilterItems> Filters { get { throw null; } set { } }
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
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.DestinationType> Type { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExportDeliveryInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExportDeliveryInfo() { }
        public Azure.Provisioning.CostManagement.ExportDeliveryDestination Destination { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ExportFormatType
    {
        Csv = 0,
        Parquet = 1,
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
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.ExportRunErrorDetails Error { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ExportRunExecutionType> ExecutionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ManifestFile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProcessingEndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProcessingStartOn { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.CommonExportProperties RunSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ExportRunExecutionStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubmittedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> SubmittedOn { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> Type { get { throw null; } }
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
    public partial class ExportSuspensionContext : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExportSuspensionContext() { }
        public Azure.Provisioning.BicepValue<string> SuspensionCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> SuspensionOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SuspensionReason { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
        FocusCost = 3,
        PriceSheet = 4,
        ReservationTransactions = 5,
        ReservationRecommendations = 6,
        ReservationDetails = 7,
    }
    public enum FilterItemNames
    {
        ReservationScope = 0,
        ResourceType = 1,
        LookBackPeriod = 2,
    }
    public partial class FilterItems : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FilterItems() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.FilterItemNames> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ForecastSpend : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ForecastSpend() { }
        public Azure.Provisioning.BicepValue<float> Amount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Unit { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum Frequency
    {
        Daily = 0,
        Weekly = 1,
        Monthly = 2,
    }
    public enum FunctionType
    {
        Sum = 0,
    }
    public partial class GenerateDetailedCostReportOperationResult : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public GenerateDetailedCostReportOperationResult(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Uri> DownloadUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiryOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ValidTill { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CostManagement.GenerateDetailedCostReportOperationResult FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_03_01;
        }
    }
    public partial class GenerateDetailedCostReportOperationStatuses : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public GenerateDetailedCostReportOperationStatuses(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Uri> DownloadUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EndTime { get { throw null; } set { } }
        public Azure.Provisioning.CostManagement.ExportRunErrorDetails Error { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiryOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ReportOperationStatusType> StatusValue { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ValidTill { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CostManagement.GenerateDetailedCostReportOperationStatuses FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_03_01;
        }
    }
    public enum GranularityType
    {
        Daily = 0,
        Monthly = 1,
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
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.FunctionType> Function { get { throw null; } set { } }
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
    public enum ReportOperationStatusType
    {
        InProgress = 0,
        Completed = 1,
        Failed = 2,
        Queued = 3,
        NoDataFound = 4,
        ReadyToDownload = 5,
        TimedOut = 6,
    }
    public enum ReportTimeframeType
    {
        WeekToDate = 0,
        MonthToDate = 1,
        YearToDate = 2,
        Custom = 3,
    }
    public enum RuleStatus
    {
        NotActive = 0,
        Active = 1,
        Processing = 2,
    }
    public partial class ScheduledAction : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ScheduledAction(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
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
        public static Azure.Provisioning.CostManagement.ScheduledAction FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_03_01;
        }
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
        Enabled = 0,
        Expired = 1,
        Disabled = 2,
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
    public partial class SourceCostAllocationEntity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SourceCostAllocationEntity() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.CostAllocationResourceType> ResourceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TagInheritanceSetting : Azure.Provisioning.CostManagement.CostManagementSetting
    {
        public TagInheritanceSetting(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> TagInheritancePreferContainerTags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TargetCostAllocationEntity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TargetCostAllocationEntity() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.CostAllocationPolicyType> PolicyType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.CostAllocationResourceType> ResourceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CostManagement.CostAllocationProportion> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TenantScheduledAction : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TenantScheduledAction(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CostManagement.ScheduledActionKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CostManagement.TenantScheduledAction FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_03_01;
        }
    }
    public partial class TenantsCostManagementViews : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TenantsCostManagementViews(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CostManagement.TenantsCostManagementViews FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_03_01;
        }
    }
    public enum ThresholdType
    {
        Actual = 0,
        Forecasted = 1,
    }
    public enum TimeframeType
    {
        MonthToDate = 0,
        BillingMonthToDate = 1,
        TheLastMonth = 2,
        TheLastBillingMonth = 3,
        WeekToDate = 4,
        Custom = 5,
        TheCurrentMonth = 6,
    }
    public enum TimeGrainType
    {
        Monthly = 0,
        Quarterly = 1,
        Annually = 2,
        BillingMonth = 3,
        BillingQuarter = 4,
        BillingAnnual = 5,
        Last7Days = 6,
        Last30Days = 7,
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
