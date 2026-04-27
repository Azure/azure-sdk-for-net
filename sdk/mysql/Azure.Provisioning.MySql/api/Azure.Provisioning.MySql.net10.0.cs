namespace Azure.Provisioning.MySql
{
    public partial class AdvancedThreatProtection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AdvancedThreatProtection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MySql.MySqlFlexibleServer Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.AdvancedThreatProtectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.AdvancedThreatProtectionState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MySql.AdvancedThreatProtection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_12_30;
        }
    }
    public enum AdvancedThreatProtectionProvisioningState
    {
        Succeeded = 0,
        Updating = 1,
        Canceled = 2,
        Failed = 3,
    }
    public enum AdvancedThreatProtectionState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ImportSourceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImportSourceProperties() { }
        public Azure.Provisioning.BicepValue<string> DataDirPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SasToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.ImportSourceStorageType> StorageType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> StorageUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ImportSourceStorageType
    {
        AzureBlob = 0,
    }
    public partial class MySqlFlexibleServer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MySqlFlexibleServer(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AdministratorLogin { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AvailabilityZone { get { throw null; } set { } }
        public Azure.Provisioning.MySql.MySqlFlexibleServerBackupProperties Backup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerCreateMode> CreateMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DatabasePort { get { throw null; } set { } }
        public Azure.Provisioning.MySql.MySqlFlexibleServerDataEncryption DataEncryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FullVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FullyQualifiedDomainName { get { throw null; } }
        public Azure.Provisioning.MySql.MySqlFlexibleServerHighAvailability HighAvailability { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.MySql.ImportSourceProperties ImportSourceProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerPatchStrategy> MaintenancePatchStrategy { get { throw null; } set { } }
        public Azure.Provisioning.MySql.MySqlFlexibleServerMaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MySql.MySqlFlexibleServerNetwork Network { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReplicaCapacity { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerReplicationRole> ReplicationRole { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RestorePointInOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MySql.MySqlFlexibleServersPrivateEndpointConnection> ServerPrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.MySql.MySqlFlexibleServerSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceServerResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerState> State { get { throw null; } }
        public Azure.Provisioning.MySql.MySqlFlexibleServerStorage Storage { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerVersion> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MySql.MySqlFlexibleServer FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_12_30;
        }
    }
    public partial class MySqlFlexibleServerAadAdministrator : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MySqlFlexibleServerAadAdministrator(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerAdministratorType> AdministratorType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> IdentityResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Login { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MySql.MySqlFlexibleServer Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sid { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MySql.MySqlFlexibleServerAadAdministrator FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_12_30;
        }
    }
    public enum MySqlFlexibleServerAdministratorType
    {
        ActiveDirectory = 0,
    }
    public partial class MySqlFlexibleServerBackup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MySqlFlexibleServerBackup(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> BackupType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CompletedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MySql.MySqlFlexibleServer Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Source { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MySql.MySqlFlexibleServerBackup FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_12_30;
        }
    }
    public partial class MySqlFlexibleServerBackupProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MySqlFlexibleServerBackupProperties() { }
        public Azure.Provisioning.BicepValue<int> BackupIntervalHours { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> BackupRetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EarliestRestoreOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerEnableStatusEnum> GeoRedundantBackup { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MySqlFlexibleServerBackupProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
        Canceled = 4,
    }
    public enum MySqlFlexibleServerBackupType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="FULL")]
        Full = 0,
    }
    public partial class MySqlFlexibleServerBackupV2 : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MySqlFlexibleServerBackupV2(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> BackupNameV2 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerBackupType> BackupType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CompletedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MySql.MySqlFlexibleServer Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerBackupProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Source { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MySql.MySqlFlexibleServerBackupV2 FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_12_30;
        }
    }
    public enum MySqlFlexibleServerBatchOfMaintenance
    {
        Default = 0,
        Batch1 = 1,
        Batch2 = 2,
    }
    public enum MySqlFlexibleServerConfigDynamicState
    {
        True = 0,
        False = 1,
    }
    public enum MySqlFlexibleServerConfigPendingRestartState
    {
        True = 0,
        False = 1,
    }
    public enum MySqlFlexibleServerConfigReadOnlyState
    {
        True = 0,
        False = 1,
    }
    public partial class MySqlFlexibleServerConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MySqlFlexibleServerConfiguration(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AllowedValues { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CurrentValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DataType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DefaultValue { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DocumentationLink { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerConfigPendingRestartState> IsConfigPendingRestart { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerConfigDynamicState> IsDynamicConfig { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerConfigReadOnlyState> IsReadOnly { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MySql.MySqlFlexibleServer Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerConfigurationSource> Source { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MySql.MySqlFlexibleServerConfiguration FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_12_30;
        }
    }
    public enum MySqlFlexibleServerConfigurationSource
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="system-default")]
        SystemDefault = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="user-override")]
        UserOverride = 1,
    }
    public enum MySqlFlexibleServerCreateMode
    {
        Default = 0,
        PointInTimeRestore = 1,
        Replica = 2,
        GeoRestore = 3,
    }
    public partial class MySqlFlexibleServerDatabase : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MySqlFlexibleServerDatabase(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Charset { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Collation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MySql.MySqlFlexibleServer Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MySql.MySqlFlexibleServerDatabase FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_12_30;
        }
    }
    public partial class MySqlFlexibleServerDataEncryption : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MySqlFlexibleServerDataEncryption() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerDataEncryptionType> EncryptionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> GeoBackupKeyUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> GeoBackupUserAssignedIdentityId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> PrimaryKeyUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrimaryUserAssignedIdentityId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MySqlFlexibleServerDataEncryptionType
    {
        AzureKeyVault = 0,
        SystemManaged = 1,
    }
    public enum MySqlFlexibleServerEnableStatusEnum
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class MySqlFlexibleServerFeatureProperty : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MySqlFlexibleServerFeatureProperty() { }
        public Azure.Provisioning.BicepValue<string> FeatureName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FeatureValue { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MySqlFlexibleServerFirewallRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MySqlFlexibleServerFirewallRule(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> EndIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MySql.MySqlFlexibleServer Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> StartIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MySql.MySqlFlexibleServerFirewallRule FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_12_30;
        }
    }
    public partial class MySqlFlexibleServerHighAvailability : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MySqlFlexibleServerHighAvailability() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerHighAvailabilityMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StandbyAvailabilityZone { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerHighAvailabilityState> State { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MySqlFlexibleServerHighAvailabilityMode
    {
        Disabled = 0,
        ZoneRedundant = 1,
        SameZone = 2,
    }
    public enum MySqlFlexibleServerHighAvailabilityState
    {
        NotEnabled = 0,
        CreatingStandby = 1,
        Healthy = 2,
        FailingOver = 3,
        RemovingStandby = 4,
    }
    public partial class MySqlFlexibleServerMaintenance : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MySqlFlexibleServerMaintenance(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> MaintenanceAvailableScheduleMaxOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> MaintenanceAvailableScheduleMinOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MaintenanceDescription { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> MaintenanceEndOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> MaintenanceExecutionEndOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> MaintenanceExecutionStartOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> MaintenanceStartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerMaintenanceState> MaintenanceState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MaintenanceTitle { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerMaintenanceType> MaintenanceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MySql.MySqlFlexibleServer Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerMaintenanceProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MySql.MySqlFlexibleServerMaintenance FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_12_30;
        }
    }
    public enum MySqlFlexibleServerMaintenanceProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public enum MySqlFlexibleServerMaintenanceState
    {
        Scheduled = 0,
        ReScheduled = 1,
        InPreparation = 2,
        Processing = 3,
        Completed = 4,
        Canceled = 5,
    }
    public enum MySqlFlexibleServerMaintenanceType
    {
        RoutineMaintenance = 0,
        MinorVersionUpgrade = 1,
        SecurityPatches = 2,
        HotFixes = 3,
    }
    public partial class MySqlFlexibleServerMaintenanceWindow : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MySqlFlexibleServerMaintenanceWindow() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerBatchOfMaintenance> BatchOfMaintenance { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomWindow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DayOfWeek { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> StartHour { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> StartMinute { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MySqlFlexibleServerNetwork : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MySqlFlexibleServerNetwork() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DelegatedSubnetResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateDnsZoneResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerEnableStatusEnum> PublicNetworkAccess { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MySqlFlexibleServerPatchStrategy
    {
        Regular = 0,
        VirtualCanary = 1,
    }
    public enum MySqlFlexibleServerReplicationRole
    {
        None = 0,
        Source = 1,
        Replica = 2,
    }
    public partial class MySqlFlexibleServersCapability : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MySqlFlexibleServersCapability(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MySql.MySqlFlexibleServerFeatureProperty> SupportedFeatures { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MySql.ServerEditionCapabilityV2> SupportedFlexibleServerEditions { get { throw null; } }
        public Azure.Provisioning.BicepList<string> SupportedGeoBackupRegions { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MySql.ServerVersionCapabilityV2> SupportedServerVersions { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MySql.MySqlFlexibleServersCapability FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_12_30;
        }
    }
    public partial class MySqlFlexibleServerSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MySqlFlexibleServerSku() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MySqlFlexibleServerSkuTier
    {
        Burstable = 0,
        GeneralPurpose = 1,
        MemoryOptimized = 2,
    }
    public partial class MySqlFlexibleServersPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MySqlFlexibleServersPrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MySql.MySqlFlexibleServer Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.MySql.MySqlPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MySql.MySqlFlexibleServersPrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_12_30;
        }
    }
    public enum MySqlFlexibleServerState
    {
        Ready = 0,
        Dropping = 1,
        Disabled = 2,
        Starting = 3,
        Stopping = 4,
        Stopped = 5,
        Updating = 6,
    }
    public partial class MySqlFlexibleServerStorage : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MySqlFlexibleServerStorage() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerEnableStatusEnum> AutoGrow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerEnableStatusEnum> AutoIoScaling { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Iops { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerEnableStatusEnum> LogOnDisk { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlFlexibleServerStorageRedundancyType> StorageRedundancy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> StorageSizeInGB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageSku { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MySqlFlexibleServerStorageEditionCapability : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MySqlFlexibleServerStorageEditionCapability() { }
        public Azure.Provisioning.BicepValue<long> MaxBackupIntervalHours { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> MaxBackupRetentionDays { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> MaxStorageSize { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> MinBackupIntervalHours { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> MinBackupRetentionDays { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> MinStorageSize { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MySqlFlexibleServerStorageRedundancyType
    {
        LocalRedundancy = 0,
        ZoneRedundancy = 1,
    }
    public enum MySqlFlexibleServerVersion
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="5.7")]
        Five7 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="8.0.21")]
        Eight021 = 1,
    }
    public enum MySqlPrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public enum MySqlPrivateEndpointServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
    }
    public partial class MySqlPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MySqlPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MySql.MySqlPrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServerEditionCapabilityV2 : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServerEditionCapabilityV2() { }
        public Azure.Provisioning.BicepValue<string> DefaultSku { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> DefaultStorageSize { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MySql.SkuCapabilityV2> SupportedSkus { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MySql.MySqlFlexibleServerStorageEditionCapability> SupportedStorageEditions { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServerVersionCapabilityV2 : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServerVersionCapabilityV2() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SkuCapabilityV2 : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SkuCapabilityV2() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepList<string> SupportedHAMode { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> SupportedIops { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> SupportedMemoryPerVCoreMB { get { throw null; } }
        public Azure.Provisioning.BicepList<string> SupportedZones { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> VCores { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
}
