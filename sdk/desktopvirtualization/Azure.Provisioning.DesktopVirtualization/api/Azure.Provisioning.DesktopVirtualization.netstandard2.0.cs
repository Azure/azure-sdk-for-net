namespace Azure.Provisioning.DesktopVirtualization
{
    public partial class ActiveSessionHostConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal ActiveSessionHostConfiguration() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.DesktopVirtualization.HostPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.ActiveSessionHostConfigurationProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DesktopVirtualization.ActiveSessionHostConfiguration FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
    public partial class ActiveSessionHostConfigurationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ActiveSessionHostConfigurationProperties() { }
        public Azure.Provisioning.BicepList<int> AvailabilityZones { get { throw null; } }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationBootDiagnosticsInfoProperties BootDiagnosticsInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> CustomConfigurationScriptUri { get { throw null; } }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationDiskInfoProperties DiskInfo { get { throw null; } }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationDomainInfoProperties DomainInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationImageInfoProperties ImageInfo { get { throw null; } }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationNetworkInfoProperties NetworkInfo { get { throw null; } }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationSecurityInfoProperties SecurityInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Version { get { throw null; } }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationKeyVaultCredentialsProperties VmAdminCredentials { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> VmLocation { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VmNamePrefix { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VmResourceGroup { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VmSizeId { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> VmTags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppAttachPackage : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AppAttachPackage(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.AppAttachPackageProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DesktopVirtualization.AppAttachPackage FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
    public partial class AppAttachPackageInfoProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppAttachPackageInfoProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CertificateExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CertificateName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ImagePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsActive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.PackageTimestamped> IsPackageTimestamped { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRegularRegistration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PackageAlias { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DesktopVirtualization.MsixPackageApplications> PackageApplications { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DesktopVirtualization.MsixPackageDependencies> PackageDependencies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PackageFamilyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PackageFullName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PackageName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PackageRelativePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppAttachPackageProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppAttachPackageProperties() { }
        public Azure.Provisioning.BicepValue<string> CustomData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationDeploymentScope> DeploymentScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.FailHealthCheckOnStagingFailure> FailHealthCheckOnStagingFailure { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> HostPoolReferences { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.AppAttachPackageInfoProperties Image { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyVaultUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> PackageLookbackUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PackageOwnerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.AppAttachPackageProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AppAttachPackageProvisioningState
    {
        Succeeded = 0,
        Provisioning = 1,
        Failed = 2,
        Canceled = 3,
    }
    public partial class DesktopVirtualizationActiveDirectoryInfoProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DesktopVirtualizationActiveDirectoryInfoProperties() { }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationKeyVaultCredentialsProperties DomainCredentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DomainName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OuPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DesktopVirtualizationAllowRdpShortPathWithPrivateLink
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class DesktopVirtualizationBootDiagnosticsInfoProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DesktopVirtualizationBootDiagnosticsInfoProperties() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> StorageUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DesktopVirtualizationCanaryPolicy
    {
        Auto = 0,
        Never = 1,
        Always = 2,
    }
    public partial class DesktopVirtualizationCreateDeleteProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DesktopVirtualizationCreateDeleteProperties() { }
        public Azure.Provisioning.BicepValue<int> RampDownMaximumHostPoolSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RampDownMinimumHostPoolSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RampUpMaximumHostPoolSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RampUpMinimumHostPoolSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DesktopVirtualizationDayOfWeek
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6,
    }
    public enum DesktopVirtualizationDeploymentScope
    {
        Geographical = 0,
        Regional = 1,
    }
    public enum DesktopVirtualizationDiffDiskOption
    {
        Local = 0,
    }
    public enum DesktopVirtualizationDiffDiskPlacement
    {
        CacheDisk = 0,
        TempDisk = 1,
    }
    public partial class DesktopVirtualizationDiffDiskProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DesktopVirtualizationDiffDiskProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationDiffDiskOption> Option { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationDiffDiskPlacement> Placement { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DesktopVirtualizationDirectUdp
    {
        Default = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public partial class DesktopVirtualizationDiskInfoProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DesktopVirtualizationDiskInfoProperties() { }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationDiffDiskProperties DiffDiskSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationVirtualMachineDiskType> ManagedDiskType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DesktopVirtualizationDomainInfoProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DesktopVirtualizationDomainInfoProperties() { }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationActiveDirectoryInfoProperties ActiveDirectoryInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureActiveDirectoryInfoMdmProviderGuid { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationDomainJoinType> JoinType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DesktopVirtualizationDomainJoinType
    {
        ActiveDirectory = 0,
        AzureActiveDirectory = 1,
    }
    public partial class DesktopVirtualizationImageInfoProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DesktopVirtualizationImageInfoProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CustomInfoResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationImageType> ImageType { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationMarketplaceInfoProperties MarketplaceInfo { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DesktopVirtualizationImageType
    {
        Marketplace = 0,
        Custom = 1,
    }
    public partial class DesktopVirtualizationKeyVaultCredentialsProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DesktopVirtualizationKeyVaultCredentialsProperties() { }
        public Azure.Provisioning.BicepValue<System.Uri> PasswordKeyVaultSecretUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> UsernameKeyVaultSecretUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DesktopVirtualizationManagedPrivateUdp
    {
        Default = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public enum DesktopVirtualizationManagementType
    {
        Automated = 0,
        Standard = 1,
    }
    public partial class DesktopVirtualizationMarketplaceInfoProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DesktopVirtualizationMarketplaceInfoProperties() { }
        public Azure.Provisioning.BicepValue<string> ExactVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Offer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sku { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DesktopVirtualizationNetworkInfoProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DesktopVirtualizationNetworkInfoProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SecurityGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DesktopVirtualizationPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DesktopVirtualizationPrivateEndpointConnection() { }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationPrivateLinkServiceConnectionState ConnectionState { get { throw null; } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> Type { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DesktopVirtualizationPrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public enum DesktopVirtualizationPrivateEndpointServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
    }
    public partial class DesktopVirtualizationPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DesktopVirtualizationPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationPrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DesktopVirtualizationPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum DesktopVirtualizationPublicUdp
    {
        Default = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public enum DesktopVirtualizationRelayUdp
    {
        Default = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public enum DesktopVirtualizationScalingMethodType
    {
        PowerManage = 0,
        CreateDeletePowerManage = 1,
    }
    public partial class DesktopVirtualizationSecurityInfoProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DesktopVirtualizationSecurityInfoProperties() { }
        public Azure.Provisioning.BicepValue<bool> IsSecureBootEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVTpmEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationVirtualMachineSecurityType> Type { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DesktopVirtualizationSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DesktopVirtualizationSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DesktopVirtualizationSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    public enum DesktopVirtualizationStopHostsWhen
    {
        ZeroSessions = 0,
        ZeroActiveSessions = 1,
    }
    public enum DesktopVirtualizationVirtualMachineDiskType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_LRS")]
        StandardLRS = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Premium_LRS")]
        PremiumLRS = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="StandardSSD_LRS")]
        StandardSSDLRS = 2,
    }
    public enum DesktopVirtualizationVirtualMachineSecurityType
    {
        Standard = 0,
        TrustedLaunch = 1,
        ConfidentialVM = 2,
    }
    public enum FailHealthCheckOnStagingFailure
    {
        Unhealthy = 0,
        NeedsAssistance = 1,
        DoNotFail = 2,
    }
    public partial class HostPool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public HostPool(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.DesktopVirtualization.SessionHostAgentUpdateProperties AgentUpdate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationAllowRdpShortPathWithPrivateLink> AllowRdpShortPathWithPrivateLink { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AppAttachPackageReferences { get { throw null; } }
        public Azure.Provisioning.BicepList<string> ApplicationGroupReferences { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ConditionalRdpProperty { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomRdpProperty { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationDeploymentScope> DeploymentScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationDirectUdp> DirectUdp { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.HostPoolType> HostPoolType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsCloudPCResource { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsValidationEnvironment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.HostPoolLoadBalancerType> LoadBalancerType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationManagedPrivateUdp> ManagedPrivateUdp { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationManagementType> ManagementType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxSessionLimit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ObjectId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OboTenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.PersonalDesktopAssignmentType> PersonalDesktopAssignmentType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ArmPlan Plan { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.PreferredAppGroupType> PreferredAppGroupType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.HostPoolPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationPublicUdp> PublicUdp { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.HostPoolRegistrationInfo RegistrationInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationRelayUdp> RelayUdp { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Ring { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SsoAdfsAuthority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SsoClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SsoClientSecretKeyVaultPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.HostPoolSsoSecretType> SsoSecretType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> StartVmOnConnect { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VmTemplate { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DesktopVirtualization.HostPool FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
    public enum HostPoolLoadBalancerType
    {
        BreadthFirst = 0,
        DepthFirst = 1,
        Persistent = 2,
        MultiplePersistent = 3,
    }
    public partial class HostPoolPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public HostPoolPrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.HostPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DesktopVirtualization.HostPoolPrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
    public enum HostPoolPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
        EnabledForSessionHostsOnly = 2,
        EnabledForClientsOnly = 3,
    }
    public partial class HostPoolRegistrationInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HostPoolRegistrationInfo() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.HostPoolRegistrationTokenOperation> RegistrationTokenOperation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Token { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HostPoolRegistrationTokenOperation
    {
        Delete = 0,
        None = 1,
        Update = 2,
    }
    public enum HostPoolSsoSecretType
    {
        SharedKey = 0,
        Certificate = 1,
        SharedKeyInKeyVault = 2,
        CertificateInKeyVault = 3,
    }
    public enum HostPoolType
    {
        Personal = 0,
        Pooled = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="BYODesktop")]
        BringYourOwnDesktop = 2,
    }
    public partial class HostPoolUpdateConfigurationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HostPoolUpdateConfigurationProperties() { }
        public Azure.Provisioning.BicepValue<int> LogOffDelayMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LogOffMessage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxVmsRemoved { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ShouldDeleteOriginalVm { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MsixPackage : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MsixPackage(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ImagePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsActive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRegularRegistration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DesktopVirtualization.MsixPackageApplications> PackageApplications { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DesktopVirtualization.MsixPackageDependencies> PackageDependencies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PackageFamilyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PackageName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PackageRelativePath { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.HostPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DesktopVirtualization.MsixPackage FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
    public partial class MsixPackageApplications : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MsixPackageApplications() { }
        public Azure.Provisioning.BicepValue<string> AppId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AppUserModelId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IconImageName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> RawIcon { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> RawPng { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MsixPackageDependencies : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MsixPackageDependencies() { }
        public Azure.Provisioning.BicepValue<string> DependencyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MinVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Publisher { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PackageTimestamped
    {
        Timestamped = 0,
        NotTimestamped = 1,
    }
    public enum PersonalDesktopAssignmentType
    {
        Automatic = 0,
        Direct = 1,
    }
    public enum PreferredAppGroupType
    {
        None = 0,
        Desktop = 1,
        RailApplications = 2,
    }
    public enum RemoteApplicationType
    {
        InBuilt = 0,
        MsixApplication = 1,
    }
    public partial class ScalingActionTime : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScalingActionTime() { }
        public Azure.Provisioning.BicepValue<int> Hour { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Minute { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ScalingHostPoolReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScalingHostPoolReference() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> HostPoolId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsScalingPlanEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ScalingHostPoolType
    {
        Pooled = 0,
        Personal = 1,
    }
    public partial class ScalingPlan : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ScalingPlan(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ExclusionTag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DesktopVirtualization.ScalingHostPoolReference> HostPoolReferences { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ObjectId { get { throw null; } }
        public Azure.Provisioning.Resources.ArmPlan Plan { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.ScalingHostPoolType> ScalingHostPoolType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DesktopVirtualization.ScalingSchedule> Schedules { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeZone { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DesktopVirtualization.ScalingPlan FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
    public partial class ScalingPlanPersonalSchedule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ScalingPlanPersonalSchedule(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationDayOfWeek> DaysOfWeek { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHandlingOperation> OffPeakActionOnDisconnect { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHandlingOperation> OffPeakActionOnLogoff { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> OffPeakMinutesToWaitOnDisconnect { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> OffPeakMinutesToWaitOnLogoff { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.ScalingActionTime OffPeakStartTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SetStartVmOnConnect> OffPeakStartVmOnConnect { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.ScalingPlan Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHandlingOperation> PeakActionOnDisconnect { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHandlingOperation> PeakActionOnLogoff { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PeakMinutesToWaitOnDisconnect { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PeakMinutesToWaitOnLogoff { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.ScalingActionTime PeakStartTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SetStartVmOnConnect> PeakStartVmOnConnect { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHandlingOperation> RampDownActionOnDisconnect { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHandlingOperation> RampDownActionOnLogoff { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RampDownMinutesToWaitOnDisconnect { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RampDownMinutesToWaitOnLogoff { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.ScalingActionTime RampDownStartTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SetStartVmOnConnect> RampDownStartVmOnConnect { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHandlingOperation> RampUpActionOnDisconnect { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHandlingOperation> RampUpActionOnLogoff { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.StartupBehavior> RampUpAutoStartHosts { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RampUpMinutesToWaitOnDisconnect { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RampUpMinutesToWaitOnLogoff { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.ScalingActionTime RampUpStartTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SetStartVmOnConnect> RampUpStartVmOnConnect { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DesktopVirtualization.ScalingPlanPersonalSchedule FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
    public partial class ScalingPlanPooledSchedule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ScalingPlanPooledSchedule(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationCreateDeleteProperties CreateDelete { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationDayOfWeek> DaysOfWeek { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHostLoadBalancingAlgorithm> OffPeakLoadBalancingAlgorithm { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.ScalingActionTime OffPeakStartTime { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.ScalingPlan Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHostLoadBalancingAlgorithm> PeakLoadBalancingAlgorithm { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.ScalingActionTime PeakStartTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RampDownCapacityThresholdPct { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RampDownForceLogoffUsers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHostLoadBalancingAlgorithm> RampDownLoadBalancingAlgorithm { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RampDownMinimumHostsPct { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RampDownNotificationMessage { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.ScalingActionTime RampDownStartTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationStopHostsWhen> RampDownStopHostsWhen { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RampDownWaitTimeMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RampUpCapacityThresholdPct { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHostLoadBalancingAlgorithm> RampUpLoadBalancingAlgorithm { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RampUpMinimumHostsPct { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.ScalingActionTime RampUpStartTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationScalingMethodType> ScalingMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScheduleName { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DesktopVirtualization.ScalingPlanPooledSchedule FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
    public partial class ScalingSchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScalingSchedule() { }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationCreateDeleteProperties CreateDelete { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DesktopVirtualization.ScalingScheduleDaysOfWeekItem> DaysOfWeek { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHostLoadBalancingAlgorithm> OffPeakLoadBalancingAlgorithm { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.ScalingActionTime OffPeakStartTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHostLoadBalancingAlgorithm> PeakLoadBalancingAlgorithm { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.ScalingActionTime PeakStartTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RampDownCapacityThresholdPct { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RampDownForceLogoffUsers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHostLoadBalancingAlgorithm> RampDownLoadBalancingAlgorithm { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RampDownMinimumHostsPct { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RampDownNotificationMessage { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.ScalingActionTime RampDownStartTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationStopHostsWhen> RampDownStopHostsWhen { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RampDownWaitTimeMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RampUpCapacityThresholdPct { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHostLoadBalancingAlgorithm> RampUpLoadBalancingAlgorithm { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RampUpMinimumHostsPct { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.ScalingActionTime RampUpStartTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationScalingMethodType> ScalingMethod { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ScalingScheduleDaysOfWeekItem
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6,
    }
    public enum SessionHandlingOperation
    {
        None = 0,
        Deallocate = 1,
        Hibernate = 2,
    }
    public partial class SessionHost : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SessionHost(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> ActiveSessions { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> AgentVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> AllowNewSession { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AssignedUser { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DisconnectedSessions { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastHeartBeatOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastSessionHostUpdateOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ObjectId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OSVersion { get { throw null; } }
        public Azure.Provisioning.DesktopVirtualization.HostPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PendingSessions { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SessionHostConfiguration { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DesktopVirtualization.SessionHostHealthCheckReport> SessionHostHealthCheckResults { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Sessions { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHostStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StatusTimestamp { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SxsStackVersion { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UpdateErrorMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHostUpdateState> UpdateState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VmId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DesktopVirtualization.SessionHost FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
    public partial class SessionHostAgentUpdateProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SessionHostAgentUpdateProperties() { }
        public Azure.Provisioning.BicepValue<bool> DoesUseSessionHostLocalTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DesktopVirtualization.SessionHostMaintenanceWindowProperties> MaintenanceWindows { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MaintenanceWindowTimeZone { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHostComponentUpdateType> UpdateType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SessionHostComponentUpdateType
    {
        Default = 0,
        Scheduled = 1,
    }
    public partial class SessionHostConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SessionHostConfiguration(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.DesktopVirtualization.HostPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.SessionHostConfigurationProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DesktopVirtualization.SessionHostConfiguration FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
    public enum SessionHostConfigurationFailedSessionHostCleanupPolicy
    {
        KeepAll = 0,
        KeepOne = 1,
        KeepNone = 2,
    }
    public partial class SessionHostConfigurationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SessionHostConfigurationProperties() { }
        public Azure.Provisioning.BicepList<int> AvailabilityZones { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationBootDiagnosticsInfoProperties BootDiagnosticsInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> CustomConfigurationScriptUri { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationDiskInfoProperties DiskInfo { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationDomainInfoProperties DomainInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationImageInfoProperties ImageInfo { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationNetworkInfoProperties NetworkInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHostConfigurationProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationSecurityInfoProperties SecurityInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Version { get { throw null; } }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationKeyVaultCredentialsProperties VmAdminCredentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> VmLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VmNamePrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VmResourceGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VmSizeId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> VmTags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SessionHostConfigurationProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Provisioning = 3,
    }
    public partial class SessionHostHealthCheckFailureDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SessionHostHealthCheckFailureDetails() { }
        public Azure.Provisioning.BicepValue<int> ErrorCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastHealthCheckOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SessionHostHealthCheckName
    {
        DomainJoinedCheck = 0,
        DomainTrustCheck = 1,
        FSLogixHealthCheck = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SxSStackListenerCheck")]
        SxsStackListenerCheck = 3,
        UrlsAccessibleCheck = 4,
        MonitoringAgentCheck = 5,
        DomainReachable = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="WebRTCRedirectorCheck")]
        WebRtcRedirectorCheck = 7,
        SupportedEncryptionCheck = 8,
        MetaDataServiceCheck = 9,
        AppAttachHealthCheck = 10,
    }
    public partial class SessionHostHealthCheckReport : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SessionHostHealthCheckReport() { }
        public Azure.Provisioning.DesktopVirtualization.SessionHostHealthCheckFailureDetails AdditionalFailureDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHostHealthCheckName> HealthCheckName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHostHealthCheckResult> HealthCheckResult { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SessionHostHealthCheckResult
    {
        Unknown = 0,
        HealthCheckSucceeded = 1,
        HealthCheckFailed = 2,
        SessionHostShutdown = 3,
    }
    public enum SessionHostLoadBalancingAlgorithm
    {
        BreadthFirst = 0,
        DepthFirst = 1,
    }
    public partial class SessionHostMaintenanceWindowProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SessionHostMaintenanceWindowProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationDayOfWeek> DayOfWeek { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Hour { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SessionHostManagement : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SessionHostManagement(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.DesktopVirtualization.HostPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.SessionHostManagementProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DesktopVirtualization.SessionHostManagement FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
    public partial class SessionHostManagementProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SessionHostManagementProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.SessionHostConfigurationFailedSessionHostCleanupPolicy> FailedSessionHostCleanupPolicy { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.SessionHostProvisioningConfigurationProperties Provisioning { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScheduledDateTimeZone { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.HostPoolUpdateConfigurationProperties Update { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SessionHostProvisioningConfigurationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SessionHostProvisioningConfigurationProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationCanaryPolicy> CanaryPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> InstanceCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDrainModeEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SessionHostStatus
    {
        Available = 0,
        Unavailable = 1,
        Shutdown = 2,
        Disconnected = 3,
        Upgrading = 4,
        UpgradeFailed = 5,
        NoHeartbeat = 6,
        NotJoinedToDomain = 7,
        DomainTrustRelationshipLost = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SxSStackListenerNotReady")]
        SxsStackListenerNotReady = 9,
        FSLogixNotHealthy = 10,
        NeedsAssistance = 11,
    }
    public enum SessionHostUpdateState
    {
        Initial = 0,
        Pending = 1,
        Started = 2,
        Succeeded = 3,
        Failed = 4,
    }
    public enum SetStartVmOnConnect
    {
        Enable = 0,
        Disable = 1,
    }
    public enum StartupBehavior
    {
        None = 0,
        WithAssignedUser = 1,
        All = 2,
    }
    public partial class UserSession : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal UserSession() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ActiveDirectoryUserName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.VirtualApplicationType> ApplicationType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreateOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ObjectId { get { throw null; } }
        public Azure.Provisioning.DesktopVirtualization.SessionHost Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.UserSessionState> SessionState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UserPrincipalName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DesktopVirtualization.UserSession FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
    public enum UserSessionState
    {
        Unknown = 0,
        Active = 1,
        Disconnected = 2,
        Pending = 3,
        LogOff = 4,
        UserProfileDiskMounted = 5,
    }
    public partial class VirtualApplication : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualApplication(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.RemoteApplicationType> ApplicationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CommandLineArguments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.VirtualApplicationCommandLineSetting> CommandLineSetting { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FilePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> IconContent { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> IconHash { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> IconIndex { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IconPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MsixPackageApplicationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MsixPackageFamilyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ObjectId { get { throw null; } }
        public Azure.Provisioning.DesktopVirtualization.VirtualApplicationGroup Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ShortcutsExtensionPutShortcutOnDesktop { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ShowInPortal { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DesktopVirtualization.VirtualApplication FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
    public enum VirtualApplicationCommandLineSetting
    {
        DoNotAllow = 0,
        Allow = 1,
        Require = 2,
    }
    public partial class VirtualApplicationGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualApplicationGroup(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.VirtualApplicationGroupType> ApplicationGroupType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationDeploymentScope> DeploymentScope { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> HostPoolId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsCloudPCResource { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ObjectId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OboTenantId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ArmPlan Plan { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ShowInFeed { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WorkspaceId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DesktopVirtualization.VirtualApplicationGroup FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
    public enum VirtualApplicationGroupType
    {
        RemoteApp = 0,
        Desktop = 1,
    }
    public enum VirtualApplicationType
    {
        RemoteApp = 0,
        Desktop = 1,
    }
    public partial class VirtualDesktop : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal VirtualDesktop() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> IconContent { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> IconHash { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ObjectId { get { throw null; } }
        public Azure.Provisioning.DesktopVirtualization.VirtualApplicationGroup Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DesktopVirtualization.VirtualDesktop FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
    public partial class VirtualWorkspace : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualWorkspace(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> ApplicationGroupReferences { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationDeploymentScope> DeploymentScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsCloudPCResource { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ObjectId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OboTenantId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ArmPlan Plan { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DesktopVirtualization.VirtualWorkspace FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
    public partial class WorkspacePrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WorkspacePrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DesktopVirtualization.VirtualWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DesktopVirtualization.WorkspacePrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_04_01_PREVIEW;
        }
    }
}
