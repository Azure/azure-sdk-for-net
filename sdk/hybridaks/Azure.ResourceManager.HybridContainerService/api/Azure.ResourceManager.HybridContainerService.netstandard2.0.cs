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
    public partial class HybridContainerServiceAgentPoolData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HybridContainerServiceAgentPoolData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public int? Count { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string NodeImageVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSSku? OSSku { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSType? OSType { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatus Status { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class HybridContainerServiceAgentPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridContainerServiceAgentPoolResource() { }
        public virtual Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string connectedClusterResourceUri, string agentPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceAgentPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceAgentPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HybridContainerServiceExtensions
    {
        public static Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource GetHybridContainerServiceAgentPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> GetHybridContainerServiceVirtualNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>> GetHybridContainerServiceVirtualNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource GetHybridContainerServiceVirtualNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkCollection GetHybridContainerServiceVirtualNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> GetHybridContainerServiceVirtualNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> GetHybridContainerServiceVirtualNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.HybridContainerServiceVmSkuResource GetHybridContainerServiceVmSku(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.HybridContainerServiceVmSkuResource GetHybridContainerServiceVmSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource GetHybridIdentityMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.KubernetesVersionProfileResource GetKubernetesVersionProfile(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.KubernetesVersionProfileResource GetKubernetesVersionProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource GetProvisionedCluster(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource GetProvisionedClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileResource GetProvisionedClusterUpgradeProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class HybridContainerServiceVirtualNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>, System.Collections.IEnumerable
    {
        protected HybridContainerServiceVirtualNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworkName, Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworkName, Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> Get(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>> GetAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> GetIfExists(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>> GetIfExistsAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridContainerServiceVirtualNetworkData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HybridContainerServiceVirtualNetworkData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceVirtualNetworkProperties Properties { get { throw null; } set { } }
    }
    public partial class HybridContainerServiceVirtualNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridContainerServiceVirtualNetworkResource() { }
        public virtual Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualNetworkName) { throw null; }
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
    public partial class HybridContainerServiceVmSkuData : Azure.ResourceManager.Models.ResourceData
    {
        public HybridContainerServiceVmSkuData() { }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceVmSkuProperties> Values { get { throw null; } }
    }
    public partial class HybridContainerServiceVmSkuResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridContainerServiceVmSkuResource() { }
        public virtual Azure.ResourceManager.HybridContainerService.HybridContainerServiceVmSkuData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVmSkuResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.HybridContainerServiceVmSkuData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVmSkuResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.HybridContainerServiceVmSkuData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string customLocationResourceUri) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVmSkuResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVmSkuResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridIdentityMetadataData : Azure.ResourceManager.Models.ResourceData
    {
        public HybridIdentityMetadataData() { }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string PublicKey { get { throw null; } set { } }
        public string ResourceUid { get { throw null; } set { } }
    }
    public partial class HybridIdentityMetadataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridIdentityMetadataResource() { }
        public virtual Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string connectedClusterResourceUri) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KubernetesVersionProfileData : Azure.ResourceManager.Models.ResourceData
    {
        public KubernetesVersionProfileData() { }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.KubernetesVersionProfileProperties Properties { get { throw null; } }
    }
    public partial class KubernetesVersionProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KubernetesVersionProfileResource() { }
        public virtual Azure.ResourceManager.HybridContainerService.KubernetesVersionProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.KubernetesVersionProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.KubernetesVersionProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.KubernetesVersionProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.KubernetesVersionProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string customLocationResourceUri) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.KubernetesVersionProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.KubernetesVersionProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProvisionedClusterData : Azure.ResourceManager.Models.ResourceData
    {
        public ProvisionedClusterData() { }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterProperties Properties { get { throw null; } set { } }
    }
    public partial class ProvisionedClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProvisionedClusterResource() { }
        public virtual Azure.ResourceManager.HybridContainerService.ProvisionedClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.ProvisionedClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.ProvisionedClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string connectedClusterResourceUri) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceCredentialListResult> GetAdminKubeconfig(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceCredentialListResult>> GetAdminKubeconfigAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource> GetHybridContainerServiceAgentPool(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource>> GetHybridContainerServiceAgentPoolAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolCollection GetHybridContainerServiceAgentPools() { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource GetHybridIdentityMetadata() { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileResource GetProvisionedClusterUpgradeProfile() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceCredentialListResult> GetUserKubeconfig(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceCredentialListResult>> GetUserKubeconfigAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProvisionedClusterUpgradeProfileData : Azure.ResourceManager.Models.ResourceData
    {
        public ProvisionedClusterUpgradeProfileData(Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile controlPlaneProfile, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile> agentPoolProfiles) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile> AgentPoolProfiles { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile ControlPlaneProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ProvisionedClusterUpgradeProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProvisionedClusterUpgradeProfileResource() { }
        public virtual Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string connectedClusterResourceUri) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HybridContainerService.Mocking
{
    public partial class MockableHybridContainerServiceArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridContainerServiceArmClient() { }
        public virtual Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource GetHybridContainerServiceAgentPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource GetHybridContainerServiceVirtualNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.HybridContainerServiceVmSkuResource GetHybridContainerServiceVmSku(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.HybridContainerServiceVmSkuResource GetHybridContainerServiceVmSkuResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource GetHybridIdentityMetadataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.KubernetesVersionProfileResource GetKubernetesVersionProfile(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.KubernetesVersionProfileResource GetKubernetesVersionProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource GetProvisionedCluster(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource GetProvisionedClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileResource GetProvisionedClusterUpgradeProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHybridContainerServiceResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridContainerServiceResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> GetHybridContainerServiceVirtualNetwork(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource>> GetHybridContainerServiceVirtualNetworkAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkCollection GetHybridContainerServiceVirtualNetworks() { throw null; }
    }
    public partial class MockableHybridContainerServiceSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridContainerServiceSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> GetHybridContainerServiceVirtualNetworks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkResource> GetHybridContainerServiceVirtualNetworksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HybridContainerService.Models
{
    public partial class AgentPoolOperationError
    {
        public AgentPoolOperationError() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
    }
    public partial class AgentPoolOperationStatus
    {
        public AgentPoolOperationStatus() { }
        public Azure.ResourceManager.HybridContainerService.Models.AgentPoolOperationError Error { get { throw null; } set { } }
        public string OperationId { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class AgentPoolProvisioningStatus
    {
        public AgentPoolProvisioningStatus() { }
        public string ErrorMessage { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.AgentPoolOperationStatus OperationStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.AgentPoolUpdateProfile> ReadyReplicas { get { throw null; } }
    }
    public partial class AgentPoolUpdateProfile
    {
        public AgentPoolUpdateProfile() { }
        public int? Count { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public static partial class ArmHybridContainerServiceModelFactory
    {
        public static Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolData HybridContainerServiceAgentPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<string> availabilityZones = null, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSType? osType = default(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSType?), Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSSku? osSku = default(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSSku?), string nodeImageVersion = null, int? count = default(int?), string vmSize = null, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState?), Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatus status = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceCredential HybridContainerServiceCredential(string name = null, byte[] value = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceCredentialListError HybridContainerServiceCredentialListError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceCredentialListResult HybridContainerServiceCredentialListResult(string id = null, string name = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState? status = default(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState?), Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceCredentialListError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceCredential> listCredentialResponseKubeconfigs = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceNetworkOperationError HybridContainerServiceNetworkOperationError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.HybridContainerServiceVirtualNetworkData HybridContainerServiceVirtualNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceVirtualNetworkProperties properties = null, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceVirtualNetworkProperties HybridContainerServiceVirtualNetworkProperties(Azure.ResourceManager.HybridContainerService.Models.InfraVnetProfile infraVnetProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.KubernetesVirtualIPItem> vipPool = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.VirtualMachineIPItem> vmipPool = null, System.Collections.Generic.IEnumerable<string> dhcpServers = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, string gateway = null, string ipAddressPrefix = null, int? vlanId = default(int?), Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceProvisioningState?), Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkPropertiesStatusOperationStatus operationStatus = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceVmSkuCapabilities HybridContainerServiceVmSkuCapabilities(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.HybridContainerServiceVmSkuData HybridContainerServiceVmSkuData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceExtendedLocation extendedLocation = null, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceVmSkuProperties> values = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceVmSkuProperties HybridContainerServiceVmSkuProperties(string resourceType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceVmSkuCapabilities> capabilities = null, string name = null, string tier = null, string size = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataData HybridIdentityMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string resourceUid = null, string publicKey = null, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.KubernetesPatchVersions KubernetesPatchVersions(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.KubernetesVersionReadiness> readiness = null, System.Collections.Generic.IEnumerable<string> upgrades = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.KubernetesVersionProfileData KubernetesVersionProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceExtendedLocation extendedLocation = null, Azure.ResourceManager.HybridContainerService.Models.KubernetesVersionProfileProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.KubernetesVersionProfileProperties KubernetesVersionProfileProperties(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.KubernetesVersionProperties> values = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.KubernetesVersionProperties KubernetesVersionProperties(string version = null, System.Collections.Generic.IEnumerable<string> capabilitiesSupportPlan = null, bool? isPreview = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HybridContainerService.Models.KubernetesPatchVersions> patchVersions = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.KubernetesVersionReadiness KubernetesVersionReadiness(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSType? osType = default(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSType?), Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSSku? osSku = default(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSSku?), bool? ready = default(bool?), string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonStatusProfile ProvisionedClusterAddonStatusProfile(string name = null, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonPhase? phase = default(Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonPhase?), bool? ready = default(bool?), string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.ProvisionedClusterData ProvisionedClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterProperties properties = null, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterOperationError ProvisionedClusterOperationError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterOperationStatus ProvisionedClusterOperationStatus(Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterOperationError error = null, string operationId = null, string status = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile ProvisionedClusterPoolUpgradeProfile(string kubernetesVersion = null, string name = null, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSType? osType = default(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfileProperties> upgrades = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfileProperties ProvisionedClusterPoolUpgradeProfileProperties(string kubernetesVersion = null, bool? isPreview = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterProperties ProvisionedClusterProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.LinuxSshPublicKey> sshPublicKeys = null, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterControlPlaneProfile controlPlane = null, string kubernetesVersion = null, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterNetworkProfile networkProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceNamedAgentPoolProfile> agentPoolProfiles = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> infraNetworkVnetSubnetIds = null, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState?), Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterStatus status = null, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAzureHybridBenefit? licenseAzureHybridBenefit = default(Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAzureHybridBenefit?)) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterStatus ProvisionedClusterStatus(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonStatusProfile> controlPlaneStatus = null, string errorMessage = null, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterOperationStatus operationStatus = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileData ProvisionedClusterUpgradeProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState?), Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile controlPlaneProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile> agentPoolProfiles = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkPropertiesStatusOperationStatus VirtualNetworkPropertiesStatusOperationStatus(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceNetworkOperationError error = null, string operationId = null, string phase = null, string status = null) { throw null; }
    }
    public partial class HciInfraVnetProfile
    {
        public HciInfraVnetProfile() { }
        public string MocGroup { get { throw null; } set { } }
        public string MocLocation { get { throw null; } set { } }
        public string MocVnetName { get { throw null; } set { } }
    }
    public partial class HybridContainerServiceAgentPoolPatch
    {
        public HybridContainerServiceAgentPoolPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class HybridContainerServiceAgentPoolProfile
    {
        public HybridContainerServiceAgentPoolProfile() { }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public string NodeImageVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSSku? OSSku { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSType? OSType { get { throw null; } set { } }
    }
    public partial class HybridContainerServiceCredential
    {
        internal HybridContainerServiceCredential() { }
        public string Name { get { throw null; } }
        public byte[] Value { get { throw null; } }
    }
    public partial class HybridContainerServiceCredentialListError
    {
        internal HybridContainerServiceCredentialListError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class HybridContainerServiceCredentialListResult
    {
        internal HybridContainerServiceCredentialListResult() { }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceCredentialListError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceCredential> ListCredentialResponseKubeconfigs { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState? Status { get { throw null; } }
    }
    public partial class HybridContainerServiceExtendedLocation
    {
        public HybridContainerServiceExtendedLocation() { }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceExtendedLocationType? ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridContainerServiceExtendedLocationType : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceExtendedLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridContainerServiceExtendedLocationType(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceExtendedLocationType CustomLocation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceExtendedLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceExtendedLocationType left, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceExtendedLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceExtendedLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceExtendedLocationType left, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceExtendedLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HybridContainerServiceNamedAgentPoolProfile : Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceAgentPoolProfile
    {
        public HybridContainerServiceNamedAgentPoolProfile() { }
        public int? Count { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class HybridContainerServiceNetworkOperationError
    {
        internal HybridContainerServiceNetworkOperationError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridContainerServiceOSSku : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridContainerServiceOSSku(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSSku CBLMariner { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSSku Windows2019 { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSSku Windows2022 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSSku left, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSSku left, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridContainerServiceOSType : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridContainerServiceOSType(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSType Linux { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSType left, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSType left, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridContainerServiceProvisioningState : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridContainerServiceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceProvisioningState left, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceProvisioningState left, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridContainerServiceResourceProvisioningState : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridContainerServiceResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState Updating { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState left, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState left, Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HybridContainerServiceVirtualNetworkPatch
    {
        public HybridContainerServiceVirtualNetworkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class HybridContainerServiceVirtualNetworkProperties
    {
        public HybridContainerServiceVirtualNetworkProperties() { }
        public System.Collections.Generic.IList<string> DhcpServers { get { throw null; } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public string Gateway { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.InfraVnetProfile InfraVnetProfile { get { throw null; } set { } }
        public string IPAddressPrefix { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkPropertiesStatusOperationStatus OperationStatus { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.KubernetesVirtualIPItem> VipPool { get { throw null; } }
        public int? VlanId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.VirtualMachineIPItem> VmipPool { get { throw null; } }
    }
    public partial class HybridContainerServiceVmSkuCapabilities
    {
        internal HybridContainerServiceVmSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class HybridContainerServiceVmSkuProperties
    {
        public HybridContainerServiceVmSkuProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceVmSkuCapabilities> Capabilities { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class InfraVnetProfile
    {
        public InfraVnetProfile() { }
        public Azure.ResourceManager.HybridContainerService.Models.HciInfraVnetProfile Hci { get { throw null; } set { } }
        public string VmwareSegmentName { get { throw null; } set { } }
    }
    public partial class KubernetesPatchVersions
    {
        internal KubernetesPatchVersions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridContainerService.Models.KubernetesVersionReadiness> Readiness { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Upgrades { get { throw null; } }
    }
    public partial class KubernetesVersionProfileProperties
    {
        internal KubernetesVersionProfileProperties() { }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridContainerService.Models.KubernetesVersionProperties> Values { get { throw null; } }
    }
    public partial class KubernetesVersionProperties
    {
        internal KubernetesVersionProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> CapabilitiesSupportPlan { get { throw null; } }
        public bool? IsPreview { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HybridContainerService.Models.KubernetesPatchVersions> PatchVersions { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class KubernetesVersionReadiness
    {
        internal KubernetesVersionReadiness() { }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSSku? OSSku { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSType? OSType { get { throw null; } }
        public bool? Ready { get { throw null; } }
    }
    public partial class KubernetesVirtualIPItem
    {
        public KubernetesVirtualIPItem() { }
        public string EndIP { get { throw null; } set { } }
        public string StartIP { get { throw null; } set { } }
    }
    public partial class LinuxSshPublicKey
    {
        public LinuxSshPublicKey() { }
        public string KeyData { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisionedClusterAddonPhase : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonPhase>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisionedClusterAddonPhase(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonPhase Deleting { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonPhase Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonPhase Pending { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonPhase Provisioned { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonPhase Provisioning { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonPhase ProvisioningHelmChartInstalled { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonPhase ProvisioningMSICertificateDownloaded { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonPhase Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonPhase other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonPhase left, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonPhase right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonPhase (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonPhase left, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonPhase right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProvisionedClusterAddonStatusProfile
    {
        internal ProvisionedClusterAddonStatusProfile() { }
        public string ErrorMessage { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonPhase? Phase { get { throw null; } }
        public bool? Ready { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisionedClusterAzureHybridBenefit : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAzureHybridBenefit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisionedClusterAzureHybridBenefit(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAzureHybridBenefit False { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAzureHybridBenefit NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAzureHybridBenefit True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAzureHybridBenefit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAzureHybridBenefit left, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAzureHybridBenefit right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAzureHybridBenefit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAzureHybridBenefit left, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAzureHybridBenefit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProvisionedClusterControlPlaneEndpoint
    {
        public ProvisionedClusterControlPlaneEndpoint() { }
        public string HostIP { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
    }
    public partial class ProvisionedClusterControlPlaneProfile : Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceNamedAgentPoolProfile
    {
        public ProvisionedClusterControlPlaneProfile() { }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterControlPlaneEndpoint ControlPlaneEndpoint { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.LinuxSshPublicKey> SshPublicKeys { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisionedClusterNetworkPolicy : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterNetworkPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisionedClusterNetworkPolicy(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterNetworkPolicy Calico { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterNetworkPolicy Flannel { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterNetworkPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterNetworkPolicy left, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterNetworkPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterNetworkPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterNetworkPolicy left, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterNetworkPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProvisionedClusterNetworkProfile
    {
        public ProvisionedClusterNetworkProfile() { }
        public int? LoadBalancerCount { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterNetworkPolicy? NetworkPolicy { get { throw null; } set { } }
        public string PodCidr { get { throw null; } set { } }
    }
    public partial class ProvisionedClusterOperationError
    {
        internal ProvisionedClusterOperationError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class ProvisionedClusterOperationStatus
    {
        internal ProvisionedClusterOperationStatus() { }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterOperationError Error { get { throw null; } }
        public string OperationId { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ProvisionedClusterPoolUpgradeProfile
    {
        public ProvisionedClusterPoolUpgradeProfile() { }
        public string KubernetesVersion { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceOSType? OSType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfileProperties> Upgrades { get { throw null; } }
    }
    public partial class ProvisionedClusterPoolUpgradeProfileProperties
    {
        public ProvisionedClusterPoolUpgradeProfileProperties() { }
        public bool? IsPreview { get { throw null; } }
        public string KubernetesVersion { get { throw null; } }
    }
    public partial class ProvisionedClusterProperties
    {
        public ProvisionedClusterProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceNamedAgentPoolProfile> AgentPoolProfiles { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterControlPlaneProfile ControlPlane { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> InfraNetworkVnetSubnetIds { get { throw null; } }
        public string KubernetesVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAzureHybridBenefit? LicenseAzureHybridBenefit { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.LinuxSshPublicKey> SshPublicKeys { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterStatus Status { get { throw null; } }
    }
    public partial class ProvisionedClusterStatus
    {
        internal ProvisionedClusterStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterAddonStatusProfile> ControlPlaneStatus { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterOperationStatus OperationStatus { get { throw null; } }
    }
    public partial class VirtualMachineIPItem
    {
        public VirtualMachineIPItem() { }
        public string EndIP { get { throw null; } set { } }
        public string StartIP { get { throw null; } set { } }
    }
    public partial class VirtualNetworkPropertiesStatusOperationStatus
    {
        internal VirtualNetworkPropertiesStatusOperationStatus() { }
        public Azure.ResourceManager.HybridContainerService.Models.HybridContainerServiceNetworkOperationError Error { get { throw null; } }
        public string OperationId { get { throw null; } }
        public string Phase { get { throw null; } }
        public string Status { get { throw null; } }
    }
}
