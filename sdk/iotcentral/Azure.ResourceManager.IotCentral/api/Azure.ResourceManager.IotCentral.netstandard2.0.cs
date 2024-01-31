namespace Azure.ResourceManager.IotCentral
{
    public partial class IotCentralAppCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotCentral.IotCentralAppResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotCentral.IotCentralAppResource>, System.Collections.IEnumerable
    {
        protected IotCentralAppCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotCentral.IotCentralAppResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.IotCentral.IotCentralAppData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotCentral.IotCentralAppResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.IotCentral.IotCentralAppData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotCentral.IotCentralAppResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotCentral.IotCentralAppResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotCentral.IotCentralAppResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotCentral.IotCentralAppResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotCentral.IotCentralAppResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotCentral.IotCentralAppResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotCentral.IotCentralAppResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotCentral.IotCentralAppResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotCentralAppData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.IotCentralAppData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.IotCentralAppData>
    {
        public IotCentralAppData(Azure.Core.AzureLocation location, Azure.ResourceManager.IotCentral.Models.IotCentralAppSkuInfo sku) { }
        public System.Guid? ApplicationId { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSets NetworkRuleSets { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.IotCentral.Models.IotCentralProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IotCentral.Models.IotCentralPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.IotCentral.Models.IotCentralAppSku? SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.IotCentral.Models.IotCentralAppState? State { get { throw null; } }
        public string Subdomain { get { throw null; } set { } }
        public string Template { get { throw null; } set { } }
        Azure.ResourceManager.IotCentral.IotCentralAppData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.IotCentralAppData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.IotCentralAppData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotCentral.IotCentralAppData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.IotCentralAppData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.IotCentralAppData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.IotCentralAppData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotCentralAppResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotCentralAppResource() { }
        public virtual Azure.ResourceManager.IotCentral.IotCentralAppData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource> GetIotCentralPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource>> GetIotCentralPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionCollection GetIotCentralPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource> GetIotCentralPrivateLinkResource(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource>> GetIotCentralPrivateLinkResourceAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResourceCollection GetIotCentralPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotCentral.Models.IotCentralAppPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotCentral.Models.IotCentralAppPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class IotCentralExtensions
    {
        public static Azure.Response<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityResponse> CheckIotCentralAppNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityResponse>> CheckIotCentralAppNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityResponse> CheckIotCentralAppSubdomainAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityResponse>> CheckIotCentralAppSubdomainAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource> GetIotCentralApp(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource>> GetIotCentralAppAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IotCentral.IotCentralAppResource GetIotCentralAppResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotCentral.IotCentralAppCollection GetIotCentralApps(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IotCentral.IotCentralAppResource> GetIotCentralApps(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IotCentral.IotCentralAppResource> GetIotCentralAppsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource GetIotCentralPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource GetIotCentralPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplate> GetTemplatesApps(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplate> GetTemplatesAppsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotCentralPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected IotCentralPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotCentralPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData>
    {
        public IotCentralPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.IotCentral.Models.IotCentralPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotCentralPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotCentralPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotCentralPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotCentralPrivateLinkResource() { }
        public virtual Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string groupId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotCentralPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected IotCentralPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource> Get(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource>> GetAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource> GetIfExists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource>> GetIfExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotCentralPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResourceData>
    {
        public IotCentralPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.IotCentral.Mocking
{
    public partial class MockableIotCentralArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableIotCentralArmClient() { }
        public virtual Azure.ResourceManager.IotCentral.IotCentralAppResource GetIotCentralAppResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource GetIotCentralPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource GetIotCentralPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableIotCentralResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableIotCentralResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource> GetIotCentralApp(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource>> GetIotCentralAppAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotCentral.IotCentralAppCollection GetIotCentralApps() { throw null; }
    }
    public partial class MockableIotCentralSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableIotCentralSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityResponse> CheckIotCentralAppNameAvailability(Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityResponse>> CheckIotCentralAppNameAvailabilityAsync(Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityResponse> CheckIotCentralAppSubdomainAvailability(Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityResponse>> CheckIotCentralAppSubdomainAvailabilityAsync(Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotCentral.IotCentralAppResource> GetIotCentralApps(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotCentral.IotCentralAppResource> GetIotCentralAppsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplate> GetTemplatesApps(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplate> GetTemplatesAppsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.IotCentral.Models
{
    public static partial class ArmIotCentralModelFactory
    {
        public static Azure.ResourceManager.IotCentral.IotCentralAppData IotCentralAppData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.IotCentral.Models.IotCentralAppSku? skuName = default(Azure.ResourceManager.IotCentral.Models.IotCentralAppSku?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.IotCentral.Models.IotCentralProvisioningState? provisioningState = default(Azure.ResourceManager.IotCentral.Models.IotCentralProvisioningState?), System.Guid? applicationId = default(System.Guid?), string displayName = null, string subdomain = null, string template = null, Azure.ResourceManager.IotCentral.Models.IotCentralAppState? state = default(Azure.ResourceManager.IotCentral.Models.IotCentralAppState?), Azure.ResourceManager.IotCentral.Models.IotCentralPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.IotCentral.Models.IotCentralPublicNetworkAccess?), Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSets networkRuleSets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityContent IotCentralAppNameAvailabilityContent(string name = null, string resourceType = null) { throw null; }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityResponse IotCentralAppNameAvailabilityResponse(bool? isNameAvailable = default(bool?), string iotCentralAppNameUnavailableReason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralAppPatch IotCentralAppPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.IotCentral.Models.IotCentralAppSku? skuName = default(Azure.ResourceManager.IotCentral.Models.IotCentralAppSku?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.IotCentral.Models.IotCentralProvisioningState? provisioningState = default(Azure.ResourceManager.IotCentral.Models.IotCentralProvisioningState?), System.Guid? applicationId = default(System.Guid?), string displayName = null, string subdomain = null, string template = null, Azure.ResourceManager.IotCentral.Models.IotCentralAppState? state = default(Azure.ResourceManager.IotCentral.Models.IotCentralAppState?), Azure.ResourceManager.IotCentral.Models.IotCentralPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.IotCentral.Models.IotCentralPublicNetworkAccess?), Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSets networkRuleSets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplate IotCentralAppTemplate(string manifestId = null, string manifestVersion = null, string name = null, string title = null, int? order = default(int?), string description = null, string industry = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplateLocation> locations = null) { throw null; }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplateLocation IotCentralAppTemplateLocation(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string displayName = null) { throw null; }
        public static Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData IotCentralPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.IotCentral.Models.IotCentralPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResourceData IotCentralPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
    }
    public partial class IotCentralAppNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityContent>
    {
        public IotCentralAppNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } set { } }
        Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotCentralAppNameAvailabilityResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityResponse>
    {
        internal IotCentralAppNameAvailabilityResponse() { }
        public string IotCentralAppNameUnavailableReason { get { throw null; } }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppNameAvailabilityResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotCentralAppPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppPatch>
    {
        public IotCentralAppPatch() { }
        public System.Guid? ApplicationId { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSets NetworkRuleSets { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.IotCentral.Models.IotCentralProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IotCentral.Models.IotCentralPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.IotCentral.Models.IotCentralAppSku? SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.IotCentral.Models.IotCentralAppState? State { get { throw null; } }
        public string Subdomain { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Template { get { throw null; } set { } }
        Azure.ResourceManager.IotCentral.Models.IotCentralAppPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotCentral.Models.IotCentralAppPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotCentralAppSku : System.IEquatable<Azure.ResourceManager.IotCentral.Models.IotCentralAppSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotCentralAppSku(string value) { throw null; }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralAppSku ST0 { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralAppSku ST1 { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralAppSku ST2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotCentral.Models.IotCentralAppSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotCentral.Models.IotCentralAppSku left, Azure.ResourceManager.IotCentral.Models.IotCentralAppSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotCentral.Models.IotCentralAppSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotCentral.Models.IotCentralAppSku left, Azure.ResourceManager.IotCentral.Models.IotCentralAppSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotCentralAppSkuInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppSkuInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppSkuInfo>
    {
        public IotCentralAppSkuInfo(Azure.ResourceManager.IotCentral.Models.IotCentralAppSku name) { }
        public Azure.ResourceManager.IotCentral.Models.IotCentralAppSku Name { get { throw null; } set { } }
        Azure.ResourceManager.IotCentral.Models.IotCentralAppSkuInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppSkuInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppSkuInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotCentral.Models.IotCentralAppSkuInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppSkuInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppSkuInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppSkuInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotCentralAppState : System.IEquatable<Azure.ResourceManager.IotCentral.Models.IotCentralAppState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotCentralAppState(string value) { throw null; }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralAppState Created { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralAppState Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotCentral.Models.IotCentralAppState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotCentral.Models.IotCentralAppState left, Azure.ResourceManager.IotCentral.Models.IotCentralAppState right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotCentral.Models.IotCentralAppState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotCentral.Models.IotCentralAppState left, Azure.ResourceManager.IotCentral.Models.IotCentralAppState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotCentralAppTemplate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplate>
    {
        internal IotCentralAppTemplate() { }
        public string Description { get { throw null; } }
        public string Industry { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplateLocation> Locations { get { throw null; } }
        public string ManifestId { get { throw null; } }
        public string ManifestVersion { get { throw null; } }
        public string Name { get { throw null; } }
        public int? Order { get { throw null; } }
        public string Title { get { throw null; } }
        Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotCentralAppTemplateLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplateLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplateLocation>
    {
        internal IotCentralAppTemplateLocation() { }
        public string DisplayName { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplateLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplateLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplateLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplateLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplateLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplateLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralAppTemplateLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotCentralNetworkAction : System.IEquatable<Azure.ResourceManager.IotCentral.Models.IotCentralNetworkAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotCentralNetworkAction(string value) { throw null; }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralNetworkAction Allow { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralNetworkAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotCentral.Models.IotCentralNetworkAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotCentral.Models.IotCentralNetworkAction left, Azure.ResourceManager.IotCentral.Models.IotCentralNetworkAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotCentral.Models.IotCentralNetworkAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotCentral.Models.IotCentralNetworkAction left, Azure.ResourceManager.IotCentral.Models.IotCentralNetworkAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotCentralNetworkRuleSetIPRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSetIPRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSetIPRule>
    {
        public IotCentralNetworkRuleSetIPRule() { }
        public string FilterName { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
        Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSetIPRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSetIPRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSetIPRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSetIPRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSetIPRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSetIPRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSetIPRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotCentralNetworkRuleSets : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSets>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSets>
    {
        public IotCentralNetworkRuleSets() { }
        public bool? ApplyToDevices { get { throw null; } set { } }
        public bool? ApplyToIotCentral { get { throw null; } set { } }
        public Azure.ResourceManager.IotCentral.Models.IotCentralNetworkAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSetIPRule> IPRules { get { throw null; } }
        Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSets System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSets System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralNetworkRuleSets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotCentralPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotCentralPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotCentralPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotCentralPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotCentralPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralPrivateLinkServiceConnectionState>
    {
        public IotCentralPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        Azure.ResourceManager.IotCentral.Models.IotCentralPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotCentral.Models.IotCentralPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotCentral.Models.IotCentralPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotCentral.Models.IotCentralPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotCentralProvisioningState : System.IEquatable<Azure.ResourceManager.IotCentral.Models.IotCentralProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotCentralProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotCentral.Models.IotCentralProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotCentral.Models.IotCentralProvisioningState left, Azure.ResourceManager.IotCentral.Models.IotCentralProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotCentral.Models.IotCentralProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotCentral.Models.IotCentralProvisioningState left, Azure.ResourceManager.IotCentral.Models.IotCentralProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotCentralPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.IotCentral.Models.IotCentralPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotCentralPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotCentral.Models.IotCentralPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotCentral.Models.IotCentralPublicNetworkAccess left, Azure.ResourceManager.IotCentral.Models.IotCentralPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotCentral.Models.IotCentralPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotCentral.Models.IotCentralPublicNetworkAccess left, Azure.ResourceManager.IotCentral.Models.IotCentralPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
}
