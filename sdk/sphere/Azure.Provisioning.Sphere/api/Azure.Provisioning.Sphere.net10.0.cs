namespace Azure.Provisioning.Sphere
{
    public enum RegionalDataBoundary
    {
        None = 0,
        EU = 1,
    }
    public enum SphereAllowCrashDumpCollectionStatus
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class SphereCatalog : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SphereCatalog(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sphere.SphereProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sphere.SphereCatalog FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class SphereCertificate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SphereCertificate() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Certificate { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiryUtc { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NotBeforeUtc { get { throw null; } }
        public Azure.Provisioning.Sphere.SphereCatalog Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sphere.SphereProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sphere.SphereCertificateStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Subject { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sphere.SphereCertificate FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public enum SphereCertificateStatus
    {
        Active = 0,
        Inactive = 1,
        Expired = 2,
        Revoked = 3,
    }
    public partial class SphereDeployment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SphereDeployment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Sphere.SphereImage> DeployedImages { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> DeploymentDateUtc { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DeploymentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sphere.SphereDeviceGroup Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sphere.SphereProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sphere.SphereDeployment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class SphereDevice : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SphereDevice(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ChipSku { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DeviceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastAvailableOSVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastInstalledOSVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastOSUpdateUtc { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdateRequestUtc { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sphere.SphereDeviceGroup Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sphere.SphereProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sphere.SphereDevice FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class SphereDeviceGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SphereDeviceGroup(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sphere.SphereAllowCrashDumpCollectionStatus> AllowCrashDumpsCollection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> HasDeployment { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sphere.SphereOSFeedType> OSFeedType { get { throw null; } set { } }
        public Azure.Provisioning.Sphere.SphereProduct Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sphere.SphereProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sphere.RegionalDataBoundary> RegionalDataBoundary { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sphere.SphereUpdatePolicy> UpdatePolicy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sphere.SphereDeviceGroup FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public partial class SphereImage : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SphereImage(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ComponentId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Image { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ImageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ImageName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sphere.SphereImageType> ImageType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sphere.SphereCatalog Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sphere.SphereProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sphere.RegionalDataBoundary> RegionalDataBoundary { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sphere.SphereImage FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public enum SphereImageType
    {
        InvalidImageType = 0,
        OneBl = 1,
        PlutonRuntime = 2,
        WifiFirmware = 3,
        SecurityMonitor = 4,
        NormalWorldLoader = 5,
        NormalWorldDtb = 6,
        NormalWorldKernel = 7,
        RootFs = 8,
        Services = 9,
        Applications = 10,
        FwConfig = 11,
        BootManifest = 12,
        Nwfs = 13,
        TrustedKeystore = 14,
        Policy = 15,
        CustomerBoardConfig = 16,
        UpdateCertStore = 17,
        BaseSystemUpdateManifest = 18,
        FirmwareUpdateManifest = 19,
        CustomerUpdateManifest = 20,
        RecoveryManifest = 21,
        ManifestSet = 22,
        Other = 23,
    }
    public enum SphereOSFeedType
    {
        Retail = 0,
        RetailEval = 1,
    }
    public partial class SphereProduct : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SphereProduct(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Sphere.SphereCatalog Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Sphere.SphereProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Sphere.SphereProduct FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_04_01;
        }
    }
    public enum SphereProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Provisioning = 3,
        Updating = 4,
        Deleting = 5,
        Accepted = 6,
    }
    public enum SphereUpdatePolicy
    {
        UpdateAll = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="No3rdPartyAppUpdates")]
        No3RdPartyAppUpdates = 1,
    }
}
