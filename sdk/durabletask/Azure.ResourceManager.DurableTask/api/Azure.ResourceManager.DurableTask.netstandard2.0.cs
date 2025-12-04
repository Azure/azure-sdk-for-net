namespace Azure.ResourceManager.DurableTask
{
    public partial class AzureResourceManagerDurableTaskContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDurableTaskContext() { }
        public static Azure.ResourceManager.DurableTask.AzureResourceManagerDurableTaskContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class DurableTaskExtensions
    {
        public static Azure.ResourceManager.DurableTask.RetentionPolicyResource GetRetentionPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DurableTask.SchedulerResource> GetScheduler(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.SchedulerResource>> GetSchedulerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DurableTask.SchedulerResource GetSchedulerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DurableTask.SchedulerCollection GetSchedulers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DurableTask.SchedulerResource> GetSchedulers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DurableTask.SchedulerResource> GetSchedulersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DurableTask.SchedulerTaskHubResource GetSchedulerTaskHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class RetentionPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.RetentionPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.RetentionPolicyData>
    {
        public RetentionPolicyData() { }
        public Azure.ResourceManager.DurableTask.Models.RetentionPolicyProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.RetentionPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.RetentionPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.RetentionPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.RetentionPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.RetentionPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.RetentionPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.RetentionPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RetentionPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.RetentionPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.RetentionPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RetentionPolicyResource() { }
        public virtual Azure.ResourceManager.DurableTask.RetentionPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.RetentionPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.RetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.RetentionPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.RetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string schedulerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.RetentionPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.RetentionPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DurableTask.RetentionPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.RetentionPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.RetentionPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.RetentionPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.RetentionPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.RetentionPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.RetentionPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.RetentionPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.RetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.RetentionPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.RetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SchedulerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DurableTask.SchedulerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DurableTask.SchedulerResource>, System.Collections.IEnumerable
    {
        protected SchedulerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.SchedulerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string schedulerName, Azure.ResourceManager.DurableTask.SchedulerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.SchedulerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string schedulerName, Azure.ResourceManager.DurableTask.SchedulerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.SchedulerResource> Get(string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DurableTask.SchedulerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DurableTask.SchedulerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.SchedulerResource>> GetAsync(string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DurableTask.SchedulerResource> GetIfExists(string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DurableTask.SchedulerResource>> GetIfExistsAsync(string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DurableTask.SchedulerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DurableTask.SchedulerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DurableTask.SchedulerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DurableTask.SchedulerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SchedulerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.SchedulerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.SchedulerData>
    {
        public SchedulerData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DurableTask.Models.SchedulerProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.SchedulerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.SchedulerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.SchedulerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.SchedulerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.SchedulerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.SchedulerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.SchedulerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchedulerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.SchedulerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.SchedulerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SchedulerResource() { }
        public virtual Azure.ResourceManager.DurableTask.SchedulerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.SchedulerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.SchedulerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string schedulerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.SchedulerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.SchedulerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DurableTask.RetentionPolicyResource GetRetentionPolicy() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.SchedulerTaskHubResource> GetSchedulerTaskHub(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.SchedulerTaskHubResource>> GetSchedulerTaskHubAsync(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DurableTask.SchedulerTaskHubCollection GetSchedulerTaskHubs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.SchedulerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.SchedulerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.SchedulerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.SchedulerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DurableTask.SchedulerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.SchedulerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.SchedulerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.SchedulerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.SchedulerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.SchedulerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.SchedulerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.SchedulerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.Models.SchedulerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.SchedulerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.Models.SchedulerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SchedulerTaskHubCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DurableTask.SchedulerTaskHubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DurableTask.SchedulerTaskHubResource>, System.Collections.IEnumerable
    {
        protected SchedulerTaskHubCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.SchedulerTaskHubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string taskHubName, Azure.ResourceManager.DurableTask.SchedulerTaskHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.SchedulerTaskHubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string taskHubName, Azure.ResourceManager.DurableTask.SchedulerTaskHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.SchedulerTaskHubResource> Get(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DurableTask.SchedulerTaskHubResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DurableTask.SchedulerTaskHubResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.SchedulerTaskHubResource>> GetAsync(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DurableTask.SchedulerTaskHubResource> GetIfExists(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DurableTask.SchedulerTaskHubResource>> GetIfExistsAsync(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DurableTask.SchedulerTaskHubResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DurableTask.SchedulerTaskHubResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DurableTask.SchedulerTaskHubResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DurableTask.SchedulerTaskHubResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SchedulerTaskHubData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.SchedulerTaskHubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.SchedulerTaskHubData>
    {
        public SchedulerTaskHubData() { }
        public Azure.ResourceManager.DurableTask.Models.SchedulerTaskHubProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.SchedulerTaskHubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.SchedulerTaskHubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.SchedulerTaskHubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.SchedulerTaskHubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.SchedulerTaskHubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.SchedulerTaskHubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.SchedulerTaskHubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchedulerTaskHubResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.SchedulerTaskHubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.SchedulerTaskHubData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SchedulerTaskHubResource() { }
        public virtual Azure.ResourceManager.DurableTask.SchedulerTaskHubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string schedulerName, string taskHubName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.SchedulerTaskHubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.SchedulerTaskHubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DurableTask.SchedulerTaskHubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.SchedulerTaskHubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.SchedulerTaskHubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.SchedulerTaskHubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.SchedulerTaskHubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.SchedulerTaskHubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.SchedulerTaskHubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.SchedulerTaskHubResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.SchedulerTaskHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.SchedulerTaskHubResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.SchedulerTaskHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DurableTask.Mocking
{
    public partial class MockableDurableTaskArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDurableTaskArmClient() { }
        public virtual Azure.ResourceManager.DurableTask.RetentionPolicyResource GetRetentionPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DurableTask.SchedulerResource GetSchedulerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DurableTask.SchedulerTaskHubResource GetSchedulerTaskHubResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDurableTaskResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDurableTaskResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.SchedulerResource> GetScheduler(string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.SchedulerResource>> GetSchedulerAsync(string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DurableTask.SchedulerCollection GetSchedulers() { throw null; }
    }
    public partial class MockableDurableTaskSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDurableTaskSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DurableTask.SchedulerResource> GetSchedulers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DurableTask.SchedulerResource> GetSchedulersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DurableTask.Models
{
    public static partial class ArmDurableTaskModelFactory
    {
        public static Azure.ResourceManager.DurableTask.RetentionPolicyData RetentionPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DurableTask.Models.RetentionPolicyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.RetentionPolicyProperties RetentionPolicyProperties(Azure.ResourceManager.DurableTask.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.DurableTask.Models.ProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DurableTask.Models.RetentionPolicyDetails> retentionPolicies = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.SchedulerData SchedulerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DurableTask.Models.SchedulerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.SchedulerPatchProperties SchedulerPatchProperties(Azure.ResourceManager.DurableTask.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.DurableTask.Models.ProvisioningState?), string endpoint = null, System.Collections.Generic.IEnumerable<string> ipAllowlist = null, Azure.ResourceManager.DurableTask.Models.SchedulerSkuUpdate sku = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.SchedulerProperties SchedulerProperties(Azure.ResourceManager.DurableTask.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.DurableTask.Models.ProvisioningState?), string endpoint = null, System.Collections.Generic.IEnumerable<string> ipAllowlist = null, Azure.ResourceManager.DurableTask.Models.SchedulerSku sku = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.SchedulerSku SchedulerSku(Azure.ResourceManager.DurableTask.Models.SchedulerSkuName name = default(Azure.ResourceManager.DurableTask.Models.SchedulerSkuName), int? capacity = default(int?), Azure.ResourceManager.DurableTask.Models.ResourceRedundancyState? redundancyState = default(Azure.ResourceManager.DurableTask.Models.ResourceRedundancyState?)) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.SchedulerSkuUpdate SchedulerSkuUpdate(Azure.ResourceManager.DurableTask.Models.SchedulerSkuName? name = default(Azure.ResourceManager.DurableTask.Models.SchedulerSkuName?), int? capacity = default(int?), Azure.ResourceManager.DurableTask.Models.ResourceRedundancyState? redundancyState = default(Azure.ResourceManager.DurableTask.Models.ResourceRedundancyState?)) { throw null; }
        public static Azure.ResourceManager.DurableTask.SchedulerTaskHubData SchedulerTaskHubData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DurableTask.Models.SchedulerTaskHubProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.SchedulerTaskHubProperties SchedulerTaskHubProperties(Azure.ResourceManager.DurableTask.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.DurableTask.Models.ProvisioningState?), System.Uri dashboardUri = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.DurableTask.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DurableTask.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DurableTask.Models.ProvisioningState left, Azure.ResourceManager.DurableTask.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DurableTask.Models.ProvisioningState left, Azure.ResourceManager.DurableTask.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurgeableOrchestrationState : System.IEquatable<Azure.ResourceManager.DurableTask.Models.PurgeableOrchestrationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurgeableOrchestrationState(string value) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.PurgeableOrchestrationState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.PurgeableOrchestrationState Completed { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.PurgeableOrchestrationState Failed { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.PurgeableOrchestrationState Terminated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DurableTask.Models.PurgeableOrchestrationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DurableTask.Models.PurgeableOrchestrationState left, Azure.ResourceManager.DurableTask.Models.PurgeableOrchestrationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.PurgeableOrchestrationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DurableTask.Models.PurgeableOrchestrationState left, Azure.ResourceManager.DurableTask.Models.PurgeableOrchestrationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceRedundancyState : System.IEquatable<Azure.ResourceManager.DurableTask.Models.ResourceRedundancyState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceRedundancyState(string value) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.ResourceRedundancyState None { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.ResourceRedundancyState Zone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DurableTask.Models.ResourceRedundancyState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DurableTask.Models.ResourceRedundancyState left, Azure.ResourceManager.DurableTask.Models.ResourceRedundancyState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.ResourceRedundancyState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DurableTask.Models.ResourceRedundancyState left, Azure.ResourceManager.DurableTask.Models.ResourceRedundancyState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RetentionPolicyDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.RetentionPolicyDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.RetentionPolicyDetails>
    {
        public RetentionPolicyDetails(int retentionPeriodInDays) { }
        public Azure.ResourceManager.DurableTask.Models.PurgeableOrchestrationState? OrchestrationState { get { throw null; } set { } }
        public int RetentionPeriodInDays { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.RetentionPolicyDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.RetentionPolicyDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.RetentionPolicyDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.RetentionPolicyDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.RetentionPolicyDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.RetentionPolicyDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.RetentionPolicyDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RetentionPolicyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.RetentionPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.RetentionPolicyProperties>
    {
        public RetentionPolicyProperties() { }
        public Azure.ResourceManager.DurableTask.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DurableTask.Models.RetentionPolicyDetails> RetentionPolicies { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.RetentionPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.RetentionPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.RetentionPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.RetentionPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.RetentionPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.RetentionPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.RetentionPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchedulerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.SchedulerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerPatch>
    {
        public SchedulerPatch() { }
        public Azure.ResourceManager.DurableTask.Models.SchedulerPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.SchedulerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.SchedulerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.SchedulerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.SchedulerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchedulerPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.SchedulerPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerPatchProperties>
    {
        public SchedulerPatchProperties() { }
        public string Endpoint { get { throw null; } }
        public System.Collections.Generic.IList<string> IPAllowlist { get { throw null; } }
        public Azure.ResourceManager.DurableTask.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DurableTask.Models.SchedulerSkuUpdate Sku { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.SchedulerPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.SchedulerPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.SchedulerPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.SchedulerPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchedulerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.SchedulerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerProperties>
    {
        public SchedulerProperties(System.Collections.Generic.IEnumerable<string> ipAllowlist, Azure.ResourceManager.DurableTask.Models.SchedulerSku sku) { }
        public string Endpoint { get { throw null; } }
        public System.Collections.Generic.IList<string> IPAllowlist { get { throw null; } }
        public Azure.ResourceManager.DurableTask.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DurableTask.Models.SchedulerSku Sku { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.SchedulerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.SchedulerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.SchedulerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.SchedulerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchedulerSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.SchedulerSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerSku>
    {
        public SchedulerSku(Azure.ResourceManager.DurableTask.Models.SchedulerSkuName name) { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.DurableTask.Models.SchedulerSkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.DurableTask.Models.ResourceRedundancyState? RedundancyState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.SchedulerSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.SchedulerSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.SchedulerSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.SchedulerSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SchedulerSkuName : System.IEquatable<Azure.ResourceManager.DurableTask.Models.SchedulerSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SchedulerSkuName(string value) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.SchedulerSkuName Consumption { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.SchedulerSkuName Dedicated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DurableTask.Models.SchedulerSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DurableTask.Models.SchedulerSkuName left, Azure.ResourceManager.DurableTask.Models.SchedulerSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.SchedulerSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DurableTask.Models.SchedulerSkuName left, Azure.ResourceManager.DurableTask.Models.SchedulerSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SchedulerSkuUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.SchedulerSkuUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerSkuUpdate>
    {
        public SchedulerSkuUpdate() { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.DurableTask.Models.SchedulerSkuName? Name { get { throw null; } set { } }
        public Azure.ResourceManager.DurableTask.Models.ResourceRedundancyState? RedundancyState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.SchedulerSkuUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.SchedulerSkuUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.SchedulerSkuUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.SchedulerSkuUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerSkuUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerSkuUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerSkuUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchedulerTaskHubProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.SchedulerTaskHubProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerTaskHubProperties>
    {
        public SchedulerTaskHubProperties() { }
        public System.Uri DashboardUri { get { throw null; } }
        public Azure.ResourceManager.DurableTask.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.SchedulerTaskHubProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.SchedulerTaskHubProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.SchedulerTaskHubProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.SchedulerTaskHubProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerTaskHubProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerTaskHubProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerTaskHubProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
