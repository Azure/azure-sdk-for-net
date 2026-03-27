namespace Azure.Provisioning.Batch
{
    public partial class AutomaticOSUpgradePolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutomaticOSUpgradePolicy() { }
        public Azure.Provisioning.BicepValue<bool> DisableAutomaticRollback { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableAutomaticOSUpgrade { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> OSRollingUpgradeDeferral { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseRollingUpgradePolicy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchAccessRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchAccessRule() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchAccessRuleProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchAccessRuleDirection
    {
        Inbound = 0,
        Outbound = 1,
    }
    public partial class BatchAccessRuleProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchAccessRuleProperties() { }
        public Azure.Provisioning.BicepList<string> AddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchAccessRuleDirection> Direction { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EmailAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> FullyQualifiedDomainNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.NetworkSecurityPerimeter> NetworkSecurityPerimeters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PhoneNumbers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> Subscriptions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchAccount : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BatchAccount(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AccountEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ActiveJobAndJobScheduleQuota { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchAuthenticationMode>> AllowedAuthenticationModes { get { throw null; } }
        public Azure.Provisioning.Batch.BatchAccountAutoStorageConfiguration AutoStorage { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.BicepValue<int>> DedicatedCoreQuota { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchVmFamilyCoreQuota>> DedicatedCoreQuotaPerVmFamily { get { throw null; } }
        public Azure.Provisioning.Batch.BatchAccountEncryptionConfiguration Encryption { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDedicatedCoreQuotaPerVmFamilyEnforced { get { throw null; } }
        public Azure.Provisioning.Batch.BatchKeyVaultReference KeyVaultReference { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.BicepValue<int>> LowPriorityCoreQuota { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchNetworkProfile> NetworkProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeManagementEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchAccountPoolAllocationMode> PoolAllocationMode { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> PoolQuota { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchPrivateEndpointConnection>> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchPublicNetworkAccess>> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Batch.BatchAccount FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_07_01;
            public static readonly string V2025_06_01;
        }
    }
    public partial class BatchAccountAutoScaleSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchAccountAutoScaleSettings() { }
        public Azure.Provisioning.BicepValue<System.TimeSpan> EvaluationInterval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Formula { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchAccountAutoStorageConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchAccountAutoStorageConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchAutoStorageAuthenticationMode> AuthenticationMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastKeySyncedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NodeIdentityResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageAccountId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchAccountDetector : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BatchAccountDetector(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Batch.BatchAccountDetector FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_07_01;
            public static readonly string V2025_06_01;
        }
    }
    public partial class BatchAccountEncryptionConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchAccountEncryptionConfiguration() { }
        public Azure.Provisioning.BicepValue<System.Uri> KeyIdentifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchAccountKeySource> KeySource { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchAccountFixedScaleSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchAccountFixedScaleSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchNodeDeallocationOption> NodeDeallocationOption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> ResizeTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TargetDedicatedNodes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TargetLowPriorityNodes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchAccountKeySource
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.Batch")]
        MicrosoftBatch = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.KeyVault")]
        MicrosoftKeyVault = 1,
    }
    public partial class BatchAccountPool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BatchAccountPool(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchAccountPoolAllocationState> AllocationState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> AllocationStateTransitionOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchApplicationPackageReference> ApplicationPackages { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchAccountPoolAutoScaleRun AutoScaleRun { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> CurrentDedicatedNodes { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> CurrentLowPriorityNodes { get { throw null; } }
        public Azure.Provisioning.Batch.BatchVmConfiguration DeploymentVmConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.InterNodeCommunicationState> InterNodeCommunication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchAccountPoolMetadataItem> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchMountConfiguration> MountConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchNetworkConfiguration NetworkConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchAccountPoolProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProvisioningStateTransitOn { get { throw null; } }
        public Azure.Provisioning.Batch.BatchResizeOperationStatus ResizeOperationStatus { get { throw null; } }
        public Azure.Provisioning.Batch.BatchAccountPoolScaleSettings ScaleSettings { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchAccountPoolStartTask StartTask { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchTaskSchedulingPolicy TaskSchedulingPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TaskSlotsPerNode { get { throw null; } set { } }
        public Azure.Provisioning.Batch.UpgradePolicy UpgradePolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchUserAccount> UserAccounts { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VmSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Batch.BatchAccountPool FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_07_01;
            public static readonly string V2025_06_01;
        }
    }
    public enum BatchAccountPoolAllocationMode
    {
        BatchService = 0,
        UserSubscription = 1,
    }
    public enum BatchAccountPoolAllocationState
    {
        Steady = 0,
        Resizing = 1,
        Stopping = 2,
    }
    public partial class BatchAccountPoolAutoScaleRun : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchAccountPoolAutoScaleRun() { }
        public Azure.Provisioning.BicepValue<Azure.ResponseError> Error { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EvaluationOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Results { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchAccountPoolMetadataItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchAccountPoolMetadataItem() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchAccountPoolProvisioningState
    {
        Succeeded = 0,
        Deleting = 1,
    }
    public partial class BatchAccountPoolScaleSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchAccountPoolScaleSettings() { }
        public Azure.Provisioning.Batch.BatchAccountAutoScaleSettings AutoScale { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchAccountFixedScaleSettings FixedScale { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchAccountPoolStartTask : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchAccountPoolStartTask() { }
        public Azure.Provisioning.BicepValue<string> CommandLine { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchTaskContainerSettings ContainerSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchEnvironmentSetting> EnvironmentSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxTaskRetryCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchResourceFile> ResourceFiles { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchUserIdentity UserIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> WaitForSuccess { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchApplication : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BatchApplication(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowUpdates { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DefaultVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Batch.BatchApplication FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_07_01;
            public static readonly string V2025_06_01;
        }
    }
    public partial class BatchApplicationPackage : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BatchApplicationPackage(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Format { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastActivatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchApplication Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchApplicationPackageState> State { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> StorageUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StorageUriExpireOn { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Batch.BatchApplicationPackage FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_07_01;
            public static readonly string V2025_06_01;
        }
    }
    public partial class BatchApplicationPackageReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchApplicationPackageReference() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchApplicationPackageState
    {
        Pending = 0,
        Active = 1,
    }
    public enum BatchAuthenticationMode
    {
        SharedKey = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AAD")]
        Aad = 1,
        TaskAuthenticationToken = 2,
    }
    public enum BatchAutoStorageAuthenticationMode
    {
        StorageKeys = 0,
        BatchAccountManagedIdentity = 1,
    }
    public enum BatchAutoUserScope
    {
        Task = 0,
        Pool = 1,
    }
    public partial class BatchAutoUserSpecification : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchAutoUserSpecification() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchUserAccountElevationLevel> ElevationLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchAutoUserScope> Scope { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchBlobFileSystemConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchBlobFileSystemConfiguration() { }
        public Azure.Provisioning.BicepValue<string> AccountKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BlobfuseOptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContainerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> IdentityResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RelativeMountPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SasKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchCifsMountConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchCifsMountConfiguration() { }
        public Azure.Provisioning.BicepValue<string> MountOptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RelativeMountPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Source { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchContainerWorkingDirectory
    {
        TaskWorkingDirectory = 0,
        ContainerImageDefault = 1,
    }
    public enum BatchDiffDiskPlacement
    {
        CacheDisk = 0,
    }
    public enum BatchDiskCachingType
    {
        None = 0,
        ReadOnly = 1,
        ReadWrite = 2,
    }
    public partial class BatchDiskCustomerManagedKey : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchDiskCustomerManagedKey() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> IdentityReferenceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RotationToLatestKeyVersionEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchDiskEncryptionConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchDiskEncryptionConfiguration() { }
        public Azure.Provisioning.Batch.BatchDiskCustomerManagedKey CustomerManagedKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchDiskEncryptionTarget> Targets { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchDiskEncryptionTarget
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="OsDisk")]
        OSDisk = 0,
        TemporaryDisk = 1,
    }
    public enum BatchEndpointAccessDefaultAction
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class BatchEndpointAccessProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchEndpointAccessProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchEndpointAccessDefaultAction> DefaultAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchIPRule> IPRules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchEnvironmentSetting : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchEnvironmentSetting() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchFileShareConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchFileShareConfiguration() { }
        public Azure.Provisioning.BicepValue<string> AccountKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> FileUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MountOptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RelativeMountPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchHostEndpointSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchHostEndpointSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> InVmAccessControlProfileReferenceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchHostEndpointSettingsModeType> Mode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchHostEndpointSettingsModeType
    {
        Audit = 0,
        Enforce = 1,
    }
    public partial class BatchImageReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchImageReference() { }
        public Azure.Provisioning.BicepValue<string> CommunityGalleryImageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Offer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SharedGalleryImageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchInboundEndpointProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="TCP")]
        Tcp = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UDP")]
        Udp = 1,
    }
    public partial class BatchInboundNatPool : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchInboundNatPool() { }
        public Azure.Provisioning.BicepValue<int> BackendPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FrontendPortRangeEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FrontendPortRangeStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchNetworkSecurityGroupRule> NetworkSecurityGroupRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchInboundEndpointProtocol> Protocol { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchIPAddressProvisioningType
    {
        BatchManaged = 0,
        UserManaged = 1,
        NoPublicIPAddresses = 2,
    }
    public enum BatchIPFamily
    {
        IPv4 = 0,
        IPv6 = 1,
    }
    public partial class BatchIPRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchIPRule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchIPRuleAction> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchIPRuleAction
    {
        Allow = 0,
    }
    public partial class BatchIPTag : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchIPTag() { }
        public Azure.Provisioning.BicepValue<string> IPTagType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tag { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchIssueType
    {
        Unknown = 0,
        ConfigurationPropagationFailure = 1,
        MissingPerimeterConfiguration = 2,
        MissingIdentityConfiguration = 3,
    }
    public enum BatchJobDefaultOrder
    {
        None = 0,
        CreationTime = 1,
    }
    public partial class BatchKeyVaultReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchKeyVaultReference() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchLinuxUserConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchLinuxUserConfiguration() { }
        public Azure.Provisioning.BicepValue<int> Gid { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SshPrivateKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Uid { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchMountConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchMountConfiguration() { }
        public Azure.Provisioning.Batch.BatchBlobFileSystemConfiguration BlobFileSystemConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchCifsMountConfiguration CifsMountConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchFileShareConfiguration FileShareConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchNfsMountConfiguration NfsMountConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchNetworkConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchNetworkConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.DynamicVNetAssignmentScope> DynamicVNetAssignmentScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableAcceleratedNetworking { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchInboundNatPool> EndpointInboundNatPools { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchPublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchNetworkProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchNetworkProfile() { }
        public Azure.Provisioning.Batch.BatchEndpointAccessProfile AccountAccess { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchEndpointAccessProfile NodeManagementAccess { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchNetworkSecurityGroupRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchNetworkSecurityGroupRule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchNetworkSecurityGroupRuleAccess> Access { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceAddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourcePortRanges { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchNetworkSecurityGroupRuleAccess
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class BatchNfsMountConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchNfsMountConfiguration() { }
        public Azure.Provisioning.BicepValue<string> MountOptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RelativeMountPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Source { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchNodeDeallocationOption
    {
        Requeue = 0,
        Terminate = 1,
        TaskCompletion = 2,
        RetainedData = 3,
    }
    public enum BatchNodeFillType
    {
        Spread = 0,
        Pack = 1,
    }
    public enum BatchNodePlacementPolicyType
    {
        Regional = 0,
        Zonal = 1,
    }
    public partial class BatchOSDisk : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchOSDisk() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchDiskCachingType> Caching { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DiskSizeGB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchDiffDiskPlacement> EphemeralOSDiskPlacement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsWriteAcceleratorEnabled { get { throw null; } set { } }
        public Azure.Provisioning.Batch.ManagedDisk ManagedDisk { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BatchPrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Batch.BatchPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Batch.BatchPrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_07_01;
            public static readonly string V2025_06_01;
        }
    }
    public enum BatchPrivateEndpointConnectionProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Failed = 4,
        Cancelled = 5,
    }
    public partial class BatchPrivateLinkResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BatchPrivateLinkResource(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> RequiredMembers { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RequiredZoneNames { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Batch.BatchPrivateLinkResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_07_01;
            public static readonly string V2025_06_01;
        }
    }
    public partial class BatchPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchPrivateLinkServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchPrivateLinkServiceConnectionStatus
    {
        Approved = 0,
        Pending = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public partial class BatchProvisioningIssue : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchProvisioningIssue() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Batch.BatchProvisioningIssueProperties Properties { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchProvisioningIssueProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchProvisioningIssueProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchIssueType> IssueType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchSeverity> Severity { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchAccessRule> SuggestedAccessRules { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> SuggestedResourceIds { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchProvisioningState
    {
        Invalid = 0,
        Creating = 1,
        Deleting = 2,
        Succeeded = 3,
        Failed = 4,
        Cancelled = 5,
    }
    public partial class BatchProxyAgentSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchProxyAgentSettings() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchHostEndpointSettings Imds { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchHostEndpointSettings WireServer { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchPublicIPAddressConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchPublicIPAddressConfiguration() { }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> IPAddressIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchIPFamily> IPFamilies { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchIPTag> IPTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchIPAddressProvisioningType> Provision { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
        SecuredByPerimeter = 2,
    }
    public partial class BatchResizeError : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchResizeError() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchResizeError> Details { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchResizeOperationStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchResizeOperationStatus() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchResizeError> Errors { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchNodeDeallocationOption> NodeDeallocationOption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> ResizeTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TargetDedicatedNodes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TargetLowPriorityNodes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchResourceAssociation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchResourceAssociation() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.ResourceAssociationAccessMode> AccessMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchResourceFile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchResourceFile() { }
        public Azure.Provisioning.BicepValue<string> AutoBlobContainerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> BlobContainerUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BlobPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FilePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> HttpUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> IdentityResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchSecurityEncryptionType
    {
        NonPersistedTPM = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="VMGuestStateOnly")]
        VmGuestStateOnly = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="DiskWithVMGuestState")]
        DiskWithVmGuestState = 2,
    }
    public partial class BatchSecurityProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchSecurityProfile() { }
        public Azure.Provisioning.BicepValue<bool> EncryptionAtHost { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchProxyAgentSettings ProxyAgentSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchSecurityType> SecurityType { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchUefiSettings UefiSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchSecurityType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="trustedLaunch")]
        TrustedLaunch = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="confidentialVM")]
        ConfidentialVm = 1,
    }
    public enum BatchSeverity
    {
        Warning = 0,
        Error = 1,
    }
    public enum BatchStorageAccountType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_LRS")]
        StandardLrs = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Premium_LRS")]
        PremiumLrs = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="StandardSSD_LRS")]
        StandardSsdLrs = 2,
    }
    public partial class BatchTaskContainerSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchTaskContainerSettings() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.ContainerHostBatchBindMountEntry> ContainerHostBatchBindMounts { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContainerRunOptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ImageName { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchVmContainerRegistry Registry { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchContainerWorkingDirectory> WorkingDirectory { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchTaskSchedulingPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchTaskSchedulingPolicy() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchJobDefaultOrder> JobDefaultOrder { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchNodeFillType> NodeFillType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchUefiSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchUefiSettings() { }
        public Azure.Provisioning.BicepValue<bool> IsSecureBootEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVTpmEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchUserAccount : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchUserAccount() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchUserAccountElevationLevel> ElevationLevel { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchLinuxUserConfiguration LinuxUserConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchWindowsLoginMode> WindowsUserLoginMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchUserAccountElevationLevel
    {
        NonAdmin = 0,
        Admin = 1,
    }
    public partial class BatchUserIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchUserIdentity() { }
        public Azure.Provisioning.Batch.BatchAutoUserSpecification AutoUser { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchVmConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchVmConfiguration() { }
        public Azure.Provisioning.Batch.BatchVmContainerConfiguration ContainerConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchVmDataDisk> DataDisks { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchDiskEncryptionConfiguration DiskEncryptionConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchVmExtension> Extensions { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchImageReference ImageReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LicenseType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeAgentSkuId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchNodePlacementPolicyType> NodePlacementPolicy { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchOSDisk OSDisk { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ServiceArtifactReferenceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> WindowsIsAutomaticUpdateEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchVmContainerConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchVmContainerConfiguration() { }
        public Azure.Provisioning.BicepList<string> ContainerImageNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchVmContainerRegistry> ContainerRegistries { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchVmContainerType> ContainerType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchVmContainerRegistry : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchVmContainerRegistry() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> IdentityResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RegistryServer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchVmContainerType
    {
        DockerCompatible = 0,
        CriCompatible = 1,
    }
    public partial class BatchVmDataDisk : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchVmDataDisk() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchDiskCachingType> Caching { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DiskSizeInGB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Lun { get { throw null; } set { } }
        public Azure.Provisioning.Batch.ManagedDisk ManagedDisk { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchVmExtension : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchVmExtension() { }
        public Azure.Provisioning.BicepValue<bool> AutoUpgradeMinorVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableAutomaticUpgrade { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExtensionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ProtectedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ProvisionAfterExtensions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Settings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TypeHandlerVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchVmFamilyCoreQuota : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchVmFamilyCoreQuota() { }
        public Azure.Provisioning.BicepValue<int> CoreQuota { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BatchWindowsLoginMode
    {
        Batch = 0,
        Interactive = 1,
    }
    public partial class ContainerHostBatchBindMountEntry : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerHostBatchBindMountEntry() { }
        public Azure.Provisioning.BicepValue<bool> IsReadOnly { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.ContainerHostDataPath> Source { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerHostDataPath
    {
        Shared = 0,
        Startup = 1,
        VfsMounts = 2,
        Task = 3,
        JobPrep = 4,
        Applications = 5,
    }
    public enum DynamicVNetAssignmentScope
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="none")]
        None = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="job")]
        Job = 1,
    }
    public enum InterNodeCommunicationState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ManagedDisk : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedDisk() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.Provisioning.Batch.VmDiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchStorageAccountType> StorageAccountType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkSecurityPerimeter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkSecurityPerimeter() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PerimeterGuid { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkSecurityPerimeterConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkSecurityPerimeterConfiguration(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Batch.BatchAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Batch.NetworkSecurityPerimeterConfigurationProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Batch.NetworkSecurityPerimeterConfiguration FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_07_01;
            public static readonly string V2025_06_01;
        }
    }
    public partial class NetworkSecurityPerimeterConfigurationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkSecurityPerimeterConfigurationProperties() { }
        public Azure.Provisioning.Batch.NetworkSecurityPerimeter NetworkSecurityPerimeter { get { throw null; } set { } }
        public Azure.Provisioning.Batch.NetworkSecurityProfile Profile { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchProvisioningIssue> ProvisioningIssues { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.NetworkSecurityPerimeterConfigurationProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Batch.BatchResourceAssociation ResourceAssociation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NetworkSecurityPerimeterConfigurationProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Updating = 2,
        Deleting = 3,
        Accepted = 4,
        Failed = 5,
        Canceled = 6,
    }
    public partial class NetworkSecurityProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkSecurityProfile() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Batch.BatchAccessRule> AccessRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> AccessRulesVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DiagnosticSettingsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EnabledLogCategories { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ResourceAssociationAccessMode
    {
        Enforced = 0,
        Learning = 1,
        Audit = 2,
    }
    public partial class RollingUpgradePolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RollingUpgradePolicy() { }
        public Azure.Provisioning.BicepValue<bool> EnableCrossZoneUpgrade { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxBatchInstancePercent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxUnhealthyInstancePercent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxUnhealthyUpgradedInstancePercent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PauseTimeBetweenBatches { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> PrioritizeUnhealthyInstances { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RollbackFailedInstancesOnPolicyBreach { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum UpgradeMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="automatic")]
        Automatic = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="manual")]
        Manual = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="rolling")]
        Rolling = 2,
    }
    public partial class UpgradePolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UpgradePolicy() { }
        public Azure.Provisioning.Batch.AutomaticOSUpgradePolicy AutomaticOSUpgradePolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.UpgradeMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.Batch.RollingUpgradePolicy RollingUpgradePolicy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VmDiskSecurityProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VmDiskSecurityProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Batch.BatchSecurityEncryptionType> SecurityEncryptionType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
