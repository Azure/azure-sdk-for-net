namespace Azure.Provisioning.PostgreSql
{
    public partial class DbLevelValidationStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DbLevelValidationStatus() { }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.PostgreSql.ValidationSummaryItem> Summary { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DbMigrationStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DbMigrationStatus() { }
        public Azure.Provisioning.BicepValue<int> AppliedChanges { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> CdcDeleteCounter { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> CdcInsertCounter { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> CdcUpdateCounter { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> FullLoadCompletedTables { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> FullLoadErroredTables { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> FullLoadLoadingTables { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> FullLoadQueuedTables { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> IncomingChanges { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Latency { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MigrationOperation { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.MigrationDbState> MigrationState { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.BicepValue<int> NumFullLoadCompletedTables { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.BicepValue<int> NumFullLoadErroredTables { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.BicepValue<int> NumFullLoadLoadingTables { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.BicepValue<int> NumFullLoadQueuedTables { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MigrateRolesEnum
    {
        True = 0,
        False = 1,
    }
    public enum MigrationDbState
    {
        InProgress = 0,
        WaitingForCutoverTrigger = 1,
        Failed = 2,
        Canceled = 3,
        Succeeded = 4,
        Canceling = 5,
    }
    public enum MigrationOption
    {
        Validate = 0,
        Migrate = 1,
        ValidateAndMigrate = 2,
    }
    public enum PostgreSqlAdministratorType
    {
        ActiveDirectory = 0,
    }
    public partial class PostgreSqlConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PostgreSqlConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AllowedValues { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DataType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DefaultValue { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Source { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PostgreSql.PostgreSqlConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_12_01;
        }
    }
    public partial class PostgreSqlDatabase : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PostgreSqlDatabase(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Charset { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Collation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PostgreSql.PostgreSqlDatabase FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_12_01;
        }
    }
    public partial class PostgreSqlFirewallRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PostgreSqlFirewallRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> EndIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> StartIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PostgreSql.PostgreSqlFirewallRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_12_01;
        }
    }
    public partial class PostgreSqlFlexibleServer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PostgreSqlFlexibleServer(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AdministratorLogin { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerAuthConfig AuthConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AvailabilityZone { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerBackupProperties Backup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerCreateMode> CreateMode { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerDataEncryption DataEncryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FullyQualifiedDomainName { get { throw null; } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerHighAvailability HighAvailability { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerUserAssignedIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerMaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MinorVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerNetwork Network { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PointInTimeUtc { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServersPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServersReplica Replica { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReplicaCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerReplicationRole> ReplicationRole { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceServerResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerState> State { get { throw null; } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerStorage Storage { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.BicepValue<int> StorageSizeInGB { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerVersion> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_06_01;
            public static readonly string V2022_12_01;
            public static readonly string V2024_08_01;
        }
    }
    public partial class PostgreSqlFlexibleServerActiveDirectoryAdministrator : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PostgreSqlFlexibleServerActiveDirectoryAdministrator(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ObjectId { get { throw null; } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrincipalName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerPrincipalType> PrincipalType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerActiveDirectoryAdministrator FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_06_01;
            public static readonly string V2022_12_01;
            public static readonly string V2024_08_01;
        }
    }
    public enum PostgreSqlFlexibleServerActiveDirectoryAuthEnum
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class PostgreSqlFlexibleServerAuthConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlFlexibleServerAuthConfig() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerActiveDirectoryAuthEnum> ActiveDirectoryAuth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerPasswordAuthEnum> PasswordAuth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlFlexibleServerBackup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PostgreSqlFlexibleServerBackup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerBackupOrigin> BackupType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CompletedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Source { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerBackup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_06_01;
            public static readonly string V2022_12_01;
            public static readonly string V2024_08_01;
        }
    }
    public enum PostgreSqlFlexibleServerBackupOrigin
    {
        Full = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Customer On-Demand")]
        CustomerOnDemand = 1,
    }
    public partial class PostgreSqlFlexibleServerBackupProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlFlexibleServerBackupProperties() { }
        public Azure.Provisioning.BicepValue<int> BackupRetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EarliestRestoreOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerGeoRedundantBackupEnum> GeoRedundantBackup { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlFlexibleServerConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PostgreSqlFlexibleServerConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AllowedValues { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerConfigurationDataType> DataType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DefaultValue { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DocumentationLink { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsConfigPendingRestart { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDynamicConfig { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsReadOnly { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Source { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Unit { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_06_01;
            public static readonly string V2022_12_01;
            public static readonly string V2024_08_01;
        }
    }
    public enum PostgreSqlFlexibleServerConfigurationDataType
    {
        Boolean = 0,
        Numeric = 1,
        Integer = 2,
        Enumeration = 3,
    }
    public enum PostgreSqlFlexibleServerCreateMode
    {
        Default = 0,
        Create = 1,
        Update = 2,
        PointInTimeRestore = 3,
        GeoRestore = 4,
        Replica = 5,
        ReviveDropped = 6,
    }
    public partial class PostgreSqlFlexibleServerDatabase : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PostgreSqlFlexibleServerDatabase(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Charset { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Collation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerDatabase FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_06_01;
            public static readonly string V2022_12_01;
            public static readonly string V2024_08_01;
        }
    }
    public partial class PostgreSqlFlexibleServerDataEncryption : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlFlexibleServerDataEncryption() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlKeyStatus> GeoBackupEncryptionKeyStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> GeoBackupKeyUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GeoBackupUserAssignedIdentityId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerKeyType> KeyType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlKeyStatus> PrimaryEncryptionKeyStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> PrimaryKeyUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrimaryUserAssignedIdentityId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlFlexibleServerFirewallRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PostgreSqlFlexibleServerFirewallRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> EndIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> StartIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerFirewallRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_06_01;
            public static readonly string V2022_12_01;
            public static readonly string V2024_08_01;
        }
    }
    public enum PostgreSqlFlexibleServerGeoRedundantBackupEnum
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum PostgreSqlFlexibleServerHAState
    {
        NotEnabled = 0,
        CreatingStandby = 1,
        ReplicatingData = 2,
        FailingOver = 3,
        Healthy = 4,
        RemovingStandby = 5,
    }
    public partial class PostgreSqlFlexibleServerHighAvailability : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlFlexibleServerHighAvailability() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerHighAvailabilityMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StandbyAvailabilityZone { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerHAState> State { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PostgreSqlFlexibleServerHighAvailabilityMode
    {
        Disabled = 0,
        ZoneRedundant = 1,
        SameZone = 2,
    }
    public enum PostgreSqlFlexibleServerIdentityType
    {
        SystemAssigned = 0,
        None = 1,
        UserAssigned = 2,
    }
    public enum PostgreSqlFlexibleServerKeyType
    {
        SystemAssigned = 0,
        SystemManaged = 1,
        AzureKeyVault = 2,
    }
    public partial class PostgreSqlFlexibleServerMaintenanceWindow : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlFlexibleServerMaintenanceWindow() { }
        public Azure.Provisioning.BicepValue<string> CustomWindow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DayOfWeek { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> StartHour { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> StartMinute { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlFlexibleServerNetwork : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlFlexibleServerNetwork() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DelegatedSubnetResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateDnsZoneArmResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerPublicNetworkAccessState> PublicNetworkAccess { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PostgreSqlFlexibleServerPasswordAuthEnum
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum PostgreSqlFlexibleServerPrincipalType
    {
        Unknown = 0,
        User = 1,
        Group = 2,
        ServicePrincipal = 3,
    }
    public enum PostgreSqlFlexibleServerPublicNetworkAccessState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum PostgreSqlFlexibleServerReplicationRole
    {
        Secondary = 0,
        WalReplica = 1,
        SyncReplica = 2,
        GeoSyncReplica = 3,
        None = 4,
        Primary = 5,
        AsyncReplica = 6,
        GeoAsyncReplica = 7,
    }
    public partial class PostgreSqlFlexibleServerSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlFlexibleServerSku() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PostgreSqlFlexibleServerSkuTier
    {
        Burstable = 0,
        GeneralPurpose = 1,
        MemoryOptimized = 2,
    }
    public partial class PostgreSqlFlexibleServersPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PostgreSqlFlexibleServersPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServersPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServersPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_06_01;
            public static readonly string V2022_12_01;
            public static readonly string V2024_08_01;
        }
    }
    public partial class PostgreSqlFlexibleServersPrivateEndpointConnectionData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlFlexibleServersPrivateEndpointConnectionData() { }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServersPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public enum PostgreSqlFlexibleServersPrivateEndpointServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
    }
    public partial class PostgreSqlFlexibleServersPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlFlexibleServersPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServersPrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlFlexibleServersReplica : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlFlexibleServersReplica() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.ReadReplicaPromoteMode> PromoteMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.ReplicationPromoteOption> PromoteOption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServersReplicationState> ReplicationState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerReplicationRole> Role { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PostgreSqlFlexibleServersReplicationState
    {
        Active = 0,
        Catchup = 1,
        Provisioning = 2,
        Updating = 3,
        Broken = 4,
        Reconfiguring = 5,
    }
    public partial class PostgreSqlFlexibleServersServerSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlFlexibleServersServerSku() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerSkuTier> Tier { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PostgreSqlFlexibleServersSourceType
    {
        OnPremises = 0,
        AWS = 1,
        GCP = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AzureVM")]
        AzureVm = 3,
        PostgreSQLSingleServer = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AWS_RDS")]
        AWSRDS = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AWS_AURORA")]
        AWSAurora = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AWS_EC2")]
        AWSEC2 = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GCP_CloudSQL")]
        GCPCloudSQL = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GCP_AlloyDB")]
        GCPAlloyDB = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GCP_Compute")]
        GCPCompute = 10,
        EDB = 11,
    }
    public enum PostgreSqlFlexibleServersSslMode
    {
        Prefer = 0,
        Require = 1,
        VerifyCA = 2,
        VerifyFull = 3,
    }
    public enum PostgreSqlFlexibleServersStorageType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Premium_LRS")]
        PremiumLRS = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PremiumV2_LRS")]
        PremiumV2LRS = 1,
    }
    public enum PostgreSqlFlexibleServerState
    {
        Ready = 0,
        Dropping = 1,
        Disabled = 2,
        Starting = 3,
        Stopping = 4,
        Stopped = 5,
        Updating = 6,
    }
    public partial class PostgreSqlFlexibleServerStorage : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlFlexibleServerStorage() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.StorageAutoGrow> AutoGrow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Iops { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> StorageSizeInGB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServersStorageType> StorageType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Throughput { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlManagedDiskPerformanceTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlFlexibleServersValidationDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlFlexibleServersValidationDetails() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.PostgreSql.DbLevelValidationStatus> DbLevelValidationDetails { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.PostgreSql.ValidationSummaryItem> ServerLevelValidationDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServersValidationState> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ValidationEndTimeInUtc { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ValidationStartTimeInUtc { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlFlexibleServersValidationMessage : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlFlexibleServersValidationMessage() { }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServersValidationState> State { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PostgreSqlFlexibleServersValidationState
    {
        Failed = 0,
        Succeeded = 1,
        Warning = 2,
    }
    public partial class PostgreSqlFlexibleServerUserAssignedIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlFlexibleServerUserAssignedIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.UserAssignedIdentityDetails> UserAssignedIdentities { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PostgreSqlFlexibleServerVersion
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="15")]
        Ver15 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="14")]
        Ver14 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="13")]
        Ver13 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="12")]
        Ver12 = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="11")]
        Ver11 = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="16")]
        Sixteen = 5,
    }
    public enum PostgreSqlGeoRedundantBackup
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum PostgreSqlInfrastructureEncryption
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum PostgreSqlKeyStatus
    {
        Valid = 0,
        Invalid = 1,
    }
    public enum PostgreSqlManagedDiskPerformanceTier
    {
        P1 = 0,
        P2 = 1,
        P3 = 2,
        P4 = 3,
        P6 = 4,
        P10 = 5,
        P15 = 6,
        P20 = 7,
        P30 = 8,
        P40 = 9,
        P50 = 10,
        P60 = 11,
        P70 = 12,
        P80 = 13,
    }
    public partial class PostgreSqlMigration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PostgreSqlMigration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlMigrationCancel> Cancel { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlMigrationStatus CurrentStatus { get { throw null; } }
        public Azure.Provisioning.BicepList<string> DbsToCancelMigrationOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DbsToMigrate { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DbsToTriggerCutoverOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.MigrateRolesEnum> MigrateRoles { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MigrationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> MigrationInstanceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlMigrationMode> MigrationMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.MigrationOption> MigrationOption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> MigrationWindowEndTimeInUtc { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> MigrationWindowStartTimeInUtc { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlMigrationOverwriteDbsInTarget> OverwriteDbsInTarget { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlMigrationSecretParameters SecretParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlMigrationLogicalReplicationOnSourceDb> SetupLogicalReplicationOnSourceDbIfNeeded { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceDbServerFullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlServerMetadata SourceDbServerMetadata { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceDbServerResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServersSourceType> SourceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServersSslMode> SslMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlMigrationStartDataMigration> StartDataMigration { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetDbServerFullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlServerMetadata TargetDbServerMetadata { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetDbServerResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlMigrationTriggerCutover> TriggerCutover { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PostgreSql.PostgreSqlMigration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_06_01;
            public static readonly string V2022_12_01;
            public static readonly string V2024_08_01;
        }
    }
    public partial class PostgreSqlMigrationAdminCredentials : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlMigrationAdminCredentials() { }
        public Azure.Provisioning.BicepValue<string> SourceServerPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetServerPassword { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PostgreSqlMigrationCancel
    {
        True = 0,
        False = 1,
    }
    public enum PostgreSqlMigrationLogicalReplicationOnSourceDb
    {
        True = 0,
        False = 1,
    }
    public enum PostgreSqlMigrationMode
    {
        Offline = 0,
        Online = 1,
    }
    public enum PostgreSqlMigrationOverwriteDbsInTarget
    {
        True = 0,
        False = 1,
    }
    public partial class PostgreSqlMigrationSecretParameters : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlMigrationSecretParameters() { }
        public Azure.Provisioning.PostgreSql.PostgreSqlMigrationAdminCredentials AdminCredentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceServerUsername { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetServerUsername { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PostgreSqlMigrationStartDataMigration
    {
        True = 0,
        False = 1,
    }
    public enum PostgreSqlMigrationState
    {
        InProgress = 0,
        WaitingForUserAction = 1,
        Canceled = 2,
        Failed = 3,
        Succeeded = 4,
        ValidationFailed = 5,
        CleaningUp = 6,
    }
    public partial class PostgreSqlMigrationStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlMigrationStatus() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlMigrationSubState> CurrentSubState { get { throw null; } }
        public Azure.Provisioning.PostgreSql.PostgreSqlMigrationSubStateDetails CurrentSubStateDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Error { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlMigrationState> State { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PostgreSqlMigrationSubState
    {
        PerformingPreRequisiteSteps = 0,
        WaitingForLogicalReplicationSetupRequestOnSourceDB = 1,
        WaitingForDBsToMigrateSpecification = 2,
        WaitingForTargetDBOverwriteConfirmation = 3,
        WaitingForDataMigrationScheduling = 4,
        WaitingForDataMigrationWindow = 5,
        MigratingData = 6,
        WaitingForCutoverTrigger = 7,
        CompletingMigration = 8,
        Completed = 9,
        CancelingRequestedDBMigrations = 10,
        ValidationInProgress = 11,
    }
    public partial class PostgreSqlMigrationSubStateDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlMigrationSubStateDetails() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlMigrationSubState> CurrentSubState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.PostgreSql.DbMigrationStatus> DbDetails { get { throw null; } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServersValidationDetails ValidationDetails { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PostgreSqlMigrationTriggerCutover
    {
        True = 0,
        False = 1,
    }
    public enum PostgreSqlMinimalTlsVersionEnum
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS1_0")]
        Tls1_0 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS1_1")]
        Tls1_1 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS1_2")]
        Tls1_2 = 2,
        TLSEnforcementDisabled = 3,
    }
    public partial class PostgreSqlPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PostgreSqlPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.PostgreSql.PostgreSqlPrivateLinkServiceConnectionStateProperty ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PostgreSql.PostgreSqlPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_06_01;
        }
    }
    public enum PostgreSqlPrivateEndpointProvisioningState
    {
        Approving = 0,
        Ready = 1,
        Dropping = 2,
        Failed = 3,
        Rejecting = 4,
    }
    public partial class PostgreSqlPrivateLinkServiceConnectionStateProperty : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlPrivateLinkServiceConnectionStateProperty() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PostgreSqlPrivateLinkServiceConnectionStateRequiredAction
    {
        None = 0,
    }
    public enum PostgreSqlPrivateLinkServiceConnectionStateStatus
    {
        Approved = 0,
        Pending = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public enum PostgreSqlPublicNetworkAccessEnum
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum PostgreSqlSecurityAlertPolicyName
    {
        Default = 0,
    }
    public partial class PostgreSqlServer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PostgreSqlServer(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AdministratorLogin { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ByokEnforcement { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EarliestRestoreOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FullyQualifiedDomainName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlInfrastructureEncryption> InfrastructureEncryption { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> MasterServerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlMinimalTlsVersionEnum> MinimalTlsVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.PostgreSql.PostgreSqlServerPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.PostgreSql.PostgreSqlServerPropertiesForCreate Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlPublicNetworkAccessEnum> PublicNetworkAccess { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ReplicaCapacity { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ReplicationRole { get { throw null; } }
        public Azure.Provisioning.PostgreSql.PostgreSqlSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlSslEnforcementEnum> SslEnforcement { get { throw null; } }
        public Azure.Provisioning.PostgreSql.PostgreSqlStorageProfile StorageProfile { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlServerState> UserVisibleState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlServerVersion> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PostgreSql.PostgreSqlServer FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_12_01;
        }
    }
    public partial class PostgreSqlServerAdministrator : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PostgreSqlServerAdministrator(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlAdministratorType> AdministratorType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LoginAccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.PostgreSql.PostgreSqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> SecureId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PostgreSql.PostgreSqlServerAdministrator FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_12_01;
        }
    }
    public partial class PostgreSqlServerKey : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PostgreSqlServerKey(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlServerKeyType> ServerKeyType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PostgreSql.PostgreSqlServerKey FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_01_01;
        }
    }
    public enum PostgreSqlServerKeyType
    {
        AzureKeyVault = 0,
    }
    public partial class PostgreSqlServerMetadata : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlServerMetadata() { }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServersServerSku ServerSku { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.PostgreSql.ServerSku? Sku { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> StorageMb { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlServerPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlServerPrivateEndpointConnection() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.PostgreSql.PostgreSqlServerPrivateEndpointConnectionProperties Properties { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlServerPrivateEndpointConnectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlServerPrivateEndpointConnectionProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.PostgreSql.PostgreSqlServerPrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlPrivateEndpointProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlServerPrivateLinkServiceConnectionStateProperty : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlServerPrivateLinkServiceConnectionStateProperty() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlPrivateLinkServiceConnectionStateRequiredAction> ActionsRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlPrivateLinkServiceConnectionStateStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlServerPropertiesForCreate : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlServerPropertiesForCreate() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlInfrastructureEncryption> InfrastructureEncryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlMinimalTlsVersionEnum> MinimalTlsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlPublicNetworkAccessEnum> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlSslEnforcementEnum> SslEnforcement { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlStorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlServerVersion> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlServerPropertiesForDefaultCreate : Azure.Provisioning.PostgreSql.PostgreSqlServerPropertiesForCreate
    {
        public PostgreSqlServerPropertiesForDefaultCreate() { }
        public Azure.Provisioning.BicepValue<string> AdministratorLogin { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> AdministratorLoginPassword { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlServerPropertiesForGeoRestore : Azure.Provisioning.PostgreSql.PostgreSqlServerPropertiesForCreate
    {
        public PostgreSqlServerPropertiesForGeoRestore() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceServerId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlServerPropertiesForReplica : Azure.Provisioning.PostgreSql.PostgreSqlServerPropertiesForCreate
    {
        public PostgreSqlServerPropertiesForReplica() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceServerId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlServerPropertiesForRestore : Azure.Provisioning.PostgreSql.PostgreSqlServerPropertiesForCreate
    {
        public PostgreSqlServerPropertiesForRestore() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RestorePointInTime { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceServerId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlServerSecurityAlertPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PostgreSqlServerSecurityAlertPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> DisabledAlerts { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EmailAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.PostgreSql.PostgreSqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SendToEmailAccountAdmins { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlServerSecurityAlertPolicyState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PostgreSql.PostgreSqlServerSecurityAlertPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_12_01;
        }
    }
    public enum PostgreSqlServerSecurityAlertPolicyState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum PostgreSqlServerState
    {
        Ready = 0,
        Dropping = 1,
        Disabled = 2,
        Inaccessible = 3,
    }
    public enum PostgreSqlServerVersion
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="9.5")]
        Ver9_5 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="9.6")]
        Ver9_6 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="10")]
        Ver10 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="10.0")]
        Ver10_0 = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="10.2")]
        Ver10_2 = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="11")]
        Ver11 = 5,
    }
    public partial class PostgreSqlSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PostgreSqlSkuTier
    {
        Basic = 0,
        GeneralPurpose = 1,
        MemoryOptimized = 2,
    }
    public enum PostgreSqlSslEnforcementEnum
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum PostgreSqlStorageAutogrow
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class PostgreSqlStorageProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PostgreSqlStorageProfile() { }
        public Azure.Provisioning.BicepValue<int> BackupRetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlGeoRedundantBackup> GeoRedundantBackup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlStorageAutogrow> StorageAutogrow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> StorageInMB { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlVirtualNetworkRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PostgreSqlVirtualNetworkRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlVirtualNetworkRuleState> State { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualNetworkSubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PostgreSql.PostgreSqlVirtualNetworkRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_12_01;
        }
    }
    public enum PostgreSqlVirtualNetworkRuleState
    {
        Initializing = 0,
        InProgress = 1,
        Ready = 2,
        Deleting = 3,
        Unknown = 4,
    }
    public enum ReadReplicaPromoteMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="standalone")]
        Standalone = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="switchover")]
        Switchover = 1,
    }
    public enum ReplicationPromoteOption
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="planned")]
        Planned = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="forced")]
        Forced = 1,
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class ServerSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServerSku() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServerSkuTier> Tier { get { throw null; } }
    }
    public partial class ServerThreatProtectionSettingsModel : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServerThreatProtectionSettingsModel(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.ThreatProtectionState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.ThreatProtectionName> ThreatProtectionName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PostgreSql.ServerThreatProtectionSettingsModel FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_06_01;
            public static readonly string V2022_12_01;
            public static readonly string V2024_08_01;
        }
    }
    public enum StorageAutoGrow
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum ThreatProtectionName
    {
        Default = 0,
    }
    public enum ThreatProtectionState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ValidationSummaryItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ValidationSummaryItem() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServersValidationMessage> Messages { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServersValidationState> State { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ValidationSummaryItemType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualEndpoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualEndpoint(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.PostgreSql.VirtualEndpointType> EndpointType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Members { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.PostgreSql.PostgreSqlFlexibleServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<string> VirtualEndpoints { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.PostgreSql.VirtualEndpoint FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_06_01;
            public static readonly string V2022_12_01;
            public static readonly string V2024_08_01;
        }
    }
    public enum VirtualEndpointType
    {
        ReadWrite = 0,
    }
}
