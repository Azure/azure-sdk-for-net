namespace Azure.Provisioning.Monitor
{
    public partial class ActionGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ActionGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorArmRoleReceiver> ArmRoleReceivers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorAutomationRunbookReceiver> AutomationRunbookReceivers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorAzureAppPushReceiver> AzureAppPushReceivers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorAzureFunctionReceiver> AzureFunctionReceivers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorEmailReceiver> EmailReceivers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorEventHubReceiver> EventHubReceivers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupShortName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorItsmReceiver> ItsmReceivers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorLogicAppReceiver> LogicAppReceivers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorSmsReceiver> SmsReceivers { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorVoiceReceiver> VoiceReceivers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorWebhookReceiver> WebhookReceivers { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.ActionGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_01_01;
        }
    }
    public partial class ActivityLogAlert : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ActivityLogAlert(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.ActivityLogAlertActionGroup> ActionsActionGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.ActivityLogAlertAnyOfOrLeafCondition> ConditionAllOf { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Scopes { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.ActivityLogAlert FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_10_01;
        }
    }
    public partial class ActivityLogAlertActionGroup : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ActivityLogAlertActionGroup() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ActionGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> WebhookProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ActivityLogAlertAnyOfOrLeafCondition : Azure.Provisioning.Monitor.AlertRuleLeafCondition
    {
        public ActivityLogAlertAnyOfOrLeafCondition() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.AlertRuleLeafCondition> AnyOf { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AlertRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AlertRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Monitor.AlertRuleAction Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.AlertRuleAction> Actions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AlertRuleName { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.AlertRuleCondition Condition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.AlertRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_03_01;
        }
    }
    public partial class AlertRuleAction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AlertRuleAction() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AlertRuleCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AlertRuleCondition() { }
        public Azure.Provisioning.Monitor.RuleDataSource DataSource { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AlertRuleLeafCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AlertRuleLeafCondition() { }
        public Azure.Provisioning.BicepList<string> ContainsAny { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EqualsValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Field { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AlertSeverity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AlertSeverity() { }
        public Azure.Provisioning.Monitor.AlertSeverity Four { get { throw null; } }
        public Azure.Provisioning.Monitor.AlertSeverity One { get { throw null; } }
        public Azure.Provisioning.Monitor.AlertSeverity Three { get { throw null; } }
        public Azure.Provisioning.Monitor.AlertSeverity Two { get { throw null; } }
        public Azure.Provisioning.Monitor.AlertSeverity Zero { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutoscaleNotification : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutoscaleNotification() { }
        public Azure.Provisioning.Monitor.EmailNotification Email { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorOperationType> Operation { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.WebhookNotification> Webhooks { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutoscaleProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutoscaleProfile() { }
        public Azure.Provisioning.Monitor.MonitorScaleCapacity Capacity { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.MonitorTimeWindow FixedDate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.MonitorRecurrence Recurrence { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.AutoscaleRule> Rules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutoscaleRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutoscaleRule() { }
        public Azure.Provisioning.Monitor.MetricTrigger MetricTrigger { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.MonitorScaleAction ScaleAction { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutoscaleRuleMetricDimension : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutoscaleRuleMetricDimension() { }
        public Azure.Provisioning.BicepValue<string> DimensionName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.ScaleRuleMetricDimensionOperationType> Operator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutoscaleSetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutoscaleSetting(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AutoscaleSettingName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.AutoscaleNotification> Notifications { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.PredictiveAutoscalePolicy PredictiveAutoscalePolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.AutoscaleProfile> Profiles { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> TargetResourceLocation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.AutoscaleSetting FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_10_01;
        }
    }
    public partial class ConditionFailingPeriods : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConditionFailingPeriods() { }
        public Azure.Provisioning.BicepValue<long> MinFailingPeriodsToAlert { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> NumberOfEvaluationPeriods { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionEndpoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataCollectionEndpoint(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ConfigurationAccessEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Monitor.DataCollectionEndpointFailoverConfiguration FailoverConfiguration { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ImmutableId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.DataCollectionEndpointResourceKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LogsIngestionEndpoint { get { throw null; } }
        public Azure.Provisioning.Monitor.DataCollectionEndpointMetadata Metadata { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MetricsIngestionEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataCollectionRulePrivateLinkScopedResourceInfo> PrivateLinkScopedResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.DataCollectionEndpointProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.DataCollectionEndpoint FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_06_01;
        }
    }
    public partial class DataCollectionEndpointFailoverConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionEndpointFailoverConfiguration() { }
        public Azure.Provisioning.BicepValue<string> ActiveLocation { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataCollectionRuleBcdrLocationSpec> Locations { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionEndpointMetadata : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionEndpointMetadata() { }
        public Azure.Provisioning.BicepValue<string> ProvisionedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisionedByResourceId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataCollectionEndpointProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
    }
    public enum DataCollectionEndpointResourceKind
    {
        Linux = 0,
        Windows = 1,
    }
    public partial class DataCollectionRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataCollectionRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DataCollectionEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataFlow> DataFlows { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.DataCollectionRuleDataSources DataSources { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.DataCollectionRuleDestinations Destinations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ImmutableId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.DataCollectionRuleResourceKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.DataCollectionRuleMetadata Metadata { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MetadataProvisionedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.DataCollectionRuleProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Monitor.DataStreamDeclaration> StreamDeclarations { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.DataCollectionRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_06_01;
        }
    }
    public partial class DataCollectionRuleAssociation : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataCollectionRuleAssociation(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DataCollectionEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DataCollectionRuleId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Monitor.DataCollectionRuleAssociationMetadata Metadata { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MetadataProvisionedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.DataCollectionRuleAssociationProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.DataCollectionRuleAssociation FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_06_01;
        }
    }
    public partial class DataCollectionRuleAssociationMetadata : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRuleAssociationMetadata() { }
        public Azure.Provisioning.BicepValue<string> ProvisionedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisionedByResourceId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataCollectionRuleAssociationProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
    }
    public partial class DataCollectionRuleBcdrLocationSpec : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRuleBcdrLocationSpec() { }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.DataCollectionRuleBcdrLocationSpecProvisioningStatus> ProvisioningStatus { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataCollectionRuleBcdrLocationSpecProvisioningStatus
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
    }
    public partial class DataCollectionRuleDataSources : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRuleDataSources() { }
        public Azure.Provisioning.Monitor.DataImportSourcesEventHub DataImportsEventHub { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.ExtensionDataSource> Extensions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.IisLogsDataSource> IisLogs { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.LogFilesDataSource> LogFiles { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.PerfCounterDataSource> PerformanceCounters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.PlatformTelemetryDataSource> PlatformTelemetry { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.PrometheusForwarderDataSource> PrometheusForwarder { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.SyslogDataSource> Syslog { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.WindowsEventLogDataSource> WindowsEventLogs { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.WindowsFirewallLogsDataSource> WindowsFirewallLogs { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionRuleDestinations : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRuleDestinations() { }
        public Azure.Provisioning.BicepValue<string> AzureMonitorMetricsName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataCollectionRuleEventHubDestination> EventHubs { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataCollectionRuleEventHubDirectDestination> EventHubsDirect { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.LogAnalyticsDestination> LogAnalytics { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitoringAccountDestination> MonitoringAccounts { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataCollectionRuleStorageBlobDestination> StorageAccounts { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataCollectionRuleStorageBlobDestination> StorageBlobsDirect { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataCollectionRuleStorageTableDestination> StorageTablesDirect { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionRuleEventHubDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRuleEventHubDestination() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> EventHubResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionRuleEventHubDirectDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRuleEventHubDirectDestination() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> EventHubResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataCollectionRuleKnownPrometheusForwarderDataSourceStream
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-PrometheusMetrics")]
        MicrosoftPrometheusMetrics = 0,
    }
    public partial class DataCollectionRuleMetadata : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRuleMetadata() { }
        public Azure.Provisioning.BicepValue<string> ProvisionedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisionedByResourceId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionRulePrivateLinkScopedResourceInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRulePrivateLinkScopedResourceInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ScopeId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataCollectionRuleProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Canceled = 4,
        Failed = 5,
    }
    public enum DataCollectionRuleResourceKind
    {
        Linux = 0,
        Windows = 1,
    }
    public partial class DataCollectionRuleStorageBlobDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRuleStorageBlobDestination() { }
        public Azure.Provisioning.BicepValue<string> ContainerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageAccountResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionRuleStorageTableDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRuleStorageTableDestination() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageAccountResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataColumnDefinition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataColumnDefinition() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.DataColumnDefinitionType> DefinitionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataColumnDefinitionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="string")]
        String = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="int")]
        Int = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="long")]
        Long = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="real")]
        Real = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="boolean")]
        Boolean = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="datetime")]
        Datetime = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="dynamic")]
        Dynamic = 6,
    }
    public partial class DataFlow : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFlow() { }
        public Azure.Provisioning.BicepValue<string> BuiltInTransform { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Destinations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OutputStream { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataFlowStream> Streams { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TransformKql { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataFlowStream
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-Event")]
        MicrosoftEvent = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-InsightsMetrics")]
        MicrosoftInsightsMetrics = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-Perf")]
        MicrosoftPerf = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-Syslog")]
        MicrosoftSyslog = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-WindowsEvent")]
        MicrosoftWindowsEvent = 4,
    }
    public partial class DataImportSourcesEventHub : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataImportSourcesEventHub() { }
        public Azure.Provisioning.BicepValue<string> ConsumerGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Stream { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataStreamDeclaration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataStreamDeclaration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataColumnDefinition> Columns { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
    public partial class DiagnosticSetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DiagnosticSetting(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> EventHubAuthorizationRuleId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EventHubName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LogAnalyticsDestinationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.LogSettings> Logs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> MarketplacePartnerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MetricSettings> Metrics { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ServiceBusRuleId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageAccountId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WorkspaceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.DiagnosticSetting FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class DynamicMetricCriteria : Azure.Provisioning.Monitor.MultiMetricCriteria
    {
        public DynamicMetricCriteria() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.DynamicThresholdSensitivity> AlertSensitivity { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.DynamicThresholdFailingPeriods FailingPeriods { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> IgnoreDataBefore { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.DynamicThresholdOperator> Operator { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DynamicThresholdFailingPeriods : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DynamicThresholdFailingPeriods() { }
        public Azure.Provisioning.BicepValue<float> MinFailingPeriodsToAlert { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> NumberOfEvaluationPeriods { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DynamicThresholdOperator
    {
        GreaterThan = 0,
        LessThan = 1,
        GreaterOrLessThan = 2,
    }
    public enum DynamicThresholdSensitivity
    {
        Low = 0,
        Medium = 1,
        High = 2,
    }
    public partial class EmailNotification : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EmailNotification() { }
        public Azure.Provisioning.BicepList<string> CustomEmails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SendToSubscriptionAdministrator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SendToSubscriptionCoAdministrators { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExtensionDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExtensionDataSource() { }
        public Azure.Provisioning.BicepValue<string> ExtensionName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ExtensionSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> InputDataSources { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.ExtensionDataSourceStream> Streams { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ExtensionDataSourceStream
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-Event")]
        MicrosoftEvent = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-InsightsMetrics")]
        MicrosoftInsightsMetrics = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-Perf")]
        MicrosoftPerf = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-Syslog")]
        MicrosoftSyslog = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-WindowsEvent")]
        MicrosoftWindowsEvent = 4,
    }
    public partial class IisLogsDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IisLogsDataSource() { }
        public Azure.Provisioning.BicepList<string> LogDirectories { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Streams { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LocationThresholdRuleCondition : Azure.Provisioning.Monitor.AlertRuleCondition
    {
        public LocationThresholdRuleCondition() { }
        public Azure.Provisioning.BicepValue<int> FailedLocationCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> WindowSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LogAnalyticsDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogAnalyticsDestination() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WorkspaceResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LogFilesDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogFilesDataSource() { }
        public Azure.Provisioning.BicepList<string> FilePatterns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.LogFilesDataSourceFormat> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Streams { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.LogFileTextSettingsRecordStartTimestampFormat> TextRecordStartTimestampFormat { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LogFilesDataSourceFormat
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="text")]
        Text = 0,
    }
    public enum LogFileTextSettingsRecordStartTimestampFormat
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="ISO 8601")]
        ISO8601 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="YYYY-MM-DD HH:MM:SS")]
        YyyyMmDdHhMmSs = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="M/D/YYYY HH:MM:SS AM/PM")]
        MDYyyyHhMmSsAMPM = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Mon DD, YYYY HH:MM:SS")]
        MonDdYyyyHhMmSs = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="yyMMdd HH:mm:ss")]
        YyMMddHhMmSs = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ddMMyy HH:mm:ss")]
        DdMMyyHhMmSs = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MMM d hh:mm:ss")]
        MmmDHhMmSs = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="dd/MMM/yyyy:HH:mm:ss zzz")]
        DdMmmYyyyHhMmSsZzz = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="yyyy-MM-ddTHH:mm:ssK")]
        YyyyMmDdTHHMmSsK = 8,
    }
    public partial class LogProfile : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public LogProfile(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> Categories { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Core.AzureLocation> Locations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ServiceBusRuleId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageAccountId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.LogProfile FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_03_01;
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
    public partial class LogSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogSettings() { }
        public Azure.Provisioning.BicepValue<string> Category { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CategoryGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagementEventAggregationCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagementEventAggregationCondition() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorConditionOperator> Operator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> Threshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> WindowSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagementEventRuleCondition : Azure.Provisioning.Monitor.AlertRuleCondition
    {
        public ManagementEventRuleCondition() { }
        public Azure.Provisioning.Monitor.ManagementEventAggregationCondition Aggregation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MetricAlert : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MetricAlert(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MetricAlertAction> Actions { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.MetricAlertCriteria Criteria { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> EvaluationFrequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAutoMitigateEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsMigrated { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Scopes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Severity { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> TargetResourceRegion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> TargetResourceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> WindowSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.MetricAlert FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_03_01;
        }
    }
    public partial class MetricAlertAction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MetricAlertAction() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ActionGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> WebHookProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MetricAlertCriteria : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MetricAlertCriteria() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MetricAlertMultipleResourceMultipleMetricCriteria : Azure.Provisioning.Monitor.MetricAlertCriteria
    {
        public MetricAlertMultipleResourceMultipleMetricCriteria() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MultiMetricCriteria> AllOf { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MetricAlertSingleResourceMultipleMetricCriteria : Azure.Provisioning.Monitor.MetricAlertCriteria
    {
        public MetricAlertSingleResourceMultipleMetricCriteria() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MetricCriteria> AllOf { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MetricCriteria : Azure.Provisioning.Monitor.MultiMetricCriteria
    {
        public MetricCriteria() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MetricCriteriaOperator> Operator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> Threshold { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MetricCriteriaOperator
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Equals")]
        EqualsValue = 0,
        GreaterThan = 1,
        GreaterThanOrEqual = 2,
        LessThan = 3,
        LessThanOrEqual = 4,
    }
    public enum MetricCriteriaTimeAggregationType
    {
        Average = 0,
        Count = 1,
        Minimum = 2,
        Maximum = 3,
        Total = 4,
    }
    public partial class MetricDimension : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MetricDimension() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Operator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
    public partial class MetricSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MetricSettings() { }
        public Azure.Provisioning.BicepValue<string> Category { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> TimeGrain { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MetricStatisticType
    {
        Average = 0,
        Min = 1,
        Max = 2,
        Sum = 3,
        Count = 4,
    }
    public partial class MetricTrigger : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MetricTrigger() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.AutoscaleRuleMetricDimension> Dimensions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDividedPerInstance { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricNamespace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> MetricResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> MetricResourceLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MetricTriggerComparisonOperation> Operator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MetricStatisticType> Statistic { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> Threshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MetricTriggerTimeAggregationType> TimeAggregation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> TimeGrain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> TimeWindow { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MetricTriggerComparisonOperation
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Equals")]
        EqualsValue = 0,
        NotEquals = 1,
        GreaterThan = 2,
        GreaterThanOrEqual = 3,
        LessThan = 4,
        LessThanOrEqual = 5,
    }
    public enum MetricTriggerTimeAggregationType
    {
        Average = 0,
        Minimum = 1,
        Maximum = 2,
        Total = 3,
        Count = 4,
        Last = 5,
    }
    public partial class MonitorArmRoleReceiver : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorArmRoleReceiver() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RoleId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseCommonAlertSchema { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorAutomationRunbookReceiver : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorAutomationRunbookReceiver() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AutomationAccountId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsGlobalRunbook { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RunbookName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ServiceUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseCommonAlertSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WebhookResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorAzureAppPushReceiver : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorAzureAppPushReceiver() { }
        public Azure.Provisioning.BicepValue<string> EmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorAzureFunctionReceiver : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorAzureFunctionReceiver() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FunctionAppResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FunctionName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> HttpTriggerUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseCommonAlertSchema { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MonitorConditionOperator
    {
        GreaterThan = 0,
        GreaterThanOrEqual = 1,
        LessThan = 2,
        LessThanOrEqual = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Equals")]
        EqualsValue = 4,
    }
    public enum MonitorDayOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }
    public partial class MonitorDimension : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorDimension() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorDimensionOperator> Operator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MonitorDimensionOperator
    {
        Include = 0,
        Exclude = 1,
    }
    public partial class MonitorEmailReceiver : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorEmailReceiver() { }
        public Azure.Provisioning.BicepValue<string> EmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorReceiverStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> UseCommonAlertSchema { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorEventHubReceiver : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorEventHubReceiver() { }
        public Azure.Provisioning.BicepValue<string> EventHubName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EventHubNameSpace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseCommonAlertSchema { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitoringAccountDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitoringAccountDestination() { }
        public Azure.Provisioning.BicepValue<string> AccountId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AccountResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorItsmReceiver : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorItsmReceiver() { }
        public Azure.Provisioning.BicepValue<string> ConnectionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Region { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TicketConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorLogicAppReceiver : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorLogicAppReceiver() { }
        public Azure.Provisioning.BicepValue<System.Uri> CallbackUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseCommonAlertSchema { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MonitorOperationType
    {
        Scale = 0,
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
    public partial class MonitorPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MonitorPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Monitor.MonitorPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.MonitorPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public enum MonitorPrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public enum MonitorPrivateEndpointServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
    public enum MonitorPrivateLinkAccessMode
    {
        Open = 0,
        PrivateOnly = 1,
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
    public partial class MonitorPrivateLinkAccessModeSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorPrivateLinkAccessModeSettings() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorPrivateLinkAccessModeSettingsExclusion> Exclusions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorPrivateLinkAccessMode> IngestionAccessMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorPrivateLinkAccessMode> QueryAccessMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
    public partial class MonitorPrivateLinkAccessModeSettingsExclusion : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorPrivateLinkAccessModeSettingsExclusion() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorPrivateLinkAccessMode> IngestionAccessMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateEndpointConnectionName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorPrivateLinkAccessMode> QueryAccessMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
    public partial class MonitorPrivateLinkScope : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MonitorPrivateLinkScope(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Monitor.MonitorPrivateLinkAccessModeSettings AccessModeSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.MonitorPrivateLinkScope FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
    public partial class MonitorPrivateLinkScoped : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MonitorPrivateLinkScoped(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> LinkedResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.MonitorPrivateLinkScoped FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class MonitorPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorPrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MonitorProvisioningState
    {
        Creating = 0,
        Succeeded = 1,
        Deleting = 2,
        Failed = 3,
        Canceled = 4,
    }
    public enum MonitorPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
        SecuredByPerimeter = 2,
    }
    public enum MonitorReceiverStatus
    {
        NotSpecified = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public partial class MonitorRecurrence : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorRecurrence() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.RecurrenceFrequency> Frequency { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.RecurrentSchedule Schedule { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorScaleAction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorScaleAction() { }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Cooldown { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorScaleDirection> Direction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorScaleType> ScaleType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorScaleCapacity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorScaleCapacity() { }
        public Azure.Provisioning.BicepValue<int> Default { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Maximum { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Minimum { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MonitorScaleDirection
    {
        None = 0,
        Increase = 1,
        Decrease = 2,
    }
    public enum MonitorScaleType
    {
        ChangeCount = 0,
        PercentChangeCount = 1,
        ExactCount = 2,
        ServiceAllowedNextValue = 3,
    }
    public partial class MonitorSmsReceiver : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorSmsReceiver() { }
        public Azure.Provisioning.BicepValue<string> CountryCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PhoneNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorReceiverStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorTimeWindow : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorTimeWindow() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeZone { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorVoiceReceiver : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorVoiceReceiver() { }
        public Azure.Provisioning.BicepValue<string> CountryCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PhoneNumber { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorWebhookReceiver : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorWebhookReceiver() { }
        public Azure.Provisioning.BicepValue<System.Uri> IdentifierUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ObjectId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ServiceUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseAadAuth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseCommonAlertSchema { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorWorkspace : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MonitorWorkspace(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AccountId { get { throw null; } }
        public Azure.Provisioning.Monitor.MonitorWorkspaceDefaultIngestionSettings DefaultIngestionSettings { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.MonitorWorkspaceMetrics Metrics { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorWorkspacePrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorWorkspacePublicNetworkAccess> PublicNetworkAccess { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.MonitorWorkspace FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_04_03;
        }
    }
    public partial class MonitorWorkspaceDefaultIngestionSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorWorkspaceDefaultIngestionSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DataCollectionEndpointResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DataCollectionRuleResourceId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorWorkspaceMetrics : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorWorkspaceMetrics() { }
        public Azure.Provisioning.BicepValue<string> InternalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrometheusQueryEndpoint { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorWorkspacePrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorWorkspacePrivateEndpointConnection() { }
        public Azure.Provisioning.Monitor.MonitorPrivateLinkServiceConnectionState ConnectionState { get { throw null; } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MonitorWorkspacePublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class MultiMetricCriteria : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MultiMetricCriteria() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MetricDimension> Dimensions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricNamespace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SkipMetricValidation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MetricCriteriaTimeAggregationType> TimeAggregation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PerfCounterDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PerfCounterDataSource() { }
        public Azure.Provisioning.BicepList<string> CounterSpecifiers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SamplingFrequencyInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.PerfCounterDataSourceStream> Streams { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PerfCounterDataSourceStream
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-Perf")]
        MicrosoftPerf = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-InsightsMetrics")]
        MicrosoftInsightsMetrics = 1,
    }
    public partial class PlatformTelemetryDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PlatformTelemetryDataSource() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Streams { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PredictiveAutoscalePolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PredictiveAutoscalePolicy() { }
        public Azure.Provisioning.BicepValue<System.TimeSpan> ScaleLookAheadTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.PredictiveAutoscalePolicyScaleMode> ScaleMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PredictiveAutoscalePolicyScaleMode
    {
        Disabled = 0,
        ForecastOnly = 1,
        Enabled = 2,
    }
    public partial class PrometheusForwarderDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrometheusForwarderDataSource() { }
        public Azure.Provisioning.BicepDictionary<string> LabelIncludeFilter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataCollectionRuleKnownPrometheusForwarderDataSourceStream> Streams { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RecurrenceFrequency
    {
        None = 0,
        Second = 1,
        Minute = 2,
        Hour = 3,
        Day = 4,
        Week = 5,
        Month = 6,
        Year = 7,
    }
    public partial class RecurrentSchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RecurrentSchedule() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorDayOfWeek> Days { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<int> Hours { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<int> Minutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeZone { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RetentionPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RetentionPolicy() { }
        public Azure.Provisioning.BicepValue<int> Days { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RuleDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RuleDataSource() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> LegacyResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricNamespace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceLocation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RuleEmailAction : Azure.Provisioning.Monitor.AlertRuleAction
    {
        public RuleEmailAction() { }
        public Azure.Provisioning.BicepList<string> CustomEmails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SendToServiceOwners { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RuleManagementEventDataSource : Azure.Provisioning.Monitor.RuleDataSource
    {
        public RuleManagementEventDataSource() { }
        public Azure.Provisioning.BicepValue<string> ClaimsEmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EventName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EventSource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Level { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OperationName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceProviderName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubStatus { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RuleMetricDataSource : Azure.Provisioning.Monitor.RuleDataSource
    {
        public RuleMetricDataSource() { }
        public Azure.Provisioning.BicepValue<string> MetricName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RuleWebhookAction : Azure.Provisioning.Monitor.AlertRuleAction
    {
        public RuleWebhookAction() { }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ServiceUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ScaleRuleMetricDimensionOperationType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Equals")]
        EqualsValue = 0,
        NotEquals = 1,
    }
    public partial class ScheduledQueryRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ScheduledQueryRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Monitor.ScheduledQueryRuleActions Actions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AutoMitigate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> CheckWorkspaceAlertsStorageConfigured { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CreatedWithApiVersion { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.ScheduledQueryRuleCondition> CriteriaAllOf { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> EvaluationFrequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsLegacyLogAnalyticsRule { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsWorkspaceAlertsStorageConfigured { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.ScheduledQueryRuleKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> MuteActionsDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> OverrideQueryTimeRange { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Scopes { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.AlertSeverity Severity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SkipQueryValidation { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> TargetResourceTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> WindowSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.ScheduledQueryRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_06_15;
        }
    }
    public partial class ScheduledQueryRuleActions : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScheduledQueryRuleActions() { }
        public Azure.Provisioning.BicepList<string> ActionGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> CustomProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ScheduledQueryRuleCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScheduledQueryRuleCondition() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorDimension> Dimensions { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.ConditionFailingPeriods FailingPeriods { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricMeasureColumn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorConditionOperator> Operator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceIdColumn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> Threshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.ScheduledQueryRuleTimeAggregationType> TimeAggregation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ScheduledQueryRuleKind
    {
        LogAlert = 0,
        LogToMetric = 1,
    }
    public enum ScheduledQueryRuleTimeAggregationType
    {
        Count = 0,
        Average = 1,
        Minimum = 2,
        Maximum = 3,
        Total = 4,
    }
    public partial class SyslogDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SyslogDataSource() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.SyslogDataSourceFacilityName> FacilityNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.SyslogDataSourceLogLevel> LogLevels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.SyslogDataSourceStream> Streams { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SyslogDataSourceFacilityName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="auth")]
        Auth = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="authpriv")]
        Authpriv = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="cron")]
        Cron = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="daemon")]
        Daemon = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="kern")]
        Kern = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="lpr")]
        Lpr = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="mail")]
        Mail = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="mark")]
        Mark = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="news")]
        News = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="syslog")]
        Syslog = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="user")]
        User = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="uucp")]
        Uucp = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="local0")]
        Local0 = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="local1")]
        Local1 = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="local2")]
        Local2 = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="local3")]
        Local3 = 15,
        [System.Runtime.Serialization.DataMemberAttribute(Name="local4")]
        Local4 = 16,
        [System.Runtime.Serialization.DataMemberAttribute(Name="local5")]
        Local5 = 17,
        [System.Runtime.Serialization.DataMemberAttribute(Name="local6")]
        Local6 = 18,
        [System.Runtime.Serialization.DataMemberAttribute(Name="local7")]
        Local7 = 19,
        [System.Runtime.Serialization.DataMemberAttribute(Name="*")]
        Asterisk = 20,
    }
    public enum SyslogDataSourceLogLevel
    {
        Debug = 0,
        Info = 1,
        Notice = 2,
        Warning = 3,
        Error = 4,
        Critical = 5,
        Alert = 6,
        Emergency = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="*")]
        Asterisk = 8,
    }
    public enum SyslogDataSourceStream
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-Syslog")]
        MicrosoftSyslog = 0,
    }
    public partial class ThresholdRuleCondition : Azure.Provisioning.Monitor.AlertRuleCondition
    {
        public ThresholdRuleCondition() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorConditionOperator> Operator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> Threshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.ThresholdRuleConditionTimeAggregationType> TimeAggregation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> WindowSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ThresholdRuleConditionTimeAggregationType
    {
        Average = 0,
        Minimum = 1,
        Maximum = 2,
        Total = 3,
        Last = 4,
    }
    public partial class WebhookNotification : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebhookNotification() { }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ServiceUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebtestLocationAvailabilityCriteria : Azure.Provisioning.Monitor.MetricAlertCriteria
    {
        public WebtestLocationAvailabilityCriteria() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ComponentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> FailedLocationCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WebTestId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WindowsEventLogDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WindowsEventLogDataSource() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.WindowsEventLogDataSourceStream> Streams { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> XPathQueries { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WindowsEventLogDataSourceStream
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-WindowsEvent")]
        MicrosoftWindowsEvent = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-Event")]
        MicrosoftEvent = 1,
    }
    public partial class WindowsFirewallLogsDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WindowsFirewallLogsDataSource() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Streams { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
