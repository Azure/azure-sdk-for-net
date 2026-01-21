namespace Azure.ResourceManager.LargeInstance
{
    public partial class AzureResourceManagerLargeInstanceContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerLargeInstanceContext() { }
        public static Azure.ResourceManager.LargeInstance.AzureResourceManagerLargeInstanceContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class LargeInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LargeInstance.LargeInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LargeInstance.LargeInstanceResource>, System.Collections.IEnumerable
    {
        protected LargeInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LargeInstance.LargeInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string azureLargeInstanceName, Azure.ResourceManager.LargeInstance.LargeInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LargeInstance.LargeInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string azureLargeInstanceName, Azure.ResourceManager.LargeInstance.LargeInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string azureLargeInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string azureLargeInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.LargeInstanceResource> Get(string azureLargeInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LargeInstance.LargeInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LargeInstance.LargeInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.LargeInstanceResource>> GetAsync(string azureLargeInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.LargeInstance.LargeInstanceResource> GetIfExists(string azureLargeInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.LargeInstance.LargeInstanceResource>> GetIfExistsAsync(string azureLargeInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LargeInstance.LargeInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LargeInstance.LargeInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LargeInstance.LargeInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LargeInstance.LargeInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LargeInstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.LargeInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.LargeInstanceData>
    {
        public LargeInstanceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.LargeInstance.Models.LargeInstanceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LargeInstance.LargeInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.LargeInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.LargeInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LargeInstance.LargeInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.LargeInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.LargeInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.LargeInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class LargeInstanceExtensions
    {
        public static Azure.Response<Azure.ResourceManager.LargeInstance.LargeInstanceResource> GetLargeInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureLargeInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.LargeInstanceResource>> GetLargeInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureLargeInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LargeInstance.LargeInstanceResource GetLargeInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LargeInstance.LargeInstanceCollection GetLargeInstances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.LargeInstance.LargeInstanceResource> GetLargeInstances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.LargeInstance.LargeInstanceResource> GetLargeInstancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource> GetLargeStorageInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureLargeStorageInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource>> GetLargeStorageInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureLargeStorageInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource GetLargeStorageInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LargeInstance.LargeStorageInstanceCollection GetLargeStorageInstances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource> GetLargeStorageInstances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource> GetLargeStorageInstancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LargeInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.LargeInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.LargeInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LargeInstanceResource() { }
        public virtual Azure.ResourceManager.LargeInstance.LargeInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.LargeInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.LargeInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureLargeInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.LargeInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.LargeInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.LargeInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.LargeInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, Azure.ResourceManager.LargeInstance.Models.LargeInstanceForceState forceParameter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.LargeInstance.Models.LargeInstanceForceState forceParameter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.LargeInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.LargeInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> Shutdown(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> ShutdownAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.LargeInstance.LargeInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.LargeInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.LargeInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LargeInstance.LargeInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.LargeInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.LargeInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.LargeInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.LargeInstanceResource> Update(Azure.ResourceManager.LargeInstance.Models.LargeInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.LargeInstanceResource>> UpdateAsync(Azure.ResourceManager.LargeInstance.Models.LargeInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LargeStorageInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource>, System.Collections.IEnumerable
    {
        protected LargeStorageInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string azureLargeStorageInstanceName, Azure.ResourceManager.LargeInstance.LargeStorageInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string azureLargeStorageInstanceName, Azure.ResourceManager.LargeInstance.LargeStorageInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string azureLargeStorageInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string azureLargeStorageInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource> Get(string azureLargeStorageInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource>> GetAsync(string azureLargeStorageInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource> GetIfExists(string azureLargeStorageInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource>> GetIfExistsAsync(string azureLargeStorageInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LargeStorageInstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.LargeStorageInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.LargeStorageInstanceData>
    {
        public LargeStorageInstanceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LargeInstance.LargeStorageInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.LargeStorageInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.LargeStorageInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LargeInstance.LargeStorageInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.LargeStorageInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.LargeStorageInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.LargeStorageInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LargeStorageInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.LargeStorageInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.LargeStorageInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LargeStorageInstanceResource() { }
        public virtual Azure.ResourceManager.LargeInstance.LargeStorageInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureLargeStorageInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.LargeInstance.LargeStorageInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.LargeStorageInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.LargeStorageInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LargeInstance.LargeStorageInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.LargeStorageInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.LargeStorageInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.LargeStorageInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource> Update(Azure.ResourceManager.LargeInstance.Models.LargeStorageInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource>> UpdateAsync(Azure.ResourceManager.LargeInstance.Models.LargeStorageInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.LargeInstance.Mocking
{
    public partial class MockableLargeInstanceArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableLargeInstanceArmClient() { }
        public virtual Azure.ResourceManager.LargeInstance.LargeInstanceResource GetLargeInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource GetLargeStorageInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableLargeInstanceResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableLargeInstanceResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.LargeInstanceResource> GetLargeInstance(string azureLargeInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.LargeInstanceResource>> GetLargeInstanceAsync(string azureLargeInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LargeInstance.LargeInstanceCollection GetLargeInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource> GetLargeStorageInstance(string azureLargeStorageInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource>> GetLargeStorageInstanceAsync(string azureLargeStorageInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LargeInstance.LargeStorageInstanceCollection GetLargeStorageInstances() { throw null; }
    }
    public partial class MockableLargeInstanceSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableLargeInstanceSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.LargeInstance.LargeInstanceResource> GetLargeInstances(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LargeInstance.LargeInstanceResource> GetLargeInstancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource> GetLargeStorageInstances(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LargeInstance.LargeStorageInstanceResource> GetLargeStorageInstancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.LargeInstance.Models
{
    public static partial class ArmLargeInstanceModelFactory
    {
        public static Azure.ResourceManager.LargeInstance.LargeInstanceData LargeInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.LargeInstance.Models.LargeInstanceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceDisk LargeInstanceDisk(string name = null, int? diskSizeInGB = default(int?), int? lun = default(int?)) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceNetworkProfile LargeInstanceNetworkProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.LargeInstance.Models.LargeInstanceIPAddress> networkInterfaces = null, string circuitId = null) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstancePatch LargeInstancePatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceProperties LargeInstanceProperties(Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareProfile hardwareProfile = null, Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProfile storageProfile = null, Azure.ResourceManager.LargeInstance.Models.LargeInstanceOSProfile osProfile = null, Azure.ResourceManager.LargeInstance.Models.LargeInstanceNetworkProfile networkProfile = null, string largeInstanceId = null, Azure.ResourceManager.LargeInstance.Models.LargeInstancePowerState? powerState = default(Azure.ResourceManager.LargeInstance.Models.LargeInstancePowerState?), string proximityPlacementGroup = null, string hardwareRevision = null, Azure.ResourceManager.LargeInstance.Models.LargeInstanceProvisioningState? provisioningState = default(Azure.ResourceManager.LargeInstance.Models.LargeInstanceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProfile LargeInstanceStorageProfile(string nfsIPAddress = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LargeInstance.Models.LargeInstanceDisk> osDisk = null) { throw null; }
        public static Azure.ResourceManager.LargeInstance.LargeStorageInstanceData LargeStorageInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.LargeStorageInstancePatch LargeStorageInstancePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
    }
    public partial class LargeInstanceDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceDisk>
    {
        public LargeInstanceDisk() { }
        public int? DiskSizeInGB { get { throw null; } set { } }
        public int? Lun { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstanceDisk JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstanceDisk PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LargeInstance.Models.LargeInstanceDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LargeInstance.Models.LargeInstanceDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LargeInstanceForcePowerState : System.IEquatable<Azure.ResourceManager.LargeInstance.Models.LargeInstanceForcePowerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LargeInstanceForcePowerState(string value) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceForcePowerState Active { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceForcePowerState Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LargeInstance.Models.LargeInstanceForcePowerState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LargeInstance.Models.LargeInstanceForcePowerState left, Azure.ResourceManager.LargeInstance.Models.LargeInstanceForcePowerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.LargeInstance.Models.LargeInstanceForcePowerState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.LargeInstance.Models.LargeInstanceForcePowerState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LargeInstance.Models.LargeInstanceForcePowerState left, Azure.ResourceManager.LargeInstance.Models.LargeInstanceForcePowerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LargeInstanceForceState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceForceState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceForceState>
    {
        public LargeInstanceForceState() { }
        public Azure.ResourceManager.LargeInstance.Models.LargeInstanceForcePowerState? ForceState { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstanceForceState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstanceForceState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LargeInstance.Models.LargeInstanceForceState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceForceState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceForceState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LargeInstance.Models.LargeInstanceForceState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceForceState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceForceState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceForceState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LargeInstanceHardwareProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareProfile>
    {
        public LargeInstanceHardwareProfile() { }
        public Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareTypeName? HardwareType { get { throw null; } set { } }
        public Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName? LargeInstanceSize { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LargeInstanceHardwareTypeName : System.IEquatable<Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareTypeName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LargeInstanceHardwareTypeName(string value) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareTypeName CiscoUcs { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareTypeName Hpe { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareTypeName SDFlex { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareTypeName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareTypeName left, Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareTypeName right) { throw null; }
        public static implicit operator Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareTypeName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareTypeName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareTypeName left, Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareTypeName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LargeInstanceIPAddress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceIPAddress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceIPAddress>
    {
        public LargeInstanceIPAddress() { }
        public string IPAddress { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstanceIPAddress JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstanceIPAddress PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LargeInstance.Models.LargeInstanceIPAddress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceIPAddress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceIPAddress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LargeInstance.Models.LargeInstanceIPAddress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceIPAddress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceIPAddress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceIPAddress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LargeInstanceNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceNetworkProfile>
    {
        public LargeInstanceNetworkProfile() { }
        public string CircuitId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.LargeInstance.Models.LargeInstanceIPAddress> NetworkInterfaces { get { throw null; } }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstanceNetworkProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstanceNetworkProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LargeInstance.Models.LargeInstanceNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LargeInstance.Models.LargeInstanceNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LargeInstanceOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceOSProfile>
    {
        public LargeInstanceOSProfile() { }
        public string ComputerName { get { throw null; } set { } }
        public string OSType { get { throw null; } set { } }
        public string SshPublicKey { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstanceOSProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstanceOSProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LargeInstance.Models.LargeInstanceOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LargeInstance.Models.LargeInstanceOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LargeInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstancePatch>
    {
        public LargeInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstancePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstancePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LargeInstance.Models.LargeInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LargeInstance.Models.LargeInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LargeInstancePowerState : System.IEquatable<Azure.ResourceManager.LargeInstance.Models.LargeInstancePowerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LargeInstancePowerState(string value) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstancePowerState Restarting { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstancePowerState Started { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstancePowerState Starting { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstancePowerState Stopped { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstancePowerState Stopping { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstancePowerState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LargeInstance.Models.LargeInstancePowerState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LargeInstance.Models.LargeInstancePowerState left, Azure.ResourceManager.LargeInstance.Models.LargeInstancePowerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.LargeInstance.Models.LargeInstancePowerState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.LargeInstance.Models.LargeInstancePowerState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LargeInstance.Models.LargeInstancePowerState left, Azure.ResourceManager.LargeInstance.Models.LargeInstancePowerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LargeInstanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceProperties>
    {
        public LargeInstanceProperties() { }
        public Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareProfile HardwareProfile { get { throw null; } set { } }
        public string HardwareRevision { get { throw null; } set { } }
        public string LargeInstanceId { get { throw null; } set { } }
        public Azure.ResourceManager.LargeInstance.Models.LargeInstanceNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LargeInstance.Models.LargeInstanceOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LargeInstance.Models.LargeInstancePowerState? PowerState { get { throw null; } set { } }
        public Azure.ResourceManager.LargeInstance.Models.LargeInstanceProvisioningState? ProvisioningState { get { throw null; } }
        public string ProximityPlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProfile StorageProfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstanceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstanceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LargeInstance.Models.LargeInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LargeInstance.Models.LargeInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LargeInstanceProvisioningState : System.IEquatable<Azure.ResourceManager.LargeInstance.Models.LargeInstanceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LargeInstanceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LargeInstance.Models.LargeInstanceProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LargeInstance.Models.LargeInstanceProvisioningState left, Azure.ResourceManager.LargeInstance.Models.LargeInstanceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.LargeInstance.Models.LargeInstanceProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.LargeInstance.Models.LargeInstanceProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LargeInstance.Models.LargeInstanceProvisioningState left, Azure.ResourceManager.LargeInstance.Models.LargeInstanceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LargeInstanceSizeName : System.IEquatable<Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LargeInstanceSizeName(string value) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S112 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S144 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S144m { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S192 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S192m { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S192xm { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S224 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S224m { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S224om { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S224oo { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S224oom { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S224ooo { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S224se { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S384 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S384m { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S384xm { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S384xxm { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S448 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S448m { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S448om { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S448oo { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S448oom { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S448ooo { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S448se { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S576m { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S576xm { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S672 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S672m { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S672om { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S672oo { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S672oom { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S672ooo { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S72 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S72m { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S768 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S768m { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S768xm { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S896 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S896m { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S896om { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S896oo { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S896oom { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S896ooo { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S96 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName S960m { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName left, Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName right) { throw null; }
        public static implicit operator Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName left, Azure.ResourceManager.LargeInstance.Models.LargeInstanceSizeName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LargeInstanceStorageBillingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageBillingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageBillingProperties>
    {
        public LargeInstanceStorageBillingProperties() { }
        public string BillingMode { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageBillingProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageBillingProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageBillingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageBillingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageBillingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageBillingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageBillingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageBillingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageBillingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LargeInstanceStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProfile>
    {
        public LargeInstanceStorageProfile() { }
        public string NfsIPAddress { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.LargeInstance.Models.LargeInstanceDisk> OSDisk { get { throw null; } }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LargeInstanceStorageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProperties>
    {
        public LargeInstanceStorageProperties() { }
        public string Generation { get { throw null; } set { } }
        public Azure.ResourceManager.LargeInstance.Models.LargeInstanceHardwareTypeName? HardwareType { get { throw null; } set { } }
        public string OfferingType { get { throw null; } set { } }
        public Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageBillingProperties StorageBillingProperties { get { throw null; } set { } }
        public string StorageType { get { throw null; } set { } }
        public string WorkloadType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LargeStorageInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeStorageInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeStorageInstancePatch>
    {
        public LargeStorageInstancePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeStorageInstancePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeStorageInstancePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LargeInstance.Models.LargeStorageInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeStorageInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeStorageInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LargeInstance.Models.LargeStorageInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeStorageInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeStorageInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeStorageInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LargeStorageInstanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProperties>
    {
        public LargeStorageInstanceProperties() { }
        public string AzureLargeStorageInstanceUniqueIdentifier { get { throw null; } set { } }
        public Azure.ResourceManager.LargeInstance.Models.LargeInstanceStorageProperties StorageProperties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LargeStorageInstanceProvisioningState : System.IEquatable<Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LargeStorageInstanceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProvisioningState left, Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProvisioningState left, Azure.ResourceManager.LargeInstance.Models.LargeStorageInstanceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
