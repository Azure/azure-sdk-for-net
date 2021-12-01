namespace Azure.ResourceManager.WebPubSub
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.WebPubSub.PrivateEndpointConnection GetPrivateEndpointConnection(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WebPubSub.SharedPrivateLink GetSharedPrivateLink(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSub GetWebPubSub(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubHub GetWebPubSubHub(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
    }
    public partial class PrivateEndpointConnection : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected PrivateEndpointConnection() { }
        public virtual Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateEndpointConnectionDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateEndpointConnectionDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateEndpointConnectionUpdateOperation CreateOrUpdate(string privateEndpointConnectionName, Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.WebPubSubPrivateEndpointConnectionUpdateOperation> CreateOrUpdateAsync(string privateEndpointConnectionName, Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionData : Azure.ResourceManager.Models.Resource
    {
        public PrivateEndpointConnectionData() { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.PrivateEndpoint PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.ResourceManager.WebPubSub.WebPubSubCollection GetWebPubSubs(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public partial class SharedPrivateLink : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected SharedPrivateLink() { }
        public virtual Azure.ResourceManager.WebPubSub.SharedPrivateLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLink> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLink>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedPrivateLinkCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.SharedPrivateLink>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.SharedPrivateLink>, System.Collections.IEnumerable
    {
        protected SharedPrivateLinkCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string sharedPrivateLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string sharedPrivateLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkCreateOrUpdateOperation CreateOrUpdate(string sharedPrivateLinkName, Azure.ResourceManager.WebPubSub.SharedPrivateLinkData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkCreateOrUpdateOperation> CreateOrUpdateAsync(string sharedPrivateLinkName, Azure.ResourceManager.WebPubSub.SharedPrivateLinkData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLink> Get(string sharedPrivateLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.SharedPrivateLink> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.SharedPrivateLink> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLink>> GetAsync(string sharedPrivateLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLink> GetIfExists(string sharedPrivateLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLink>> GetIfExistsAsync(string sharedPrivateLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WebPubSub.SharedPrivateLink> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.SharedPrivateLink>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WebPubSub.SharedPrivateLink> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.SharedPrivateLink>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SharedPrivateLinkData : Azure.ResourceManager.Models.Resource
    {
        public SharedPrivateLinkData() { }
        public string GroupId { get { throw null; } set { } }
        public string PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string RequestMessage { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Response<Azure.ResourceManager.WebPubSub.Models.NameAvailability> CheckNameAvailabilityWebPubSub(this Azure.ResourceManager.Resources.Subscription subscription, string location, Azure.ResourceManager.WebPubSub.Models.NameAvailabilityParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.Models.NameAvailability>> CheckNameAvailabilityWebPubSubAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, Azure.ResourceManager.WebPubSub.Models.NameAvailabilityParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage> GetUsages(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.Models.SignalRServiceUsage> GetUsagesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetWebPubSubByName(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetWebPubSubByNameAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WebPubSub.WebPubSub> GetWebPubSubs(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.WebPubSub> GetWebPubSubsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSub : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected WebPubSub() { }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSub> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSub>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.WebPubSubDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSub> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSub>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public Azure.ResourceManager.WebPubSub.SharedPrivateLinkCollection GetSharedPrivateLinks() { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WebPubSub.Models.Sku>> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WebPubSub.Models.Sku>>> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.WebPubSub.WebPubSubHubCollection GetWebPubSubHubs() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.Models.PrivateLink> GetWebPubSubPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.Models.PrivateLink> GetWebPubSubPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubRegenerateKeyOperation RegenerateKey(Azure.ResourceManager.WebPubSub.Models.RegenerateKeyParameters parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.WebPubSubRegenerateKeyOperation> RegenerateKeyAsync(Azure.ResourceManager.WebPubSub.Models.RegenerateKeyParameters parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSub> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSub>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubRestartOperation Restart(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.WebPubSubRestartOperation> RestartAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSub> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSub>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubUpdateOperation Update(Azure.ResourceManager.WebPubSub.WebPubSubData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.WebPubSubUpdateOperation> UpdateAsync(Azure.ResourceManager.WebPubSub.WebPubSubData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSub>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSub>, System.Collections.IEnumerable
    {
        protected WebPubSubCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubCreateOrUpdateOperation CreateOrUpdate(string resourceName, Azure.ResourceManager.WebPubSub.WebPubSubData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.WebPubSubCreateOrUpdateOperation> CreateOrUpdateAsync(string resourceName, Azure.ResourceManager.WebPubSub.WebPubSubData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSub> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.WebPubSub> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.WebPubSub> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSub>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSub> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSub>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WebPubSub.WebPubSub> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSub>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WebPubSub.WebPubSub> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSub>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebPubSubData : Azure.ResourceManager.Models.TrackedResource
    {
        public WebPubSubData(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
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
        public Azure.ResourceManager.WebPubSub.Models.ResourceLogConfiguration ResourceLogConfiguration { get { throw null; } set { } }
        public int? ServerPort { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WebPubSub.SharedPrivateLinkData> SharedPrivateLinkResources { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubTlsSettings Tls { get { throw null; } set { } }
        public string Version { get { throw null; } }
    }
    public partial class WebPubSubHub : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected WebPubSubHub() { }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubHubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubHubDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.WebPubSubHubDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHub> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHub>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubHubCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubHub>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubHub>, System.Collections.IEnumerable
    {
        protected WebPubSubHubCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubHubCreateOrUpdateOperation CreateOrUpdate(string hubName, Azure.ResourceManager.WebPubSub.WebPubSubHubData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.WebPubSubHubCreateOrUpdateOperation> CreateOrUpdateAsync(string hubName, Azure.ResourceManager.WebPubSub.WebPubSubHubData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHub> Get(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.WebPubSubHub> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.WebPubSubHub> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHub>> GetAsync(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHub> GetIfExists(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHub>> GetIfExistsAsync(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubHub> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubHub>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WebPubSub.WebPubSubHub> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WebPubSub.WebPubSubHub>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebPubSubHubData : Azure.ResourceManager.Models.Resource
    {
        public WebPubSubHubData(Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties properties) { }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.CreatedByType left, Azure.ResourceManager.WebPubSub.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.CreatedByType left, Azure.ResourceManager.WebPubSub.Models.CreatedByType right) { throw null; }
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
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.ManagedIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    public partial class ManagedIdentitySettings
    {
        public ManagedIdentitySettings() { }
        public string Resource { get { throw null; } set { } }
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
    public partial class NameAvailabilityParameters
    {
        public NameAvailabilityParameters(string type, string name) { }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class NetworkAcl
    {
        public NetworkAcl() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType> Allow { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType> Deny { get { throw null; } }
    }
    public partial class PrivateEndpoint
    {
        public PrivateEndpoint() { }
        public string Id { get { throw null; } set { } }
    }
    public partial class PrivateEndpointAcl : Azure.ResourceManager.WebPubSub.Models.NetworkAcl
    {
        public PrivateEndpointAcl(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class PrivateLink : Azure.ResourceManager.Models.Resource
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
    public partial class RegenerateKeyParameters
    {
        public RegenerateKeyParameters() { }
        public Azure.ResourceManager.WebPubSub.Models.KeyType? KeyType { get { throw null; } set { } }
    }
    public partial class ResourceLogCategory
    {
        public ResourceLogCategory() { }
        public string Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ResourceLogConfiguration
    {
        public ResourceLogConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.ResourceLogCategory> Categories { get { throw null; } }
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
        public string Type { get { throw null; } set { } }
    }
    public partial class ShareablePrivateLinkType
    {
        public ShareablePrivateLinkType() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkProperties Properties { get { throw null; } set { } }
    }
    public partial class SharedPrivateLinkCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.WebPubSub.SharedPrivateLink>
    {
        protected SharedPrivateLinkCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.WebPubSub.SharedPrivateLink Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLink>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLink>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedPrivateLinkDeleteOperation : Azure.Operation
    {
        protected SharedPrivateLinkDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class Sku
    {
        internal Sku() { }
        public Azure.ResourceManager.WebPubSub.Models.SkuCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubSku SkuValue { get { throw null; } }
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
    public partial class SkuList
    {
        internal SkuList() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WebPubSub.Models.Sku> Value { get { throw null; } }
    }
    public partial class UpstreamAuthSettings
    {
        public UpstreamAuthSettings() { }
        public Azure.ResourceManager.WebPubSub.Models.ManagedIdentitySettings ManagedIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.UpstreamAuthType? Type { get { throw null; } set { } }
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
    public partial class WebPubSubCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.WebPubSub.WebPubSub>
    {
        protected WebPubSubCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.WebPubSub.WebPubSub Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSub>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSub>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubDeleteOperation : Azure.Operation
    {
        protected WebPubSubDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubHubCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.WebPubSub.WebPubSubHub>
    {
        protected WebPubSubHubCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.WebPubSub.WebPubSubHub Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHub>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHub>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubHubDeleteOperation : Azure.Operation
    {
        protected WebPubSubHubDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class WebPubSubPrivateEndpointConnectionDeleteOperation : Azure.Operation
    {
        protected WebPubSubPrivateEndpointConnectionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubPrivateEndpointConnectionUpdateOperation : Azure.Operation<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection>
    {
        protected WebPubSubPrivateEndpointConnectionUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.WebPubSub.PrivateEndpointConnection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubRegenerateKeyOperation : Azure.Operation<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys>
    {
        protected WebPubSubRegenerateKeyOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class WebPubSubRestartOperation : Azure.Operation
    {
        protected WebPubSubRestartOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class WebPubSubTlsSettings
    {
        public WebPubSubTlsSettings() { }
        public bool? ClientCertEnabled { get { throw null; } set { } }
    }
    public partial class WebPubSubUpdateOperation : Azure.Operation<Azure.ResourceManager.WebPubSub.WebPubSub>
    {
        protected WebPubSubUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.WebPubSub.WebPubSub Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSub>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSub>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
