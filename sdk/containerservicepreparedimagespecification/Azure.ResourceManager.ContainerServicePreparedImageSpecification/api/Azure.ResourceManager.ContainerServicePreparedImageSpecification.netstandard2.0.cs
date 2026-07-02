namespace Azure.ResourceManager.ContainerServicePreparedImageSpecification
{
    public partial class AzureResourceManagerContainerServicePreparedImageSpecificationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerContainerServicePreparedImageSpecificationContext() { }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.AzureResourceManagerContainerServicePreparedImageSpecificationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ContainerServicePreparedImageSpecificationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource> GetPreparedImageSpecification(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string preparedImageSpecificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource>> GetPreparedImageSpecificationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string preparedImageSpecificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource GetPreparedImageSpecificationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationCollection GetPreparedImageSpecifications(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource> GetPreparedImageSpecifications(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource> GetPreparedImageSpecificationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionResource GetPreparedImageSpecificationVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class PreparedImageSpecificationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource>, System.Collections.IEnumerable
    {
        protected PreparedImageSpecificationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string preparedImageSpecificationName, Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string preparedImageSpecificationName, Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string preparedImageSpecificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string preparedImageSpecificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource> Get(string preparedImageSpecificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource>> GetAsync(string preparedImageSpecificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource> GetIfExists(string preparedImageSpecificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource>> GetIfExistsAsync(string preparedImageSpecificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PreparedImageSpecificationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData>
    {
        public PreparedImageSpecificationData(Azure.Core.AzureLocation location) { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PreparedImageSpecificationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PreparedImageSpecificationResource() { }
        public virtual Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string preparedImageSpecificationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionResource> GetPreparedImageSpecificationVersion(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionResource>> GetPreparedImageSpecificationVersionAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionCollection GetPreparedImageSpecificationVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource> Update(Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationPatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource>> UpdateAsync(Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationPatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PreparedImageSpecificationVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionResource>, System.Collections.IEnumerable
    {
        protected PreparedImageSpecificationVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionResource> GetIfExists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionResource>> GetIfExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PreparedImageSpecificationVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionData>
    {
        internal PreparedImageSpecificationVersionData() { }
        public Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PreparedImageSpecificationVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PreparedImageSpecificationVersionResource() { }
        public virtual Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string preparedImageSpecificationName, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerServicePreparedImageSpecification.Mocking
{
    public partial class MockableContainerServicePreparedImageSpecificationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerServicePreparedImageSpecificationArmClient() { }
        public virtual Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource GetPreparedImageSpecificationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionResource GetPreparedImageSpecificationVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableContainerServicePreparedImageSpecificationResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerServicePreparedImageSpecificationResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource> GetPreparedImageSpecification(string preparedImageSpecificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource>> GetPreparedImageSpecificationAsync(string preparedImageSpecificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationCollection GetPreparedImageSpecifications() { throw null; }
    }
    public partial class MockableContainerServicePreparedImageSpecificationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerServicePreparedImageSpecificationSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource> GetPreparedImageSpecifications(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationResource> GetPreparedImageSpecificationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models
{
    public static partial class ArmContainerServicePreparedImageSpecificationModelFactory
    {
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationData PreparedImageSpecificationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationProperties properties = null, string eTag = null) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationManagedIdentityProfile PreparedImageSpecificationManagedIdentityProfile(Azure.Core.ResourceIdentifier resourceId = null, System.Guid? objectId = default(System.Guid?), System.Guid? clientId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationPatch PreparedImageSpecificationPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationProperties PreparedImageSpecificationProperties(System.Collections.Generic.IEnumerable<string> containerImages = null, Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationManagedIdentityProfile identityProfile = null, string version = null, Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationScript> customizationScripts = null) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationScript PreparedImageSpecificationScript(string name = null, Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ExecutionPoint executionPoint = default(Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ExecutionPoint), Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ScriptType scriptType = default(Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ScriptType), string script = null, Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PostScriptAction? postScriptAction = default(Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PostScriptAction?)) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.PreparedImageSpecificationVersionData PreparedImageSpecificationVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationProperties properties = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExecutionPoint : System.IEquatable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ExecutionPoint>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExecutionPoint(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ExecutionPoint NodeImageBuildTime { get { throw null; } }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ExecutionPoint NodeProvisionTime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ExecutionPoint other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ExecutionPoint left, Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ExecutionPoint right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ExecutionPoint (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ExecutionPoint? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ExecutionPoint left, Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ExecutionPoint right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostScriptAction : System.IEquatable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PostScriptAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostScriptAction(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PostScriptAction None { get { throw null; } }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PostScriptAction RebootAfter { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PostScriptAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PostScriptAction left, Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PostScriptAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PostScriptAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PostScriptAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PostScriptAction left, Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PostScriptAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PreparedImageSpecificationManagedIdentityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationManagedIdentityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationManagedIdentityProfile>
    {
        public PreparedImageSpecificationManagedIdentityProfile(Azure.Core.ResourceIdentifier resourceId) { }
        public System.Guid? ClientId { get { throw null; } }
        public System.Guid? ObjectId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationManagedIdentityProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationManagedIdentityProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationManagedIdentityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationManagedIdentityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationManagedIdentityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationManagedIdentityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationManagedIdentityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationManagedIdentityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationManagedIdentityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PreparedImageSpecificationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationPatch>
    {
        public PreparedImageSpecificationPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PreparedImageSpecificationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationProperties>
    {
        public PreparedImageSpecificationProperties() { }
        public System.Collections.Generic.IList<string> ContainerImages { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationScript> CustomizationScripts { get { throw null; } }
        public Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationManagedIdentityProfile IdentityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PreparedImageSpecificationScript : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationScript>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationScript>
    {
        public PreparedImageSpecificationScript(string name, Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ExecutionPoint executionPoint, Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ScriptType scriptType) { }
        public Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ExecutionPoint ExecutionPoint { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PostScriptAction? PostScriptAction { get { throw null; } set { } }
        public string Script { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ScriptType ScriptType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationScript JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationScript PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationScript System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationScript>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationScript>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationScript System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationScript>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationScript>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.PreparedImageSpecificationScript>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ProvisioningState left, Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ProvisioningState left, Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptType : System.IEquatable<Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ScriptType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ScriptType Bash { get { throw null; } }
        public static Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ScriptType PowerShell { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ScriptType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ScriptType left, Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ScriptType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ScriptType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ScriptType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ScriptType left, Azure.ResourceManager.ContainerServicePreparedImageSpecification.Models.ScriptType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
