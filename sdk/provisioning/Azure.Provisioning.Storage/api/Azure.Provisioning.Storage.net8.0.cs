namespace Azure.Provisioning.Storage
{
    public partial class AccountImmutabilityPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AccountImmutabilityPolicy() { }
        public Azure.Provisioning.BicepValue<bool> AllowProtectedAppendWrites { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ImmutabilityPeriodSinceCreationInDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.AccountImmutabilityPolicyState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AccountImmutabilityPolicyState
    {
        Unlocked = 0,
        Locked = 1,
        Disabled = 2,
    }
    public enum ActiveDirectoryAccountType
    {
        User = 0,
        Computer = 1,
    }
    public enum AllowedCopyScope
    {
        PrivateLink = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AAD")]
        Aad = 1,
    }
    public partial class BlobContainer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BlobContainer(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DefaultEncryptionScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> DeletedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> EnableNfsV3AllSquash { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableNfsV3RootSquash { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> HasImmutabilityPolicy { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> HasLegalHold { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Storage.BlobContainerImmutabilityPolicy ImmutabilityPolicy { get { throw null; } }
        public Azure.Provisioning.Storage.ImmutableStorageWithVersioning ImmutableStorageWithVersioning { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDeleted { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageLeaseDurationType> LeaseDuration { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageLeaseState> LeaseState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageLeaseStatus> LeaseStatus { get { throw null; } }
        public Azure.Provisioning.Storage.LegalHoldProperties LegalHold { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Storage.BlobService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> PreventEncryptionScopeOverride { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StoragePublicAccessType> PublicAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RemainingRetentionDays { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Storage.BlobContainer FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_05_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_01_01;
        }
    }
    public partial class BlobContainerImmutabilityPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BlobContainerImmutabilityPolicy() { }
        public Azure.Provisioning.BicepValue<bool> AllowProtectedAppendWrites { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> AllowProtectedAppendWritesAll { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ImmutabilityPeriodSinceCreationInDays { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.ImmutabilityPolicyState> State { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.UpdateHistoryEntry> UpdateHistory { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BlobInventoryPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BlobInventoryPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Storage.StorageAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Storage.BlobInventoryPolicySchema PolicySchema { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Storage.BlobInventoryPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_01_01;
            public static readonly string V2016_05_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_01_01;
        }
    }
    public partial class BlobInventoryPolicyDefinition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BlobInventoryPolicyDefinition() { }
        public Azure.Provisioning.Storage.BlobInventoryPolicyFilter Filters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.BlobInventoryPolicyFormat> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.BlobInventoryPolicyObjectType> ObjectType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.BlobInventoryPolicySchedule> Schedule { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SchemaFields { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BlobInventoryPolicyFilter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BlobInventoryPolicyFilter() { }
        public Azure.Provisioning.BicepList<string> BlobTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CreationTimeLastNDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ExcludePrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IncludeBlobVersions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IncludeDeleted { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> IncludePrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IncludeSnapshots { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BlobInventoryPolicyFormat
    {
        Csv = 0,
        Parquet = 1,
    }
    public enum BlobInventoryPolicyObjectType
    {
        Blob = 0,
        Container = 1,
    }
    public partial class BlobInventoryPolicyRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BlobInventoryPolicyRule() { }
        public Azure.Provisioning.Storage.BlobInventoryPolicyDefinition Definition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BlobInventoryPolicySchedule
    {
        Daily = 0,
        Weekly = 1,
    }
    public partial class BlobInventoryPolicySchema : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BlobInventoryPolicySchema() { }
        public Azure.Provisioning.BicepValue<string> Destination { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.BlobInventoryPolicyRule> Rules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.BlobInventoryRuleType> RuleType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BlobInventoryRuleType
    {
        Inventory = 0,
    }
    public partial class BlobRestoreContent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BlobRestoreContent() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.BlobRestoreRange> BlobRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TimeToRestore { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BlobRestoreProgressStatus
    {
        InProgress = 0,
        Complete = 1,
        Failed = 2,
    }
    public partial class BlobRestoreRange : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BlobRestoreRange() { }
        public Azure.Provisioning.BicepValue<string> EndRange { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartRange { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BlobRestoreStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BlobRestoreStatus() { }
        public Azure.Provisioning.BicepValue<string> FailureReason { get { throw null; } }
        public Azure.Provisioning.Storage.BlobRestoreContent Parameters { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RestoreId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.BlobRestoreProgressStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BlobService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BlobService(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Storage.BlobServiceChangeFeed ChangeFeed { get { throw null; } set { } }
        public Azure.Provisioning.Storage.DeleteRetentionPolicy ContainerDeleteRetentionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.StorageCorsRule> CorsRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DefaultServiceVersion { get { throw null; } set { } }
        public Azure.Provisioning.Storage.DeleteRetentionPolicy DeleteRetentionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAutomaticSnapshotPolicyEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVersioningEnabled { get { throw null; } set { } }
        public Azure.Provisioning.Storage.LastAccessTimeTrackingPolicy LastAccessTimeTrackingPolicy { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Storage.RestorePolicy RestorePolicy { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageSku Sku { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Storage.BlobService FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_05_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_01_01;
        }
    }
    public partial class BlobServiceChangeFeed : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BlobServiceChangeFeed() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionInDays { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CorsRuleAllowedMethod
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="DELETE")]
        Delete = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GET")]
        Get = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HEAD")]
        Head = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MERGE")]
        Merge = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="POST")]
        Post = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="OPTIONS")]
        Options = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PUT")]
        Put = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PATCH")]
        Patch = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="CONNECT")]
        Connect = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TRACE")]
        Trace = 9,
    }
    public partial class DateAfterCreation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DateAfterCreation() { }
        public Azure.Provisioning.BicepValue<float> DaysAfterCreationGreaterThan { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> DaysAfterLastTierChangeGreaterThan { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DateAfterModification : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DateAfterModification() { }
        public Azure.Provisioning.BicepValue<float> DaysAfterCreationGreaterThan { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> DaysAfterLastAccessTimeGreaterThan { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> DaysAfterLastTierChangeGreaterThan { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> DaysAfterModificationGreaterThan { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DefaultSharePermission
    {
        None = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="StorageFileDataSmbShareReader")]
        Reader = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="StorageFileDataSmbShareContributor")]
        Contributor = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="StorageFileDataSmbShareElevatedContributor")]
        ElevatedContributor = 3,
    }
    public partial class DeleteRetentionPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeleteRetentionPolicy() { }
        public Azure.Provisioning.BicepValue<bool> AllowPermanentDelete { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Days { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DirectoryServiceOption
    {
        None = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AADDS")]
        Aadds = 1,
        AD = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AADKERB")]
        Aadkerb = 3,
    }
    public partial class EncryptionScope : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EncryptionScope(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Storage.EncryptionScopeKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RequireInfrastructureEncryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.EncryptionScopeSource> Source { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.EncryptionScopeState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Storage.EncryptionScope FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_06_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_01_01;
        }
    }
    public partial class EncryptionScopeKeyVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EncryptionScopeKeyVaultProperties() { }
        public Azure.Provisioning.BicepValue<string> CurrentVersionedKeyIdentifier { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastKeyRotationTimestamp { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EncryptionScopeSource
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.Storage")]
        Storage = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.KeyVault")]
        KeyVault = 1,
    }
    public enum EncryptionScopeState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum ExecutionIntervalUnit
    {
        Days = 0,
    }
    public partial class ExecutionTarget : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExecutionTarget() { }
        public Azure.Provisioning.BicepList<string> ExcludePrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Prefix { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExecutionTrigger : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExecutionTrigger() { }
        public Azure.Provisioning.Storage.ExecutionTriggerParameters Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.ExecutionTriggerType> TriggerType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExecutionTriggerParameters : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExecutionTriggerParameters() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Interval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.ExecutionIntervalUnit> IntervalUnit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartFrom { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ExecutionTriggerType
    {
        RunOnce = 0,
        OnSchedule = 1,
    }
    public enum ExpirationAction
    {
        Log = 0,
        Block = 1,
    }
    public partial class FileService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FileService(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.StorageCorsRule> CorsRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Storage.StorageAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Storage.SmbSetting ProtocolSmbSetting { get { throw null; } set { } }
        public Azure.Provisioning.Storage.DeleteRetentionPolicy ShareDeleteRetentionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageSku Sku { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Storage.FileService FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_05_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_01_01;
        }
    }
    public partial class FileShare : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FileShare(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.FileShareAccessTier> AccessTier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> AccessTierChangeOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> AccessTierStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> DeletedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.FileShareEnabledProtocol> EnabledProtocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Storage.FileSharePropertiesFileSharePaidBursting FileSharePaidBursting { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> IncludedBurstIops { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDeleted { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageLeaseDurationType> LeaseDuration { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageLeaseState> LeaseState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageLeaseStatus> LeaseStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> MaxBurstCreditsForIops { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NextAllowedProvisionedBandwidthDowngradeOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NextAllowedProvisionedIopsDowngradeOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NextAllowedQuotaDowngradeOn { get { throw null; } }
        public Azure.Provisioning.Storage.FileService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ProvisionedBandwidthMibps { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ProvisionedIops { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RemainingRetentionDays { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.RootSquashType> RootSquash { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ShareQuota { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> ShareUsageBytes { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.StorageSignedIdentifier> SignedIdentifiers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> SnapshotOn { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Storage.FileShare FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_05_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_01_01;
        }
    }
    public enum FileShareAccessTier
    {
        TransactionOptimized = 0,
        Hot = 1,
        Cool = 2,
        Premium = 3,
    }
    public enum FileShareEnabledProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="SMB")]
        Smb = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="NFS")]
        Nfs = 1,
    }
    public partial class FileSharePropertiesFileSharePaidBursting : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FileSharePropertiesFileSharePaidBursting() { }
        public Azure.Provisioning.BicepValue<bool> PaidBurstingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PaidBurstingMaxBandwidthMibps { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PaidBurstingMaxIops { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FilesIdentityBasedAuthentication : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FilesIdentityBasedAuthentication() { }
        public Azure.Provisioning.Storage.StorageActiveDirectoryProperties ActiveDirectoryProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.DefaultSharePermission> DefaultSharePermission { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.DirectoryServiceOption> DirectoryServiceOptions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GeoReplicationStatistics : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GeoReplicationStatistics() { }
        public Azure.Provisioning.BicepValue<bool> CanFailover { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> CanPlannedFailover { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastSyncOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.PostFailoverRedundancy> PostFailoverRedundancy { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.PostPlannedFailoverRedundancy> PostPlannedFailoverRedundancy { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.GeoReplicationStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GeoReplicationStatus
    {
        Live = 0,
        Bootstrap = 1,
        Unavailable = 2,
    }
    public partial class ImmutabilityPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ImmutabilityPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowProtectedAppendWrites { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowProtectedAppendWritesAll { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ImmutabilityPeriodSinceCreationInDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Storage.BlobContainer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.ImmutabilityPolicyState> State { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Storage.ImmutabilityPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_05_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_01_01;
        }
    }
    public enum ImmutabilityPolicyState
    {
        Locked = 0,
        Unlocked = 1,
    }
    public enum ImmutabilityPolicyUpdateType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="put")]
        Put = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="lock")]
        Lock = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="extend")]
        Extend = 2,
    }
    public partial class ImmutableStorageAccount : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImmutableStorageAccount() { }
        public Azure.Provisioning.Storage.AccountImmutabilityPolicy ImmutabilityPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImmutableStorageWithVersioning : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImmutableStorageWithVersioning() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.ImmutableStorageWithVersioningMigrationState> MigrationState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TimeStamp { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ImmutableStorageWithVersioningMigrationState
    {
        InProgress = 0,
        Completed = 1,
    }
    public enum LargeFileSharesState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class LastAccessTimeTrackingPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LastAccessTimeTrackingPolicy() { }
        public Azure.Provisioning.BicepList<string> BlobType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.LastAccessTimeTrackingPolicyName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TrackingGranularityInDays { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LastAccessTimeTrackingPolicyName
    {
        AccessTimeTracking = 0,
    }
    public partial class LegalHoldProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LegalHoldProperties() { }
        public Azure.Provisioning.BicepValue<bool> HasLegalHold { get { throw null; } }
        public Azure.Provisioning.Storage.ProtectedAppendWritesHistory ProtectedAppendWritesHistory { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.LegalHoldTag> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LegalHoldTag : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LegalHoldTag() { }
        public Azure.Provisioning.BicepValue<string> ObjectIdentifier { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Tag { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Timestamp { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Upn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LocalUserKeys : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LocalUserKeys() { }
        public Azure.Provisioning.BicepValue<string> SharedKey { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.StorageSshPublicKey> SshAuthorizedKeys { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagementPolicyAction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagementPolicyAction() { }
        public Azure.Provisioning.Storage.ManagementPolicyBaseBlob BaseBlob { get { throw null; } set { } }
        public Azure.Provisioning.Storage.ManagementPolicySnapShot Snapshot { get { throw null; } set { } }
        public Azure.Provisioning.Storage.ManagementPolicyVersion Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagementPolicyBaseBlob : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagementPolicyBaseBlob() { }
        public Azure.Provisioning.Storage.DateAfterModification Delete { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableAutoTierToHotFromCool { get { throw null; } set { } }
        public Azure.Provisioning.Storage.DateAfterModification TierToArchive { get { throw null; } set { } }
        public Azure.Provisioning.Storage.DateAfterModification TierToCold { get { throw null; } set { } }
        public Azure.Provisioning.Storage.DateAfterModification TierToCool { get { throw null; } set { } }
        public Azure.Provisioning.Storage.DateAfterModification TierToHot { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagementPolicyDefinition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagementPolicyDefinition() { }
        public Azure.Provisioning.Storage.ManagementPolicyAction Actions { get { throw null; } set { } }
        public Azure.Provisioning.Storage.ManagementPolicyFilter Filters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagementPolicyFilter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagementPolicyFilter() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.ManagementPolicyTagFilter> BlobIndexMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> BlobTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PrefixMatch { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagementPolicyRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagementPolicyRule() { }
        public Azure.Provisioning.Storage.ManagementPolicyDefinition Definition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.ManagementPolicyRuleType> RuleType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagementPolicyRuleType
    {
        Lifecycle = 0,
    }
    public partial class ManagementPolicySnapShot : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagementPolicySnapShot() { }
        public Azure.Provisioning.Storage.DateAfterCreation Delete { get { throw null; } set { } }
        public Azure.Provisioning.Storage.DateAfterCreation TierToArchive { get { throw null; } set { } }
        public Azure.Provisioning.Storage.DateAfterCreation TierToCold { get { throw null; } set { } }
        public Azure.Provisioning.Storage.DateAfterCreation TierToCool { get { throw null; } set { } }
        public Azure.Provisioning.Storage.DateAfterCreation TierToHot { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagementPolicyTagFilter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagementPolicyTagFilter() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Operator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagementPolicyVersion : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagementPolicyVersion() { }
        public Azure.Provisioning.Storage.DateAfterCreation Delete { get { throw null; } set { } }
        public Azure.Provisioning.Storage.DateAfterCreation TierToArchive { get { throw null; } set { } }
        public Azure.Provisioning.Storage.DateAfterCreation TierToCold { get { throw null; } set { } }
        public Azure.Provisioning.Storage.DateAfterCreation TierToCool { get { throw null; } set { } }
        public Azure.Provisioning.Storage.DateAfterCreation TierToHot { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ObjectReplicationPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ObjectReplicationPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DestinationAccount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EnabledOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsMetricsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Storage.StorageAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicyId { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.ObjectReplicationPolicyRule> Rules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceAccount { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Storage.ObjectReplicationPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_01_01;
            public static readonly string V2016_05_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_01_01;
        }
    }
    public partial class ObjectReplicationPolicyFilter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ObjectReplicationPolicyFilter() { }
        public Azure.Provisioning.BicepValue<string> MinCreationTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PrefixMatch { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ObjectReplicationPolicyRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ObjectReplicationPolicyRule() { }
        public Azure.Provisioning.BicepValue<string> DestinationContainer { get { throw null; } set { } }
        public Azure.Provisioning.Storage.ObjectReplicationPolicyFilter Filters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuleId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceContainer { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PostFailoverRedundancy
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_LRS")]
        StandardLrs = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_ZRS")]
        StandardZrs = 1,
    }
    public enum PostPlannedFailoverRedundancy
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_GRS")]
        StandardGrs = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_GZRS")]
        StandardGzrs = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_RAGRS")]
        StandardRagrs = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_RAGZRS")]
        StandardRagzrs = 3,
    }
    public partial class ProtectedAppendWritesHistory : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ProtectedAppendWritesHistory() { }
        public Azure.Provisioning.BicepValue<bool> AllowProtectedAppendWritesAll { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Timestamp { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class QueueService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public QueueService(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.StorageCorsRule> CorsRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Storage.StorageAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Storage.QueueService FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_05_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_01_01;
        }
    }
    public partial class RestorePolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RestorePolicy() { }
        public Azure.Provisioning.BicepValue<int> Days { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastEnabledOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> MinRestoreOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RootSquashType
    {
        NoRootSquash = 0,
        RootSquash = 1,
        AllSquash = 2,
    }
    public partial class SmbSetting : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SmbSetting() { }
        public Azure.Provisioning.BicepValue<string> AuthenticationMethods { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ChannelEncryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsMultiChannelEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KerberosTicketEncryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Versions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageAccount : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StorageAccount(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageAccountAccessTier> AccessTier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowBlobPublicAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowCrossTenantReplication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.AllowedCopyScope> AllowedCopyScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowSharedKeyAccess { get { throw null; } set { } }
        public Azure.Provisioning.Storage.FilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get { throw null; } set { } }
        public Azure.Provisioning.Storage.BlobRestoreStatus BlobRestoreStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.Storage.StorageCustomDomain CustomDomain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageDnsEndpointType> DnsEndpointType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableHttpsTrafficOnly { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageAccountEncryption Encryption { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.Storage.GeoReplicationStatistics GeoReplicationStats { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.Storage.ImmutableStorageAccount ImmutableStorageWithVersioning { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAccountMigrationInProgress { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDefaultToOAuthAuthentication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsExtendedGroupEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsFailoverInProgress { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsHnsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsLocalUserEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsNfsV3Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSftpEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSkuConversionBlocked { get { throw null; } }
        public Azure.Provisioning.Storage.StorageAccountKeyCreationTime KeyCreationTime { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> KeyExpirationPeriodInDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.LargeFileSharesState> LargeFileSharesState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastGeoFailoverOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageMinimumTlsVersion> MinimumTlsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageAccountNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageAccountEndpoints PrimaryEndpoints { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> PrimaryLocation { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.StoragePrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StoragePublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageRoutingPreference RoutingPreference { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageAccountSasPolicy SasPolicy { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageAccountEndpoints SecondaryEndpoints { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> SecondaryLocation { get { throw null; } }
        public Azure.Provisioning.Storage.StorageSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageAccountStatus> StatusOfPrimary { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageAccountStatus> StatusOfSecondary { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageAccountProvisioningState> StorageAccountProvisioningState { get { throw null; } }
        public Azure.Provisioning.Storage.StorageAccountSkuConversionStatus StorageAccountSkuConversionStatus { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.Storage.StorageBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string? bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.Storage.StorageBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Storage.StorageAccount FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.StorageAccountKey> GetKeys() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_01_01;
            public static readonly string V2016_05_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_01_01;
        }
    }
    public enum StorageAccountAccessTier
    {
        Hot = 0,
        Cool = 1,
        Premium = 2,
        Cold = 3,
    }
    public partial class StorageAccountEncryption : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageAccountEncryption() { }
        public Azure.Provisioning.Storage.StorageAccountEncryptionIdentity EncryptionIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageAccountKeySource> KeySource { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageAccountKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RequireInfrastructureEncryption { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageAccountEncryptionServices Services { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageAccountEncryptionIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageAccountEncryptionIdentity() { }
        public Azure.Provisioning.BicepValue<string> EncryptionFederatedIdentityClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptionUserAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageAccountEncryptionServices : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageAccountEncryptionServices() { }
        public Azure.Provisioning.Storage.StorageEncryptionService Blob { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageEncryptionService File { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageEncryptionService Queue { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageEncryptionService Table { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageAccountEndpoints : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageAccountEndpoints() { }
        public Azure.Provisioning.BicepValue<System.Uri> BlobUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> DfsUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> FileUri { get { throw null; } }
        public Azure.Provisioning.Storage.StorageAccountInternetEndpoints InternetEndpoints { get { throw null; } }
        public Azure.Provisioning.Storage.StorageAccountMicrosoftEndpoints MicrosoftEndpoints { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> QueueUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> TableUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> WebUri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageAccountInternetEndpoints : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageAccountInternetEndpoints() { }
        public Azure.Provisioning.BicepValue<System.Uri> BlobUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> DfsUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> FileUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> WebUri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageAccountIPRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageAccountIPRule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageAccountNetworkRuleAction> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IPAddressOrRange { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageAccountKey : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageAccountKey() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageAccountKeyPermission> Permissions { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageAccountKeyCreationTime : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageAccountKeyCreationTime() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Key1 { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Key2 { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StorageAccountKeyPermission
    {
        Read = 0,
        Full = 1,
    }
    public enum StorageAccountKeySource
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.Storage")]
        Storage = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.Keyvault")]
        KeyVault = 1,
    }
    public partial class StorageAccountKeyVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageAccountKeyVaultProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CurrentVersionedKeyExpirationTimestamp { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CurrentVersionedKeyIdentifier { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyVaultUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastKeyRotationTimestamp { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageAccountLocalUser : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StorageAccountLocalUser(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<int> ExtendedGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> GroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> HasSharedKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> HasSshKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> HasSshPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HomeDirectory { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAclAuthorizationAllowed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsNfsV3Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.StoragePermissionScope> PermissionScopes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sid { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.StorageSshPublicKey> SshAuthorizedKeys { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> UserId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Storage.StorageAccountLocalUser FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public Azure.Provisioning.Storage.LocalUserKeys GetKeys() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_01_01;
            public static readonly string V2016_05_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_01_01;
        }
    }
    public partial class StorageAccountManagementPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StorageAccountManagementPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.Storage.StorageAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.ManagementPolicyRule> Rules { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Storage.StorageAccountManagementPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_01_01;
            public static readonly string V2016_05_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_01_01;
        }
    }
    public partial class StorageAccountMicrosoftEndpoints : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageAccountMicrosoftEndpoints() { }
        public Azure.Provisioning.BicepValue<System.Uri> BlobUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> DfsUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> FileUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> QueueUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> TableUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> WebUri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StorageAccountNetworkRuleAction
    {
        Allow = 0,
    }
    public partial class StorageAccountNetworkRuleSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageAccountNetworkRuleSet() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageNetworkBypass> Bypass { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageNetworkDefaultAction> DefaultAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.StorageAccountIPRule> IPRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.StorageAccountResourceAccessRule> ResourceAccessRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.StorageAccountVirtualNetworkRule> VirtualNetworkRules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StorageAccountNetworkRuleState
    {
        Provisioning = 0,
        Deprovisioning = 1,
        Succeeded = 2,
        Failed = 3,
        NetworkSourceDeleted = 4,
    }
    public enum StorageAccountProvisioningState
    {
        Creating = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ResolvingDNS")]
        ResolvingDns = 1,
        Succeeded = 2,
    }
    public partial class StorageAccountResourceAccessRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageAccountResourceAccessRule() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageAccountSasPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageAccountSasPolicy() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.ExpirationAction> ExpirationAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SasExpirationPeriod { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StorageAccountSkuConversionState
    {
        InProgress = 0,
        Succeeded = 1,
        Failed = 2,
    }
    public partial class StorageAccountSkuConversionStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageAccountSkuConversionStatus() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageAccountSkuConversionState> SkuConversionStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageSkuName> TargetSkuName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StorageAccountStatus
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="available")]
        Available = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="unavailable")]
        Unavailable = 1,
    }
    public partial class StorageAccountVirtualNetworkRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageAccountVirtualNetworkRule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageAccountNetworkRuleAction> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageAccountNetworkRuleState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualNetworkResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageActiveDirectoryProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageActiveDirectoryProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.ActiveDirectoryAccountType> AccountType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureStorageSid { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> DomainGuid { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DomainName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DomainSid { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ForestName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NetBiosDomainName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SamAccountName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageBuiltInRole : System.IEquatable<Azure.Provisioning.Storage.StorageBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.Storage.StorageBuiltInRole ClassicStorageAccountContributor { get { throw null; } }
        public static Azure.Provisioning.Storage.StorageBuiltInRole ClassicStorageAccountKeyOperatorServiceRole { get { throw null; } }
        public static Azure.Provisioning.Storage.StorageBuiltInRole StorageAccountBackupContributor { get { throw null; } }
        public static Azure.Provisioning.Storage.StorageBuiltInRole StorageAccountContributor { get { throw null; } }
        public static Azure.Provisioning.Storage.StorageBuiltInRole StorageAccountKeyOperatorServiceRole { get { throw null; } }
        public static Azure.Provisioning.Storage.StorageBuiltInRole StorageBlobDataContributor { get { throw null; } }
        public static Azure.Provisioning.Storage.StorageBuiltInRole StorageBlobDataOwner { get { throw null; } }
        public static Azure.Provisioning.Storage.StorageBuiltInRole StorageBlobDataReader { get { throw null; } }
        public static Azure.Provisioning.Storage.StorageBuiltInRole StorageBlobDelegator { get { throw null; } }
        public static Azure.Provisioning.Storage.StorageBuiltInRole StorageFileDataPrivilegedContributor { get { throw null; } }
        public static Azure.Provisioning.Storage.StorageBuiltInRole StorageFileDataPrivilegedReader { get { throw null; } }
        public static Azure.Provisioning.Storage.StorageBuiltInRole StorageFileDataSmbShareContributor { get { throw null; } }
        public static Azure.Provisioning.Storage.StorageBuiltInRole StorageFileDataSmbShareElevatedContributor { get { throw null; } }
        public static Azure.Provisioning.Storage.StorageBuiltInRole StorageFileDataSmbShareReader { get { throw null; } }
        public static Azure.Provisioning.Storage.StorageBuiltInRole StorageQueueDataContributor { get { throw null; } }
        public static Azure.Provisioning.Storage.StorageBuiltInRole StorageQueueDataMessageProcessor { get { throw null; } }
        public static Azure.Provisioning.Storage.StorageBuiltInRole StorageQueueDataMessageSender { get { throw null; } }
        public static Azure.Provisioning.Storage.StorageBuiltInRole StorageQueueDataReader { get { throw null; } }
        public static Azure.Provisioning.Storage.StorageBuiltInRole StorageTableDataContributor { get { throw null; } }
        public static Azure.Provisioning.Storage.StorageBuiltInRole StorageTableDataReader { get { throw null; } }
        public bool Equals(Azure.Provisioning.Storage.StorageBuiltInRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string GetBuiltInRoleName(Azure.Provisioning.Storage.StorageBuiltInRole value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.Storage.StorageBuiltInRole left, Azure.Provisioning.Storage.StorageBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.Storage.StorageBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.Storage.StorageBuiltInRole left, Azure.Provisioning.Storage.StorageBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageCorsRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageCorsRule() { }
        public Azure.Provisioning.BicepList<string> AllowedHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.CorsRuleAllowedMethod> AllowedMethods { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AllowedOrigins { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ExposedHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxAgeInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageCustomDomain : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageCustomDomain() { }
        public Azure.Provisioning.BicepValue<bool> IsUseSubDomainNameEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StorageDnsEndpointType
    {
        Standard = 0,
        AzureDnsZone = 1,
    }
    public enum StorageEncryptionKeyType
    {
        Service = 0,
        Account = 1,
    }
    public partial class StorageEncryptionService : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageEncryptionService() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageEncryptionKeyType> KeyType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastEnabledOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StorageKind
    {
        Storage = 0,
        StorageV2 = 1,
        BlobStorage = 2,
        FileStorage = 3,
        BlockBlobStorage = 4,
    }
    public enum StorageLeaseDurationType
    {
        Infinite = 0,
        Fixed = 1,
    }
    public enum StorageLeaseState
    {
        Available = 0,
        Leased = 1,
        Expired = 2,
        Breaking = 3,
        Broken = 4,
    }
    public enum StorageLeaseStatus
    {
        Locked = 0,
        Unlocked = 1,
    }
    public enum StorageMinimumTlsVersion
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS1_0")]
        Tls1_0 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS1_1")]
        Tls1_1 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS1_2")]
        Tls1_2 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TLS1_3")]
        Tls1_3 = 3,
    }
    public enum StorageNetworkBypass
    {
        None = 0,
        Logging = 1,
        Metrics = 2,
        AzureServices = 3,
    }
    public enum StorageNetworkDefaultAction
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class StoragePermissionScope : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StoragePermissionScope() { }
        public Azure.Provisioning.BicepValue<string> Permissions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Service { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StoragePrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StoragePrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Storage.StoragePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StoragePrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Storage.StoragePrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_01_01;
            public static readonly string V2016_05_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_01_01;
        }
    }
    public partial class StoragePrivateEndpointConnectionData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StoragePrivateEndpointConnectionData() { }
        public Azure.Provisioning.Storage.StoragePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StoragePrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StoragePrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public enum StoragePrivateEndpointServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
    }
    public partial class StoragePrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StoragePrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StoragePrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StorageProvisioningState
    {
        Creating = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ResolvingDNS")]
        ResolvingDns = 1,
        Succeeded = 2,
        ValidateSubscriptionQuotaBegin = 3,
        ValidateSubscriptionQuotaEnd = 4,
        Deleting = 5,
        Canceled = 6,
        Failed = 7,
    }
    public enum StoragePublicAccessType
    {
        None = 0,
        Container = 1,
        Blob = 2,
    }
    public enum StoragePublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
        SecuredByPerimeter = 2,
    }
    public partial class StorageQueue : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StorageQueue(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> ApproximateMessageCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Storage.QueueService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Storage.StorageQueue FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_05_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_01_01;
        }
    }
    public enum StorageRoutingChoice
    {
        MicrosoftRouting = 0,
        InternetRouting = 1,
    }
    public partial class StorageRoutingPreference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageRoutingPreference() { }
        public Azure.Provisioning.BicepValue<bool> IsInternetEndpointsPublished { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsMicrosoftEndpointsPublished { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageRoutingChoice> RoutingChoice { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageServiceAccessPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageServiceAccessPolicy() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Permission { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageSignedIdentifier : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageSignedIdentifier() { }
        public Azure.Provisioning.Storage.StorageServiceAccessPolicy AccessPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageSkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageSkuTier> Tier { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StorageSkuName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_LRS")]
        StandardLrs = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_GRS")]
        StandardGrs = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_RAGRS")]
        StandardRagrs = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_ZRS")]
        StandardZrs = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Premium_LRS")]
        PremiumLrs = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Premium_ZRS")]
        PremiumZrs = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_GZRS")]
        StandardGzrs = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_RAGZRS")]
        StandardRagzrs = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="StandardV2_LRS")]
        StandardV2Lrs = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="StandardV2_GRS")]
        StandardV2Grs = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="StandardV2_ZRS")]
        StandardV2Zrs = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="StandardV2_GZRS")]
        StandardV2Gzrs = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PremiumV2_LRS")]
        PremiumV2Lrs = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PremiumV2_ZRS")]
        PremiumV2Zrs = 13,
    }
    public enum StorageSkuTier
    {
        Standard = 0,
        Premium = 1,
    }
    public partial class StorageSshPublicKey : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageSshPublicKey() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageTable : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StorageTable(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Storage.TableService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.StorageTableSignedIdentifier> SignedIdentifiers { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Storage.StorageTable FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_05_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_01_01;
        }
    }
    public partial class StorageTableAccessPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageTableAccessPolicy() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Permission { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageTableSignedIdentifier : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageTableSignedIdentifier() { }
        public Azure.Provisioning.Storage.StorageTableAccessPolicy AccessPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageTaskAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StorageTaskAssignment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageTaskAssignmentProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Storage.StorageTaskAssignment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_09_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_01_01;
        }
    }
    public partial class StorageTaskAssignmentExecutionContext : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageTaskAssignmentExecutionContext() { }
        public Azure.Provisioning.Storage.ExecutionTarget Target { get { throw null; } set { } }
        public Azure.Provisioning.Storage.ExecutionTrigger Trigger { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageTaskAssignmentProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageTaskAssignmentProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageTaskAssignmentExecutionContext ExecutionContext { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ReportPrefix { get { throw null; } set { } }
        public Azure.Provisioning.Storage.StorageTaskReportProperties RunStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageTaskAssignmentProvisioningState> StorageTaskAssignmentProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TaskId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StorageTaskAssignmentProvisioningState
    {
        ValidateSubscriptionQuotaBegin = 0,
        ValidateSubscriptionQuotaEnd = 1,
        Accepted = 2,
        Creating = 3,
        Succeeded = 4,
        Deleting = 5,
        Canceled = 6,
        Failed = 7,
    }
    public partial class StorageTaskReportProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageTaskReportProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> FinishedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ObjectFailedCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ObjectsOperatedOnCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ObjectsSucceededCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ObjectsTargetedCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageTaskRunResult> RunResult { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.StorageTaskRunStatus> RunStatusEnum { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RunStatusError { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageAccountId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SummaryReportPath { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TaskAssignmentId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TaskId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TaskVersion { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StorageTaskRunResult
    {
        Succeeded = 0,
        Failed = 1,
    }
    public enum StorageTaskRunStatus
    {
        InProgress = 0,
        Finished = 1,
    }
    public partial class TableService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TableService(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Storage.StorageCorsRule> CorsRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Storage.StorageAccount? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Storage.TableService FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2016_05_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_10_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_11_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_09_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_01_01;
        }
    }
    public partial class UpdateHistoryEntry : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UpdateHistoryEntry() { }
        public Azure.Provisioning.BicepValue<bool> AllowProtectedAppendWrites { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> AllowProtectedAppendWritesAll { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ImmutabilityPeriodSinceCreationInDays { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ObjectIdentifier { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Timestamp { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Storage.ImmutabilityPolicyUpdateType> UpdateType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Upn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
}
