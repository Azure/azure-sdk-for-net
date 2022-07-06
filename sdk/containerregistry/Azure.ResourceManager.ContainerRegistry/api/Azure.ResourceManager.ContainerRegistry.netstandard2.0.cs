namespace Azure.ResourceManager.ContainerRegistry
{
    public partial class AgentPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.AgentPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.AgentPoolResource>, System.Collections.IEnumerable
    {
        protected AgentPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.AgentPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.ContainerRegistry.AgentPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.AgentPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.ContainerRegistry.AgentPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.AgentPoolResource> Get(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.AgentPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.AgentPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.AgentPoolResource>> GetAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.AgentPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.AgentPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.AgentPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.AgentPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AgentPoolData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AgentPoolData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public int? Count { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.O? OS { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string Tier { get { throw null; } set { } }
        public string VirtualNetworkSubnetResourceId { get { throw null; } set { } }
    }
    public partial class AgentPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AgentPoolResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.AgentPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.AgentPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.AgentPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string agentPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.AgentPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.AgentPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.AgentPoolQueueStatus> GetQueueStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.AgentPoolQueueStatus>> GetQueueStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.AgentPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.AgentPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.AgentPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.AgentPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.AgentPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.AgentPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.AgentPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.AgentPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ContainerRegistryExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.RegistryNameStatus> CheckNameAvailabilityRegistry(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ContainerRegistry.Models.RegistryNameCheckContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.RegistryNameStatus>> CheckNameAvailabilityRegistryAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ContainerRegistry.Models.RegistryNameCheckContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.AgentPoolResource GetAgentPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource GetContainerRegistryPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource GetContainerRegistryPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.RegistryCollection GetRegistries(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerRegistry.RegistryResource> GetRegistries(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.RegistryResource> GetRegistriesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.RegistryResource> GetRegistry(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.RegistryResource>> GetRegistryAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.RegistryResource GetRegistryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ReplicationResource GetReplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.RunResource GetRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.TaskResource GetTaskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.TaskRunResource GetTaskRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.WebhookResource GetWebhookResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ContainerRegistryPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public ContainerRegistryPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ContainerRegistryPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryPrivateLinkResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal ContainerRegistryPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class RegistryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.RegistryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.RegistryResource>, System.Collections.IEnumerable
    {
        protected RegistryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.RegistryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string registryName, Azure.ResourceManager.ContainerRegistry.RegistryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.RegistryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string registryName, Azure.ResourceManager.ContainerRegistry.RegistryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.RegistryResource> Get(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.RegistryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.RegistryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.RegistryResource>> GetAsync(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.RegistryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.RegistryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.RegistryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.RegistryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RegistryData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public RegistryData(Azure.Core.AzureLocation location, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku sku) : base (default(Azure.Core.AzureLocation)) { }
        public bool? AdminUserEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
        public bool? DataEndpointEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> DataEndpointHostNames { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.EncryptionProperty Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties Identity { get { throw null; } set { } }
        public string LoginServer { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.NetworkRuleBypassOption? NetworkRuleBypassOptions { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.NetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.Policies Policies { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.Status Status { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ZoneRedundancy? ZoneRedundancy { get { throw null; } set { } }
    }
    public partial class RegistryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RegistryResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.RegistryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.RegistryResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.RegistryResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.RegistryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.AgentPoolResource> GetAgentPool(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.AgentPoolResource>> GetAgentPoolAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.AgentPoolCollection GetAgentPools() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.RegistryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition> GetBuildSourceUploadUrlBuild(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition>> GetBuildSourceUploadUrlBuildAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource> GetContainerRegistryPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource>> GetContainerRegistryPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionCollection GetContainerRegistryPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource> GetContainerRegistryPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource>> GetContainerRegistryPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceCollection GetContainerRegistryPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.RegistryListCredentialsResult> GetCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.RegistryListCredentialsResult>> GetCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ReplicationResource> GetReplication(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ReplicationResource>> GetReplicationAsync(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ReplicationCollection GetReplications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.RunResource> GetRun(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.RunResource>> GetRunAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.RunCollection GetRuns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskResource> GetTask(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskResource>> GetTaskAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskRunResource> GetTaskRun(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskRunResource>> GetTaskRunAsync(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.TaskRunCollection GetTaskRuns() { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.TaskCollection GetTasks() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.Models.RegistryUsage> GetUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.Models.RegistryUsage> GetUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.WebhookResource> GetWebhook(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.WebhookResource>> GetWebhookAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.WebhookCollection GetWebhooks() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ImportImage(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ImportImageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ImportImageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ImportImageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.RegistryListCredentialsResult> RegenerateCredential(Azure.ResourceManager.ContainerRegistry.Models.RegenerateCredentialContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.RegistryListCredentialsResult>> RegenerateCredentialAsync(Azure.ResourceManager.ContainerRegistry.Models.RegenerateCredentialContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.RegistryResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.RegistryResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.RunResource> ScheduleRunSchedule(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.RunContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.RunResource>> ScheduleRunScheduleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.RunContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.RegistryResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.RegistryResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.RegistryResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.RegistryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.RegistryResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.RegistryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ReplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ReplicationResource>, System.Collections.IEnumerable
    {
        protected ReplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ReplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string replicationName, Azure.ResourceManager.ContainerRegistry.ReplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ReplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string replicationName, Azure.ResourceManager.ContainerRegistry.ReplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ReplicationResource> Get(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ReplicationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ReplicationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ReplicationResource>> GetAsync(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ReplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ReplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ReplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ReplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ReplicationData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ReplicationData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public bool? RegionEndpointEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.Status Status { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ZoneRedundancy? ZoneRedundancy { get { throw null; } set { } }
    }
    public partial class ReplicationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReplicationResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ReplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ReplicationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ReplicationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string replicationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ReplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ReplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ReplicationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ReplicationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ReplicationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ReplicationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ReplicationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ReplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ReplicationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ReplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.RunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.RunResource>, System.Collections.IEnumerable
    {
        protected RunCollection() { }
        public virtual Azure.Response<bool> Exists(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.RunResource> Get(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.RunResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.RunResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.RunResource>> GetAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.RunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.RunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.RunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.RunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RunData : Azure.ResourceManager.Models.ResourceData
    {
        public RunData() { }
        public int? AgentCpu { get { throw null; } set { } }
        public string AgentPoolName { get { throw null; } set { } }
        public System.DateTimeOffset? CreateOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> CustomRegistries { get { throw null; } }
        public System.DateTimeOffset? FinishOn { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ImageUpdateTrigger ImageUpdateTrigger { get { throw null; } set { } }
        public bool? IsArchiveEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ImageDescriptor LogArtifact { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ImageDescriptor> OutputImages { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.PlatformProperties Platform { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string RunErrorMessage { get { throw null; } }
        public string RunId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.RunType? RunType { get { throw null; } set { } }
        public string SourceRegistryAuth { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceTriggerDescriptor SourceTrigger { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.RunStatus? Status { get { throw null; } set { } }
        public string Task { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.TimerTriggerDescriptor TimerTrigger { get { throw null; } set { } }
        public string UpdateTriggerToken { get { throw null; } set { } }
    }
    public partial class RunResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RunResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.RunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string runId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.RunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.RunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.RunGetLogResult> GetLogSasUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.RunGetLogResult>> GetLogSasUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.RunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.RunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.RunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.RunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TaskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.TaskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.TaskResource>, System.Collections.IEnumerable
    {
        protected TaskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.TaskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string taskName, Azure.ResourceManager.ContainerRegistry.TaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.TaskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string taskName, Azure.ResourceManager.ContainerRegistry.TaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskResource> Get(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.TaskResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.TaskResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskResource>> GetAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.TaskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.TaskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.TaskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.TaskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TaskData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public TaskData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public int? AgentCpu { get { throw null; } set { } }
        public string AgentPoolName { get { throw null; } set { } }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.Credentials Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties Identity { get { throw null; } set { } }
        public bool? IsSystemTask { get { throw null; } set { } }
        public string LogTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.PlatformProperties Platform { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.TaskStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.TaskStepProperties Step { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.TriggerProperties Trigger { get { throw null; } set { } }
    }
    public partial class TaskResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TaskResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.TaskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string taskName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskResource> GetDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskResource>> GetDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.TaskResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.TaskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.TaskResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.TaskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TaskRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.TaskRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.TaskRunResource>, System.Collections.IEnumerable
    {
        protected TaskRunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.TaskRunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string taskRunName, Azure.ResourceManager.ContainerRegistry.TaskRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.TaskRunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string taskRunName, Azure.ResourceManager.ContainerRegistry.TaskRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskRunResource> Get(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.TaskRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.TaskRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskRunResource>> GetAsync(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.TaskRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.TaskRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.TaskRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.TaskRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TaskRunData : Azure.ResourceManager.Models.ResourceData
    {
        public TaskRunData() { }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.RunContent RunRequest { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.RunData RunResult { get { throw null; } }
    }
    public partial class TaskRunResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TaskRunResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.TaskRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string taskRunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskRunResource> GetDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.TaskRunResource>> GetDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.TaskRunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.TaskRunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.TaskRunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.TaskRunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebhookCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.WebhookResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.WebhookResource>, System.Collections.IEnumerable
    {
        protected WebhookCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.WebhookResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string webhookName, Azure.ResourceManager.ContainerRegistry.Models.WebhookCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.WebhookResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string webhookName, Azure.ResourceManager.ContainerRegistry.Models.WebhookCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.WebhookResource> Get(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.WebhookResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.WebhookResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.WebhookResource>> GetAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.WebhookResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.WebhookResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.WebhookResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.WebhookResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebhookData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public WebhookData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.WebhookAction> Actions { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.WebhookStatus? Status { get { throw null; } set { } }
    }
    public partial class WebhookResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebhookResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.WebhookData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.WebhookResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.WebhookResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string webhookName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.WebhookResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.WebhookResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.CallbackConfig> GetCallbackConfig(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.CallbackConfig>> GetCallbackConfigAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.Models.Event> GetEvents(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.Models.Event> GetEventsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.EventInfo> Ping(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.EventInfo>> PingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.WebhookResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.WebhookResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.WebhookResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.WebhookResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.WebhookResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.WebhookPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.WebhookResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.WebhookPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerRegistry.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Action : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.Action>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Action(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.Action Allow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.Action other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.Action left, Azure.ResourceManager.ContainerRegistry.Models.Action right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.Action (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.Action left, Azure.ResourceManager.ContainerRegistry.Models.Action right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionsRequired : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ActionsRequired>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionsRequired(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ActionsRequired None { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ActionsRequired Recreate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ActionsRequired other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ActionsRequired left, Azure.ResourceManager.ContainerRegistry.Models.ActionsRequired right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ActionsRequired (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ActionsRequired left, Azure.ResourceManager.ContainerRegistry.Models.ActionsRequired right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentPoolPatch
    {
        public AgentPoolPatch() { }
        public int? Count { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AgentPoolQueueStatus
    {
        internal AgentPoolQueueStatus() { }
        public int? Count { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Architecture : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.Architecture>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Architecture(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.Architecture Amd64 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.Architecture Arm { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.Architecture Arm64 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.Architecture ThreeHundredEightySix { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.Architecture X86 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.Architecture other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.Architecture left, Azure.ResourceManager.ContainerRegistry.Models.Architecture right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.Architecture (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.Architecture left, Azure.ResourceManager.ContainerRegistry.Models.Architecture right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Argument
    {
        public Argument(string name, string value) { }
        public bool? IsSecret { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class AuthInfo
    {
        public AuthInfo(Azure.ResourceManager.ContainerRegistry.Models.TokenType tokenType, string token) { }
        public int? ExpiresIn { get { throw null; } set { } }
        public string RefreshToken { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.TokenType TokenType { get { throw null; } set { } }
    }
    public partial class AuthInfoUpdateParameters
    {
        public AuthInfoUpdateParameters() { }
        public int? ExpiresIn { get { throw null; } set { } }
        public string RefreshToken { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.TokenType? TokenType { get { throw null; } set { } }
    }
    public partial class BaseImageDependency
    {
        internal BaseImageDependency() { }
        public Azure.ResourceManager.ContainerRegistry.Models.BaseImageDependencyType? DependencyType { get { throw null; } }
        public string Digest { get { throw null; } }
        public string Registry { get { throw null; } }
        public string Repository { get { throw null; } }
        public string Tag { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BaseImageDependencyType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.BaseImageDependencyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BaseImageDependencyType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.BaseImageDependencyType BuildTime { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.BaseImageDependencyType RunTime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.BaseImageDependencyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.BaseImageDependencyType left, Azure.ResourceManager.ContainerRegistry.Models.BaseImageDependencyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.BaseImageDependencyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.BaseImageDependencyType left, Azure.ResourceManager.ContainerRegistry.Models.BaseImageDependencyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BaseImageTrigger
    {
        public BaseImageTrigger(Azure.ResourceManager.ContainerRegistry.Models.BaseImageTriggerType baseImageTriggerType, string name) { }
        public Azure.ResourceManager.ContainerRegistry.Models.BaseImageTriggerType BaseImageTriggerType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.TriggerStatus? Status { get { throw null; } set { } }
        public string UpdateTriggerEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.UpdateTriggerPayloadType? UpdateTriggerPayloadType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BaseImageTriggerType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.BaseImageTriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BaseImageTriggerType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.BaseImageTriggerType All { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.BaseImageTriggerType Runtime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.BaseImageTriggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.BaseImageTriggerType left, Azure.ResourceManager.ContainerRegistry.Models.BaseImageTriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.BaseImageTriggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.BaseImageTriggerType left, Azure.ResourceManager.ContainerRegistry.Models.BaseImageTriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BaseImageTriggerUpdateParameters
    {
        public BaseImageTriggerUpdateParameters(string name) { }
        public Azure.ResourceManager.ContainerRegistry.Models.BaseImageTriggerType? BaseImageTriggerType { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.TriggerStatus? Status { get { throw null; } set { } }
        public string UpdateTriggerEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.UpdateTriggerPayloadType? UpdateTriggerPayloadType { get { throw null; } set { } }
    }
    public partial class CallbackConfig
    {
        internal CallbackConfig() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> CustomHeaders { get { throw null; } }
        public System.Uri ServiceUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ConnectionStatus left, Azure.ResourceManager.ContainerRegistry.Models.ConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ConnectionStatus left, Azure.ResourceManager.ContainerRegistry.Models.ConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryPrivateLinkServiceConnectionState
    {
        public ContainerRegistryPrivateLinkServiceConnectionState() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ActionsRequired? ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryResourceType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryResourceType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType MicrosoftContainerRegistryRegistries { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistrySku
    {
        public ContainerRegistrySku(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName name) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier? Tier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistrySkuName : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistrySkuName(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName Classic { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName Premium { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistrySkuTier : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistrySkuTier(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier Classic { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier Premium { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Credentials
    {
        public Credentials() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials> CustomRegistries { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode? SourceRegistryLoginMode { get { throw null; } set { } }
    }
    public partial class CustomRegistryCredentials
    {
        public CustomRegistryCredentials() { }
        public string Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SecretObject Password { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SecretObject UserName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefaultAction : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.DefaultAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefaultAction(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.DefaultAction Allow { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.DefaultAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.DefaultAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.DefaultAction left, Azure.ResourceManager.ContainerRegistry.Models.DefaultAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.DefaultAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.DefaultAction left, Azure.ResourceManager.ContainerRegistry.Models.DefaultAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DockerBuildRequest : Azure.ResourceManager.ContainerRegistry.Models.RunContent
    {
        public DockerBuildRequest(string dockerFilePath, Azure.ResourceManager.ContainerRegistry.Models.PlatformProperties platform) { }
        public int? AgentCpu { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.Argument> Arguments { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.Credentials Credentials { get { throw null; } set { } }
        public string DockerFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ImageNames { get { throw null; } }
        public bool? IsPushEnabled { get { throw null; } set { } }
        public bool? NoCache { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.PlatformProperties Platform { get { throw null; } set { } }
        public string SourceLocation { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class DockerBuildStep : Azure.ResourceManager.ContainerRegistry.Models.TaskStepProperties
    {
        public DockerBuildStep(string dockerFilePath) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.Argument> Arguments { get { throw null; } }
        public string DockerFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ImageNames { get { throw null; } }
        public bool? IsPushEnabled { get { throw null; } set { } }
        public bool? NoCache { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
    }
    public partial class EncodedTaskRunRequest : Azure.ResourceManager.ContainerRegistry.Models.RunContent
    {
        public EncodedTaskRunRequest(string encodedTaskContent, Azure.ResourceManager.ContainerRegistry.Models.PlatformProperties platform) { }
        public int? AgentCpu { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.Credentials Credentials { get { throw null; } set { } }
        public string EncodedTaskContent { get { throw null; } set { } }
        public string EncodedValuesContent { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.PlatformProperties Platform { get { throw null; } set { } }
        public string SourceLocation { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.SetValue> Values { get { throw null; } }
    }
    public partial class EncodedTaskStep : Azure.ResourceManager.ContainerRegistry.Models.TaskStepProperties
    {
        public EncodedTaskStep(string encodedTaskContent) { }
        public string EncodedTaskContent { get { throw null; } set { } }
        public string EncodedValuesContent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.SetValue> Values { get { throw null; } }
    }
    public partial class EncryptionProperty
    {
        public EncryptionProperty() { }
        public Azure.ResourceManager.ContainerRegistry.Models.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.EncryptionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.EncryptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.EncryptionStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.EncryptionStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.EncryptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.EncryptionStatus left, Azure.ResourceManager.ContainerRegistry.Models.EncryptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.EncryptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.EncryptionStatus left, Azure.ResourceManager.ContainerRegistry.Models.EncryptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Event : Azure.ResourceManager.ContainerRegistry.Models.EventInfo
    {
        internal Event() { }
        public Azure.ResourceManager.ContainerRegistry.Models.EventRequestMessage EventRequestMessage { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.EventResponseMessage EventResponseMessage { get { throw null; } }
    }
    public partial class EventContent
    {
        internal EventContent() { }
        public string Action { get { throw null; } }
        public string ActorName { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.Request Request { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.Source Source { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.Target Target { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class EventInfo
    {
        internal EventInfo() { }
        public string Id { get { throw null; } }
    }
    public partial class EventRequestMessage
    {
        internal EventRequestMessage() { }
        public Azure.ResourceManager.ContainerRegistry.Models.EventContent Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Headers { get { throw null; } }
        public string Method { get { throw null; } }
        public System.Uri RequestUri { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class EventResponseMessage
    {
        internal EventResponseMessage() { }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Headers { get { throw null; } }
        public string ReasonPhrase { get { throw null; } }
        public string StatusCode { get { throw null; } }
        public string Version { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExportPolicyStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ExportPolicyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExportPolicyStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ExportPolicyStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ExportPolicyStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ExportPolicyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ExportPolicyStatus left, Azure.ResourceManager.ContainerRegistry.Models.ExportPolicyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ExportPolicyStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ExportPolicyStatus left, Azure.ResourceManager.ContainerRegistry.Models.ExportPolicyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileTaskRunRequest : Azure.ResourceManager.ContainerRegistry.Models.RunContent
    {
        public FileTaskRunRequest(string taskFilePath, Azure.ResourceManager.ContainerRegistry.Models.PlatformProperties platform) { }
        public int? AgentCpu { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.Credentials Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.PlatformProperties Platform { get { throw null; } set { } }
        public string SourceLocation { get { throw null; } set { } }
        public string TaskFilePath { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.SetValue> Values { get { throw null; } }
        public string ValuesFilePath { get { throw null; } set { } }
    }
    public partial class FileTaskStep : Azure.ResourceManager.ContainerRegistry.Models.TaskStepProperties
    {
        public FileTaskStep(string taskFilePath) { }
        public string TaskFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.SetValue> Values { get { throw null; } }
        public string ValuesFilePath { get { throw null; } set { } }
    }
    public partial class IdentityProperties
    {
        public IdentityProperties() { }
        public string PrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ResourceIdentityType? ResourceIdentityType { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    public partial class ImageDescriptor
    {
        public ImageDescriptor() { }
        public string Digest { get { throw null; } set { } }
        public string Registry { get { throw null; } set { } }
        public string Repository { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
    }
    public partial class ImageUpdateTrigger
    {
        public ImageUpdateTrigger() { }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ImageDescriptor> Images { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } set { } }
    }
    public partial class ImportImageContent
    {
        public ImportImageContent(Azure.ResourceManager.ContainerRegistry.Models.ImportSource source) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ImportMode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ImportSource Source { get { throw null; } }
        public System.Collections.Generic.IList<string> TargetTags { get { throw null; } }
        public System.Collections.Generic.IList<string> UntaggedTargetRepositories { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImportMode : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ImportMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImportMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ImportMode Force { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ImportMode NoForce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ImportMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ImportMode left, Azure.ResourceManager.ContainerRegistry.Models.ImportMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ImportMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ImportMode left, Azure.ResourceManager.ContainerRegistry.Models.ImportMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImportSource
    {
        public ImportSource(string sourceImage) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ImportSourceCredentials Credentials { get { throw null; } set { } }
        public System.Uri RegistryUri { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string SourceImage { get { throw null; } }
    }
    public partial class ImportSourceCredentials
    {
        public ImportSourceCredentials(string password) { }
        public string Password { get { throw null; } }
        public string Username { get { throw null; } set { } }
    }
    public partial class IPRule
    {
        public IPRule(string ipAddressOrRange) { }
        public Azure.ResourceManager.ContainerRegistry.Models.Action? Action { get { throw null; } set { } }
        public string IPAddressOrRange { get { throw null; } set { } }
    }
    public partial class KeyVaultProperties
    {
        public KeyVaultProperties() { }
        public string Identity { get { throw null; } set { } }
        public string KeyIdentifier { get { throw null; } set { } }
        public bool? KeyRotationEnabled { get { throw null; } }
        public System.DateTimeOffset? LastKeyRotationTimestamp { get { throw null; } }
        public string VersionedKeyIdentifier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkRuleBypassOption : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.NetworkRuleBypassOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkRuleBypassOption(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.NetworkRuleBypassOption AzureServices { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.NetworkRuleBypassOption None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.NetworkRuleBypassOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.NetworkRuleBypassOption left, Azure.ResourceManager.ContainerRegistry.Models.NetworkRuleBypassOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.NetworkRuleBypassOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.NetworkRuleBypassOption left, Azure.ResourceManager.ContainerRegistry.Models.NetworkRuleBypassOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkRuleSet
    {
        public NetworkRuleSet(Azure.ResourceManager.ContainerRegistry.Models.DefaultAction defaultAction) { }
        public Azure.ResourceManager.ContainerRegistry.Models.DefaultAction DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.IPRule> IPRules { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct O : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.O>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public O(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.O Linux { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.O Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.O other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.O left, Azure.ResourceManager.ContainerRegistry.Models.O right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.O (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.O left, Azure.ResourceManager.ContainerRegistry.Models.O right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OverrideTaskStepProperties
    {
        public OverrideTaskStepProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.Argument> Arguments { get { throw null; } }
        public string ContextPath { get { throw null; } set { } }
        public string File { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public string UpdateTriggerToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.SetValue> Values { get { throw null; } }
    }
    public enum PasswordName
    {
        Password = 0,
        Password2 = 1,
    }
    public partial class PlatformProperties
    {
        public PlatformProperties(Azure.ResourceManager.ContainerRegistry.Models.O os) { }
        public Azure.ResourceManager.ContainerRegistry.Models.Architecture? Architecture { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.O OS { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.Variant? Variant { get { throw null; } set { } }
    }
    public partial class PlatformUpdateParameters
    {
        public PlatformUpdateParameters() { }
        public Azure.ResourceManager.ContainerRegistry.Models.Architecture? Architecture { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.O? OS { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.Variant? Variant { get { throw null; } set { } }
    }
    public partial class Policies
    {
        public Policies() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ExportPolicyStatus? ExportStatus { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.PolicyStatus? QuarantineStatus { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.TrustPolicy TrustPolicy { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.PolicyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.PolicyStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.PolicyStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.PolicyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.PolicyStatus left, Azure.ResourceManager.ContainerRegistry.Models.PolicyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.PolicyStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.PolicyStatus left, Azure.ResourceManager.ContainerRegistry.Models.PolicyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState left, Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState left, Azure.ResourceManager.ContainerRegistry.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.PublicNetworkAccess left, Azure.ResourceManager.ContainerRegistry.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.PublicNetworkAccess left, Azure.ResourceManager.ContainerRegistry.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegenerateCredentialContent
    {
        public RegenerateCredentialContent(Azure.ResourceManager.ContainerRegistry.Models.PasswordName name) { }
        public Azure.ResourceManager.ContainerRegistry.Models.PasswordName Name { get { throw null; } }
    }
    public partial class RegistryListCredentialsResult
    {
        internal RegistryListCredentialsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerRegistry.Models.RegistryPassword> Passwords { get { throw null; } }
        public string Username { get { throw null; } }
    }
    public partial class RegistryNameCheckContent
    {
        public RegistryNameCheckContent(string name) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType ContainerRegistryResourceType { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class RegistryNameStatus
    {
        internal RegistryNameStatus() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class RegistryPassword
    {
        internal RegistryPassword() { }
        public Azure.ResourceManager.ContainerRegistry.Models.PasswordName? Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class RegistryPatch
    {
        public RegistryPatch() { }
        public bool? AdminUserEnabled { get { throw null; } set { } }
        public bool? DataEndpointEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.EncryptionProperty Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.NetworkRuleBypassOption? NetworkRuleBypassOptions { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.NetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.Policies Policies { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class RegistryUsage
    {
        internal RegistryUsage() { }
        public long? CurrentValue { get { throw null; } }
        public long? Limit { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.RegistryUsageUnit? Unit { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegistryUsageUnit : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.RegistryUsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegistryUsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.RegistryUsageUnit Bytes { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.RegistryUsageUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.RegistryUsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.RegistryUsageUnit left, Azure.ResourceManager.ContainerRegistry.Models.RegistryUsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.RegistryUsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.RegistryUsageUnit left, Azure.ResourceManager.ContainerRegistry.Models.RegistryUsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReplicationPatch
    {
        public ReplicationPatch() { }
        public bool? RegionEndpointEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class Request
    {
        internal Request() { }
        public string Addr { get { throw null; } }
        public string Host { get { throw null; } }
        public string Id { get { throw null; } }
        public string Method { get { throw null; } }
        public string Useragent { get { throw null; } }
    }
    public enum ResourceIdentityType
    {
        None = 0,
        SystemAssigned = 1,
        UserAssigned = 2,
        SystemAssignedUserAssigned = 3,
    }
    public partial class RetentionPolicy
    {
        public RetentionPolicy() { }
        public int? Days { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.PolicyStatus? Status { get { throw null; } set { } }
    }
    public partial class RunContent
    {
        public RunContent() { }
        public string AgentPoolName { get { throw null; } set { } }
        public bool? IsArchiveEnabled { get { throw null; } set { } }
        public string LogTemplate { get { throw null; } set { } }
    }
    public partial class RunGetLogResult
    {
        internal RunGetLogResult() { }
        public string LogArtifactLink { get { throw null; } }
        public string LogLink { get { throw null; } }
    }
    public partial class RunPatch
    {
        public RunPatch() { }
        public bool? IsArchiveEnabled { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.RunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.RunStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.RunStatus Error { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.RunStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.RunStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.RunStatus Running { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.RunStatus Started { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.RunStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.RunStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.RunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.RunStatus left, Azure.ResourceManager.ContainerRegistry.Models.RunStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.RunStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.RunStatus left, Azure.ResourceManager.ContainerRegistry.Models.RunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.RunType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.RunType AutoBuild { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.RunType AutoRun { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.RunType QuickBuild { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.RunType QuickRun { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.RunType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.RunType left, Azure.ResourceManager.ContainerRegistry.Models.RunType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.RunType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.RunType left, Azure.ResourceManager.ContainerRegistry.Models.RunType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecretObject
    {
        public SecretObject() { }
        public Azure.ResourceManager.ContainerRegistry.Models.SecretObjectType? ObjectType { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecretObjectType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.SecretObjectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecretObjectType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.SecretObjectType Opaque { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.SecretObjectType Vaultsecret { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.SecretObjectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.SecretObjectType left, Azure.ResourceManager.ContainerRegistry.Models.SecretObjectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.SecretObjectType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.SecretObjectType left, Azure.ResourceManager.ContainerRegistry.Models.SecretObjectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SetValue
    {
        public SetValue(string name, string value) { }
        public bool? IsSecret { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class Source
    {
        internal Source() { }
        public string Addr { get { throw null; } }
        public string InstanceId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceControlType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.SourceControlType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceControlType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.SourceControlType Github { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.SourceControlType VisualStudioTeamService { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.SourceControlType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.SourceControlType left, Azure.ResourceManager.ContainerRegistry.Models.SourceControlType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.SourceControlType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.SourceControlType left, Azure.ResourceManager.ContainerRegistry.Models.SourceControlType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SourceProperties
    {
        public SourceProperties(Azure.ResourceManager.ContainerRegistry.Models.SourceControlType sourceControlType, System.Uri repositoryUri) { }
        public string Branch { get { throw null; } set { } }
        public System.Uri RepositoryUri { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.AuthInfo SourceControlAuthProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceControlType SourceControlType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceRegistryLoginMode : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceRegistryLoginMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode Default { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode left, Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode left, Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SourceTrigger
    {
        public SourceTrigger(Azure.ResourceManager.ContainerRegistry.Models.SourceProperties sourceRepository, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.SourceTriggerEvent> sourceTriggerEvents, string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceProperties SourceRepository { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.SourceTriggerEvent> SourceTriggerEvents { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.TriggerStatus? Status { get { throw null; } set { } }
    }
    public partial class SourceTriggerDescriptor
    {
        public SourceTriggerDescriptor() { }
        public string BranchName { get { throw null; } set { } }
        public string CommitId { get { throw null; } set { } }
        public string EventType { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string ProviderType { get { throw null; } set { } }
        public string PullRequestId { get { throw null; } set { } }
        public System.Uri RepositoryUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceTriggerEvent : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.SourceTriggerEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceTriggerEvent(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.SourceTriggerEvent Commit { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.SourceTriggerEvent Pullrequest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.SourceTriggerEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.SourceTriggerEvent left, Azure.ResourceManager.ContainerRegistry.Models.SourceTriggerEvent right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.SourceTriggerEvent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.SourceTriggerEvent left, Azure.ResourceManager.ContainerRegistry.Models.SourceTriggerEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SourceTriggerUpdateParameters
    {
        public SourceTriggerUpdateParameters(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceUpdateParameters SourceRepository { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.SourceTriggerEvent> SourceTriggerEvents { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.TriggerStatus? Status { get { throw null; } set { } }
    }
    public partial class SourceUpdateParameters
    {
        public SourceUpdateParameters() { }
        public string Branch { get { throw null; } set { } }
        public System.Uri RepositoryUri { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.AuthInfoUpdateParameters SourceControlAuthProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceControlType? SourceControlType { get { throw null; } set { } }
    }
    public partial class SourceUploadDefinition
    {
        internal SourceUploadDefinition() { }
        public string RelativePath { get { throw null; } }
        public System.Uri UploadUri { get { throw null; } }
    }
    public partial class Status
    {
        internal Status() { }
        public string DisplayStatus { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class Target
    {
        internal Target() { }
        public string Digest { get { throw null; } }
        public long? Length { get { throw null; } }
        public string MediaType { get { throw null; } }
        public string Name { get { throw null; } }
        public string Repository { get { throw null; } }
        public long? Size { get { throw null; } }
        public string Tag { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class TaskPatch
    {
        public TaskPatch() { }
        public int? AgentCpu { get { throw null; } set { } }
        public string AgentPoolName { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.Credentials Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties Identity { get { throw null; } set { } }
        public string LogTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.PlatformUpdateParameters Platform { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.TaskStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.TaskStepUpdateParameters Step { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public int? Timeout { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.TriggerUpdateParameters Trigger { get { throw null; } set { } }
    }
    public partial class TaskRunPatch
    {
        public TaskRunPatch() { }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.IdentityProperties Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.RunContent RunRequest { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class TaskRunRequest : Azure.ResourceManager.ContainerRegistry.Models.RunContent
    {
        public TaskRunRequest(string taskId) { }
        public Azure.ResourceManager.ContainerRegistry.Models.OverrideTaskStepProperties OverrideTaskStepProperties { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TaskStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.TaskStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TaskStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.TaskStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.TaskStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.TaskStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.TaskStatus left, Azure.ResourceManager.ContainerRegistry.Models.TaskStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.TaskStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.TaskStatus left, Azure.ResourceManager.ContainerRegistry.Models.TaskStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TaskStepProperties
    {
        public TaskStepProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerRegistry.Models.BaseImageDependency> BaseImageDependencies { get { throw null; } }
        public string ContextAccessToken { get { throw null; } set { } }
        public string ContextPath { get { throw null; } set { } }
    }
    public partial class TaskStepUpdateParameters
    {
        public TaskStepUpdateParameters() { }
        public string ContextAccessToken { get { throw null; } set { } }
        public string ContextPath { get { throw null; } set { } }
    }
    public partial class TimerTrigger
    {
        public TimerTrigger(string schedule, string name) { }
        public string Name { get { throw null; } set { } }
        public string Schedule { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.TriggerStatus? Status { get { throw null; } set { } }
    }
    public partial class TimerTriggerDescriptor
    {
        public TimerTriggerDescriptor() { }
        public string ScheduleOccurrence { get { throw null; } set { } }
        public string TimerTriggerName { get { throw null; } set { } }
    }
    public partial class TimerTriggerUpdateParameters
    {
        public TimerTriggerUpdateParameters(string name) { }
        public string Name { get { throw null; } }
        public string Schedule { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.TriggerStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TokenType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.TokenType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TokenType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.TokenType OAuth { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.TokenType PAT { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.TokenType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.TokenType left, Azure.ResourceManager.ContainerRegistry.Models.TokenType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.TokenType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.TokenType left, Azure.ResourceManager.ContainerRegistry.Models.TokenType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TriggerProperties
    {
        public TriggerProperties() { }
        public Azure.ResourceManager.ContainerRegistry.Models.BaseImageTrigger BaseImageTrigger { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.SourceTrigger> SourceTriggers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.TimerTrigger> TimerTriggers { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TriggerStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.TriggerStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TriggerStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.TriggerStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.TriggerStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.TriggerStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.TriggerStatus left, Azure.ResourceManager.ContainerRegistry.Models.TriggerStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.TriggerStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.TriggerStatus left, Azure.ResourceManager.ContainerRegistry.Models.TriggerStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TriggerUpdateParameters
    {
        public TriggerUpdateParameters() { }
        public Azure.ResourceManager.ContainerRegistry.Models.BaseImageTriggerUpdateParameters BaseImageTrigger { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.SourceTriggerUpdateParameters> SourceTriggers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.TimerTriggerUpdateParameters> TimerTriggers { get { throw null; } }
    }
    public partial class TrustPolicy
    {
        public TrustPolicy() { }
        public Azure.ResourceManager.ContainerRegistry.Models.TrustPolicyType? PolicyType { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.PolicyStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrustPolicyType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.TrustPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrustPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.TrustPolicyType Notary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.TrustPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.TrustPolicyType left, Azure.ResourceManager.ContainerRegistry.Models.TrustPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.TrustPolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.TrustPolicyType left, Azure.ResourceManager.ContainerRegistry.Models.TrustPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateTriggerPayloadType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.UpdateTriggerPayloadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateTriggerPayloadType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.UpdateTriggerPayloadType Default { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.UpdateTriggerPayloadType Token { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.UpdateTriggerPayloadType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.UpdateTriggerPayloadType left, Azure.ResourceManager.ContainerRegistry.Models.UpdateTriggerPayloadType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.UpdateTriggerPayloadType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.UpdateTriggerPayloadType left, Azure.ResourceManager.ContainerRegistry.Models.UpdateTriggerPayloadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Variant : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.Variant>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Variant(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.Variant V6 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.Variant V7 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.Variant V8 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.Variant other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.Variant left, Azure.ResourceManager.ContainerRegistry.Models.Variant right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.Variant (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.Variant left, Azure.ResourceManager.ContainerRegistry.Models.Variant right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebhookAction : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.WebhookAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebhookAction(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.WebhookAction ChartDelete { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.WebhookAction ChartPush { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.WebhookAction Delete { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.WebhookAction Push { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.WebhookAction Quarantine { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.WebhookAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.WebhookAction left, Azure.ResourceManager.ContainerRegistry.Models.WebhookAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.WebhookAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.WebhookAction left, Azure.ResourceManager.ContainerRegistry.Models.WebhookAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebhookCreateOrUpdateContent
    {
        public WebhookCreateOrUpdateContent(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.WebhookAction> Actions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CustomHeaders { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        public System.Uri ServiceUri { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.WebhookStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class WebhookPatch
    {
        public WebhookPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.WebhookAction> Actions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CustomHeaders { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        public System.Uri ServiceUri { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.WebhookStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebhookStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.WebhookStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebhookStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.WebhookStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.WebhookStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.WebhookStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.WebhookStatus left, Azure.ResourceManager.ContainerRegistry.Models.WebhookStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.WebhookStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.WebhookStatus left, Azure.ResourceManager.ContainerRegistry.Models.WebhookStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZoneRedundancy : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ZoneRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZoneRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ZoneRedundancy Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ZoneRedundancy Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ZoneRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ZoneRedundancy left, Azure.ResourceManager.ContainerRegistry.Models.ZoneRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ZoneRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ZoneRedundancy left, Azure.ResourceManager.ContainerRegistry.Models.ZoneRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
}
