namespace Azure.Provisioning.Sql
{
    public enum AdvancedThreatProtectionName
    {
        Default = 0,
    }
    public enum AdvancedThreatProtectionState
    {
        New = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public enum AuthenticationName
    {
        Default = 0,
    }
    public enum AuthMetadataLookupMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="AzureAD")]
        Aad = 0,
        Paired = 1,
        Windows = 2,
    }
    public partial class BackupShortTermRetentionPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BackupShortTermRetentionPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> DiffBackupIntervalInHours { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.BackupShortTermRetentionPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum BlobAuditingPolicyName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="default")]
        Default = 0,
    }
    public enum BlobAuditingPolicyState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum CatalogCollationType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DATABASE_DEFAULT")]
        DatabaseDefault = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SQL_Latin1_General_CP1_CI_AS")]
        SqlLatin1GeneralCp1CiAs = 1,
    }
    public enum ClientClassificationSource
    {
        None = 0,
        Native = 1,
        Recommended = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MIP")]
        Mip = 3,
    }
    public enum ConnectionPolicyName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="default")]
        Default = 0,
    }
    public partial class CreateDatabaseRestorePointDefinition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CreateDatabaseRestorePointDefinition() { }
        public Azure.Provisioning.BicepValue<string> RestorePointLabel { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatabaseAdvancedThreatProtection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DatabaseAdvancedThreatProtection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.AdvancedThreatProtectionState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.DatabaseAdvancedThreatProtection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class DatabaseIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabaseIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.DatabaseIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.UserAssignedIdentityDetails> UserAssignedIdentities { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DatabaseIdentityType
    {
        None = 0,
        UserAssigned = 1,
    }
    public enum DatabaseLicenseType
    {
        LicenseIncluded = 0,
        BasePrice = 1,
    }
    public enum DatabaseReadScale
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class DatabaseVulnerabilityAssessmentRuleBaselineItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabaseVulnerabilityAssessmentRuleBaselineItem() { }
        public Azure.Provisioning.BicepList<string> Result { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataMaskingPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataMaskingPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ApplicationPrincipals { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.DataMaskingState> DataMaskingState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExemptPrincipals { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MaskingLevel { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.DataMaskingPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_01_01;
            public static readonly string V2014_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum DataMaskingState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class DistributedAvailabilityGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DistributedAvailabilityGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Guid> DistributedAvailabilityGroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastHardenedLsn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LinkState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.ManagedInstance? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrimaryAvailabilityGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.DistributedAvailabilityGroupReplicationMode> ReplicationMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecondaryAvailabilityGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> SourceReplicaId { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TargetDatabase { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TargetReplicaId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.DistributedAvailabilityGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class DistributedAvailabilityGroupDatabase : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DistributedAvailabilityGroupDatabase() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlReplicaConnectedState> ConnectedState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> InstanceRedoReplicationLagSeconds { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> InstanceReplicaId { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> InstanceSendReplicationLagSeconds { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastBackupLsn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastBackupOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastCommitLsn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastCommitOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastHardenedLsn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastHardenedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastReceivedLsn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastReceivedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastSentLsn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastSentOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MostRecentLinkError { get { throw null; } }
        public Azure.Provisioning.Sql.SqlServerCertificateInfo PartnerAuthCertValidity { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> PartnerReplicaId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ReplicaState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SeedingProgress { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlReplicaSynchronizationHealth> SynchronizationHealth { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DistributedAvailabilityGroupReplicationMode
    {
        Async = 0,
        Sync = 1,
    }
    public enum DtcName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="current")]
        Current = 0,
    }
    public partial class ElasticPool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ElasticPool(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> AutoPauseDelay { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlAvailabilityZoneType> AvailabilityZone { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> HighAvailabilityReplicaCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsZoneRedundant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ElasticPoolLicenseType> LicenseType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> MaintenanceConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MaxSizeBytes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> MinCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Sql.ElasticPoolPerDatabaseSettings PerDatabaseSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlAlwaysEncryptedEnclaveType> PreferredEnclaveType { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ElasticPoolState> State { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ElasticPool FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_01_01;
            public static readonly string V2014_04_01;
            public static readonly string V2015_05_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum ElasticPoolLicenseType
    {
        LicenseIncluded = 0,
        BasePrice = 1,
    }
    public partial class ElasticPoolPerDatabaseSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ElasticPoolPerDatabaseSettings() { }
        public Azure.Provisioning.BicepValue<int> AutoPauseDelay { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> MaxCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> MinCapacity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ElasticPoolState
    {
        Creating = 0,
        Ready = 1,
        Disabled = 2,
    }
    public partial class EncryptionProtector : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EncryptionProtector(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAutoRotationEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServerKeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlServerKeyType> ServerKeyType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Subregion { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.EncryptionProtector FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum EncryptionProtectorName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="current")]
        Current = 0,
    }
    public partial class ExtendedDatabaseBlobAuditingPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ExtendedDatabaseBlobAuditingPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AuditActionsAndGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsManagedIdentityInUse { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PredicateExpression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> QueueDelayMs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.BlobAuditingPolicyState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> StorageAccountSubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ExtendedDatabaseBlobAuditingPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_01_01;
            public static readonly string V2014_04_01;
            public static readonly string V2015_01_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class ExtendedServerBlobAuditingPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ExtendedServerBlobAuditingPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AuditActionsAndGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDevopsAuditEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsManagedIdentityInUse { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PredicateExpression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> QueueDelayMs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.BlobAuditingPolicyState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> StorageAccountSubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ExtendedServerBlobAuditingPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum ExternalGovernanceStatus
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class FailoverGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FailoverGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> FailoverDatabases { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Sql.PartnerServerInfo> PartnerServers { get { throw null; } set { } }
        public Azure.Provisioning.Sql.FailoverGroupReadOnlyEndpoint ReadOnlyEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.Sql.FailoverGroupReadWriteEndpoint ReadWriteEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.FailoverGroupReplicationRole> ReplicationRole { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ReplicationState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.FailoverGroupDatabasesSecondaryType> SecondaryType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.FailoverGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum FailoverGroupDatabasesSecondaryType
    {
        Geo = 0,
        Standby = 1,
    }
    public partial class FailoverGroupReadOnlyEndpoint : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FailoverGroupReadOnlyEndpoint() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ReadOnlyEndpointFailoverPolicy> FailoverPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetServer { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FailoverGroupReadWriteEndpoint : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FailoverGroupReadWriteEndpoint() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ReadWriteEndpointFailoverPolicy> FailoverPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FailoverWithDataLossGracePeriodMinutes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FailoverGroupReplicationRole
    {
        Primary = 0,
        Secondary = 1,
    }
    public enum FreeLimitExhaustionBehavior
    {
        AutoPause = 0,
        BillOverUsage = 1,
    }
    public partial class GeoBackupPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public GeoBackupPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.GeoBackupPolicyState> GeoBackupPolicyState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.GeoBackupPolicyState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageType { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.GeoBackupPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_01_01;
            public static readonly string V2014_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum GeoBackupPolicyName
    {
        Default = 0,
    }
    public enum GeoBackupPolicyState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum GeoSecondaryInstanceType
    {
        Geo = 0,
        Standby = 1,
    }
    public enum HybridSecondaryUsage
    {
        Active = 0,
        Passive = 1,
    }
    public enum HybridSecondaryUsageDetected
    {
        Active = 0,
        Passive = 1,
    }
    public partial class InstanceFailoverGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public InstanceFailoverGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Sql.ManagedInstancePairInfo> ManagedInstancePairs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Sql.PartnerRegionInfo> PartnerRegions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ReadOnlyEndpointFailoverPolicy> ReadOnlyEndpointFailoverPolicy { get { throw null; } set { } }
        public Azure.Provisioning.Sql.InstanceFailoverGroupReadWriteEndpoint ReadWriteEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.InstanceFailoverGroupReplicationRole> ReplicationRole { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ReplicationState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.GeoSecondaryInstanceType> SecondaryType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.InstanceFailoverGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class InstanceFailoverGroupReadWriteEndpoint : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public InstanceFailoverGroupReadWriteEndpoint() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ReadWriteEndpointFailoverPolicy> FailoverPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FailoverWithDataLossGracePeriodMinutes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum InstanceFailoverGroupReplicationRole
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class InstancePool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public InstancePool(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DnsZone { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.InstancePoolLicenseType> LicenseType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> MaintenanceConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> VCores { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.InstancePool FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum InstancePoolLicenseType
    {
        LicenseIncluded = 0,
        BasePrice = 1,
    }
    public partial class IPv6FirewallRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IPv6FirewallRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> EndIPv6Address { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartIPv6Address { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.IPv6FirewallRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_01_01;
            public static readonly string V2014_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class JobAgentIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JobAgentIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.JobAgentIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.UserAssignedIdentityDetails> UserAssignedIdentities { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum JobAgentIdentityType
    {
        None = 0,
        SystemAssigned = 1,
        UserAssigned = 2,
        SystemAssignedUserAssigned = 3,
    }
    public enum JobAgentState
    {
        Creating = 0,
        Ready = 1,
        Updating = 2,
        Deleting = 3,
        Disabled = 4,
    }
    public enum JobExecutionLifecycle
    {
        Created = 0,
        InProgress = 1,
        WaitingForChildJobExecutions = 2,
        WaitingForRetry = 3,
        Succeeded = 4,
        SucceededWithSkipped = 5,
        Failed = 6,
        TimedOut = 7,
        Canceled = 8,
        Skipped = 9,
    }
    public enum JobExecutionProvisioningState
    {
        Created = 0,
        InProgress = 1,
        Succeeded = 2,
        Failed = 3,
        Canceled = 4,
    }
    public partial class JobExecutionTarget : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JobExecutionTarget() { }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ServerName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.JobTargetType> TargetType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JobStepAction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JobStepAction() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.JobStepActionType> ActionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.JobStepActionSource> Source { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum JobStepActionSource
    {
        Inline = 0,
    }
    public enum JobStepActionType
    {
        TSql = 0,
    }
    public partial class JobStepExecutionOptions : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JobStepExecutionOptions() { }
        public Azure.Provisioning.BicepValue<int> InitialRetryIntervalSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaximumRetryIntervalSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetryAttempts { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> RetryIntervalBackoffMultiplier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TimeoutSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JobStepOutput : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JobStepOutput() { }
        public Azure.Provisioning.BicepValue<string> Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.JobStepOutputType> OutputType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SchemaName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> SubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum JobStepOutputType
    {
        SqlDatabase = 0,
    }
    public partial class JobTarget : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JobTarget() { }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ElasticPoolName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.JobTargetGroupMembershipType> MembershipType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RefreshCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ShardMapName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.JobTargetType> TargetType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum JobTargetGroupMembershipType
    {
        Include = 0,
        Exclude = 1,
    }
    public enum JobTargetType
    {
        TargetGroup = 0,
        SqlDatabase = 1,
        SqlElasticPool = 2,
        SqlShardMap = 3,
        SqlServer = 4,
    }
    public partial class LedgerDigestUpload : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public LedgerDigestUpload(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DigestStorageEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.LedgerDigestUploadsState> State { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.LedgerDigestUpload FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum LedgerDigestUploadsName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="current")]
        Current = 0,
    }
    public enum LedgerDigestUploadsState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class LogicalDatabaseTransparentDataEncryption : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public LogicalDatabaseTransparentDataEncryption(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.TransparentDataEncryptionState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.LogicalDatabaseTransparentDataEncryption FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class LongTermRetentionPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public LongTermRetentionPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlBackupStorageAccessTier> BackupStorageAccessTier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.BicepValue<bool> MakeBackupsImmutable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MonthlyRetention { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> WeeklyRetention { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> WeekOfYear { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> YearlyRetention { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.LongTermRetentionPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum LongTermRetentionPolicyName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="default")]
        Default = 0,
    }
    public partial class ManagedBackupShortTermRetentionPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedBackupShortTermRetentionPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.ManagedDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedBackupShortTermRetentionPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class ManagedDatabase : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedDatabase(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowAutoCompleteRestore { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.CatalogCollationType> CatalogCollation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Collation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ManagedDatabaseCreateMode> CreateMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CrossSubscriptionRestorableDroppedDatabaseId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CrossSubscriptionSourceDatabaseId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CrossSubscriptionTargetManagedInstanceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> DefaultSecondaryLocation { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EarliestRestorePoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FailoverGroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsLedgerOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LastBackupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> LongTermRetentionBackupResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.ManagedInstance? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RecoverableDatabaseId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RestorableDroppedDatabaseId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RestorePointInTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceDatabaseId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ManagedDatabaseStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> StorageContainerIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageContainerSasToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> StorageContainerUri { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedDatabase FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class ManagedDatabaseAdvancedThreatProtection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedDatabaseAdvancedThreatProtection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.ManagedDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.AdvancedThreatProtectionState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedDatabaseAdvancedThreatProtection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum ManagedDatabaseCreateMode
    {
        Default = 0,
        RestoreExternalBackup = 1,
        PointInTimeRestore = 2,
        Recovery = 3,
        RestoreLongTermRetentionBackup = 4,
    }
    public partial class ManagedDatabaseSecurityAlertPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedDatabaseSecurityAlertPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<string> DisabledAlerts { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EmailAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.ManagedDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SendToEmailAccountAdmins { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SecurityAlertPolicyState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedDatabaseSecurityAlertPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class ManagedDatabaseSensitivityLabel : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedDatabaseSensitivityLabel(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ClientClassificationSource> ClientClassificationSource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ColumnName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InformationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InformationTypeId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDisabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LabelId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LabelName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SensitivityLabelRank> Rank { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SchemaName { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedDatabaseSensitivityLabel FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public enum ManagedDatabaseStatus
    {
        Online = 0,
        Offline = 1,
        Shutdown = 2,
        Creating = 3,
        Inaccessible = 4,
        Restoring = 5,
        Updating = 6,
        Stopping = 7,
        Stopped = 8,
        Starting = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="DbMoving")]
        DBMoving = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="DbCopying")]
        DBCopying = 11,
    }
    public partial class ManagedDatabaseVulnerabilityAssessment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedDatabaseVulnerabilityAssessment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.ManagedDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Sql.VulnerabilityAssessmentRecurringScansProperties RecurringScans { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageContainerPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageContainerSasKey { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedDatabaseVulnerabilityAssessment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class ManagedDatabaseVulnerabilityAssessmentRuleBaseline : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedDatabaseVulnerabilityAssessmentRuleBaseline(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Sql.DatabaseVulnerabilityAssessmentRuleBaselineItem> BaselineResults { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedDatabaseVulnerabilityAssessmentRuleBaseline FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class ManagedInstance : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedInstance(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AdministratorLogin { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.Provisioning.Sql.ManagedInstanceExternalAdministrator Administrators { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.AuthMetadataLookupMode> AuthenticationMetadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Collation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreateOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlBackupStorageRedundancy> CurrentBackupStorageRedundancy { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ManagedInstanceDatabaseFormat> DatabaseFormat { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DnsZone { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ExternalGovernanceStatus> ExternalGovernanceStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FullyQualifiedDomainName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.HybridSecondaryUsage> HybridSecondaryUsage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.HybridSecondaryUsageDetected> HybridSecondaryUsageDetected { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> InstancePoolId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsGeneralPurposeV2 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPublicDataEndpointEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsZoneRedundant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ManagedInstanceLicenseType> LicenseType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> MaintenanceConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedDnsZonePartner { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ManagedServerCreateMode> ManagedInstanceCreateMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MinimalTlsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlManagedInstancePricingModel> PricingModel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrimaryUserAssignedIdentityId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Sql.ManagedInstancePecProperty> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ManagedInstancePropertiesProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ManagedInstanceProxyOverride> ProxyOverride { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlBackupStorageRedundancy> RequestedBackupStorageRedundancy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RestorePointInTime { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlServicePrincipal ServicePrincipal { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceManagedInstanceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> State { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> StorageIOps { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> StorageSizeInGB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> StorageThroughputMBps { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimezoneId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> VCores { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualClusterId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedInstance FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class ManagedInstanceAdministrator : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedInstanceAdministrator(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ManagedInstanceAdministratorType> AdministratorType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Login { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.ManagedInstance? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> Sid { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedInstanceAdministrator FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum ManagedInstanceAdministratorType
    {
        ActiveDirectory = 0,
    }
    public partial class ManagedInstanceAdvancedThreatProtection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedInstanceAdvancedThreatProtection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.ManagedInstance? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.AdvancedThreatProtectionState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedInstanceAdvancedThreatProtection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class ManagedInstanceAzureADOnlyAuthentication : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedInstanceAzureADOnlyAuthentication(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAzureADOnlyAuthenticationEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.ManagedInstance? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedInstanceAzureADOnlyAuthentication FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum ManagedInstanceDatabaseFormat
    {
        AlwaysUpToDate = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SQLServer2022")]
        SqlServer2022 = 1,
    }
    public partial class ManagedInstanceDtc : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedInstanceDtc(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> DtcEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DtcHostNameDnsSuffix { get { throw null; } }
        public Azure.Provisioning.BicepList<string> ExternalDnsSuffixSearchList { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.ManagedInstance? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.JobExecutionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Sql.ManagedInstanceDtcSecuritySettings SecuritySettings { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedInstanceDtc FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class ManagedInstanceDtcSecuritySettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedInstanceDtcSecuritySettings() { }
        public Azure.Provisioning.BicepValue<bool> IsXATransactionsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SnaLu6Point2TransactionsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.Sql.ManagedInstanceDtcTransactionManagerCommunicationSettings TransactionManagerCommunicationSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> XATransactionsDefaultTimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> XATransactionsMaximumTimeoutInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedInstanceDtcTransactionManagerCommunicationSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedInstanceDtcTransactionManagerCommunicationSettings() { }
        public Azure.Provisioning.BicepValue<bool> AllowInboundEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowOutboundEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Authentication { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedInstanceEncryptionProtector : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedInstanceEncryptionProtector(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAutoRotationEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.ManagedInstance? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServerKeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlServerKeyType> ServerKeyType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedInstanceEncryptionProtector FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class ManagedInstanceExternalAdministrator : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedInstanceExternalAdministrator() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlAdministratorType> AdministratorType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAzureADOnlyAuthenticationEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Login { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlServerPrincipalType> PrincipalType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> Sid { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedInstanceKey : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedInstanceKey(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAutoRotationEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.ManagedInstance? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlServerKeyType> ServerKeyType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedInstanceKey FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum ManagedInstanceLicenseType
    {
        LicenseIncluded = 0,
        BasePrice = 1,
    }
    public partial class ManagedInstanceLongTermRetentionPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedInstanceLongTermRetentionPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlBackupStorageAccessTier> BackupStorageAccessTier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MonthlyRetention { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.ManagedDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> WeeklyRetention { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> WeekOfYear { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> YearlyRetention { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedInstanceLongTermRetentionPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum ManagedInstanceLongTermRetentionPolicyName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="default")]
        Default = 0,
    }
    public partial class ManagedInstancePairInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedInstancePairInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PartnerManagedInstanceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrimaryManagedInstanceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedInstancePecProperty : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedInstancePecProperty() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Sql.ManagedInstancePrivateEndpointConnectionProperties Properties { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedInstancePrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedInstancePrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Sql.ManagedInstancePrivateLinkServiceConnectionStateProperty ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.ManagedInstance? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedInstancePrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class ManagedInstancePrivateEndpointConnectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedInstancePrivateEndpointConnectionProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.Sql.ManagedInstancePrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedInstancePrivateLinkServiceConnectionStateProperty : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedInstancePrivateLinkServiceConnectionStateProperty() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedInstancePropertiesProvisioningState
    {
        Creating = 0,
        Deleting = 1,
        Updating = 2,
        Unknown = 3,
        Succeeded = 4,
        Failed = 5,
        Accepted = 6,
        Created = 7,
        Deleted = 8,
        Unrecognized = 9,
        Running = 10,
        Canceled = 11,
        NotSpecified = 12,
        Registering = 13,
        TimedOut = 14,
        InProgress = 15,
    }
    public enum ManagedInstanceProxyOverride
    {
        Proxy = 0,
        Redirect = 1,
        Default = 2,
    }
    public partial class ManagedInstanceServerConfigurationOption : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedInstanceServerConfigurationOption(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.ManagedInstance? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.JobExecutionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ServerConfigurationOptionValue { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedInstanceServerConfigurationOption FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum ManagedInstanceServerConfigurationOptionName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="allowPolybaseExport")]
        AllowPolybaseExport = 0,
    }
    public partial class ManagedInstanceServerTrustCertificate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedInstanceServerTrustCertificate(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> CertificateName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.ManagedInstance? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublicBlob { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedInstanceServerTrustCertificate FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class ManagedInstanceStartStopSchedule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedInstanceStartStopSchedule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> NextExecutionTime { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> NextRunAction { get { throw null; } }
        public Azure.Provisioning.Sql.ManagedInstance? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Sql.SqlScheduleItem> ScheduleList { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TimeZoneId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedInstanceStartStopSchedule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum ManagedInstanceStartStopScheduleName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="default")]
        Default = 0,
    }
    public partial class ManagedInstanceVulnerabilityAssessment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedInstanceVulnerabilityAssessment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.ManagedInstance? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Sql.VulnerabilityAssessmentRecurringScansProperties RecurringScans { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageContainerPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageContainerSasKey { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedInstanceVulnerabilityAssessment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class ManagedLedgerDigestUpload : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedLedgerDigestUpload(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DigestStorageEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.ManagedDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ManagedLedgerDigestUploadsState> State { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedLedgerDigestUpload FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum ManagedLedgerDigestUploadsName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="current")]
        Current = 0,
    }
    public enum ManagedLedgerDigestUploadsState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ManagedRestorableDroppedDbBackupShortTermRetentionPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedRestorableDroppedDbBackupShortTermRetentionPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> RetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedRestorableDroppedDbBackupShortTermRetentionPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public enum ManagedServerCreateMode
    {
        Default = 0,
        PointInTimeRestore = 1,
    }
    public partial class ManagedServerDnsAlias : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedServerDnsAlias(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AzureDnsRecord { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> CreateDnsRecord { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.ManagedInstance? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublicAzureDnsRecord { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedServerDnsAlias FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class ManagedServerSecurityAlertPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedServerSecurityAlertPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<string> DisabledAlerts { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EmailAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.ManagedInstance? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SendToEmailAccountAdmins { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SecurityAlertsPolicyState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedServerSecurityAlertPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum ManagedShortTermRetentionPolicyName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="default")]
        Default = 0,
    }
    public partial class ManagedTransparentDataEncryption : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedTransparentDataEncryption(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.ManagedDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.TransparentDataEncryptionState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ManagedTransparentDataEncryption FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class OutboundFirewallRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public OutboundFirewallRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.OutboundFirewallRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_01_01;
            public static readonly string V2014_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class PartnerRegionInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PartnerRegionInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.InstanceFailoverGroupReplicationRole> ReplicationRole { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PartnerServerInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PartnerServerInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.FailoverGroupReplicationRole> ReplicationRole { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ReadOnlyEndpointFailoverPolicy
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum ReadWriteEndpointFailoverPolicy
    {
        Manual = 0,
        Automatic = 1,
    }
    public enum ReplicationLinkState
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="PENDING")]
        Pending = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SEEDING")]
        Seeding = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="CATCH_UP")]
        CatchUp = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SUSPENDED")]
        Suspended = 3,
    }
    public enum ReplicationLinkType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="GEO")]
        Geo = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="NAMED")]
        Named = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="STANDBY")]
        Standby = 2,
    }
    public enum RestorePointType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="CONTINUOUS")]
        Continuous = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="DISCRETE")]
        Discrete = 1,
    }
    public enum SampleSchemaName
    {
        AdventureWorksLT = 0,
        WideWorldImportersStd = 1,
        WideWorldImportersFull = 2,
    }
    public enum SecondaryType
    {
        Geo = 0,
        Named = 1,
        Standby = 2,
    }
    public enum SecurityAlertPolicyState
    {
        New = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public enum SecurityAlertsPolicyState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum SeedingModeType
    {
        Automatic = 0,
        Manual = 1,
    }
    public enum SensitivityLabelRank
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4,
    }
    public partial class ServerAdvancedThreatProtection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServerAdvancedThreatProtection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.AdvancedThreatProtectionState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.ServerAdvancedThreatProtection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum ServerConnectionType
    {
        Default = 0,
        Redirect = 1,
        Proxy = 2,
    }
    public partial class ServerExternalAdministrator : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServerExternalAdministrator() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlAdministratorType> AdministratorType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAzureADOnlyAuthenticationEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Login { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlServerPrincipalType> PrincipalType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> Sid { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServerNetworkAccessFlag
    {
        Enabled = 0,
        Disabled = 1,
        SecuredByPerimeter = 2,
    }
    public partial class ServerPrivateEndpointConnectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServerPrivateEndpointConnectionProperties() { }
        public Azure.Provisioning.Sql.SqlPrivateLinkServiceConnectionStateProperty ConnectionState { get { throw null; } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlPrivateEndpointProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServerTrustGroupPropertiesTrustScopesItem
    {
        GlobalTransactions = 0,
        ServiceBroker = 1,
    }
    public partial class ServerTrustGroupServerInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServerTrustGroupServerInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ServerId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServerWorkspaceFeature
    {
        Connected = 0,
        Disconnected = 1,
    }
    public enum ShortTermRetentionPolicyName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="default")]
        Default = 0,
    }
    public enum SqlAdministratorName
    {
        ActiveDirectory = 0,
    }
    public enum SqlAdministratorType
    {
        ActiveDirectory = 0,
    }
    public partial class SqlAgentConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlAgentConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.ManagedInstance? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlAgentConfigurationPropertiesState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlAgentConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_06_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum SqlAgentConfigurationPropertiesState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum SqlAlwaysEncryptedEnclaveType
    {
        Default = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="VBS")]
        Vbs = 1,
    }
    public enum SqlAvailabilityZoneType
    {
        NoPreference = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1")]
        One = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="2")]
        Two = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="3")]
        Three = 3,
    }
    public enum SqlBackupStorageAccessTier
    {
        Hot = 0,
        Archive = 1,
    }
    public enum SqlBackupStorageRedundancy
    {
        Geo = 0,
        Local = 1,
        Zone = 2,
        GeoZone = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlBuiltInRole : System.IEquatable<Azure.Provisioning.Sql.SqlBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.Sql.SqlBuiltInRole AzureConnectedSqlServerOnboarding { get { throw null; } }
        public static Azure.Provisioning.Sql.SqlBuiltInRole SqlDBContributor { get { throw null; } }
        public static Azure.Provisioning.Sql.SqlBuiltInRole SqlManagedInstanceContributor { get { throw null; } }
        public static Azure.Provisioning.Sql.SqlBuiltInRole SqlSecurityManager { get { throw null; } }
        public static Azure.Provisioning.Sql.SqlBuiltInRole SqlServerContributor { get { throw null; } }
        public bool Equals(Azure.Provisioning.Sql.SqlBuiltInRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string GetBuiltInRoleName(Azure.Provisioning.Sql.SqlBuiltInRole value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.Sql.SqlBuiltInRole left, Azure.Provisioning.Sql.SqlBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.Sql.SqlBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.Sql.SqlBuiltInRole left, Azure.Provisioning.Sql.SqlBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlDatabase : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlDatabase(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> AutoPauseDelay { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlAvailabilityZoneType> AvailabilityZone { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.CatalogCollationType> CatalogCollation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Collation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlDatabaseCreateMode> CreateMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlBackupStorageRedundancy> CurrentBackupStorageRedundancy { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CurrentServiceObjectiveName { get { throw null; } }
        public Azure.Provisioning.Sql.SqlSku CurrentSku { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> DatabaseId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> DefaultSecondaryLocation { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EarliestRestoreOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ElasticPoolId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptionProtector { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EncryptionProtectorAutoRotation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FailoverGroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> FederatedClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.FreeLimitExhaustionBehavior> FreeLimitExhaustionBehavior { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HighAvailabilityReplicaCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Sql.DatabaseIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsInfraEncryptionEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsLedgerOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsZoneRedundant { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Sql.SqlDatabaseKey> Keys { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.DatabaseLicenseType> LicenseType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> LongTermRetentionBackupResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> MaintenanceConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> ManualCutover { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MaxLogSizeBytes { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> MaxSizeBytes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> MinCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PausedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> PerformCutover { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlAlwaysEncryptedEnclaveType> PreferredEnclaveType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.DatabaseReadScale> ReadScale { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RecoverableDatabaseId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RecoveryServicesRecoveryPointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlBackupStorageRedundancy> RequestedBackupStorageRedundancy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RequestedServiceObjectiveName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RestorableDroppedDatabaseId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RestorePointInTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ResumedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SampleSchemaName> SampleName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SecondaryType> SecondaryType { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> SourceDatabaseDeletedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceDatabaseId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlDatabaseStatus> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseFreeLimit { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlDatabase FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_01_01;
            public static readonly string V2014_04_01;
            public static readonly string V2015_01_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlDatabaseBlobAuditingPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlDatabaseBlobAuditingPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AuditActionsAndGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsManagedIdentityInUse { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> QueueDelayMs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.BlobAuditingPolicyState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> StorageAccountSubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlDatabaseBlobAuditingPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum SqlDatabaseCreateMode
    {
        Default = 0,
        Copy = 1,
        Secondary = 2,
        PointInTimeRestore = 3,
        Restore = 4,
        Recovery = 5,
        RestoreExternalBackup = 6,
        RestoreExternalBackupSecondary = 7,
        RestoreLongTermRetentionBackup = 8,
        OnlineSecondary = 9,
    }
    public partial class SqlDatabaseKey : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlDatabaseKey() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlDatabaseKeyType> KeyType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Subregion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SqlDatabaseKeyType
    {
        AzureKeyVault = 0,
    }
    public partial class SqlDatabaseSecurityAlertPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlDatabaseSecurityAlertPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<string> DisabledAlerts { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EmailAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SendToEmailAccountAdmins { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SecurityAlertsPolicyState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlDatabaseSecurityAlertPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_01_01;
            public static readonly string V2014_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlDatabaseSensitivityLabel : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlDatabaseSensitivityLabel(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ClientClassificationSource> ClientClassificationSource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ColumnName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InformationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InformationTypeId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDisabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LabelId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LabelName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SensitivityLabelRank> Rank { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SchemaName { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlDatabaseSensitivityLabel FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class SqlDatabaseSqlVulnerabilityAssessmentBaseline : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlDatabaseSqlVulnerabilityAssessmentBaseline(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsLatestScan { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<string>>> Results { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaseline FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class SqlDatabaseSqlVulnerabilityAssessmentBaselineRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlDatabaseSqlVulnerabilityAssessmentBaselineRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsLatestScan { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaseline? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<string>> Results { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlDatabaseSqlVulnerabilityAssessmentBaselineRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public enum SqlDatabaseStatus
    {
        Online = 0,
        Restoring = 1,
        RecoveryPending = 2,
        Recovering = 3,
        Suspect = 4,
        Offline = 5,
        Standby = 6,
        Shutdown = 7,
        EmergencyMode = 8,
        AutoClosed = 9,
        Copying = 10,
        Creating = 11,
        Inaccessible = 12,
        OfflineSecondary = 13,
        Pausing = 14,
        Paused = 15,
        Resuming = 16,
        Scaling = 17,
        OfflineChangingDwPerformanceTiers = 18,
        OnlineChangingDwPerformanceTiers = 19,
        Disabled = 20,
        Stopping = 21,
        Stopped = 22,
        Starting = 23,
    }
    public partial class SqlDatabaseVulnerabilityAssessment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlDatabaseVulnerabilityAssessment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Sql.VulnerabilityAssessmentRecurringScansProperties RecurringScans { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageContainerPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageContainerSasKey { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlDatabaseVulnerabilityAssessment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlDatabaseVulnerabilityAssessmentRuleBaseline : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlDatabaseVulnerabilityAssessmentRuleBaseline(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Sql.DatabaseVulnerabilityAssessmentRuleBaselineItem> BaselineResults { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlDatabaseVulnerabilityAssessmentRuleBaseline FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public enum SqlDayOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }
    public partial class SqlDistributedAvailabilityGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlDistributedAvailabilityGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Sql.DistributedAvailabilityGroupDatabase> Databases { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> DistributedAvailabilityGroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DistributedAvailabilityGroupName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlServerFailoverModeType> FailoverMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InstanceAvailabilityGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlServerSideLinkRole> InstanceLinkRole { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.ManagedInstance? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartnerAvailabilityGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartnerEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlServerSideLinkRole> PartnerLinkRole { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlReplicationModeType> ReplicationMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SeedingModeType> SeedingMode { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlDistributedAvailabilityGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlFirewallRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlFirewallRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> EndIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartIPAddress { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlFirewallRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_01_01;
            public static readonly string V2014_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum SqlManagedInstancePricingModel
    {
        Regular = 0,
        Freemium = 1,
    }
    public enum SqlMinimalTlsVersion
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="None")]
        TlsNone = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.0")]
        Tls1_0 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.1")]
        Tls1_1 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.2")]
        Tls1_2 = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1.3")]
        Tls1_3 = 4,
    }
    public partial class SqlPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Sql.SqlPrivateLinkServiceConnectionStateProperty ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlPrivateEndpointProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_01_01;
            public static readonly string V2014_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum SqlPrivateEndpointProvisioningState
    {
        Approving = 0,
        Ready = 1,
        Dropping = 2,
        Failed = 3,
        Rejecting = 4,
    }
    public enum SqlPrivateLinkServiceConnectionActionsRequired
    {
        None = 0,
    }
    public partial class SqlPrivateLinkServiceConnectionStateProperty : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlPrivateLinkServiceConnectionStateProperty() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlPrivateLinkServiceConnectionActionsRequired> ActionsRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlPrivateLinkServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SqlPrivateLinkServiceConnectionStatus
    {
        Approved = 0,
        Pending = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public enum SqlReplicaConnectedState
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DISCONNECTED")]
        Disconnected = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="CONNECTED")]
        Connected = 1,
    }
    public enum SqlReplicaSynchronizationHealth
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="NOT_HEALTHY")]
        NotHealthy = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PARTIALLY_HEALTHY")]
        PartiallyHealthy = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HEALTHY")]
        Healthy = 2,
    }
    public enum SqlReplicationModeType
    {
        Async = 0,
        Sync = 1,
    }
    public partial class SqlScheduleItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlScheduleItem() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlDayOfWeek> StartDay { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlDayOfWeek> StopDay { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StopTime { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SqlSecurityAlertPolicyName
    {
        Default = 0,
    }
    public partial class SqlServer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServer(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AdministratorLogin { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.Provisioning.Sql.ServerExternalAdministrator Administrators { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ExternalGovernanceStatus> ExternalGovernanceStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> FederatedClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FullyQualifiedDomainName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ServerNetworkAccessFlag> IsIPv6Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlMinimalTlsVersion> MinTlsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrimaryUserAssignedIdentityId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Sql.SqlServerPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ServerNetworkAccessFlag> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ServerNetworkAccessFlag> RestrictOutboundNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> State { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ServerWorkspaceFeature> WorkspaceFeature { get { throw null; } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.Sql.SqlBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string? bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.Sql.SqlBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServer FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_01_01;
            public static readonly string V2014_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlServerAzureADAdministrator : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerAzureADAdministrator(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlAdministratorType> AdministratorType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAzureADOnlyAuthenticationEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Login { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> Sid { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerAzureADAdministrator FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_01_01;
            public static readonly string V2014_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlServerAzureADOnlyAuthentication : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerAzureADOnlyAuthentication(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAzureADOnlyAuthenticationEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerAzureADOnlyAuthentication FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_01_01;
            public static readonly string V2014_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlServerBlobAuditingPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerBlobAuditingPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AuditActionsAndGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDevopsAuditEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsManagedIdentityInUse { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> QueueDelayMs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.BlobAuditingPolicyState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> StorageAccountSubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerBlobAuditingPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlServerCertificateInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlServerCertificateInfo() { }
        public Azure.Provisioning.BicepValue<string> CertificateName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiryOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlServerCommunicationLink : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerCommunicationLink(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartnerServer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> State { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerCommunicationLink FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_01_01;
            public static readonly string V2014_04_01;
        }
    }
    public partial class SqlServerConnectionPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerConnectionPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ServerConnectionType> ConnectionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerConnectionPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_01_01;
            public static readonly string V2014_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlServerDatabaseReplicationLink : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerDatabaseReplicationLink(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsTerminationAllowed { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LinkId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ReplicationLinkType> LinkType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartnerDatabase { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PartnerDatabaseId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> PartnerLocation { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlServerDatabaseReplicationRole> PartnerRole { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PartnerServer { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> PercentComplete { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ReplicationMode { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.ReplicationLinkState> ReplicationState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlServerDatabaseReplicationRole> Role { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerDatabaseReplicationLink FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_01_01;
            public static readonly string V2014_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum SqlServerDatabaseReplicationRole
    {
        Primary = 0,
        Secondary = 1,
        NonReadableSecondary = 2,
        Source = 3,
        Copy = 4,
    }
    public partial class SqlServerDatabaseRestorePoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerDatabaseRestorePoint(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EarliestRestoreOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RestorePointCreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RestorePointLabel { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.RestorePointType> RestorePointType { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerDatabaseRestorePoint FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_01_01;
            public static readonly string V2014_04_01;
            public static readonly string V2015_01_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlServerDevOpsAuditingSetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerDevOpsAuditingSetting(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsManagedIdentityInUse { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.BlobAuditingPolicyState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> StorageAccountSubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerDevOpsAuditingSetting FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlServerDnsAlias : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerDnsAlias(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AzureDnsRecord { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerDnsAlias FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum SqlServerFailoverModeType
    {
        None = 0,
        Manual = 1,
    }
    public partial class SqlServerJob : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerJob(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlServerJobAgent? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlServerJobSchedule Schedule { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerJob FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlServerJobAgent : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerJobAgent(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DatabaseId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Sql.JobAgentIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.JobAgentState> State { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerJobAgent FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlServerJobCredential : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerJobCredential(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlServerJobAgent? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerJobCredential FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlServerJobExecution : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerJobExecution(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreateOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> CurrentAttempts { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CurrentAttemptStartOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> JobExecutionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> JobVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.JobExecutionLifecycle> Lifecycle { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlServerJob? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.JobExecutionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> StepId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> StepName { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.Sql.JobExecutionTarget Target { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerJobExecution FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlServerJobSchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlServerJobSchedule() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Interval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlServerJobScheduleType> ScheduleType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SqlServerJobScheduleType
    {
        Once = 0,
        Recurring = 1,
    }
    public partial class SqlServerJobStep : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerJobStep(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Sql.JobStepAction Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Credential { get { throw null; } set { } }
        public Azure.Provisioning.Sql.JobStepExecutionOptions ExecutionOptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.JobStepOutput Output { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlServerJob? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> StepId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TargetGroup { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerJobStep FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlServerJobTargetGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerJobTargetGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Sql.JobTarget> Members { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlServerJobAgent? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerJobTargetGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlServerKey : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerKey(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAutoRotationEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlServerKeyType> ServerKeyType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Subregion { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerKey FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum SqlServerKeyType
    {
        ServiceManaged = 0,
        AzureKeyVault = 1,
    }
    public enum SqlServerPrincipalType
    {
        User = 0,
        Group = 1,
        Application = 2,
    }
    public partial class SqlServerPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlServerPrivateEndpointConnection() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Sql.ServerPrivateEndpointConnectionProperties Properties { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlServerSecurityAlertPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerSecurityAlertPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<string> DisabledAlerts { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EmailAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SendToEmailAccountAdmins { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SecurityAlertsPolicyState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerSecurityAlertPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum SqlServerSideLinkRole
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class SqlServerSqlVulnerabilityAssessment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerSqlVulnerabilityAssessment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlVulnerabilityAssessmentState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerSqlVulnerabilityAssessment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_01_01;
            public static readonly string V2014_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlServerSqlVulnerabilityAssessmentBaseline : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerSqlVulnerabilityAssessmentBaseline(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsLatestScan { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlServerSqlVulnerabilityAssessment? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<string>>> Results { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerSqlVulnerabilityAssessmentBaseline FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_01_01;
            public static readonly string V2014_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlServerSqlVulnerabilityAssessmentBaselineRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerSqlVulnerabilityAssessmentBaselineRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsLatestScan { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlServerSqlVulnerabilityAssessmentBaseline? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<string>> Results { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerSqlVulnerabilityAssessmentBaselineRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_01_01;
            public static readonly string V2014_04_01;
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlServerTrustGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerTrustGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Sql.ServerTrustGroupServerInfo> GroupMembers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Sql.ServerTrustGroupPropertiesTrustScopesItem> TrustScopes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerTrustGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlServerVirtualNetworkRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerVirtualNetworkRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlServerVirtualNetworkRuleState> State { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualNetworkSubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerVirtualNetworkRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum SqlServerVirtualNetworkRuleState
    {
        Initializing = 0,
        InProgress = 1,
        Ready = 2,
        Failed = 3,
        Deleting = 4,
        Unknown = 5,
    }
    public partial class SqlServerVulnerabilityAssessment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlServerVulnerabilityAssessment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Sql.VulnerabilityAssessmentRecurringScansProperties RecurringScans { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageContainerPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageContainerSasKey { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SqlServerVulnerabilityAssessment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SqlServicePrincipal : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlServicePrincipal() { }
        public Azure.Provisioning.BicepValue<System.Guid> ClientId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SqlServicePrincipalType> PrincipalType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SqlServicePrincipalType
    {
        None = 0,
        SystemAssigned = 1,
    }
    public partial class SqlSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SqlVulnerabilityAssessmentBaselineName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="default")]
        Default = 0,
    }
    public enum SqlVulnerabilityAssessmentState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class SyncAgent : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SyncAgent(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsUpToDate { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastAliveOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlServer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SyncAgentState> State { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SyncDatabaseId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SyncAgent FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum SyncAgentState
    {
        Online = 0,
        Offline = 1,
        NeverConnected = 2,
    }
    public enum SyncConflictResolutionPolicy
    {
        HubWin = 0,
        MemberWin = 1,
    }
    public enum SyncDirection
    {
        Bidirectional = 0,
        OneWayMemberToHub = 1,
        OneWayHubToMember = 2,
    }
    public partial class SyncGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SyncGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> ConflictLoggingRetentionInDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SyncConflictResolutionPolicy> ConflictResolutionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HubDatabasePassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HubDatabaseUserName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Interval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsConflictLoggingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastSyncOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateEndpointName { get { throw null; } }
        public Azure.Provisioning.Sql.SyncGroupSchema Schema { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SyncDatabaseId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SyncGroupState> SyncState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> UsePrivateLinkConnection { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SyncGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class SyncGroupSchema : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SyncGroupSchema() { }
        public Azure.Provisioning.BicepValue<string> MasterSyncMemberName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Sql.SyncGroupSchemaTable> Tables { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SyncGroupSchemaTable : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SyncGroupSchemaTable() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Sql.SyncGroupSchemaTableColumn> Columns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QuotedName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SyncGroupSchemaTableColumn : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SyncGroupSchemaTableColumn() { }
        public Azure.Provisioning.BicepValue<string> DataSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DataType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QuotedName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SyncGroupState
    {
        NotReady = 0,
        Error = 1,
        Warning = 2,
        Progressing = 3,
        Good = 4,
    }
    public partial class SyncMember : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SyncMember(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SyncMemberDbType> DatabaseType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SyncGroup? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateEndpointName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ServerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> SqlServerDatabaseId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SyncAgentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SyncDirection> SyncDirection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SyncMemberAzureDatabaseResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sql.SyncMemberState> SyncState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> UsePrivateLinkConnection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.SyncMember FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public enum SyncMemberDbType
    {
        AzureSqlDatabase = 0,
        SqlServerDatabase = 1,
    }
    public enum SyncMemberState
    {
        SyncInProgress = 0,
        SyncSucceeded = 1,
        SyncFailed = 2,
        DisabledTombstoneCleanup = 3,
        DisabledBackupRestore = 4,
        SyncSucceededWithWarnings = 5,
        SyncCancelling = 6,
        SyncCancelled = 7,
        UnProvisioned = 8,
        Provisioning = 9,
        Provisioned = 10,
        ProvisionFailed = 11,
        DeProvisioning = 12,
        DeProvisioned = 13,
        DeProvisionFailed = 14,
        Reprovisioning = 15,
        ReprovisionFailed = 16,
        UnReprovisioned = 17,
    }
    public enum TransparentDataEncryptionName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="current")]
        Current = 0,
    }
    public enum TransparentDataEncryptionState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum VulnerabilityAssessmentName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="default")]
        Default = 0,
    }
    public enum VulnerabilityAssessmentPolicyBaselineName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="default")]
        Default = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="master")]
        Master = 1,
    }
    public partial class VulnerabilityAssessmentRecurringScansProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VulnerabilityAssessmentRecurringScansProperties() { }
        public Azure.Provisioning.BicepList<string> Emails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EmailSubscriptionAdmins { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkloadClassifier : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WorkloadClassifier(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Context { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EndTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Importance { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Label { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MemberName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.WorkloadGroup? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartTime { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.WorkloadClassifier FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
    public partial class WorkloadGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WorkloadGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Importance { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxResourcePercent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> MaxResourcePercentPerRequest { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinResourcePercent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> MinResourcePercentPerRequest { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sql.SqlDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> QueryExecutionTimeout { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sql.WorkloadGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_11_01;
            public static readonly string V2023_08_01;
        }
    }
}
