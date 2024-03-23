namespace Azure.ResourceManager.AgFoodPlatform
{
    public static partial class AgFoodPlatformExtensions
    {
        public static Azure.Response<Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityResponse> CheckNameAvailabilityLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityResponse>> CheckNameAvailabilityLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource GetAgFoodPlatformPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResource GetAgFoodPlatformPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.ExtensionResource GetExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource> GetFarmBeat(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string farmBeatsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource>> GetFarmBeatAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string farmBeatsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.FarmBeatResource GetFarmBeatResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.FarmBeatCollection GetFarmBeats(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource> GetFarmBeats(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? maxPageSize = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource> GetFarmBeatsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? maxPageSize = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionResource> GetFarmBeatsExtension(this Azure.ResourceManager.Resources.TenantResource tenantResource, string farmBeatsExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionResource>> GetFarmBeatsExtensionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string farmBeatsExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionResource GetFarmBeatsExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionCollection GetFarmBeatsExtensions(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
    }
    public partial class AgFoodPlatformPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected AgFoodPlatformPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AgFoodPlatformPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionData>
    {
        public AgFoodPlatformPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgFoodPlatformPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AgFoodPlatformPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string farmBeatsResourceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AgFoodPlatformPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AgFoodPlatformPrivateLinkResource() { }
        public virtual Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string farmBeatsResourceName, string subResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AgFoodPlatformPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected AgFoodPlatformPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResource> Get(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResource>> GetAsync(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResource> GetIfExists(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResource>> GetIfExistsAsync(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AgFoodPlatformPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResourceData>
    {
        public AgFoodPlatformPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AgFoodPlatform.ExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgFoodPlatform.ExtensionResource>, System.Collections.IEnumerable
    {
        protected ExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AgFoodPlatform.ExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string extensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AgFoodPlatform.ExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string extensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string extensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string extensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.ExtensionResource> Get(string extensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AgFoodPlatform.ExtensionResource> GetAll(System.Collections.Generic.IEnumerable<string> extensionIds = null, System.Collections.Generic.IEnumerable<string> extensionCategories = null, int? maxPageSize = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AgFoodPlatform.ExtensionResource> GetAllAsync(System.Collections.Generic.IEnumerable<string> extensionIds = null, System.Collections.Generic.IEnumerable<string> extensionCategories = null, int? maxPageSize = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.ExtensionResource>> GetAsync(string extensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AgFoodPlatform.ExtensionResource> GetIfExists(string extensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AgFoodPlatform.ExtensionResource>> GetIfExistsAsync(string extensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AgFoodPlatform.ExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AgFoodPlatform.ExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AgFoodPlatform.ExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgFoodPlatform.ExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExtensionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.ExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.ExtensionData>
    {
        public ExtensionData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public string ExtensionApiDocsLink { get { throw null; } }
        public string ExtensionAuthLink { get { throw null; } }
        public string ExtensionCategory { get { throw null; } }
        public string ExtensionId { get { throw null; } }
        public string InstalledExtensionVersion { get { throw null; } }
        Azure.ResourceManager.AgFoodPlatform.ExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.ExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.ExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgFoodPlatform.ExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.ExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.ExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.ExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExtensionResource() { }
        public virtual Azure.ResourceManager.AgFoodPlatform.ExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string farmBeatsResourceName, string extensionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.ExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.ExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.ExtensionResource> Update(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.ExtensionResource>> UpdateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FarmBeatCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource>, System.Collections.IEnumerable
    {
        protected FarmBeatCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string farmBeatsResourceName, Azure.ResourceManager.AgFoodPlatform.FarmBeatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string farmBeatsResourceName, Azure.ResourceManager.AgFoodPlatform.FarmBeatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string farmBeatsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string farmBeatsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource> Get(string farmBeatsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource> GetAll(int? maxPageSize = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource> GetAllAsync(int? maxPageSize = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource>> GetAsync(string farmBeatsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource> GetIfExists(string farmBeatsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource>> GetIfExistsAsync(string farmBeatsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FarmBeatData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.FarmBeatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.FarmBeatData>
    {
        public FarmBeatData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Uri InstanceUri { get { throw null; } }
        public Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionData PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.AgFoodPlatform.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AgFoodPlatform.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.AgFoodPlatform.Models.SensorIntegration SensorIntegration { get { throw null; } set { } }
        Azure.ResourceManager.AgFoodPlatform.FarmBeatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.FarmBeatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.FarmBeatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgFoodPlatform.FarmBeatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.FarmBeatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.FarmBeatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.FarmBeatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FarmBeatResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FarmBeatResource() { }
        public virtual Azure.ResourceManager.AgFoodPlatform.FarmBeatData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string farmBeatsResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource> GetAgFoodPlatformPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource>> GetAgFoodPlatformPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionCollection GetAgFoodPlatformPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResource> GetAgFoodPlatformPrivateLinkResource(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResource>> GetAgFoodPlatformPrivateLinkResourceAsync(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResourceCollection GetAgFoodPlatformPrivateLinkResources() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.ExtensionResource> GetExtension(string extensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.ExtensionResource>> GetExtensionAsync(string extensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AgFoodPlatform.ExtensionCollection GetExtensions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.Models.ArmAsyncOperation> GetOperationResult(string operationResultsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.Models.ArmAsyncOperation>> GetOperationResultAsync(string operationResultsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FarmBeatsExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionResource>, System.Collections.IEnumerable
    {
        protected FarmBeatsExtensionCollection() { }
        public virtual Azure.Response<bool> Exists(string farmBeatsExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string farmBeatsExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionResource> Get(string farmBeatsExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionResource> GetAll(System.Collections.Generic.IEnumerable<string> farmBeatsExtensionIds = null, System.Collections.Generic.IEnumerable<string> farmBeatsExtensionNames = null, System.Collections.Generic.IEnumerable<string> extensionCategories = null, System.Collections.Generic.IEnumerable<string> publisherIds = null, int? maxPageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionResource> GetAllAsync(System.Collections.Generic.IEnumerable<string> farmBeatsExtensionIds = null, System.Collections.Generic.IEnumerable<string> farmBeatsExtensionNames = null, System.Collections.Generic.IEnumerable<string> extensionCategories = null, System.Collections.Generic.IEnumerable<string> publisherIds = null, int? maxPageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionResource>> GetAsync(string farmBeatsExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionResource> GetIfExists(string farmBeatsExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionResource>> GetIfExistsAsync(string farmBeatsExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FarmBeatsExtensionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionData>
    {
        public FarmBeatsExtensionData() { }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AgFoodPlatform.Models.DetailedInformation> DetailedInformation { get { throw null; } }
        public string ExtensionApiDocsLink { get { throw null; } }
        public string ExtensionAuthLink { get { throw null; } }
        public string ExtensionCategory { get { throw null; } }
        public string FarmBeatsExtensionId { get { throw null; } }
        public string FarmBeatsExtensionName { get { throw null; } }
        public string FarmBeatsExtensionVersion { get { throw null; } }
        public string PublisherId { get { throw null; } }
        public string TargetResourceType { get { throw null; } }
        Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FarmBeatsExtensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FarmBeatsExtensionResource() { }
        public virtual Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string farmBeatsExtensionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AgFoodPlatform.Mocking
{
    public partial class MockableAgFoodPlatformArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAgFoodPlatformArmClient() { }
        public virtual Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionResource GetAgFoodPlatformPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResource GetAgFoodPlatformPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AgFoodPlatform.ExtensionResource GetExtensionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AgFoodPlatform.FarmBeatResource GetFarmBeatResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionResource GetFarmBeatsExtensionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableAgFoodPlatformResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAgFoodPlatformResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource> GetFarmBeat(string farmBeatsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource>> GetFarmBeatAsync(string farmBeatsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AgFoodPlatform.FarmBeatCollection GetFarmBeats() { throw null; }
    }
    public partial class MockableAgFoodPlatformSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAgFoodPlatformSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityResponse> CheckNameAvailabilityLocation(Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityResponse>> CheckNameAvailabilityLocationAsync(Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource> GetFarmBeats(int? maxPageSize = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AgFoodPlatform.FarmBeatResource> GetFarmBeatsAsync(int? maxPageSize = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableAgFoodPlatformTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAgFoodPlatformTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionResource> GetFarmBeatsExtension(string farmBeatsExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionResource>> GetFarmBeatsExtensionAsync(string farmBeatsExtensionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionCollection GetFarmBeatsExtensions() { throw null; }
    }
}
namespace Azure.ResourceManager.AgFoodPlatform.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgFoodPlatformPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgFoodPlatformPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgFoodPlatformPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgFoodPlatformPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgFoodPlatformPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateLinkServiceConnectionState>
    {
        public AgFoodPlatformPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmAgFoodPlatformModelFactory
    {
        public static Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionData AgFoodPlatformPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.AgFoodPlatform.Models.AgFoodPlatformPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateLinkResourceData AgFoodPlatformPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.Models.ArmAsyncOperation ArmAsyncOperation(string status = null) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityResponse CheckNameAvailabilityResponse(bool? nameAvailable = default(bool?), Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityReason? reason = default(Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.Models.DetailedInformation DetailedInformation(string apiName = null, System.Collections.Generic.IEnumerable<string> customParameters = null, System.Collections.Generic.IEnumerable<string> platformParameters = null, Azure.ResourceManager.AgFoodPlatform.Models.UnitSystemsInfo unitsSupported = null, System.Collections.Generic.IEnumerable<string> apiInputParameters = null) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.ExtensionData ExtensionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? eTag = default(Azure.ETag?), string extensionId = null, string extensionCategory = null, string installedExtensionVersion = null, string extensionAuthLink = null, string extensionApiDocsLink = null) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.FarmBeatData FarmBeatData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Uri instanceUri = null, Azure.ResourceManager.AgFoodPlatform.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.AgFoodPlatform.Models.ProvisioningState?), Azure.ResourceManager.AgFoodPlatform.Models.SensorIntegration sensorIntegration = null, Azure.ResourceManager.AgFoodPlatform.Models.PublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.AgFoodPlatform.Models.PublicNetworkAccess?), Azure.ResourceManager.AgFoodPlatform.AgFoodPlatformPrivateEndpointConnectionData privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.FarmBeatsExtensionData FarmBeatsExtensionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string targetResourceType = null, string farmBeatsExtensionId = null, string farmBeatsExtensionName = null, string farmBeatsExtensionVersion = null, string publisherId = null, string description = null, string extensionCategory = null, string extensionAuthLink = null, string extensionApiDocsLink = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgFoodPlatform.Models.DetailedInformation> detailedInformation = null) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.Models.SensorIntegration SensorIntegration(string enabled = null, Azure.ResourceManager.AgFoodPlatform.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.AgFoodPlatform.Models.ProvisioningState?), Azure.ResponseError provisioningInfoError = null) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.Models.UnitSystemsInfo UnitSystemsInfo(string key = null, System.Collections.Generic.IEnumerable<string> values = null) { throw null; }
    }
    public partial class ArmAsyncOperation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.ArmAsyncOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.ArmAsyncOperation>
    {
        internal ArmAsyncOperation() { }
        public string Status { get { throw null; } }
        Azure.ResourceManager.AgFoodPlatform.Models.ArmAsyncOperation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.ArmAsyncOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.ArmAsyncOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgFoodPlatform.Models.ArmAsyncOperation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.ArmAsyncOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.ArmAsyncOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.ArmAsyncOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityContent>
    {
        public CheckNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CheckNameAvailabilityReason : System.IEquatable<Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CheckNameAvailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckNameAvailabilityResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityResponse>
    {
        internal CheckNameAvailabilityResponse() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityReason? Reason { get { throw null; } }
        Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.CheckNameAvailabilityResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DetailedInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.DetailedInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.DetailedInformation>
    {
        internal DetailedInformation() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiInputParameters { get { throw null; } }
        public string ApiName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> CustomParameters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PlatformParameters { get { throw null; } }
        public Azure.ResourceManager.AgFoodPlatform.Models.UnitSystemsInfo UnitsSupported { get { throw null; } }
        Azure.ResourceManager.AgFoodPlatform.Models.DetailedInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.DetailedInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.DetailedInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgFoodPlatform.Models.DetailedInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.DetailedInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.DetailedInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.DetailedInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FarmBeatPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatPatch>
    {
        public FarmBeatPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatsUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FarmBeatsUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatsUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatsUpdateProperties>
    {
        public FarmBeatsUpdateProperties() { }
        public Azure.ResourceManager.AgFoodPlatform.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.AgFoodPlatform.Models.SensorIntegration SensorIntegration { get { throw null; } set { } }
        Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatsUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatsUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatsUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatsUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatsUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatsUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.FarmBeatsUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.AgFoodPlatform.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.AgFoodPlatform.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AgFoodPlatform.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AgFoodPlatform.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AgFoodPlatform.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AgFoodPlatform.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AgFoodPlatform.Models.ProvisioningState left, Azure.ResourceManager.AgFoodPlatform.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AgFoodPlatform.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AgFoodPlatform.Models.ProvisioningState left, Azure.ResourceManager.AgFoodPlatform.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.AgFoodPlatform.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.AgFoodPlatform.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public static Azure.ResourceManager.AgFoodPlatform.Models.PublicNetworkAccess Hybrid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AgFoodPlatform.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AgFoodPlatform.Models.PublicNetworkAccess left, Azure.ResourceManager.AgFoodPlatform.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.AgFoodPlatform.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AgFoodPlatform.Models.PublicNetworkAccess left, Azure.ResourceManager.AgFoodPlatform.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SensorIntegration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.SensorIntegration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.SensorIntegration>
    {
        public SensorIntegration() { }
        public string Enabled { get { throw null; } set { } }
        public Azure.ResponseError ProvisioningInfoError { get { throw null; } set { } }
        public Azure.ResourceManager.AgFoodPlatform.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.AgFoodPlatform.Models.SensorIntegration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.SensorIntegration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.SensorIntegration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgFoodPlatform.Models.SensorIntegration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.SensorIntegration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.SensorIntegration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.SensorIntegration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UnitSystemsInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.UnitSystemsInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.UnitSystemsInfo>
    {
        internal UnitSystemsInfo() { }
        public string Key { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
        Azure.ResourceManager.AgFoodPlatform.Models.UnitSystemsInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.UnitSystemsInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgFoodPlatform.Models.UnitSystemsInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgFoodPlatform.Models.UnitSystemsInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.UnitSystemsInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.UnitSystemsInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgFoodPlatform.Models.UnitSystemsInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
