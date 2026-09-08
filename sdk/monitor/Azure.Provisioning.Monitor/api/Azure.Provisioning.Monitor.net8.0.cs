namespace Azure.Provisioning.Monitor
{
    public partial class ActionGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ActionGroup(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorArmRoleReceiver> ArmRoleReceivers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorAutomationRunbookReceiver> AutomationRunbookReceivers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorAzureAppPushReceiver> AzureAppPushReceivers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorAzureFunctionReceiver> AzureFunctionReceivers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorEmailReceiver> EmailReceivers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorEventHubReceiver> EventHubReceivers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupShortName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorIncidentReceiver> IncidentReceivers { get { throw null; } set { } }
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
        public static Azure.Provisioning.Monitor.ActionGroup FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2024_10_01_PREVIEW;
        }
    }
    public partial class ActivityLogAlert : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ActivityLogAlert(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
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
        public Azure.Provisioning.BicepValue<string> TenantScope { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.ActivityLogAlert FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2023_01_01_PREVIEW;
        }
    }
    public partial class ActivityLogAlertActionGroup : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ActivityLogAlertActionGroup() { }
        public Azure.Provisioning.BicepValue<string> ActionGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ActionProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> WebhookProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ActivityLogAlertAnyOfOrLeafCondition : Azure.Provisioning.Monitor.AlertRuleLeafCondition
    {
        public ActivityLogAlertAnyOfOrLeafCondition() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.AlertRuleLeafCondition> AnyOf { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AdxDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AdxDestination() { }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> IngestionUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
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
    public enum AlertSeverity
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="0")]
        Zero = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1")]
        One = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="2")]
        Two = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="3")]
        Three = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="4")]
        Four = 4,
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
        public AutoscaleSetting(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
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
        public static Azure.Provisioning.Monitor.AutoscaleSetting FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_10_01;
        }
    }
    public enum CategoryType
    {
        Metrics = 0,
        Logs = 1,
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
        public DataCollectionEndpoint(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
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
        public Azure.Provisioning.Monitor.DataCollectionEndpointResourceSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.DataCollectionEndpoint FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_11;
        }
    }
    public partial class DataCollectionEndpointFailoverConfiguration : Azure.Provisioning.Monitor.DataCollectionRuleBcdrFailoverConfigurationSpec
    {
        public DataCollectionEndpointFailoverConfiguration() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionEndpointMetadata : Azure.Provisioning.Monitor.DataCollectionRuleRelatedResourceMetadata
    {
        public DataCollectionEndpointMetadata() { }
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
    public partial class DataCollectionEndpointResourceSku : Azure.Provisioning.Monitor.MonitorSku
    {
        public DataCollectionEndpointResourceSku() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionEndpointsInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionEndpointsInfo() { }
        public Azure.Provisioning.BicepValue<string> LogsIngestion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MetricsIngestion { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionReferencesInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionReferencesInfo() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorApplicationInsightsReference> ApplicationInsights { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataCollectionRuleEnrichmentStorageBlob> EnrichmentDataStorageBlobs { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataCollectionRule(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorAgentSetting> AgentLogs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DataCollectionEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataFlow> DataFlows { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.DataCollectionRuleDataSources DataSources { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.DataCollectionRuleDestinations Destinations { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.DataCollectionRuleDirectDataSources DirectDataSources { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.DataCollectionRuleEndpoints Endpoints { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ImmutableId { get { throw null; } }
        public Azure.Provisioning.Monitor.IngestionQuotasLogs IngestionQuotasLogs { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.DataCollectionRuleResourceKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.DataCollectionRuleMetadata Metadata { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.DataCollectionRuleProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Monitor.DataCollectionRuleReferences References { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.DataCollectionRuleResourceSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Monitor.DataStreamDeclaration> StreamDeclarations { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.DataCollectionRule FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_11;
        }
    }
    public partial class DataCollectionRuleAssociation : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataCollectionRuleAssociation(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DataCollectionEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DataCollectionRuleId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Monitor.DataCollectionRuleAssociationMetadata Metadata { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.DataCollectionRuleAssociationProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.DataCollectionRuleAssociation FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_11;
        }
    }
    public partial class DataCollectionRuleAssociationMetadata : Azure.Provisioning.Monitor.DataCollectionRuleRelatedResourceMetadata
    {
        public DataCollectionRuleAssociationMetadata() { }
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
    public partial class DataCollectionRuleBcdrFailoverConfigurationSpec : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRuleBcdrFailoverConfigurationSpec() { }
        public Azure.Provisioning.BicepValue<string> ActiveLocation { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataCollectionRuleBcdrLocationSpec> Locations { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionRuleBcdrLocationSpec : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRuleBcdrLocationSpec() { }
        public Azure.Provisioning.BicepValue<string> Location { get { throw null; } }
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
    public partial class DataCollectionRuleDataSources : Azure.Provisioning.Monitor.DataSourcesSpec
    {
        public DataCollectionRuleDataSources() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionRuleDestinations : Azure.Provisioning.Monitor.DestinationsSpec
    {
        public DataCollectionRuleDestinations() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionRuleDirectDataSources : Azure.Provisioning.Monitor.DataCollectionRuleDirectDataSourcesBase
    {
        public DataCollectionRuleDirectDataSources() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionRuleDirectDataSourcesBase : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRuleDirectDataSourcesBase() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.OtelLogsDirectDataSource> OtelLogs { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.OtelMetricsDirectDataSource> OtelMetrics { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.OtelTracesDirectDataSource> OtelTraces { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionRuleEndpoints : Azure.Provisioning.Monitor.DataCollectionEndpointsInfo
    {
        public DataCollectionRuleEndpoints() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionRuleEnrichmentStorageBlob : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRuleEnrichmentStorageBlob() { }
        public Azure.Provisioning.BicepValue<string> BlobUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.KnownStorageBlobLookupType> LookupType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionRuleEventHubDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRuleEventHubDataSource() { }
        public Azure.Provisioning.BicepValue<string> ConsumerGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Stream { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionRuleEventHubDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRuleEventHubDestination() { }
        public Azure.Provisioning.BicepValue<string> EventHubResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionRuleEventHubDirectDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRuleEventHubDirectDestination() { }
        public Azure.Provisioning.BicepValue<string> EventHubResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataCollectionRuleKnownPrometheusForwarderDataSourceStream
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-PrometheusMetrics")]
        MicrosoftPrometheusMetrics = 0,
    }
    public partial class DataCollectionRuleMetadata : Azure.Provisioning.Monitor.DataCollectionRuleRelatedResourceMetadata
    {
        public DataCollectionRuleMetadata() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionRulePrivateLinkScopedResourceInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRulePrivateLinkScopedResourceInfo() { }
        public Azure.Provisioning.BicepValue<string> ResourceId { get { throw null; } }
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
    public partial class DataCollectionRuleReferences : Azure.Provisioning.Monitor.DataCollectionReferencesInfo
    {
        public DataCollectionRuleReferences() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionRuleRelatedResourceMetadata : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRuleRelatedResourceMetadata() { }
        public Azure.Provisioning.BicepValue<string> ProvisionedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisionedByImmutableId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ProvisionedByResourceId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataCollectionRuleResourceKind
    {
        Linux = 0,
        Windows = 1,
    }
    public partial class DataCollectionRuleResourceSku : Azure.Provisioning.Monitor.MonitorSku
    {
        public DataCollectionRuleResourceSku() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionRuleStorageBlobDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRuleStorageBlobDestination() { }
        public Azure.Provisioning.BicepValue<string> ContainerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionRuleStorageTableDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionRuleStorageTableDestination() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountResourceId { get { throw null; } set { } }
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
    public partial class DataContainer : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataContainer() { }
        public Azure.Provisioning.Monitor.WorkspaceInfo Workspace { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFlow : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFlow() { }
        public Azure.Provisioning.BicepValue<string> BuiltInTransform { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Destinations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OutputStream { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ShouldCaptureOverflow { get { throw null; } set { } }
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
    public partial class DataImportSourcesEventHub : Azure.Provisioning.Monitor.DataCollectionRuleEventHubDataSource
    {
        public DataImportSourcesEventHub() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataSourcesSpec : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataSourcesSpec() { }
        public Azure.Provisioning.Monitor.DataImportSourcesEventHub DataImportsEventHub { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.EtwProviderDataSource> EtwProviders { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.ExtensionDataSource> Extensions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.IisLogsDataSource> IisLogs { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.LogFilesDataSource> LogFiles { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.OtelLogsDataSource> OtelLogs { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.OtelMetricsDataSource> OtelMetrics { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.OtelTracesDataSource> OtelTraces { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.PerfCounterDataSource> PerformanceCounters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.PerformanceCountersOtelDataSource> PerformanceCountersOtel { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.PlatformTelemetryDataSource> PlatformTelemetry { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.PrometheusForwarderDataSource> PrometheusForwarder { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.SyslogDataSource> Syslog { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.WindowsEventLogDataSource> WindowsEventLogs { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.WindowsFirewallLogsDataSource> WindowsFirewallLogs { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataStatus
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="present")]
        Present = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="notPresent")]
        NotPresent = 1,
    }
    public partial class DataStreamDeclaration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataStreamDeclaration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataColumnDefinition> Columns { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DestinationsSpec : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DestinationsSpec() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.AdxDestination> AzureDataExplorer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureMonitorMetricsName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataCollectionRuleEventHubDestination> EventHubs { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataCollectionRuleEventHubDirectDestination> EventHubsDirect { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.LogAnalyticsDestination> LogAnalytics { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MicrosoftFabricDestination> MicrosoftFabric { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitoringAccountDestination> MonitoringAccounts { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataCollectionRuleStorageBlobDestination> StorageAccounts { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataCollectionRuleStorageBlobDestination> StorageBlobsDirect { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataCollectionRuleStorageTableDestination> StorageTablesDirect { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DiagnosticSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiagnosticSettings() { }
        public Azure.Provisioning.BicepValue<string> EventHubAuthorizationRuleId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EventHubName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LogAnalyticsDestinationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DiagnosticsLogSettings> Logs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MarketplacePartnerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DiagnosticsMetricSettings> Metrics { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceBusRuleId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DiagnosticSettingsCategory : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiagnosticSettingsCategory() { }
        public Azure.Provisioning.BicepList<string> CategoryGroups { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.CategoryType> CategoryType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DiagnosticSettingsCategoryResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal DiagnosticSettingsCategoryResource() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.DiagnosticSettingsCategory Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.DiagnosticSettingsCategoryResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_05_01_PREVIEW;
        }
    }
    public partial class DiagnosticSettingsResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DiagnosticSettingsResource(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.DiagnosticSettings Properties { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.DiagnosticSettingsResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_05_01_PREVIEW;
        }
    }
    public partial class DiagnosticsLogSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiagnosticsLogSettings() { }
        public Azure.Provisioning.BicepValue<string> Category { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CategoryGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DiagnosticsMetricSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiagnosticsMetricSettings() { }
        public Azure.Provisioning.BicepValue<string> Category { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> TimeGrain { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class DynamicPromQLCriteria : Azure.Provisioning.Monitor.MultiPromQLCriteria
    {
        public DynamicPromQLCriteria() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.DynamicThresholdSensitivity> AlertSensitivity { get { throw null; } set { } }
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
    public partial class EtwProviderDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EtwProviderDataSource() { }
        public Azure.Provisioning.BicepList<string> EventIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Keyword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.KnownEtwProviderDataSourceLogLevel> LogLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Provider { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.KnownEtwProviderType> ProviderType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Streams { get { throw null; } set { } }
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
        public Azure.Provisioning.BicepValue<string> TransformKql { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IngestionQuotasLogs : Azure.Provisioning.Monitor.LogsQuotaInfo
    {
        public IngestionQuotasLogs() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KnownEtwProviderDataSourceLogLevel
    {
        Critical = 0,
        Error = 1,
        Warning = 2,
        Informational = 3,
        Verbose = 4,
    }
    public enum KnownEtwProviderType
    {
        EventSource = 0,
        Manifest = 1,
    }
    public enum KnownMonitorAgentSettingName
    {
        MaxDiskQuotaInMB = 0,
        UseTimeReceivedForForwardedEvents = 1,
        Tags = 2,
    }
    public enum KnownOtelLogsDataSourceStreams
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-OTel-Logs")]
        MicrosoftOTelLogs = 0,
    }
    public enum KnownOtelLogsDirectDataSourceStreams
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-OTel-Logs")]
        MicrosoftOTelLogs = 0,
    }
    public enum KnownOtelTracesDataSourceStreams
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-OTel-Traces-Spans")]
        MicrosoftOTelTracesSpans = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-OTel-Traces-Events")]
        MicrosoftOTelTracesEvents = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-OTel-Traces-Resources")]
        MicrosoftOTelTracesResources = 2,
    }
    public enum KnownOtelTracesDirectDataSourceStreams
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-OTel-Traces-Spans")]
        MicrosoftOTelTracesSpans = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-OTel-Traces-Events")]
        MicrosoftOTelTracesEvents = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-OTel-Traces-Resources")]
        MicrosoftOTelTracesResources = 2,
    }
    public enum KnownPerformanceCountersOtelDataSourceStreams
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-OtelPerfMetrics")]
        MicrosoftOtelPerfMetrics = 0,
    }
    public enum KnownStorageBlobLookupType
    {
        String = 0,
        Cidr = 1,
    }
    public enum KnownWindowsFirewallLogsDataSourceProfileFilter
    {
        Domain = 0,
        Private = 1,
        Public = 2,
    }
    public partial class LogAnalyticsDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogAnalyticsDestination() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> WorkspaceResourceId { get { throw null; } set { } }
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
        public Azure.Provisioning.BicepValue<string> TransformKql { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LogFilesDataSourceFormat
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="json")]
        Json = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="text")]
        Text = 1,
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
        public LogProfile(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
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
        public static Azure.Provisioning.Monitor.LogProfile FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_03_01;
        }
    }
    public partial class LogSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogSettings() { }
        public Azure.Provisioning.BicepValue<string> Category { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CategoryGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LogsQuotaInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogsQuotaInfo() { }
        public Azure.Provisioning.BicepValue<string> MaxRequestsPerMinute { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MaxSizePerMinuteInGB { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MetricAlert : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MetricAlert(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepDictionary<string> ActionProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MetricAlertAction> Actions { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.MetricAlertCriteria Criteria { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> CustomProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> EvaluationFrequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAutoMitigateEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsMigrated { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.MetricAlertResolveConfiguration ResolveConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Scopes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Severity { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> TargetResourceRegion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> TargetResourceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> WindowSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.MetricAlert FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_01_01;
        }
    }
    public partial class MetricAlertAction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MetricAlertAction() { }
        public Azure.Provisioning.BicepValue<string> ActionGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> WebHookProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MetricAlertCriteria : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MetricAlertCriteria() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MetricAlertMultipleResourceMultipleMetricCriteria : Azure.Provisioning.Monitor.MetricAlertCriteria
    {
        public MetricAlertMultipleResourceMultipleMetricCriteria() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MultiMetricCriteria> AllOf { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MetricAlertResolveConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MetricAlertResolveConfiguration() { }
        public Azure.Provisioning.BicepValue<bool> IsAutoResolved { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> TimeToResolve { get { throw null; } set { } }
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
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MetricTriggerComparisonOperator> ComparisonOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.AutoscaleRuleMetricDimension> Dimensions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDividedPerInstance { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricNamespace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> MetricResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricResourceLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MetricStatisticType> Statistic { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> Threshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MetricTriggerTimeAggregationType> TimeAggregation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> TimeGrain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> TimeWindow { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MetricTriggerComparisonOperator
    {
        Equals = 0,
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
    public partial class MicrosoftFabricDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MicrosoftFabricDestination() { }
        public Azure.Provisioning.BicepValue<string> ArtifactId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IngestionUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorAgentSetting : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorAgentSetting() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.KnownMonitorAgentSettingName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorApplicationInsightsReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorApplicationInsightsReference() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
        public Azure.Provisioning.BicepValue<string> AutomationAccountId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsGlobalRunbook { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RunbookName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseCommonAlertSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WebhookResourceId { get { throw null; } set { } }
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
        public Azure.Provisioning.BicepValue<string> FunctionAppResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FunctionName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HttpTriggerUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedIdentity { get { throw null; } set { } }
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
        public Azure.Provisioning.BicepValue<string> ManagedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseCommonAlertSchema { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MonitorIncidentManagementService
    {
        Icm = 0,
    }
    public partial class MonitorIncidentReceiver : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorIncidentReceiver() { }
        public Azure.Provisioning.Monitor.MonitorIncidentServiceConnection Connection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorIncidentManagementService> IncidentManagementService { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Mappings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorIncidentServiceConnection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorIncidentServiceConnection() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitoringAccountDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitoringAccountDestination() { }
        public Azure.Provisioning.BicepValue<string> AccountId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> AccountResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorItsmReceiver : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorItsmReceiver() { }
        public Azure.Provisioning.BicepValue<string> ConnectionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Region { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TicketConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorLogicAppReceiver : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorLogicAppReceiver() { }
        public Azure.Provisioning.BicepValue<string> CallbackUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseCommonAlertSchema { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MonitorOperationType
    {
        Scale = 0,
    }
    public partial class MonitorPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MonitorPrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Monitor.MonitorPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.MonitorPrivateLinkScope Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.MonitorPrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2023_06_01_PREVIEW;
        }
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
    public enum MonitorPrivateLinkAccessMode
    {
        Open = 0,
        PrivateOnly = 1,
    }
    public partial class MonitorPrivateLinkAccessModeSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorPrivateLinkAccessModeSettings() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorPrivateLinkAccessModeSettingsExclusion> Exclusions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorPrivateLinkAccessMode> IngestionAccessMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorPrivateLinkAccessMode> QueryAccessMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorPrivateLinkAccessModeSettingsExclusion : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorPrivateLinkAccessModeSettingsExclusion() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorPrivateLinkAccessMode> IngestionAccessMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateEndpointConnectionName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorPrivateLinkAccessMode> QueryAccessMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorPrivateLinkResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal MonitorPrivateLinkResource() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.MonitorPrivateLinkScope Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> RequiredMembers { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RequiredZoneNames { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.MonitorPrivateLinkResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2023_06_01_PREVIEW;
        }
    }
    public partial class MonitorPrivateLinkScope : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MonitorPrivateLinkScope(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Monitor.MonitorPrivateLinkAccessModeSettings AccessModeSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorPrivateLinkScopeProvisioningState> PrivateLinkScopeProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.MonitorPrivateLinkScope FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2023_06_01_PREVIEW;
        }
    }
    public partial class MonitorPrivateLinkScopedResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MonitorPrivateLinkScopedResource(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorScopedResourceKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> LinkedResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.MonitorPrivateLinkScope Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorScopedResourceProvisioningState> ScopedResourceProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> SubscriptionLocation { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.MonitorPrivateLinkScopedResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2023_06_01_PREVIEW;
        }
    }
    public enum MonitorPrivateLinkScopeProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Deleting = 2,
        Canceled = 3,
    }
    public partial class MonitorPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorPrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
        public Azure.Provisioning.BicepValue<string> Default { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Maximum { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Minimum { get { throw null; } set { } }
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
    public enum MonitorScopedResourceKind
    {
        Resource = 0,
        Metrics = 1,
    }
    public enum MonitorScopedResourceProvisioningState
    {
        Succeeded = 0,
        Provisioning = 1,
        Failed = 2,
        Canceled = 3,
    }
    public partial class MonitorSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MonitorSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
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
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndsOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } set { } }
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
        public Azure.Provisioning.BicepValue<string> IdentifierUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ObjectId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseAadAuth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseCommonAlertSchema { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MultiMetricCriteria : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MultiMetricCriteria() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MetricDimension> Dimensions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricNamespace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SkipMetricValidation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MetricCriteriaTimeAggregationType> TimeAggregation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MultiPromQLCriteria : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MultiPromQLCriteria() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OnboardingStatus
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="onboarded")]
        Onboarded = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="notOnboarded")]
        NotOnboarded = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="unknown")]
        Unknown = 2,
    }
    public partial class OtelDataSourceResourceAttributeRouting : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OtelDataSourceResourceAttributeRouting() { }
        public Azure.Provisioning.BicepValue<string> AttributeName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AttributeValue { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OtelLogsDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OtelLogsDataSource() { }
        public Azure.Provisioning.BicepValue<string> EnrichWithReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EnrichWithResourceAttributes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.OtelLogsDataSourceResourceAttributeRouting ResourceAttributeRouting { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ShouldReplaceResourceIdWithReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.KnownOtelLogsDataSourceStreams> Streams { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OtelLogsDataSourceResourceAttributeRouting : Azure.Provisioning.Monitor.OtelDataSourceResourceAttributeRouting
    {
        public OtelLogsDataSourceResourceAttributeRouting() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OtelLogsDirectDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OtelLogsDirectDataSource() { }
        public Azure.Provisioning.BicepValue<string> EnrichWithReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EnrichWithResourceAttributes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ShouldReplaceResourceIdWithReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.KnownOtelLogsDirectDataSourceStreams> Streams { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OtelMetricsDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OtelMetricsDataSource() { }
        public Azure.Provisioning.BicepValue<string> EnrichWithReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EnrichWithResourceAttributes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.OtelMetricsDataSourceResourceAttributeRouting ResourceAttributeRouting { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Streams { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OtelMetricsDataSourceResourceAttributeRouting : Azure.Provisioning.Monitor.OtelDataSourceResourceAttributeRouting
    {
        public OtelMetricsDataSourceResourceAttributeRouting() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OtelMetricsDirectDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OtelMetricsDirectDataSource() { }
        public Azure.Provisioning.BicepValue<string> EnrichWithReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EnrichWithResourceAttributes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Streams { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OtelTracesDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OtelTracesDataSource() { }
        public Azure.Provisioning.BicepValue<string> EnrichWithReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EnrichWithResourceAttributes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.OtelTracesDataSourceResourceAttributeRouting ResourceAttributeRouting { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ShouldReplaceResourceIdWithReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.KnownOtelTracesDataSourceStreams> Streams { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OtelTracesDataSourceResourceAttributeRouting : Azure.Provisioning.Monitor.OtelDataSourceResourceAttributeRouting
    {
        public OtelTracesDataSourceResourceAttributeRouting() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OtelTracesDirectDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OtelTracesDirectDataSource() { }
        public Azure.Provisioning.BicepValue<string> EnrichWithReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EnrichWithResourceAttributes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ShouldReplaceResourceIdWithReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.KnownOtelTracesDirectDataSourceStreams> Streams { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PerfCounterDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PerfCounterDataSource() { }
        public Azure.Provisioning.BicepList<string> CounterSpecifiers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SamplingFrequencyInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.PerfCounterDataSourceStream> Streams { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TransformKql { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PerfCounterDataSourceStream
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-Perf")]
        MicrosoftPerf = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-InsightsMetrics")]
        MicrosoftInsightsMetrics = 1,
    }
    public partial class PerformanceCountersOtelDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PerformanceCountersOtelDataSource() { }
        public Azure.Provisioning.BicepList<string> CounterSpecifiers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SamplingFrequencyInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.KnownPerformanceCountersOtelDataSourceStreams> Streams { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
        public Azure.Provisioning.BicepList<System.BinaryData> CustomVMScrapeConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> LabelIncludeFilter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataCollectionRuleKnownPrometheusForwarderDataSourceStream> Streams { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PromQLCriteria : Azure.Provisioning.Monitor.MetricAlertCriteria
    {
        public PromQLCriteria() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MultiPromQLCriteria> AllOf { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> FailingPeriodsFor { get { throw null; } set { } }
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
    public partial class RuleResolveConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RuleResolveConfiguration() { }
        public Azure.Provisioning.BicepValue<bool> IsAutoResolved { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> TimeToResolve { get { throw null; } set { } }
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
        public ScheduledQueryRule(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
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
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsLegacyLogAnalyticsRule { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsWorkspaceAlertsStorageConfigured { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.ScheduledQueryRuleKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> MuteActionsDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> OverrideQueryTimeRange { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.RuleResolveConfiguration ResolveConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Scopes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.AlertSeverity> Severity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SkipQueryValidation { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> TargetResourceTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> WindowSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.ScheduledQueryRule FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_01_01_PREVIEW;
        }
    }
    public partial class ScheduledQueryRuleActions : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScheduledQueryRuleActions() { }
        public Azure.Provisioning.BicepList<string> ActionGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ActionProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> CustomProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ScheduledQueryRuleCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScheduledQueryRuleCondition() { }
        public Azure.Provisioning.BicepValue<string> AlertSensitivity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.ScheduledQueryRuleCriterionType> CriterionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorDimension> Dimensions { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.ConditionFailingPeriods FailingPeriods { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> IgnoreDataBefore { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricMeasureColumn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MinRecurrenceCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.MonitorConditionOperator> Operator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceIdColumn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> Threshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.ScheduledQueryRuleTimeAggregationType> TimeAggregation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ScheduledQueryRuleCriterionType
    {
        StaticThresholdCriterion = 0,
        DynamicThresholdCriterion = 1,
    }
    public enum ScheduledQueryRuleKind
    {
        LogAlert = 0,
        SimpleLogAlert = 1,
        LogToMetric = 2,
    }
    public enum ScheduledQueryRuleTimeAggregationType
    {
        Count = 0,
        Average = 1,
        Minimum = 2,
        Maximum = 3,
        Total = 4,
    }
    public partial class ServiceDiagnosticSetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceDiagnosticSetting(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> EventHubAuthorizationRuleId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.LogSettings> Logs { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MetricSettings> Metrics { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ServiceBusRuleId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageAccountId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WorkspaceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.ServiceDiagnosticSetting FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_09_01;
        }
    }
    public partial class StaticPromQLCriteria : Azure.Provisioning.Monitor.MultiPromQLCriteria
    {
        public StaticPromQLCriteria() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SyslogDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SyslogDataSource() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.SyslogDataSourceFacilityName> FacilityNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.SyslogDataSourceLogLevel> LogLevels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.SyslogDataSourceStream> Streams { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TransformKql { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SyslogDataSourceFacilityName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="*")]
        Asterisk = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="alert")]
        Alert = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="audit")]
        Audit = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="auth")]
        Auth = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="authpriv")]
        Authpriv = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="clock")]
        Clock = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="cron")]
        Cron = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="daemon")]
        Daemon = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ftp")]
        Ftp = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="kern")]
        Kern = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="local0")]
        Local0 = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="local1")]
        Local1 = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="local2")]
        Local2 = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="local3")]
        Local3 = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="local4")]
        Local4 = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="local5")]
        Local5 = 15,
        [System.Runtime.Serialization.DataMemberAttribute(Name="local6")]
        Local6 = 16,
        [System.Runtime.Serialization.DataMemberAttribute(Name="local7")]
        Local7 = 17,
        [System.Runtime.Serialization.DataMemberAttribute(Name="lpr")]
        Lpr = 18,
        [System.Runtime.Serialization.DataMemberAttribute(Name="mail")]
        Mail = 19,
        [System.Runtime.Serialization.DataMemberAttribute(Name="mark")]
        Mark = 20,
        [System.Runtime.Serialization.DataMemberAttribute(Name="news")]
        News = 21,
        [System.Runtime.Serialization.DataMemberAttribute(Name="nopri")]
        Nopri = 22,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ntp")]
        Ntp = 23,
        [System.Runtime.Serialization.DataMemberAttribute(Name="syslog")]
        Syslog = 24,
        [System.Runtime.Serialization.DataMemberAttribute(Name="user")]
        User = 25,
        [System.Runtime.Serialization.DataMemberAttribute(Name="uucp")]
        Uucp = 26,
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
    public partial class TenantActionGroupResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TenantActionGroupResource(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorAzureAppPushReceiver> AzureAppPushReceivers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorEmailReceiver> EmailReceivers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupShortName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorSmsReceiver> SmsReceivers { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.MonitorVoiceReceiver> VoiceReceivers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.WebhookReceiver> WebhookReceivers { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.TenantActionGroupResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2023_05_01_PREVIEW;
        }
    }
    public partial class VMInsightsOnboardingStatus : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal VMInsightsOnboardingStatus() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.DataContainer> Data { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.DataStatus> DataStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.OnboardingStatus> OnboardingStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResourceId { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.VMInsightsOnboardingStatus FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2018_11_27_PREVIEW;
        }
    }
    public partial class WebhookNotification : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebhookNotification() { }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebhookReceiver : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebhookReceiver() { }
        public Azure.Provisioning.BicepValue<string> IdentifierUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ObjectId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseAadAuth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseCommonAlertSchema { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebtestLocationAvailabilityCriteria : Azure.Provisioning.Monitor.MetricAlertCriteria
    {
        public WebtestLocationAvailabilityCriteria() { }
        public Azure.Provisioning.BicepValue<string> ComponentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> FailedLocationCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WebTestId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WindowsEventLogDataSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WindowsEventLogDataSource() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.WindowsEventLogDataSourceStream> Streams { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TransformKql { get { throw null; } set { } }
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
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.KnownWindowsFirewallLogsDataSourceProfileFilter> ProfileFilter { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Streams { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkspaceInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkspaceInfo() { }
        public Azure.Provisioning.BicepValue<string> CustomerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Location { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
}
