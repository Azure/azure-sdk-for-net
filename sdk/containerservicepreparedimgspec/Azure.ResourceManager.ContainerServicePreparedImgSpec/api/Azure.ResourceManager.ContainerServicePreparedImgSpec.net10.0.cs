namespace Azure.ResourceManager.ContainerServicePreparedImgSpec
{
    public partial class AzureResourceManagerContainerServicePreparedImgSpecContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerContainerServicePreparedImgSpecContext() { }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.AzureResourceManagerContainerServicePreparedImgSpecContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ContainerServicePreparedImgSpecExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource> GetPreparedImageSpecification(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string preparedImageSpecificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource>> GetPreparedImageSpecificationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string preparedImageSpecificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource GetPreparedImageSpecificationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationCollection GetPreparedImageSpecifications(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource> GetPreparedImageSpecifications(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource> GetPreparedImageSpecificationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionResource GetPreparedImageSpecificationVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class PreparedImageSpecificationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource>, System.Collections.IEnumerable
    {
        protected PreparedImageSpecificationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string preparedImageSpecificationName, Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string preparedImageSpecificationName, Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string preparedImageSpecificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string preparedImageSpecificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource> Get(string preparedImageSpecificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource>> GetAsync(string preparedImageSpecificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource> GetIfExists(string preparedImageSpecificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource>> GetIfExistsAsync(string preparedImageSpecificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PreparedImageSpecificationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData>
    {
        public PreparedImageSpecificationData(Azure.Core.AzureLocation location) { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PreparedImageSpecificationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PreparedImageSpecificationResource() { }
        public virtual Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string preparedImageSpecificationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionResource> GetPreparedImageSpecificationVersion(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionResource>> GetPreparedImageSpecificationVersionAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionCollection GetPreparedImageSpecificationVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource> Update(Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationPatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource>> UpdateAsync(Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationPatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PreparedImageSpecificationVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionResource>, System.Collections.IEnumerable
    {
        protected PreparedImageSpecificationVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionResource> GetIfExists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionResource>> GetIfExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PreparedImageSpecificationVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionData>
    {
        internal PreparedImageSpecificationVersionData() { }
        public Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PreparedImageSpecificationVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PreparedImageSpecificationVersionResource() { }
        public virtual Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string preparedImageSpecificationName, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerServicePreparedImgSpec.Mocking
{
    public partial class MockableContainerServicePreparedImgSpecArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerServicePreparedImgSpecArmClient() { }
        public virtual Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource GetPreparedImageSpecificationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionResource GetPreparedImageSpecificationVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableContainerServicePreparedImgSpecResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerServicePreparedImgSpecResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource> GetPreparedImageSpecification(string preparedImageSpecificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource>> GetPreparedImageSpecificationAsync(string preparedImageSpecificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationCollection GetPreparedImageSpecifications() { throw null; }
    }
    public partial class MockableContainerServicePreparedImgSpecSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerServicePreparedImgSpecSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource> GetPreparedImageSpecifications(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationResource> GetPreparedImageSpecificationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerServicePreparedImgSpec.Models
{
    public static partial class ArmContainerServicePreparedImgSpecModelFactory
    {
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationData PreparedImageSpecificationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationProperties properties = null, string eTag = null) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationManagedIdentityProfile PreparedImageSpecificationManagedIdentityProfile(Azure.Core.ResourceIdentifier resourceId = null, System.Guid? objectId = default(System.Guid?), System.Guid? clientId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationPatch PreparedImageSpecificationPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationProperties PreparedImageSpecificationProperties(System.Collections.Generic.IEnumerable<string> containerImages = null, Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationManagedIdentityProfile identityProfile = null, string version = null, Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationScript> customizationScripts = null) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationScript PreparedImageSpecificationScript(string name = null, Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ExecutionPoint executionPoint = default(Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ExecutionPoint), Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ScriptType scriptType = default(Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ScriptType), string script = null, Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PostScriptAction? postScriptAction = default(Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PostScriptAction?)) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.PreparedImageSpecificationVersionData PreparedImageSpecificationVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationProperties properties = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExecutionPoint : System.IEquatable<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ExecutionPoint>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExecutionPoint(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ExecutionPoint NodeImageBuildTime { get { throw null; } }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ExecutionPoint NodeProvisionTime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ExecutionPoint other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ExecutionPoint left, Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ExecutionPoint right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ExecutionPoint (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ExecutionPoint? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ExecutionPoint left, Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ExecutionPoint right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostScriptAction : System.IEquatable<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PostScriptAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostScriptAction(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PostScriptAction None { get { throw null; } }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PostScriptAction RebootAfter { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PostScriptAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PostScriptAction left, Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PostScriptAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PostScriptAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PostScriptAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PostScriptAction left, Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PostScriptAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PreparedImageSpecificationManagedIdentityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationManagedIdentityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationManagedIdentityProfile>
    {
        public PreparedImageSpecificationManagedIdentityProfile(Azure.Core.ResourceIdentifier resourceId) { }
        public System.Guid? ClientId { get { throw null; } }
        public System.Guid? ObjectId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationManagedIdentityProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationManagedIdentityProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationManagedIdentityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationManagedIdentityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationManagedIdentityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationManagedIdentityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationManagedIdentityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationManagedIdentityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationManagedIdentityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PreparedImageSpecificationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationPatch>
    {
        public PreparedImageSpecificationPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PreparedImageSpecificationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationProperties>
    {
        public PreparedImageSpecificationProperties() { }
        public System.Collections.Generic.IList<string> ContainerImages { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationScript> CustomizationScripts { get { throw null; } }
        public Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationManagedIdentityProfile IdentityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PreparedImageSpecificationScript : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationScript>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationScript>
    {
        public PreparedImageSpecificationScript(string name, Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ExecutionPoint executionPoint, Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ScriptType scriptType) { }
        public Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ExecutionPoint ExecutionPoint { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PostScriptAction? PostScriptAction { get { throw null; } set { } }
        public string Script { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ScriptType ScriptType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationScript JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationScript PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationScript System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationScript>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationScript>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationScript System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationScript>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationScript>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.PreparedImageSpecificationScript>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ProvisioningState left, Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ProvisioningState left, Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptType : System.IEquatable<Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ScriptType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ScriptType Bash { get { throw null; } }
        public static Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ScriptType PowerShell { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ScriptType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ScriptType left, Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ScriptType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ScriptType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ScriptType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ScriptType left, Azure.ResourceManager.ContainerServicePreparedImgSpec.Models.ScriptType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
