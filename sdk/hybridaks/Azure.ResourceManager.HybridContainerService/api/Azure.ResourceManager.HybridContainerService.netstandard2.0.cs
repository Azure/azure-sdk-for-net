namespace Azure.ResourceManager.HybridContainerService
{
    public partial class HybridContainerServiceAgentPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource>, System.Collections.IEnumerable
    {
        protected HybridContainerServiceAgentPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource> Get(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource>> GetAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource> GetIfExists(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource>> GetIfExistsAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridContainerServiceAgentPoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolData>
    {
        public HybridContainerServiceAgentPoolData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.CloudProviderProfile CloudProviderProfile { get { throw null; } set { } }
        public int? Count { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.AgentPoolExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public int? MaxCount { get { throw null; } set { } }
        public int? MaxPods { get { throw null; } set { } }
        public int? MinCount { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.Mode? Mode { get { throw null; } set { } }
        public string NodeImageVersion { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> NodeLabels { get { throw null; } }
        public System.Collections.Generic.IList<string> NodeTaints { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.OSType? OSType { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatus Status { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridContainerServiceAgentPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridContainerServiceAgentPoolResource() { }
        public virtual Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string agentPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource> Update(Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource>> UpdateAsync(Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HybridContainerServiceExtensions
    {
        public static Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource GetHybridContainerServiceAgentPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> GetHybridContainerServiceVirtualNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualNetworksName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>> GetHybridContainerServiceVirtualNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualNetworksName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource GetHybridContainerServiceVirtualNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkCollection GetHybridContainerServiceVirtualNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> GetHybridContainerServiceVirtualNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> GetHybridContainerServiceVirtualNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource GetHybridIdentityMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfileListResult> GetOrchestratorsHybridContainerService(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfileListResult>> GetOrchestratorsHybridContainerServiceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource> GetProvisionedCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource>> GetProvisionedClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource GetProvisionedClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.ProvisionedClusterCollection GetProvisionedClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource> GetProvisionedClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource> GetProvisionedClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileResource GetProvisionedClusterUpgradeProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridContainerService.StorageSpaceResource> GetStorageSpace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageSpacesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.StorageSpaceResource>> GetStorageSpaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageSpacesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.StorageSpaceResource GetStorageSpaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.StorageSpaceCollection GetStorageSpaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridContainerService.StorageSpaceResource> GetStorageSpaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridContainerService.StorageSpaceResource> GetStorageSpacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridContainerService.Models.VmSkuListResult> GetVmSkusHybridContainerService(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.Models.VmSkuListResult>> GetVmSkusHybridContainerServiceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridContainerServiceVirtualNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>, System.Collections.IEnumerable
    {
        protected HybridContainerServiceVirtualNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworksName, Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworksName, Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworksName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworksName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> Get(string virtualNetworksName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>> GetAsync(string virtualNetworksName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> GetIfExists(string virtualNetworksName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>> GetIfExistsAsync(string virtualNetworksName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridContainerServiceVirtualNetworkData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkData>
    {
        public HybridContainerServiceVirtualNetworkData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridContainerServiceVirtualNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridContainerServiceVirtualNetworkResource() { }
        public virtual Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualNetworksName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceVirtualNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceVirtualNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridIdentityMetadataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource>, System.Collections.IEnumerable
    {
        protected HybridIdentityMetadataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hybridIdentityMetadataResourceName, Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hybridIdentityMetadataResourceName, Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hybridIdentityMetadataResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hybridIdentityMetadataResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource> Get(string hybridIdentityMetadataResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource>> GetAsync(string hybridIdentityMetadataResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource> GetIfExists(string hybridIdentityMetadataResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource>> GetIfExistsAsync(string hybridIdentityMetadataResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridIdentityMetadataData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataData>
    {
        public HybridIdentityMetadataData() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string PublicKey { get { throw null; } set { } }
        public string ResourceUid { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridIdentityMetadataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridIdentityMetadataResource() { }
        public virtual Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string hybridIdentityMetadataResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProvisionedClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource>, System.Collections.IEnumerable
    {
        protected ProvisionedClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProvisionedClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.ProvisionedClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.ProvisionedClusterData>
    {
        public ProvisionedClusterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.ProvisionedClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.ProvisionedClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.ProvisionedClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.ProvisionedClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.ProvisionedClusterData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.ProvisionedClusterData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.ProvisionedClusterData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvisionedClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProvisionedClusterResource() { }
        public virtual Azure.ResourceManager.HybridContainerService.ProvisionedClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataCollection GetAllHybridIdentityMetadata() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource> GetHybridContainerServiceAgentPool(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource>> GetHybridContainerServiceAgentPoolAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolCollection GetHybridContainerServiceAgentPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource> GetHybridIdentityMetadata(string hybridIdentityMetadataResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource>> GetHybridIdentityMetadataAsync(string hybridIdentityMetadataResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileResource GetProvisionedClusterUpgradeProfile() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpgradeNodeImageVersionForEntireCluster(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeNodeImageVersionForEntireClusterAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProvisionedClusterUpgradeProfileData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileData>
    {
        public ProvisionedClusterUpgradeProfileData(Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile controlPlaneProfile, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile> agentPoolProfiles) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile> AgentPoolProfiles { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile ControlPlaneProfile { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvisionedClusterUpgradeProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProvisionedClusterUpgradeProfileResource() { }
        public virtual Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageSpaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridContainerService.StorageSpaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.StorageSpaceResource>, System.Collections.IEnumerable
    {
        protected StorageSpaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.StorageSpaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageSpacesName, Azure.ResourceManager.HybridContainerService.StorageSpaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.StorageSpaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageSpacesName, Azure.ResourceManager.HybridContainerService.StorageSpaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageSpacesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageSpacesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.StorageSpaceResource> Get(string storageSpacesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridContainerService.StorageSpaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridContainerService.StorageSpaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.StorageSpaceResource>> GetAsync(string storageSpacesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridContainerService.StorageSpaceResource> GetIfExists(string storageSpacesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridContainerService.StorageSpaceResource>> GetIfExistsAsync(string storageSpacesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridContainerService.StorageSpaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridContainerService.StorageSpaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridContainerService.StorageSpaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.StorageSpaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageSpaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.StorageSpaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.StorageSpaceData>
    {
        public StorageSpaceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridContainerService.Models.StorageSpacesExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.StorageSpacesProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.StorageSpaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.StorageSpaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.StorageSpaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.StorageSpaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.StorageSpaceData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.StorageSpaceData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.StorageSpaceData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageSpaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageSpaceResource() { }
        public virtual Azure.ResourceManager.HybridContainerService.StorageSpaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.StorageSpaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.StorageSpaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageSpacesName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.StorageSpaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.StorageSpaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.StorageSpaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.StorageSpaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.StorageSpaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.StorageSpaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.StorageSpaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.Models.StorageSpacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.StorageSpaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.Models.StorageSpacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HybridContainerService.Mocking
{
    public partial class MockableHybridContainerServiceArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridContainerServiceArmClient() { }
        public virtual Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource GetHybridContainerServiceAgentPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource GetHybridContainerServiceVirtualNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource GetHybridIdentityMetadataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfileListResult> GetOrchestratorsHybridContainerService(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfileListResult>> GetOrchestratorsHybridContainerServiceAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource GetProvisionedClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileResource GetProvisionedClusterUpgradeProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.StorageSpaceResource GetStorageSpaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.Models.VmSkuListResult> GetVmSkusHybridContainerService(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.Models.VmSkuListResult>> GetVmSkusHybridContainerServiceAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableHybridContainerServiceResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridContainerServiceResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> GetHybridContainerServiceVirtualNetwork(string virtualNetworksName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>> GetHybridContainerServiceVirtualNetworkAsync(string virtualNetworksName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkCollection GetHybridContainerServiceVirtualNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource> GetProvisionedCluster(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource>> GetProvisionedClusterAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.ProvisionedClusterCollection GetProvisionedClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.StorageSpaceResource> GetStorageSpace(string storageSpacesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.StorageSpaceResource>> GetStorageSpaceAsync(string storageSpacesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.StorageSpaceCollection GetStorageSpaces() { throw null; }
    }
    public partial class MockableHybridContainerServiceSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridContainerServiceSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> GetHybridContainerServiceVirtualNetworks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> GetHybridContainerServiceVirtualNetworksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource> GetProvisionedClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource> GetProvisionedClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridContainerService.StorageSpaceResource> GetStorageSpaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridContainerService.StorageSpaceResource> GetStorageSpacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HybridContainerService.Models
{
    public partial class AADProfile : Azure.ResourceManager.HybridContainerService.Models.AADProfileSecret, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AADProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AADProfile>
    {
        public AADProfile() { }
        public System.Collections.Generic.IList<string> AdminGroupObjectIds { get { throw null; } }
        public string ClientAppId { get { throw null; } set { } }
        public bool? EnableAzureRbac { get { throw null; } set { } }
        public bool? Managed { get { throw null; } set { } }
        public string ServerAppId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.AADProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AADProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AADProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.AADProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AADProfile>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AADProfile>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AADProfile>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AADProfileResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AADProfileResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AADProfileResponse>
    {
        public AADProfileResponse() { }
        public System.Collections.Generic.IList<string> AdminGroupObjectIds { get { throw null; } }
        public string ClientAppId { get { throw null; } set { } }
        public bool? EnableAzureRbac { get { throw null; } set { } }
        public bool? Managed { get { throw null; } set { } }
        public string ServerAppId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.AADProfileResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AADProfileResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AADProfileResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.AADProfileResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AADProfileResponse>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AADProfileResponse>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AADProfileResponse>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AADProfileSecret : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AADProfileSecret>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AADProfileSecret>
    {
        public AADProfileSecret() { }
        public string ServerAppSecret { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.AADProfileSecret System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AADProfileSecret>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AADProfileSecret>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.AADProfileSecret System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AADProfileSecret>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AADProfileSecret>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AADProfileSecret>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AddonProfiles : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AddonProfiles>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AddonProfiles>
    {
        public AddonProfiles() { }
        public System.Collections.Generic.IDictionary<string, string> Config { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.AddonProfiles System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AddonProfiles>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AddonProfiles>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.AddonProfiles System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AddonProfiles>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AddonProfiles>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AddonProfiles>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AddonStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AddonStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AddonStatus>
    {
        internal AddonStatus() { }
        public string ErrorMessage { get { throw null; } }
        public string Phase { get { throw null; } }
        public bool? Ready { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.AddonStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AddonStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AddonStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.AddonStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AddonStatus>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AddonStatus>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AddonStatus>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentPoolExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolExtendedLocation>
    {
        public AgentPoolExtendedLocation() { }
        public string AgentPoolExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.AgentPoolExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.AgentPoolExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolExtendedLocation>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolExtendedLocation>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolExtendedLocation>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentPoolProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProfile>
    {
        public AgentPoolProfile() { }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.CloudProviderProfile CloudProviderProfile { get { throw null; } set { } }
        public int? Count { get { throw null; } set { } }
        public int? MaxCount { get { throw null; } set { } }
        public int? MaxPods { get { throw null; } set { } }
        public int? MinCount { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.Mode? Mode { get { throw null; } set { } }
        public string NodeImageVersion { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> NodeLabels { get { throw null; } }
        public System.Collections.Generic.IList<string> NodeTaints { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.OSType? OSType { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.AgentPoolProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.AgentPoolProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProfile>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProfile>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProfile>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentPoolProvisioningState : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentPoolProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningState left, Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningState left, Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentPoolProvisioningStatusError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusError>
    {
        public AgentPoolProvisioningStatusError() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusError>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusError>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusError>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentPoolProvisioningStatusStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatus>
    {
        public AgentPoolProvisioningStatusStatus() { }
        public string ErrorMessage { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatusProvisioningStatus ProvisioningStatus { get { throw null; } set { } }
        public int? ReadyReplicas { get { throw null; } set { } }
        public int? Replicas { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatus>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatus>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatus>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentPoolProvisioningStatusStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatusProvisioningStatus>
    {
        public AgentPoolProvisioningStatusStatusProvisioningStatus() { }
        public Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusError Error { get { throw null; } set { } }
        public string OperationId { get { throw null; } set { } }
        public string Phase { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatusProvisioningStatus>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArcAgentProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ArcAgentProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ArcAgentProfile>
    {
        public ArcAgentProfile() { }
        public Azure.ResourceManager.HybridContainerService.Models.AutoUpgradeOption? AgentAutoUpgrade { get { throw null; } set { } }
        public string AgentVersion { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.ArcAgentProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ArcAgentProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ArcAgentProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.ArcAgentProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ArcAgentProfile>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ArcAgentProfile>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ArcAgentProfile>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArcAgentStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ArcAgentStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ArcAgentStatus>
    {
        internal ArcAgentStatus() { }
        public string AgentVersion { get { throw null; } }
        public long? CoreCount { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.DeploymentState? DeploymentState { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public System.DateTimeOffset? LastConnectivityOn { get { throw null; } }
        public System.DateTimeOffset? ManagedIdentityCertificateExpirationOn { get { throw null; } }
        public string OnboardingPublicKey { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.ArcAgentStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ArcAgentStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ArcAgentStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.ArcAgentStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ArcAgentStatus>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ArcAgentStatus>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ArcAgentStatus>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmHybridContainerServiceModelFactory
    {
        public static Azure.ResourceManager.HybridContainerService.Models.AddonStatus AddonStatus(string errorMessage = null, string phase = null, bool? ready = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ArcAgentStatus ArcAgentStatus(Azure.ResourceManager.HybridContainerService.Models.DeploymentState? deploymentState = default(Azure.ResourceManager.HybridContainerService.Models.DeploymentState?), string errorMessage = null, string onboardingPublicKey = null, string agentVersion = null, long? coreCount = default(long?), System.DateTimeOffset? managedIdentityCertificateExpirationOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastConnectivityOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolData HybridContainerServiceAgentPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridContainerService.Models.AgentPoolExtendedLocation extendedLocation = null, int? count = default(int?), System.Collections.Generic.IEnumerable<string> availabilityZones = null, int? maxCount = default(int?), int? maxPods = default(int?), int? minCount = default(int?), Azure.ResourceManager.HybridContainerService.Models.Mode? mode = default(Azure.ResourceManager.HybridContainerService.Models.Mode?), System.Collections.Generic.IDictionary<string, string> nodeLabels = null, System.Collections.Generic.IEnumerable<string> nodeTaints = null, Azure.ResourceManager.HybridContainerService.Models.OSType? osType = default(Azure.ResourceManager.HybridContainerService.Models.OSType?), string nodeImageVersion = null, string vmSize = null, Azure.ResourceManager.HybridContainerService.Models.CloudProviderProfile cloudProviderProfile = null, Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningState? provisioningState = default(Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningState?), Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatus status = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkData HybridContainerServiceVirtualNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksProperties properties = null, Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataData HybridIdentityMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string resourceUid = null, string publicKey = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.OrchestratorProfile OrchestratorProfile(bool? isPreview = default(bool?), string orchestratorType = null, string orchestratorVersion = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfile OrchestratorVersionProfile(bool? isPreview = default(bool?), bool? @default = default(bool?), string orchestratorType = null, string orchestratorVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.OrchestratorProfile> upgrades = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfileListResult OrchestratorVersionProfileListResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfile> orchestrators = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterCreateOrUpdateContent ProvisionedClusterCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersAllProperties properties = null, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.ProvisionedClusterData ProvisionedClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseProperties properties = null, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile ProvisionedClusterPoolUpgradeProfile(string kubernetesVersion = null, string name = null, Azure.ResourceManager.HybridContainerService.Models.OSType? osType = default(Azure.ResourceManager.HybridContainerService.Models.OSType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfileProperties> upgrades = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfileProperties ProvisionedClusterPoolUpgradeProfileProperties(string kubernetesVersion = null, bool? isPreview = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersAllProperties ProvisionedClustersAllProperties(Azure.ResourceManager.HybridContainerService.Models.AADProfile aadProfile = null, Azure.ResourceManager.HybridContainerService.Models.WindowsProfile windowsProfile = null, Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfig httpProxyConfig = null, bool? enableRbac = default(bool?), Azure.ResourceManager.HybridContainerService.Models.LinuxProfileProperties linuxProfile = null, Azure.ResourceManager.HybridContainerService.Models.ArcAgentProfile featuresArcAgentProfile = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.HybridContainerService.Models.AddonProfiles> addonProfiles = null, Azure.ResourceManager.HybridContainerService.Models.ControlPlaneProfile controlPlane = null, string kubernetesVersion = null, Azure.ResourceManager.HybridContainerService.Models.NetworkProfile networkProfile = null, string nodeResourceGroup = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.NamedAgentPoolProfile> agentPoolProfiles = null, Azure.ResourceManager.HybridContainerService.Models.CloudProviderProfile cloudProviderProfile = null, Azure.ResourceManager.HybridContainerService.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridContainerService.Models.ProvisioningState?), Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatus status = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatus ProvisionedClustersCommonPropertiesStatus(Azure.ResourceManager.HybridContainerService.Models.ArcAgentStatus arcAgentStatus = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HybridContainerService.Models.AddonStatus> addonStatus = null, string errorMessage = null, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatus ProvisionedClustersCommonPropertiesStatusProvisioningStatus(Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatusError error = null, string operationId = null, string phase = null, string status = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatusError ProvisionedClustersCommonPropertiesStatusProvisioningStatusError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseProperties ProvisionedClustersResponseProperties(Azure.ResourceManager.HybridContainerService.Models.AADProfileResponse aadProfile = null, Azure.ResourceManager.HybridContainerService.Models.WindowsProfileResponse windowsProfile = null, Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfigResponse httpProxyConfig = null, bool? enableRbac = default(bool?), Azure.ResourceManager.HybridContainerService.Models.LinuxProfileProperties linuxProfile = null, Azure.ResourceManager.HybridContainerService.Models.ArcAgentProfile featuresArcAgentProfile = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.HybridContainerService.Models.AddonProfiles> addonProfiles = null, Azure.ResourceManager.HybridContainerService.Models.ControlPlaneProfile controlPlane = null, string kubernetesVersion = null, Azure.ResourceManager.HybridContainerService.Models.NetworkProfile networkProfile = null, string nodeResourceGroup = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.NamedAgentPoolProfile> agentPoolProfiles = null, Azure.ResourceManager.HybridContainerService.Models.CloudProviderProfile cloudProviderProfile = null, Azure.ResourceManager.HybridContainerService.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridContainerService.Models.ProvisioningState?), Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatus status = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileData ProvisionedClusterUpgradeProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile controlPlaneProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile> agentPoolProfiles = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.StorageSpaceData StorageSpaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridContainerService.Models.StorageSpacesProperties properties = null, Azure.ResourceManager.HybridContainerService.Models.StorageSpacesExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.StorageSpacesProperties StorageSpacesProperties(Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesHciStorageProfile hciStorageProfile = null, Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesVmwareStorageProfile vmwareStorageProfile = null, Azure.ResourceManager.HybridContainerService.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridContainerService.Models.ProvisioningState?), Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksProperties VirtualNetworksProperties(Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfile infraVnetProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVipPoolItem> vipPool = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVmipPoolItem> vmipPool = null, System.Collections.Generic.IEnumerable<string> dhcpServers = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, string gateway = null, string ipAddressPrefix = null, string vlanId = null, Azure.ResourceManager.HybridContainerService.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridContainerService.Models.ProvisioningState?), Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatus VirtualNetworksPropertiesStatusProvisioningStatus(Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatusError error = null, string operationId = null, string phase = null, string status = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatusError VirtualNetworksPropertiesStatusProvisioningStatusError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.VmSkuListResult VmSkuListResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> vmSKUs = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoUpgradeOption : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.AutoUpgradeOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoUpgradeOption(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.AutoUpgradeOption Disabled { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.AutoUpgradeOption Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.AutoUpgradeOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.AutoUpgradeOption left, Azure.ResourceManager.HybridContainerService.Models.AutoUpgradeOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.AutoUpgradeOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.AutoUpgradeOption left, Azure.ResourceManager.HybridContainerService.Models.AutoUpgradeOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CloudProviderProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.CloudProviderProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.CloudProviderProfile>
    {
        public CloudProviderProfile() { }
        public System.Collections.Generic.IList<string> InfraNetworkVnetSubnetIds { get { throw null; } }
        public System.Collections.Generic.IList<string> StorageSpaceIds { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.CloudProviderProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.CloudProviderProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.CloudProviderProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.CloudProviderProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.CloudProviderProfile>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.CloudProviderProfile>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.CloudProviderProfile>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ControlPlaneEndpointProfileControlPlaneEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ControlPlaneEndpointProfileControlPlaneEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ControlPlaneEndpointProfileControlPlaneEndpoint>
    {
        public ControlPlaneEndpointProfileControlPlaneEndpoint() { }
        public string HostIP { get { throw null; } set { } }
        public string Port { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.ControlPlaneEndpointProfileControlPlaneEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ControlPlaneEndpointProfileControlPlaneEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ControlPlaneEndpointProfileControlPlaneEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.ControlPlaneEndpointProfileControlPlaneEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ControlPlaneEndpointProfileControlPlaneEndpoint>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ControlPlaneEndpointProfileControlPlaneEndpoint>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ControlPlaneEndpointProfileControlPlaneEndpoint>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ControlPlaneProfile : Azure.ResourceManager.HybridContainerService.Models.NamedAgentPoolProfile, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ControlPlaneProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ControlPlaneProfile>
    {
        public ControlPlaneProfile() { }
        public Azure.ResourceManager.HybridContainerService.Models.ControlPlaneEndpointProfileControlPlaneEndpoint ControlPlaneEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.LinuxProfileProperties LinuxProfile { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.ControlPlaneProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ControlPlaneProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ControlPlaneProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.ControlPlaneProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ControlPlaneProfile>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ControlPlaneProfile>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ControlPlaneProfile>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentState : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.DeploymentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentState(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.DeploymentState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.DeploymentState Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.DeploymentState Pending { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.DeploymentState Provisioned { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.DeploymentState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.DeploymentState Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.DeploymentState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.DeploymentState left, Azure.ResourceManager.HybridContainerService.Models.DeploymentState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.DeploymentState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.DeploymentState left, Azure.ResourceManager.HybridContainerService.Models.DeploymentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HttpProxyConfig : Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfigResponse, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfig>
    {
        public HttpProxyConfig() { }
        public string Password { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfig>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfig>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfig>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HttpProxyConfigResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfigResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfigResponse>
    {
        public HttpProxyConfigResponse() { }
        public string HttpProxy { get { throw null; } set { } }
        public string HttpsProxy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NoProxy { get { throw null; } }
        public string TrustedCa { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfigResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfigResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfigResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfigResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfigResponse>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfigResponse>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfigResponse>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridContainerServiceVirtualNetworkPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceVirtualNetworkPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceVirtualNetworkPatch>
    {
        public HybridContainerServiceVirtualNetworkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceVirtualNetworkPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceVirtualNetworkPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceVirtualNetworkPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceVirtualNetworkPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceVirtualNetworkPatch>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceVirtualNetworkPatch>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceVirtualNetworkPatch>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LicenseType : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.LicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LicenseType(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.LicenseType None { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.LicenseType WindowsServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.LicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.LicenseType left, Azure.ResourceManager.HybridContainerService.Models.LicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.LicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.LicenseType left, Azure.ResourceManager.HybridContainerService.Models.LicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinuxProfileProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.LinuxProfileProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.LinuxProfileProperties>
    {
        public LinuxProfileProperties() { }
        public string AdminUsername { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.LinuxProfilePropertiesSshPublicKeysItem> SshPublicKeys { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.LinuxProfileProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.LinuxProfileProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.LinuxProfileProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.LinuxProfileProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.LinuxProfileProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.LinuxProfileProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.LinuxProfileProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinuxProfilePropertiesSshPublicKeysItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.LinuxProfilePropertiesSshPublicKeysItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.LinuxProfilePropertiesSshPublicKeysItem>
    {
        public LinuxProfilePropertiesSshPublicKeysItem() { }
        public string KeyData { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.LinuxProfilePropertiesSshPublicKeysItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.LinuxProfilePropertiesSshPublicKeysItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.LinuxProfilePropertiesSshPublicKeysItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.LinuxProfilePropertiesSshPublicKeysItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.LinuxProfilePropertiesSshPublicKeysItem>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.LinuxProfilePropertiesSshPublicKeysItem>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.LinuxProfilePropertiesSshPublicKeysItem>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadBalancerProfile : Azure.ResourceManager.HybridContainerService.Models.NamedAgentPoolProfile, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.LoadBalancerProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.LoadBalancerProfile>
    {
        public LoadBalancerProfile() { }
        public Azure.ResourceManager.HybridContainerService.Models.LinuxProfileProperties LinuxProfile { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.LoadBalancerProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.LoadBalancerProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.LoadBalancerProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.LoadBalancerProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.LoadBalancerProfile>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.LoadBalancerProfile>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.LoadBalancerProfile>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoadBalancerSku : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.LoadBalancerSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoadBalancerSku(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.LoadBalancerSku StackedKubeVip { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.LoadBalancerSku StackedMetallb { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.LoadBalancerSku Unmanaged { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.LoadBalancerSku UnstackedHaproxy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.LoadBalancerSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.LoadBalancerSku left, Azure.ResourceManager.HybridContainerService.Models.LoadBalancerSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.LoadBalancerSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.LoadBalancerSku left, Azure.ResourceManager.HybridContainerService.Models.LoadBalancerSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Mode : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.Mode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Mode(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.Mode LB { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.Mode System { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.Mode User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.Mode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.Mode left, Azure.ResourceManager.HybridContainerService.Models.Mode right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.Mode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.Mode left, Azure.ResourceManager.HybridContainerService.Models.Mode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NamedAgentPoolProfile : Azure.ResourceManager.HybridContainerService.Models.AgentPoolProfile, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.NamedAgentPoolProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.NamedAgentPoolProfile>
    {
        public NamedAgentPoolProfile() { }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.NamedAgentPoolProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.NamedAgentPoolProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.NamedAgentPoolProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.NamedAgentPoolProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.NamedAgentPoolProfile>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.NamedAgentPoolProfile>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.NamedAgentPoolProfile>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkPolicy : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.NetworkPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkPolicy(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.NetworkPolicy Calico { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.NetworkPolicy Flannel { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.NetworkPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.NetworkPolicy left, Azure.ResourceManager.HybridContainerService.Models.NetworkPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.NetworkPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.NetworkPolicy left, Azure.ResourceManager.HybridContainerService.Models.NetworkPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.NetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.NetworkProfile>
    {
        public NetworkProfile() { }
        public string DnsServiceIP { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.LoadBalancerProfile LoadBalancerProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.LoadBalancerSku? LoadBalancerSku { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.NetworkPolicy? NetworkPolicy { get { throw null; } set { } }
        public string PodCidr { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PodCidrs { get { throw null; } }
        public string ServiceCidr { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ServiceCidrs { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.NetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.NetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.NetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.NetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.NetworkProfile>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.NetworkProfile>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.NetworkProfile>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrchestratorProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorProfile>
    {
        internal OrchestratorProfile() { }
        public bool? IsPreview { get { throw null; } }
        public string OrchestratorType { get { throw null; } }
        public string OrchestratorVersion { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.OrchestratorProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.OrchestratorProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorProfile>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorProfile>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorProfile>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrchestratorVersionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfile>
    {
        internal OrchestratorVersionProfile() { }
        public bool? Default { get { throw null; } }
        public bool? IsPreview { get { throw null; } }
        public string OrchestratorType { get { throw null; } }
        public string OrchestratorVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridContainerService.Models.OrchestratorProfile> Upgrades { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfile>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfile>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfile>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrchestratorVersionProfileListResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfileListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfileListResult>
    {
        internal OrchestratorVersionProfileListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfile> Orchestrators { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfileListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfileListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfileListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfileListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfileListResult>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfileListResult>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.OrchestratorVersionProfileListResult>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSType : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.OSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSType(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.OSType Linux { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.OSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.OSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.OSType left, Azure.ResourceManager.HybridContainerService.Models.OSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.OSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.OSType left, Azure.ResourceManager.HybridContainerService.Models.OSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProvisionedClusterCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterCreateOrUpdateContent>
    {
        public ProvisionedClusterCreateOrUpdateContent(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersAllProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterCreateOrUpdateContent>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvisionedClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPatch>
    {
        public ProvisionedClusterPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPatch>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPatch>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPatch>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvisionedClusterPoolUpgradeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile>
    {
        public ProvisionedClusterPoolUpgradeProfile() { }
        public string KubernetesVersion { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.OSType? OSType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfileProperties> Upgrades { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvisionedClusterPoolUpgradeProfileProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfileProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfileProperties>
    {
        public ProvisionedClusterPoolUpgradeProfileProperties() { }
        public bool? IsPreview { get { throw null; } }
        public string KubernetesVersion { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfileProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfileProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfileProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfileProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfileProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfileProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfileProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvisionedClustersAllProperties : Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersPropertiesWithSecrets, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersAllProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersAllProperties>
    {
        public ProvisionedClustersAllProperties() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.HybridContainerService.Models.AddonProfiles> AddonProfiles { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.NamedAgentPoolProfile> AgentPoolProfiles { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.CloudProviderProfile CloudProviderProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.ControlPlaneProfile ControlPlane { get { throw null; } set { } }
        public bool? EnableRbac { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.ArcAgentProfile FeaturesArcAgentProfile { get { throw null; } set { } }
        public string KubernetesVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.LinuxProfileProperties LinuxProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public string NodeResourceGroup { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatus Status { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersAllProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersAllProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersAllProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersAllProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersAllProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersAllProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersAllProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvisionedClustersCommonPropertiesStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatus>
    {
        internal ProvisionedClustersCommonPropertiesStatus() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HybridContainerService.Models.AddonStatus> AddonStatus { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.ArcAgentStatus ArcAgentStatus { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatus>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatus>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatus>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvisionedClustersCommonPropertiesStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatus>
    {
        internal ProvisionedClustersCommonPropertiesStatusProvisioningStatus() { }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatusError Error { get { throw null; } }
        public string OperationId { get { throw null; } }
        public string Phase { get { throw null; } }
        public string Status { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatus>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvisionedClustersCommonPropertiesStatusProvisioningStatusError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatusError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatusError>
    {
        internal ProvisionedClustersCommonPropertiesStatusProvisioningStatusError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatusError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatusError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatusError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatusError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatusError>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatusError>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatusProvisioningStatusError>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvisionedClustersExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersExtendedLocation>
    {
        public ProvisionedClustersExtendedLocation() { }
        public string Name { get { throw null; } set { } }
        public string ProvisionedClustersExtendedLocationType { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersExtendedLocation>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersExtendedLocation>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersExtendedLocation>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvisionedClustersPropertiesWithoutSecrets : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersPropertiesWithoutSecrets>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersPropertiesWithoutSecrets>
    {
        public ProvisionedClustersPropertiesWithoutSecrets() { }
        public Azure.ResourceManager.HybridContainerService.Models.AADProfileResponse AadProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfigResponse HttpProxyConfig { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.WindowsProfileResponse WindowsProfile { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersPropertiesWithoutSecrets System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersPropertiesWithoutSecrets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersPropertiesWithoutSecrets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersPropertiesWithoutSecrets System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersPropertiesWithoutSecrets>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersPropertiesWithoutSecrets>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersPropertiesWithoutSecrets>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvisionedClustersPropertiesWithSecrets : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersPropertiesWithSecrets>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersPropertiesWithSecrets>
    {
        public ProvisionedClustersPropertiesWithSecrets() { }
        public Azure.ResourceManager.HybridContainerService.Models.AADProfile AadProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.HttpProxyConfig HttpProxyConfig { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.WindowsProfile WindowsProfile { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersPropertiesWithSecrets System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersPropertiesWithSecrets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersPropertiesWithSecrets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersPropertiesWithSecrets System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersPropertiesWithSecrets>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersPropertiesWithSecrets>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersPropertiesWithSecrets>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvisionedClustersResponseExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseExtendedLocation>
    {
        public ProvisionedClustersResponseExtendedLocation() { }
        public string Name { get { throw null; } set { } }
        public string ProvisionedClustersResponseExtendedLocationType { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseExtendedLocation>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseExtendedLocation>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseExtendedLocation>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvisionedClustersResponseProperties : Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersPropertiesWithoutSecrets, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseProperties>
    {
        public ProvisionedClustersResponseProperties() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.HybridContainerService.Models.AddonProfiles> AddonProfiles { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.NamedAgentPoolProfile> AgentPoolProfiles { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.CloudProviderProfile CloudProviderProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.ControlPlaneProfile ControlPlane { get { throw null; } set { } }
        public bool? EnableRbac { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.ArcAgentProfile FeaturesArcAgentProfile { get { throw null; } set { } }
        public string KubernetesVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.LinuxProfileProperties LinuxProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public string NodeResourceGroup { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersCommonPropertiesStatus Status { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClustersResponseProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.ProvisioningState left, Azure.ResourceManager.HybridContainerService.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.ProvisioningState left, Azure.ResourceManager.HybridContainerService.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageSpacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacePatch>
    {
        public StorageSpacePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.StorageSpacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.StorageSpacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacePatch>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacePatch>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacePatch>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageSpacesExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesExtendedLocation>
    {
        public StorageSpacesExtendedLocation() { }
        public string Name { get { throw null; } set { } }
        public string StorageSpacesExtendedLocationType { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.StorageSpacesExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.StorageSpacesExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesExtendedLocation>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesExtendedLocation>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesExtendedLocation>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageSpacesProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesProperties>
    {
        public StorageSpacesProperties() { }
        public Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesHciStorageProfile HciStorageProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatus ProvisioningStatus { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesVmwareStorageProfile VmwareStorageProfile { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.StorageSpacesProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.StorageSpacesProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageSpacesPropertiesHciStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesHciStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesHciStorageProfile>
    {
        public StorageSpacesPropertiesHciStorageProfile() { }
        public string MocGroup { get { throw null; } set { } }
        public string MocLocation { get { throw null; } set { } }
        public string MocStorageContainer { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesHciStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesHciStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesHciStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesHciStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesHciStorageProfile>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesHciStorageProfile>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesHciStorageProfile>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageSpacesPropertiesStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatus>
    {
        public StorageSpacesPropertiesStatusProvisioningStatus() { }
        public Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatusError Error { get { throw null; } set { } }
        public string OperationId { get { throw null; } set { } }
        public string Phase { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatus>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageSpacesPropertiesStatusProvisioningStatusError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatusError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatusError>
    {
        public StorageSpacesPropertiesStatusProvisioningStatusError() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatusError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatusError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatusError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatusError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatusError>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatusError>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesStatusProvisioningStatusError>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageSpacesPropertiesVmwareStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesVmwareStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesVmwareStorageProfile>
    {
        public StorageSpacesPropertiesVmwareStorageProfile() { }
        public string Datacenter { get { throw null; } set { } }
        public string Datastore { get { throw null; } set { } }
        public string Folder { get { throw null; } set { } }
        public string ResourcePool { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesVmwareStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesVmwareStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesVmwareStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesVmwareStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesVmwareStorageProfile>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesVmwareStorageProfile>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.StorageSpacesPropertiesVmwareStorageProfile>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualNetworksExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksExtendedLocation>
    {
        public VirtualNetworksExtendedLocation() { }
        public string Name { get { throw null; } set { } }
        public string VirtualNetworksExtendedLocationType { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksExtendedLocation>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksExtendedLocation>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksExtendedLocation>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualNetworksProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksProperties>
    {
        public VirtualNetworksProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> DhcpServers { get { throw null; } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public string Gateway { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfile InfraVnetProfile { get { throw null; } set { } }
        public string IPAddressPrefix { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVipPoolItem> VipPool { get { throw null; } }
        public string VlanId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVmipPoolItem> VmipPool { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualNetworksPropertiesInfraVnetProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfile>
    {
        public VirtualNetworksPropertiesInfraVnetProfile() { }
        public Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfileHci Hci { get { throw null; } set { } }
        public string NetworkId { get { throw null; } set { } }
        public string VmwareSegmentName { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfile>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfile>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfile>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualNetworksPropertiesInfraVnetProfileHci : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfileHci>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfileHci>
    {
        public VirtualNetworksPropertiesInfraVnetProfileHci() { }
        public string MocGroup { get { throw null; } set { } }
        public string MocLocation { get { throw null; } set { } }
        public string MocVnetName { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfileHci System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfileHci>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfileHci>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfileHci System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfileHci>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfileHci>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesInfraVnetProfileHci>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualNetworksPropertiesStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatus>
    {
        internal VirtualNetworksPropertiesStatusProvisioningStatus() { }
        public Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatusError Error { get { throw null; } }
        public string OperationId { get { throw null; } }
        public string Phase { get { throw null; } }
        public string Status { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatus>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualNetworksPropertiesStatusProvisioningStatusError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatusError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatusError>
    {
        internal VirtualNetworksPropertiesStatusProvisioningStatusError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatusError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatusError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatusError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatusError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatusError>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatusError>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesStatusProvisioningStatusError>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualNetworksPropertiesVipPoolItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVipPoolItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVipPoolItem>
    {
        public VirtualNetworksPropertiesVipPoolItem() { }
        public string EndIP { get { throw null; } set { } }
        public string StartIP { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVipPoolItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVipPoolItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVipPoolItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVipPoolItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVipPoolItem>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVipPoolItem>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVipPoolItem>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualNetworksPropertiesVmipPoolItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVmipPoolItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVmipPoolItem>
    {
        public VirtualNetworksPropertiesVmipPoolItem() { }
        public string EndIP { get { throw null; } set { } }
        public string StartIP { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVmipPoolItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVmipPoolItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVmipPoolItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVmipPoolItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVmipPoolItem>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVmipPoolItem>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworksPropertiesVmipPoolItem>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmSkuListResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VmSkuListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VmSkuListResult>
    {
        internal VmSkuListResult() { }
        public System.Collections.Generic.IReadOnlyList<string> VmSKUs { get { throw null; } }
        Azure.ResourceManager.HybridContainerService.Models.VmSkuListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VmSkuListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.VmSkuListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.VmSkuListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VmSkuListResult>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VmSkuListResult>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.VmSkuListResult>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WindowsProfile : Azure.ResourceManager.HybridContainerService.Models.WindowsProfileResponse, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.WindowsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.WindowsProfile>
    {
        public WindowsProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.WindowsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.WindowsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.WindowsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.WindowsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.WindowsProfile>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.WindowsProfile>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.WindowsProfile>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WindowsProfileResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.WindowsProfileResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.WindowsProfileResponse>
    {
        public WindowsProfileResponse() { }
        public string AdminUsername { get { throw null; } set { } }
        public bool? EnableCsiProxy { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.LicenseType? LicenseType { get { throw null; } set { } }
        Azure.ResourceManager.HybridContainerService.Models.WindowsProfileResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.WindowsProfileResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridContainerService.Models.WindowsProfileResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridContainerService.Models.WindowsProfileResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.WindowsProfileResponse>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.WindowsProfileResponse>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridContainerService.Models.WindowsProfileResponse>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
}
