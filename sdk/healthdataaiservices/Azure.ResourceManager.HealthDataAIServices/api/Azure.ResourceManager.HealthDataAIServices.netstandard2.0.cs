namespace Azure.ResourceManager.HealthDataAIServices
{
    public partial class DeidServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource>, System.Collections.IEnumerable
    {
        protected DeidServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deidServiceName, Azure.ResourceManager.HealthDataAIServices.DeidServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deidServiceName, Azure.ResourceManager.HealthDataAIServices.DeidServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deidServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deidServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource> Get(string deidServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource>> GetAsync(string deidServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource> GetIfExists(string deidServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource>> GetIfExistsAsync(string deidServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeidServiceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.DeidServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.DeidServiceData>
    {
        public DeidServiceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HealthDataAIServices.Models.DeidServiceProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.HealthDataAIServices.DeidServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.DeidServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.DeidServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthDataAIServices.DeidServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.DeidServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.DeidServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.DeidServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeidServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.DeidServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.DeidServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeidServiceResource() { }
        public virtual Azure.ResourceManager.HealthDataAIServices.DeidServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deidServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource> GetHealthDataAIServicePrivateEndpointConnectionResource(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource>> GetHealthDataAIServicePrivateEndpointConnectionResourceAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceCollection GetHealthDataAIServicePrivateEndpointConnectionResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicePrivateLinkResourceData> GetPrivateLinks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicePrivateLinkResourceData> GetPrivateLinksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HealthDataAIServices.DeidServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.DeidServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.DeidServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthDataAIServices.DeidServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.DeidServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.DeidServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.DeidServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthDataAIServices.Models.DeidServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthDataAIServices.Models.DeidServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthDataAIServicePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthDataAIServicePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deidServiceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthDataAIServicePrivateEndpointConnectionResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected HealthDataAIServicePrivateEndpointConnectionResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HealthDataAIServicePrivateEndpointConnectionResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData>
    {
        public HealthDataAIServicePrivateEndpointConnectionResourceData() { }
        public Azure.ResourceManager.HealthDataAIServices.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class HealthDataAIServicesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource> GetDeidService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deidServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource>> GetDeidServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deidServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HealthDataAIServices.DeidServiceResource GetDeidServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HealthDataAIServices.DeidServiceCollection GetDeidServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource> GetDeidServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource> GetDeidServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource GetHealthDataAIServicePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.HealthDataAIServices.Mocking
{
    public partial class MockableHealthDataAIServicesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHealthDataAIServicesArmClient() { }
        public virtual Azure.ResourceManager.HealthDataAIServices.DeidServiceResource GetDeidServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResource GetHealthDataAIServicePrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHealthDataAIServicesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHealthDataAIServicesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource> GetDeidService(string deidServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource>> GetDeidServiceAsync(string deidServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HealthDataAIServices.DeidServiceCollection GetDeidServices() { throw null; }
    }
    public partial class MockableHealthDataAIServicesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHealthDataAIServicesSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource> GetDeidServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthDataAIServices.DeidServiceResource> GetDeidServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HealthDataAIServices.Models
{
    public static partial class ArmHealthDataAIServicesModelFactory
    {
        public static Azure.ResourceManager.HealthDataAIServices.DeidServiceData DeidServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HealthDataAIServices.Models.DeidServiceProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.HealthDataAIServices.Models.DeidServiceProperties DeidServiceProperties(Azure.ResourceManager.HealthDataAIServices.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HealthDataAIServices.Models.ProvisioningState?), string deidServicePropertiei = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnection> privateEndpointConnections = null, Azure.ResourceManager.HealthDataAIServices.Models.PublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.HealthDataAIServices.Models.PublicNetworkAccess?)) { throw null; }
        public static Azure.ResourceManager.HealthDataAIServices.HealthDataAIServicePrivateEndpointConnectionResourceData HealthDataAIServicePrivateEndpointConnectionResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HealthDataAIServices.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicePrivateLinkResourceData HealthDataAIServicePrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnection HealthDataAIServicesPrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HealthDataAIServices.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkResourceProperties HealthDataAIServicesPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.HealthDataAIServices.Models.PrivateEndpointConnectionProperties PrivateEndpointConnectionProperties(System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnectionProvisioningState?)) { throw null; }
    }
    public partial class DeidServicePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.DeidServicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.DeidServicePatch>
    {
        public DeidServicePatch() { }
        public Azure.ResourceManager.HealthDataAIServices.Models.PublicNetworkAccess? DeidPropertiesUpdatePublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.HealthDataAIServices.Models.DeidServicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.DeidServicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.DeidServicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthDataAIServices.Models.DeidServicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.DeidServicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.DeidServicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.DeidServicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeidServiceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.DeidServiceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.DeidServiceProperties>
    {
        public DeidServiceProperties() { }
        public string DeidServicePropertiei { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.HealthDataAIServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HealthDataAIServices.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        Azure.ResourceManager.HealthDataAIServices.Models.DeidServiceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.DeidServiceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.DeidServiceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthDataAIServices.Models.DeidServiceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.DeidServiceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.DeidServiceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.DeidServiceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthDataAIServicePrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicePrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicePrivateLinkResourceData>
    {
        internal HealthDataAIServicePrivateLinkResourceData() { }
        public Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkResourceProperties Properties { get { throw null; } }
        Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicePrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicePrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicePrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicePrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicePrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicePrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicePrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthDataAIServicesPrivateEndpointConnection : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnection>
    {
        internal HealthDataAIServicesPrivateEndpointConnection() { }
        public Azure.ResourceManager.HealthDataAIServices.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } }
        Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthDataAIServicesPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthDataAIServicesPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthDataAIServicesPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthDataAIServicesPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HealthDataAIServicesPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkResourceProperties>
    {
        internal HealthDataAIServicesPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthDataAIServicesPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkServiceConnectionState>
    {
        public HealthDataAIServicesPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.PrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.PrivateEndpointConnectionProperties>
    {
        public PrivateEndpointConnectionProperties(Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkServiceConnectionState privateLinkServiceConnectionState) { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.HealthDataAIServices.Models.HealthDataAIServicesPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.HealthDataAIServices.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.PrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthDataAIServices.Models.PrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthDataAIServices.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.PrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.PrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthDataAIServices.Models.PrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.HealthDataAIServices.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HealthDataAIServices.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.HealthDataAIServices.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HealthDataAIServices.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HealthDataAIServices.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HealthDataAIServices.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.HealthDataAIServices.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HealthDataAIServices.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthDataAIServices.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthDataAIServices.Models.ProvisioningState left, Azure.ResourceManager.HealthDataAIServices.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthDataAIServices.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthDataAIServices.Models.ProvisioningState left, Azure.ResourceManager.HealthDataAIServices.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum PublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
}
