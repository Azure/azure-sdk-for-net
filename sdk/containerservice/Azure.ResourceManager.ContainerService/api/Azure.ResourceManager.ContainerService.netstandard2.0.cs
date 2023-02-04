namespace Azure.ResourceManager.ContainerService
{
    public partial class AgentPoolSnapshotCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource>, System.Collections.IEnumerable
    {
        protected AgentPoolSnapshotCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ContainerService.AgentPoolSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ContainerService.AgentPoolSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AgentPoolSnapshotData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AgentPoolSnapshotData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.Core.ResourceIdentifier CreationDataSourceResourceId { get { throw null; } set { } }
        public bool? EnableFips { get { throw null; } }
        public string KubernetesVersion { get { throw null; } }
        public string NodeImageVersion { get { throw null; } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku? OSSku { get { throw null; } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType? OSType { get { throw null; } }
        public Azure.ResourceManager.ContainerService.Models.SnapshotType? SnapshotType { get { throw null; } set { } }
        public string VmSize { get { throw null; } }
    }
    public partial class AgentPoolSnapshotResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AgentPoolSnapshotResource() { }
        public virtual Azure.ResourceManager.ContainerService.AgentPoolSnapshotData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource> Update(Azure.ResourceManager.ContainerService.Models.ContainerServiceTagsObject containerServiceTagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource>> UpdateAsync(Azure.ResourceManager.ContainerService.Models.ContainerServiceTagsObject containerServiceTagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AgentPoolUpgradeProfileData : Azure.ResourceManager.Models.ResourceData
    {
        internal AgentPoolUpgradeProfileData() { }
        public string KubernetesVersion { get { throw null; } }
        public string LatestNodeImageVersion { get { throw null; } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType OSType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerService.Models.AgentPoolUpgradeProfilePropertiesUpgradesItem> Upgrades { get { throw null; } }
    }
    public partial class AgentPoolUpgradeProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AgentPoolUpgradeProfileResource() { }
        public virtual Azure.ResourceManager.ContainerService.AgentPoolUpgradeProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string agentPoolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.AgentPoolUpgradeProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.AgentPoolUpgradeProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerServiceAgentPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource>, System.Collections.IEnumerable
    {
        protected ContainerServiceAgentPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource> Get(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource>> GetAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerServiceAgentPoolData : Azure.ResourceManager.Models.ResourceData
    {
        public ContainerServiceAgentPoolData() { }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public int? Count { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CreationDataSourceResourceId { get { throw null; } set { } }
        public string CurrentOrchestratorVersion { get { throw null; } }
        public bool? EnableAutoScaling { get { throw null; } set { } }
        public bool? EnableEncryptionAtHost { get { throw null; } set { } }
        public bool? EnableFips { get { throw null; } set { } }
        public bool? EnableNodePublicIP { get { throw null; } set { } }
        public bool? EnableUltraSsd { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.GpuInstanceProfile? GpuInstanceProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HostGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.KubeletConfig KubeletConfig { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.KubeletDiskType? KubeletDiskType { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.LinuxOSConfig LinuxOSConfig { get { throw null; } set { } }
        public int? MaxCount { get { throw null; } set { } }
        public int? MaxPods { get { throw null; } set { } }
        public int? MinCount { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.AgentPoolMode? Mode { get { throw null; } set { } }
        public string NodeImageVersion { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> NodeLabels { get { throw null; } }
        public Azure.Core.ResourceIdentifier NodePublicIPPrefixId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NodeTaints { get { throw null; } }
        public string OrchestratorVersion { get { throw null; } set { } }
        public int? OSDiskSizeInGB { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceOSDiskType? OSDiskType { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku? OSSku { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType? OSType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PodSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceStateCode? PowerStateCode { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ScaleDownMode? ScaleDownMode { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ScaleSetEvictionPolicy? ScaleSetEvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ScaleSetPriority? ScaleSetPriority { get { throw null; } set { } }
        public float? SpotMaxPrice { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.ContainerService.Models.AgentPoolType? TypePropertiesType { get { throw null; } set { } }
        public string UpgradeMaxSurge { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VnetSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.WorkloadRuntime? WorkloadRuntime { get { throw null; } set { } }
    }
    public partial class ContainerServiceAgentPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerServiceAgentPoolResource() { }
        public virtual Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string agentPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerService.AgentPoolUpgradeProfileResource GetAgentPoolUpgradeProfile() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpgradeNodeImageVersion(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeNodeImageVersionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ContainerServiceExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource> GetAgentPoolSnapshot(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource>> GetAgentPoolSnapshotAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource GetAgentPoolSnapshotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerService.AgentPoolSnapshotCollection GetAgentPoolSnapshots(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource> GetAgentPoolSnapshots(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerService.AgentPoolSnapshotResource> GetAgentPoolSnapshotsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerService.AgentPoolUpgradeProfileResource GetAgentPoolUpgradeProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource GetContainerServiceAgentPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationResource GetContainerServiceMaintenanceConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource> GetContainerServiceManagedCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource>> GetContainerServiceManagedClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource GetContainerServiceManagedClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterCollection GetContainerServiceManagedClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource> GetContainerServiceManagedClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource> GetContainerServiceManagedClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionResource GetContainerServicePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerService.ManagedClusterUpgradeProfileResource GetManagedClusterUpgradeProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerService.OSOptionProfileResource GetOSOptionProfile(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.ContainerService.OSOptionProfileResource GetOSOptionProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ContainerServiceMaintenanceConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationResource>, System.Collections.IEnumerable
    {
        protected ContainerServiceMaintenanceConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configName, Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configName, Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationResource> Get(string configName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationResource>> GetAsync(string configName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerServiceMaintenanceConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public ContainerServiceMaintenanceConfigurationData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerService.Models.ContainerServiceTimeSpan> NotAllowedTimes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerService.Models.ContainerServiceTimeInWeek> TimesInWeek { get { throw null; } }
    }
    public partial class ContainerServiceMaintenanceConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerServiceMaintenanceConfigurationResource() { }
        public virtual Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string configName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerServiceManagedClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource>, System.Collections.IEnumerable
    {
        protected ContainerServiceManagedClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerServiceManagedClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ContainerServiceManagedClusterData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterAadProfile AadProfile { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ContainerService.Models.ManagedClusterAddonProfile> AddonProfiles { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerService.Models.ManagedClusterAgentPoolProfile> AgentPoolProfiles { get { throw null; } }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterApiServerAccessProfile ApiServerAccessProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterAutoScalerProfile AutoScalerProfile { get { throw null; } set { } }
        public string AzurePortalFqdn { get { throw null; } }
        public string CurrentKubernetesVersion { get { throw null; } }
        public bool? DisableLocalAccounts { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public string DnsPrefix { get { throw null; } set { } }
        public bool? EnablePodSecurityPolicy { get { throw null; } set { } }
        public bool? EnableRbac { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public string FqdnSubdomain { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterHttpProxyConfig HttpProxyConfig { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ContainerService.Models.ContainerServiceUserAssignedIdentity> IdentityProfile { get { throw null; } }
        public string KubernetesVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceLinuxProfile LinuxProfile { get { throw null; } set { } }
        public int? MaxAgentPools { get { throw null; } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkProfile NetworkProfile { get { throw null; } set { } }
        public string NodeResourceGroup { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterOidcIssuerProfile OidcIssuerProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterPodIdentityProfile PodIdentityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceStateCode? PowerStateCode { get { throw null; } }
        public string PrivateFqdn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkResourceData> PrivateLinkResources { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServicePublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterSecurityProfileAzureDefender SecurityAzureDefender { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterServicePrincipalProfile ServicePrincipalProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterStorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.UpgradeChannel? UpgradeChannel { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterWindowsProfile WindowsProfile { get { throw null; } set { } }
    }
    public partial class ContainerServiceManagedClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerServiceManagedClusterResource() { }
        public virtual Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.Models.ManagedClusterAccessProfile> GetAccessProfile(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.Models.ManagedClusterAccessProfile>> GetAccessProfileAsync(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.Models.AgentPoolAvailableVersions> GetAvailableAgentPoolVersions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.Models.AgentPoolAvailableVersions>> GetAvailableAgentPoolVersionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.Models.ManagedClusterCredentials> GetClusterAdminCredentials(string serverFqdn = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.Models.ManagedClusterCredentials>> GetClusterAdminCredentialsAsync(string serverFqdn = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.Models.ManagedClusterCredentials> GetClusterMonitoringUserCredentials(string serverFqdn = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.Models.ManagedClusterCredentials>> GetClusterMonitoringUserCredentialsAsync(string serverFqdn = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.Models.ManagedClusterCredentials> GetClusterUserCredentials(string serverFqdn = null, Azure.ResourceManager.ContainerService.Models.KubeConfigFormat? format = default(Azure.ResourceManager.ContainerService.Models.KubeConfigFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.Models.ManagedClusterCredentials>> GetClusterUserCredentialsAsync(string serverFqdn = null, Azure.ResourceManager.ContainerService.Models.KubeConfigFormat? format = default(Azure.ResourceManager.ContainerService.Models.KubeConfigFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.Models.ManagedClusterRunCommandResult> GetCommandResult(string commandId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.Models.ManagedClusterRunCommandResult>> GetCommandResultAsync(string commandId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource> GetContainerServiceAgentPool(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolResource>> GetContainerServiceAgentPoolAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolCollection GetContainerServiceAgentPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationResource> GetContainerServiceMaintenanceConfiguration(string configName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationResource>> GetContainerServiceMaintenanceConfigurationAsync(string configName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationCollection GetContainerServiceMaintenanceConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionResource> GetContainerServicePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionResource>> GetContainerServicePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionCollection GetContainerServicePrivateEndpointConnections() { throw null; }
        public virtual Azure.ResourceManager.ContainerService.ManagedClusterUpgradeProfileResource GetManagedClusterUpgradeProfile() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerService.Models.ContainerServiceOutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerService.Models.ContainerServiceOutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkResourceData> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkResourceData> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResetAadProfile(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerService.Models.ManagedClusterAadProfile managedClusterAadProfile, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResetAadProfileAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerService.Models.ManagedClusterAadProfile managedClusterAadProfile, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResetServicePrincipalProfile(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerService.Models.ManagedClusterServicePrincipalProfile managedClusterServicePrincipalProfile, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResetServicePrincipalProfileAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerService.Models.ManagedClusterServicePrincipalProfile managedClusterServicePrincipalProfile, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkResourceData> ResolvePrivateLinkServiceId(Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkResourceData>> ResolvePrivateLinkServiceIdAsync(Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RotateClusterCertificates(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RotateClusterCertificatesAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RotateServiceAccountSigningKeys(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RotateServiceAccountSigningKeysAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerService.Models.ManagedClusterRunCommandResult> RunCommand(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerService.Models.ManagedClusterRunCommandContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerService.Models.ManagedClusterRunCommandResult>> RunCommandAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerService.Models.ManagedClusterRunCommandContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerService.Models.ContainerServiceTagsObject containerServiceTagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerService.Models.ContainerServiceTagsObject containerServiceTagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerServicePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected ContainerServicePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerServicePrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public ContainerServicePrivateEndpointConnectionData() { }
        public Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ContainerServicePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerServicePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedClusterUpgradeProfileData : Azure.ResourceManager.Models.ResourceData
    {
        internal ManagedClusterUpgradeProfileData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerService.Models.ManagedClusterPoolUpgradeProfile> AgentPoolProfiles { get { throw null; } }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterPoolUpgradeProfile ControlPlaneProfile { get { throw null; } }
    }
    public partial class ManagedClusterUpgradeProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedClusterUpgradeProfileResource() { }
        public virtual Azure.ResourceManager.ContainerService.ManagedClusterUpgradeProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.ManagedClusterUpgradeProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.ManagedClusterUpgradeProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OSOptionProfileData : Azure.ResourceManager.Models.ResourceData
    {
        internal OSOptionProfileData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerService.Models.ContainerServiceOSOptionProperty> OSOptionPropertyList { get { throw null; } }
    }
    public partial class OSOptionProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OSOptionProfileResource() { }
        public virtual Azure.ResourceManager.ContainerService.OSOptionProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerService.OSOptionProfileResource> Get(Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerService.OSOptionProfileResource>> GetAsync(Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class AgentPoolAvailableVersion
    {
        internal AgentPoolAvailableVersion() { }
        public bool? IsDefault { get { throw null; } }
        public bool? IsPreview { get { throw null; } }
        public string KubernetesVersion { get { throw null; } }
    }
    public partial class AgentPoolAvailableVersions : Azure.ResourceManager.Models.ResourceData
    {
        internal AgentPoolAvailableVersions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerService.Models.AgentPoolAvailableVersion> AgentPoolVersions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentPoolMode : System.IEquatable<Azure.ResourceManager.ContainerService.Models.AgentPoolMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentPoolMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.AgentPoolMode System { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.AgentPoolMode User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.AgentPoolMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.AgentPoolMode left, Azure.ResourceManager.ContainerService.Models.AgentPoolMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.AgentPoolMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.AgentPoolMode left, Azure.ResourceManager.ContainerService.Models.AgentPoolMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentPoolType : System.IEquatable<Azure.ResourceManager.ContainerService.Models.AgentPoolType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentPoolType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.AgentPoolType AvailabilitySet { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.AgentPoolType VirtualMachineScaleSets { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.AgentPoolType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.AgentPoolType left, Azure.ResourceManager.ContainerService.Models.AgentPoolType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.AgentPoolType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.AgentPoolType left, Azure.ResourceManager.ContainerService.Models.AgentPoolType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentPoolUpgradeProfilePropertiesUpgradesItem
    {
        internal AgentPoolUpgradeProfilePropertiesUpgradesItem() { }
        public bool? IsPreview { get { throw null; } }
        public string KubernetesVersion { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoScaleExpander : System.IEquatable<Azure.ResourceManager.ContainerService.Models.AutoScaleExpander>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoScaleExpander(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.AutoScaleExpander LeastWaste { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.AutoScaleExpander MostPods { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.AutoScaleExpander Priority { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.AutoScaleExpander Random { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.AutoScaleExpander other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.AutoScaleExpander left, Azure.ResourceManager.ContainerService.Models.AutoScaleExpander right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.AutoScaleExpander (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.AutoScaleExpander left, Azure.ResourceManager.ContainerService.Models.AutoScaleExpander right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceEndpointDependency
    {
        internal ContainerServiceEndpointDependency() { }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerService.Models.ContainerServiceEndpointDetail> EndpointDetails { get { throw null; } }
    }
    public partial class ContainerServiceEndpointDetail
    {
        internal ContainerServiceEndpointDetail() { }
        public string Description { get { throw null; } }
        public System.Net.IPAddress IPAddress { get { throw null; } }
        public int? Port { get { throw null; } }
        public string Protocol { get { throw null; } }
    }
    public partial class ContainerServiceLinuxProfile
    {
        public ContainerServiceLinuxProfile(string adminUsername, Azure.ResourceManager.ContainerService.Models.ContainerServiceSshConfiguration ssh) { }
        public string AdminUsername { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerService.Models.ContainerServiceSshPublicKey> SshPublicKeys { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceLoadBalancerSku : System.IEquatable<Azure.ResourceManager.ContainerService.Models.ContainerServiceLoadBalancerSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceLoadBalancerSku(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceLoadBalancerSku Basic { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceLoadBalancerSku Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.ContainerServiceLoadBalancerSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.ContainerServiceLoadBalancerSku left, Azure.ResourceManager.ContainerService.Models.ContainerServiceLoadBalancerSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.ContainerServiceLoadBalancerSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.ContainerServiceLoadBalancerSku left, Azure.ResourceManager.ContainerService.Models.ContainerServiceLoadBalancerSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ContainerServiceModelFactory
    {
        public static Azure.ResourceManager.ContainerService.Models.AgentPoolAvailableVersion AgentPoolAvailableVersion(bool? isDefault = default(bool?), string kubernetesVersion = null, bool? isPreview = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.AgentPoolAvailableVersions AgentPoolAvailableVersions(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.Models.AgentPoolAvailableVersion> agentPoolVersions = null) { throw null; }
        public static Azure.ResourceManager.ContainerService.AgentPoolSnapshotData AgentPoolSnapshotData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier creationDataSourceResourceId = null, Azure.ResourceManager.ContainerService.Models.SnapshotType? snapshotType = default(Azure.ResourceManager.ContainerService.Models.SnapshotType?), string kubernetesVersion = null, string nodeImageVersion = null, Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType? osType = default(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType?), Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku? osSku = default(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku?), string vmSize = null, bool? enableFips = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ContainerService.AgentPoolUpgradeProfileData AgentPoolUpgradeProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kubernetesVersion = null, Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType osType = default(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.Models.AgentPoolUpgradeProfilePropertiesUpgradesItem> upgrades = null, string latestNodeImageVersion = null) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.AgentPoolUpgradeProfilePropertiesUpgradesItem AgentPoolUpgradeProfilePropertiesUpgradesItem(string kubernetesVersion = null, bool? isPreview = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ContainerService.ContainerServiceAgentPoolData ContainerServiceAgentPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? count = default(int?), string vmSize = null, int? osDiskSizeInGB = default(int?), Azure.ResourceManager.ContainerService.Models.ContainerServiceOSDiskType? osDiskType = default(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSDiskType?), Azure.ResourceManager.ContainerService.Models.KubeletDiskType? kubeletDiskType = default(Azure.ResourceManager.ContainerService.Models.KubeletDiskType?), Azure.ResourceManager.ContainerService.Models.WorkloadRuntime? workloadRuntime = default(Azure.ResourceManager.ContainerService.Models.WorkloadRuntime?), Azure.Core.ResourceIdentifier vnetSubnetId = null, Azure.Core.ResourceIdentifier podSubnetId = null, int? maxPods = default(int?), Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType? osType = default(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType?), Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku? osSku = default(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku?), int? maxCount = default(int?), int? minCount = default(int?), bool? enableAutoScaling = default(bool?), Azure.ResourceManager.ContainerService.Models.ScaleDownMode? scaleDownMode = default(Azure.ResourceManager.ContainerService.Models.ScaleDownMode?), Azure.ResourceManager.ContainerService.Models.AgentPoolType? typePropertiesType = default(Azure.ResourceManager.ContainerService.Models.AgentPoolType?), Azure.ResourceManager.ContainerService.Models.AgentPoolMode? mode = default(Azure.ResourceManager.ContainerService.Models.AgentPoolMode?), string orchestratorVersion = null, string currentOrchestratorVersion = null, string nodeImageVersion = null, string upgradeMaxSurge = null, string provisioningState = null, Azure.ResourceManager.ContainerService.Models.ContainerServiceStateCode? powerStateCode = default(Azure.ResourceManager.ContainerService.Models.ContainerServiceStateCode?), System.Collections.Generic.IEnumerable<string> availabilityZones = null, bool? enableNodePublicIP = default(bool?), Azure.Core.ResourceIdentifier nodePublicIPPrefixId = null, Azure.ResourceManager.ContainerService.Models.ScaleSetPriority? scaleSetPriority = default(Azure.ResourceManager.ContainerService.Models.ScaleSetPriority?), Azure.ResourceManager.ContainerService.Models.ScaleSetEvictionPolicy? scaleSetEvictionPolicy = default(Azure.ResourceManager.ContainerService.Models.ScaleSetEvictionPolicy?), float? spotMaxPrice = default(float?), System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> nodeLabels = null, System.Collections.Generic.IEnumerable<string> nodeTaints = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, Azure.ResourceManager.ContainerService.Models.KubeletConfig kubeletConfig = null, Azure.ResourceManager.ContainerService.Models.LinuxOSConfig linuxOSConfig = null, bool? enableEncryptionAtHost = default(bool?), bool? enableUltraSsd = default(bool?), bool? enableFips = default(bool?), Azure.ResourceManager.ContainerService.Models.GpuInstanceProfile? gpuInstanceProfile = default(Azure.ResourceManager.ContainerService.Models.GpuInstanceProfile?), Azure.Core.ResourceIdentifier creationDataSourceResourceId = null, Azure.Core.ResourceIdentifier hostGroupId = null) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceEndpointDependency ContainerServiceEndpointDependency(string domainName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.Models.ContainerServiceEndpointDetail> endpointDetails = null) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceEndpointDetail ContainerServiceEndpointDetail(System.Net.IPAddress ipAddress = null, int? port = default(int?), string protocol = null, string description = null) { throw null; }
        public static Azure.ResourceManager.ContainerService.ContainerServiceMaintenanceConfigurationData ContainerServiceMaintenanceConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.Models.ContainerServiceTimeInWeek> timesInWeek = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.Models.ContainerServiceTimeSpan> notAllowedTimes = null) { throw null; }
        public static Azure.ResourceManager.ContainerService.ContainerServiceManagedClusterData ContainerServiceManagedClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ContainerService.Models.ManagedClusterSku sku = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string provisioningState = null, Azure.ResourceManager.ContainerService.Models.ContainerServiceStateCode? powerStateCode = default(Azure.ResourceManager.ContainerService.Models.ContainerServiceStateCode?), int? maxAgentPools = default(int?), string kubernetesVersion = null, string currentKubernetesVersion = null, string dnsPrefix = null, string fqdnSubdomain = null, string fqdn = null, string privateFqdn = null, string azurePortalFqdn = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.Models.ManagedClusterAgentPoolProfile> agentPoolProfiles = null, Azure.ResourceManager.ContainerService.Models.ContainerServiceLinuxProfile linuxProfile = null, Azure.ResourceManager.ContainerService.Models.ManagedClusterWindowsProfile windowsProfile = null, Azure.ResourceManager.ContainerService.Models.ManagedClusterServicePrincipalProfile servicePrincipalProfile = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ContainerService.Models.ManagedClusterAddonProfile> addonProfiles = null, Azure.ResourceManager.ContainerService.Models.ManagedClusterPodIdentityProfile podIdentityProfile = null, Azure.ResourceManager.ContainerService.Models.ManagedClusterOidcIssuerProfile oidcIssuerProfile = null, string nodeResourceGroup = null, bool? enableRbac = default(bool?), bool? enablePodSecurityPolicy = default(bool?), Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkProfile networkProfile = null, Azure.ResourceManager.ContainerService.Models.ManagedClusterAadProfile aadProfile = null, Azure.ResourceManager.ContainerService.Models.UpgradeChannel? upgradeChannel = default(Azure.ResourceManager.ContainerService.Models.UpgradeChannel?), Azure.ResourceManager.ContainerService.Models.ManagedClusterAutoScalerProfile autoScalerProfile = null, Azure.ResourceManager.ContainerService.Models.ManagedClusterApiServerAccessProfile apiServerAccessProfile = null, Azure.Core.ResourceIdentifier diskEncryptionSetId = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ContainerService.Models.ContainerServiceUserAssignedIdentity> identityProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkResourceData> privateLinkResources = null, bool? disableLocalAccounts = default(bool?), Azure.ResourceManager.ContainerService.Models.ManagedClusterHttpProxyConfig httpProxyConfig = null, Azure.ResourceManager.ContainerService.Models.ManagedClusterSecurityProfile securityProfile = null, Azure.ResourceManager.ContainerService.Models.ManagedClusterStorageProfile storageProfile = null, Azure.ResourceManager.ContainerService.Models.ContainerServicePublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.ContainerService.Models.ContainerServicePublicNetworkAccess?)) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceOSOptionProperty ContainerServiceOSOptionProperty(string osType = null, bool enableFipsImage = false) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceOutboundEnvironmentEndpoint ContainerServiceOutboundEnvironmentEndpoint(string category = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.Models.ContainerServiceEndpointDependency> endpoints = null) { throw null; }
        public static Azure.ResourceManager.ContainerService.ContainerServicePrivateEndpointConnectionData ContainerServicePrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateEndpointConnectionProvisioningState?), Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkServiceConnectionState connectionState = null) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkResourceData ContainerServicePrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, Azure.Core.ResourceIdentifier privateLinkServiceId = null) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ManagedClusterAccessProfile ManagedClusterAccessProfile(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), byte[] kubeConfig = null) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ManagedClusterAddonProfile ManagedClusterAddonProfile(bool isEnabled = false, System.Collections.Generic.IDictionary<string, string> config = null, Azure.ResourceManager.ContainerService.Models.ManagedClusterAddonProfileIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ManagedClusterAgentPoolProfile ManagedClusterAgentPoolProfile(int? count = default(int?), string vmSize = null, int? osDiskSizeInGB = default(int?), Azure.ResourceManager.ContainerService.Models.ContainerServiceOSDiskType? osDiskType = default(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSDiskType?), Azure.ResourceManager.ContainerService.Models.KubeletDiskType? kubeletDiskType = default(Azure.ResourceManager.ContainerService.Models.KubeletDiskType?), Azure.ResourceManager.ContainerService.Models.WorkloadRuntime? workloadRuntime = default(Azure.ResourceManager.ContainerService.Models.WorkloadRuntime?), Azure.Core.ResourceIdentifier vnetSubnetId = null, Azure.Core.ResourceIdentifier podSubnetId = null, int? maxPods = default(int?), Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType? osType = default(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType?), Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku? osSku = default(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku?), int? maxCount = default(int?), int? minCount = default(int?), bool? enableAutoScaling = default(bool?), Azure.ResourceManager.ContainerService.Models.ScaleDownMode? scaleDownMode = default(Azure.ResourceManager.ContainerService.Models.ScaleDownMode?), Azure.ResourceManager.ContainerService.Models.AgentPoolType? agentPoolType = default(Azure.ResourceManager.ContainerService.Models.AgentPoolType?), Azure.ResourceManager.ContainerService.Models.AgentPoolMode? mode = default(Azure.ResourceManager.ContainerService.Models.AgentPoolMode?), string orchestratorVersion = null, string currentOrchestratorVersion = null, string nodeImageVersion = null, string upgradeMaxSurge = null, string provisioningState = null, Azure.ResourceManager.ContainerService.Models.ContainerServiceStateCode? powerStateCode = default(Azure.ResourceManager.ContainerService.Models.ContainerServiceStateCode?), System.Collections.Generic.IEnumerable<string> availabilityZones = null, bool? enableNodePublicIP = default(bool?), Azure.Core.ResourceIdentifier nodePublicIPPrefixId = null, Azure.ResourceManager.ContainerService.Models.ScaleSetPriority? scaleSetPriority = default(Azure.ResourceManager.ContainerService.Models.ScaleSetPriority?), Azure.ResourceManager.ContainerService.Models.ScaleSetEvictionPolicy? scaleSetEvictionPolicy = default(Azure.ResourceManager.ContainerService.Models.ScaleSetEvictionPolicy?), float? spotMaxPrice = default(float?), System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> nodeLabels = null, System.Collections.Generic.IEnumerable<string> nodeTaints = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, Azure.ResourceManager.ContainerService.Models.KubeletConfig kubeletConfig = null, Azure.ResourceManager.ContainerService.Models.LinuxOSConfig linuxOSConfig = null, bool? enableEncryptionAtHost = default(bool?), bool? enableUltraSsd = default(bool?), bool? enableFips = default(bool?), Azure.ResourceManager.ContainerService.Models.GpuInstanceProfile? gpuInstanceProfile = default(Azure.ResourceManager.ContainerService.Models.GpuInstanceProfile?), Azure.Core.ResourceIdentifier creationDataSourceResourceId = null, Azure.Core.ResourceIdentifier hostGroupId = null, string name = null) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ManagedClusterAgentPoolProfileProperties ManagedClusterAgentPoolProfileProperties(int? count = default(int?), string vmSize = null, int? osDiskSizeInGB = default(int?), Azure.ResourceManager.ContainerService.Models.ContainerServiceOSDiskType? osDiskType = default(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSDiskType?), Azure.ResourceManager.ContainerService.Models.KubeletDiskType? kubeletDiskType = default(Azure.ResourceManager.ContainerService.Models.KubeletDiskType?), Azure.ResourceManager.ContainerService.Models.WorkloadRuntime? workloadRuntime = default(Azure.ResourceManager.ContainerService.Models.WorkloadRuntime?), Azure.Core.ResourceIdentifier vnetSubnetId = null, Azure.Core.ResourceIdentifier podSubnetId = null, int? maxPods = default(int?), Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType? osType = default(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType?), Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku? osSku = default(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku?), int? maxCount = default(int?), int? minCount = default(int?), bool? enableAutoScaling = default(bool?), Azure.ResourceManager.ContainerService.Models.ScaleDownMode? scaleDownMode = default(Azure.ResourceManager.ContainerService.Models.ScaleDownMode?), Azure.ResourceManager.ContainerService.Models.AgentPoolType? agentPoolType = default(Azure.ResourceManager.ContainerService.Models.AgentPoolType?), Azure.ResourceManager.ContainerService.Models.AgentPoolMode? mode = default(Azure.ResourceManager.ContainerService.Models.AgentPoolMode?), string orchestratorVersion = null, string currentOrchestratorVersion = null, string nodeImageVersion = null, string upgradeMaxSurge = null, string provisioningState = null, Azure.ResourceManager.ContainerService.Models.ContainerServiceStateCode? powerStateCode = default(Azure.ResourceManager.ContainerService.Models.ContainerServiceStateCode?), System.Collections.Generic.IEnumerable<string> availabilityZones = null, bool? enableNodePublicIP = default(bool?), Azure.Core.ResourceIdentifier nodePublicIPPrefixId = null, Azure.ResourceManager.ContainerService.Models.ScaleSetPriority? scaleSetPriority = default(Azure.ResourceManager.ContainerService.Models.ScaleSetPriority?), Azure.ResourceManager.ContainerService.Models.ScaleSetEvictionPolicy? scaleSetEvictionPolicy = default(Azure.ResourceManager.ContainerService.Models.ScaleSetEvictionPolicy?), float? spotMaxPrice = default(float?), System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> nodeLabels = null, System.Collections.Generic.IEnumerable<string> nodeTaints = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, Azure.ResourceManager.ContainerService.Models.KubeletConfig kubeletConfig = null, Azure.ResourceManager.ContainerService.Models.LinuxOSConfig linuxOSConfig = null, bool? enableEncryptionAtHost = default(bool?), bool? enableUltraSsd = default(bool?), bool? enableFips = default(bool?), Azure.ResourceManager.ContainerService.Models.GpuInstanceProfile? gpuInstanceProfile = default(Azure.ResourceManager.ContainerService.Models.GpuInstanceProfile?), Azure.Core.ResourceIdentifier creationDataSourceResourceId = null, Azure.Core.ResourceIdentifier hostGroupId = null) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ManagedClusterCredential ManagedClusterCredential(string name = null, byte[] value = null) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ManagedClusterCredentials ManagedClusterCredentials(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.Models.ManagedClusterCredential> kubeconfigs = null) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ManagedClusterOidcIssuerProfile ManagedClusterOidcIssuerProfile(string issuerUriInfo = null, bool? isEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ManagedClusterPodIdentity ManagedClusterPodIdentity(string name = null, string @namespace = null, string bindingSelector = null, Azure.ResourceManager.ContainerService.Models.ContainerServiceUserAssignedIdentity identity = null, Azure.ResourceManager.ContainerService.Models.ManagedClusterPodIdentityProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerService.Models.ManagedClusterPodIdentityProvisioningState?), Azure.ResponseError errorDetail = null) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ManagedClusterPoolUpgradeProfile ManagedClusterPoolUpgradeProfile(string kubernetesVersion = null, string name = null, Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType osType = default(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.Models.ManagedClusterPoolUpgradeProfileUpgradesItem> upgrades = null) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ManagedClusterPoolUpgradeProfileUpgradesItem ManagedClusterPoolUpgradeProfileUpgradesItem(string kubernetesVersion = null, bool? isPreview = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ManagedClusterRunCommandResult ManagedClusterRunCommandResult(string id = null, string provisioningState = null, int? exitCode = default(int?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? finishedOn = default(System.DateTimeOffset?), string logs = null, string reason = null) { throw null; }
        public static Azure.ResourceManager.ContainerService.ManagedClusterUpgradeProfileData ManagedClusterUpgradeProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerService.Models.ManagedClusterPoolUpgradeProfile controlPlaneProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.Models.ManagedClusterPoolUpgradeProfile> agentPoolProfiles = null) { throw null; }
        public static Azure.ResourceManager.ContainerService.OSOptionProfileData OSOptionProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.Models.ContainerServiceOSOptionProperty> osOptionPropertyList = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceNetworkMode : System.IEquatable<Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceNetworkMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkMode Bridge { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkMode Transparent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkMode left, Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkMode left, Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceNetworkPlugin : System.IEquatable<Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPlugin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceNetworkPlugin(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPlugin Azure { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPlugin Kubenet { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPlugin None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPlugin other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPlugin left, Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPlugin right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPlugin (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPlugin left, Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPlugin right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceNetworkPolicy : System.IEquatable<Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceNetworkPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPolicy Azure { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPolicy Calico { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPolicy left, Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPolicy left, Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceNetworkProfile
    {
        public ContainerServiceNetworkProfile() { }
        public string DnsServiceIP { get { throw null; } set { } }
        public string DockerBridgeCidr { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerService.Models.IPFamily> IPFamilies { get { throw null; } }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterLoadBalancerProfile LoadBalancerProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceLoadBalancerSku? LoadBalancerSku { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterNatGatewayProfile NatGatewayProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkMode? NetworkMode { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPlugin? NetworkPlugin { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceNetworkPolicy? NetworkPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceOutboundType? OutboundType { get { throw null; } set { } }
        public string PodCidr { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PodCidrs { get { throw null; } }
        public string ServiceCidr { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ServiceCidrs { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceOSDiskType : System.IEquatable<Azure.ResourceManager.ContainerService.Models.ContainerServiceOSDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceOSDiskType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceOSDiskType Ephemeral { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceOSDiskType Managed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSDiskType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSDiskType left, Azure.ResourceManager.ContainerService.Models.ContainerServiceOSDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.ContainerServiceOSDiskType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSDiskType left, Azure.ResourceManager.ContainerService.Models.ContainerServiceOSDiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceOSOptionProperty
    {
        internal ContainerServiceOSOptionProperty() { }
        public bool EnableFipsImage { get { throw null; } }
        public string OSType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceOSSku : System.IEquatable<Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceOSSku(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku CblMariner { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku Ubuntu { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku Windows2019 { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku Windows2022 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku left, Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku left, Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceOSType : System.IEquatable<Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceOSType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType Linux { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType left, Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType left, Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceOutboundEnvironmentEndpoint
    {
        internal ContainerServiceOutboundEnvironmentEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerService.Models.ContainerServiceEndpointDependency> Endpoints { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceOutboundType : System.IEquatable<Azure.ResourceManager.ContainerService.Models.ContainerServiceOutboundType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceOutboundType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceOutboundType LoadBalancer { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceOutboundType ManagedNatGateway { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceOutboundType UserAssignedNatGateway { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceOutboundType UserDefinedRouting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.ContainerServiceOutboundType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.ContainerServiceOutboundType left, Azure.ResourceManager.ContainerService.Models.ContainerServiceOutboundType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.ContainerServiceOutboundType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.ContainerServiceOutboundType left, Azure.ResourceManager.ContainerService.Models.ContainerServiceOutboundType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServicePrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServicePrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServicePrivateLinkResourceData
    {
        public ContainerServicePrivateLinkResourceData() { }
        public string GroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkServiceId { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredMembers { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
    }
    public partial class ContainerServicePrivateLinkServiceConnectionState
    {
        public ContainerServicePrivateLinkServiceConnectionState() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServicePrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServicePrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkServiceConnectionStatus left, Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkServiceConnectionStatus left, Azure.ResourceManager.ContainerService.Models.ContainerServicePrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServicePublicNetworkAccess : System.IEquatable<Azure.ResourceManager.ContainerService.Models.ContainerServicePublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServicePublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServicePublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServicePublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.ContainerServicePublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.ContainerServicePublicNetworkAccess left, Azure.ResourceManager.ContainerService.Models.ContainerServicePublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.ContainerServicePublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.ContainerServicePublicNetworkAccess left, Azure.ResourceManager.ContainerService.Models.ContainerServicePublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceSshConfiguration
    {
        public ContainerServiceSshConfiguration(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerService.Models.ContainerServiceSshPublicKey> publicKeys) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerService.Models.ContainerServiceSshPublicKey> PublicKeys { get { throw null; } }
    }
    public partial class ContainerServiceSshPublicKey
    {
        public ContainerServiceSshPublicKey(string keyData) { }
        public string KeyData { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceStateCode : System.IEquatable<Azure.ResourceManager.ContainerService.Models.ContainerServiceStateCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceStateCode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceStateCode Running { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceStateCode Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.ContainerServiceStateCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.ContainerServiceStateCode left, Azure.ResourceManager.ContainerService.Models.ContainerServiceStateCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.ContainerServiceStateCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.ContainerServiceStateCode left, Azure.ResourceManager.ContainerService.Models.ContainerServiceStateCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceTagsObject
    {
        public ContainerServiceTagsObject() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ContainerServiceTimeInWeek
    {
        public ContainerServiceTimeInWeek() { }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceWeekDay? Day { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> HourSlots { get { throw null; } }
    }
    public partial class ContainerServiceTimeSpan
    {
        public ContainerServiceTimeSpan() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class ContainerServiceUserAssignedIdentity
    {
        public ContainerServiceUserAssignedIdentity() { }
        public System.Guid? ClientId { get { throw null; } set { } }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceWeekDay : System.IEquatable<Azure.ResourceManager.ContainerService.Models.ContainerServiceWeekDay>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceWeekDay(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceWeekDay Friday { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceWeekDay Monday { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceWeekDay Saturday { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceWeekDay Sunday { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceWeekDay Thursday { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceWeekDay Tuesday { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ContainerServiceWeekDay Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.ContainerServiceWeekDay other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.ContainerServiceWeekDay left, Azure.ResourceManager.ContainerService.Models.ContainerServiceWeekDay right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.ContainerServiceWeekDay (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.ContainerServiceWeekDay left, Azure.ResourceManager.ContainerService.Models.ContainerServiceWeekDay right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GpuInstanceProfile : System.IEquatable<Azure.ResourceManager.ContainerService.Models.GpuInstanceProfile>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GpuInstanceProfile(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.GpuInstanceProfile Mig1G { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.GpuInstanceProfile Mig2G { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.GpuInstanceProfile Mig3G { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.GpuInstanceProfile Mig4G { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.GpuInstanceProfile Mig7G { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.GpuInstanceProfile other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.GpuInstanceProfile left, Azure.ResourceManager.ContainerService.Models.GpuInstanceProfile right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.GpuInstanceProfile (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.GpuInstanceProfile left, Azure.ResourceManager.ContainerService.Models.GpuInstanceProfile right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPFamily : System.IEquatable<Azure.ResourceManager.ContainerService.Models.IPFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPFamily(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.IPFamily IPv4 { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.IPFamily IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.IPFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.IPFamily left, Azure.ResourceManager.ContainerService.Models.IPFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.IPFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.IPFamily left, Azure.ResourceManager.ContainerService.Models.IPFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubeConfigFormat : System.IEquatable<Azure.ResourceManager.ContainerService.Models.KubeConfigFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubeConfigFormat(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.KubeConfigFormat Azure { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.KubeConfigFormat Exec { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.KubeConfigFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.KubeConfigFormat left, Azure.ResourceManager.ContainerService.Models.KubeConfigFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.KubeConfigFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.KubeConfigFormat left, Azure.ResourceManager.ContainerService.Models.KubeConfigFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KubeletConfig
    {
        public KubeletConfig() { }
        public System.Collections.Generic.IList<string> AllowedUnsafeSysctls { get { throw null; } }
        public int? ContainerLogMaxFiles { get { throw null; } set { } }
        public int? ContainerLogMaxSizeInMB { get { throw null; } set { } }
        public string CpuCfsQuotaPeriod { get { throw null; } set { } }
        public string CpuManagerPolicy { get { throw null; } set { } }
        public bool? FailStartWithSwapOn { get { throw null; } set { } }
        public int? ImageGcHighThreshold { get { throw null; } set { } }
        public int? ImageGcLowThreshold { get { throw null; } set { } }
        public bool? IsCpuCfsQuotaEnabled { get { throw null; } set { } }
        public int? PodMaxPids { get { throw null; } set { } }
        public string TopologyManagerPolicy { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubeletDiskType : System.IEquatable<Azure.ResourceManager.ContainerService.Models.KubeletDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubeletDiskType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.KubeletDiskType OS { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.KubeletDiskType Temporary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.KubeletDiskType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.KubeletDiskType left, Azure.ResourceManager.ContainerService.Models.KubeletDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.KubeletDiskType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.KubeletDiskType left, Azure.ResourceManager.ContainerService.Models.KubeletDiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinuxOSConfig
    {
        public LinuxOSConfig() { }
        public int? SwapFileSizeInMB { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.SysctlConfig Sysctls { get { throw null; } set { } }
        public string TransparentHugePageDefrag { get { throw null; } set { } }
        public string TransparentHugePageEnabled { get { throw null; } set { } }
    }
    public partial class ManagedClusterAadProfile
    {
        public ManagedClusterAadProfile() { }
        public System.Collections.Generic.IList<System.Guid> AdminGroupObjectIds { get { throw null; } }
        public System.Guid? ClientAppId { get { throw null; } set { } }
        public bool? IsAzureRbacEnabled { get { throw null; } set { } }
        public bool? IsManagedAadEnabled { get { throw null; } set { } }
        public System.Guid? ServerAppId { get { throw null; } set { } }
        public string ServerAppSecret { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class ManagedClusterAccessProfile : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ManagedClusterAccessProfile(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public byte[] KubeConfig { get { throw null; } set { } }
    }
    public partial class ManagedClusterAddonProfile
    {
        public ManagedClusterAddonProfile(bool isEnabled) { }
        public System.Collections.Generic.IDictionary<string, string> Config { get { throw null; } }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterAddonProfileIdentity Identity { get { throw null; } }
        public bool IsEnabled { get { throw null; } set { } }
    }
    public partial class ManagedClusterAddonProfileIdentity : Azure.ResourceManager.ContainerService.Models.ContainerServiceUserAssignedIdentity
    {
        public ManagedClusterAddonProfileIdentity() { }
    }
    public partial class ManagedClusterAgentPoolProfile : Azure.ResourceManager.ContainerService.Models.ManagedClusterAgentPoolProfileProperties
    {
        public ManagedClusterAgentPoolProfile(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class ManagedClusterAgentPoolProfileProperties
    {
        public ManagedClusterAgentPoolProfileProperties() { }
        public Azure.ResourceManager.ContainerService.Models.AgentPoolType? AgentPoolType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public int? Count { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CreationDataSourceResourceId { get { throw null; } set { } }
        public string CurrentOrchestratorVersion { get { throw null; } }
        public bool? EnableAutoScaling { get { throw null; } set { } }
        public bool? EnableEncryptionAtHost { get { throw null; } set { } }
        public bool? EnableFips { get { throw null; } set { } }
        public bool? EnableNodePublicIP { get { throw null; } set { } }
        public bool? EnableUltraSsd { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.GpuInstanceProfile? GpuInstanceProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HostGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.KubeletConfig KubeletConfig { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.KubeletDiskType? KubeletDiskType { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.LinuxOSConfig LinuxOSConfig { get { throw null; } set { } }
        public int? MaxCount { get { throw null; } set { } }
        public int? MaxPods { get { throw null; } set { } }
        public int? MinCount { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.AgentPoolMode? Mode { get { throw null; } set { } }
        public string NodeImageVersion { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> NodeLabels { get { throw null; } }
        public Azure.Core.ResourceIdentifier NodePublicIPPrefixId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NodeTaints { get { throw null; } }
        public string OrchestratorVersion { get { throw null; } set { } }
        public int? OSDiskSizeInGB { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceOSDiskType? OSDiskType { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceOSSku? OSSku { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType? OSType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PodSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceStateCode? PowerStateCode { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ScaleDownMode? ScaleDownMode { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ScaleSetEvictionPolicy? ScaleSetEvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ScaleSetPriority? ScaleSetPriority { get { throw null; } set { } }
        public float? SpotMaxPrice { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string UpgradeMaxSurge { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VnetSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.WorkloadRuntime? WorkloadRuntime { get { throw null; } set { } }
    }
    public partial class ManagedClusterApiServerAccessProfile
    {
        public ManagedClusterApiServerAccessProfile() { }
        public System.Collections.Generic.IList<string> AuthorizedIPRanges { get { throw null; } }
        public bool? DisableRunCommand { get { throw null; } set { } }
        public bool? EnablePrivateCluster { get { throw null; } set { } }
        public bool? EnablePrivateClusterPublicFqdn { get { throw null; } set { } }
        public string PrivateDnsZone { get { throw null; } set { } }
    }
    public partial class ManagedClusterAutoScalerProfile
    {
        public ManagedClusterAutoScalerProfile() { }
        public string BalanceSimilarNodeGroups { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.AutoScaleExpander? Expander { get { throw null; } set { } }
        public string MaxEmptyBulkDelete { get { throw null; } set { } }
        public string MaxGracefulTerminationSec { get { throw null; } set { } }
        public string MaxNodeProvisionTime { get { throw null; } set { } }
        public string MaxTotalUnreadyPercentage { get { throw null; } set { } }
        public string NewPodScaleUpDelay { get { throw null; } set { } }
        public string OkTotalUnreadyCount { get { throw null; } set { } }
        public string ScaleDownDelayAfterAdd { get { throw null; } set { } }
        public string ScaleDownDelayAfterDelete { get { throw null; } set { } }
        public string ScaleDownDelayAfterFailure { get { throw null; } set { } }
        public string ScaleDownUnneededTime { get { throw null; } set { } }
        public string ScaleDownUnreadyTime { get { throw null; } set { } }
        public string ScaleDownUtilizationThreshold { get { throw null; } set { } }
        public string ScanIntervalInSeconds { get { throw null; } set { } }
        public string SkipNodesWithLocalStorage { get { throw null; } set { } }
        public string SkipNodesWithSystemPods { get { throw null; } set { } }
    }
    public partial class ManagedClusterCredential
    {
        internal ManagedClusterCredential() { }
        public string Name { get { throw null; } }
        public byte[] Value { get { throw null; } }
    }
    public partial class ManagedClusterCredentials
    {
        internal ManagedClusterCredentials() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerService.Models.ManagedClusterCredential> Kubeconfigs { get { throw null; } }
    }
    public partial class ManagedClusterHttpProxyConfig
    {
        public ManagedClusterHttpProxyConfig() { }
        public string HttpProxy { get { throw null; } set { } }
        public string HttpsProxy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NoProxy { get { throw null; } }
        public string TrustedCA { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterKeyVaultNetworkAccessType : System.IEquatable<Azure.ResourceManager.ContainerService.Models.ManagedClusterKeyVaultNetworkAccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterKeyVaultNetworkAccessType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ManagedClusterKeyVaultNetworkAccessType Private { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ManagedClusterKeyVaultNetworkAccessType Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.ManagedClusterKeyVaultNetworkAccessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.ManagedClusterKeyVaultNetworkAccessType left, Azure.ResourceManager.ContainerService.Models.ManagedClusterKeyVaultNetworkAccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.ManagedClusterKeyVaultNetworkAccessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.ManagedClusterKeyVaultNetworkAccessType left, Azure.ResourceManager.ContainerService.Models.ManagedClusterKeyVaultNetworkAccessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedClusterLoadBalancerProfile
    {
        public ManagedClusterLoadBalancerProfile() { }
        public int? AllocatedOutboundPorts { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> EffectiveOutboundIPs { get { throw null; } }
        public bool? EnableMultipleStandardLoadBalancers { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterLoadBalancerProfileManagedOutboundIPs ManagedOutboundIPs { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> OutboundPublicIPPrefixes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> OutboundPublicIPs { get { throw null; } }
    }
    public partial class ManagedClusterLoadBalancerProfileManagedOutboundIPs
    {
        public ManagedClusterLoadBalancerProfileManagedOutboundIPs() { }
        public int? Count { get { throw null; } set { } }
        public int? CountIPv6 { get { throw null; } set { } }
    }
    public partial class ManagedClusterNatGatewayProfile
    {
        public ManagedClusterNatGatewayProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> EffectiveOutboundIPs { get { throw null; } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public int? ManagedOutboundIPCount { get { throw null; } set { } }
    }
    public partial class ManagedClusterOidcIssuerProfile
    {
        public ManagedClusterOidcIssuerProfile() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public string IssuerUriInfo { get { throw null; } }
    }
    public partial class ManagedClusterPodIdentity
    {
        public ManagedClusterPodIdentity(string name, string @namespace, Azure.ResourceManager.ContainerService.Models.ContainerServiceUserAssignedIdentity identity) { }
        public string BindingSelector { get { throw null; } set { } }
        public Azure.ResponseError ErrorDetail { get { throw null; } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceUserAssignedIdentity Identity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterPodIdentityProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ManagedClusterPodIdentityException
    {
        public ManagedClusterPodIdentityException(string name, string @namespace, System.Collections.Generic.IDictionary<string, string> podLabels) { }
        public string Name { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> PodLabels { get { throw null; } }
    }
    public partial class ManagedClusterPodIdentityProfile
    {
        public ManagedClusterPodIdentityProfile() { }
        public bool? AllowNetworkPluginKubenet { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerService.Models.ManagedClusterPodIdentity> UserAssignedIdentities { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerService.Models.ManagedClusterPodIdentityException> UserAssignedIdentityExceptions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterPodIdentityProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerService.Models.ManagedClusterPodIdentityProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterPodIdentityProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ManagedClusterPodIdentityProvisioningState Assigned { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ManagedClusterPodIdentityProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ManagedClusterPodIdentityProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ManagedClusterPodIdentityProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.ManagedClusterPodIdentityProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.ManagedClusterPodIdentityProvisioningState left, Azure.ResourceManager.ContainerService.Models.ManagedClusterPodIdentityProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.ManagedClusterPodIdentityProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.ManagedClusterPodIdentityProvisioningState left, Azure.ResourceManager.ContainerService.Models.ManagedClusterPodIdentityProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedClusterPoolUpgradeProfile
    {
        internal ManagedClusterPoolUpgradeProfile() { }
        public string KubernetesVersion { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ContainerService.Models.ContainerServiceOSType OSType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerService.Models.ManagedClusterPoolUpgradeProfileUpgradesItem> Upgrades { get { throw null; } }
    }
    public partial class ManagedClusterPoolUpgradeProfileUpgradesItem
    {
        internal ManagedClusterPoolUpgradeProfileUpgradesItem() { }
        public bool? IsPreview { get { throw null; } }
        public string KubernetesVersion { get { throw null; } }
    }
    public partial class ManagedClusterRunCommandContent
    {
        public ManagedClusterRunCommandContent(string command) { }
        public string ClusterToken { get { throw null; } set { } }
        public string Command { get { throw null; } }
        public string Context { get { throw null; } set { } }
    }
    public partial class ManagedClusterRunCommandResult
    {
        internal ManagedClusterRunCommandResult() { }
        public int? ExitCode { get { throw null; } }
        public System.DateTimeOffset? FinishedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string Logs { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Reason { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
    }
    public partial class ManagedClusterSecurityProfile
    {
        public ManagedClusterSecurityProfile() { }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterSecurityProfileKeyVaultKms AzureKeyVaultKms { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterSecurityProfileDefender Defender { get { throw null; } set { } }
    }
    public partial class ManagedClusterSecurityProfileAzureDefender
    {
        public ManagedClusterSecurityProfileAzureDefender() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogAnalyticsWorkspaceResourceId { get { throw null; } set { } }
    }
    public partial class ManagedClusterSecurityProfileDefender
    {
        public ManagedClusterSecurityProfileDefender() { }
        public bool? IsSecurityMonitoringEnabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogAnalyticsWorkspaceResourceId { get { throw null; } set { } }
    }
    public partial class ManagedClusterSecurityProfileKeyVaultKms
    {
        public ManagedClusterSecurityProfileKeyVaultKms() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public string KeyId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterKeyVaultNetworkAccessType? KeyVaultNetworkAccess { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KeyVaultResourceId { get { throw null; } set { } }
    }
    public partial class ManagedClusterServicePrincipalProfile
    {
        public ManagedClusterServicePrincipalProfile(string clientId) { }
        public string ClientId { get { throw null; } set { } }
        public string Secret { get { throw null; } set { } }
    }
    public partial class ManagedClusterSku
    {
        public ManagedClusterSku() { }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterSkuName? Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.ManagedClusterSkuTier? Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterSkuName : System.IEquatable<Azure.ResourceManager.ContainerService.Models.ManagedClusterSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterSkuName(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ManagedClusterSkuName Basic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.ManagedClusterSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.ManagedClusterSkuName left, Azure.ResourceManager.ContainerService.Models.ManagedClusterSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.ManagedClusterSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.ManagedClusterSkuName left, Azure.ResourceManager.ContainerService.Models.ManagedClusterSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterSkuTier : System.IEquatable<Azure.ResourceManager.ContainerService.Models.ManagedClusterSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ManagedClusterSkuTier Free { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ManagedClusterSkuTier Paid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.ManagedClusterSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.ManagedClusterSkuTier left, Azure.ResourceManager.ContainerService.Models.ManagedClusterSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.ManagedClusterSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.ManagedClusterSkuTier left, Azure.ResourceManager.ContainerService.Models.ManagedClusterSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedClusterStorageProfile
    {
        public ManagedClusterStorageProfile() { }
        public bool? IsBlobCsiDriverEnabled { get { throw null; } set { } }
        public bool? IsDiskCsiDriverEnabled { get { throw null; } set { } }
        public bool? IsFileCsiDriverEnabled { get { throw null; } set { } }
        public bool? IsSnapshotControllerEnabled { get { throw null; } set { } }
    }
    public partial class ManagedClusterWindowsProfile
    {
        public ManagedClusterWindowsProfile(string adminUsername) { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.WindowsGmsaProfile GmsaProfile { get { throw null; } set { } }
        public bool? IsCsiProxyEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerService.Models.WindowsVmLicenseType? LicenseType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScaleDownMode : System.IEquatable<Azure.ResourceManager.ContainerService.Models.ScaleDownMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScaleDownMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ScaleDownMode Deallocate { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ScaleDownMode Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.ScaleDownMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.ScaleDownMode left, Azure.ResourceManager.ContainerService.Models.ScaleDownMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.ScaleDownMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.ScaleDownMode left, Azure.ResourceManager.ContainerService.Models.ScaleDownMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScaleSetEvictionPolicy : System.IEquatable<Azure.ResourceManager.ContainerService.Models.ScaleSetEvictionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScaleSetEvictionPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ScaleSetEvictionPolicy Deallocate { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ScaleSetEvictionPolicy Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.ScaleSetEvictionPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.ScaleSetEvictionPolicy left, Azure.ResourceManager.ContainerService.Models.ScaleSetEvictionPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.ScaleSetEvictionPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.ScaleSetEvictionPolicy left, Azure.ResourceManager.ContainerService.Models.ScaleSetEvictionPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScaleSetPriority : System.IEquatable<Azure.ResourceManager.ContainerService.Models.ScaleSetPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScaleSetPriority(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.ScaleSetPriority Regular { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.ScaleSetPriority Spot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.ScaleSetPriority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.ScaleSetPriority left, Azure.ResourceManager.ContainerService.Models.ScaleSetPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.ScaleSetPriority (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.ScaleSetPriority left, Azure.ResourceManager.ContainerService.Models.ScaleSetPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SnapshotType : System.IEquatable<Azure.ResourceManager.ContainerService.Models.SnapshotType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SnapshotType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.SnapshotType NodePool { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.SnapshotType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.SnapshotType left, Azure.ResourceManager.ContainerService.Models.SnapshotType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.SnapshotType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.SnapshotType left, Azure.ResourceManager.ContainerService.Models.SnapshotType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SysctlConfig
    {
        public SysctlConfig() { }
        public int? FsAioMaxNr { get { throw null; } set { } }
        public int? FsFileMax { get { throw null; } set { } }
        public int? FsInotifyMaxUserWatches { get { throw null; } set { } }
        public int? FsNrOpen { get { throw null; } set { } }
        public int? KernelThreadsMax { get { throw null; } set { } }
        public int? NetCoreNetdevMaxBacklog { get { throw null; } set { } }
        public int? NetCoreOptmemMax { get { throw null; } set { } }
        public int? NetCoreRmemDefault { get { throw null; } set { } }
        public int? NetCoreRmemMax { get { throw null; } set { } }
        public int? NetCoreSomaxconn { get { throw null; } set { } }
        public int? NetCoreWmemDefault { get { throw null; } set { } }
        public int? NetCoreWmemMax { get { throw null; } set { } }
        public string NetIPv4IPLocalPortRange { get { throw null; } set { } }
        public int? NetIPv4NeighDefaultGcThresh1 { get { throw null; } set { } }
        public int? NetIPv4NeighDefaultGcThresh2 { get { throw null; } set { } }
        public int? NetIPv4NeighDefaultGcThresh3 { get { throw null; } set { } }
        public int? NetIPv4TcpFinTimeout { get { throw null; } set { } }
        public int? NetIPv4TcpKeepaliveIntvl { get { throw null; } set { } }
        public int? NetIPv4TcpKeepaliveProbes { get { throw null; } set { } }
        public int? NetIPv4TcpKeepaliveTime { get { throw null; } set { } }
        public int? NetIPv4TcpMaxSynBacklog { get { throw null; } set { } }
        public int? NetIPv4TcpMaxTwBuckets { get { throw null; } set { } }
        public bool? NetIPv4TcpTwReuse { get { throw null; } set { } }
        public int? NetNetfilterNfConntrackBuckets { get { throw null; } set { } }
        public int? NetNetfilterNfConntrackMax { get { throw null; } set { } }
        public int? VmMaxMapCount { get { throw null; } set { } }
        public int? VmSwappiness { get { throw null; } set { } }
        public int? VmVfsCachePressure { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpgradeChannel : System.IEquatable<Azure.ResourceManager.ContainerService.Models.UpgradeChannel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpgradeChannel(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.UpgradeChannel NodeImage { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.UpgradeChannel None { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.UpgradeChannel Patch { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.UpgradeChannel Rapid { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.UpgradeChannel Stable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.UpgradeChannel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.UpgradeChannel left, Azure.ResourceManager.ContainerService.Models.UpgradeChannel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.UpgradeChannel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.UpgradeChannel left, Azure.ResourceManager.ContainerService.Models.UpgradeChannel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WindowsGmsaProfile
    {
        public WindowsGmsaProfile() { }
        public string DnsServer { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string RootDomainName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsVmLicenseType : System.IEquatable<Azure.ResourceManager.ContainerService.Models.WindowsVmLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsVmLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.WindowsVmLicenseType None { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.WindowsVmLicenseType WindowsServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.WindowsVmLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.WindowsVmLicenseType left, Azure.ResourceManager.ContainerService.Models.WindowsVmLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.WindowsVmLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.WindowsVmLicenseType left, Azure.ResourceManager.ContainerService.Models.WindowsVmLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadRuntime : System.IEquatable<Azure.ResourceManager.ContainerService.Models.WorkloadRuntime>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadRuntime(string value) { throw null; }
        public static Azure.ResourceManager.ContainerService.Models.WorkloadRuntime OciContainer { get { throw null; } }
        public static Azure.ResourceManager.ContainerService.Models.WorkloadRuntime WasmWasi { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerService.Models.WorkloadRuntime other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerService.Models.WorkloadRuntime left, Azure.ResourceManager.ContainerService.Models.WorkloadRuntime right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerService.Models.WorkloadRuntime (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerService.Models.WorkloadRuntime left, Azure.ResourceManager.ContainerService.Models.WorkloadRuntime right) { throw null; }
        public override string ToString() { throw null; }
    }
}
