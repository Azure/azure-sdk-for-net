namespace Azure.Provisioning.ContainerService
{
    public enum AgentPoolMode
    {
        System = 0,
        User = 1,
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
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ContainerServiceIPTag> NodePublicIPTags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AgentPoolSnapshot : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AgentPoolSnapshot(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CreationDataSourceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableFips { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
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
        public static Azure.Provisioning.ContainerService.AgentPoolSnapshot FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2021_10_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_02_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_04_01;
            public static readonly string V2022_06_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_08_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_03_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_07_01;
            public static readonly string V2023_08_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_10_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_06_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_08_01;
            public static readonly string V2024_09_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_02_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_04_01;
        }
    }
    public enum AgentPoolType
    {
        VirtualMachineScaleSets = 0,
        AvailabilitySet = 1,
    }
    public partial class AgentPoolUpgradeSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgentPoolUpgradeSettings() { }
        public Azure.Provisioning.BicepValue<int> DrainTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MaxSurge { get { throw null; } set { } }
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
    public partial class ContainerServiceAgentPool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerServiceAgentPool(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AvailabilityZones { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CapacityReservationGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CreationDataSourceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CurrentOrchestratorVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> EnableAutoScaling { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableEncryptionAtHost { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableFips { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableNodePublicIP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableUltraSsd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.GpuInstanceProfile> GpuInstanceProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> HostGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.ContainerService.KubeletConfig KubeletConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.KubeletDiskType> KubeletDiskType { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.LinuxOSConfig LinuxOSConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxPods { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.AgentPoolNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeImageVersion { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> NodeLabels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NodePublicIPPrefixId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NodeTaints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OrchestratorVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> OSDiskSizeInGB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOSDiskType> OSDiskType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOSSku> OSSku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOSType> OSType { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceManagedCluster? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PodSubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceStateCode> PowerStateCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ScaleDownMode> ScaleDownMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ScaleSetEvictionPolicy> ScaleSetEvictionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ScaleSetPriority> ScaleSetPriority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> SpotMaxPrice { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolType> TypePropertiesType { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.AgentPoolUpgradeSettings UpgradeSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VmSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VnetSubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.WorkloadRuntime> WorkloadRuntime { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ContainerServiceAgentPool FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_08_31;
            public static readonly string V2018_03_31;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_10_01;
            public static readonly string V2019_11_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_02_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_11_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_07_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2021_10_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_02_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_04_01;
            public static readonly string V2022_06_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_08_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_03_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_07_01;
            public static readonly string V2023_08_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_10_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_06_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_08_01;
            public static readonly string V2024_09_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_02_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_04_01;
        }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string GetBuiltInRoleName(Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
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
        [System.Runtime.Serialization.DataMemberAttribute(Name="standard")]
        Standard = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="basic")]
        Basic = 1,
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
        public ContainerServiceMaintenanceConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.ContainerService.ContainerServiceMaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ContainerServiceTimeSpan> NotAllowedTimes { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceManagedCluster? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ContainerServiceTimeInWeek> TimesInWeek { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ContainerServiceMaintenanceConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_08_31;
            public static readonly string V2018_03_31;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_10_01;
            public static readonly string V2019_11_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_02_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_11_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_07_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2021_10_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_02_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_04_01;
            public static readonly string V2022_06_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_08_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_03_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_07_01;
            public static readonly string V2023_08_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_10_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_06_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_08_01;
            public static readonly string V2024_09_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_02_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_04_01;
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
        public ContainerServiceManagedCluster(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.ContainerService.ManagedClusterAadProfile AadProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.ContainerService.ManagedClusterAddonProfile> AddonProfiles { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ManagedClusterAgentPoolProfile> AgentPoolProfiles { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterApiServerAccessProfile ApiServerAccessProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterAutoScalerProfile AutoScalerProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterAutoUpgradeProfile AutoUpgradeProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterMonitorProfileMetrics AzureMonitorMetrics { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzurePortalFqdn { get { throw null; } }
        public Azure.Provisioning.ContainerService.ManagedClusterIdentity ClusterIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CurrentKubernetesVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> DisableLocalAccounts { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DnsPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePodSecurityPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableRbac { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Fqdn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FqdnSubdomain { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterHttpProxyConfig HttpProxyConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.ContainerService.ContainerServiceUserAssignedIdentity> IdentityProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KubernetesVersion { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceLinuxProfile LinuxProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxAgentPools { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeResourceGroup { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterOidcIssuerProfile OidcIssuerProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterPodIdentityProfile PodIdentityProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceStateCode> PowerStateCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrivateFqdn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ContainerServicePrivateLinkResourceData> PrivateLinkResources { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServicePublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } }
        public Azure.Provisioning.ContainerService.ManagedClusterSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ServiceMeshProfile ServiceMeshProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterServicePrincipalProfile ServicePrincipalProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterStorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.KubernetesSupportPlan> SupportPlan { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.UpgradeOverrideSettings UpgradeOverrideSettings { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterWindowsProfile WindowsProfile { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterWorkloadAutoScalerProfile WorkloadAutoScalerProfile { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string? bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.ContainerService.ContainerServiceBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ContainerServiceManagedCluster FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_08_31;
            public static readonly string V2018_03_31;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_10_01;
            public static readonly string V2019_11_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_02_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_11_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_07_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2021_10_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_02_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_04_01;
            public static readonly string V2022_06_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_08_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_03_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_07_01;
            public static readonly string V2023_08_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_10_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_06_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_08_01;
            public static readonly string V2024_09_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_02_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_04_01;
        }
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
        [System.Runtime.Serialization.DataMemberAttribute(Name="calico")]
        Calico = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="azure")]
        Azure = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="cilium")]
        Cilium = 2,
    }
    public partial class ContainerServiceNetworkProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerServiceNetworkProfile() { }
        public Azure.Provisioning.BicepValue<string> DnsServiceIP { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.IPFamily> IPFamilies { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterLoadBalancerProfile LoadBalancerProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceLoadBalancerSku> LoadBalancerSku { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterNatGatewayProfile NatGatewayProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.NetworkDataplane> NetworkDataplane { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceNetworkMode> NetworkMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceNetworkPlugin> NetworkPlugin { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceNetworkPluginMode> NetworkPluginMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceNetworkPolicy> NetworkPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOutboundType> OutboundType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PodCidr { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PodCidrs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceCidr { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ServiceCidrs { get { throw null; } set { } }
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
        [System.Runtime.Serialization.DataMemberAttribute(Name="CBLMariner")]
        CblMariner = 2,
        Windows2019 = 3,
        Windows2022 = 4,
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
    }
    public partial class ContainerServicePrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerServicePrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.ContainerService.ContainerServicePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceManagedCluster? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServicePrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ContainerServicePrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_08_31;
            public static readonly string V2018_03_31;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_10_01;
            public static readonly string V2019_11_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_02_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_11_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_07_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2021_10_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_02_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_04_01;
            public static readonly string V2022_06_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_08_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_03_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_07_01;
            public static readonly string V2023_08_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_10_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_06_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_08_01;
            public static readonly string V2024_09_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_02_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_04_01;
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
    public enum ContainerServicePublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
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
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerServiceTrustedAccessRoleBinding : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerServiceTrustedAccessRoleBinding(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ContainerServiceManagedCluster? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceTrustedAccessRoleBindingProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Roles { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerService.ContainerServiceTrustedAccessRoleBinding FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_08_31;
            public static readonly string V2018_03_31;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_10_01;
            public static readonly string V2019_11_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_02_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_09_01;
            public static readonly string V2020_11_01;
            public static readonly string V2020_12_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_07_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_09_01;
            public static readonly string V2021_10_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_02_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_04_01;
            public static readonly string V2022_06_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_08_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_01_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_03_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_07_01;
            public static readonly string V2023_08_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_10_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_02_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_06_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_08_01;
            public static readonly string V2024_09_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_02_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_04_01;
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
    public enum IPFamily
    {
        IPv4 = 0,
        IPv6 = 1,
    }
    public partial class IstioComponents : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IstioComponents() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.IstioEgressGateway> EgressGateways { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.IstioIngressGateway> IngressGateways { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IstioEgressGateway : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IstioEgressGateway() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> NodeSelector { get { throw null; } set { } }
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
        public Azure.Provisioning.BicepValue<bool> FailStartWithSwapOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ImageGcHighThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ImageGcLowThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsCpuCfsQuotaEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PodMaxPids { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TopologyManagerPolicy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KubeletDiskType
    {
        OS = 0,
        Temporary = 1,
    }
    public enum KubernetesSupportPlan
    {
        KubernetesOfficial = 0,
        AKSLongTermSupport = 1,
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
    public partial class ManagedClusterAgentPoolProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterAgentPoolProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolType> AgentPoolType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AvailabilityZones { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CapacityReservationGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CreationDataSourceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CurrentOrchestratorVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> EnableAutoScaling { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableEncryptionAtHost { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableFips { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableNodePublicIP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableUltraSsd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.GpuInstanceProfile> GpuInstanceProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> HostGroupId { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.KubeletConfig KubeletConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.KubeletDiskType> KubeletDiskType { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.LinuxOSConfig LinuxOSConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxPods { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AgentPoolMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.AgentPoolNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeImageVersion { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> NodeLabels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NodePublicIPPrefixId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NodeTaints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OrchestratorVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> OSDiskSizeInGB { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOSDiskType> OSDiskType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOSSku> OSSku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceOSType> OSType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PodSubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ContainerServiceStateCode> PowerStateCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ScaleDownMode> ScaleDownMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ScaleSetEvictionPolicy> ScaleSetEvictionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ScaleSetPriority> ScaleSetPriority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> SpotMaxPrice { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.AgentPoolUpgradeSettings UpgradeSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VmSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VnetSubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.WorkloadRuntime> WorkloadRuntime { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterApiServerAccessProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterApiServerAccessProfile() { }
        public Azure.Provisioning.BicepList<string> AuthorizedIPRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableRunCommand { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePrivateCluster { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePrivateClusterPublicFqdn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateDnsZone { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterAutoScalerProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterAutoScalerProfile() { }
        public Azure.Provisioning.BicepValue<string> BalanceSimilarNodeGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.AutoScaleExpander> Expander { get { throw null; } set { } }
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
    public partial class ManagedClusterDelegatedIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterDelegatedIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReferralResource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterHttpProxyConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterHttpProxyConfig() { }
        public Azure.Provisioning.BicepValue<string> HttpProxy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HttpsProxy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NoProxy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TrustedCA { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterIdentity() { }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.ContainerService.ManagedClusterDelegatedIdentity> DelegatedResources { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Resources.ManagedServiceIdentityType> ResourceIdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Resources.UserAssignedIdentityDetails> UserAssignedIdentities { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedClusterKeyVaultNetworkAccessType
    {
        Public = 0,
        Private = 1,
    }
    public enum ManagedClusterLoadBalancerBackendPoolType
    {
        NodeIPConfiguration = 0,
        NodeIP = 1,
    }
    public partial class ManagedClusterLoadBalancerProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterLoadBalancerProfile() { }
        public Azure.Provisioning.BicepValue<int> AllocatedOutboundPorts { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerService.ManagedClusterLoadBalancerBackendPoolType> BackendPoolType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> EffectiveOutboundIPs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableMultipleStandardLoadBalancers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IdleTimeoutInMinutes { get { throw null; } set { } }
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
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterMonitorProfileKubeStateMetrics KubeStateMetrics { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterNatGatewayProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterNatGatewayProfile() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> EffectiveOutboundIPs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IdleTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ManagedOutboundIPCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedClusterNodeOSUpgradeChannel
    {
        None = 0,
        Unmanaged = 1,
        NodeImage = 2,
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
        public Azure.Provisioning.BicepValue<Azure.ResponseError> ErrorDetail { get { throw null; } }
        public Azure.Provisioning.ContainerService.ContainerServiceUserAssignedIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Namespace { get { throw null; } set { } }
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
        public Azure.Provisioning.BicepValue<bool> AllowNetworkPluginKubenet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ManagedClusterPodIdentity> UserAssignedIdentities { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerService.ManagedClusterPodIdentityException> UserAssignedIdentityExceptions { get { throw null; } set { } }
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
    public partial class ManagedClusterSecurityProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterSecurityProfile() { }
        public Azure.Provisioning.ContainerService.ManagedClusterSecurityProfileKeyVaultKms AzureKeyVaultKms { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterSecurityProfileDefender Defender { get { throw null; } set { } }
        public Azure.Provisioning.ContainerService.ManagedClusterSecurityProfileImageCleaner ImageCleaner { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsWorkloadIdentityEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedClusterSecurityProfileDefender : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterSecurityProfileDefender() { }
        public Azure.Provisioning.BicepValue<bool> IsSecurityMonitoringEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> LogAnalyticsWorkspaceResourceId { get { throw null; } set { } }
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
        Basic = 0,
        Base = 1,
    }
    public enum ManagedClusterSkuTier
    {
        Paid = 0,
        Premium = 1,
        Standard = 2,
        Free = 3,
    }
    public partial class ManagedClusterStorageProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedClusterStorageProfile() { }
        public Azure.Provisioning.BicepValue<bool> IsBlobCsiDriverEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDiskCsiDriverEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsFileCsiDriverEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSnapshotControllerEnabled { get { throw null; } set { } }
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
        public Azure.Provisioning.BicepValue<bool> IsVpaEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NetworkDataplane
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="azure")]
        Azure = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="cilium")]
        Cilium = 1,
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
    }
    public partial class SysctlConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SysctlConfig() { }
        public Azure.Provisioning.BicepValue<int> FsAioMaxNr { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FsFileMax { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FsInotifyMaxUserWatches { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FsNrOpen { get { throw null; } set { } }
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
        public Azure.Provisioning.BicepValue<bool> NetIPv4TcpTwReuse { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NetNetfilterNfConntrackBuckets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NetNetfilterNfConntrackMax { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> VmMaxMapCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> VmSwappiness { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> VmVfsCachePressure { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class UpgradeOverrideSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UpgradeOverrideSettings() { }
        public Azure.Provisioning.BicepValue<bool> ForceUpgrade { get { throw null; } set { } }
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
    }
}
