namespace Azure.ResourceManager.WebPubSub
{
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public PrivateEndpointConnectionData() { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public string PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedPrivateLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected SharedPrivateLinkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sharedPrivateLinkResourceName, Azure.ResourceManager.WebPubSub.SharedPrivateLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sharedPrivateLinkResourceName, Azure.ResourceManager.WebPubSub.SharedPrivateLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource> Get(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource>> GetAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SharedPrivateLinkData : Azure.ResourceManager.Models.ResourceData
    {
        public SharedPrivateLinkData() { }
        public string GroupId { get { throw null; } set { } }
        public string PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string RequestMessage { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkStatus? Status { get { throw null; } }
    }
    public partial class SharedPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SharedPrivateLinkResource() { }
        public virtual Azure.ResourceManager.WebPubSub.SharedPrivateLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string sharedPrivateLinkResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubResource>, System.Collections.IEnumerable
    {
        protected WebPubSubCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.WebPubSub.WebPubSubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.WebPubSub.WebPubSubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebPubSubData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public WebPubSubData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? ClientCertEnabled { get { throw null; } set { } }
        public bool? DisableAadAuth { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public string ExternalIP { get { throw null; } }
        public string HostName { get { throw null; } }
        public string HostNamePrefix { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.ManagedIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration LiveTraceConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkAcls NetworkAcls { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public int? PublicPort { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory> ResourceLogCategories { get { throw null; } }
        public int? ServerPort { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WebPubSub.SharedPrivateLinkData> SharedPrivateLinkResources { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubSku Sku { get { throw null; } set { } }
        public string Version { get { throw null; } }
    }
    public static partial class WebPubSubExtensions
    {
        public static Azure.Response<Azure.ResourceManager.WebPubSub.Models.NameAvailability> CheckWebPubSubNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.WebPubSub.Models.NameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.Models.NameAvailability>> CheckWebPubSubNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.WebPubSub.Models.NameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource GetSharedPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage> GetUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage> GetUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetWebPubSub(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> GetWebPubSubAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubHubResource GetWebPubSubHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubResource GetWebPubSubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubCollection GetWebPubSubs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetWebPubSubs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetWebPubSubsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubHubCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubHubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubHubResource>, System.Collections.IEnumerable
    {
        protected WebPubSubHubCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubHubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hubName, Azure.ResourceManager.WebPubSub.WebPubSubHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubHubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hubName, Azure.ResourceManager.WebPubSub.WebPubSubHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHubResource> Get(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.WebPubSubHubResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.WebPubSubHubResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHubResource>> GetAsync(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubHubResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubHubResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubHubResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubHubResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebPubSubHubData : Azure.ResourceManager.Models.ResourceData
    {
        public WebPubSubHubData(Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties properties) { }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties Properties { get { throw null; } set { } }
    }
    public partial class WebPubSubHubResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebPubSubHubResource() { }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubHubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string hubName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebPubSubResource() { }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource> GetPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionResource>> GetPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource> GetSharedPrivateLink(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource>> GetSharedPrivateLinkAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.SharedPrivateLinkCollection GetSharedPrivateLinks() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.Models.WebPubSubResourceSku> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.Models.WebPubSubResourceSku> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHubResource> GetWebPubSubHub(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHubResource>> GetWebPubSubHubAsync(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubHubCollection GetWebPubSubHubs() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.Models.PrivateLink> GetWebPubSubPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.Models.PrivateLink> GetWebPubSubPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys> RegenerateKey(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.Models.RegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys>> RegenerateKeyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.Models.RegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.WebPubSubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WebPubSub.WebPubSubResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WebPubSub.WebPubSubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.WebPubSub.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AclAction : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.AclAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AclAction(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.AclAction Allow { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.AclAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.AclAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.AclAction left, Azure.ResourceManager.WebPubSub.Models.AclAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.AclAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.AclAction left, Azure.ResourceManager.WebPubSub.Models.AclAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventHandler
    {
        public EventHandler(string urlTemplate) { }
        public Azure.ResourceManager.WebPubSub.Models.UpstreamAuthSettings Auth { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SystemEvents { get { throw null; } }
        public string UrlTemplate { get { throw null; } set { } }
        public string UserEventPattern { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyType : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.KeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyType(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.KeyType Primary { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.KeyType Salt { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.KeyType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.KeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.KeyType left, Azure.ResourceManager.WebPubSub.Models.KeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.KeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.KeyType left, Azure.ResourceManager.WebPubSub.Models.KeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LiveTraceCategory
    {
        public LiveTraceCategory() { }
        public string Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class LiveTraceConfiguration
    {
        public LiveTraceConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.LiveTraceCategory> Categories { get { throw null; } }
        public string Enabled { get { throw null; } set { } }
    }
    public partial class ManagedIdentity
    {
        public ManagedIdentity() { }
        public Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType? IdentityType { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedIdentityType : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType left, Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType left, Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NameAvailability
    {
        internal NameAvailability() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class NameAvailabilityContent
    {
        public NameAvailabilityContent(string resourceType, string name) { }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class NetworkAcl
    {
        public NetworkAcl() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType> Allow { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType> Deny { get { throw null; } }
    }
    public partial class PrivateEndpointAcl : Azure.ResourceManager.WebPubSub.Models.NetworkAcl
    {
        public PrivateEndpointAcl(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class PrivateLink : Azure.ResourceManager.Models.ResourceData
    {
        public PrivateLink() { }
        public string GroupId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkType> ShareablePrivateLinkTypes { get { throw null; } }
    }
    public partial class PrivateLinkServiceConnectionState
    {
        public PrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.PrivateLinkServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.PrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.PrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.PrivateLinkServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.PrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.PrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.PrivateLinkServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.PrivateLinkServiceConnectionStatus left, Azure.ResourceManager.WebPubSub.Models.PrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.PrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.PrivateLinkServiceConnectionStatus left, Azure.ResourceManager.WebPubSub.Models.PrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.ProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.ProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.ProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.ProvisioningState left, Azure.ResourceManager.WebPubSub.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.ProvisioningState left, Azure.ResourceManager.WebPubSub.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegenerateKeyContent
    {
        public RegenerateKeyContent() { }
        public Azure.ResourceManager.WebPubSub.Models.KeyType? KeyType { get { throw null; } set { } }
    }
    public partial class ResourceLogCategory
    {
        public ResourceLogCategory() { }
        public string Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScaleType : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.ScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScaleType(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.ScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.ScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.ScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.ScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.ScaleType left, Azure.ResourceManager.WebPubSub.Models.ScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.ScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.ScaleType left, Azure.ResourceManager.WebPubSub.Models.ScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ShareablePrivateLinkProperties
    {
        public ShareablePrivateLinkProperties() { }
        public string Description { get { throw null; } set { } }
        public string GroupId { get { throw null; } set { } }
        public string ShareablePrivateLinkPropertiesType { get { throw null; } set { } }
    }
    public partial class ShareablePrivateLinkType
    {
        public ShareablePrivateLinkType() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties Properties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SharedPrivateLinkStatus : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SharedPrivateLinkStatus(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkStatus left, Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkStatus left, Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SignalRServiceUsage
    {
        internal SignalRServiceUsage() { }
        public long? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsageName Name { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class SignalRServiceUsageName
    {
        internal SignalRServiceUsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class SkuCapacity
    {
        internal SkuCapacity() { }
        public System.Collections.Generic.IReadOnlyList<int> AllowedValues { get { throw null; } }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.ScaleType? ScaleType { get { throw null; } }
    }
    public partial class UpstreamAuthSettings
    {
        public UpstreamAuthSettings() { }
        public Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType? AuthType { get { throw null; } set { } }
        public string ManagedIdentityResource { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpstreamAuthType : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpstreamAuthType(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType left, Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType left, Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebPubSubHubProperties
    {
        public WebPubSubHubProperties() { }
        public string AnonymousConnectPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.EventHandler> EventHandlers { get { throw null; } }
    }
    public partial class WebPubSubKeys
    {
        internal WebPubSubKeys() { }
        public string PrimaryConnectionString { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryConnectionString { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    public partial class WebPubSubNetworkAcls
    {
        public WebPubSubNetworkAcls() { }
        public Azure.ResourceManager.WebPubSub.Models.AclAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.PrivateEndpointAcl> PrivateEndpoints { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.NetworkAcl PublicNetwork { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebPubSubRequestType : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebPubSubRequestType(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType ClientConnection { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType Restapi { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType ServerConnection { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType Trace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType left, Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType left, Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebPubSubResourceSku
    {
        internal WebPubSubResourceSku() { }
        public Azure.ResourceManager.WebPubSub.Models.SkuCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubSku Sku { get { throw null; } }
    }
    public partial class WebPubSubSku
    {
        public WebPubSubSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier? Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebPubSubSkuTier : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebPubSubSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier Free { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier Premium { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier left, Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier left, Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
}
