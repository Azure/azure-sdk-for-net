namespace Azure.Provisioning.ContainerService
{
    public partial class AgentFabricMembership : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AgentFabricMembership(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentFabricMembershipProvisioningState> AgentFabricMembershipProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceManagedCluster Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentFabricMembershipSkuName> SkuName { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.AgentFabricMembership FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public enum AgentFabricMembershipProvisioningState
    {
        Canceled = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
        Succeeded = 4,
        Updating = 5,
    }
    public enum AgentFabricMembershipSkuName
    {
        Standard = 0,
        Premium = 1,
    }
    public partial class AgentPoolAutoScaleProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgentPoolAutoScaleProfile() { }
        public Azure.Provisioning.BicepValue<int> MaxCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AgentPoolBlueGreenUpgradeSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgentPoolBlueGreenUpgradeSettings() { }
        public Azure.Provisioning.BicepValue<int> BatchSoakDurationInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DrainBatchSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DrainTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FinalSoakDurationInMinutes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AgentPoolGpuDriver
    {
        Install = 0,
        None = 1,
    }
    public enum AgentPoolGpuDriverType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="GRID")]
        Grid = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="CUDA")]
        Cuda = 1,
    }
    public partial class AgentPoolGpuProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgentPoolGpuProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolGpuDriver> Driver { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolGpuDriverType> DriverType { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.AgentPoolNvidiaGpuProfile Nvidia { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AgentPoolMode
    {
        System = 0,
        User = 1,
        Gateway = 2,
        ManagedSystem = 3,
        Machines = 4,
    }
    public enum AgentPoolMultiInstanceGpuStrategy
    {
        None = 0,
        Single = 1,
        Mixed = 2,
    }
    public partial class AgentPoolNetworkInterface : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgentPoolNetworkInterface() { }
        public Azure.Provisioning.BicepValue<bool> EnableAcceleratedNetworking { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.AgentPoolNicPublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolNetworkInterfaceType> Type { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VnetSubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AgentPoolNetworkInterfaceType
    {
        Standard = 0,
        Dynamic = 1,
    }
    public enum AgentPoolNetworkPortProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="TCP")]
        Tcp = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UDP")]
        Udp = 1,
    }
    public partial class AgentPoolNetworkPortRange : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgentPoolNetworkPortRange() { }
        public Azure.Provisioning.BicepValue<int> PortEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PortStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolNetworkPortProtocol> Protocol { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AgentPoolNetworkProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgentPoolNetworkProfile() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.AgentPoolNetworkPortRange> AllowedHostPorts { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> ApplicationSecurityGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.DranetMode> DranetMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> NodePublicIPPrefixIDs { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ContainerServiceIPTag> NodePublicIPTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.AgentPoolNetworkInterface> SecondaryNetworkInterfaces { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AgentPoolNicPublicIPAddressConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgentPoolNicPublicIPAddressConfiguration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ContainerServiceIPTag> IPTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolNicPublicIPAddressVersion> PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PublicIPPrefixID { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AgentPoolNicPublicIPAddressVersion
    {
        IPv4 = 0,
    }
    public enum AgentPoolNodeDisruptionPolicy
    {
        Allow = 0,
        AllowDuringMaintenanceWindow = 1,
        Block = 2,
    }
    public enum AgentPoolNvidiaDriverMode
    {
        DevicePlugin = 0,
        DRA = 1,
    }
    public partial class AgentPoolNvidiaGpuProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgentPoolNvidiaGpuProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolNvidiaDriverMode> DriverMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.GpuManagementMode> ManagementMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.GpuInstanceProfile> MigProfiles { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolMultiInstanceGpuStrategy> MigStrategy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AgentPoolPodLinkLocalAccess
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="IMDS")]
        Imds = 0,
        None = 1,
    }
    public partial class AgentPoolRecentlyUsedVersion : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgentPoolRecentlyUsedVersion() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUsedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> NodeImageVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OrchestratorVersion { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AgentPoolScaleProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgentPoolScaleProfile() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.AgentPoolAutoScaleProfile> Autoscale { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ManualScaleProfile> Manual { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AgentPoolScopeEvaluation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgentPoolScopeEvaluation() { }
        public Azure.Provisioning.BicepValue<string> AgentPoolName { get { throw null; } }
        public Azure.Provisioning.ContainerService.ContainerServiceUpgradeContext Context { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CurrentKubernetesVersion { get { throw null; } }
        public Azure.Provisioning.ContainerService.UpgradeInsightEvaluation Evaluation { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> KubernetesVersionEndOfSupportOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.KubernetesVersionSupportStatus> KubernetesVersionSupportStatus { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AgentPoolSecurityProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgentPoolSecurityProfile() { }
        public Azure.Provisioning.BicepValue<bool> IsSecureBootEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVtpmEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolSshAccess> SshAccess { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AgentPoolSnapshot : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AgentPoolSnapshot(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CreationDataSourceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsFipsEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> KubernetesVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeImageVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOSSku> OSSku { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOSType> OSType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.SnapshotType> SnapshotType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VmSize { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.AgentPoolSnapshot FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_01;
            public static readonly string V2026_01_01;
            public static readonly string V2026_02_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_04_01;
            public static readonly string V2026_05_01;
            public static readonly string V2026_06_01;
            public static readonly string V2026_07_01;
            public static readonly string V2026_08_01;
            public static readonly string V2026_09_01;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public enum AgentPoolSshAccess
    {
        LocalUser = 0,
        Disabled = 1,
        EntraId = 2,
    }
    public enum AgentPoolType
    {
        VirtualMachineScaleSets = 0,
        AvailabilitySet = 1,
        VirtualMachines = 2,
        FlexNodes = 3,
    }
    public partial class AgentPoolUpgradeInsightProperties : Azure.Provisioning.ContainerService.UpgradeInsightProperties
    {
        public AgentPoolUpgradeInsightProperties() { }
        public Azure.Provisioning.BicepValue<string> AgentPoolName { get { throw null; } }
        public Azure.Provisioning.ContainerService.ContainerServiceUpgradeContext Context { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CurrentKubernetesVersion { get { throw null; } }
        public Azure.Provisioning.ContainerService.UpgradeInsightEvaluation Evaluation { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> KubernetesVersionEndOfSupportOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.KubernetesVersionSupportStatus> KubernetesVersionSupportStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TargetKubernetesVersion { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AgentPoolUpgradeProfile : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal AgentPoolUpgradeProfile() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.KubernetesVersionComponents> ComponentsByReleases { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> KubernetesVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LatestNodeImageVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOSType> OSType { get { throw null; } }
        public Azure.Provisioning.ContainerService.ContainerServiceAgentPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.AgentPoolRecentlyUsedVersion> RecentlyUsedVersions { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.AgentPoolUpgradeProfilePropertiesUpgradesItem> Upgrades { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.AgentPoolUpgradeProfile FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_01;
            public static readonly string V2026_01_01;
            public static readonly string V2026_02_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_04_01;
            public static readonly string V2026_05_01;
            public static readonly string V2026_06_01;
            public static readonly string V2026_07_01;
            public static readonly string V2026_08_01;
            public static readonly string V2026_09_01;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public partial class AgentPoolUpgradeProfilePropertiesUpgradesItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgentPoolUpgradeProfilePropertiesUpgradesItem() { }
        public Azure.Provisioning.BicepValue<bool> IsOutOfSupport { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsPreview { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> KubernetesVersion { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AgentPoolUpgradeSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgentPoolUpgradeSettings() { }
        public Azure.Provisioning.BicepValue<int> DrainTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MaxBlockedNodes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MaxSurge { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MaxUnavailable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NodeSoakDurationInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.UndrainableNodeBehavior> UndrainableNodeBehavior { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UpgradeGateIsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AgentPoolUpgradeStrategy
    {
        Rolling = 0,
        BlueGreen = 1,
    }
    public partial class AgentPoolVirtualMachineNodes : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgentPoolVirtualMachineNodes() { }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AutoScaleExpander
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="least-waste")]
        LeastWaste = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="most-pods")]
        MostPods = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="priority")]
        Priority = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="random")]
        Random = 3,
    }
    public partial class CloudShellNetworkProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CloudShellNetworkProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RelayNamespaceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CloudShellProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CloudShellProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.CloudShellProfileMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.CloudShellNetworkProfile Network { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.CloudShellStorageProfile Storage { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CloudShellProfileMode
    {
        Disabled = 0,
        Managed = 1,
        Custom = 2,
    }
    public partial class CloudShellStorageProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CloudShellStorageProfile() { }
        public Azure.Provisioning.BicepValue<string> FileShareName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.CloudShellStorageProfileMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageAccountId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CloudShellStorageProfileMode
    {
        Disabled = 0,
        Managed = 1,
        Custom = 2,
    }
    public partial class ClusterApiConnectivityProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClusterApiConnectivityProfile() { }
        public Azure.Provisioning.ContainerService.ManagedClusterBastionProfile Bastion { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.CloudShellProfile CloudShell { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ClusterServiceLoadBalancerHealthProbeMode
    {
        ServiceNodePort = 0,
        Shared = 1,
    }
    public partial class ClusterUpgradeSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClusterUpgradeSettings() { }
        public Azure.Provisioning.ContainerService.UpgradeOverrideSettings OverrideSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UpgradeGateIsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CompatibleVersions : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CompatibleVersions() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Versions { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerNetworkLogs
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class ContainerServiceAgentPool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerServiceAgentPool(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolType> AgentPoolType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AvailabilityZones { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CapacityReservationGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CreationDataSourceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CurrentOrchestratorVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> GatewayPublicIPPrefixSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.GpuInstanceProfile> GpuInstanceProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.AgentPoolGpuProfile GpuProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> HostGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsArtifactStreamingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAutoScalingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEncryptionAtHostEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsFipsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsNodePublicIPEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsOSDiskFullCachingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsUltraSsdEnabled { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.KubeletConfig KubeletConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.KubeletDiskType> KubeletDiskType { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.LinuxOSConfig LinuxOSConfig { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.LocalDnsProfile LocalDnsProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxPods { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageOfTheDay { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.AgentPoolNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeImageVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NodeInitializationTaints { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> NodeLabels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NodePublicIPPrefixId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NodeTaints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OrchestratorVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> OSDiskSizeInGB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOSDiskType> OSDiskType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOSSku> OSSku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOSType> OSType { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceManagedCluster Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.PodIPAllocationMode> PodIPAllocationMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PodSubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceStateCode> PowerStateCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PreparedImageSpecificationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ScaleDownMode> ScaleDownMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ScaleSetEvictionPolicy> ScaleSetEvictionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ScaleSetPriority> ScaleSetPriority { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.AgentPoolSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> SpotMaxPrice { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ResponseError> StatusProvisioningError { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.AgentPoolUpgradeSettings UpgradeSettings { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.AgentPoolBlueGreenUpgradeSettings UpgradeSettingsBlueGreen { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolUpgradeStrategy> UpgradeStrategy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.AgentPoolVirtualMachineNodes> VirtualMachineNodesStatus { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.AgentPoolScaleProfile VirtualMachinesScale { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VmSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VnetSubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> WindowsIsOutboundNatDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.WorkloadRuntime> WorkloadRuntime { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ContainerServiceAgentPool FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_01;
            public static readonly string V2026_01_01;
            public static readonly string V2026_02_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_04_01;
            public static readonly string V2026_05_01;
            public static readonly string V2026_06_01;
            public static readonly string V2026_07_01;
            public static readonly string V2026_08_01;
            public static readonly string V2026_09_01;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public partial class ContainerServiceAlertConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerServiceAlertConfiguration(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceManagedCluster Parent { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceAlertConfigurationProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ContainerServiceAlertConfiguration FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public enum ContainerServiceAlertConfigurationMode
    {
        Disabled = 0,
        Managed = 1,
    }
    public partial class ContainerServiceAlertConfigurationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceAlertConfigurationProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceAlertConfigurationMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NotificationActionGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceAlertConfigurationProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerServiceAlertConfigurationProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Creating = 3,
        Updating = 4,
        Deleting = 5,
    }
    public enum ContainerServiceArtifactSource
    {
        Cache = 0,
        Direct = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceBuiltInRole : System.IEquatable<Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole AzureKubernetesServiceClusterAdminRole { get { throw null; } }
        public static Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole AzureKubernetesServiceClusterMonitoringUser { get { throw null; } }
        public static Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole AzureKubernetesServiceClusterUserRole { get { throw null; } }
        public static Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole AzureKubernetesServiceContributorRole { get { throw null; } }
        public static Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole AzureKubernetesServiceRbacAdmin { get { throw null; } }
        public static Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole AzureKubernetesServiceRbacClusterAdmin { get { throw null; } }
        public static Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole AzureKubernetesServiceRbacReader { get { throw null; } }
        public static Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole AzureKubernetesServiceRbacWriter { get { throw null; } }
        public bool Equals(Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public static string GetBuiltInRoleName(Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole value) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole left, Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole left, Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceDateSpan : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceDateSpan() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> End { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Start { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServiceDetectedUpgradeIssue : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceDetectedUpgradeIssue() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.UpgradeInsightImpactedResourceInfo> ImpactedResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceUpgradeIssueType> IssueType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.UpgradeInsightRecommendedAction> RecommendedActions { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceUpgradeIssueSeverity> Severity { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServiceGuardrailsAvailableVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal ContainerServiceGuardrailsAvailableVersion() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.GuardrailsAvailableVersionsProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ContainerServiceGuardrailsAvailableVersion FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public enum ContainerServiceGuardrailsSupport
    {
        Preview = 0,
        Stable = 1,
    }
    public enum ContainerServiceIPFamily
    {
        IPv4 = 0,
        IPv6 = 1,
    }
    public partial class ContainerServiceIPTag : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceIPTag() { }
        public Azure.Provisioning.BicepValue<string> IPTagType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tag { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServiceLinuxProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceLinuxProfile() { }
        public Azure.Provisioning.BicepValue<string> AdminUsername { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ContainerServiceSshPublicKey> SshPublicKeys { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerServiceLoadBalancerSku
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="service")]
        Service = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="standard")]
        Standard = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="basic")]
        Basic = 2,
    }
    public partial class ContainerServiceMachine : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerServiceMachine(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceAgentPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceMachineProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ContainerServiceMachine FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public enum ContainerServiceMachineDriftAction
    {
        Synced = 0,
        Recreate = 1,
    }
    public partial class ContainerServiceMachineHardwareProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceMachineHardwareProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.GpuInstanceProfile> GpuInstanceProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.AgentPoolGpuProfile GpuProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsUltraSsdEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VmSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServiceMachineIPAddress : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceMachineIPAddress() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceIPFamily> Family { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> IP { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServiceMachineKubernetesProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceMachineKubernetesProfile() { }
        public Azure.Provisioning.BicepValue<string> CurrentOrchestratorVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsArtifactStreamingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.KubeletConfig KubeletConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.KubeletDiskType> KubeletDiskType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxPods { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NodeInitializationTaints { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> NodeLabels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeName { get { throw null; } }
        public Azure.Provisioning.BicepList<string> NodeTaints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OrchestratorVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.WorkloadRuntime> WorkloadRuntime { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServiceMachineLinuxProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceMachineLinuxProfile() { }
        public Azure.Provisioning.ContainerService.LinuxOSConfig LinuxOSConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageOfTheDay { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServiceMachineNetworkProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceMachineNetworkProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ContainerServiceMachineIPAddress> IPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsNodePublicIPEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NodePublicIPPrefixId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ContainerServiceIPTag> NodePublicIPTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.PodIPAllocationMode> PodIPAllocationMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PodSubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VnetSubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServiceMachineOSProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceMachineOSProfile() { }
        public Azure.Provisioning.BicepValue<bool> IsFipsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceMachineLinuxProfile LinuxProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> OSDiskSizeInGB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOSDiskType> OSDiskType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOSSku> OSSku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOSType> OSType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> WindowsIsOutboundNatDisabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServiceMachineProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceMachineProperties() { }
        public Azure.Provisioning.BicepValue<float> BillingSpotMaxPrice { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CapacityReservationGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ScaleSetEvictionPolicy> EvictionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceMachineHardwareProfile Hardware { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceMachineKubernetesProfile Kubernetes { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.LocalDnsProfile LocalDnsProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceMachineNetworkProperties Network { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeImageVersion { get { throw null; } }
        public Azure.Provisioning.ContainerService.ContainerServiceMachineOSProfile OperatingSystem { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ScaleSetPriority> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } }
        public Azure.Provisioning.ContainerService.ContainerServiceMachineSecurityProfile Security { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceMachineStatus Status { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServiceMachineSecurityProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceMachineSecurityProfile() { }
        public Azure.Provisioning.BicepValue<bool> IsEncryptionAtHostEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSecureBootEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVtpmEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolSshAccess> SshAccess { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServiceMachineStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceMachineStatus() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceMachineDriftAction> DriftAction { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DriftReason { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ResponseError> ProvisioningError { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceMachineVmState> VmState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerServiceMachineVmState
    {
        Running = 0,
        Deleted = 1,
    }
    public partial class ContainerServiceMaintenanceAbsoluteMonthlySchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceMaintenanceAbsoluteMonthlySchedule() { }
        public Azure.Provisioning.BicepValue<int> DayOfMonth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IntervalMonths { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServiceMaintenanceConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerServiceMaintenanceConfiguration(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.ContainerService.ContainerServiceMaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> MaintenanceWindowId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ContainerServiceTimeSpan> NotAllowedTimes { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceManagedCluster Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ContainerServiceTimeInWeek> TimesInWeek { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ContainerServiceMaintenanceConfiguration FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_01;
            public static readonly string V2026_01_01;
            public static readonly string V2026_02_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_04_01;
            public static readonly string V2026_05_01;
            public static readonly string V2026_06_01;
            public static readonly string V2026_07_01;
            public static readonly string V2026_08_01;
            public static readonly string V2026_09_01;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public partial class ContainerServiceMaintenanceRelativeMonthlySchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceMaintenanceRelativeMonthlySchedule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceWeekDay> DayOfWeek { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IntervalMonths { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceMaintenanceRelativeMonthlyScheduleWeekIndex> WeekIndex { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerServiceMaintenanceRelativeMonthlyScheduleWeekIndex
    {
        First = 0,
        Second = 1,
        Third = 2,
        Fourth = 3,
        Last = 4,
    }
    public partial class ContainerServiceMaintenanceSchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceMaintenanceSchedule() { }
        public Azure.Provisioning.ContainerService.ContainerServiceMaintenanceAbsoluteMonthlySchedule AbsoluteMonthly { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DailyIntervalDays { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceMaintenanceRelativeMonthlySchedule RelativeMonthly { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceMaintenanceWeeklySchedule Weekly { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServiceMaintenanceWeeklySchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceMaintenanceWeeklySchedule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceWeekDay> DayOfWeek { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IntervalWeeks { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServiceMaintenanceWindow : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceMaintenanceWindow() { }
        public Azure.Provisioning.BicepValue<int> DurationHours { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ContainerServiceDateSpan> NotAllowedDates { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceMaintenanceSchedule Schedule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartDate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UtcOffset { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServiceManagedCluster : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerServiceManagedCluster(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.ContainerService.ManagedClusterAadProfile AadProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.ContainerService.ManagedClusterAddonProfile> AddonProfiles { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ManagedClusterAgentPoolProfile> AgentPoolProfiles { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterApiServerAccessProfile ApiServerAccessProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterAutoScalerProfile AutoScalerProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterAutoUpgradeProfile AutoUpgradeProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterAzureMonitorProfile AzureMonitorProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzurePortalFqdn { get { throw null; } }
        public Azure.Provisioning.ContainerService.ManagedClusterBootstrapProfile BootstrapProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterIdentity ClusterIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CreationDataSourceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CurrentKubernetesVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DnsPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableNodeHardening { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Fqdn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FqdnSubdomain { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterHealthMonitorProfile HealthMonitorProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterHostedSystemProfile HostedSystemProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterHttpProxyConfig HttpProxyConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.ContainerService.ContainerServiceUserAssignedIdentity> IdentityProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterIngressProfile IngressProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAgentSandboxProfileEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAIToolchainOperatorEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsFipsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsLocalAccountsDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsNamespaceResourcesEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPodSnapshotProfileEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRbacEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KubernetesVersion { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceLinuxProfile LinuxProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxAgentPools { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> MetricsIsCostAnalysisEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolNodeDisruptionPolicy> NodeDisruptionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterNodeProvisioningProfile NodeProvisioningProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeResourceGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ManagedClusterNodeResourceGroupRestrictionLevel> NodeResourceGroupRestrictionLevel { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterOidcIssuerProfile OidcIssuerProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterPodIdentityProfile PodIdentityProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceStateCode> PowerStateCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrivateFqdn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ContainerServicePrivateLinkResourceData> PrivateLinkResources { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServicePublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ManagedClusterControlPlaneScalingSize> ScalingSize { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ServiceMeshProfile ServiceMeshProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterServicePrincipalProfile ServicePrincipalProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ResponseError> StatusProvisioningError { get { throw null; } }
        public Azure.Provisioning.ContainerService.ManagedClusterStorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.KubernetesSupportPlan> SupportPlan { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ClusterUpgradeSettings UpgradeSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.SchedulerConfigMode> UpstreamSchedulerConfigMode { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterWindowsProfile WindowsProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterWorkloadAutoScalerProfile WorkloadAutoScalerProfile { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ContainerServiceManagedCluster FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_01;
            public static readonly string V2026_01_01;
            public static readonly string V2026_02_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_04_01;
            public static readonly string V2026_05_01;
            public static readonly string V2026_06_01;
            public static readonly string V2026_07_01;
            public static readonly string V2026_08_01;
            public static readonly string V2026_09_01;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public partial class ContainerServiceManagedMaintenanceWindow : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerServiceManagedMaintenanceWindow(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.MaintenanceWindowResourceProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ContainerServiceManagedMaintenanceWindow FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public enum ContainerServiceNetworkIpvsScheduler
    {
        RoundRobin = 0,
        LeastConnection = 1,
    }
    public enum ContainerServiceNetworkKubeProxyMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="IPTABLES")]
        IPTables = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IPVS")]
        Ipvs = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="NFTABLES")]
        NFTables = 2,
    }
    public enum ContainerServiceNetworkMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="transparent")]
        Transparent = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="bridge")]
        Bridge = 1,
    }
    public enum ContainerServiceNetworkPlugin
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="azure")]
        Azure = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="kubenet")]
        Kubenet = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="none")]
        None = 2,
    }
    public enum ContainerServiceNetworkPluginMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="overlay")]
        Overlay = 0,
    }
    public enum ContainerServiceNetworkPolicy
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="none")]
        None = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="calico")]
        Calico = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="azure")]
        Azure = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="cilium")]
        Cilium = 3,
    }
    public partial class ContainerServiceNetworkProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceNetworkProfile() { }
        public Azure.Provisioning.ContainerService.ManagedClusterAdvancedNetworking AdvancedNetworking { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ClusterApiConnectivityProfile ClusterApiConnectivityProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DnsServiceIP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsStaticEgressGatewayAddonEnabled { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceNetworkProfileKubeProxyConfig KubeProxyConfig { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterLoadBalancerProfile LoadBalancerProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceLoadBalancerSku> LoadBalancerSku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NatGatewayId { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterNatGatewayProfile NatGatewayProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.NetworkDataplane> NetworkDataplane { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ContainerServiceIPFamily> NetworkIPFamilies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceNetworkMode> NetworkMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceNetworkPlugin> NetworkPlugin { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceNetworkPluginMode> NetworkPluginMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceNetworkPolicy> NetworkPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOutboundType> OutboundType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PodCidr { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PodCidrs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolPodLinkLocalAccess> PodLinkLocalAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceCidr { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ServiceCidrs { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServiceNetworkProfileKubeProxyConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceNetworkProfileKubeProxyConfig() { }
        public Azure.Provisioning.ContainerService.ContainerServiceNetworkProfileKubeProxyConfigIpvsConfig IpvsConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsKubeProxyEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceNetworkKubeProxyMode> Mode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServiceNetworkProfileKubeProxyConfigIpvsConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceNetworkProfileKubeProxyConfigIpvsConfig() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceNetworkIpvsScheduler> Scheduler { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TcpFinTimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TcpTimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> UdpTimeoutInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerServiceOSDiskType
    {
        Managed = 0,
        Ephemeral = 1,
    }
    public enum ContainerServiceOSSku
    {
        Ubuntu = 0,
        AzureLinux = 1,
        AzureLinux3 = 2,
        Mariner = 3,
        Flatcar = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="CBLMariner")]
        CblMariner = 5,
        Windows2019 = 6,
        Windows2022 = 7,
        Ubuntu2204 = 8,
        Windows2025 = 9,
        WindowsAnnual = 10,
        Ubuntu2404 = 11,
        AzureContainerLinux = 12,
        Ubuntu2604 = 13,
    }
    public enum ContainerServiceOSType
    {
        Linux = 0,
        Windows = 1,
    }
    public enum ContainerServiceOutboundType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="loadBalancer")]
        LoadBalancer = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="userDefinedRouting")]
        UserDefinedRouting = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="managedNATGateway")]
        ManagedNatGateway = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="userAssignedNATGateway")]
        UserAssignedNatGateway = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="none")]
        None = 4,
    }
    public partial class ContainerServicePrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerServicePrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.ContainerService.ContainerServicePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceManagedCluster Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServicePrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ContainerServicePrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_01;
            public static readonly string V2026_01_01;
            public static readonly string V2026_02_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_04_01;
            public static readonly string V2026_05_01;
            public static readonly string V2026_06_01;
            public static readonly string V2026_07_01;
            public static readonly string V2026_08_01;
            public static readonly string V2026_09_01;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public enum ContainerServicePrivateEndpointConnectionProvisioningState
    {
        Canceled = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
        Succeeded = 4,
    }
    public partial class ContainerServicePrivateLinkResourceData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServicePrivateLinkResourceData() { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateLinkServiceId { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RequiredMembers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServicePrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServicePrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServicePrivateLinkServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerServicePrivateLinkServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public enum ContainerServiceProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
    }
    public enum ContainerServicePublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
        SecuredByPerimeter = 2,
    }
    public partial class ContainerServiceSafeguardsAvailableVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal ContainerServiceSafeguardsAvailableVersion() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.SafeguardsAvailableVersionsProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ContainerServiceSafeguardsAvailableVersion FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public enum ContainerServiceSafeguardsSupport
    {
        Preview = 0,
        Stable = 1,
    }
    public enum ContainerServiceSeccompDefault
    {
        Unconfined = 0,
        RuntimeDefault = 1,
    }
    public partial class ContainerServiceSshPublicKey : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceSshPublicKey() { }
        public Azure.Provisioning.BicepValue<string> KeyData { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerServiceStateCode
    {
        Running = 0,
        Stopped = 1,
    }
    public partial class ContainerServiceTimeInWeek : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceTimeInWeek() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceWeekDay> Day { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<int> HourSlots { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServiceTimeSpan : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceTimeSpan() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndsOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServiceTrustedAccessRoleBinding : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerServiceTrustedAccessRoleBinding(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceManagedCluster Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceTrustedAccessRoleBindingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Roles { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ContainerServiceTrustedAccessRoleBinding FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_01;
            public static readonly string V2026_01_01;
            public static readonly string V2026_02_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_04_01;
            public static readonly string V2026_05_01;
            public static readonly string V2026_06_01;
            public static readonly string V2026_07_01;
            public static readonly string V2026_08_01;
            public static readonly string V2026_09_01;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public enum ContainerServiceTrustedAccessRoleBindingProvisioningState
    {
        Canceled = 0,
        Deleting = 1,
        Failed = 2,
        Succeeded = 3,
        Updating = 4,
    }
    public partial class ContainerServiceUpgradeContext : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceUpgradeContext() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.UpgradeInsightStrategy> CurrentUpgradeStrategy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastSuccessfulUpgradeOn { get { throw null; } }
        public Azure.Provisioning.ContainerService.UpgradeInsightMaintenanceWindow NextMaintenanceWindow { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerServiceUpgradeIssueSeverity
    {
        Blocking = 0,
        Warning = 1,
    }
    public enum ContainerServiceUpgradeIssueType
    {
        PDBConstraint = 0,
        SubnetIPExhausted = 1,
        QuotaExceeded = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="APIBreakingChange")]
        ApiBreakingChange = 3,
        ComponentVersionMismatch = 4,
        UnsupportedKubernetesVersion = 5,
        NodeImageOutOfSLA = 6,
    }
    public partial class ContainerServiceUserAssignedIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceUserAssignedIdentity() { }
        public Azure.Provisioning.BicepValue<System.Guid> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ObjectId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerServiceWeekDay
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }
    public partial class ControlPlaneAndAgentPoolsUpgradeInsightProperties : Azure.Provisioning.ContainerService.UpgradeInsightProperties
    {
        public ControlPlaneAndAgentPoolsUpgradeInsightProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.AgentPoolScopeEvaluation> AgentPools { get { throw null; } }
        public Azure.Provisioning.ContainerService.UpgradeInsightScopeEvaluationResult ControlPlane { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TargetKubernetesVersion { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ControlPlaneUpgradeInsightProperties : Azure.Provisioning.ContainerService.UpgradeInsightProperties
    {
        public ControlPlaneUpgradeInsightProperties() { }
        public Azure.Provisioning.ContainerService.ContainerServiceUpgradeContext Context { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CurrentKubernetesVersion { get { throw null; } }
        public Azure.Provisioning.ContainerService.UpgradeInsightEvaluation Evaluation { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> KubernetesVersionEndOfSupportOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.KubernetesVersionSupportStatus> KubernetesVersionSupportStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TargetKubernetesVersion { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DranetMode
    {
        Unmanaged = 0,
        Managed = 1,
    }
    public enum GatewayApiIstioMode
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum GpuInstanceProfile
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="MIG1g")]
        Mig1G = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MIG2g")]
        Mig2G = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MIG3g")]
        Mig3G = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MIG4g")]
        Mig4G = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MIG7g")]
        Mig7G = 4,
    }
    public enum GpuManagementMode
    {
        Unmanaged = 0,
        Managed = 1,
    }
    public partial class GuardrailsAvailableVersionsProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GuardrailsAvailableVersionsProperties() { }
        public Azure.Provisioning.BicepValue<bool> IsDefaultVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceGuardrailsSupport> Support { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IdentityBindingManagedIdentityProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IdentityBindingManagedIdentityProfile() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ObjectId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IstioComponents : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IstioComponents() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.IstioEgressGateway> EgressGateways { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.IstioIngressGateway> IngressGateways { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ProxyRedirectionMechanism> ProxyRedirectionMechanism { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IstioEgressGateway : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IstioEgressGateway() { }
        public Azure.Provisioning.BicepValue<string> GatewayConfigurationName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Namespace { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IstioIngressGateway : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IstioIngressGateway() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.IstioIngressGatewayMode> Mode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IstioIngressGatewayMode
    {
        External = 0,
        Internal = 1,
    }
    public partial class IstioPluginCertificateAuthority : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IstioPluginCertificateAuthority() { }
        public Azure.Provisioning.BicepValue<string> CertChainObjectName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CertObjectName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyObjectName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> KeyVaultId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RootCertObjectName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IstioServiceMesh : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IstioServiceMesh() { }
        public Azure.Provisioning.ContainerService.IstioPluginCertificateAuthority CertificateAuthorityPlugin { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.IstioComponents Components { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Revisions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubeletConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubeletConfig() { }
        public Azure.Provisioning.BicepList<string> AllowedUnsafeSysctls { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ContainerLogMaxFiles { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ContainerLogMaxSizeInMB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CpuCfsQuotaPeriod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CpuManagerPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> EvictionMaxPodGracePeriodInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.KubeletHardEvictionThreshold HardEvictionThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ImageGcHighThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ImageGcLowThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsCpuCfsQuotaEnabled { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.KubeletReservedResources KubeReserved { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PodMaxPids { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceSeccompDefault> SeccompDefault { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ShouldFailStartWithSwapOn { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.SoftEvictionGracePeriod SoftEvictionGracePeriod { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.SoftEvictionThreshold SoftEvictionThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TopologyManagerPolicy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KubeletDiskType
    {
        OS = 0,
        Temporary = 1,
    }
    public partial class KubeletHardEvictionThreshold : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubeletHardEvictionThreshold() { }
        public Azure.Provisioning.BicepValue<string> MemoryAvailable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeFsAvailable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeFsInodesFree { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubeletReservedResources : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubeletReservedResources() { }
        public Azure.Provisioning.BicepValue<int> CpuMillicores { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MemoryMB { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KubernetesResourceObjectInfrastructureEncryption
    {
        Enabled = 0,
    }
    public enum KubernetesSupportPlan
    {
        KubernetesOfficial = 0,
        AKSLongTermSupport = 1,
    }
    public partial class KubernetesVersionComponent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesVersionComponent() { }
        public Azure.Provisioning.BicepValue<bool> HasBreakingChanges { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubernetesVersionComponents : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesVersionComponents() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.KubernetesVersionComponent> Components { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> KubernetesVersion { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KubernetesVersionSupportStatus
    {
        InSupport = 0,
        OutOfSupport = 1,
    }
    public partial class LinuxOSConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LinuxOSConfig() { }
        public Azure.Provisioning.BicepValue<int> SwapFileSizeInMB { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.SysctlConfig Sysctls { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TransparentHugePageDefrag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TransparentHugePageEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LocalDnsForwardDestination
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="ClusterCoreDNS")]
        ClusterCoreDns = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="VnetDNS")]
        VnetDns = 1,
    }
    public enum LocalDnsForwardPolicy
    {
        Sequential = 0,
        RoundRobin = 1,
        Random = 2,
    }
    public enum LocalDnsMode
    {
        Preferred = 0,
        Required = 1,
        Disabled = 2,
    }
    public partial class LocalDnsOverride : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LocalDnsOverride() { }
        public Azure.Provisioning.BicepValue<int> CacheDurationInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.LocalDnsForwardDestination> ForwardDestination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.LocalDnsForwardPolicy> ForwardPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxConcurrent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.LocalDnsProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.LocalDnsQueryLogging> QueryLogging { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.LocalDnsServeStale> ServeStale { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ServeStaleDurationInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LocalDnsProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LocalDnsProfile() { }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.ContainerService.LocalDnsOverride> KubeDnsOverrides { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.LocalDnsMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.LocalDnsState> State { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.ContainerService.LocalDnsOverride> VnetDnsOverrides { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LocalDnsProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="PreferUDP")]
        PreferUdp = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ForceTCP")]
        ForceTcp = 1,
    }
    public enum LocalDnsQueryLogging
    {
        Error = 0,
        Log = 1,
    }
    public enum LocalDnsServeStale
    {
        Verify = 0,
        Immediate = 1,
        Disable = 2,
    }
    public enum LocalDnsState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class MaintenanceWindowResourceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MaintenanceWindowResourceProperties() { }
        public Azure.Provisioning.BicepValue<int> DurationHours { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ContainerServiceDateSpan> NotAllowedDates { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.ContainerService.ContainerServiceMaintenanceSchedule Schedule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UtcOffset { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MaintenanceWindowSource
    {
        ClusterAutoUpgradeSchedule = 0,
        NodeOSUpgradeSchedule = 1,
    }
    public partial class ManagedClusterAadProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterAadProfile() { }
        public Azure.Provisioning.BicepList<System.Guid> AdminGroupObjectIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ClientAppId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAzureRbacEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsManagedAadEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ServerAppId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServerAppSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedClusterAddonAutoscaling
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ManagedClusterAddonProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterAddonProfile() { }
        public Azure.Provisioning.BicepDictionary<string> Config { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterAddonProfileIdentity Identity { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterAddonProfileIdentity : Azure.Provisioning.ContainerService.ContainerServiceUserAssignedIdentity
    {
        public ManagedClusterAddonProfileIdentity() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterAdvancedNetworking : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterAdvancedNetworking() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsObservabilityEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ManagedClusterAdvancedNetworkingAccelerationMode> PerformanceAccelerationMode { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterAdvancedNetworkingSecurity Security { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedClusterAdvancedNetworkingAccelerationMode
    {
        BpfVeth = 0,
        None = 1,
    }
    public partial class ManagedClusterAdvancedNetworkingSecurity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterAdvancedNetworkingSecurity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ManagedClusterAdvancedNetworkPolicy> AdvancedNetworkPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.TransitEncryptionType> TransitEncryptionType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedClusterAdvancedNetworkPolicy
    {
        L7 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="FQDN")]
        Fqdn = 1,
        None = 2,
    }
    public partial class ManagedClusterAgentPoolProfile : Azure.Provisioning.ContainerService.ManagedClusterAgentPoolProfileProperties
    {
        public ManagedClusterAgentPoolProfile() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterAgentPoolProfileProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterAgentPoolProfileProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolType> AgentPoolType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AvailabilityZones { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CapacityReservationGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CreationDataSourceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CurrentOrchestratorVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> GatewayPublicIPPrefixSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.GpuInstanceProfile> GpuInstanceProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.AgentPoolGpuProfile GpuProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> HostGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArtifactStreamingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAutoScalingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEncryptionAtHostEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsFipsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsNodePublicIPEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsOSDiskFullCachingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsUltraSsdEnabled { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.KubeletConfig KubeletConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.KubeletDiskType> KubeletDiskType { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.LinuxOSConfig LinuxOSConfig { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.LocalDnsProfile LocalDnsProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxPods { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageOfTheDay { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.AgentPoolNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeImageVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NodeInitializationTaints { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> NodeLabels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NodePublicIPPrefixId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NodeTaints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OrchestratorVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> OSDiskSizeInGB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOSDiskType> OSDiskType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOSSku> OSSku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOSType> OSType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.PodIPAllocationMode> PodIPAllocationMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PodSubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceStateCode> PowerStateCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PreparedImageSpecificationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ScaleDownMode> ScaleDownMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ScaleSetEvictionPolicy> ScaleSetEvictionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ScaleSetPriority> ScaleSetPriority { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.AgentPoolSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> SpotMaxPrice { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ResponseError> StatusProvisioningError { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.AgentPoolUpgradeSettings UpgradeSettings { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.AgentPoolBlueGreenUpgradeSettings UpgradeSettingsBlueGreen { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolUpgradeStrategy> UpgradeStrategy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.AgentPoolVirtualMachineNodes> VirtualMachineNodesStatus { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.AgentPoolScaleProfile VirtualMachinesScale { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VmSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VnetSubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> WindowsIsOutboundNatDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.WorkloadRuntime> WorkloadRuntime { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterApiServerAccessProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterApiServerAccessProfile() { }
        public Azure.Provisioning.BicepList<string> AuthorizedIPRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPrivateClusterEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPrivateClusterPublicFqdnEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRunCommandDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVnetIntegrationEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateDnsZone { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterAutoScalerProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterAutoScalerProfile() { }
        public Azure.Provisioning.BicepValue<string> BalanceSimilarNodeGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AutoScaleExpander> Expander { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDaemonsetEvictionForEmptyNodesEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDaemonsetEvictionForOccupiedNodesEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDaemonsetsUtilizationIgnored { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MaxEmptyBulkDelete { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MaxGracefulTerminationSec { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MaxNodeProvisionTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MaxTotalUnreadyPercentage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NewPodScaleUpDelay { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OkTotalUnreadyCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScaleDownDelayAfterAdd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScaleDownDelayAfterDelete { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScaleDownDelayAfterFailure { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScaleDownUnneededTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScaleDownUnreadyTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScaleDownUtilizationThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScanIntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SkipNodesWithLocalStorage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SkipNodesWithSystemPods { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterAutoUpgradeProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterAutoUpgradeProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ManagedClusterNodeOSUpgradeChannel> NodeOSUpgradeChannel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.UpgradeChannel> UpgradeChannel { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterAzureMonitorProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterAzureMonitorProfile() { }
        public Azure.Provisioning.ContainerService.ManagedClusterAzureMonitorProfileAppMonitoring AppMonitoring { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterAzureMonitorProfileContainerInsights ContainerInsights { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterMonitorProfileMetrics Metrics { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterAzureMonitorProfileAppMonitoring : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterAzureMonitorProfileAppMonitoring() { }
        public Azure.Provisioning.BicepValue<bool> IsAppMonitoringAutoInstrumentationEnabled { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterAzureMonitorProfileAppMonitoringOpenTelemetryLogsAndTraces OpenTelemetryLogsAndTraces { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterAzureMonitorProfileAppMonitoringOpenTelemetryMetrics OpenTelemetryMetrics { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterAzureMonitorProfileAppMonitoringOpenTelemetryLogsAndTraces : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterAzureMonitorProfileAppMonitoringOpenTelemetryLogsAndTraces() { }
        public Azure.Provisioning.BicepValue<long> GrpcPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> HttpPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAppMonitoringOpenTelemetryLogsAndTracesEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterAzureMonitorProfileAppMonitoringOpenTelemetryMetrics : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterAzureMonitorProfileAppMonitoringOpenTelemetryMetrics() { }
        public Azure.Provisioning.BicepValue<long> GrpcPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> HttpPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAppMonitoringOpenTelemetryMetricsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterAzureMonitorProfileContainerInsights : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterAzureMonitorProfileContainerInsights() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerNetworkLogs> ContainerNetworkLogs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsContainerInsightsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPrometheusMetricsScrapingDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> LogAnalyticsWorkspaceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SyslogPort { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterBastionProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterBastionProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BastionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PublicIPAddressId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ScaleUnits { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ManagedClusterBastionSku> Sku { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedClusterBastionSku
    {
        Standard = 0,
        Premium = 1,
    }
    public partial class ManagedClusterBootstrapProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterBootstrapProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceArtifactSource> ArtifactSource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ContainerRegistryId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedClusterControlPlaneScalingSize
    {
        H2 = 0,
        H4 = 1,
        H8 = 2,
    }
    public partial class ManagedClusterDelegatedIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterDelegatedIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReferralResource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterHealthMonitorProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterHealthMonitorProfile() { }
        public Azure.Provisioning.BicepValue<bool> IsContinuousControlPlaneAndAddonMonitorEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsOnDemandMonitorEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterHostedSystemProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterHostedSystemProfile() { }
        public Azure.Provisioning.BicepValue<bool> IsHostedSystemAddonsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NodeSubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SystemNodeSubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterHttpProxyConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterHttpProxyConfig() { }
        public Azure.Provisioning.BicepList<string> EffectiveNoProxy { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> HttpProxy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HttpsProxy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsHttpProxyEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NoProxy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TrustedCA { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterIdentity() { }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.ContainerService.ManagedClusterDelegatedIdentity> DelegatedResources { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.ContainerService.ManagedServiceIdentityUserAssignedIdentitiesValue> UserAssignedIdentities { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterIdentityBinding : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedClusterIdentityBinding(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ManagedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceManagedCluster Parent { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterIdentityBindingProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ManagedClusterIdentityBinding FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2026_04_01;
            public static readonly string V2026_05_01;
            public static readonly string V2026_06_01;
            public static readonly string V2026_07_01;
            public static readonly string V2026_08_01;
            public static readonly string V2026_09_01;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public partial class ManagedClusterIdentityBindingAllowedSubject : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterIdentityBindingAllowedSubject() { }
        public Azure.Provisioning.ContainerService.ManagedClusterLoadBalancerLabelSelector NamespaceSelector { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterLoadBalancerLabelSelector ServiceAccountSelector { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterIdentityBindingProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterIdentityBindingProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ManagedClusterIdentityBindingAllowedSubject> AllowedSubjects { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.IdentityBindingManagedIdentityProfile ManagedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> OidcIssuerUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ManagedClusterIdentityBindingProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedClusterIdentityBindingProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Creating = 3,
        Updating = 4,
        Deleting = 5,
    }
    public partial class ManagedClusterIngressDefaultDomainProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterIngressDefaultDomainProfile() { }
        public Azure.Provisioning.BicepValue<string> DomainName { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDefaultDomainEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterIngressProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterIngressProfile() { }
        public Azure.Provisioning.ContainerService.ManagedClusterIngressProfileApplicationLoadBalancer ApplicationLoadBalancer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ManagedGatewayType> GatewayApiInstallation { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterIngressProfileWebAppRouting WebAppRouting { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterIngressProfileApplicationLoadBalancer : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterIngressProfileApplicationLoadBalancer() { }
        public Azure.Provisioning.ContainerService.ContainerServiceUserAssignedIdentity Identity { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsApplicationLoadBalancerEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterIngressProfileWebAppRouting : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterIngressProfileWebAppRouting() { }
        public Azure.Provisioning.ContainerService.ManagedClusterIngressDefaultDomainProfile DefaultDomain { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> DnsZoneResourceIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.GatewayApiIstioMode> GatewayApiImplementationsIstioMode { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceUserAssignedIdentity Identity { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.NginxIngressControllerType> NginxDefaultIngressControllerType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterJwtAuthenticator : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedClusterJwtAuthenticator(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceManagedCluster Parent { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterJwtAuthenticatorProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ManagedClusterJwtAuthenticator FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public partial class ManagedClusterJwtAuthenticatorClaimMappings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterJwtAuthenticatorClaimMappings() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ManagedClusterJwtAuthenticatorExtraClaimMappingExpression> Extra { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupsExpression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UidExpression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UsernameExpression { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterJwtAuthenticatorExtraClaimMappingExpression : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterJwtAuthenticatorExtraClaimMappingExpression() { }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ValueExpression { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterJwtAuthenticatorIssuer : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterJwtAuthenticatorIssuer() { }
        public Azure.Provisioning.BicepList<string> Audiences { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterJwtAuthenticatorProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterJwtAuthenticatorProperties() { }
        public Azure.Provisioning.BicepValue<string> CertificateAuthorityBundle { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterJwtAuthenticatorClaimMappings ClaimMappings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ManagedClusterJwtAuthenticatorValidationRule> ClaimValidationRules { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterJwtAuthenticatorIssuer Issuer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ManagedClusterJwtAuthenticatorProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ManagedClusterJwtAuthenticatorValidationRule> UserValidationRules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedClusterJwtAuthenticatorProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Creating = 3,
        Updating = 4,
        Deleting = 5,
    }
    public partial class ManagedClusterJwtAuthenticatorValidationRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterJwtAuthenticatorValidationRule() { }
        public Azure.Provisioning.BicepValue<string> Expression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedClusterKeyVaultNetworkAccessType
    {
        Public = 0,
        Private = 1,
    }
    public enum ManagedClusterLabelSelectorOperator
    {
        In = 0,
        NotIn = 1,
        Exists = 2,
        DoesNotExist = 3,
    }
    public partial class ManagedClusterLoadBalancer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedClusterLoadBalancer(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsServicePlacementAllowed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterLoadBalancerLabelSelector NodeSelector { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceManagedCluster Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrimaryAgentPoolName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.ContainerService.ManagedClusterLoadBalancerLabelSelector ServiceLabelSelector { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterLoadBalancerLabelSelector ServiceNamespaceSelector { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ManagedClusterLoadBalancer FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public enum ManagedClusterLoadBalancerBackendPoolType
    {
        NodeIPConfiguration = 0,
        NodeIP = 1,
        PodIP = 2,
    }
    public partial class ManagedClusterLoadBalancerLabelSelector : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterLoadBalancerLabelSelector() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ManagedClusterLoadBalancerLabelSelectorRequirement> MatchExpressions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> MatchLabels { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterLoadBalancerLabelSelectorRequirement : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterLoadBalancerLabelSelectorRequirement() { }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ManagedClusterLabelSelectorOperator> Operator { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterLoadBalancerProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterLoadBalancerProfile() { }
        public Azure.Provisioning.BicepValue<int> AllocatedOutboundPorts { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ManagedClusterLoadBalancerBackendPoolType> BackendPoolType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ClusterServiceLoadBalancerHealthProbeMode> ClusterServiceLoadBalancerHealthProbeMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> EffectiveOutboundIPs { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> IdleTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsMultipleStandardLoadBalancersEnabled { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterLoadBalancerProfileManagedOutboundIPs ManagedOutboundIPs { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> OutboundPublicIPPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> OutboundPublicIPs { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterLoadBalancerProfileManagedOutboundIPs : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterLoadBalancerProfileManagedOutboundIPs() { }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CountIPv6 { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterManagedOutboundIPProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterManagedOutboundIPProfile() { }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CountIPv6 { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterMeshMembership : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedClusterMeshMembership(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ManagedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceManagedCluster Parent { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterMeshMembershipProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ManagedClusterMeshMembership FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public partial class ManagedClusterMeshMembershipProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterMeshMembershipProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedMeshId { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.MeshMembershipPrivateConnectProfile PrivateConnectProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.MeshMembershipProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterMonitorProfileKubeStateMetrics : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterMonitorProfileKubeStateMetrics() { }
        public Azure.Provisioning.BicepValue<string> MetricAnnotationsAllowList { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MetricLabelsAllowlist { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterMonitorProfileMetrics : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterMonitorProfileMetrics() { }
        public Azure.Provisioning.BicepValue<bool> IsControlPlaneEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterMonitorProfileKubeStateMetrics KubeStateMetrics { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterNamespace : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedClusterNamespace(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceManagedCluster Parent { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterNamespaceProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ManagedClusterNamespace FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_01;
            public static readonly string V2026_01_01;
            public static readonly string V2026_02_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_04_01;
            public static readonly string V2026_05_01;
            public static readonly string V2026_06_01;
            public static readonly string V2026_07_01;
            public static readonly string V2026_08_01;
            public static readonly string V2026_09_01;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public partial class ManagedClusterNamespaceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterNamespaceProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.NamespaceAdoptionPolicy> AdoptionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Annotations { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.NamespaceNetworkPolicies DefaultNetworkPolicy { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.NamespaceResourceQuota DefaultResourceQuota { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.NamespaceDeletePolicy> DeletePolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Labels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PortalFqdn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ManagedClusterNamespaceProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedClusterNamespaceProvisioningState
    {
        Updating = 0,
        Deleting = 1,
        Creating = 2,
        Succeeded = 3,
        Failed = 4,
        Canceled = 5,
    }
    public partial class ManagedClusterNatGatewayProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterNatGatewayProfile() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> EffectiveOutboundIPs { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> IdleTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterManagedOutboundIPProfile ManagedOutboundIPProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> OutboundPublicIPPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> OutboundPublicIPs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ManagedClusterNatGatewaySku> Sku { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedClusterNatGatewaySku
    {
        Standard = 0,
        StandardV2 = 1,
    }
    public enum ManagedClusterNodeOSUpgradeChannel
    {
        None = 0,
        Unmanaged = 1,
        NodeImage = 2,
        SecurityPatch = 3,
    }
    public partial class ManagedClusterNodeProvisioningProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterNodeProvisioningProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.NodeProvisioningDefaultNodePool> DefaultNodePools { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.NodeProvisioningMode> Mode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedClusterNodeResourceGroupRestrictionLevel
    {
        Unrestricted = 0,
        ReadOnly = 1,
    }
    public partial class ManagedClusterOidcIssuerProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterOidcIssuerProfile() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IssuerUriInfo { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterPodIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterPodIdentity() { }
        public Azure.Provisioning.BicepValue<string> BindingSelector { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceUserAssignedIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Namespace { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterPodIdentityProvisioningErrorDetail ProvisioningInfoErrorDetail { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ManagedClusterPodIdentityProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterPodIdentityException : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterPodIdentityException() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Namespace { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> PodLabels { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterPodIdentityProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterPodIdentityProfile() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsKubenetNetworkPluginAllowed { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ManagedClusterPodIdentity> UserAssignedIdentities { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ManagedClusterPodIdentityException> UserAssignedIdentityExceptions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterPodIdentityProvisioningErrorDetail : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterPodIdentityProvisioningErrorDetail() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ManagedClusterPodIdentityProvisioningErrorDetail> Details { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Target { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedClusterPodIdentityProvisioningState
    {
        Assigned = 0,
        Canceled = 1,
        Deleting = 2,
        Failed = 3,
        Succeeded = 4,
        Updating = 5,
    }
    public partial class ManagedClusterPoolUpgradeProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterPoolUpgradeProfile() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.KubernetesVersionComponents> ComponentsByReleases { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> KubernetesVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOSType> OSType { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ManagedClusterPoolUpgradeProfileUpgradesItem> Upgrades { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterPoolUpgradeProfileUpgradesItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterPoolUpgradeProfileUpgradesItem() { }
        public Azure.Provisioning.BicepValue<bool> IsOutOfSupport { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsPreview { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> KubernetesVersion { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterSecurityProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterSecurityProfile() { }
        public Azure.Provisioning.ContainerService.ManagedClusterSecurityProfileKeyVaultKms AzureKeyVaultKms { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> CustomCATrustCertificates { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterSecurityProfileDefender Defender { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterSecurityProfileImageCleaner ImageCleaner { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.KubernetesResourceObjectInfrastructureEncryption> InfrastructureEncryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsImageIntegrityEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsNodeRestrictionEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsWorkloadIdentityEnabled { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ServiceAccountImagePullProfile ServiceAccountImagePullProfile { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterSecurityProfileDefender : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterSecurityProfileDefender() { }
        public Azure.Provisioning.BicepValue<bool> IsSecurityMonitoringEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> LogAnalyticsWorkspaceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterSecurityProfileDefenderSecurityGating SecurityGating { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterSecurityProfileDefenderSecurityGating : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterSecurityProfileDefenderSecurityGating() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ManagedClusterSecurityProfileDefenderSecurityGatingIdentity> Identities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSecretAccessAllowed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSecurityGatingEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterSecurityProfileDefenderSecurityGatingIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterSecurityProfileDefenderSecurityGatingIdentity() { }
        public Azure.Provisioning.BicepValue<string> AzureContainerRegistry { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceUserAssignedIdentity Identity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterSecurityProfileImageCleaner : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterSecurityProfileImageCleaner() { }
        public Azure.Provisioning.BicepValue<int> IntervalHours { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterSecurityProfileKeyVaultKms : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterSecurityProfileKeyVaultKms() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ManagedClusterKeyVaultNetworkAccessType> KeyVaultNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> KeyVaultResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterServicePrincipalProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterServicePrincipalProfile() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Secret { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ManagedClusterSkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ManagedClusterSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedClusterSkuName
    {
        Base = 0,
        Automatic = 1,
    }
    public enum ManagedClusterSkuTier
    {
        Premium = 0,
        Standard = 1,
        Free = 2,
    }
    public partial class ManagedClusterSnapshot : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedClusterSnapshot(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CreationDataSourceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterSnapshotInfo ManagedClusterPropertiesReadOnly { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.SnapshotType> SnapshotType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ManagedClusterSnapshot FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public partial class ManagedClusterSnapshotInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterSnapshotInfo() { }
        public Azure.Provisioning.BicepValue<bool> IsRbacEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> KubernetesVersion { get { throw null; } }
        public Azure.Provisioning.ContainerService.ManagedClusterSnapshotNetworkProfile NetworkProfile { get { throw null; } }
        public Azure.Provisioning.ContainerService.ManagedClusterSku Sku { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterSnapshotNetworkProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterSnapshotNetworkProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceLoadBalancerSku> LoadBalancerSku { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceNetworkMode> NetworkMode { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceNetworkPlugin> NetworkPlugin { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceNetworkPluginMode> NetworkPluginMode { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceNetworkPolicy> NetworkPolicy { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterStorageProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterStorageProfile() { }
        public Azure.Provisioning.ContainerService.ManagedClusterStorageProfileDiskCsiDriver DiskCsiDriver { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsBlobCsiDriverEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsFileCsiDriverEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSnapshotControllerEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterStorageProfileDiskCsiDriver : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterStorageProfileDiskCsiDriver() { }
        public Azure.Provisioning.BicepValue<bool> IsDiskCsiDriverEnabled { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterStorageProfileDiskCsiDriverQuickAttachDetach QuickAttachDetach { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterStorageProfileDiskCsiDriverQuickAttachDetach : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterStorageProfileDiskCsiDriverQuickAttachDetach() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceUserAssignedIdentity Identity { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterUpgradeProfile : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal ManagedClusterUpgradeProfile() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ManagedClusterPoolUpgradeProfile> AgentPoolProfiles { get { throw null; } }
        public Azure.Provisioning.ContainerService.ManagedClusterPoolUpgradeProfile ControlPlaneProfile { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceManagedCluster Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ManagedClusterUpgradeProfile FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_01;
            public static readonly string V2026_01_01;
            public static readonly string V2026_02_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_04_01;
            public static readonly string V2026_05_01;
            public static readonly string V2026_06_01;
            public static readonly string V2026_07_01;
            public static readonly string V2026_08_01;
            public static readonly string V2026_09_01;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public partial class ManagedClusterVerticalPodAutoscaler : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterVerticalPodAutoscaler() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ManagedClusterAddonAutoscaling> AddonAutoscaling { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVpaEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterWindowsProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterWindowsProfile() { }
        public Azure.Provisioning.BicepValue<string> AdminPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AdminUsername { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.WindowsGmsaProfile GmsaProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsCsiProxyEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.WindowsVmLicenseType> LicenseType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterWorkloadAutoScalerProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterWorkloadAutoScalerProfile() { }
        public Azure.Provisioning.BicepValue<bool> IsKedaEnabled { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterVerticalPodAutoscaler VerticalPodAutoscaler { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedGatewayType
    {
        Disabled = 0,
        Standard = 1,
    }
    public partial class ManagedServiceIdentityUserAssignedIdentitiesValue : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedServiceIdentityUserAssignedIdentitiesValue() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrincipalId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManualScaleProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManualScaleProfile() { }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MeshMembershipPrivateConnectProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MeshMembershipPrivateConnectProfile() { }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MeshMembershipProvisioningState
    {
        Canceled = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
        Succeeded = 4,
        Updating = 5,
    }
    public partial class MeshRevision : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MeshRevision() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.CompatibleVersions> CompatibleWith { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Revision { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Upgrades { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MeshRevisionProfile : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal MeshRevisionProfile() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.MeshRevision> MeshRevisions { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.MeshRevisionProfile FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_01;
            public static readonly string V2026_01_01;
            public static readonly string V2026_02_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_04_01;
            public static readonly string V2026_05_01;
            public static readonly string V2026_06_01;
            public static readonly string V2026_07_01;
            public static readonly string V2026_08_01;
            public static readonly string V2026_09_01;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public partial class MeshUpgradeProfile : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal MeshUpgradeProfile() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceManagedCluster Parent { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.MeshUpgradeProfileProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.MeshUpgradeProfile FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_01;
            public static readonly string V2026_01_01;
            public static readonly string V2026_02_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_04_01;
            public static readonly string V2026_05_01;
            public static readonly string V2026_06_01;
            public static readonly string V2026_07_01;
            public static readonly string V2026_08_01;
            public static readonly string V2026_09_01;
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public partial class MeshUpgradeProfileProperties : Azure.Provisioning.ContainerService.MeshRevision
    {
        public MeshUpgradeProfileProperties() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NamespaceAdoptionPolicy
    {
        Never = 0,
        IfIdentical = 1,
        Always = 2,
    }
    public enum NamespaceDeletePolicy
    {
        Keep = 0,
        Delete = 1,
    }
    public partial class NamespaceNetworkPolicies : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NamespaceNetworkPolicies() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.NamespaceNetworkPolicyRule> Egress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.NamespaceNetworkPolicyRule> Ingress { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NamespaceNetworkPolicyRule
    {
        DenyAll = 0,
        AllowAll = 1,
        AllowSameNamespace = 2,
    }
    public partial class NamespaceResourceQuota : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NamespaceResourceQuota() { }
        public Azure.Provisioning.BicepValue<string> CpuLimit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CpuRequest { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MemoryLimit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MemoryRequest { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NetworkDataplane
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="azure")]
        Azure = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="cilium")]
        Cilium = 1,
    }
    public enum NginxIngressControllerType
    {
        AnnotationControlled = 0,
        External = 1,
        Internal = 2,
        None = 3,
    }
    public partial class NodeImageUpgradeInsightProperties : Azure.Provisioning.ContainerService.UpgradeInsightProperties
    {
        public NodeImageUpgradeInsightProperties() { }
        public Azure.Provisioning.BicepValue<string> AgentPoolName { get { throw null; } }
        public Azure.Provisioning.ContainerService.ContainerServiceUpgradeContext Context { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CurrentNodeImageVersion { get { throw null; } }
        public Azure.Provisioning.ContainerService.UpgradeInsightEvaluation Evaluation { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TargetNodeImageVersion { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NodeProvisioningDefaultNodePool
    {
        None = 0,
        Auto = 1,
    }
    public enum NodeProvisioningMode
    {
        Manual = 0,
        Auto = 1,
    }
    public enum PodIPAllocationMode
    {
        DynamicIndividual = 0,
        StaticBlock = 1,
    }
    public enum ProxyRedirectionMechanism
    {
        InitContainers = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="CNIChaining")]
        CniChaining = 1,
    }
    public partial class SafeguardsAvailableVersionsProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SafeguardsAvailableVersionsProperties() { }
        public Azure.Provisioning.BicepValue<bool> IsDefaultVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceSafeguardsSupport> Support { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ScaleDownMode
    {
        Delete = 0,
        Deallocate = 1,
    }
    public enum ScaleSetEvictionPolicy
    {
        Delete = 0,
        Deallocate = 1,
    }
    public enum ScaleSetPriority
    {
        Spot = 0,
        Regular = 1,
    }
    public enum SchedulerConfigMode
    {
        Default = 0,
        ManagedByCRD = 1,
    }
    public partial class ServiceAccountImagePullProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAccountImagePullProfile() { }
        public Azure.Provisioning.BicepValue<string> DefaultManagedIdentityId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceMeshMode
    {
        Istio = 0,
        Disabled = 1,
    }
    public partial class ServiceMeshProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceMeshProfile() { }
        public Azure.Provisioning.ContainerService.IstioServiceMesh Istio { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ServiceMeshMode> Mode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SnapshotType
    {
        NodePool = 0,
        ManagedCluster = 1,
    }
    public partial class SoftEvictionGracePeriod : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SoftEvictionGracePeriod() { }
        public Azure.Provisioning.BicepValue<string> MemoryAvailable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeFsAvailable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeFsInodesFree { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SoftEvictionThreshold : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SoftEvictionThreshold() { }
        public Azure.Provisioning.BicepValue<string> MemoryAvailable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeFsAvailable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeFsInodesFree { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SysctlConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SysctlConfig() { }
        public Azure.Provisioning.BicepValue<int> FsAioMaxNr { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FsFileMax { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FsInotifyMaxUserWatches { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FsNrOpen { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsNetIPv4TcpTwReuseEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> KernelThreadsMax { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NetCoreNetdevMaxBacklog { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NetCoreOptmemMax { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NetCoreRmemDefault { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NetCoreRmemMax { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NetCoreSomaxconn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NetCoreWmemDefault { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NetCoreWmemMax { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NetIPv4IPLocalPortRange { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NetIPv4NeighDefaultGcThresh1 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NetIPv4NeighDefaultGcThresh2 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NetIPv4NeighDefaultGcThresh3 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NetIPv4TcpFinTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NetIPv4TcpKeepaliveIntvl { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NetIPv4TcpKeepaliveProbes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NetIPv4TcpKeepaliveTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NetIPv4TcpMaxSynBacklog { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NetIPv4TcpMaxTwBuckets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NetNetfilterNfConntrackBuckets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NetNetfilterNfConntrackMax { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> VmMaxMapCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> VmSwappiness { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> VmVfsCachePressure { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum TransitEncryptionType
    {
        WireGuard = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="mTLS")]
        ClientCertificateAuthentication = 1,
        None = 2,
    }
    public enum UndrainableNodeBehavior
    {
        Cordon = 0,
        Schedule = 1,
    }
    public enum UpgradeChannel
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="rapid")]
        Rapid = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="stable")]
        Stable = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="patch")]
        Patch = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="node-image")]
        NodeImage = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="none")]
        None = 4,
    }
    public partial class UpgradeInsight : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal UpgradeInsight() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceManagedCluster Parent { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.UpgradeInsightProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.UpgradeInsight FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2026_09_02_PREVIEW;
        }
    }
    public partial class UpgradeInsightArmImpactedResourceInfo : Azure.Provisioning.ContainerService.UpgradeInsightImpactedResourceInfo
    {
        public UpgradeInsightArmImpactedResourceInfo() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UpgradeInsightEvaluation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UpgradeInsightEvaluation() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ContainerServiceDetectedUpgradeIssue> DetectedIssues { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EvaluatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.UpgradeInsightStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UpgradeInsightImpactedResourceInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UpgradeInsightImpactedResourceInfo() { }
        public Azure.Provisioning.BicepValue<string> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UpgradeInsightKubernetesImpactedResourceInfo : Azure.Provisioning.ContainerService.UpgradeInsightImpactedResourceInfo
    {
        public UpgradeInsightKubernetesImpactedResourceInfo() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Namespace { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UpgradeInsightMaintenanceWindow : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UpgradeInsightMaintenanceWindow() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MaintenanceConfigurationName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.MaintenanceWindowSource> Source { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UpgradeInsightProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UpgradeInsightProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiresOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastEvaluatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UpgradeInsightRecommendedAction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UpgradeInsightRecommendedAction() { }
        public Azure.Provisioning.BicepValue<string> Details { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> DocumentationLink { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UpgradeInsightScopeEvaluationResult : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UpgradeInsightScopeEvaluationResult() { }
        public Azure.Provisioning.ContainerService.ContainerServiceUpgradeContext Context { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CurrentKubernetesVersion { get { throw null; } }
        public Azure.Provisioning.ContainerService.UpgradeInsightEvaluation Evaluation { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> KubernetesVersionEndOfSupportOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.KubernetesVersionSupportStatus> KubernetesVersionSupportStatus { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum UpgradeInsightStatus
    {
        Passed = 0,
        Warning = 1,
        Failed = 2,
    }
    public enum UpgradeInsightStrategy
    {
        Manual = 0,
        Auto = 1,
    }
    public partial class UpgradeOverrideSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UpgradeOverrideSettings() { }
        public Azure.Provisioning.BicepValue<bool> IsForceUpgradeEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Until { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WindowsGmsaProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WindowsGmsaProfile() { }
        public Azure.Provisioning.BicepValue<string> DnsServer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RootDomainName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WindowsVmLicenseType
    {
        None = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Windows_Server")]
        WindowsServer = 1,
    }
    public enum WorkloadRuntime
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="OCIContainer")]
        OciContainer = 0,
        WasmWasi = 1,
        KataMshvVmIsolation = 2,
        KataVmIsolation = 3,
    }
}
