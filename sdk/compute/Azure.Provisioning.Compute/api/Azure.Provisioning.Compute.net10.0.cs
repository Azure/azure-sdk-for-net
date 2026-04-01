namespace Azure.Provisioning.Compute
{
    public partial class AdditionalCapabilities : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AdditionalCapabilities() { }
        public Azure.Provisioning.BicepValue<bool> EnableFips1403Encryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> HibernationEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UltraSsdEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AdditionalReplicaSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AdditionalReplicaSet() { }
        public Azure.Provisioning.BicepValue<int> RegionalReplicaCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ImageStorageAccountType> StorageAccountType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AdditionalUnattendContent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AdditionalUnattendContent() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ComponentName> ComponentName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Content { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.PassName> PassName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.SettingName> SettingName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AggregatedReplicationState
    {
        Unknown = 0,
        InProgress = 1,
        Completed = 2,
        Failed = 3,
    }
    public partial class AllInstancesDown : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AllInstancesDown() { }
        public Azure.Provisioning.BicepValue<bool> AutomaticallyApprove { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ArchitectureType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="x64")]
        X64 = 0,
        Arm64 = 1,
    }
    public partial class AutomaticOSUpgradePolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutomaticOSUpgradePolicy() { }
        public Azure.Provisioning.BicepValue<bool> DisableAutomaticRollback { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableAutomaticOSUpgrade { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> OSRollingUpgradeDeferral { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseRollingUpgradePolicy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutomaticRepairsPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutomaticRepairsPolicy() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GracePeriod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.RepairAction> RepairAction { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutomaticZoneRebalancingPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutomaticZoneRebalancingPolicy() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.VmssRebalanceBehavior> RebalanceBehavior { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.VmssRebalanceStrategy> RebalanceStrategy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AvailabilityPolicyDiskDelay
    {
        None = 0,
        AutomaticReattach = 1,
    }
    public partial class AvailabilitySet : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AvailabilitySet(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PlatformFaultDomainCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PlatformUpdateDomainCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ScheduledEventsPolicy ScheduledEventsPolicy { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ComputeSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.InstanceViewStatus> Statuses { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> VirtualMachines { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSetMigrationInfo VirtualMachineScaleSetMigrationInfo { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.AvailabilitySet FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_04_01;
        }
    }
    public partial class AvailablePatchSummary : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AvailablePatchSummary() { }
        public Azure.Provisioning.BicepValue<string> AssessmentActivityId { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> CriticalAndSecurityPatchCount { get { throw null; } }
        public Azure.Provisioning.Compute.ComputeApiError Error { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> OtherPatchCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> RebootPending { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.PatchOperationStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BootDiagnostics : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BootDiagnostics() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> StorageUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BootDiagnosticsInstanceView : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BootDiagnosticsInstanceView() { }
        public Azure.Provisioning.BicepValue<System.Uri> ConsoleScreenshotBlobUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> SerialConsoleLogBlobUri { get { throw null; } }
        public Azure.Provisioning.Compute.InstanceViewStatus Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CachingType
    {
        None = 0,
        ReadOnly = 1,
        ReadWrite = 2,
    }
    public partial class CapacityReservation : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CapacityReservation(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Compute.CapacityReservationInstanceView InstanceView { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Compute.CapacityReservationGroup? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PlatformFaultDomainCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProvisioningOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ReservationId { get { throw null; } }
        public Azure.Provisioning.Compute.ScheduleProfile ScheduleProfile { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ComputeSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TimeCreated { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> VirtualMachinesAssociated { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.CapacityReservation FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_04_01;
        }
    }
    public partial class CapacityReservationGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CapacityReservationGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> CapacityReservations { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Compute.CapacityReservationGroupInstanceView InstanceView { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.CapacityReservationType> ReservationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> SharingSubscriptionIds { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> VirtualMachinesAssociated { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.CapacityReservationGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_04_01;
        }
    }
    public partial class CapacityReservationGroupInstanceView : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CapacityReservationGroupInstanceView() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.CapacityReservationInstanceViewWithName> CapacityReservations { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> SharedSubscriptionIds { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CapacityReservationInstanceView : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CapacityReservationInstanceView() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.InstanceViewStatus> Statuses { get { throw null; } }
        public Azure.Provisioning.Compute.CapacityReservationUtilization UtilizationInfo { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CapacityReservationInstanceViewWithName : Azure.Provisioning.Compute.CapacityReservationInstanceView
    {
        public CapacityReservationInstanceViewWithName() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CapacityReservationType
    {
        Targeted = 0,
        Block = 1,
    }
    public partial class CapacityReservationUtilization : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CapacityReservationUtilization() { }
        public Azure.Provisioning.BicepValue<int> CurrentCapacity { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> VirtualMachinesAllocated { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CommunityGalleryInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CommunityGalleryInfo() { }
        public Azure.Provisioning.BicepValue<bool> CommunityGalleryEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Eula { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublicNamePrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PublicNames { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PublisherContact { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublisherUriString { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ComponentName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft-Windows-Shell-Setup")]
        MicrosoftWindowsShellSetup = 0,
    }
    public enum ComputeAllocationStrategy
    {
        LowestPrice = 0,
        CapacityOptimized = 1,
        Prioritized = 2,
    }
    public partial class ComputeApiError : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ComputeApiError() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.ComputeApiErrorBase> Details { get { throw null; } }
        public Azure.Provisioning.Compute.InnerError Innererror { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Target { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ComputeApiErrorBase : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ComputeApiErrorBase() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Target { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ComputeDeleteOption
    {
        Delete = 0,
        Detach = 1,
    }
    public enum ComputeEncryptionType
    {
        EncryptionAtRestWithPlatformKey = 0,
        EncryptionAtRestWithCustomerKey = 1,
        EncryptionAtRestWithPlatformAndCustomerKeys = 2,
    }
    public partial class ComputeGallery : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ComputeGallery(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> IdentifierUniqueName { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSoftDeleteEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.GalleryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Compute.SharingProfile SharingProfile { get { throw null; } set { } }
        public Azure.Provisioning.Compute.SharingStatus SharingStatus { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.ComputeGallery FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_03_03;
        }
    }
    public enum ComputeGalleryEndpointAccess
    {
        Allow = 0,
        Deny = 1,
    }
    public enum ComputeGalleryEndpointType
    {
        WireServer = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IMDS")]
        Imds = 1,
    }
    public partial class ComputeGalleryPlatformAttribute : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ComputeGalleryPlatformAttribute() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ComputeGalleryValidationStatus
    {
        Unknown = 0,
        Failed = 1,
        Succeeded = 2,
    }
    public enum ComputeNetworkInterfaceAuxiliaryMode
    {
        None = 0,
        AcceleratedConnections = 1,
        Floating = 2,
    }
    public enum ComputeNetworkInterfaceAuxiliarySku
    {
        None = 0,
        A1 = 1,
        A2 = 2,
        A4 = 3,
        A8 = 4,
    }
    public partial class ComputePlan : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ComputePlan() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Product { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PromotionCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ComputePrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ComputePrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Compute.ComputePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Compute.DiskAccess? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ComputePrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.ComputePrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_01_02;
        }
    }
    public enum ComputePrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public enum ComputePrivateEndpointServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
    }
    public partial class ComputePrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ComputePrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ComputePrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ComputePublicIPAddressSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ComputePublicIPAddressSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ComputePublicIPAddressSkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ComputePublicIPAddressSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ComputePublicIPAddressSkuName
    {
        Basic = 0,
        Standard = 1,
    }
    public enum ComputePublicIPAddressSkuTier
    {
        Regional = 0,
        Global = 1,
    }
    public partial class ComputeScheduledEventsProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ComputeScheduledEventsProfile() { }
        public Azure.Provisioning.Compute.OSImageNotificationProfile OSImageNotificationProfile { get { throw null; } set { } }
        public Azure.Provisioning.Compute.TerminateNotificationProfile TerminateNotificationProfile { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ComputeSecurityPostureReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ComputeSecurityPostureReference() { }
        public Azure.Provisioning.BicepList<string> ExcludeExtensionNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsOverridable { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ComputeSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ComputeSku() { }
        public Azure.Provisioning.BicepValue<long> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ComputeSkuProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ComputeSkuProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ComputeAllocationStrategy> AllocationStrategy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.ComputeSkuProfileVmSize> VmSizes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ComputeSkuProfileVmSize : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ComputeSkuProfileVmSize() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Rank { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ComputeSnapshot : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ComputeSnapshot(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<float> CompletionPercent { get { throw null; } set { } }
        public Azure.Provisioning.Compute.CopyCompletionError CopyCompletionError { get { throw null; } set { } }
        public Azure.Provisioning.Compute.DiskCreationData CreationData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DataAccessAuthMode> DataAccessAuthMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DiskAccessId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> DiskSizeBytes { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> DiskSizeGB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiskState> DiskState { get { throw null; } }
        public Azure.Provisioning.Compute.DiskEncryption Encryption { get { throw null; } set { } }
        public Azure.Provisioning.Compute.EncryptionSettingsGroup EncryptionSettingsGroup { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.HyperVGeneration> HyperVGeneration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> Incremental { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IncrementalSnapshotFamilyId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.NetworkAccessPolicy> NetworkAccessPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.SupportedOperatingSystemType> OSType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiskPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.Compute.DiskPurchasePlan PurchasePlan { get { throw null; } set { } }
        public Azure.Provisioning.Compute.DiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Provisioning.Compute.SnapshotSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.SnapshotAccessState> SnapshotAccessState { get { throw null; } }
        public Azure.Provisioning.Compute.SupportedCapabilities SupportedCapabilities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SupportsHibernation { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TimeCreated { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UniqueId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.ComputeSnapshot FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_01_02;
        }
    }
    public enum ComputeStatusLevelType
    {
        Info = 0,
        Warning = 1,
        Error = 2,
    }
    public partial class ComputeSubResourceDataWithColocationStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ComputeSubResourceDataWithColocationStatus() { }
        public Azure.Provisioning.Compute.InstanceViewStatus ColocationStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ConfidentialVmEncryptionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="EncryptedVMGuestStateOnlyWithPmk")]
        EncryptedVmGuestStateOnlyWithPmk = 0,
        EncryptedWithPmk = 1,
        EncryptedWithCmk = 2,
        NonPersistedTPM = 3,
    }
    public enum ConsistencyModeType
    {
        CrashConsistent = 0,
        FileSystemConsistent = 1,
        ApplicationConsistent = 2,
    }
    public partial class CopyCompletionError : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CopyCompletionError() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.CopyCompletionErrorReason> ErrorCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ErrorMessage { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CopyCompletionErrorReason
    {
        CopySourceNotFound = 0,
    }
    public enum DataAccessAuthMode
    {
        AzureActiveDirectory = 0,
        None = 1,
    }
    public partial class DataDiskImageEncryption : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataDiskImageEncryption() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Lun { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DedicatedHost : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DedicatedHost(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AutoReplaceOnFailure { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Compute.DedicatedHostInstanceView InstanceView { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DedicatedHostLicenseType> LicenseType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Compute.DedicatedHostGroup? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PlatformFaultDomain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ProvisioningOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Compute.ComputeSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TimeCreated { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> VirtualMachines { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.DedicatedHost FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_04_01;
        }
    }
    public partial class DedicatedHostAllocatableVm : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DedicatedHostAllocatableVm() { }
        public Azure.Provisioning.BicepValue<double> Count { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VmSize { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DedicatedHostGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DedicatedHostGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> DedicatedHosts { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PlatformFaultDomainCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SupportAutomaticPlacement { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UltraSsdEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.DedicatedHostGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_04_01;
        }
    }
    public partial class DedicatedHostInstanceView : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DedicatedHostInstanceView() { }
        public Azure.Provisioning.BicepValue<string> AssetId { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.DedicatedHostAllocatableVm> AvailableCapacityAllocatableVms { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.InstanceViewStatus> Statuses { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DedicatedHostInstanceViewWithName : Azure.Provisioning.Compute.DedicatedHostInstanceView
    {
        public DedicatedHostInstanceViewWithName() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DedicatedHostLicenseType
    {
        None = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Windows_Server_Hybrid")]
        WindowsServerHybrid = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Windows_Server_Perpetual")]
        WindowsServerPerpetual = 2,
    }
    public partial class DefaultVirtualMachineScaleSetInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DefaultVirtualMachineScaleSetInfo() { }
        public Azure.Provisioning.BicepValue<bool> ConstrainedMaximumCapacity { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DefaultVirtualMachineScaleSetId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DiffDiskOption
    {
        Local = 0,
    }
    public enum DiffDiskPlacement
    {
        CacheDisk = 0,
        ResourceDisk = 1,
        NvmeDisk = 2,
    }
    public partial class DiffDiskSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiffDiskSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiffDiskOption> Option { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiffDiskPlacement> Placement { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DiskAccess : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DiskAccess(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.ComputePrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TimeCreated { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.DiskAccess FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_01_02;
        }
    }
    public enum DiskControllerType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="SCSI")]
        Scsi = 0,
        NVMe = 1,
    }
    public enum DiskCreateOption
    {
        Empty = 0,
        Attach = 1,
        FromImage = 2,
        Import = 3,
        Copy = 4,
        Restore = 5,
        Upload = 6,
        CopyStart = 7,
        ImportSecure = 8,
        UploadPreparedSecure = 9,
        CopyFromSanSnapshot = 10,
    }
    public enum DiskCreateOptionType
    {
        FromImage = 0,
        Empty = 1,
        Attach = 2,
        Copy = 3,
        Restore = 4,
    }
    public partial class DiskCreationData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiskCreationData() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiskCreateOption> CreateOption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ElasticSanResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ImageDiskReference GalleryImageReference { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ImageDiskReference ImageReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> InstantAccessDurationMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPerformancePlusEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> LogicalSectorSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ProvisionedBandwidthCopyOption> ProvisionedBandwidthCopySpeed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> SecurityDataUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> SecurityMetadataUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceUniqueId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> SourceUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageAccountId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> UploadSizeBytes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DiskDeleteOptionType
    {
        Delete = 0,
        Detach = 1,
    }
    public enum DiskDetachOptionType
    {
        ForceDetach = 0,
    }
    public partial class DiskEncryption : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiskEncryption() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ComputeEncryptionType> EncryptionType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DiskEncryptionSet : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DiskEncryptionSet(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Compute.KeyForDiskEncryptionSet ActiveKey { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ComputeApiError AutoKeyRotationError { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiskEncryptionSetType> EncryptionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FederatedClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastKeyRotationTimestamp { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.KeyForDiskEncryptionSet> PreviousKeys { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> RotationToLatestKeyVersionEnabled { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.DiskEncryptionSet FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_01_02;
        }
    }
    public partial class DiskEncryptionSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiskEncryptionSettings() { }
        public Azure.Provisioning.Compute.KeyVaultSecretReference DiskEncryptionKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.Compute.KeyVaultKeyReference KeyEncryptionKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DiskEncryptionSetType
    {
        EncryptionAtRestWithCustomerKey = 0,
        EncryptionAtRestWithPlatformAndCustomerKeys = 1,
        ConfidentialVmEncryptedWithCustomerKey = 2,
    }
    public partial class DiskImage : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DiskImage(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.HyperVGeneration> HyperVGeneration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceVirtualMachineId { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ImageStorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.DiskImage FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_04_01;
        }
    }
    public partial class DiskInstanceView : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiskInstanceView() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.DiskEncryptionSettings> EncryptionSettings { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.InstanceViewStatus> Statuses { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DiskPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class DiskPurchasePlan : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiskPurchasePlan() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Product { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PromotionCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DiskRestorePointAttributes : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiskRestorePointAttributes() { }
        public Azure.Provisioning.Compute.RestorePointEncryption Encryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceDiskRestorePointId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DiskRestorePointInstanceView : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiskRestorePointInstanceView() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.Compute.DiskRestorePointReplicationStatus ReplicationStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.SnapshotAccessState> SnapshotAccessState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DiskRestorePointReplicationStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiskRestorePointReplicationStatus() { }
        public Azure.Provisioning.BicepValue<int> CompletionPercent { get { throw null; } }
        public Azure.Provisioning.Compute.InstanceViewStatus Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DiskSecurityProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiskSecurityProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SecureVmDiskEncryptionSetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiskSecurityType> SecurityType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DiskSecurityType
    {
        TrustedLaunch = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ConfidentialVM_VMGuestStateOnlyEncryptedWithPlatformKey")]
        ConfidentialVmGuestStateOnlyEncryptedWithPlatformKey = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ConfidentialVM_DiskEncryptedWithPlatformKey")]
        ConfidentialVmDiskEncryptedWithPlatformKey = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ConfidentialVM_DiskEncryptedWithCustomerKey")]
        ConfidentialVmDiskEncryptedWithCustomerKey = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ConfidentialVM_NonPersistedTPM")]
        ConfidentialVmNonPersistedTPM = 4,
    }
    public partial class DiskSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiskSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiskStorageAccountType> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tier { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DiskState
    {
        Unattached = 0,
        Attached = 1,
        Reserved = 2,
        Frozen = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ActiveSAS")]
        ActiveSas = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ActiveSASFrozen")]
        ActiveSasFrozen = 5,
        ReadyToUpload = 6,
        ActiveUpload = 7,
    }
    public enum DiskStorageAccountType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_LRS")]
        StandardLrs = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Premium_LRS")]
        PremiumLrs = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="StandardSSD_LRS")]
        StandardSsdLrs = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UltraSSD_LRS")]
        UltraSsdLrs = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Premium_ZRS")]
        PremiumZrs = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="StandardSSD_ZRS")]
        StandardSsdZrs = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PremiumV2_LRS")]
        PremiumV2Lrs = 6,
    }
    public enum DomainNameLabelScopeType
    {
        TenantReuse = 0,
        SubscriptionReuse = 1,
        ResourceGroupReuse = 2,
        NoReuse = 3,
    }
    public enum EdgeZoneStorageAccountType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_LRS")]
        StandardLrs = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_ZRS")]
        StandardZrs = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="StandardSSD_LRS")]
        StandardSsdLrs = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Premium_LRS")]
        PremiumLrs = 3,
    }
    public partial class EncryptionImages : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EncryptionImages() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.DataDiskImageEncryption> DataDiskImages { get { throw null; } set { } }
        public Azure.Provisioning.Compute.OSDiskImageEncryption OSDiskImage { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EncryptionSettingsElement : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EncryptionSettingsElement() { }
        public Azure.Provisioning.Compute.KeyVaultAndSecretReference DiskEncryptionKey { get { throw null; } set { } }
        public Azure.Provisioning.Compute.KeyVaultAndKeyReference KeyEncryptionKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EncryptionSettingsGroup : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EncryptionSettingsGroup() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.EncryptionSettingsElement> EncryptionSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptionSettingsVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EventGridAndResourceGraph : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EventGridAndResourceGraph() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScheduledEventsApiVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ExecutionState
    {
        Unknown = 0,
        Pending = 1,
        Running = 2,
        Failed = 3,
        Succeeded = 4,
        TimedOut = 5,
        Canceled = 6,
    }
    public partial class GalleryApplication : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public GalleryApplication(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.GalleryApplicationCustomAction> CustomActions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOfLifeOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Eula { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ComputeGallery? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> PrivacyStatementUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ReleaseNoteUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.SupportedOperatingSystemType> SupportedOSType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.GalleryApplication FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_03;
            public static readonly string V2025_03_03;
        }
    }
    public partial class GalleryApplicationCustomAction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryApplicationCustomAction() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.GalleryApplicationCustomActionParameter> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Script { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryApplicationCustomActionParameter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryApplicationCustomActionParameter() { }
        public Azure.Provisioning.BicepValue<string> DefaultValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.GalleryApplicationCustomActionParameterType> ParameterType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GalleryApplicationCustomActionParameterType
    {
        String = 0,
        ConfigurationDataBlob = 1,
        LogOutputBlob = 2,
    }
    public enum GalleryApplicationScriptRebootBehavior
    {
        None = 0,
        Rerun = 1,
    }
    public partial class GalleryApplicationVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public GalleryApplicationVersion(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowDeletionOfReplicatedLocations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Compute.GalleryApplication? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.GalleryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Compute.GalleryApplicationVersionPublishingProfile PublishingProfile { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ReplicationStatus ReplicationStatus { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.GalleryApplicationVersion FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_03;
            public static readonly string V2025_03_03;
        }
    }
    public partial class GalleryApplicationVersionPublishingProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryApplicationVersionPublishingProfile() { }
        public Azure.Provisioning.BicepDictionary<string> AdvancedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.GalleryApplicationCustomAction> CustomActions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableHealthCheck { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOfLifeOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsExcludedFromLatest { get { throw null; } set { } }
        public Azure.Provisioning.Compute.UserArtifactManagement ManageActions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PublishedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ReplicaCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.GalleryReplicationMode> ReplicationMode { get { throw null; } set { } }
        public Azure.Provisioning.Compute.UserArtifactSettings Settings { get { throw null; } set { } }
        public Azure.Provisioning.Compute.UserArtifactSource Source { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.StorageAccountStrategy> StorageAccountStrategy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ImageStorageAccountType> StorageAccountType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.GalleryTargetExtendedLocation> TargetExtendedLocations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.TargetRegion> TargetRegions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryArtifactVersionFullSource : Azure.Provisioning.Compute.GalleryArtifactVersionSource
    {
        public GalleryArtifactVersionFullSource() { }
        public Azure.Provisioning.BicepValue<string> CommunityGalleryImageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualMachineId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryArtifactVersionSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryArtifactVersionSource() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryDataDiskImage : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryDataDiskImage() { }
        public Azure.Provisioning.Compute.GalleryDiskImageSource GallerySource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.HostCaching> HostCaching { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Lun { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SizeInGB { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryDiskImageSource : Azure.Provisioning.Compute.GalleryArtifactVersionSource
    {
        public GalleryDiskImageSource() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageAccountId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryExtendedLocation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryExtendedLocation() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.GalleryExtendedLocationType> ExtendedLocationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GalleryExtendedLocationType
    {
        EdgeZone = 0,
        Unknown = 1,
    }
    public partial class GalleryImage : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public GalleryImage(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowUpdateImage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ArchitectureType> Architecture { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DisallowedDiskTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOfLifeOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Eula { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.GalleryImageFeature> Features { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.HyperVGeneration> HyperVGeneration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Compute.GalleryImageIdentifier Identifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.OperatingSystemStateType> OSState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.SupportedOperatingSystemType> OSType { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ComputeGallery? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> PrivacyStatementUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.GalleryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Compute.ImagePurchasePlan PurchasePlan { get { throw null; } set { } }
        public Azure.Provisioning.Compute.RecommendedMachineConfiguration Recommended { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ReleaseNoteUri { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.GalleryImage FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_03;
            public static readonly string V2025_03_03;
        }
    }
    public partial class GalleryImageExecutedValidation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryImageExecutedValidation() { }
        public Azure.Provisioning.BicepValue<string> ExecutedValidationType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExecutionOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ComputeGalleryValidationStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryImageFeature : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryImageFeature() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartsAtVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryImageIdentifier : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryImageIdentifier() { }
        public Azure.Provisioning.BicepValue<string> Offer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sku { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryImageValidationsProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryImageValidationsProfile() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.GalleryImageExecutedValidation> ExecutedValidations { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.ComputeGalleryPlatformAttribute> PlatformAttributes { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ValidationETag { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryImageVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public GalleryImageVersion(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsRestoreEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Compute.GalleryImage? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.GalleryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Compute.GalleryImageVersionPublishingProfile PublishingProfile { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ReplicationStatus ReplicationStatus { get { throw null; } }
        public Azure.Provisioning.Compute.GalleryImageVersionSafetyProfile SafetyProfile { get { throw null; } set { } }
        public Azure.Provisioning.Compute.GalleryImageVersionUefiSettings SecurityUefiSettings { get { throw null; } set { } }
        public Azure.Provisioning.Compute.GalleryImageVersionStorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.Compute.GalleryImageValidationsProfile ValidationsProfile { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.GalleryImageVersion FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_03;
            public static readonly string V2025_03_03;
        }
    }
    public partial class GalleryImageVersionPolicyViolation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryImageVersionPolicyViolation() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.GalleryImageVersionPolicyViolationCategory> Category { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Details { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GalleryImageVersionPolicyViolationCategory
    {
        Other = 0,
        ImageFlaggedUnsafe = 1,
        CopyrightValidation = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IpTheft")]
        IPTheft = 3,
    }
    public partial class GalleryImageVersionPublishingProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryImageVersionPublishingProfile() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOfLifeOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsExcludedFromLatest { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PublishedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ReplicaCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.GalleryReplicationMode> ReplicationMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.StorageAccountStrategy> StorageAccountStrategy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ImageStorageAccountType> StorageAccountType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.GalleryTargetExtendedLocation> TargetExtendedLocations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.TargetRegion> TargetRegions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryImageVersionSafetyProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryImageVersionSafetyProfile() { }
        public Azure.Provisioning.BicepValue<bool> AllowDeletionOfReplicatedLocations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsBlockedDeletionBeforeEndOfLife { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsReportedForPolicyViolation { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.GalleryImageVersionPolicyViolation> PolicyViolations { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryImageVersionStorageProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryImageVersionStorageProfile() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.GalleryDataDiskImage> DataDiskImages { get { throw null; } set { } }
        public Azure.Provisioning.Compute.GalleryArtifactVersionFullSource GallerySource { get { throw null; } set { } }
        public Azure.Provisioning.Compute.GalleryOSDiskImage OSDiskImage { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryImageVersionUefiSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryImageVersionUefiSettings() { }
        public Azure.Provisioning.Compute.UefiKeySignatures AdditionalSignatures { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.UefiSignatureTemplateName> SignatureTemplateNames { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryInVmAccessControlProfile : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public GalleryInVmAccessControlProfile(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ComputeGallery? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Compute.GalleryInVmAccessControlProfileProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.GalleryInVmAccessControlProfile FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_03;
            public static readonly string V2025_03_03;
        }
    }
    public partial class GalleryInVmAccessControlProfileProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryInVmAccessControlProfileProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ComputeGalleryEndpointType> ApplicableHostEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.SupportedOperatingSystemType> OSType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.GalleryProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryInVmAccessControlProfileVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public GalleryInVmAccessControlProfileVersion(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ComputeGalleryEndpointAccess> DefaultAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ExcludeFromLatest { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.GalleryInVmAccessControlRulesMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Compute.GalleryInVmAccessControlProfile? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.GalleryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PublishedOn { get { throw null; } }
        public Azure.Provisioning.Compute.ReplicationStatus ReplicationStatus { get { throw null; } }
        public Azure.Provisioning.Compute.GalleryInVmAccessControlRules Rules { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.TargetRegion> TargetLocations { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.GalleryInVmAccessControlProfileVersion FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_03;
            public static readonly string V2025_03_03;
        }
    }
    public partial class GalleryInVmAccessControlRules : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryInVmAccessControlRules() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.GalleryInVmAccessControlRulesIdentity> Identities { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.GalleryInVmAccessControlRulesPrivilege> Privileges { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.GalleryInVmAccessControlRulesRoleAssignment> RoleAssignments { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.GalleryInVmAccessControlRulesRole> Roles { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryInVmAccessControlRulesIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryInVmAccessControlRulesIdentity() { }
        public Azure.Provisioning.BicepValue<string> ExePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProcessName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GalleryInVmAccessControlRulesMode
    {
        Audit = 0,
        Enforce = 1,
        Disabled = 2,
    }
    public partial class GalleryInVmAccessControlRulesPrivilege : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryInVmAccessControlRulesPrivilege() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> QueryParameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryInVmAccessControlRulesRole : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryInVmAccessControlRulesRole() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Privileges { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryInVmAccessControlRulesRoleAssignment : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryInVmAccessControlRulesRoleAssignment() { }
        public Azure.Provisioning.BicepList<string> Identities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Role { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryOSDiskImage : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryOSDiskImage() { }
        public Azure.Provisioning.Compute.GalleryDiskImageSource GallerySource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.HostCaching> HostCaching { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SizeInGB { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GalleryProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Failed = 2,
        Succeeded = 3,
        Deleting = 4,
        Migrating = 5,
    }
    public enum GalleryReplicationMode
    {
        Full = 0,
        Shallow = 1,
    }
    public partial class GalleryScript : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public GalleryScript(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ComputeGallery? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Compute.GalleryScriptProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.GalleryScript FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_03_03;
        }
    }
    public partial class GalleryScriptParameter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryScriptParameter() { }
        public Azure.Provisioning.BicepValue<string> DefaultValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EnumValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MaxValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MinValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.GalleryScriptParameterType> ParameterType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Required { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GalleryScriptParameterType
    {
        String = 0,
        Int = 1,
        Double = 2,
        Boolean = 3,
        Enum = 4,
    }
    public partial class GalleryScriptProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryScriptProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOfLifeOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Eula { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> PrivacyStatementUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.GalleryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> ReleaseNoteUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.SupportedOperatingSystemType> SupportedOSType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryScriptVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public GalleryScriptVersion(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Compute.GalleryScript? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Compute.GalleryScriptVersionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.GalleryScriptVersion FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_03_03;
        }
    }
    public partial class GalleryScriptVersionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryScriptVersionProperties() { }
        public Azure.Provisioning.BicepValue<bool> AllowDeletionOfReplicatedLocations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.GalleryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Compute.GalleryScriptVersionPublishingProfile PublishingProfile { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ReplicationStatus ReplicationStatus { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GalleryScriptVersionPublishingProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryScriptVersionPublishingProfile() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOfLifeOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsExcludedFromLatest { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PublishedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ReplicaCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.GalleryReplicationMode> ReplicationMode { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ScriptSource Source { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.StorageAccountStrategy> StorageAccountStrategy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ImageStorageAccountType> StorageAccountType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.GalleryTargetExtendedLocation> TargetExtendedLocations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.TargetRegion> TargetRegions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GallerySharingPermissionType
    {
        Private = 0,
        Groups = 1,
        Community = 2,
    }
    public partial class GalleryTargetExtendedLocation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GalleryTargetExtendedLocation() { }
        public Azure.Provisioning.Compute.EncryptionImages Encryption { get { throw null; } set { } }
        public Azure.Provisioning.Compute.GalleryExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ExtendedLocationReplicaCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.EdgeZoneStorageAccountType> GalleryStorageAccountType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HighSpeedInterconnectPlacement
    {
        None = 0,
        Trunk = 1,
    }
    public enum HostCaching
    {
        None = 0,
        ReadOnly = 1,
        ReadWrite = 2,
    }
    public partial class HostEndpointSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HostEndpointSettings() { }
        public Azure.Provisioning.BicepValue<string> InVmAccessControlProfileReferenceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.HostEndpointSettingsMode> Mode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HostEndpointSettingsMode
    {
        Audit = 0,
        Enforce = 1,
        Disabled = 2,
    }
    public enum HyperVGeneration
    {
        V1 = 0,
        V2 = 1,
    }
    public partial class ImageDataDisk : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageDataDisk() { }
        public Azure.Provisioning.BicepValue<System.Uri> BlobUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.CachingType> Caching { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DiskSizeGB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Lun { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedDiskId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SnapshotId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.StorageAccountType> StorageAccountType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageDiskReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageDiskReference() { }
        public Azure.Provisioning.BicepValue<string> CommunityGalleryImageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Lun { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SharedGalleryImageId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageOSDisk : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageOSDisk() { }
        public Azure.Provisioning.BicepValue<System.Uri> BlobUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.CachingType> Caching { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DiskSizeGB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedDiskId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.OperatingSystemStateType> OSState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.SupportedOperatingSystemType> OSType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SnapshotId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.StorageAccountType> StorageAccountType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImagePurchasePlan : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImagePurchasePlan() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Product { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageReference() { }
        public Azure.Provisioning.BicepValue<string> CommunityGalleryImageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExactVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Offer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SharedGalleryImageUniqueId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ImageStorageAccountType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="StandardSSD_LRS")]
        StandardSsdLrs = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_LRS")]
        StandardLrs = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_ZRS")]
        StandardZrs = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Premium_LRS")]
        PremiumLrs = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PremiumV2_LRS")]
        PremiumV2Lrs = 4,
    }
    public partial class ImageStorageProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageStorageProfile() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.ImageDataDisk> DataDisks { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ImageOSDisk OSDisk { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ZoneResilient { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class InnerError : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public InnerError() { }
        public Azure.Provisioning.BicepValue<string> Errordetail { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Exceptiontype { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class InstanceViewStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public InstanceViewStatus() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ComputeStatusLevelType> Level { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Time { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IPVersion
    {
        IPv4 = 0,
        IPv6 = 1,
    }
    public partial class KeyForDiskEncryptionSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyForDiskEncryptionSet() { }
        public Azure.Provisioning.BicepValue<System.Uri> KeyUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceVaultId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KeyVaultAndKeyReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyVaultAndKeyReference() { }
        public Azure.Provisioning.BicepValue<System.Uri> KeyUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceVaultId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KeyVaultAndSecretReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyVaultAndSecretReference() { }
        public Azure.Provisioning.BicepValue<System.Uri> SecretUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceVaultId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KeyVaultKeyReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyVaultKeyReference() { }
        public Azure.Provisioning.BicepValue<System.Uri> KeyUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceVaultId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KeyVaultSecretReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyVaultSecretReference() { }
        public Azure.Provisioning.BicepValue<System.Uri> SecretUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceVaultId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LastPatchInstallationSummary : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LastPatchInstallationSummary() { }
        public Azure.Provisioning.Compute.ComputeApiError Error { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ExcludedPatchCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> FailedPatchCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InstallationActivityId { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> InstalledPatchCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> MaintenanceWindowExceeded { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> NotSelectedPatchCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> PendingPatchCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.PatchOperationStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LinuxConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LinuxConfiguration() { }
        public Azure.Provisioning.BicepValue<bool> IsPasswordAuthenticationDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVmAgentPlatformUpdatesEnabled { get { throw null; } set { } }
        public Azure.Provisioning.Compute.LinuxPatchSettings PatchSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ProvisionVmAgent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.SshPublicKeyConfiguration> SshPublicKeys { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LinuxPatchAssessmentMode
    {
        ImageDefault = 0,
        AutomaticByPlatform = 1,
    }
    public partial class LinuxPatchSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LinuxPatchSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.LinuxPatchAssessmentMode> AssessmentMode { get { throw null; } set { } }
        public Azure.Provisioning.Compute.LinuxVmGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.LinuxVmGuestPatchMode> PatchMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LinuxVmGuestPatchAutomaticByPlatformRebootSetting
    {
        Unknown = 0,
        IfRequired = 1,
        Never = 2,
        Always = 3,
    }
    public partial class LinuxVmGuestPatchAutomaticByPlatformSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LinuxVmGuestPatchAutomaticByPlatformSettings() { }
        public Azure.Provisioning.BicepValue<bool> BypassPlatformSafetyChecksOnUserSchedule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.LinuxVmGuestPatchAutomaticByPlatformRebootSetting> RebootSetting { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LinuxVmGuestPatchMode
    {
        ImageDefault = 0,
        AutomaticByPlatform = 1,
    }
    public partial class LoadBalancerFrontendIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LoadBalancerFrontendIPConfiguration() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PublicIPAddressId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MaintenanceOperationResultCodeType
    {
        None = 0,
        RetryLater = 1,
        MaintenanceAborted = 2,
        MaintenanceCompleted = 3,
    }
    public partial class MaintenanceRedeployStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MaintenanceRedeployStatus() { }
        public Azure.Provisioning.BicepValue<bool> IsCustomerInitiatedMaintenanceAllowed { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastOperationMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.MaintenanceOperationResultCodeType> LastOperationResultCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> MaintenanceWindowEndOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> MaintenanceWindowStartOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PreMaintenanceWindowEndOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> PreMaintenanceWindowStartOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedDisk : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedDisk(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.AvailabilityPolicyDiskDelay> AvailabilityActionOnDiskDelay { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> BurstingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> BurstingEnabledOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> CompletionPercent { get { throw null; } set { } }
        public Azure.Provisioning.Compute.DiskCreationData CreationData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DataAccessAuthMode> DataAccessAuthMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DiskAccessId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> DiskIopsReadOnly { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> DiskIopsReadWrite { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> DiskMBpsReadOnly { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> DiskMBpsReadWrite { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> DiskSizeBytes { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> DiskSizeGB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiskState> DiskState { get { throw null; } }
        public Azure.Provisioning.Compute.DiskEncryption Encryption { get { throw null; } set { } }
        public Azure.Provisioning.Compute.EncryptionSettingsGroup EncryptionSettingsGroup { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.HyperVGeneration> HyperVGeneration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsOptimizedForFrequentAttach { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastOwnershipUpdateOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedBy { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> ManagedByExtended { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> MaxShares { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.NetworkAccessPolicy> NetworkAccessPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.SupportedOperatingSystemType> OSType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PropertyUpdatesInProgressTargetTier { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiskPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.Compute.DiskPurchasePlan PurchasePlan { get { throw null; } set { } }
        public Azure.Provisioning.Compute.DiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.ShareInfoElement> ShareInfo { get { throw null; } }
        public Azure.Provisioning.Compute.DiskSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Compute.SupportedCapabilities SupportedCapabilities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SupportsHibernation { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TimeCreated { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UniqueId { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.ManagedDisk FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_01_02;
        }
    }
    public partial class MaxInstancePercentPerZonePolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MaxInstancePercentPerZonePolicy() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum Mode
    {
        Audit = 0,
        Enforce = 1,
    }
    public enum NetworkAccessPolicy
    {
        AllowAll = 0,
        AllowPrivate = 1,
        DenyAll = 2,
    }
    public enum NetworkApiVersion
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="2020-11-01")]
        v2020_11_01 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="2022-11-01")]
        v2022_11_01 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="2020-11-01")]
        TwoThousandTwenty1101 = 2,
    }
    public enum OperatingSystemStateType
    {
        Generalized = 0,
        Specialized = 1,
    }
    public enum OperatingSystemType
    {
        Windows = 0,
        Linux = 1,
    }
    public enum OrchestrationMode
    {
        Uniform = 0,
        Flexible = 1,
    }
    public partial class OSDiskImageEncryption : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OSDiskImageEncryption() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.Provisioning.Compute.OSDiskImageSecurityProfile SecurityProfile { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OSDiskImageSecurityProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OSDiskImageSecurityProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ConfidentialVmEncryptionType> ConfidentialVmEncryptionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecureVmDiskEncryptionSetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OSImageNotificationProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OSImageNotificationProfile() { }
        public Azure.Provisioning.BicepValue<bool> Enable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NotBeforeTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PassName
    {
        OobeSystem = 0,
    }
    public enum PatchOperationStatus
    {
        Unknown = 0,
        InProgress = 1,
        Failed = 2,
        Succeeded = 3,
        CompletedWithWarnings = 4,
    }
    public partial class PatchSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PatchSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.WindowsPatchAssessmentMode> AssessmentMode { get { throw null; } set { } }
        public Azure.Provisioning.Compute.WindowsVmGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableHotpatching { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.WindowsVmGuestPatchMode> PatchMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ProvisionedBandwidthCopyOption
    {
        None = 0,
        Enhanced = 1,
    }
    public partial class ProximityPlacementGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ProximityPlacementGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.ComputeSubResourceDataWithColocationStatus> AvailabilitySets { get { throw null; } }
        public Azure.Provisioning.Compute.InstanceViewStatus ColocationStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<string> IntentVmSizes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ProximityPlacementGroupType> ProximityPlacementGroupType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.ComputeSubResourceDataWithColocationStatus> VirtualMachines { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.ComputeSubResourceDataWithColocationStatus> VirtualMachineScaleSets { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.ProximityPlacementGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_04_01;
        }
    }
    public enum ProximityPlacementGroupType
    {
        Standard = 0,
        Ultra = 1,
    }
    public partial class ProxyAgentSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ProxyAgentSettings() { }
        public Azure.Provisioning.BicepValue<bool> AddProxyAgentExtension { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.Compute.HostEndpointSettings Imds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> KeyIncarnationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.Mode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.Compute.HostEndpointSettings WireServer { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PublicIPAllocationMethod
    {
        Dynamic = 0,
        Static = 1,
    }
    public partial class RecommendedMachineConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RecommendedMachineConfiguration() { }
        public Azure.Provisioning.Compute.ResourceRange Memory { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ResourceRange VCpus { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RegionalReplicationState
    {
        Unknown = 0,
        Replicating = 1,
        Completed = 2,
        Failed = 3,
    }
    public partial class RegionalReplicationStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RegionalReplicationStatus() { }
        public Azure.Provisioning.BicepValue<string> Details { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Progress { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Region { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.RegionalReplicationState> State { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RegionalSharingStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RegionalSharingStatus() { }
        public Azure.Provisioning.BicepValue<string> Details { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Region { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.SharingState> State { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RepairAction
    {
        Replace = 0,
        Restart = 1,
        Reimage = 2,
    }
    public partial class ReplicationStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReplicationStatus() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.AggregatedReplicationState> AggregatedState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.RegionalReplicationStatus> Summary { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResiliencyPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResiliencyPolicy() { }
        public Azure.Provisioning.Compute.AutomaticZoneRebalancingPolicy AutomaticZoneRebalancingPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ResilientVmCreationPolicyEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ResilientVmDeletionPolicyEnabled { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ZoneAllocationPolicy ZoneAllocationPolicy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ResilientVmDeletionStatus
    {
        Enabled = 0,
        Disabled = 1,
        InProgress = 2,
        Failed = 3,
    }
    public partial class ResourceRange : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceRange() { }
        public Azure.Provisioning.BicepValue<int> Max { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Min { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RestorePoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RestorePoint(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ConsistencyModeType> ConsistencyMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> ExcludeDisks { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Compute.RestorePointInstanceView InstanceView { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> InstantAccessDurationMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Compute.RestorePointGroup? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Compute.RestorePointSourceMetadata SourceMetadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceRestorePointId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TimeCreated { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.RestorePoint FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_04_01;
        }
    }
    public partial class RestorePointEncryption : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RestorePointEncryption() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.RestorePointEncryptionType> EncryptionType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RestorePointEncryptionType
    {
        EncryptionAtRestWithPlatformKey = 0,
        EncryptionAtRestWithCustomerKey = 1,
        EncryptionAtRestWithPlatformAndCustomerKeys = 2,
    }
    public partial class RestorePointGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RestorePointGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> InstantAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RestorePointGroupId { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.RestorePoint> RestorePoints { get { throw null; } }
        public Azure.Provisioning.Compute.RestorePointGroupSource Source { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.RestorePointGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_04_01;
        }
    }
    public partial class RestorePointGroupSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RestorePointGroupSource() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RestorePointInstanceView : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RestorePointInstanceView() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.DiskRestorePointInstanceView> DiskRestorePoints { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.InstanceViewStatus> Statuses { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RestorePointSourceMetadata : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RestorePointSourceMetadata() { }
        public Azure.Provisioning.Compute.BootDiagnostics BootDiagnostics { get { throw null; } }
        public Azure.Provisioning.Compute.VirtualMachineHardwareProfile HardwareProfile { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.HyperVGeneration> HyperVGeneration { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LicenseType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.Compute.VirtualMachineOSProfile OSProfile { get { throw null; } }
        public Azure.Provisioning.Compute.SecurityProfile SecurityProfile { get { throw null; } }
        public Azure.Provisioning.Compute.RestorePointSourceVmStorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VmId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RestorePointSourceVmDataDisk : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RestorePointSourceVmDataDisk() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.CachingType> Caching { get { throw null; } }
        public Azure.Provisioning.Compute.DiskRestorePointAttributes DiskRestorePoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DiskSizeGB { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Lun { get { throw null; } }
        public Azure.Provisioning.Compute.VirtualMachineManagedDisk ManagedDisk { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> WriteAcceleratorEnabled { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RestorePointSourceVmOSDisk : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RestorePointSourceVmOSDisk() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.CachingType> Caching { get { throw null; } }
        public Azure.Provisioning.Compute.DiskRestorePointAttributes DiskRestorePoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DiskSizeGB { get { throw null; } }
        public Azure.Provisioning.Compute.DiskEncryptionSettings EncryptionSettings { get { throw null; } }
        public Azure.Provisioning.Compute.VirtualMachineManagedDisk ManagedDisk { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.OperatingSystemType> OSType { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> WriteAcceleratorEnabled { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RestorePointSourceVmStorageProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RestorePointSourceVmStorageProfile() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.RestorePointSourceVmDataDisk> DataDiskList { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiskControllerType> DiskControllerType { get { throw null; } }
        public Azure.Provisioning.Compute.RestorePointSourceVmOSDisk OSDisk { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RollingUpgradePolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RollingUpgradePolicy() { }
        public Azure.Provisioning.BicepValue<bool> EnableCrossZoneUpgrade { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsMaxSurgeEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxBatchInstancePercent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxUnhealthyInstancePercent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxUnhealthyUpgradedInstancePercent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PauseTimeBetweenBatches { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> PrioritizeUnhealthyInstances { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RollbackFailedInstancesOnPolicyBreach { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RunCommandInputParameter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RunCommandInputParameter() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RunCommandManagedIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RunCommandManagedIdentity() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ObjectId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ScaleInPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScaleInPolicy() { }
        public Azure.Provisioning.BicepValue<bool> ForceDeletion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> PrioritizeUnhealthyVms { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VirtualMachineScaleSetScaleInRule> Rules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ScheduledEventsPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScheduledEventsPolicy() { }
        public Azure.Provisioning.Compute.AllInstancesDown AllInstancesDown { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AutomaticallyApprove { get { throw null; } set { } }
        public Azure.Provisioning.Compute.EventGridAndResourceGraph ScheduledEventsAdditionalPublishingTargetsEventGridAndResourceGraph { get { throw null; } set { } }
        public Azure.Provisioning.Compute.UserInitiatedRedeploy UserInitiatedRedeploy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ScheduleProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScheduleProfile() { }
        public Azure.Provisioning.BicepValue<string> End { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Start { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ScriptShellType
    {
        Default = 0,
        Powershell7 = 1,
    }
    public partial class ScriptSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScriptSource() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.GalleryScriptParameter> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptLink { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SecurityEncryptionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="VMGuestStateOnly")]
        VmGuestStateOnly = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="DiskWithVMGuestState")]
        DiskWithVmGuestState = 1,
        NonPersistedTPM = 2,
    }
    public partial class SecurityProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityProfile() { }
        public Azure.Provisioning.BicepValue<bool> EncryptionAtHost { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ProxyAgentSettings ProxyAgentSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.SecurityType> SecurityType { get { throw null; } set { } }
        public Azure.Provisioning.Compute.UefiSettings UefiSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserAssignedIdentityResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SecurityType
    {
        TrustedLaunch = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ConfidentialVM")]
        ConfidentialVm = 1,
    }
    public enum SettingName
    {
        AutoLogon = 0,
        FirstLogonCommands = 1,
    }
    public partial class ShareInfoElement : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ShareInfoElement() { }
        public Azure.Provisioning.BicepValue<System.Uri> VmUri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SharingProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SharingProfile() { }
        public Azure.Provisioning.Compute.CommunityGalleryInfo CommunityGalleryInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.SharingProfileGroup> Groups { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.GallerySharingPermissionType> Permission { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SharingProfileGroup : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SharingProfileGroup() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.SharingProfileGroupType> GroupType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Ids { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SharingProfileGroupType
    {
        Subscriptions = 0,
        AADTenants = 1,
    }
    public enum SharingState
    {
        Succeeded = 0,
        InProgress = 1,
        Failed = 2,
        Unknown = 3,
    }
    public partial class SharingStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SharingStatus() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.SharingState> AggregatedState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.RegionalSharingStatus> Summary { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SnapshotAccessState
    {
        Unknown = 0,
        Pending = 1,
        Available = 2,
        InstantAccess = 3,
        AvailableWithInstantAccess = 4,
    }
    public partial class SnapshotSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SnapshotSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.SnapshotStorageAccountType> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tier { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SnapshotStorageAccountType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_LRS")]
        StandardLrs = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Premium_LRS")]
        PremiumLrs = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_ZRS")]
        StandardZrs = 2,
    }
    public partial class SpotRestorePolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SpotRestorePolicy() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RestoreTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SshPublicKey : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SshPublicKey(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublicKey { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.SshPublicKey FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_04_01;
        }
    }
    public partial class SshPublicKeyConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SshPublicKeyConfiguration() { }
        public Azure.Provisioning.BicepValue<string> KeyData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StorageAccountStrategy
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="PreferStandard_ZRS")]
        PreferStandardZrs = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="DefaultStandard_LRS")]
        DefaultStandardLrs = 1,
    }
    public enum StorageAccountType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_LRS")]
        StandardLrs = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Premium_LRS")]
        PremiumLrs = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="StandardSSD_LRS")]
        StandardSsdLrs = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UltraSSD_LRS")]
        UltraSsdLrs = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Premium_ZRS")]
        PremiumZrs = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="StandardSSD_ZRS")]
        StandardSsdZrs = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PremiumV2_LRS")]
        PremiumV2Lrs = 6,
    }
    public partial class SupportedCapabilities : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SupportedCapabilities() { }
        public Azure.Provisioning.BicepValue<bool> AcceleratedNetwork { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ArchitectureType> Architecture { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DiskControllerTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.SupportedSecurityOption> SupportedSecurityOption { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SupportedOperatingSystemType
    {
        Windows = 0,
        Linux = 1,
    }
    public enum SupportedSecurityOption
    {
        TrustedLaunchSupported = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TrustedLaunchAndConfidentialVMSupported")]
        TrustedLaunchAndConfidentialVmSupported = 1,
    }
    public partial class TargetRegion : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TargetRegion() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.AdditionalReplicaSet> AdditionalReplicaSets { get { throw null; } set { } }
        public Azure.Provisioning.Compute.EncryptionImages Encryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsExcludedFromLatest { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RegionalReplicaCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ImageStorageAccountType> StorageAccountType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TerminateNotificationProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TerminateNotificationProfile() { }
        public Azure.Provisioning.BicepValue<bool> Enable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NotBeforeTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UefiKey : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UefiKey() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.UefiKeyType> KeyType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UefiKeySignatures : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UefiKeySignatures() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.UefiKey> Db { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.UefiKey> Dbx { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.UefiKey> Kek { get { throw null; } set { } }
        public Azure.Provisioning.Compute.UefiKey Pk { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum UefiKeyType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="sha256")]
        Sha256 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="x509")]
        X509 = 1,
    }
    public partial class UefiSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UefiSettings() { }
        public Azure.Provisioning.BicepValue<bool> IsSecureBootEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVirtualTpmEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum UefiSignatureTemplateName
    {
        NoSignatureTemplate = 0,
        MicrosoftUefiCertificateAuthorityTemplate = 1,
        MicrosoftWindowsTemplate = 2,
    }
    public partial class UserArtifactManagement : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UserArtifactManagement() { }
        public Azure.Provisioning.BicepValue<string> Install { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Remove { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Update { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UserArtifactSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UserArtifactSettings() { }
        public Azure.Provisioning.BicepValue<string> ConfigFileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PackageFileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.GalleryApplicationScriptRebootBehavior> ScriptBehaviorAfterReboot { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UserArtifactSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UserArtifactSource() { }
        public Azure.Provisioning.BicepValue<string> DefaultConfigurationLink { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MediaLink { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UserInitiatedRedeploy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UserInitiatedRedeploy() { }
        public Azure.Provisioning.BicepValue<bool> AutomaticallyApprove { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VaultCertificate : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VaultCertificate() { }
        public Azure.Provisioning.BicepValue<string> CertificateStore { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> CertificateUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VaultSecretGroup : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VaultSecretGroup() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceVaultId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VaultCertificate> VaultCertificates { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachine : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualMachine(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Compute.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AvailabilitySetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> BillingMaxPrice { get { throw null; } set { } }
        public Azure.Provisioning.Compute.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CapacityReservationGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.VirtualMachineEvictionPolicyType> EvictionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExtensionsTimeBudget { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VirtualMachineGalleryApplication> GalleryApplications { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineHardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> HostGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> HostId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineInstanceView InstanceView { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LicenseType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineOSProfile OSProfile { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachinePlacement Placement { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ComputePlan Plan { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PlatformFaultDomain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.VirtualMachinePriorityType> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VirtualMachineExtension> Resources { get { throw null; } }
        public Azure.Provisioning.Compute.ScheduledEventsPolicy ScheduledEventsPolicy { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ComputeScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
        public Azure.Provisioning.Compute.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineStorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TimeCreated { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UserData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualMachineScaleSetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VmId { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.VirtualMachine FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_04_01;
        }
    }
    public partial class VirtualMachineAgentInstanceView : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineAgentInstanceView() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VirtualMachineExtensionHandlerInstanceView> ExtensionHandlers { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.InstanceViewStatus> Statuses { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VmAgentVersion { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineDataDisk : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineDataDisk() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.CachingType> Caching { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiskCreateOptionType> CreateOption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiskDeleteOptionType> DeleteOption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiskDetachOptionType> DetachOption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> DiskIopsReadWrite { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> DiskMBpsReadWrite { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DiskSizeGB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ImageUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Lun { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineManagedDisk ManagedDisk { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ToBeDetached { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> VhdUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> WriteAcceleratorEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineDiskSecurityProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineDiskSecurityProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.SecurityEncryptionType> SecurityEncryptionType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualMachineEvictionPolicyType
    {
        Deallocate = 0,
        Delete = 1,
    }
    public partial class VirtualMachineExtension : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualMachineExtension(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AutoUpgradeMinorVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableAutomaticUpgrade { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExtensionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ForceUpdateTag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Compute.VirtualMachineExtensionInstanceView InstanceView { get { throw null; } set { } }
        public Azure.Provisioning.Compute.KeyVaultSecretReference KeyVaultProtectedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachine? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ProtectedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ProvisionAfterExtensions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Settings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SuppressFailures { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TypeHandlerVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.VirtualMachineExtension FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_04_01;
        }
    }
    public partial class VirtualMachineExtensionHandlerInstanceView : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineExtensionHandlerInstanceView() { }
        public Azure.Provisioning.Compute.InstanceViewStatus Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TypeHandlerVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VirtualMachineExtensionHandlerInstanceViewType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineExtensionInstanceView : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineExtensionInstanceView() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.InstanceViewStatus> Statuses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.InstanceViewStatus> Substatuses { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TypeHandlerVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VirtualMachineExtensionInstanceViewType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineGalleryApplication : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineGalleryApplication() { }
        public Azure.Provisioning.BicepValue<string> ConfigurationReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableAutomaticUpgrade { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Order { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PackageReferenceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TreatFailureAsDeploymentFailure { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineHardwareProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineHardwareProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.VirtualMachineSizeType> VmSize { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineSizeProperties VmSizeProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineInstanceView : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineInstanceView() { }
        public Azure.Provisioning.BicepValue<string> AssignedHost { get { throw null; } }
        public Azure.Provisioning.Compute.BootDiagnosticsInstanceView BootDiagnostics { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ComputerName { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.DiskInstanceView> Disks { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VirtualMachineExtensionInstanceView> Extensions { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.HyperVGeneration> HyperVGeneration { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsVmInStandbyPool { get { throw null; } }
        public Azure.Provisioning.Compute.MaintenanceRedeployStatus MaintenanceRedeployStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OSName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OSVersion { get { throw null; } }
        public Azure.Provisioning.Compute.VirtualMachinePatchStatus PatchStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> PlatformFaultDomain { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> PlatformUpdateDomain { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RdpThumbPrint { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.InstanceViewStatus> Statuses { get { throw null; } }
        public Azure.Provisioning.Compute.VirtualMachineAgentInstanceView VmAgent { get { throw null; } }
        public Azure.Provisioning.Compute.InstanceViewStatus VmHealthStatus { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineIPTag : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineIPTag() { }
        public Azure.Provisioning.BicepValue<string> IPTagType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tag { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineManagedDisk : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineManagedDisk() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineDiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.StorageAccountType> StorageAccountType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineNetworkInterfaceConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineNetworkInterfaceConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ComputeNetworkInterfaceAuxiliaryMode> AuxiliaryMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ComputeNetworkInterfaceAuxiliarySku> AuxiliarySku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ComputeDeleteOption> DeleteOption { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DnsServers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DscpConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableAcceleratedNetworking { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableFpga { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableIPForwarding { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VirtualMachineNetworkInterfaceIPConfiguration> IPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsTcpStateTrackingDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NetworkSecurityGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Primary { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineNetworkInterfaceIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineNetworkInterfaceIPConfiguration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> ApplicationGatewayBackendAddressPools { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> ApplicationSecurityGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> LoadBalancerBackendAddressPools { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Primary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.IPVersion> PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachinePublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineNetworkInterfaceReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineNetworkInterfaceReference() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ComputeDeleteOption> DeleteOption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Primary { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineNetworkProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineNetworkProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.NetworkApiVersion> NetworkApiVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VirtualMachineNetworkInterfaceConfiguration> NetworkInterfaceConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VirtualMachineNetworkInterfaceReference> NetworkInterfaces { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineOSDisk : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineOSDisk() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.CachingType> Caching { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiskCreateOptionType> CreateOption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiskDeleteOptionType> DeleteOption { get { throw null; } set { } }
        public Azure.Provisioning.Compute.DiffDiskSettings DiffDiskSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DiskSizeGB { get { throw null; } set { } }
        public Azure.Provisioning.Compute.DiskEncryptionSettings EncryptionSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ImageUri { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineManagedDisk ManagedDisk { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.SupportedOperatingSystemType> OSType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> VhdUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> WriteAcceleratorEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineOSProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineOSProfile() { }
        public Azure.Provisioning.BicepValue<string> AdminPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AdminUsername { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowExtensionOperations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ComputerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomData { get { throw null; } set { } }
        public Azure.Provisioning.Compute.LinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RequireGuestProvisionSignal { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VaultSecretGroup> Secrets { get { throw null; } set { } }
        public Azure.Provisioning.Compute.WindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachinePatchStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachinePatchStatus() { }
        public Azure.Provisioning.Compute.AvailablePatchSummary AvailablePatchSummary { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.InstanceViewStatus> ConfigurationStatuses { get { throw null; } }
        public Azure.Provisioning.Compute.LastPatchInstallationSummary LastPatchInstallationSummary { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachinePlacement : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachinePlacement() { }
        public Azure.Provisioning.BicepList<string> ExcludeZones { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> IncludeZones { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ZonePlacementPolicy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualMachinePriorityType
    {
        Regular = 0,
        Low = 1,
        Spot = 2,
    }
    public partial class VirtualMachinePublicIPAddressConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachinePublicIPAddressConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ComputeDeleteOption> DeleteOption { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachinePublicIPAddressDnsSettingsConfiguration DnsSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IdleTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VirtualMachineIPTag> IPTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.IPVersion> PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.PublicIPAllocationMethod> PublicIPAllocationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PublicIPPrefixId { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ComputePublicIPAddressSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachinePublicIPAddressDnsSettingsConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachinePublicIPAddressDnsSettingsConfiguration() { }
        public Azure.Provisioning.BicepValue<string> DomainNameLabel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DomainNameLabelScopeType> DomainNameLabelScope { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineRunCommand : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualMachineRunCommand(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AsyncExecution { get { throw null; } set { } }
        public Azure.Provisioning.Compute.RunCommandManagedIdentity ErrorBlobManagedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ErrorBlobUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Compute.VirtualMachineRunCommandInstanceView InstanceView { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Compute.RunCommandManagedIdentity OutputBlobManagedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> OutputBlobUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.RunCommandInputParameter> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachine? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.RunCommandInputParameter> ProtectedParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RunAsPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RunAsUser { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineRunCommandScriptSource Source { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TreatFailureAsDeploymentFailure { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.VirtualMachineRunCommand FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_04_01;
        }
    }
    public partial class VirtualMachineRunCommandInstanceView : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineRunCommandInstanceView() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Error { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ExecutionMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ExecutionState> ExecutionState { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ExitCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Output { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.InstanceViewStatus> Statuses { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineRunCommandScriptSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineRunCommandScriptSource() { }
        public Azure.Provisioning.BicepValue<string> CommandId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GalleryScriptReferenceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Script { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ScriptShellType> ScriptShell { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ScriptUri { get { throw null; } set { } }
        public Azure.Provisioning.Compute.RunCommandManagedIdentity ScriptUriManagedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineScaleSet : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualMachineScaleSet(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachinePlacement Placement { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ComputePlan Plan { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSetProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ComputeSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.VirtualMachineScaleSet FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_04_01;
        }
    }
    public partial class VirtualMachineScaleSetDataDisk : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineScaleSetDataDisk() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.CachingType> Caching { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiskCreateOptionType> CreateOption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiskDeleteOptionType> DeleteOption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> DiskIopsReadWrite { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> DiskMBpsReadWrite { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DiskSizeGB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Lun { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSetManagedDisk ManagedDisk { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> WriteAcceleratorEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineScaleSetExtension : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualMachineScaleSetExtension(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AutoUpgradeMinorVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableAutomaticUpgrade { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExtensionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ForceUpdateTag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Compute.KeyVaultSecretReference KeyVaultProtectedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSet? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ProtectedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ProvisionAfterExtensions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Settings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SuppressFailures { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TypeHandlerVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.VirtualMachineScaleSetExtension FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_04_01;
        }
    }
    public partial class VirtualMachineScaleSetExtensionProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineScaleSetExtensionProfile() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VirtualMachineScaleSetExtension> Extensions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExtensionsTimeBudget { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineScaleSetIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineScaleSetIPConfiguration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> ApplicationGatewayBackendAddressPools { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> ApplicationSecurityGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> LoadBalancerBackendAddressPools { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> LoadBalancerInboundNatPools { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Primary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.IPVersion> PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSetPublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineScaleSetIPTag : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineScaleSetIPTag() { }
        public Azure.Provisioning.BicepValue<string> IPTagType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tag { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineScaleSetManagedDisk : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineScaleSetManagedDisk() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineDiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.StorageAccountType> StorageAccountType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineScaleSetMigrationInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineScaleSetMigrationInfo() { }
        public Azure.Provisioning.Compute.DefaultVirtualMachineScaleSetInfo DefaultVirtualMachineScaleSetInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> MigrateToVirtualMachineScaleSetId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineScaleSetNetworkConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineScaleSetNetworkConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ComputeNetworkInterfaceAuxiliaryMode> AuxiliaryMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ComputeNetworkInterfaceAuxiliarySku> AuxiliarySku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ComputeDeleteOption> DeleteOption { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DnsServers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableAcceleratedNetworking { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableFpga { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableIPForwarding { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VirtualMachineScaleSetIPConfiguration> IPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsTcpStateTrackingDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NetworkSecurityGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Primary { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineScaleSetNetworkProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineScaleSetNetworkProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> HealthProbeId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.NetworkApiVersion> NetworkApiVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VirtualMachineScaleSetNetworkConfiguration> NetworkInterfaceConfigurations { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineScaleSetOSDisk : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineScaleSetOSDisk() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.CachingType> Caching { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiskCreateOptionType> CreateOption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiskDeleteOptionType> DeleteOption { get { throw null; } set { } }
        public Azure.Provisioning.Compute.DiffDiskSettings DiffDiskSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DiskSizeGB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ImageUri { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSetManagedDisk ManagedDisk { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.SupportedOperatingSystemType> OSType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> VhdContainers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> WriteAcceleratorEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineScaleSetOSProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineScaleSetOSProfile() { }
        public Azure.Provisioning.BicepValue<string> AdminPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AdminUsername { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowExtensionOperations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ComputerNamePrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomData { get { throw null; } set { } }
        public Azure.Provisioning.Compute.LinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RequireGuestProvisionSignal { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VaultSecretGroup> Secrets { get { throw null; } set { } }
        public Azure.Provisioning.Compute.WindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineScaleSetPriorityMixPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineScaleSetPriorityMixPolicy() { }
        public Azure.Provisioning.BicepValue<int> BaseRegularPriorityCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RegularPriorityPercentageAboveBase { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineScaleSetProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineScaleSetProperties() { }
        public Azure.Provisioning.Compute.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.Provisioning.Compute.AutomaticRepairsPolicy AutomaticRepairsPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DoNotRunExtensionsOnOverprovisionedVms { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.HighSpeedInterconnectPlacement> HighSpeedInterconnectPlacement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> HostGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsMaximumCapacityConstrained { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.OrchestrationMode> OrchestrationMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Overprovision { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PlatformFaultDomainCount { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSetPriorityMixPolicy PriorityMixPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ResiliencyPolicy ResiliencyPolicy { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ScaleInPolicy ScaleInPolicy { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ScheduledEventsPolicy ScheduledEventsPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SinglePlacementGroup { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ComputeSkuProfile SkuProfile { get { throw null; } set { } }
        public Azure.Provisioning.Compute.SpotRestorePolicy SpotRestorePolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TimeCreated { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UniqueId { get { throw null; } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSetUpgradePolicy UpgradePolicy { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSetVmProfile VirtualMachineProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ZonalPlatformFaultDomainAlignMode> ZonalPlatformFaultDomainAlignMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ZoneBalance { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineScaleSetPublicIPAddressConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineScaleSetPublicIPAddressConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ComputeDeleteOption> DeleteOption { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings DnsSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IdleTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VirtualMachineScaleSetIPTag> IPTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.IPVersion> PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PublicIPPrefixId { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ComputePublicIPAddressSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings() { }
        public Azure.Provisioning.BicepValue<string> DomainNameLabel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DomainNameLabelScopeType> DomainNameLabelScope { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualMachineScaleSetScaleInRule
    {
        Default = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="OldestVM")]
        OldestVm = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="NewestVM")]
        NewestVm = 2,
    }
    public partial class VirtualMachineScaleSetStorageProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineScaleSetStorageProfile() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VirtualMachineScaleSetDataDisk> DataDisks { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DiskControllerType { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSetOSDisk OSDisk { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualMachineScaleSetUpgradeMode
    {
        Automatic = 0,
        Manual = 1,
        Rolling = 2,
    }
    public partial class VirtualMachineScaleSetUpgradePolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineScaleSetUpgradePolicy() { }
        public Azure.Provisioning.Compute.AutomaticOSUpgradePolicy AutomaticOSUpgradePolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.VirtualMachineScaleSetUpgradeMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.Compute.RollingUpgradePolicy RollingUpgradePolicy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineScaleSetVm : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualMachineScaleSetVm(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InstanceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSet? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ComputePlan Plan { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSetVmProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VirtualMachineExtension> Resources { get { throw null; } }
        public Azure.Provisioning.Compute.ComputeSku Sku { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.VirtualMachineScaleSetVm FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_04_01;
        }
    }
    public partial class VirtualMachineScaleSetVmExtension : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualMachineScaleSetVmExtension(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AutoUpgradeMinorVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableAutomaticUpgrade { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExtensionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ForceUpdateTag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Compute.VirtualMachineExtensionInstanceView InstanceView { get { throw null; } set { } }
        public Azure.Provisioning.Compute.KeyVaultSecretReference KeyVaultProtectedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSetVm? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ProtectedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ProvisionAfterExtensions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Settings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SuppressFailures { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TypeHandlerVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.VirtualMachineScaleSetVmExtension FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_04_01;
        }
    }
    public partial class VirtualMachineScaleSetVmInstanceView : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineScaleSetVmInstanceView() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AssignedHost { get { throw null; } }
        public Azure.Provisioning.Compute.BootDiagnosticsInstanceView BootDiagnostics { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ComputerName { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.DiskInstanceView> Disks { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VirtualMachineExtensionInstanceView> Extensions { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.HyperVGeneration> HyperVGeneration { get { throw null; } }
        public Azure.Provisioning.Compute.MaintenanceRedeployStatus MaintenanceRedeployStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OSName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OSVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PlacementGroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> PlatformFaultDomain { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> PlatformUpdateDomain { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RdpThumbPrint { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.InstanceViewStatus> Statuses { get { throw null; } }
        public Azure.Provisioning.Compute.VirtualMachineAgentInstanceView VmAgent { get { throw null; } }
        public Azure.Provisioning.Compute.InstanceViewStatus VmHealthStatus { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineScaleSetVmProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineScaleSetVmProfile() { }
        public Azure.Provisioning.BicepValue<double> BillingMaxPrice { get { throw null; } set { } }
        public Azure.Provisioning.Compute.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CapacityReservationGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.VirtualMachineEvictionPolicyType> EvictionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSetExtensionProfile ExtensionProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VirtualMachineGalleryApplication> GalleryApplications { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineSizeProperties HardwareVmSizeProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LicenseType { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSetNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSetOSProfile OSProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.VirtualMachinePriorityType> Priority { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ComputeScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ComputeSecurityPostureReference SecurityPostureReference { get { throw null; } set { } }
        public Azure.Provisioning.Compute.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ServiceArtifactReferenceId { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSetStorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TimeCreated { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UserData { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineScaleSetVmProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineScaleSetVmProperties() { }
        public Azure.Provisioning.Compute.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AvailabilitySetId { get { throw null; } set { } }
        public Azure.Provisioning.Compute.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineHardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSetVmInstanceView InstanceView { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> LatestModelApplied { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LicenseType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModelDefinitionApplied { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VirtualMachineScaleSetNetworkConfiguration> NetworkInterfaceConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineOSProfile OSProfile { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSetVmProtectionPolicy ProtectionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.ResilientVmDeletionStatus> ResilientVmDeletionStatus { get { throw null; } set { } }
        public Azure.Provisioning.Compute.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineStorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TimeCreated { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UserData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VmId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineScaleSetVmProtectionPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineScaleSetVmProtectionPolicy() { }
        public Azure.Provisioning.BicepValue<bool> ProtectFromScaleIn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ProtectFromScaleSetActions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualMachineScaleSetVmRunCommand : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualMachineScaleSetVmRunCommand(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AsyncExecution { get { throw null; } set { } }
        public Azure.Provisioning.Compute.RunCommandManagedIdentity ErrorBlobManagedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ErrorBlobUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Compute.VirtualMachineRunCommandInstanceView InstanceView { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Compute.RunCommandManagedIdentity OutputBlobManagedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> OutputBlobUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.RunCommandInputParameter> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineScaleSetVm? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.RunCommandInputParameter> ProtectedParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RunAsPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RunAsUser { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineRunCommandScriptSource Source { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TreatFailureAsDeploymentFailure { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Compute.VirtualMachineScaleSetVmRunCommand FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_04_01;
        }
    }
    public partial class VirtualMachineSizeProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineSizeProperties() { }
        public Azure.Provisioning.BicepValue<int> VCpusAvailable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> VCpusPerCore { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualMachineSizeType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Basic_A0")]
        BasicA0 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Basic_A1")]
        BasicA1 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Basic_A2")]
        BasicA2 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Basic_A3")]
        BasicA3 = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Basic_A4")]
        BasicA4 = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_A0")]
        StandardA0 = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_A1")]
        StandardA1 = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_A2")]
        StandardA2 = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_A3")]
        StandardA3 = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_A4")]
        StandardA4 = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_A5")]
        StandardA5 = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_A6")]
        StandardA6 = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_A7")]
        StandardA7 = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_A8")]
        StandardA8 = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_A9")]
        StandardA9 = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_A10")]
        StandardA10 = 15,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_A11")]
        StandardA11 = 16,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_A1_v2")]
        StandardA1V2 = 17,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_A2_v2")]
        StandardA2V2 = 18,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_A4_v2")]
        StandardA4V2 = 19,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_A8_v2")]
        StandardA8V2 = 20,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_A2m_v2")]
        StandardA2MV2 = 21,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_A4m_v2")]
        StandardA4MV2 = 22,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_A8m_v2")]
        StandardA8MV2 = 23,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_B1s")]
        StandardB1S = 24,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_B1ms")]
        StandardB1Ms = 25,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_B2s")]
        StandardB2S = 26,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_B2ms")]
        StandardB2Ms = 27,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_B4ms")]
        StandardB4Ms = 28,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_B8ms")]
        StandardB8Ms = 29,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D1")]
        StandardD1 = 30,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D2")]
        StandardD2 = 31,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D3")]
        StandardD3 = 32,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D4")]
        StandardD4 = 33,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D11")]
        StandardD11 = 34,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D12")]
        StandardD12 = 35,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D13")]
        StandardD13 = 36,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D14")]
        StandardD14 = 37,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D1_v2")]
        StandardD1V2 = 38,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D2_v2")]
        StandardD2V2 = 39,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D3_v2")]
        StandardD3V2 = 40,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D4_v2")]
        StandardD4V2 = 41,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D5_v2")]
        StandardD5V2 = 42,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D2_v3")]
        StandardD2V3 = 43,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D4_v3")]
        StandardD4V3 = 44,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D8_v3")]
        StandardD8V3 = 45,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D16_v3")]
        StandardD16V3 = 46,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D32_v3")]
        StandardD32V3 = 47,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D64_v3")]
        StandardD64V3 = 48,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D2s_v3")]
        StandardD2SV3 = 49,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D4s_v3")]
        StandardD4SV3 = 50,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D8s_v3")]
        StandardD8SV3 = 51,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D16s_v3")]
        StandardD16SV3 = 52,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D32s_v3")]
        StandardD32SV3 = 53,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D64s_v3")]
        StandardD64SV3 = 54,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D11_v2")]
        StandardD11V2 = 55,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D12_v2")]
        StandardD12V2 = 56,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D13_v2")]
        StandardD13V2 = 57,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D14_v2")]
        StandardD14V2 = 58,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D15_v2")]
        StandardD15V2 = 59,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS1")]
        StandardDS1 = 60,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS2")]
        StandardDS2 = 61,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS3")]
        StandardDS3 = 62,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS4")]
        StandardDS4 = 63,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS11")]
        StandardDS11 = 64,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS12")]
        StandardDS12 = 65,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS13")]
        StandardDS13 = 66,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS14")]
        StandardDS14 = 67,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS1_v2")]
        StandardDS1V2 = 68,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS2_v2")]
        StandardDS2V2 = 69,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS3_v2")]
        StandardDS3V2 = 70,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS4_v2")]
        StandardDS4V2 = 71,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS5_v2")]
        StandardDS5V2 = 72,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS11_v2")]
        StandardDS11V2 = 73,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS12_v2")]
        StandardDS12V2 = 74,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS13_v2")]
        StandardDS13V2 = 75,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS14_v2")]
        StandardDS14V2 = 76,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS15_v2")]
        StandardDS15V2 = 77,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS13-4_v2")]
        StandardDS134V2 = 78,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS13-2_v2")]
        StandardDS132V2 = 79,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS14-8_v2")]
        StandardDS148V2 = 80,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS14-4_v2")]
        StandardDS144V2 = 81,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E2_v3")]
        StandardE2V3 = 82,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E4_v3")]
        StandardE4V3 = 83,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E8_v3")]
        StandardE8V3 = 84,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E16_v3")]
        StandardE16V3 = 85,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E32_v3")]
        StandardE32V3 = 86,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E64_v3")]
        StandardE64V3 = 87,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E2s_v3")]
        StandardE2SV3 = 88,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E4s_v3")]
        StandardE4SV3 = 89,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E8s_v3")]
        StandardE8SV3 = 90,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E16s_v3")]
        StandardE16SV3 = 91,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E32s_v3")]
        StandardE32SV3 = 92,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E64s_v3")]
        StandardE64SV3 = 93,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E32-16_v3")]
        StandardE3216V3 = 94,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E32-8s_v3")]
        StandardE328SV3 = 95,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E64-32s_v3")]
        StandardE6432SV3 = 96,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E64-16s_v3")]
        StandardE6416SV3 = 97,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_F1")]
        StandardF1 = 98,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_F2")]
        StandardF2 = 99,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_F4")]
        StandardF4 = 100,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_F8")]
        StandardF8 = 101,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_F16")]
        StandardF16 = 102,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_F1s")]
        StandardF1S = 103,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_F2s")]
        StandardF2S = 104,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_F4s")]
        StandardF4S = 105,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_F8s")]
        StandardF8S = 106,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_F16s")]
        StandardF16S = 107,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_F2s_v2")]
        StandardF2SV2 = 108,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_F4s_v2")]
        StandardF4SV2 = 109,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_F8s_v2")]
        StandardF8SV2 = 110,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_F16s_v2")]
        StandardF16SV2 = 111,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_F32s_v2")]
        StandardF32SV2 = 112,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_F64s_v2")]
        StandardF64SV2 = 113,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_F72s_v2")]
        StandardF72SV2 = 114,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_G1")]
        StandardG1 = 115,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_G2")]
        StandardG2 = 116,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_G3")]
        StandardG3 = 117,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_G4")]
        StandardG4 = 118,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_G5")]
        StandardG5 = 119,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_GS1")]
        StandardGS1 = 120,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_GS2")]
        StandardGS2 = 121,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_GS3")]
        StandardGS3 = 122,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_GS4")]
        StandardGS4 = 123,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_GS5")]
        StandardGS5 = 124,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_GS4-8")]
        StandardGS48 = 125,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_GS4-4")]
        StandardGS44 = 126,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_GS5-16")]
        StandardGS516 = 127,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_GS5-8")]
        StandardGS58 = 128,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_H8")]
        StandardH8 = 129,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_H16")]
        StandardH16 = 130,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_H8m")]
        StandardH8M = 131,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_H16m")]
        StandardH16M = 132,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_H16r")]
        StandardH16R = 133,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_H16mr")]
        StandardH16Mr = 134,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_L4s")]
        StandardL4S = 135,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_L8s")]
        StandardL8S = 136,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_L16s")]
        StandardL16S = 137,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_L32s")]
        StandardL32S = 138,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_M64s")]
        StandardM64S = 139,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_M64ms")]
        StandardM64Ms = 140,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_M128s")]
        StandardM128S = 141,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_M128ms")]
        StandardM128Ms = 142,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_M64-32ms")]
        StandardM6432Ms = 143,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_M64-16ms")]
        StandardM6416Ms = 144,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_M128-64ms")]
        StandardM12864Ms = 145,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_M128-32ms")]
        StandardM12832Ms = 146,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_NC6")]
        StandardNC6 = 147,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_NC12")]
        StandardNC12 = 148,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_NC24")]
        StandardNC24 = 149,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_NC24r")]
        StandardNC24R = 150,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_NC6s_v2")]
        StandardNC6SV2 = 151,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_NC12s_v2")]
        StandardNC12SV2 = 152,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_NC24s_v2")]
        StandardNC24SV2 = 153,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_NC24rs_v2")]
        StandardNC24RsV2 = 154,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_NC6s_v3")]
        StandardNC6SV3 = 155,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_NC12s_v3")]
        StandardNC12SV3 = 156,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_NC24s_v3")]
        StandardNC24SV3 = 157,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_NC24rs_v3")]
        StandardNC24RsV3 = 158,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_ND6s")]
        StandardND6S = 159,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_ND12s")]
        StandardND12S = 160,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_ND24s")]
        StandardND24S = 161,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_ND24rs")]
        StandardND24Rs = 162,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_NV6")]
        StandardNV6 = 163,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_NV12")]
        StandardNV12 = 164,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_NV24")]
        StandardNV24 = 165,
    }
    public partial class VirtualMachineStorageProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualMachineStorageProfile() { }
        public Azure.Provisioning.BicepValue<bool> AlignRegionalDisksToVmZone { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.VirtualMachineDataDisk> DataDisks { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.DiskControllerType> DiskControllerType { get { throw null; } set { } }
        public Azure.Provisioning.Compute.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.Provisioning.Compute.VirtualMachineOSDisk OSDisk { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VmssRebalanceBehavior
    {
        CreateBeforeDelete = 0,
    }
    public enum VmssRebalanceStrategy
    {
        Recreate = 0,
    }
    public partial class WindowsConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WindowsConfiguration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.AdditionalUnattendContent> AdditionalUnattendContent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAutomaticUpdatesEnabled { get { throw null; } set { } }
        public Azure.Provisioning.Compute.PatchSettings PatchSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ProvisionVmAgent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeZone { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Compute.WinRMListener> WinRMListeners { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WindowsPatchAssessmentMode
    {
        ImageDefault = 0,
        AutomaticByPlatform = 1,
    }
    public enum WindowsVmGuestPatchAutomaticByPlatformRebootSetting
    {
        Unknown = 0,
        IfRequired = 1,
        Never = 2,
        Always = 3,
    }
    public partial class WindowsVmGuestPatchAutomaticByPlatformSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WindowsVmGuestPatchAutomaticByPlatformSettings() { }
        public Azure.Provisioning.BicepValue<bool> BypassPlatformSafetyChecksOnUserSchedule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.WindowsVmGuestPatchAutomaticByPlatformRebootSetting> RebootSetting { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WindowsVmGuestPatchMode
    {
        Manual = 0,
        AutomaticByOS = 1,
        AutomaticByPlatform = 2,
    }
    public partial class WinRMListener : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WinRMListener() { }
        public Azure.Provisioning.BicepValue<System.Uri> CertificateUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Compute.WinRMListenerProtocolType> Protocol { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WinRMListenerProtocolType
    {
        Http = 0,
        Https = 1,
    }
    public enum ZonalPlatformFaultDomainAlignMode
    {
        Aligned = 0,
        Unaligned = 1,
    }
    public partial class ZoneAllocationPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ZoneAllocationPolicy() { }
        public Azure.Provisioning.Compute.MaxInstancePercentPerZonePolicy MaxInstancePercentPerZonePolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxZoneCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
