namespace Azure.ResourceManager.AgriculturePlatform
{
    public static partial class AgriculturePlatformExtensions
    {
        public static Azure.ResourceManager.AgriculturePlatform.AgriServiceResource GetAgriServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource> GetAgriServiceResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string agriServiceResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource>> GetAgriServiceResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string agriServiceResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceCollection GetAgriServiceResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource> GetAgriServiceResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource> GetAgriServiceResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AgriServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AgriServiceResource() { }
        public virtual Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string agriServiceResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult> GetAvailableSolutions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult>> GetAvailableSolutionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AgriServiceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource>, System.Collections.IEnumerable
    {
        protected AgriServiceResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agriServiceResourceName, Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agriServiceResourceName, Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string agriServiceResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agriServiceResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource> Get(string agriServiceResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource>> GetAsync(string agriServiceResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource> GetIfExists(string agriServiceResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource>> GetIfExistsAsync(string agriServiceResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AgriServiceResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData>
    {
        public AgriServiceResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.AgriculturePlatform.Mocking
{
    public partial class MockableAgriculturePlatformArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAgriculturePlatformArmClient() { }
        public virtual Azure.ResourceManager.AgriculturePlatform.AgriServiceResource GetAgriServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableAgriculturePlatformResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAgriculturePlatformResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource> GetAgriServiceResource(string agriServiceResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource>> GetAgriServiceResourceAsync(string agriServiceResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceCollection GetAgriServiceResources() { throw null; }
    }
    public partial class MockableAgriculturePlatformSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAgriculturePlatformSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource> GetAgriServiceResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AgriculturePlatform.AgriServiceResource> GetAgriServiceResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AgriculturePlatform.Models
{
    public partial class AgriculturePlatformSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku>
    {
        public AgriculturePlatformSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSkuTier? Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AgriculturePlatformSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    public partial class AgriServiceConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceConfig>
    {
        public AgriServiceConfig() { }
        public string AppServiceResourceId { get { throw null; } }
        public string CosmosDbResourceId { get { throw null; } }
        public string InstanceUri { get { throw null; } }
        public string KeyVaultResourceId { get { throw null; } }
        public string RedisCacheResourceId { get { throw null; } }
        public string StorageAccountResourceId { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgriServiceResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourcePatch>
    {
        public AgriServiceResourcePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgriServiceResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceProperties>
    {
        public AgriServiceResourceProperties() { }
        public Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceConfig Config { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap> DataConnectorCredentials { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap> InstalledSolutions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public Azure.ResourceManager.AgriculturePlatform.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgriServiceResourceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties>
    {
        public AgriServiceResourceUpdateProperties() { }
        public Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceConfig Config { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap> DataConnectorCredentials { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap> InstalledSolutions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmAgriculturePlatformModelFactory
    {
        public static Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceConfig AgriServiceConfig(string instanceUri = null, string version = null, string appServiceResourceId = null, string cosmosDbResourceId = null, string storageAccountResourceId = null, string keyVaultResourceId = null, string redisCacheResourceId = null) { throw null; }
        public static Azure.ResourceManager.AgriculturePlatform.AgriServiceResourceData AgriServiceResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.AgriculturePlatform.Models.AgriculturePlatformSku sku = null) { throw null; }
        public static Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceResourceProperties AgriServiceResourceProperties(Azure.ResourceManager.AgriculturePlatform.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.AgriculturePlatform.Models.ProvisioningState?), Azure.ResourceManager.AgriculturePlatform.Models.AgriServiceConfig config = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> managedOnBehalfOfMoboBrokerResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap> dataConnectorCredentials = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap> installedSolutions = null) { throw null; }
        public static Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult AvailableAgriSolutionListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution> solutions = null) { throw null; }
        public static Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution DataManagerForAgricultureSolution(string partnerId = null, string solutionId = null, string partnerTenantId = null, System.Collections.Generic.IEnumerable<string> dataAccessScopes = null, Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails marketPlaceOfferDetails = null, string saasApplicationId = null, string accessAzureDataManagerForAgricultureApplicationId = null, string accessAzureDataManagerForAgricultureApplicationName = null, bool isValidateInput = false) { throw null; }
        public static Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails MarketPlaceOfferDetails(string saasOfferId = null, string publisherId = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthCredentialsKind : System.IEquatable<Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthCredentialsKind(string value) { throw null; }
        public static Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind ApiKeyAuthCredentials { get { throw null; } }
        public static Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind OAuthClientCredentials { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind left, Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind left, Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvailableAgriSolutionListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult>
    {
        internal AvailableAgriSolutionListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution> Solutions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.AvailableAgriSolutionListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataConnectorCredentialMap : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap>
    {
        public DataConnectorCredentialMap(string key, Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials value) { }
        public string Key { get { throw null; } set { } }
        public Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentialMap>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataConnectorCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials>
    {
        public DataConnectorCredentials() { }
        public string ClientId { get { throw null; } set { } }
        public string KeyName { get { throw null; } set { } }
        public string KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public Azure.ResourceManager.AgriculturePlatform.Models.AuthCredentialsKind? Kind { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataConnectorCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataManagerForAgricultureSolution : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution>
    {
        internal DataManagerForAgricultureSolution() { }
        public string AccessAzureDataManagerForAgricultureApplicationId { get { throw null; } }
        public string AccessAzureDataManagerForAgricultureApplicationName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DataAccessScopes { get { throw null; } }
        public bool IsValidateInput { get { throw null; } }
        public Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails MarketPlaceOfferDetails { get { throw null; } }
        public string PartnerId { get { throw null; } }
        public string PartnerTenantId { get { throw null; } }
        public string SaasApplicationId { get { throw null; } }
        public string SolutionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.DataManagerForAgricultureSolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstalledSolutionMap : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap>
    {
        public InstalledSolutionMap(string key, Azure.ResourceManager.AgriculturePlatform.Models.Solution value) { }
        public string Key { get { throw null; } set { } }
        public Azure.ResourceManager.AgriculturePlatform.Models.Solution Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.InstalledSolutionMap>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketPlaceOfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails>
    {
        internal MarketPlaceOfferDetails() { }
        public string PublisherId { get { throw null; } }
        public string SaasOfferId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.MarketPlaceOfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.AgriculturePlatform.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AgriculturePlatform.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.AgriculturePlatform.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.AgriculturePlatform.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AgriculturePlatform.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AgriculturePlatform.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.AgriculturePlatform.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AgriculturePlatform.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AgriculturePlatform.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AgriculturePlatform.Models.ProvisioningState left, Azure.ResourceManager.AgriculturePlatform.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AgriculturePlatform.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AgriculturePlatform.Models.ProvisioningState left, Azure.ResourceManager.AgriculturePlatform.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Solution : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.Solution>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.Solution>
    {
        public Solution() { }
        public string ApplicationName { get { throw null; } set { } }
        public string MarketPlacePublisherId { get { throw null; } set { } }
        public string PartnerId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string SaasSubscriptionId { get { throw null; } set { } }
        public string SaasSubscriptionName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.Solution System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.Solution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AgriculturePlatform.Models.Solution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AgriculturePlatform.Models.Solution System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.Solution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.Solution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AgriculturePlatform.Models.Solution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
