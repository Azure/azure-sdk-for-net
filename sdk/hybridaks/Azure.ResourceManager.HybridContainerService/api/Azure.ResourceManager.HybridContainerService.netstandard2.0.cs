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
        public Azure.ResourceManager.HybridContainerService.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string NodeImageVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.Ossku? OSSKU { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.OSType? OSType { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatus Status { get { throw null; } set { } }
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
        public static Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource GetHybridIdentityMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.KubernetesVersionProfileResource GetKubernetesVersionProfile(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.KubernetesVersionProfileResource GetKubernetesVersionProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource GetProvisionedCluster(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource GetProvisionedClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileResource GetProvisionedClusterUpgradeProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource> GetVirtualNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource>> GetVirtualNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.VirtualNetworkResource GetVirtualNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.VirtualNetworkCollection GetVirtualNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource> GetVirtualNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource> GetVirtualNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.VmSkuProfileResource GetVmSkuProfile(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.VmSkuProfileResource GetVmSkuProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class HybridIdentityMetadataData : Azure.ResourceManager.Models.ResourceData
    {
        public HybridIdentityMetadataData() { }
        public Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
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
        public Azure.ResourceManager.HybridContainerService.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
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
        public Azure.ResourceManager.HybridContainerService.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.Models.ListCredentialResponse> GetAdminKubeconfig(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.Models.ListCredentialResponse>> GetAdminKubeconfigAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource> GetHybridContainerServiceAgentPool(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource>> GetHybridContainerServiceAgentPoolAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolCollection GetHybridContainerServiceAgentPools() { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource GetHybridIdentityMetadata() { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileResource GetProvisionedClusterUpgradeProfile() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.Models.ListCredentialResponse> GetUserKubeconfig(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.Models.ListCredentialResponse>> GetUserKubeconfigAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProvisionedClusterUpgradeProfileData : Azure.ResourceManager.Models.ResourceData
    {
        public ProvisionedClusterUpgradeProfileData(Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile controlPlaneProfile, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile> agentPoolProfiles) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile> AgentPoolProfiles { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile ControlPlaneProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
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
    public partial class VirtualNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource>, System.Collections.IEnumerable
    {
        protected VirtualNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworkName, Azure.ResourceManager.HybridContainerService.VirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworkName, Azure.ResourceManager.HybridContainerService.VirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource> Get(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource>> GetAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource> GetIfExists(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource>> GetIfExistsAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualNetworkData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VirtualNetworkData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkProperties Properties { get { throw null; } set { } }
    }
    public partial class VirtualNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualNetworkResource() { }
        public virtual Azure.ResourceManager.HybridContainerService.VirtualNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VmSkuProfileData : Azure.ResourceManager.Models.ResourceData
    {
        public VmSkuProfileData() { }
        public Azure.ResourceManager.HybridContainerService.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.VmSkuProfileProperties Properties { get { throw null; } }
    }
    public partial class VmSkuProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VmSkuProfileResource() { }
        public virtual Azure.ResourceManager.HybridContainerService.VmSkuProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.VmSkuProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.VmSkuProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridContainerService.VmSkuProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridContainerService.VmSkuProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string customLocationResourceUri) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.VmSkuProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.VmSkuProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HybridContainerService.Mocking
{
    public partial class MockableHybridContainerServiceArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridContainerServiceArmClient() { }
        public virtual Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolResource GetHybridContainerServiceAgentPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataResource GetHybridIdentityMetadataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.KubernetesVersionProfileResource GetKubernetesVersionProfile(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.KubernetesVersionProfileResource GetKubernetesVersionProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource GetProvisionedCluster(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.ProvisionedClusterResource GetProvisionedClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileResource GetProvisionedClusterUpgradeProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.VirtualNetworkResource GetVirtualNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.VmSkuProfileResource GetVmSkuProfile(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.VmSkuProfileResource GetVmSkuProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHybridContainerServiceResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridContainerServiceResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource> GetVirtualNetwork(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource>> GetVirtualNetworkAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridContainerService.VirtualNetworkCollection GetVirtualNetworks() { throw null; }
    }
    public partial class MockableHybridContainerServiceSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridContainerServiceSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource> GetVirtualNetworks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridContainerService.VirtualNetworkResource> GetVirtualNetworksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HybridContainerService.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AddonPhase : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.AddonPhase>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AddonPhase(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.AddonPhase Deleting { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.AddonPhase Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.AddonPhase Pending { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.AddonPhase Provisioned { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.AddonPhase Provisioning { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.AddonPhase ProvisioningHelmChartInstalled { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.AddonPhase ProvisioningMSICertificateDownloaded { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.AddonPhase Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.AddonPhase other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.AddonPhase left, Azure.ResourceManager.HybridContainerService.Models.AddonPhase right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.AddonPhase (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.AddonPhase left, Azure.ResourceManager.HybridContainerService.Models.AddonPhase right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AddonStatusProfile
    {
        internal AddonStatusProfile() { }
        public string ErrorMessage { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.AddonPhase? Phase { get { throw null; } }
        public bool? Ready { get { throw null; } }
    }
    public partial class AgentPoolProfile
    {
        public AgentPoolProfile() { }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public string NodeImageVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.Ossku? OSSKU { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.OSType? OSType { get { throw null; } set { } }
    }
    public partial class AgentPoolProvisioningStatusOperationStatus
    {
        public AgentPoolProvisioningStatusOperationStatus() { }
        public Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusOperationStatusError Error { get { throw null; } set { } }
        public string OperationId { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class AgentPoolProvisioningStatusOperationStatusError
    {
        public AgentPoolProvisioningStatusOperationStatusError() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
    }
    public partial class AgentPoolProvisioningStatusStatus
    {
        public AgentPoolProvisioningStatusStatus() { }
        public string ErrorMessage { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusOperationStatus OperationStatus { get { throw null; } set { } }
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
        public static Azure.ResourceManager.HybridContainerService.Models.AddonStatusProfile AddonStatusProfile(string name = null, Azure.ResourceManager.HybridContainerService.Models.AddonPhase? phase = default(Azure.ResourceManager.HybridContainerService.Models.AddonPhase?), bool? ready = default(bool?), string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.CredentialResult CredentialResult(string name = null, byte[] value = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.HybridContainerServiceAgentPoolData HybridContainerServiceAgentPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridContainerService.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<string> availabilityZones = null, Azure.ResourceManager.HybridContainerService.Models.OSType? osType = default(Azure.ResourceManager.HybridContainerService.Models.OSType?), Azure.ResourceManager.HybridContainerService.Models.Ossku? ossku = default(Azure.ResourceManager.HybridContainerService.Models.Ossku?), string nodeImageVersion = null, int? count = default(int?), string vmSize = null, Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState?), Azure.ResourceManager.HybridContainerService.Models.AgentPoolProvisioningStatusStatus status = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.HybridIdentityMetadataData HybridIdentityMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string resourceUid = null, string publicKey = null, Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.KubernetesPatchVersions KubernetesPatchVersions(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.KubernetesVersionReadiness> readiness = null, System.Collections.Generic.IEnumerable<string> upgrades = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.KubernetesVersionProfileData KubernetesVersionProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridContainerService.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.HybridContainerService.Models.KubernetesVersionProfileProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.KubernetesVersionProfileProperties KubernetesVersionProfileProperties(Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.KubernetesVersionProperties> values = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.KubernetesVersionProperties KubernetesVersionProperties(string version = null, System.Collections.Generic.IEnumerable<string> capabilitiesSupportPlan = null, bool? isPreview = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HybridContainerService.Models.KubernetesPatchVersions> patchVersions = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.KubernetesVersionReadiness KubernetesVersionReadiness(Azure.ResourceManager.HybridContainerService.Models.OSType? osType = default(Azure.ResourceManager.HybridContainerService.Models.OSType?), Azure.ResourceManager.HybridContainerService.Models.Ossku? osSku = default(Azure.ResourceManager.HybridContainerService.Models.Ossku?), bool? ready = default(bool?), string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ListCredentialResponse ListCredentialResponse(string id = null, string name = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState? status = default(Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState?), Azure.ResourceManager.HybridContainerService.Models.ListCredentialResponseError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.CredentialResult> listCredentialResponseKubeconfigs = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ListCredentialResponseError ListCredentialResponseError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.ProvisionedClusterData ProvisionedClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterProperties properties = null, Azure.ResourceManager.HybridContainerService.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile ProvisionedClusterPoolUpgradeProfile(string kubernetesVersion = null, string name = null, Azure.ResourceManager.HybridContainerService.Models.OSType? osType = default(Azure.ResourceManager.HybridContainerService.Models.OSType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfileProperties> upgrades = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfileProperties ProvisionedClusterPoolUpgradeProfileProperties(string kubernetesVersion = null, bool? isPreview = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterProperties ProvisionedClusterProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.LinuxProfilePropertiesSshPublicKeysItem> sshPublicKeys = null, Azure.ResourceManager.HybridContainerService.Models.ControlPlaneProfile controlPlane = null, string kubernetesVersion = null, Azure.ResourceManager.HybridContainerService.Models.NetworkProfile networkProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.NamedAgentPoolProfile> agentPoolProfiles = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> infraNetworkVnetSubnetIds = null, Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState?), Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPropertiesStatus status = null, Azure.ResourceManager.HybridContainerService.Models.AzureHybridBenefit? licenseAzureHybridBenefit = default(Azure.ResourceManager.HybridContainerService.Models.AzureHybridBenefit?)) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPropertiesStatus ProvisionedClusterPropertiesStatus(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.AddonStatusProfile> controlPlaneStatus = null, string errorMessage = null, Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPropertiesStatusOperationStatus operationStatus = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPropertiesStatusOperationStatus ProvisionedClusterPropertiesStatusOperationStatus(Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPropertiesStatusOperationStatusError error = null, string operationId = null, string status = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPropertiesStatusOperationStatusError ProvisionedClusterPropertiesStatusOperationStatusError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.ProvisionedClusterUpgradeProfileData ProvisionedClusterUpgradeProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState?), Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile controlPlaneProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPoolUpgradeProfile> agentPoolProfiles = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.VirtualNetworkData VirtualNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkProperties properties = null, Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkProperties VirtualNetworkProperties(Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkPropertiesInfraVnetProfile infraVnetProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkPropertiesVipPoolItem> vipPool = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkPropertiesVmipPoolItem> vmipPool = null, System.Collections.Generic.IEnumerable<string> dhcpServers = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, string gateway = null, string ipAddressPrefix = null, int? vlanId = default(int?), Azure.ResourceManager.HybridContainerService.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridContainerService.Models.ProvisioningState?), Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkPropertiesStatusOperationStatus operationStatus = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkPropertiesStatusOperationStatus VirtualNetworkPropertiesStatusOperationStatus(Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkPropertiesStatusOperationStatusError error = null, string operationId = null, string phase = null, string status = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkPropertiesStatusOperationStatusError VirtualNetworkPropertiesStatusOperationStatusError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.VmSkuCapabilities VmSkuCapabilities(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.VmSkuProfileData VmSkuProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridContainerService.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.HybridContainerService.Models.VmSkuProfileProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.VmSkuProfileProperties VmSkuProfileProperties(Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.VmSkuProperties> values = null) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.VmSkuProperties VmSkuProperties(string resourceType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridContainerService.Models.VmSkuCapabilities> capabilities = null, string name = null, string tier = null, string size = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureHybridBenefit : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.AzureHybridBenefit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureHybridBenefit(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.AzureHybridBenefit False { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.AzureHybridBenefit NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.AzureHybridBenefit True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.AzureHybridBenefit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.AzureHybridBenefit left, Azure.ResourceManager.HybridContainerService.Models.AzureHybridBenefit right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.AzureHybridBenefit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.AzureHybridBenefit left, Azure.ResourceManager.HybridContainerService.Models.AzureHybridBenefit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ControlPlaneEndpointProfileControlPlaneEndpoint
    {
        public ControlPlaneEndpointProfileControlPlaneEndpoint() { }
        public string HostIP { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
    }
    public partial class ControlPlaneProfile : Azure.ResourceManager.HybridContainerService.Models.NamedAgentPoolProfile
    {
        public ControlPlaneProfile() { }
        public Azure.ResourceManager.HybridContainerService.Models.ControlPlaneEndpointProfileControlPlaneEndpoint ControlPlaneEndpoint { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.LinuxProfilePropertiesSshPublicKeysItem> SshPublicKeys { get { throw null; } }
    }
    public partial class CredentialResult
    {
        internal CredentialResult() { }
        public string Name { get { throw null; } }
        public byte[] Value { get { throw null; } }
    }
    public partial class ExtendedLocation
    {
        public ExtendedLocation() { }
        public Azure.ResourceManager.HybridContainerService.Models.ExtendedLocationType? ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtendedLocationType : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.ExtendedLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtendedLocationType(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ExtendedLocationType CustomLocation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.ExtendedLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.ExtendedLocationType left, Azure.ResourceManager.HybridContainerService.Models.ExtendedLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.ExtendedLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.ExtendedLocationType left, Azure.ResourceManager.HybridContainerService.Models.ExtendedLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HybridContainerServiceAgentPoolPatch
    {
        public HybridContainerServiceAgentPoolPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
        public Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
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
        public Azure.ResourceManager.HybridContainerService.Models.Ossku? OSSku { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.OSType? OSType { get { throw null; } }
        public bool? Ready { get { throw null; } }
    }
    public partial class LinuxProfilePropertiesSshPublicKeysItem
    {
        public LinuxProfilePropertiesSshPublicKeysItem() { }
        public string KeyData { get { throw null; } set { } }
    }
    public partial class ListCredentialResponse
    {
        internal ListCredentialResponse() { }
        public Azure.ResourceManager.HybridContainerService.Models.ListCredentialResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridContainerService.Models.CredentialResult> ListCredentialResponseKubeconfigs { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState? Status { get { throw null; } }
    }
    public partial class ListCredentialResponseError
    {
        internal ListCredentialResponseError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class NamedAgentPoolProfile : Azure.ResourceManager.HybridContainerService.Models.AgentPoolProfile
    {
        public NamedAgentPoolProfile() { }
        public int? Count { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
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
    public partial class NetworkProfile
    {
        public NetworkProfile() { }
        public int? LoadBalancerCount { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.NetworkPolicy? NetworkPolicy { get { throw null; } set { } }
        public string PodCidr { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Ossku : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.Ossku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Ossku(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.Ossku CBLMariner { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.Ossku Windows2019 { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.Ossku Windows2022 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.Ossku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.Ossku left, Azure.ResourceManager.HybridContainerService.Models.Ossku right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.Ossku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.Ossku left, Azure.ResourceManager.HybridContainerService.Models.Ossku right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class ProvisionedClusterPoolUpgradeProfile
    {
        public ProvisionedClusterPoolUpgradeProfile() { }
        public string KubernetesVersion { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.OSType? OSType { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.NamedAgentPoolProfile> AgentPoolProfiles { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.ControlPlaneProfile ControlPlane { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> InfraNetworkVnetSubnetIds { get { throw null; } }
        public string KubernetesVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.AzureHybridBenefit? LicenseAzureHybridBenefit { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.LinuxProfilePropertiesSshPublicKeysItem> SshPublicKeys { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPropertiesStatus Status { get { throw null; } }
    }
    public partial class ProvisionedClusterPropertiesStatus
    {
        internal ProvisionedClusterPropertiesStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridContainerService.Models.AddonStatusProfile> ControlPlaneStatus { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPropertiesStatusOperationStatus OperationStatus { get { throw null; } }
    }
    public partial class ProvisionedClusterPropertiesStatusOperationStatus
    {
        internal ProvisionedClusterPropertiesStatusOperationStatus() { }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisionedClusterPropertiesStatusOperationStatusError Error { get { throw null; } }
        public string OperationId { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ProvisionedClusterPropertiesStatusOperationStatusError
    {
        internal ProvisionedClusterPropertiesStatusOperationStatusError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState Updating { get { throw null; } }
        public static Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState left, Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState left, Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualNetworkExtendedLocation
    {
        public VirtualNetworkExtendedLocation() { }
        public string Name { get { throw null; } set { } }
        public string VirtualNetworkExtendedLocationType { get { throw null; } set { } }
    }
    public partial class VirtualNetworkPatch
    {
        public VirtualNetworkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class VirtualNetworkProperties
    {
        public VirtualNetworkProperties() { }
        public System.Collections.Generic.IList<string> DhcpServers { get { throw null; } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public string Gateway { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkPropertiesInfraVnetProfile InfraVnetProfile { get { throw null; } set { } }
        public string IPAddressPrefix { get { throw null; } set { } }
        public Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkPropertiesStatusOperationStatus OperationStatus { get { throw null; } }
        public Azure.ResourceManager.HybridContainerService.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkPropertiesVipPoolItem> VipPool { get { throw null; } }
        public int? VlanId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkPropertiesVmipPoolItem> VmipPool { get { throw null; } }
    }
    public partial class VirtualNetworkPropertiesInfraVnetProfile
    {
        public VirtualNetworkPropertiesInfraVnetProfile() { }
        public Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkPropertiesInfraVnetProfileHci Hci { get { throw null; } set { } }
        public string VmwareSegmentName { get { throw null; } set { } }
    }
    public partial class VirtualNetworkPropertiesInfraVnetProfileHci
    {
        public VirtualNetworkPropertiesInfraVnetProfileHci() { }
        public string MocGroup { get { throw null; } set { } }
        public string MocLocation { get { throw null; } set { } }
        public string MocVnetName { get { throw null; } set { } }
    }
    public partial class VirtualNetworkPropertiesStatusOperationStatus
    {
        internal VirtualNetworkPropertiesStatusOperationStatus() { }
        public Azure.ResourceManager.HybridContainerService.Models.VirtualNetworkPropertiesStatusOperationStatusError Error { get { throw null; } }
        public string OperationId { get { throw null; } }
        public string Phase { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class VirtualNetworkPropertiesStatusOperationStatusError
    {
        internal VirtualNetworkPropertiesStatusOperationStatusError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class VirtualNetworkPropertiesVipPoolItem
    {
        public VirtualNetworkPropertiesVipPoolItem() { }
        public string EndIP { get { throw null; } set { } }
        public string StartIP { get { throw null; } set { } }
    }
    public partial class VirtualNetworkPropertiesVmipPoolItem
    {
        public VirtualNetworkPropertiesVmipPoolItem() { }
        public string EndIP { get { throw null; } set { } }
        public string StartIP { get { throw null; } set { } }
    }
    public partial class VmSkuCapabilities
    {
        internal VmSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class VmSkuProfileProperties
    {
        internal VmSkuProfileProperties() { }
        public Azure.ResourceManager.HybridContainerService.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridContainerService.Models.VmSkuProperties> Values { get { throw null; } }
    }
    public partial class VmSkuProperties
    {
        internal VmSkuProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridContainerService.Models.VmSkuCapabilities> Capabilities { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
    }
}
