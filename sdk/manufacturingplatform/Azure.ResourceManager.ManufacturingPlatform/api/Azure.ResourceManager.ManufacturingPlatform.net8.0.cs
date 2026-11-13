namespace Azure.ResourceManager.ManufacturingPlatform
{
    public partial class AzureResourceManagerManufacturingPlatformContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerManufacturingPlatformContext() { }
        public static Azure.ResourceManager.ManufacturingPlatform.AzureResourceManagerManufacturingPlatformContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ManufacturingDataServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource>, System.Collections.IEnumerable
    {
        protected ManufacturingDataServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string mdsResourceName, Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string mdsResourceName, Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string mdsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string mdsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource> Get(string mdsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource>> GetAsync(string mdsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource> GetIfExists(string mdsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource>> GetIfExistsAsync(string mdsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManufacturingDataServiceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData>
    {
        public ManufacturingDataServiceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformSku Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManufacturingDataServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManufacturingDataServiceResource() { }
        public virtual Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mdsResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceAvailableVersionListResult> GetAvailableVersions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceAvailableVersionListResult>> GetAvailableVersionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ManufacturingPlatformExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource> GetManufacturingDataService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string mdsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource>> GetManufacturingDataServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string mdsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource GetManufacturingDataServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceCollection GetManufacturingDataServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource> GetManufacturingDataServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource> GetManufacturingDataServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ManufacturingPlatform.Mocking
{
    public partial class MockableManufacturingPlatformArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableManufacturingPlatformArmClient() { }
        public virtual Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource GetManufacturingDataServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableManufacturingPlatformResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableManufacturingPlatformResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource> GetManufacturingDataService(string mdsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource>> GetManufacturingDataServiceAsync(string mdsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceCollection GetManufacturingDataServices() { throw null; }
    }
    public partial class MockableManufacturingPlatformSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableManufacturingPlatformSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource> GetManufacturingDataServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceResource> GetManufacturingDataServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ManufacturingPlatform.Models
{
    public partial class AdxProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.AdxProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.AdxProfile>
    {
        internal AdxProfile() { }
        public string DataIngestionUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Uri { get { throw null; } }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.AdxProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.AdxProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManufacturingPlatform.Models.AdxProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.AdxProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.AdxProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManufacturingPlatform.Models.AdxProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.AdxProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.AdxProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.AdxProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmManufacturingPlatformModelFactory
    {
        public static Azure.ResourceManager.ManufacturingPlatform.Models.AdxProfile AdxProfile(Azure.Core.ResourceIdentifier id = null, string uri = null, string dataIngestionUri = null) { throw null; }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.DenyAssignmentExclusion DenyAssignmentExclusion(string id = null, string type = null) { throw null; }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.EventHubProfile EventHubProfile(Azure.Core.ResourceIdentifier adxInstanceId = null, string hostName = null) { throw null; }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.FabricProfile FabricProfile(string keyUri = null, string oneLakeUri = null, string oneLakePath = null) { throw null; }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.ManagedOnBehalfOfBrokerResourceInfo ManagedOnBehalfOfBrokerResourceInfo(Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.ManagedResourceGroupConfiguration ManagedResourceGroupConfiguration(string name = null, string location = null) { throw null; }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceApplicationVersion ManufacturingDataServiceApplicationVersion(string version = null, bool isLatest = false, bool isPreview = false, bool isDeprecated = false) { throw null; }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceAvailableVersionListResult ManufacturingDataServiceAvailableVersionListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceApplicationVersion> versions = null) { throw null; }
        public static Azure.ResourceManager.ManufacturingPlatform.ManufacturingDataServiceData ManufacturingDataServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformSku sku = null) { throw null; }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServicePatch ManufacturingDataServicePatch(Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformSku sku = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceUpdateProperties ManufacturingDataServiceUpdateProperties(string version = null, bool? enableCopilot = default(bool?), bool? enableDiagnosticSettings = default(bool?), Azure.ResourceManager.ManufacturingPlatform.Models.OpenAIProfile openAIProfile = null, Azure.ResourceManager.ManufacturingPlatform.Models.FabricProfile fabricProfile = null, Azure.ResourceManager.ManufacturingPlatform.Models.UserManagedOpenAIProfile userManagedOpenAIProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManufacturingPlatform.Models.DenyAssignmentExclusion> denyAssignmentExclusions = null, Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformResourceState? resourceState = default(Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformResourceState?)) { throw null; }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformSku ManufacturingPlatformSku(string name = null, Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformSkuTier? tier = default(Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformSkuTier?), string size = null, string family = null, int? capacity = default(int?)) { throw null; }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.OpenAIProfile OpenAIProfile(Azure.Core.ResourceIdentifier id = null, string gptModelName = null, string gptModelVersion = null, int? gptModelCapacity = default(int?), string gptModelSkuName = null, string embeddingModelName = null, string embeddingModelVersion = null, string embeddingModelSkuName = null, int? embeddingModelCapacity = default(int?)) { throw null; }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.UserManagedOpenAIProfile UserManagedOpenAIProfile(Azure.Core.ResourceIdentifier id = null, string gptModelDeploymentName = null, string embeddingModelDeploymentName = null, string embeddingModelType = null) { throw null; }
    }
    public partial class DenyAssignmentExclusion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.DenyAssignmentExclusion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.DenyAssignmentExclusion>
    {
        public DenyAssignmentExclusion(string id, string type) { }
        public string Id { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.DenyAssignmentExclusion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.DenyAssignmentExclusion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManufacturingPlatform.Models.DenyAssignmentExclusion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.DenyAssignmentExclusion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.DenyAssignmentExclusion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManufacturingPlatform.Models.DenyAssignmentExclusion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.DenyAssignmentExclusion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.DenyAssignmentExclusion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.DenyAssignmentExclusion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventHubProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.EventHubProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.EventHubProfile>
    {
        internal EventHubProfile() { }
        public Azure.Core.ResourceIdentifier AdxInstanceId { get { throw null; } }
        public string HostName { get { throw null; } }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.EventHubProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.EventHubProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManufacturingPlatform.Models.EventHubProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.EventHubProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.EventHubProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManufacturingPlatform.Models.EventHubProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.EventHubProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.EventHubProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.EventHubProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FabricProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.FabricProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.FabricProfile>
    {
        public FabricProfile(string keyUri, string oneLakeUri, string oneLakePath) { }
        public string KeyUri { get { throw null; } set { } }
        public string OneLakePath { get { throw null; } set { } }
        public string OneLakeUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.FabricProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.FabricProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManufacturingPlatform.Models.FabricProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.FabricProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.FabricProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManufacturingPlatform.Models.FabricProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.FabricProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.FabricProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.FabricProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedOnBehalfOfBrokerResourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManagedOnBehalfOfBrokerResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManagedOnBehalfOfBrokerResourceInfo>
    {
        internal ManagedOnBehalfOfBrokerResourceInfo() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.ManagedOnBehalfOfBrokerResourceInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.ManagedOnBehalfOfBrokerResourceInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManufacturingPlatform.Models.ManagedOnBehalfOfBrokerResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManagedOnBehalfOfBrokerResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManagedOnBehalfOfBrokerResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManufacturingPlatform.Models.ManagedOnBehalfOfBrokerResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManagedOnBehalfOfBrokerResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManagedOnBehalfOfBrokerResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManagedOnBehalfOfBrokerResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedResourceGroupConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManagedResourceGroupConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManagedResourceGroupConfiguration>
    {
        internal ManagedResourceGroupConfiguration() { }
        public string Location { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.ManagedResourceGroupConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.ManagedResourceGroupConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManufacturingPlatform.Models.ManagedResourceGroupConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManagedResourceGroupConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManagedResourceGroupConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManufacturingPlatform.Models.ManagedResourceGroupConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManagedResourceGroupConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManagedResourceGroupConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManagedResourceGroupConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManufacturingDataServiceApplicationVersion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceApplicationVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceApplicationVersion>
    {
        internal ManufacturingDataServiceApplicationVersion() { }
        public bool IsDeprecated { get { throw null; } }
        public bool IsLatest { get { throw null; } }
        public bool IsPreview { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceApplicationVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceApplicationVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceApplicationVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceApplicationVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceApplicationVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceApplicationVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceApplicationVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceApplicationVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceApplicationVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManufacturingDataServiceAvailableVersionListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceAvailableVersionListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceAvailableVersionListResult>
    {
        internal ManufacturingDataServiceAvailableVersionListResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceApplicationVersion> Versions { get { throw null; } }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceAvailableVersionListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceAvailableVersionListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceAvailableVersionListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceAvailableVersionListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceAvailableVersionListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceAvailableVersionListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceAvailableVersionListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceAvailableVersionListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceAvailableVersionListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManufacturingDataServicePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServicePatch>
    {
        public ManufacturingDataServicePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceUpdateProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServicePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServicePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManufacturingDataServiceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceProperties>
    {
        public ManufacturingDataServiceProperties(System.Guid aadApplicationId) { }
        public System.Guid AadApplicationId { get { throw null; } set { } }
        public Azure.ResourceManager.ManufacturingPlatform.Models.AdxProfile AdxProfile { get { throw null; } }
        public System.Guid? AksAdminGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AksProfileId { get { throw null; } }
        public string CmkKeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DatabaseCosmosId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManufacturingPlatform.Models.DenyAssignmentExclusion> DenyAssignmentExclusions { get { throw null; } }
        public bool? EnableCopilot { get { throw null; } set { } }
        public bool? EnableDiagnosticSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ManufacturingPlatform.Models.EventHubProfile EventHubProfile { get { throw null; } }
        public Azure.ResourceManager.ManufacturingPlatform.Models.FabricProfile FabricProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier FunctionAppProfileId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManufacturingPlatform.Models.ManagedOnBehalfOfBrokerResourceInfo> ManagedOnBehalfOfBrokerResources { get { throw null; } }
        public Azure.ResourceManager.ManufacturingPlatform.Models.ManagedResourceGroupConfiguration ManagedResourceGroupConfiguration { get { throw null; } }
        public Azure.Core.ResourceIdentifier MonitoringProfileId { get { throw null; } }
        public Azure.ResourceManager.ManufacturingPlatform.Models.OpenAIProfile OpenAIProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier RedisProfileId { get { throw null; } }
        public Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformRedundancyState? RedundancyState { get { throw null; } set { } }
        public Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformResourceState? ResourceState { get { throw null; } set { } }
        public string ServiceUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageProfileId { get { throw null; } }
        public Azure.ResourceManager.ManufacturingPlatform.Models.UserManagedOpenAIProfile UserManagedOpenAIProfile { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManufacturingDataServiceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceUpdateProperties>
    {
        public ManufacturingDataServiceUpdateProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManufacturingPlatform.Models.DenyAssignmentExclusion> DenyAssignmentExclusions { get { throw null; } }
        public bool? EnableCopilot { get { throw null; } set { } }
        public bool? EnableDiagnosticSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ManufacturingPlatform.Models.FabricProfile FabricProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ManufacturingPlatform.Models.OpenAIProfile OpenAIProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformResourceState? ResourceState { get { throw null; } set { } }
        public Azure.ResourceManager.ManufacturingPlatform.Models.UserManagedOpenAIProfile UserManagedOpenAIProfile { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingDataServiceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManufacturingPlatformProvisioningState : System.IEquatable<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManufacturingPlatformProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformProvisioningState left, Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformProvisioningState left, Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManufacturingPlatformRedundancyState : System.IEquatable<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformRedundancyState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManufacturingPlatformRedundancyState(string value) { throw null; }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformRedundancyState None { get { throw null; } }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformRedundancyState Zonal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformRedundancyState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformRedundancyState left, Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformRedundancyState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformRedundancyState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformRedundancyState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformRedundancyState left, Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformRedundancyState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManufacturingPlatformResourceState : System.IEquatable<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManufacturingPlatformResourceState(string value) { throw null; }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformResourceState Active { get { throw null; } }
        public static Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformResourceState Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformResourceState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformResourceState left, Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformResourceState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformResourceState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformResourceState left, Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManufacturingPlatformSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformSku>
    {
        public ManufacturingPlatformSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformSkuTier? Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.ManufacturingPlatformSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ManufacturingPlatformSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    public partial class OpenAIProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.OpenAIProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.OpenAIProfile>
    {
        public OpenAIProfile() { }
        public int? EmbeddingModelCapacity { get { throw null; } set { } }
        public string EmbeddingModelName { get { throw null; } set { } }
        public string EmbeddingModelSkuName { get { throw null; } set { } }
        public string EmbeddingModelVersion { get { throw null; } set { } }
        public int? GptModelCapacity { get { throw null; } set { } }
        public string GptModelName { get { throw null; } set { } }
        public string GptModelSkuName { get { throw null; } set { } }
        public string GptModelVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.OpenAIProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.OpenAIProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManufacturingPlatform.Models.OpenAIProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.OpenAIProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.OpenAIProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManufacturingPlatform.Models.OpenAIProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.OpenAIProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.OpenAIProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.OpenAIProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserManagedOpenAIProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.UserManagedOpenAIProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.UserManagedOpenAIProfile>
    {
        public UserManagedOpenAIProfile(Azure.Core.ResourceIdentifier id, string gptModelDeploymentName, string embeddingModelDeploymentName) { }
        public string EmbeddingModelDeploymentName { get { throw null; } set { } }
        public string EmbeddingModelType { get { throw null; } }
        public string GptModelDeploymentName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.UserManagedOpenAIProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManufacturingPlatform.Models.UserManagedOpenAIProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManufacturingPlatform.Models.UserManagedOpenAIProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.UserManagedOpenAIProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManufacturingPlatform.Models.UserManagedOpenAIProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManufacturingPlatform.Models.UserManagedOpenAIProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.UserManagedOpenAIProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.UserManagedOpenAIProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManufacturingPlatform.Models.UserManagedOpenAIProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
