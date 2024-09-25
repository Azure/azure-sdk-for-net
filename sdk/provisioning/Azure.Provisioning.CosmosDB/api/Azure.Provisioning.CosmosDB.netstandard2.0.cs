namespace Azure.Provisioning.CosmosDB
{
    public enum AnalyticalStorageSchemaType
    {
        WellDefined = 0,
        FullFidelity = 1,
    }
    public partial class AuthenticationMethodLdapProperties : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public AuthenticationMethodLdapProperties() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<int> ConnectionTimeoutInMs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SearchBaseDistinguishedName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SearchFilterTemplate { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CassandraCertificate> ServerCertificates { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServerHostname { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ServerPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceUserDistinguishedName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceUserPassword { get { throw null; } set { } }
    }
    public partial class AutoscaleSettingsResourceInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public AutoscaleSettingsResourceInfo() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ThroughputPolicyResourceInfo> AutoUpgradeThroughputPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxThroughput { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TargetMaxThroughput { get { throw null; } }
    }
    public partial class AzureBlobDataTransferDataSourceSink : Azure.Provisioning.CosmosDB.DataTransferDataSourceSink
    {
        public AzureBlobDataTransferDataSourceSink() { }
        public Azure.Provisioning.BicepValue<string> ContainerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> EndpointUri { get { throw null; } set { } }
    }
    public partial class BackupPolicyMigrationState : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public BackupPolicyMigrationState() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.BackupPolicyMigrationStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.BackupPolicyType> TargetType { get { throw null; } set { } }
    }
    public enum BackupPolicyMigrationStatus
    {
        Invalid = 0,
        InProgress = 1,
        Completed = 2,
        Failed = 3,
    }
    public enum BackupPolicyType
    {
        Periodic = 0,
        Continuous = 1,
    }
    public partial class BaseCosmosDataTransferDataSourceSink : Azure.Provisioning.CosmosDB.DataTransferDataSourceSink
    {
        public BaseCosmosDataTransferDataSourceSink() { }
        public Azure.Provisioning.BicepValue<string> RemoteAccountName { get { throw null; } set { } }
    }
    public enum CassandraAuthenticationMethod
    {
        None = 0,
        Cassandra = 1,
        Ldap = 2,
    }
    public enum CassandraAutoReplicateForm
    {
        None = 0,
        SystemKeyspaces = 1,
        AllKeyspaces = 2,
    }
    public partial class CassandraCertificate : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CassandraCertificate() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> Pem { get { throw null; } set { } }
    }
    public partial class CassandraCluster : Azure.Provisioning.Primitives.Resource
    {
        public CassandraCluster(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CassandraClusterProperties> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.CassandraCluster FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_10_15;
            public static readonly string V2022_05_15;
            public static readonly string V2022_08_15;
            public static readonly string V2022_11_15;
            public static readonly string V2023_03_15;
            public static readonly string V2023_04_15;
            public static readonly string V2023_09_15;
            public static readonly string V2023_11_15;
            public static readonly string V2024_05_15;
            public static readonly string V2024_08_15;
            public static readonly string V2024_09_01_preview;
        }
    }
    public partial class CassandraClusterBackupSchedule : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CassandraClusterBackupSchedule() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> CronExpression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionInHours { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScheduleName { get { throw null; } set { } }
    }
    public partial class CassandraClusterKey : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CassandraClusterKey() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OrderBy { get { throw null; } set { } }
    }
    public partial class CassandraClusterProperties : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CassandraClusterProperties() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CassandraAuthenticationMethod> AuthenticationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CassandraAutoReplicateForm> AutoReplicate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ServiceConnectionType> AzureConnectionMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CassandraClusterBackupSchedule> BackupSchedules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CassandraVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CassandraCertificate> ClientCertificates { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClusterNameOverride { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CassandraClusterType> ClusterType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DelegatedManagementSubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Extensions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ExternalDataCenters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CassandraCertificate> ExternalGossipCertificates { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CassandraDataCenterSeedNode> ExternalSeedNodes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CassandraCertificate> GossipCertificates { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> HoursBetweenBackups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InitialCassandraAdminPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsCassandraAuditLoggingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDeallocated { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRepairEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateLinkResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrometheusEndpointIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CassandraError> ProvisionError { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CassandraProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RestoreFromBackupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ScheduledEventStrategy> ScheduledEventStrategy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CassandraDataCenterSeedNode> SeedNodes { get { throw null; } }
    }
    public enum CassandraClusterType
    {
        Production = 0,
        NonProduction = 1,
    }
    public partial class CassandraColumn : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CassandraColumn() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> CassandraColumnType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
    }
    public partial class CassandraDataCenter : Azure.Provisioning.Primitives.Resource
    {
        public CassandraDataCenter(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.CassandraCluster? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CassandraDataCenterProperties> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.CosmosDB.CassandraDataCenter FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class CassandraDataCenterProperties : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CassandraDataCenterProperties() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.AuthenticationMethodLdapProperties> AuthenticationMethodLdapProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> BackupStorageCustomerKeyUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Base64EncodedCassandraYamlFragment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> DataCenterLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Deallocated { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DelegatedSubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DiskCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DiskSku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DoesSupportAvailabilityZone { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ManagedDiskCustomerKeyUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NodeCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateEndpointIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CassandraError> ProvisionError { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CassandraProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CassandraDataCenterSeedNode> SeedNodes { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Sku { get { throw null; } set { } }
    }
    public partial class CassandraDataCenterSeedNode : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CassandraDataCenterSeedNode() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> IPAddress { get { throw null; } set { } }
    }
    public partial class CassandraError : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CassandraError() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> AdditionalErrorInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Target { get { throw null; } set { } }
    }
    public partial class CassandraKeyspace : Azure.Provisioning.Primitives.Resource
    {
        public CassandraKeyspace(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBCreateUpdateConfig> Options { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.CosmosDBAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ExtendedCassandraKeyspaceResourceInfo> Resource { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResourceKeyspaceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.CassandraKeyspace FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class CassandraKeyspacePropertiesConfig : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CassandraKeyspacePropertiesConfig() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<int> AutoscaleMaxThroughput { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Throughput { get { throw null; } set { } }
    }
    public partial class CassandraKeyspaceThroughputSetting : Azure.Provisioning.Primitives.Resource
    {
        public CassandraKeyspaceThroughputSetting(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.CosmosDB.CassandraKeyspace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ThroughputSettingsResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.CassandraKeyspaceThroughputSetting FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class CassandraPartitionKey : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CassandraPartitionKey() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
    }
    public enum CassandraProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Failed = 4,
        Canceled = 5,
    }
    public partial class CassandraSchema : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CassandraSchema() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CassandraClusterKey> ClusterKeys { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CassandraColumn> Columns { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CassandraPartitionKey> PartitionKeys { get { throw null; } set { } }
    }
    public partial class CassandraTable : Azure.Provisioning.Primitives.Resource
    {
        public CassandraTable(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBCreateUpdateConfig> Options { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.CassandraKeyspace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CassandraTableResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.CassandraTable FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class CassandraTablePropertiesConfig : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CassandraTablePropertiesConfig() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<int> AutoscaleMaxThroughput { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Throughput { get { throw null; } set { } }
    }
    public partial class CassandraTableResourceInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CassandraTableResourceInfo() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<int> AnalyticalStorageTtl { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DefaultTtl { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CassandraSchema> Schema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
    }
    public partial class CassandraTableThroughputSetting : Azure.Provisioning.Primitives.Resource
    {
        public CassandraTableThroughputSetting(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.CosmosDB.CassandraTable? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ThroughputSettingsResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.CassandraTableThroughputSetting FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class CassandraViewGetPropertiesOptions : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CassandraViewGetPropertiesOptions() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<int> AutoscaleMaxThroughput { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Throughput { get { throw null; } set { } }
    }
    public partial class CassandraViewGetPropertiesResource : Azure.Provisioning.CosmosDB.CassandraViewResource
    {
        public CassandraViewGetPropertiesResource() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Rid { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Timestamp { get { throw null; } }
    }
    public partial class CassandraViewGetResult : Azure.Provisioning.Primitives.Resource
    {
        public CassandraViewGetResult(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBCreateUpdateConfig> Options { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.CassandraKeyspace? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CassandraViewResource> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.CassandraViewGetResult FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class CassandraViewResource : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CassandraViewResource() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ViewDefinition { get { throw null; } set { } }
    }
    public partial class CassandraViewThroughputSetting : Azure.Provisioning.Primitives.Resource
    {
        public CassandraViewThroughputSetting(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.CosmosDB.CassandraViewGetResult? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ThroughputSettingsResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.CassandraViewThroughputSetting FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public enum CompositePathSortOrder
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="ascending")]
        Ascending = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="descending")]
        Descending = 1,
    }
    public partial class ComputedProperty : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ComputedProperty() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
    }
    public enum ConflictResolutionMode
    {
        LastWriterWins = 0,
        Custom = 1,
    }
    public partial class ConflictResolutionPolicy : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ConflictResolutionPolicy() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> ConflictResolutionPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConflictResolutionProcedure { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ConflictResolutionMode> Mode { get { throw null; } set { } }
    }
    public enum ConnectorOffer
    {
        Small = 0,
    }
    public partial class ConsistencyPolicy : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ConsistencyPolicy() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.DefaultConsistencyLevel> DefaultConsistencyLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxIntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MaxStalenessPrefix { get { throw null; } set { } }
    }
    public partial class ContinuousModeBackupPolicy : Azure.Provisioning.CosmosDB.CosmosDBAccountBackupPolicy
    {
        public ContinuousModeBackupPolicy() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ContinuousTier> ContinuousModeTier { get { throw null; } set { } }
    }
    public enum ContinuousTier
    {
        Continuous7Days = 0,
        Continuous30Days = 1,
    }
    public partial class CosmosCassandraDataTransferDataSourceSink : Azure.Provisioning.CosmosDB.BaseCosmosDataTransferDataSourceSink
    {
        public CosmosCassandraDataTransferDataSourceSink() { }
        public Azure.Provisioning.BicepValue<string> KeyspaceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
    }
    public partial class CosmosDBAccount : Azure.Provisioning.Primitives.Resource
    {
        public CosmosDBAccount(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.AnalyticalStorageSchemaType> AnalyticalStorageSchemaType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBServerVersion> ApiServerVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBAccountBackupPolicy> BackupPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CosmosDBAccountCapability> Capabilities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CapacityTotalThroughputLimit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ConnectorOffer> ConnectorOffer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ConsistencyPolicy> ConsistencyPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CosmosDBAccountCorsPolicy> Cors { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBAccountCreateMode> CreateMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomerManagedKeyStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBAccountOfferType> DatabaseAccountOfferType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DefaultIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.DefaultPriorityLevel> DefaultPriorityLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.EnableFullTextQuery> DiagnosticLogEnableFullTextQuery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableKeyBasedMetadataWriteAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableLocalAuth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DocumentEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> EnableAutomaticFailover { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableBurstCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableCassandraConnector { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableMaterializedViews { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableMultipleWriteLocations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePartitionMerge { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePerRegionPerPartitionAutoscale { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePriorityBasedExecution { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CosmosDBFailoverPolicy> FailoverPolicies { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> InstanceId { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CosmosDBIPAddressOrRange> IPRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAnalyticalStorageEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsFreeTierEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVirtualNetworkFilterEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.DatabaseAccountKeysMetadata> KeysMetadata { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyVaultKeyUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBAccountKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CosmosDBAccountLocation> Locations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBMinimalTlsVersion> MinimalTlsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.NetworkAclBypass> NetworkAclBypass { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> NetworkAclBypassResourceIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CosmosDBPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CosmosDBAccountLocation> ReadLocations { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBAccountRestoreParameters> RestoreParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CosmosDBVirtualNetworkRule> VirtualNetworkRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CosmosDBAccountLocation> WriteLocations { get { throw null; } }
        public Azure.Provisioning.Authorization.RoleAssignment AssignRole(Azure.Provisioning.CosmosDB.CosmosDBBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment AssignRole(Azure.Provisioning.CosmosDB.CosmosDBBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        public static Azure.Provisioning.CosmosDB.CosmosDBAccount FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public Azure.Provisioning.CosmosDB.CosmosDBAccountKeyList GetKeys() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2015_04_08;
            public static readonly string V2015_11_06;
            public static readonly string V2016_03_19;
            public static readonly string V2016_03_31;
            public static readonly string V2019_08_01;
            public static readonly string V2019_12_12;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_09_01;
            public static readonly string V2021_01_15;
            public static readonly string V2021_03_15;
            public static readonly string V2021_04_15;
            public static readonly string V2021_05_15;
            public static readonly string V2021_06_15;
            public static readonly string V2021_10_15;
            public static readonly string V2022_05_15;
            public static readonly string V2022_08_15;
            public static readonly string V2022_11_15;
            public static readonly string V2023_03_15;
            public static readonly string V2023_04_15;
            public static readonly string V2023_09_15;
            public static readonly string V2023_11_15;
            public static readonly string V2024_05_15;
            public static readonly string V2024_08_15;
            public static readonly string V2024_09_01_preview;
        }
    }
    public partial class CosmosDBAccountBackupPolicy : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBAccountBackupPolicy() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.BackupPolicyMigrationState> MigrationState { get { throw null; } set { } }
    }
    public partial class CosmosDBAccountCapability : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBAccountCapability() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
    }
    public partial class CosmosDBAccountCorsPolicy : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBAccountCorsPolicy() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> AllowedHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AllowedMethods { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AllowedOrigins { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExposedHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MaxAgeInSeconds { get { throw null; } set { } }
    }
    public enum CosmosDBAccountCreateMode
    {
        Default = 0,
        Restore = 1,
        PointInTimeRestore = 2,
    }
    public partial class CosmosDBAccountKeyList : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBAccountKeyList() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> PrimaryMasterKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrimaryReadonlyMasterKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondaryMasterKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecondaryReadonlyMasterKey { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Provisioning.CosmosDB.CosmosDBAccountKeyList FromExpression(Azure.Provisioning.Expressions.Expression expression) { throw null; }
    }
    public enum CosmosDBAccountKind
    {
        GlobalDocumentDB = 0,
        MongoDB = 1,
        Parse = 2,
    }
    public partial class CosmosDBAccountLocation : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBAccountLocation() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> DocumentEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> FailoverPriority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsZoneRedundant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> LocationName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
    }
    public enum CosmosDBAccountOfferType
    {
        Standard = 0,
    }
    public enum CosmosDBAccountRestoreMode
    {
        PointInTime = 0,
    }
    public partial class CosmosDBAccountRestoreParameters : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBAccountRestoreParameters() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.DatabaseRestoreResourceInfo> DatabasesToRestore { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.GremlinDatabaseRestoreResourceInfo> GremlinDatabasesToRestore { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRestoreWithTtlDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBAccountRestoreMode> RestoreMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RestoreSource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RestoreTimestampInUtc { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceBackupLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> TablesToRestore { get { throw null; } set { } }
    }
    public enum CosmosDBBackupStorageRedundancy
    {
        Geo = 0,
        Local = 1,
        Zone = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CosmosDBBuiltInRole : System.IEquatable<Azure.Provisioning.CosmosDB.CosmosDBBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CosmosDBBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.CosmosDB.CosmosDBBuiltInRole CosmosBackupOperator { get { throw null; } }
        public static Azure.Provisioning.CosmosDB.CosmosDBBuiltInRole CosmosDBAccountReaderRole { get { throw null; } }
        public static Azure.Provisioning.CosmosDB.CosmosDBBuiltInRole CosmosDBOperator { get { throw null; } }
        public static Azure.Provisioning.CosmosDB.CosmosDBBuiltInRole CosmosRestoreOperator { get { throw null; } }
        public static Azure.Provisioning.CosmosDB.CosmosDBBuiltInRole DocumentDBAccountContributor { get { throw null; } }
        public bool Equals(Azure.Provisioning.CosmosDB.CosmosDBBuiltInRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string GetBuiltInRoleName(Azure.Provisioning.CosmosDB.CosmosDBBuiltInRole value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.CosmosDB.CosmosDBBuiltInRole left, Azure.Provisioning.CosmosDB.CosmosDBBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.CosmosDB.CosmosDBBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.CosmosDB.CosmosDBBuiltInRole left, Azure.Provisioning.CosmosDB.CosmosDBBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CosmosDBClientEncryptionIncludedPath : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBClientEncryptionIncludedPath() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> ClientEncryptionKeyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptionAlgorithm { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
    }
    public partial class CosmosDBClientEncryptionPolicy : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBClientEncryptionPolicy() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CosmosDBClientEncryptionIncludedPath> IncludedPaths { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PolicyFormatVersion { get { throw null; } set { } }
    }
    public partial class CosmosDBCompositePath : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBCompositePath() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CompositePathSortOrder> Order { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
    }
    public partial class CosmosDBContainerPartitionKey : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBContainerPartitionKey() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<bool> IsSystemKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBPartitionKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Paths { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Version { get { throw null; } set { } }
    }
    public partial class CosmosDBCreateUpdateConfig : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBCreateUpdateConfig() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<int> AutoscaleMaxThroughput { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Throughput { get { throw null; } set { } }
    }
    public enum CosmosDBDataType
    {
        String = 0,
        Number = 1,
        Point = 2,
        Polygon = 3,
        LineString = 4,
        MultiPolygon = 5,
    }
    public partial class CosmosDBExcludedPath : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBExcludedPath() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
    }
    public partial class CosmosDBFailoverPolicy : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBFailoverPolicy() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<int> FailoverPriority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> LocationName { get { throw null; } set { } }
    }
    public partial class CosmosDBFirewallRule : Azure.Provisioning.Primitives.Resource
    {
        public CosmosDBFirewallRule(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> EndIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.MongoCluster? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> StartIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.CosmosDB.CosmosDBFirewallRule FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class CosmosDBIncludedPath : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBIncludedPath() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CosmosDBPathIndexes> Indexes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
    }
    public enum CosmosDBIndexingMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="consistent")]
        Consistent = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="lazy")]
        Lazy = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="none")]
        None = 2,
    }
    public partial class CosmosDBIndexingPolicy : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBIndexingPolicy() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CosmosDBCompositePath>> CompositeIndexes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CosmosDBExcludedPath> ExcludedPaths { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CosmosDBIncludedPath> IncludedPaths { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBIndexingMode> IndexingMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAutomatic { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.SpatialSpec> SpatialIndexes { get { throw null; } set { } }
    }
    public enum CosmosDBIndexKind
    {
        Hash = 0,
        Range = 1,
        Spatial = 2,
    }
    public partial class CosmosDBIPAddressOrRange : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBIPAddressOrRange() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> IPAddressOrRange { get { throw null; } set { } }
    }
    public partial class CosmosDBKeyWrapMetadata : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBKeyWrapMetadata() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> Algorithm { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CosmosDBKeyWrapMetadataType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
    }
    public enum CosmosDBMinimalTlsVersion
    {
        Tls = 0,
        Tls11 = 1,
        Tls12 = 2,
    }
    public enum CosmosDBPartitionKind
    {
        Hash = 0,
        Range = 1,
        MultiHash = 2,
    }
    public partial class CosmosDBPathIndexes : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBPathIndexes() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBDataType> DataType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBIndexKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Precision { get { throw null; } set { } }
    }
    public partial class CosmosDBPrivateEndpointConnection : Azure.Provisioning.Primitives.Resource
    {
        public CosmosDBPrivateEndpointConnection(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBPrivateLinkServiceConnectionStateProperty> ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.CosmosDBAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.CosmosDB.CosmosDBPrivateEndpointConnection FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class CosmosDBPrivateEndpointConnectionData : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBPrivateEndpointConnectionData() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBPrivateLinkServiceConnectionStateProperty> ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
    }
    public partial class CosmosDBPrivateLinkServiceConnectionStateProperty : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBPrivateLinkServiceConnectionStateProperty() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } set { } }
    }
    public enum CosmosDBProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        InProgress = 3,
        Updating = 4,
        Dropping = 5,
    }
    public enum CosmosDBPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
        SecuredByPerimeter = 2,
    }
    public enum CosmosDBServerVersion
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="3.2")]
        V3_2 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="3.6")]
        V3_6 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="4.0")]
        V4_0 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="4.2")]
        V4_2 = 3,
    }
    public partial class CosmosDBService : Azure.Provisioning.Primitives.Resource
    {
        public CosmosDBService(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> InstanceCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBServiceSize> InstanceSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.CosmosDBAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBServiceProperties> Properties { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBServiceType> ServiceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.CosmosDB.CosmosDBService FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class CosmosDBServiceProperties : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBServiceProperties() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> InstanceCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBServiceSize> InstanceSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBServiceStatus> Status { get { throw null; } }
    }
    public enum CosmosDBServiceSize
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Cosmos.D4s")]
        CosmosD4S = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Cosmos.D8s")]
        CosmosD8S = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Cosmos.D16s")]
        CosmosD16S = 2,
    }
    public enum CosmosDBServiceStatus
    {
        Creating = 0,
        Running = 1,
        Updating = 2,
        Deleting = 3,
        Error = 4,
        Stopped = 5,
    }
    public enum CosmosDBServiceType
    {
        SqlDedicatedGateway = 0,
        DataTransfer = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GraphAPICompute")]
        GraphApiCompute = 2,
        MaterializedViewsBuilder = 3,
    }
    public enum CosmosDBSpatialType
    {
        Point = 0,
        LineString = 1,
        Polygon = 2,
        MultiPolygon = 3,
    }
    public partial class CosmosDBSqlClientEncryptionKey : Azure.Provisioning.Primitives.Resource
    {
        public CosmosDBSqlClientEncryptionKey(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.CosmosDBSqlDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBSqlClientEncryptionKeyResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.CosmosDB.CosmosDBSqlClientEncryptionKey FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class CosmosDBSqlClientEncryptionKeyProperties : Azure.Provisioning.CosmosDB.CosmosDBSqlClientEncryptionKeyResourceInfo
    {
        public CosmosDBSqlClientEncryptionKeyProperties() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Rid { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Timestamp { get { throw null; } }
    }
    public partial class CosmosDBSqlClientEncryptionKeyResourceInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBSqlClientEncryptionKeyResourceInfo() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> EncryptionAlgorithm { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBKeyWrapMetadata> KeyWrapMetadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> WrappedDataEncryptionKey { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlContainer : Azure.Provisioning.Primitives.Resource
    {
        public CosmosDBSqlContainer(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBCreateUpdateConfig> Options { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.CosmosDBSqlDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBSqlContainerResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.CosmosDBSqlContainer FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class CosmosDBSqlContainerPropertiesConfig : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBSqlContainerPropertiesConfig() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<int> AutoscaleMaxThroughput { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Throughput { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlContainerResourceInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBSqlContainerResourceInfo() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<long> AnalyticalStorageTtl { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBClientEncryptionPolicy> ClientEncryptionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.ComputedProperty> ComputedProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ConflictResolutionPolicy> ConflictResolutionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContainerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBAccountCreateMode> CreateMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DefaultTtl { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBIndexingPolicy> IndexingPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.MaterializedViewDefinition> MaterializedViewDefinition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBContainerPartitionKey> PartitionKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ResourceRestoreParameters> RestoreParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CosmosDBUniqueKey> UniqueKeys { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlContainerThroughputSetting : Azure.Provisioning.Primitives.Resource
    {
        public CosmosDBSqlContainerThroughputSetting(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.CosmosDB.CosmosDBSqlContainer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ThroughputSettingsResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.CosmosDBSqlContainerThroughputSetting FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class CosmosDBSqlDatabase : Azure.Provisioning.Primitives.Resource
    {
        public CosmosDBSqlDatabase(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBCreateUpdateConfig> Options { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.CosmosDBAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBSqlDatabaseResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.CosmosDBSqlDatabase FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class CosmosDBSqlDatabasePropertiesConfig : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBSqlDatabasePropertiesConfig() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<int> AutoscaleMaxThroughput { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Throughput { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlDatabaseResourceInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBSqlDatabaseResourceInfo() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBAccountCreateMode> CreateMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ResourceRestoreParameters> RestoreParameters { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlDatabaseThroughputSetting : Azure.Provisioning.Primitives.Resource
    {
        public CosmosDBSqlDatabaseThroughputSetting(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.CosmosDB.CosmosDBSqlDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ThroughputSettingsResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.CosmosDBSqlDatabaseThroughputSetting FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class CosmosDBSqlRoleAssignment : Azure.Provisioning.Primitives.Resource
    {
        public CosmosDBSqlRoleAssignment(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.CosmosDB.CosmosDBAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RoleDefinitionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.CosmosDB.CosmosDBSqlRoleAssignment FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class CosmosDBSqlRoleDefinition : Azure.Provisioning.Primitives.Resource
    {
        public CosmosDBSqlRoleDefinition(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepList<string> AssignableScopes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.CosmosDB.CosmosDBAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CosmosDBSqlRolePermission> Permissions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBSqlRoleDefinitionType> RoleDefinitionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RoleName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.CosmosDB.CosmosDBSqlRoleDefinition FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public enum CosmosDBSqlRoleDefinitionType
    {
        BuiltInRole = 0,
        CustomRole = 1,
    }
    public partial class CosmosDBSqlRolePermission : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBSqlRolePermission() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepList<string> DataActions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NotDataActions { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlStoredProcedure : Azure.Provisioning.Primitives.Resource
    {
        public CosmosDBSqlStoredProcedure(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBCreateUpdateConfig> Options { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.CosmosDBSqlContainer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBSqlStoredProcedureResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.CosmosDBSqlStoredProcedure FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class CosmosDBSqlStoredProcedureResourceInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBSqlStoredProcedureResourceInfo() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> Body { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StoredProcedureName { get { throw null; } set { } }
    }
    public partial class CosmosDBSqlTrigger : Azure.Provisioning.Primitives.Resource
    {
        public CosmosDBSqlTrigger(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBCreateUpdateConfig> Options { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.CosmosDBSqlContainer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBSqlTriggerResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.CosmosDBSqlTrigger FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public enum CosmosDBSqlTriggerOperation
    {
        All = 0,
        Create = 1,
        Update = 2,
        Delete = 3,
        Replace = 4,
    }
    public partial class CosmosDBSqlTriggerResourceInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBSqlTriggerResourceInfo() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> Body { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TriggerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBSqlTriggerOperation> TriggerOperation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBSqlTriggerType> TriggerType { get { throw null; } set { } }
    }
    public enum CosmosDBSqlTriggerType
    {
        Pre = 0,
        Post = 1,
    }
    public partial class CosmosDBSqlUserDefinedFunction : Azure.Provisioning.Primitives.Resource
    {
        public CosmosDBSqlUserDefinedFunction(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBCreateUpdateConfig> Options { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.CosmosDBSqlContainer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBSqlUserDefinedFunctionResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.CosmosDBSqlUserDefinedFunction FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class CosmosDBSqlUserDefinedFunctionResourceInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBSqlUserDefinedFunctionResourceInfo() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> Body { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FunctionName { get { throw null; } set { } }
    }
    public enum CosmosDBStatus
    {
        Uninitialized = 0,
        Initializing = 1,
        InternallyReady = 2,
        Online = 3,
        Deleting = 4,
        Succeeded = 5,
        Failed = 6,
        Canceled = 7,
        Updating = 8,
    }
    public partial class CosmosDBTable : Azure.Provisioning.Primitives.Resource
    {
        public CosmosDBTable(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBCreateUpdateConfig> Options { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.CosmosDBAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBTableResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.CosmosDBTable FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class CosmosDBTablePropertiesOptions : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBTablePropertiesOptions() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<int> AutoscaleMaxThroughput { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Throughput { get { throw null; } set { } }
    }
    public partial class CosmosDBTablePropertiesResource : Azure.Provisioning.CosmosDB.CosmosDBTableResourceInfo
    {
        public CosmosDBTablePropertiesResource() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Rid { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Timestamp { get { throw null; } }
    }
    public partial class CosmosDBTableResourceInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBTableResourceInfo() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBAccountCreateMode> CreateMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ResourceRestoreParameters> RestoreParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
    }
    public partial class CosmosDBThroughputPool : Azure.Provisioning.Primitives.Resource
    {
        public CosmosDBThroughputPool(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxThroughput { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBStatus> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.CosmosDBThroughputPool FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_02_15_preview;
        }
    }
    public partial class CosmosDBThroughputPoolAccount : Azure.Provisioning.Primitives.Resource
    {
        public CosmosDBThroughputPoolAccount(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> AccountInstanceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> AccountLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AccountResourceIdentifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.CosmosDBThroughputPool? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBStatus> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.CosmosDB.CosmosDBThroughputPoolAccount FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_02_15_preview;
        }
    }
    public partial class CosmosDBUniqueKey : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBUniqueKey() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepList<string> Paths { get { throw null; } set { } }
    }
    public partial class CosmosDBVirtualNetworkRule : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public CosmosDBVirtualNetworkRule() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
    }
    public partial class CosmosMongoDataTransferDataSourceSink : Azure.Provisioning.CosmosDB.BaseCosmosDataTransferDataSourceSink
    {
        public CosmosMongoDataTransferDataSourceSink() { }
        public Azure.Provisioning.BicepValue<string> CollectionName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
    }
    public partial class CosmosSqlDataTransferDataSourceSink : Azure.Provisioning.CosmosDB.BaseCosmosDataTransferDataSourceSink
    {
        public CosmosSqlDataTransferDataSourceSink() { }
        public Azure.Provisioning.BicepValue<string> ContainerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
    }
    public partial class CosmosTableThroughputSetting : Azure.Provisioning.Primitives.Resource
    {
        public CosmosTableThroughputSetting(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.CosmosDB.CosmosDBTable? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ThroughputSettingsResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.CosmosTableThroughputSetting FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class DatabaseAccountKeysMetadata : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public DatabaseAccountKeysMetadata() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PrimaryMasterKeyGeneratedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PrimaryReadonlyMasterKeyGeneratedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> SecondaryMasterKeyGeneratedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> SecondaryReadonlyMasterKeyGeneratedOn { get { throw null; } }
    }
    public partial class DatabaseRestoreResourceInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public DatabaseRestoreResourceInfo() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepList<string> CollectionNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
    }
    public partial class DataTransferDataSourceSink : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public DataTransferDataSourceSink() : base (default(Azure.Provisioning.ProvisioningContext)) { }
    }
    public partial class DataTransferJobGetResult : Azure.Provisioning.Primitives.Resource
    {
        public DataTransferJobGetResult(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.DataTransferDataSourceSink> Destination { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ErrorResponse> Error { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> JobName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedUtcOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.DataTransferJobMode> Mode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.CosmosDBAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> ProcessedCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.DataTransferJobProperties> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.DataTransferDataSourceSink> Source { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> TotalCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> WorkerCount { get { throw null; } }
        public static Azure.Provisioning.CosmosDB.DataTransferJobGetResult FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public enum DataTransferJobMode
    {
        Offline = 0,
        Online = 1,
    }
    public partial class DataTransferJobProperties : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public DataTransferJobProperties() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.DataTransferDataSourceSink> Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ErrorResponse> Error { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> JobName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedUtcOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.DataTransferJobMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> ProcessedCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.DataTransferDataSourceSink> Source { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> TotalCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> WorkerCount { get { throw null; } set { } }
    }
    public partial class DataTransferRegionalService : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public DataTransferRegionalService() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBServiceStatus> Status { get { throw null; } }
    }
    public partial class DataTransferServiceProperties : Azure.Provisioning.CosmosDB.CosmosDBServiceProperties
    {
        public DataTransferServiceProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.DataTransferRegionalService> Locations { get { throw null; } }
    }
    public enum DefaultConsistencyLevel
    {
        Eventual = 0,
        Session = 1,
        BoundedStaleness = 2,
        Strong = 3,
        ConsistentPrefix = 4,
    }
    public enum DefaultPriorityLevel
    {
        High = 0,
        Low = 1,
    }
    public enum EnableFullTextQuery
    {
        None = 0,
        True = 1,
        False = 2,
    }
    public partial class ErrorResponse : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ErrorResponse() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
    }
    public partial class ExtendedCassandraKeyspaceResourceInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ExtendedCassandraKeyspaceResourceInfo() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> KeyspaceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Rid { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Timestamp { get { throw null; } }
    }
    public partial class ExtendedCassandraTableResourceInfo : Azure.Provisioning.CosmosDB.CassandraTableResourceInfo
    {
        public ExtendedCassandraTableResourceInfo() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Rid { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Timestamp { get { throw null; } }
    }
    public partial class ExtendedCosmosDBSqlContainerResourceInfo : Azure.Provisioning.CosmosDB.CosmosDBSqlContainerResourceInfo
    {
        public ExtendedCosmosDBSqlContainerResourceInfo() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Rid { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Timestamp { get { throw null; } }
    }
    public partial class ExtendedCosmosDBSqlDatabaseResourceInfo : Azure.Provisioning.CosmosDB.CosmosDBSqlDatabaseResourceInfo
    {
        public ExtendedCosmosDBSqlDatabaseResourceInfo() { }
        public Azure.Provisioning.BicepValue<string> Colls { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Rid { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Timestamp { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Users { get { throw null; } set { } }
    }
    public partial class ExtendedCosmosDBSqlStoredProcedureResourceInfo : Azure.Provisioning.CosmosDB.CosmosDBSqlStoredProcedureResourceInfo
    {
        public ExtendedCosmosDBSqlStoredProcedureResourceInfo() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Rid { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Timestamp { get { throw null; } }
    }
    public partial class ExtendedCosmosDBSqlTriggerResourceInfo : Azure.Provisioning.CosmosDB.CosmosDBSqlTriggerResourceInfo
    {
        public ExtendedCosmosDBSqlTriggerResourceInfo() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Rid { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Timestamp { get { throw null; } }
    }
    public partial class ExtendedCosmosDBSqlUserDefinedFunctionResourceInfo : Azure.Provisioning.CosmosDB.CosmosDBSqlUserDefinedFunctionResourceInfo
    {
        public ExtendedCosmosDBSqlUserDefinedFunctionResourceInfo() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Rid { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Timestamp { get { throw null; } }
    }
    public partial class ExtendedGremlinDatabaseResourceInfo : Azure.Provisioning.CosmosDB.GremlinDatabaseResourceInfo
    {
        public ExtendedGremlinDatabaseResourceInfo() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Rid { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Timestamp { get { throw null; } }
    }
    public partial class ExtendedGremlinGraphResourceInfo : Azure.Provisioning.CosmosDB.GremlinGraphResourceInfo
    {
        public ExtendedGremlinGraphResourceInfo() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Rid { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Timestamp { get { throw null; } }
    }
    public partial class ExtendedMongoDBCollectionResourceInfo : Azure.Provisioning.CosmosDB.MongoDBCollectionResourceInfo
    {
        public ExtendedMongoDBCollectionResourceInfo() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Rid { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Timestamp { get { throw null; } }
    }
    public partial class ExtendedMongoDBDatabaseResourceInfo : Azure.Provisioning.CosmosDB.MongoDBDatabaseResourceInfo
    {
        public ExtendedMongoDBDatabaseResourceInfo() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Rid { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Timestamp { get { throw null; } }
    }
    public partial class ExtendedThroughputSettingsResourceInfo : Azure.Provisioning.CosmosDB.ThroughputSettingsResourceInfo
    {
        public ExtendedThroughputSettingsResourceInfo() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Rid { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Timestamp { get { throw null; } }
    }
    public partial class GraphApiComputeRegionalService : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public GraphApiComputeRegionalService() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> GraphApiComputeEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBServiceStatus> Status { get { throw null; } }
    }
    public partial class GraphApiComputeServiceProperties : Azure.Provisioning.CosmosDB.CosmosDBServiceProperties
    {
        public GraphApiComputeServiceProperties() { }
        public Azure.Provisioning.BicepValue<string> GraphApiComputeEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.GraphApiComputeRegionalService> Locations { get { throw null; } }
    }
    public partial class GraphResourceGetPropertiesOptions : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public GraphResourceGetPropertiesOptions() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<int> AutoscaleMaxThroughput { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Throughput { get { throw null; } set { } }
    }
    public partial class GraphResourceGetResult : Azure.Provisioning.Primitives.Resource
    {
        public GraphResourceGetResult(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBCreateUpdateConfig> Options { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.CosmosDBAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.GraphResourceGetResult FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class GremlinDatabase : Azure.Provisioning.Primitives.Resource
    {
        public GremlinDatabase(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBCreateUpdateConfig> Options { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.CosmosDBAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.GremlinDatabaseResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.GremlinDatabase FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class GremlinDatabasePropertiesConfig : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public GremlinDatabasePropertiesConfig() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<int> AutoscaleMaxThroughput { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Throughput { get { throw null; } set { } }
    }
    public partial class GremlinDatabaseResourceInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public GremlinDatabaseResourceInfo() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBAccountCreateMode> CreateMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ResourceRestoreParameters> RestoreParameters { get { throw null; } set { } }
    }
    public partial class GremlinDatabaseRestoreResourceInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public GremlinDatabaseRestoreResourceInfo() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GraphNames { get { throw null; } set { } }
    }
    public partial class GremlinDatabaseThroughputSetting : Azure.Provisioning.Primitives.Resource
    {
        public GremlinDatabaseThroughputSetting(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.CosmosDB.GremlinDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ThroughputSettingsResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.GremlinDatabaseThroughputSetting FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class GremlinGraph : Azure.Provisioning.Primitives.Resource
    {
        public GremlinGraph(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBCreateUpdateConfig> Options { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.GremlinDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.GremlinGraphResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.GremlinGraph FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class GremlinGraphPropertiesConfig : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public GremlinGraphPropertiesConfig() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<int> AutoscaleMaxThroughput { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Throughput { get { throw null; } set { } }
    }
    public partial class GremlinGraphResourceInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public GremlinGraphResourceInfo() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<long> AnalyticalStorageTtl { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ConflictResolutionPolicy> ConflictResolutionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBAccountCreateMode> CreateMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DefaultTtl { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GraphName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBIndexingPolicy> IndexingPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBContainerPartitionKey> PartitionKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ResourceRestoreParameters> RestoreParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CosmosDBUniqueKey> UniqueKeys { get { throw null; } set { } }
    }
    public partial class GremlinGraphThroughputSetting : Azure.Provisioning.Primitives.Resource
    {
        public GremlinGraphThroughputSetting(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.CosmosDB.GremlinGraph? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ThroughputSettingsResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.GremlinGraphThroughputSetting FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class MaterializedViewDefinition : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public MaterializedViewDefinition() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> Definition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceCollectionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceCollectionRid { get { throw null; } }
    }
    public partial class MaterializedViewsBuilderRegionalService : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public MaterializedViewsBuilderRegionalService() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBServiceStatus> Status { get { throw null; } }
    }
    public partial class MaterializedViewsBuilderServiceProperties : Azure.Provisioning.CosmosDB.CosmosDBServiceProperties
    {
        public MaterializedViewsBuilderServiceProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.MaterializedViewsBuilderRegionalService> Locations { get { throw null; } }
    }
    public partial class MongoCluster : Azure.Provisioning.Primitives.Resource
    {
        public MongoCluster(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> AdministratorLogin { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.MongoClusterStatus> ClusterStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBAccountCreateMode> CreateMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EarliestRestoreTime { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.NodeGroupSpec> NodeGroupSpecs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.MongoClusterRestoreParameters> RestoreParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServerVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.MongoCluster FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_07_01;
        }
    }
    public partial class MongoClusterRestoreParameters : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public MongoClusterRestoreParameters() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PointInTimeUTC { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceResourceId { get { throw null; } set { } }
    }
    public enum MongoClusterStatus
    {
        Ready = 0,
        Provisioning = 1,
        Updating = 2,
        Starting = 3,
        Stopping = 4,
        Stopped = 5,
        Dropping = 6,
    }
    public partial class MongoDBCollection : Azure.Provisioning.Primitives.Resource
    {
        public MongoDBCollection(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBCreateUpdateConfig> Options { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.MongoDBDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.MongoDBCollectionResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.MongoDBCollection FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class MongoDBCollectionPropertiesConfig : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public MongoDBCollectionPropertiesConfig() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<int> AutoscaleMaxThroughput { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Throughput { get { throw null; } set { } }
    }
    public partial class MongoDBCollectionResourceInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public MongoDBCollectionResourceInfo() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<int> AnalyticalStorageTtl { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CollectionName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBAccountCreateMode> CreateMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.MongoDBIndex> Indexes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ResourceRestoreParameters> RestoreParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ShardKey { get { throw null; } set { } }
    }
    public partial class MongoDBCollectionThroughputSetting : Azure.Provisioning.Primitives.Resource
    {
        public MongoDBCollectionThroughputSetting(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.CosmosDB.MongoDBCollection? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ThroughputSettingsResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.MongoDBCollectionThroughputSetting FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class MongoDBDatabase : Azure.Provisioning.Primitives.Resource
    {
        public MongoDBDatabase(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBCreateUpdateConfig> Options { get { throw null; } set { } }
        public Azure.Provisioning.CosmosDB.CosmosDBAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.MongoDBDatabaseResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.MongoDBDatabase FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class MongoDBDatabasePropertiesConfig : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public MongoDBDatabasePropertiesConfig() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<int> AutoscaleMaxThroughput { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Throughput { get { throw null; } set { } }
    }
    public partial class MongoDBDatabaseResourceInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public MongoDBDatabaseResourceInfo() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBAccountCreateMode> CreateMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ResourceRestoreParameters> RestoreParameters { get { throw null; } set { } }
    }
    public partial class MongoDBDatabaseThroughputSetting : Azure.Provisioning.Primitives.Resource
    {
        public MongoDBDatabaseThroughputSetting(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentity> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.CosmosDB.MongoDBDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.ThroughputSettingsResourceInfo> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.MongoDBDatabaseThroughputSetting FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public partial class MongoDBIndex : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public MongoDBIndex() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepList<string> Keys { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.MongoDBIndexConfig> Options { get { throw null; } set { } }
    }
    public partial class MongoDBIndexConfig : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public MongoDBIndexConfig() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<int> ExpireAfterSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsUnique { get { throw null; } set { } }
    }
    public partial class MongoDBPrivilege : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public MongoDBPrivilege() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepList<string> Actions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.MongoDBPrivilegeResourceInfo> Resource { get { throw null; } set { } }
    }
    public partial class MongoDBPrivilegeResourceInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public MongoDBPrivilegeResourceInfo() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> Collection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DBName { get { throw null; } set { } }
    }
    public partial class MongoDBRole : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public MongoDBRole() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> DBName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Role { get { throw null; } set { } }
    }
    public partial class MongoDBRoleDefinition : Azure.Provisioning.Primitives.Resource
    {
        public MongoDBRoleDefinition(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.MongoDBRoleDefinitionType> DefinitionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.CosmosDB.CosmosDBAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.MongoDBPrivilege> Privileges { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RoleName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.MongoDBRole> Roles { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public static Azure.Provisioning.CosmosDB.MongoDBRoleDefinition FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public enum MongoDBRoleDefinitionType
    {
        BuiltInRole = 0,
        CustomRole = 1,
    }
    public partial class MongoDBUserDefinition : Azure.Provisioning.Primitives.Resource
    {
        public MongoDBUserDefinition(string resourceName, string? resourceVersion = null, Azure.Provisioning.ProvisioningContext? context = null) : base (default(string), default(Azure.Core.ResourceType), default(string), default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> CustomData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Mechanisms { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.CosmosDB.CosmosDBAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.MongoDBRole> Roles { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.SystemData> SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        public static Azure.Provisioning.CosmosDB.MongoDBUserDefinition FromExisting(string resourceName, string? resourceVersion = null) { throw null; }
    }
    public enum NetworkAclBypass
    {
        None = 0,
        AzureServices = 1,
    }
    public partial class NodeGroupSpec : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public NodeGroupSpec() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<long> DiskSizeInGB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableHa { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.NodeKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NodeCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sku { get { throw null; } set { } }
    }
    public enum NodeKind
    {
        Shard = 0,
    }
    public partial class PeriodicModeBackupPolicy : Azure.Provisioning.CosmosDB.CosmosDBAccountBackupPolicy
    {
        public PeriodicModeBackupPolicy() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.PeriodicModeProperties> PeriodicModeProperties { get { throw null; } set { } }
    }
    public partial class PeriodicModeProperties : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public PeriodicModeProperties() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<int> BackupIntervalInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> BackupRetentionIntervalInHours { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBBackupStorageRedundancy> BackupStorageRedundancy { get { throw null; } set { } }
    }
    public partial class ResourceRestoreParameters : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ResourceRestoreParameters() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<bool> IsRestoreWithTtlDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RestoreSource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RestoreTimestampInUtc { get { throw null; } set { } }
    }
    public partial class RestorableSqlContainerPropertiesResourceContainer : Azure.Provisioning.CosmosDB.CosmosDBSqlContainerResourceInfo
    {
        public RestorableSqlContainerPropertiesResourceContainer() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Rid { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Self { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Timestamp { get { throw null; } }
    }
    public partial class RestorableSqlDatabasePropertiesResourceDatabase : Azure.Provisioning.CosmosDB.CosmosDBSqlDatabaseResourceInfo
    {
        public RestorableSqlDatabasePropertiesResourceDatabase() { }
        public Azure.Provisioning.BicepValue<string> Colls { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Rid { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Self { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Timestamp { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Users { get { throw null; } }
    }
    public enum ScheduledEventStrategy
    {
        Ignore = 0,
        StopAny = 1,
        StopByRack = 2,
    }
    public enum ServiceConnectionType
    {
        None = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="VPN")]
        Vpn = 1,
    }
    public partial class SpatialSpec : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public SpatialSpec() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.CosmosDBSpatialType> Types { get { throw null; } set { } }
    }
    public partial class SqlDedicatedGatewayRegionalService : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public SqlDedicatedGatewayRegionalService() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SqlDedicatedGatewayEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.CosmosDBServiceStatus> Status { get { throw null; } }
    }
    public partial class SqlDedicatedGatewayServiceProperties : Azure.Provisioning.CosmosDB.CosmosDBServiceProperties
    {
        public SqlDedicatedGatewayServiceProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CosmosDB.SqlDedicatedGatewayRegionalService> Locations { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SqlDedicatedGatewayEndpoint { get { throw null; } set { } }
    }
    public partial class ThroughputPolicyResourceInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ThroughputPolicyResourceInfo() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<int> IncrementPercent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
    }
    public partial class ThroughputSettingsResourceInfo : Azure.Provisioning.Primitives.ProvisioningConstruct
    {
        public ThroughputSettingsResourceInfo() : base (default(Azure.Provisioning.ProvisioningContext)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CosmosDB.AutoscaleSettingsResourceInfo> AutoscaleSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InstantMaximumThroughput { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MinimumThroughput { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OfferReplacePending { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SoftAllowedMaximumThroughput { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Throughput { get { throw null; } set { } }
    }
}
