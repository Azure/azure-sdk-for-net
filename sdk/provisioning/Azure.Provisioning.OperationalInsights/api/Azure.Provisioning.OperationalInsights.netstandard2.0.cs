namespace Azure.Provisioning.OperationalInsights
{
    public partial class LogAnalyticsQuery : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public LogAnalyticsQuery(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Guid> ApplicationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Author { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Body { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.OperationalInsights.LogAnalyticsQueryPack? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Properties { get { throw null; } set { } }
        public Azure.Provisioning.OperationalInsights.LogAnalyticsQueryRelatedMetadata Related { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.BicepList<string>> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.OperationalInsights.LogAnalyticsQuery FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_09_01;
            public static readonly string V2023_09_01;
            public static readonly string V2025_02_01;
        }
    }
    public partial class LogAnalyticsQueryPack : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public LogAnalyticsQueryPack(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> QueryPackId { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.OperationalInsights.LogAnalyticsQueryPack FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_09_01;
            public static readonly string V2023_09_01;
            public static readonly string V2025_02_01;
        }
    }
    public partial class LogAnalyticsQueryRelatedMetadata : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogAnalyticsQueryRelatedMetadata() { }
        public Azure.Provisioning.BicepList<string> Categories { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ResourceTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Solutions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OperationalInsightsBillingType
    {
        Cluster = 0,
        Workspaces = 1,
    }
    public partial class OperationalInsightsCapacityReservationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OperationalInsightsCapacityReservationProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastSkuUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> MinCapacity { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OperationalInsightsCluster : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public OperationalInsightsCluster(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.OperationalInsights.OperationalInsightsClusterAssociatedWorkspace> AssociatedWorkspaces { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsBillingType> BillingType { get { throw null; } set { } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsCapacityReservationProperties CapacityReservationProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ClusterId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAvailabilityZonesEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDoubleEncryptionEnabled { get { throw null; } set { } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsClusterEntityStatus> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsClusterReplicationProperties Replication { get { throw null; } set { } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsClusterSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.OperationalInsights.OperationalInsightsCluster FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_08_01;
            public static readonly string V2020_10_01;
            public static readonly string V2021_06_01;
            public static readonly string V2022_10_01;
            public static readonly string V2023_09_01;
            public static readonly string V2025_02_01;
        }
    }
    public partial class OperationalInsightsClusterAssociatedWorkspace : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OperationalInsightsClusterAssociatedWorkspace() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> AssociatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> WorkspaceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> WorkspaceName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OperationalInsightsClusterCapacity
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="500")]
        FiveHundred = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1000")]
        TenHundred = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="2000")]
        TwoThousand = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="5000")]
        FiveThousand = 3,
    }
    public enum OperationalInsightsClusterEntityStatus
    {
        Creating = 0,
        Succeeded = 1,
        Failed = 2,
        Canceled = 3,
        Deleting = 4,
        ProvisioningAccount = 5,
        Updating = 6,
    }
    public partial class OperationalInsightsClusterReplicationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OperationalInsightsClusterReplicationProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAvailabilityZonesEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsReplicationEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsClusterReplicationState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OperationalInsightsClusterReplicationState
    {
        Succeeded = 0,
        EnableRequested = 1,
        Enabling = 2,
        DisableRequested = 3,
        Disabling = 4,
        RollbackRequested = 5,
        RollingBack = 6,
        Failed = 7,
        Canceled = 8,
    }
    public partial class OperationalInsightsClusterSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OperationalInsightsClusterSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsClusterCapacity> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsClusterSkuName> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OperationalInsightsClusterSkuName
    {
        CapacityReservation = 0,
    }
    public partial class OperationalInsightsColumn : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OperationalInsightsColumn() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsColumnType> ColumnType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsColumnDataTypeHint> DataTypeHint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDefaultDisplay { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsHidden { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OperationalInsightsColumnDataTypeHint
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="uri")]
        Uri = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="guid")]
        Guid = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="armPath")]
        ArmPath = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ip")]
        IP = 3,
    }
    public enum OperationalInsightsColumnType
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
        [System.Runtime.Serialization.DataMemberAttribute(Name="dateTime")]
        DateTime = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="guid")]
        Guid = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="dynamic")]
        Dynamic = 7,
    }
    public partial class OperationalInsightsDataExport : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public OperationalInsightsDataExport(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> DataExportId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsDataExportDestinationType> DestinationType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> EventHubName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<string> TableNames { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.OperationalInsights.OperationalInsightsDataExport FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_08_01;
            public static readonly string V2023_09_01;
            public static readonly string V2025_02_01;
        }
    }
    public enum OperationalInsightsDataExportDestinationType
    {
        StorageAccount = 0,
        EventHub = 1,
    }
    public enum OperationalInsightsDataIngestionStatus
    {
        RespectQuota = 0,
        ForceOn = 1,
        ForceOff = 2,
        OverQuota = 3,
        SubscriptionSuspended = 4,
        ApproachingQuota = 5,
    }
    public partial class OperationalInsightsDataSource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public OperationalInsightsDataSource(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsDataSourceKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.OperationalInsights.OperationalInsightsDataSource FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_08_01;
            public static readonly string V2023_09_01;
            public static readonly string V2025_02_01;
        }
    }
    public enum OperationalInsightsDataSourceKind
    {
        WindowsEvent = 0,
        WindowsPerformanceCounter = 1,
        IISLogs = 2,
        LinuxSyslog = 3,
        LinuxSyslogCollection = 4,
        LinuxPerformanceObject = 5,
        LinuxPerformanceCollection = 6,
        CustomLog = 7,
        CustomLogCollection = 8,
        AzureAuditLog = 9,
        AzureActivityLog = 10,
        GenericDataSource = 11,
        ChangeTrackingCustomPath = 12,
        ChangeTrackingPath = 13,
        ChangeTrackingServices = 14,
        ChangeTrackingDataTypeConfiguration = 15,
        ChangeTrackingDefaultRegistry = 16,
        ChangeTrackingRegistry = 17,
        ChangeTrackingLinuxPath = 18,
        LinuxChangeTrackingPath = 19,
        ChangeTrackingContentLocation = 20,
        WindowsTelemetry = 21,
        Office365 = 22,
        SecurityWindowsBaselineConfiguration = 23,
        SecurityCenterSecurityWindowsBaselineConfiguration = 24,
        SecurityEventCollectionConfiguration = 25,
        SecurityInsightsSecurityEventCollectionConfiguration = 26,
        ImportComputerGroup = 27,
        NetworkMonitoring = 28,
        Itsm = 29,
        DnsAnalytics = 30,
        ApplicationInsights = 31,
        SqlDataClassification = 32,
    }
    public enum OperationalInsightsDataSourceType
    {
        CustomLogs = 0,
        AzureWatson = 1,
        Query = 2,
        Ingestion = 3,
        Alerts = 4,
    }
    public partial class OperationalInsightsKeyVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OperationalInsightsKeyVaultProperties() { }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> KeyRsaSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyVaultUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OperationalInsightsLinkedService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public OperationalInsightsLinkedService(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsLinkedServiceEntityStatus> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WriteAccessResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.OperationalInsights.OperationalInsightsLinkedService FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_08_01;
            public static readonly string V2023_09_01;
            public static readonly string V2025_02_01;
        }
    }
    public enum OperationalInsightsLinkedServiceEntityStatus
    {
        Succeeded = 0,
        Deleting = 1,
        ProvisioningAccount = 2,
        Updating = 3,
    }
    public partial class OperationalInsightsLinkedStorageAccounts : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public OperationalInsightsLinkedStorageAccounts(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsDataSourceType> DataSourceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> StorageAccountIds { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.OperationalInsights.OperationalInsightsLinkedStorageAccounts FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_08_01;
            public static readonly string V2023_09_01;
            public static readonly string V2025_02_01;
        }
    }
    public partial class OperationalInsightsPrivateLinkScopedResourceInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OperationalInsightsPrivateLinkScopedResourceInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ScopeId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OperationalInsightsPublicNetworkAccessType
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class OperationalInsightsSavedSearch : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public OperationalInsightsSavedSearch(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Category { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FunctionAlias { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FunctionParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.OperationalInsights.OperationalInsightsTag> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.OperationalInsights.OperationalInsightsSavedSearch FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_03_20;
            public static readonly string V2020_08_01;
            public static readonly string V2020_10_01;
            public static readonly string V2021_06_01;
            public static readonly string V2022_10_01;
            public static readonly string V2023_09_01;
            public static readonly string V2025_02_01;
        }
    }
    public partial class OperationalInsightsSchema : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OperationalInsightsSchema() { }
        public Azure.Provisioning.BicepList<string> Categories { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.OperationalInsights.OperationalInsightsColumn> Columns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Labels { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Solutions { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsTableCreator> Source { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.OperationalInsights.OperationalInsightsColumn> StandardColumns { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsTableSubType> TableSubType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsTableType> TableType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OperationalInsightsStorageAccount : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OperationalInsightsStorageAccount() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OperationalInsightsTable : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public OperationalInsightsTable(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> ArchiveRetentionInDays { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsRetentionInDaysAsDefault { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsTotalRetentionInDaysAsDefault { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastPlanModifiedDate { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsTablePlan> Plan { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsTableProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsTableRestoredLogs RestoredLogs { get { throw null; } set { } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsTableResultStatistics ResultStatistics { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> RetentionInDays { get { throw null; } set { } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsSchema Schema { get { throw null; } set { } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsTableSearchResults SearchResults { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> TotalRetentionInDays { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.OperationalInsights.OperationalInsightsTable FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_08_01;
            public static readonly string V2022_10_01;
            public static readonly string V2023_09_01;
            public static readonly string V2025_02_01;
        }
    }
    public enum OperationalInsightsTableCreator
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="microsoft")]
        Microsoft = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="customer")]
        Customer = 1,
    }
    public enum OperationalInsightsTablePlan
    {
        Basic = 0,
        Analytics = 1,
    }
    public enum OperationalInsightsTableProvisioningState
    {
        Updating = 0,
        InProgress = 1,
        Succeeded = 2,
        Deleting = 3,
    }
    public partial class OperationalInsightsTableRestoredLogs : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OperationalInsightsTableRestoredLogs() { }
        public Azure.Provisioning.BicepValue<System.Guid> AzureAsyncOperationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndRestoreOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceTable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartRestoreOn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OperationalInsightsTableResultStatistics : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OperationalInsightsTableResultStatistics() { }
        public Azure.Provisioning.BicepValue<int> IngestedRecords { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Progress { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> ScannedGB { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OperationalInsightsTableSearchResults : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OperationalInsightsTableSearchResults() { }
        public Azure.Provisioning.BicepValue<System.Guid> AzureAsyncOperationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndSearchOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Limit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceTable { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartSearchOn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OperationalInsightsTableSubType
    {
        Any = 0,
        Classic = 1,
        DataCollectionRuleBased = 2,
    }
    public enum OperationalInsightsTableType
    {
        Microsoft = 0,
        CustomLog = 1,
        RestoredLogs = 2,
        SearchResults = 3,
    }
    public partial class OperationalInsightsTag : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OperationalInsightsTag() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OperationalInsightsWorkspace : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public OperationalInsightsWorkspace(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> CustomerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DefaultDataCollectionRuleResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspaceFailoverProperties Failover { get { throw null; } set { } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspaceFeatures Features { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ForceCmkForQuery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.OperationalInsights.OperationalInsightsPrivateLinkScopedResourceInfo> PrivateLinkScopedResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspaceEntityStatus> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsPublicNetworkAccessType> PublicNetworkAccessForIngestion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsPublicNetworkAccessType> PublicNetworkAccessForQuery { get { throw null; } set { } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspaceReplicationProperties Replication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionInDays { get { throw null; } set { } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspaceSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspaceCapping WorkspaceCapping { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspace FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspaceSharedKeys GetKeys() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_03_20;
            public static readonly string V2020_08_01;
            public static readonly string V2020_10_01;
            public static readonly string V2021_06_01;
            public static readonly string V2022_10_01;
            public static readonly string V2023_09_01;
            public static readonly string V2025_02_01;
        }
    }
    public enum OperationalInsightsWorkspaceCapacityReservationLevel
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="100")]
        OneHundred = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="200")]
        TwoHundred = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="300")]
        ThreeHundred = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="400")]
        FourHundred = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="500")]
        FiveHundred = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1000")]
        TenHundred = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="2000")]
        TwoThousand = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="5000")]
        FiveThousand = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="10000")]
        TenThousand = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="25000")]
        TwentyFiveThousand = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="50000")]
        FiftyThousand = 10,
    }
    public partial class OperationalInsightsWorkspaceCapping : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OperationalInsightsWorkspaceCapping() { }
        public Azure.Provisioning.BicepValue<double> DailyQuotaInGB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsDataIngestionStatus> DataIngestionStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> QuotaNextResetTime { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OperationalInsightsWorkspaceEntityStatus
    {
        Creating = 0,
        Succeeded = 1,
        Failed = 2,
        Canceled = 3,
        Deleting = 4,
        ProvisioningAccount = 5,
        Updating = 6,
    }
    public partial class OperationalInsightsWorkspaceFailoverProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OperationalInsightsWorkspaceFailoverProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspaceFailoverState> State { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OperationalInsightsWorkspaceFailoverState
    {
        Inactive = 0,
        Activating = 1,
        Active = 2,
        Deactivating = 3,
        Failed = 4,
    }
    public partial class OperationalInsightsWorkspaceFeatures : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OperationalInsightsWorkspaceFeatures() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ClusterResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ImmediatePurgeDataOn30Days { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDataExportEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsLogAccessUsingOnlyResourcePermissionsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsUnifiedSentinelBillingOnly { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OperationalInsightsWorkspaceReplicationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OperationalInsightsWorkspaceReplicationProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsReplicationEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspaceReplicationState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OperationalInsightsWorkspaceReplicationState
    {
        Succeeded = 0,
        EnableRequested = 1,
        Enabling = 2,
        DisableRequested = 3,
        Disabling = 4,
        RollbackRequested = 5,
        RollingBack = 6,
        Failed = 7,
        Canceled = 8,
    }
    public partial class OperationalInsightsWorkspaceSharedKeys : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OperationalInsightsWorkspaceSharedKeys() { }
        public Azure.Provisioning.BicepValue<string> PrimarySharedKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondarySharedKey { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OperationalInsightsWorkspaceSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OperationalInsightsWorkspaceSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspaceCapacityReservationLevel> CapacityReservationLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastSkuUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspaceSkuName> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OperationalInsightsWorkspaceSkuName
    {
        Free = 0,
        Standard = 1,
        Premium = 2,
        PerNode = 3,
        PerGB2018 = 4,
        Standalone = 5,
        CapacityReservation = 6,
        LACluster = 7,
    }
    public enum RetentionInDaysAsDefaultState
    {
        True = 0,
        False = 1,
    }
    public partial class StorageInsight : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StorageInsight(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> Containers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.OperationalInsights.StorageInsightStatus Status { get { throw null; } }
        public Azure.Provisioning.OperationalInsights.OperationalInsightsStorageAccount StorageAccount { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Tables { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.OperationalInsights.StorageInsight FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_03_20;
            public static readonly string V2020_08_01;
            public static readonly string V2023_09_01;
            public static readonly string V2025_02_01;
        }
    }
    public enum StorageInsightState
    {
        OK = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ERROR")]
        Error = 1,
    }
    public partial class StorageInsightStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageInsightStatus() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.OperationalInsights.StorageInsightState> State { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum TotalRetentionInDaysAsDefaultState
    {
        True = 0,
        False = 1,
    }
}
