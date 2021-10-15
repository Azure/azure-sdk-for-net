namespace Azure.ResourceManager.WebPubSub
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.WebPubSub.EventHandler GetEventHandler(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WebPubSub.PrivateEndpointConnection GetPrivateEndpointConnection(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource GetSharedPrivateLinkResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubHub GetWebPubSubHub(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WebPubSub.WebPubSubResource GetWebPubSubResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
    }
    public partial class EventHandler : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected EventHandler() { }
        public virtual Azure.ResourceManager.WebPubSub.EventHandlerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public Azure.ResourceManager.Core.ArmResource Parent { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandlerCreateOrUpdateOperation CreateOrUpdate(Azure.ResourceManager.WebPubSub.Models.EventHandlerProperties properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandlerCreateOrUpdateOperation> CreateOrUpdateAsync(Azure.ResourceManager.WebPubSub.Models.EventHandlerProperties properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandlerDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.WebPubSubEventHandlerDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.EventHandler> Get(string eventHandlerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.EventHandler>> GetAsync(string eventHandlerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventHandlerData : Azure.ResourceManager.Models.Resource
    {
        public EventHandlerData(Azure.ResourceManager.WebPubSub.Models.EventHandlerProperties properties) { }
        public Azure.ResourceManager.WebPubSub.Models.EventHandlerProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
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
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection> Update(Azure.ResourceManager.WebPubSub.Models.PrivateEndpoint privateEndpoint = null, Azure.ResourceManager.WebPubSub.Models.PrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection>> UpdateAsync(Azure.ResourceManager.WebPubSub.Models.PrivateEndpoint privateEndpoint = null, Azure.ResourceManager.WebPubSub.Models.PrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionContainer : Azure.ResourceManager.Core.ArmContainer
    {
        protected PrivateEndpointConnectionContainer() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.PrivateEndpointConnection>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.WebPubSub.WebPubSubResourceContainer GetWebPubSubResources(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public partial class SharedPrivateLinkResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected SharedPrivateLinkResource() { }
        public virtual Azure.ResourceManager.WebPubSub.SharedPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkResourceDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkResourceDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedPrivateLinkResourceContainer : Azure.ResourceManager.Core.ArmContainer
    {
        protected SharedPrivateLinkResourceContainer() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkResourceCreateOrUpdateOperation CreateOrUpdate(string sharedPrivateLinkResourceName, Azure.ResourceManager.WebPubSub.SharedPrivateLinkResourceData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.WebPubSubSharedPrivateLinkResourceCreateOrUpdateOperation> CreateOrUpdateAsync(string sharedPrivateLinkResourceName, Azure.ResourceManager.WebPubSub.SharedPrivateLinkResourceData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource> Get(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource>> GetAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource> GetIfExists(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource>> GetIfExistsAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedPrivateLinkResourceData : Azure.ResourceManager.Models.Resource
    {
        public SharedPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } set { } }
        public string PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string RequestMessage { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkResourceStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetWebPubSubResourceByName(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetWebPubSubResourceByNameAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetWebPubSubResources(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetWebPubSubResourcesAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubHub : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected WebPubSubHub() { }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubHubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public Azure.ResourceManager.Core.ArmResource Parent { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubHubCreateOrUpdateOperation CreateOrUpdate(Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.WebPubSubHubCreateOrUpdateOperation> CreateOrUpdateAsync(Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubHubDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.WebPubSubHubDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHub> Get(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubHub>> GetAsync(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.WebPubSub.EventHandler GetEventHandler() { throw null; }
    }
    public partial class WebPubSubHubData : Azure.ResourceManager.Models.Resource
    {
        public WebPubSubHubData(Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties properties) { }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class WebPubSubResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected WebPubSubResource() { }
        public virtual Azure.ResourceManager.WebPubSub.WebPubSubResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.Models.NameAvailability> CheckNameAvailability(string type, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.Models.NameAvailability>> CheckNameAvailabilityAsync(string type, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.WebPubSubDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.Models.WebPubSubKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionContainer GetPrivateEndpointConnections() { throw null; }
        public Azure.ResourceManager.WebPubSub.SharedPrivateLinkResourceContainer GetSharedPrivateLinkResources() { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WebPubSub.Models.Sku>> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WebPubSub.Models.Sku>>> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.Models.PrivateLinkResource> GetWebPubSubPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.Models.PrivateLinkResource> GetWebPubSubPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubRegenerateKeyOperation RegenerateKey(Azure.ResourceManager.WebPubSub.Models.KeyType? keyType = default(Azure.ResourceManager.WebPubSub.Models.KeyType?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.WebPubSubRegenerateKeyOperation> RegenerateKeyAsync(Azure.ResourceManager.WebPubSub.Models.KeyType? keyType = default(Azure.ResourceManager.WebPubSub.Models.KeyType?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubRestartOperation Restart(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.WebPubSubRestartOperation> RestartAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubUpdateOperation Update(Azure.ResourceManager.WebPubSub.WebPubSubResourceData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.WebPubSubUpdateOperation> UpdateAsync(Azure.ResourceManager.WebPubSub.WebPubSubResourceData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubResourceContainer : Azure.ResourceManager.Core.ArmContainer
    {
        protected WebPubSubResourceContainer() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WebPubSub.Models.WebPubSubCreateOrUpdateOperation CreateOrUpdate(string resourceName, Azure.ResourceManager.WebPubSub.WebPubSubResourceData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.WebPubSub.Models.WebPubSubCreateOrUpdateOperation> CreateOrUpdateAsync(string resourceName, Azure.ResourceManager.WebPubSub.WebPubSubResourceData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubResourceData : Azure.ResourceManager.Models.TrackedResource
    {
        public WebPubSubResourceData(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public bool? DisableAadAuth { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public string ExternalIP { get { throw null; } }
        public string HostName { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.ManagedIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.LiveTraceConfiguration LiveTraceConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubNetworkACLs NetworkACLs { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WebPubSub.PrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public int? PublicPort { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.ResourceLogConfiguration ResourceLogConfiguration { get { throw null; } set { } }
        public int? ServerPort { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResourceData> SharedPrivateLinkResources { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.ResourceSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubTlsSettings Tls { get { throw null; } set { } }
        public string Version { get { throw null; } }
    }
}
namespace Azure.ResourceManager.WebPubSub.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ACLAction : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.ACLAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ACLAction(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.ACLAction Allow { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.ACLAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.ACLAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.ACLAction left, Azure.ResourceManager.WebPubSub.Models.ACLAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.ACLAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.ACLAction left, Azure.ResourceManager.WebPubSub.Models.ACLAction right) { throw null; }
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
    public partial class EventHandlerProperties
    {
        public EventHandlerProperties(string urlTemplate) { }
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
    public partial class NetworkACL
    {
        public NetworkACL() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType> Allow { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.WebPubSubRequestType> Deny { get { throw null; } }
    }
    public partial class PrivateEndpoint
    {
        public PrivateEndpoint() { }
        public string Id { get { throw null; } set { } }
    }
    public partial class PrivateEndpointACL : Azure.ResourceManager.WebPubSub.Models.NetworkACL
    {
        public PrivateEndpointACL(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.Models.Resource
    {
        public PrivateLinkResource() { }
        public string GroupId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkResourceType> ShareablePrivateLinkResourceTypes { get { throw null; } }
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
    public partial class ResourceSku
    {
        public ResourceSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.WebPubSubSkuTier? Tier { get { throw null; } set { } }
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
    public partial class ShareablePrivateLinkResourceProperties
    {
        public ShareablePrivateLinkResourceProperties() { }
        public string Description { get { throw null; } set { } }
        public string GroupId { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
    }
    public partial class ShareablePrivateLinkResourceType
    {
        public ShareablePrivateLinkResourceType() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.WebPubSub.Models.ShareablePrivateLinkResourceProperties Properties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SharedPrivateLinkResourceStatus : System.IEquatable<Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkResourceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SharedPrivateLinkResourceStatus(string value) { throw null; }
        public static Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkResourceStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkResourceStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkResourceStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkResourceStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkResourceStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkResourceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkResourceStatus left, Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkResourceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkResourceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkResourceStatus left, Azure.ResourceManager.WebPubSub.Models.SharedPrivateLinkResourceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SignalRServiceUsage : Azure.ResourceManager.Resources.Models.SubResource
    {
        internal SignalRServiceUsage() { }
        public long? CurrentValue { get { throw null; } }
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
        public Azure.ResourceManager.WebPubSub.Models.ResourceSku SkuValue { get { throw null; } }
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
    public partial class WebPubSubCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.WebPubSub.WebPubSubResource>
    {
        protected WebPubSubCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.WebPubSub.WebPubSubResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class WebPubSubEventHandlerCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.WebPubSub.EventHandler>
    {
        protected WebPubSubEventHandlerCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.WebPubSub.EventHandler Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.WebPubSub.EventHandler>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.WebPubSub.EventHandler>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubEventHandlerDeleteOperation : Azure.Operation
    {
        protected WebPubSubEventHandlerDeleteOperation() { }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.EventHandlerData> EventHandlers { get { throw null; } }
    }
    public partial class WebPubSubKeys
    {
        internal WebPubSubKeys() { }
        public string PrimaryConnectionString { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryConnectionString { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    public partial class WebPubSubNetworkACLs
    {
        public WebPubSubNetworkACLs() { }
        public Azure.ResourceManager.WebPubSub.Models.ACLAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WebPubSub.Models.PrivateEndpointACL> PrivateEndpoints { get { throw null; } }
        public Azure.ResourceManager.WebPubSub.Models.NetworkACL PublicNetwork { get { throw null; } set { } }
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
    public partial class WebPubSubSharedPrivateLinkResourceCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource>
    {
        protected WebPubSubSharedPrivateLinkResourceCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.WebPubSub.SharedPrivateLinkResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubSharedPrivateLinkResourceDeleteOperation : Azure.Operation
    {
        protected WebPubSubSharedPrivateLinkResourceDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class WebPubSubUpdateOperation : Azure.Operation<Azure.ResourceManager.WebPubSub.WebPubSubResource>
    {
        protected WebPubSubUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.WebPubSub.WebPubSubResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.WebPubSub.WebPubSubResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
