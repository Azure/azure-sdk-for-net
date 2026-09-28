namespace Azure.Provisioning.ImageBuilder
{
    public partial class DistributeVersioner : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DistributeVersioner() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DistributeVersionerLatest : Azure.Provisioning.ImageBuilder.DistributeVersioner
    {
        public DistributeVersionerLatest() { }
        public Azure.Provisioning.BicepValue<int> Major { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DistributeVersionerSource : Azure.Provisioning.ImageBuilder.DistributeVersioner
    {
        public DistributeVersionerSource() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageBuilderDataDisk : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageBuilderDataDisk() { }
        public Azure.Provisioning.BicepValue<int> SizeGB { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ImageBuilderIdentityType
    {
        UserAssigned = 0,
        None = 1,
    }
    public enum ImageBuilderOnBuildError
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="cleanup")]
        Cleanup = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="abort")]
        Abort = 1,
    }
    public partial class ImageBuilderProvisioningError : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageBuilderProvisioningError() { }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ImageBuilder.ImageBuilderProvisioningErrorCode> ProvisioningErrorCode { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ImageBuilderProvisioningErrorCode
    {
        BadSourceType = 0,
        BadPIRSource = 1,
        BadManagedImageSource = 2,
        BadSharedImageVersionSource = 3,
        BadCustomizerType = 4,
        UnsupportedCustomizerType = 5,
        NoCustomizerScript = 6,
        BadValidatorType = 7,
        UnsupportedValidatorType = 8,
        NoValidatorScript = 9,
        BadDistributeType = 10,
        BadSharedImageDistribute = 11,
        BadStagingResourceGroup = 12,
        ServerError = 13,
        Other = 14,
    }
    public enum ImageBuilderProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Succeeded = 2,
        Failed = 3,
        Deleting = 4,
        Canceled = 5,
    }
    public partial class ImageBuilderVirtualNetworkConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageBuilderVirtualNetworkConfig() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ContainerInstanceSubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProxyVmSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ImageTemplate(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ImageBuilder.ImageBuilderDataDisk> AdditionalDataDisks { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ImageBuilder.ImageTemplateAutoRunState> AutoRunState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> BuildTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ImageBuilder.ImageTemplateCustomizer> Customize { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ImageBuilder.ImageTemplateDistributor> Distribute { get { throw null; } set { } }
        public Azure.Provisioning.ImageBuilder.ImageTemplateErrorHandling ErrorHandling { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExactStagingResourceGroup { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.ImageBuilder.ImageTemplateIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.ImageBuilder.ImageTemplateLastRunStatus LastRunStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ManagedResourceTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ImageBuilder.ImageTemplateOptimizeConfig Optimize { get { throw null; } set { } }
        public Azure.Provisioning.ImageBuilder.ImageBuilderProvisioningError ProvisioningError { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ImageBuilder.ImageBuilderProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.ImageBuilder.ImageTemplateSource Source { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StagingResourceGroup { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.ImageBuilder.ImageTemplateValidationConfig Validation { get { throw null; } set { } }
        public Azure.Provisioning.ImageBuilder.ImageTemplateVmProfile VmProfile { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ImageBuilder.ImageTemplate FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_01;
        }
    }
    public enum ImageTemplateAutoRunState
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Enabled")]
        AutoRunEnabled = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Disabled")]
        AutoRunDisabled = 1,
    }
    public partial class ImageTemplateCustomizer : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageTemplateCustomizer() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateDistributor : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageTemplateDistributor() { }
        public Azure.Provisioning.BicepDictionary<string> ArtifactTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RunOutputName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateErrorHandling : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageTemplateErrorHandling() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ImageBuilder.ImageBuilderOnBuildError> OnCustomizerError { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ImageBuilder.ImageBuilderOnBuildError> OnValidationError { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateFileCustomizer : Azure.Provisioning.ImageBuilder.ImageTemplateCustomizer
    {
        public ImageTemplateFileCustomizer() { }
        public Azure.Provisioning.BicepValue<string> Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sha256Checksum { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateFileValidator : Azure.Provisioning.ImageBuilder.ImageTemplateInVMValidator
    {
        public ImageTemplateFileValidator() { }
        public Azure.Provisioning.BicepValue<string> Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sha256Checksum { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageTemplateIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ImageBuilder.ImageBuilderIdentityType> Type { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.UserAssignedIdentityDetails> UserAssignedIdentities { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateInVMValidator : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageTemplateInVMValidator() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateLastRunStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageTemplateLastRunStatus() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ImageBuilder.ImageTemplateRunState> RunState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ImageBuilder.ImageTemplateRunSubState> RunSubState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateManagedImageDistributor : Azure.Provisioning.ImageBuilder.ImageTemplateDistributor
    {
        public ImageTemplateManagedImageDistributor() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ImageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateManagedImageSource : Azure.Provisioning.ImageBuilder.ImageTemplateSource
    {
        public ImageTemplateManagedImageSource() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ImageId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateOptimizeConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageTemplateOptimizeConfig() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ImageBuilder.ImageTemplateVMBootOptimizationState> VmBootState { get { throw null; } set { } }
        public Azure.Provisioning.ImageBuilder.ImageTemplateWorkloadOptimization Workload { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplatePlatformImageSource : Azure.Provisioning.ImageBuilder.ImageTemplateSource
    {
        public ImageTemplatePlatformImageSource() { }
        public Azure.Provisioning.BicepValue<string> ExactVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Offer { get { throw null; } set { } }
        public Azure.Provisioning.ImageBuilder.PlatformImagePurchasePlan PlanInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplatePowerShellCustomizer : Azure.Provisioning.ImageBuilder.ImageTemplateCustomizer
    {
        public ImageTemplatePowerShellCustomizer() { }
        public Azure.Provisioning.BicepList<string> Inline { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRunAsSystem { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRunElevated { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sha256Checksum { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<int> ValidExitCodes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplatePowerShellValidator : Azure.Provisioning.ImageBuilder.ImageTemplateInVMValidator
    {
        public ImageTemplatePowerShellValidator() { }
        public Azure.Provisioning.BicepList<string> Inline { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRunAsSystem { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRunElevated { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sha256Checksum { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<int> ValidExitCodes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ImageTemplateReplicationMode
    {
        Full = 0,
        Shallow = 1,
    }
    public partial class ImageTemplateRestartCustomizer : Azure.Provisioning.ImageBuilder.ImageTemplateCustomizer
    {
        public ImageTemplateRestartCustomizer() { }
        public Azure.Provisioning.BicepValue<string> RestartCheckCommand { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RestartCommand { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RestartTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateRunOutput : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal ImageTemplateRunOutput() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ArtifactId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ArtifactUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ImageBuilder.ImageTemplate Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ImageBuilder.ImageBuilderProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ImageBuilder.ImageTemplateRunOutput FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_01;
        }
    }
    public enum ImageTemplateRunState
    {
        Running = 0,
        Canceling = 1,
        Succeeded = 2,
        PartiallySucceeded = 3,
        Failed = 4,
        Canceled = 5,
    }
    public enum ImageTemplateRunSubState
    {
        Queued = 0,
        Building = 1,
        Customizing = 2,
        Optimizing = 3,
        Validating = 4,
        Distributing = 5,
    }
    public partial class ImageTemplateSharedImageDistributor : Azure.Provisioning.ImageBuilder.ImageTemplateDistributor
    {
        public ImageTemplateSharedImageDistributor() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> GalleryImageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsExcludedFromLatest { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ImageBuilder.ImageTemplateReplicationMode> ReplicationMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ReplicationRegions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ImageBuilder.SharedImageStorageAccountType> StorageAccountType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ImageBuilder.ImageTemplateTargetRegion> TargetRegions { get { throw null; } set { } }
        public Azure.Provisioning.ImageBuilder.DistributeVersioner Versioning { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateSharedImageVersionSource : Azure.Provisioning.ImageBuilder.ImageTemplateSource
    {
        public ImageTemplateSharedImageVersionSource() { }
        public Azure.Provisioning.BicepValue<string> ExactVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ImageVersionId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateShellCustomizer : Azure.Provisioning.ImageBuilder.ImageTemplateCustomizer
    {
        public ImageTemplateShellCustomizer() { }
        public Azure.Provisioning.BicepList<string> Inline { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sha256Checksum { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateShellValidator : Azure.Provisioning.ImageBuilder.ImageTemplateInVMValidator
    {
        public ImageTemplateShellValidator() { }
        public Azure.Provisioning.BicepList<string> Inline { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sha256Checksum { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageTemplateSource() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateTargetRegion : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageTemplateTargetRegion() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReplicaCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ImageBuilder.SharedImageStorageAccountType> StorageAccountType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateTrigger : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ImageTemplateTrigger(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ImageBuilder.ImageTemplate Parent { get { throw null; } set { } }
        public Azure.Provisioning.ImageBuilder.TriggerProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ImageBuilder.ImageTemplateTrigger FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_01;
        }
    }
    public partial class ImageTemplateTriggerStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageTemplateTriggerStatus() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RecordedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateValidationConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageTemplateValidationConfig() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ImageBuilder.ImageTemplateInVMValidator> InVMValidations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSourceValidationOnly { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ShouldContinueDistributeOnFailure { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateVhdDistributor : Azure.Provisioning.ImageBuilder.ImageTemplateDistributor
    {
        public ImageTemplateVhdDistributor() { }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ImageTemplateVMBootOptimizationState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ImageTemplateVmProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageTemplateVmProfile() { }
        public Azure.Provisioning.BicepValue<int> OSDiskSizeGB { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> UserAssignedIdentities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VmSize { get { throw null; } set { } }
        public Azure.Provisioning.ImageBuilder.ImageBuilderVirtualNetworkConfig VnetConfig { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateWindowsUpdateCustomizer : Azure.Provisioning.ImageBuilder.ImageTemplateCustomizer
    {
        public ImageTemplateWindowsUpdateCustomizer() { }
        public Azure.Provisioning.BicepList<string> Filters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SearchCriteria { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> UpdateLimit { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageTemplateWorkloadOptimization : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageTemplateWorkloadOptimization() { }
        public Azure.Provisioning.BicepValue<string> ScriptUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sha256Checksum { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ImageBuilder.ImageTemplateWorkloadOptimizationState> State { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ImageTemplateWorkloadOptimizationState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class PlatformImagePurchasePlan : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PlatformImagePurchasePlan() { }
        public Azure.Provisioning.BicepValue<string> PlanName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PlanProduct { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PlanPublisher { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SharedImageStorageAccountType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_LRS")]
        StandardLRS = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_ZRS")]
        StandardZRS = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Premium_LRS")]
        PremiumLRS = 2,
    }
    public partial class SourceImageTriggerProperties : Azure.Provisioning.ImageBuilder.TriggerProperties
    {
        public SourceImageTriggerProperties() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TriggerProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TriggerProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ImageBuilder.ImageBuilderProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.ImageBuilder.ImageTemplateTriggerStatus Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
}
