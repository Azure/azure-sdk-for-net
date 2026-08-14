namespace Azure.Provisioning.RecoveryServices
{
    public enum BackupStorageVersion
    {
        V1 = 0,
        V2 = 1,
        Unassigned = 2,
    }
    public enum BcdrSecurityLevel
    {
        Poor = 0,
        Fair = 1,
        Good = 2,
        Excellent = 3,
    }
    public partial class CmkKekIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CmkKekIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> UserAssignedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseSystemAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CrossRegionRestore
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum CrossSubscriptionRestoreState
    {
        Enabled = 0,
        Disabled = 1,
        PermanentlyDisabled = 2,
    }
    public partial class DeletedVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeletedVaultProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PurgeOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> VaultDeletionOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VaultId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GranularityLevel
    {
        VaultLevel = 0,
        ProtectedItemLevel = 1,
        ProtectedItemWithParentTag = 2,
    }
    public partial class ImmutabilityConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImmutabilityConfiguration() { }
        public Azure.Provisioning.BicepValue<int> DurationInDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.ImmutabilityType> Type { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImmutabilitySettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImmutabilitySettings() { }
        public Azure.Provisioning.RecoveryServices.ImmutabilityConfiguration Configuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.ImmutabilityState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ImmutabilityState
    {
        Disabled = 0,
        Unlocked = 1,
        Locked = 2,
    }
    public enum ImmutabilityType
    {
        AsPerPolicy = 0,
        TimeBased = 1,
    }
    public enum InfrastructureEncryptionState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum MultiUserAuthorization
    {
        Invalid = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public enum RecoveryServicesAlertsState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class RecoveryServicesAssociatedIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RecoveryServicesAssociatedIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.RecoveryServicesIdentityType> OperationIdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RecoveryServicesAzureMonitorAlertSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RecoveryServicesAzureMonitorAlertSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.RecoveryServicesAlertsState> AlertsForAllFailoverIssues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.RecoveryServicesAlertsState> AlertsForAllJobFailures { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.RecoveryServicesAlertsState> AlertsForAllReplicationIssues { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RecoveryServicesClassicAlertSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RecoveryServicesClassicAlertSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.RecoveryServicesAlertsState> AlertsForCriticalOperations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.RecoveryServicesAlertsState> EmailNotificationsForSiteRecovery { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RecoveryServicesDeletedVault : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal RecoveryServicesDeletedVault() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServices.DeletedVaultProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.RecoveryServices.RecoveryServicesDeletedVault FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_08_01;
            public static readonly string V2026_01_01;
            public static readonly string V2026_02_01;
            public static readonly string V2026_05_01;
        }
    }
    public enum RecoveryServicesEnhancedSecurityState
    {
        Invalid = 0,
        Enabled = 1,
        Disabled = 2,
        AlwaysON = 3,
    }
    public enum RecoveryServicesIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
    }
    public partial class RecoveryServicesPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RecoveryServicesPrivateEndpointConnection() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServices.VaultSubResourceType> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.RecoveryServices.RecoveryServicesPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.RecoveryServicesPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RecoveryServicesPrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Deleting = 1,
        Failed = 2,
        Pending = 3,
    }
    public enum RecoveryServicesPrivateEndpointConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public partial class RecoveryServicesPrivateEndpointConnectionVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RecoveryServicesPrivateEndpointConnectionVaultProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.RecoveryServices.RecoveryServicesPrivateEndpointConnection Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> Type { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RecoveryServicesPrivateLinkResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal RecoveryServicesPrivateLinkResource() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServices.RecoveryServicesVault Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> RequiredMembers { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RequiredZoneNames { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.RecoveryServices.RecoveryServicesPrivateLinkResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01;
            public static readonly string V2025_08_01;
            public static readonly string V2026_01_01;
            public static readonly string V2026_02_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class RecoveryServicesPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RecoveryServicesPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.RecoveryServicesPrivateEndpointConnectionStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RecoveryServicesSecuritySettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RecoveryServicesSecuritySettings() { }
        public Azure.Provisioning.RecoveryServices.ImmutabilitySettings ImmutabilitySettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.MultiUserAuthorization> MultiUserAuthorization { get { throw null; } }
        public Azure.Provisioning.RecoveryServices.RecoveryServicesSoftDeleteSettings SoftDeleteSettings { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServices.SourceScanConfiguration SourceScanConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RecoveryServicesSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RecoveryServicesSku() { }
        public Azure.Provisioning.BicepValue<string> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.RecoveryServicesSkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RecoveryServicesSkuName
    {
        Standard = 0,
        RS0 = 1,
    }
    public partial class RecoveryServicesSoftDeleteSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RecoveryServicesSoftDeleteSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.RecoveryServicesEnhancedSecurityState> EnhancedSecurityState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SoftDeleteRetentionPeriodInDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.RecoveryServicesSoftDeleteState> SoftDeleteState { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RecoveryServicesSoftDeleteState
    {
        Invalid = 0,
        Enabled = 1,
        Disabled = 2,
        AlwaysON = 3,
    }
    public enum RecoveryServicesSourceScanState
    {
        Invalid = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public partial class RecoveryServicesVault : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RecoveryServicesVault(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServices.RecoveryServicesVaultProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServices.RecoveryServicesSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.RecoveryServices.RecoveryServicesVault FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01;
            public static readonly string V2025_08_01;
            public static readonly string V2026_01_01;
            public static readonly string V2026_02_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class RecoveryServicesVaultExtendedInfo : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RecoveryServicesVaultExtendedInfo(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Algorithm { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptionKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptionKeyThumbprint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> IntegrityKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.RecoveryServices.RecoveryServicesVault Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.RecoveryServices.RecoveryServicesVaultExtendedInfo FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01;
            public static readonly string V2025_08_01;
            public static readonly string V2026_01_01;
            public static readonly string V2026_02_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class RecoveryServicesVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RecoveryServicesVaultProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.BackupStorageVersion> BackupStorageVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.BcdrSecurityLevel> BcdrSecurityLevel { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.GranularityLevel> CostManagementGranularityLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.CrossSubscriptionRestoreState> CrossSubscriptionRestoreState { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServices.VaultPropertiesEncryption Encryption { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServices.VaultMonitoringSettings MonitoringSettings { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServices.VaultPropertiesMoveDetails MoveDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.ResourceMoveState> MoveState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServices.RecoveryServicesPrivateEndpointConnectionVaultProperties> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.VaultPrivateEndpointState> PrivateEndpointStateForBackup { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.VaultPrivateEndpointState> PrivateEndpointStateForSiteRecovery { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.VaultPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServices.VaultPropertiesRedundancySettings RedundancySettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ResourceGuardOperationRequests { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.SecureScoreLevel> SecureScore { get { throw null; } }
        public Azure.Provisioning.RecoveryServices.RecoveryServicesSecuritySettings SecuritySettings { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServices.VaultUpgradeDetails UpgradeDetails { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ResourceMoveState
    {
        Unknown = 0,
        InProgress = 1,
        PrepareFailed = 2,
        CommitFailed = 3,
        PrepareTimedout = 4,
        CommitTimedout = 5,
        MoveSucceeded = 6,
        Failure = 7,
        CriticalFailure = 8,
        PartialSuccess = 9,
    }
    public enum SecureScoreLevel
    {
        None = 0,
        Minimum = 1,
        Adequate = 2,
        Maximum = 3,
    }
    public partial class SourceScanConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SourceScanConfiguration() { }
        public Azure.Provisioning.RecoveryServices.RecoveryServicesAssociatedIdentity SourceScanIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.RecoveryServicesSourceScanState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StandardTierStorageRedundancy
    {
        Invalid = 0,
        LocallyRedundant = 1,
        GeoRedundant = 2,
        ZoneRedundant = 3,
    }
    public partial class VaultMonitoringSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VaultMonitoringSettings() { }
        public Azure.Provisioning.RecoveryServices.RecoveryServicesAzureMonitorAlertSettings AzureMonitorAlertSettings { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServices.RecoveryServicesClassicAlertSettings ClassicAlertSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VaultPrivateEndpointState
    {
        None = 0,
        Enabled = 1,
    }
    public partial class VaultPropertiesEncryption : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VaultPropertiesEncryption() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.InfrastructureEncryptionState> InfrastructureEncryption { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServices.CmkKekIdentity KekIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VaultPropertiesMoveDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VaultPropertiesMoveDetails() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CompletedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OperationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetResourceId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VaultPropertiesRedundancySettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VaultPropertiesRedundancySettings() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.CrossRegionRestore> CrossRegionRestore { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.StandardTierStorageRedundancy> StandardTierStorageRedundancy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VaultPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum VaultSubResourceType
    {
        AzureBackup = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AzureBackup_secondary")]
        AzureBackupSecondary = 1,
        AzureSiteRecovery = 2,
    }
    public partial class VaultUpgradeDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VaultUpgradeDetails() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OperationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PreviousResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.VaultUpgradeState> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServices.VaultUpgradeTriggerType> TriggerType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> UpgradedResourceId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VaultUpgradeState
    {
        Unknown = 0,
        InProgress = 1,
        Upgraded = 2,
        Failed = 3,
    }
    public enum VaultUpgradeTriggerType
    {
        UserTriggered = 0,
        ForcedUpgrade = 1,
    }
}
