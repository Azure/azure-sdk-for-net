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
        public static Azure.ResourceManager.DurableTask.DurableTaskHubResource GetDurableTaskHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyResource GetDurableTaskRetentionPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource> GetDurableTaskScheduler(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource>> GetDurableTaskSchedulerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource GetDurableTaskSchedulerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DurableTask.DurableTaskSchedulerCollection GetDurableTaskSchedulers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource> GetDurableTaskSchedulers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource> GetDurableTaskSchedulersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DurableTaskHubCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DurableTask.DurableTaskHubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DurableTask.DurableTaskHubResource>, System.Collections.IEnumerable
    {
        protected DurableTaskHubCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.DurableTaskHubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string taskHubName, Azure.ResourceManager.DurableTask.DurableTaskHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.DurableTaskHubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string taskHubName, Azure.ResourceManager.DurableTask.DurableTaskHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskHubResource> Get(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DurableTask.DurableTaskHubResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DurableTask.DurableTaskHubResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskHubResource>> GetAsync(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DurableTask.DurableTaskHubResource> GetIfExists(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DurableTask.DurableTaskHubResource>> GetIfExistsAsync(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DurableTask.DurableTaskHubResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DurableTask.DurableTaskHubResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DurableTask.DurableTaskHubResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DurableTask.DurableTaskHubResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DurableTaskHubData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskHubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskHubData>
    {
        public DurableTaskHubData() { }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.DurableTaskHubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskHubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskHubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.DurableTaskHubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskHubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskHubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskHubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DurableTaskHubResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskHubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskHubData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DurableTaskHubResource() { }
        public virtual Azure.ResourceManager.DurableTask.DurableTaskHubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string schedulerName, string taskHubName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskHubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskHubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DurableTask.DurableTaskHubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskHubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskHubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.DurableTaskHubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskHubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskHubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskHubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.DurableTaskHubResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.DurableTaskHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.DurableTaskHubResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.DurableTaskHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DurableTaskRetentionPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData>
    {
        public DurableTaskRetentionPolicyData() { }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DurableTaskRetentionPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DurableTaskRetentionPolicyResource() { }
        public virtual Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string schedulerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DurableTaskSchedulerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource>, System.Collections.IEnumerable
    {
        protected DurableTaskSchedulerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string schedulerName, Azure.ResourceManager.DurableTask.DurableTaskSchedulerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string schedulerName, Azure.ResourceManager.DurableTask.DurableTaskSchedulerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource> Get(string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource>> GetAsync(string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource> GetIfExists(string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource>> GetIfExistsAsync(string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DurableTaskSchedulerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerData>
    {
        public DurableTaskSchedulerData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.DurableTaskSchedulerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.DurableTaskSchedulerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DurableTaskSchedulerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DurableTaskSchedulerResource() { }
        public virtual Azure.ResourceManager.DurableTask.DurableTaskSchedulerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string schedulerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskHubResource> GetDurableTaskHub(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskHubResource>> GetDurableTaskHubAsync(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DurableTask.DurableTaskHubCollection GetDurableTaskHubs() { throw null; }
        public virtual Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyResource GetDurableTaskRetentionPolicy() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DurableTask.DurableTaskSchedulerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.DurableTaskSchedulerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DurableTask.Mocking
{
    public partial class MockableDurableTaskArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDurableTaskArmClient() { }
        public virtual Azure.ResourceManager.DurableTask.DurableTaskHubResource GetDurableTaskHubResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyResource GetDurableTaskRetentionPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource GetDurableTaskSchedulerResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDurableTaskResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDurableTaskResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource> GetDurableTaskScheduler(string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource>> GetDurableTaskSchedulerAsync(string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DurableTask.DurableTaskSchedulerCollection GetDurableTaskSchedulers() { throw null; }
    }
    public partial class MockableDurableTaskSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDurableTaskSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource> GetDurableTaskSchedulers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource> GetDurableTaskSchedulersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DurableTask.Models
{
    public static partial class ArmDurableTaskModelFactory
    {
        public static Azure.ResourceManager.DurableTask.DurableTaskHubData DurableTaskHubData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties DurableTaskHubProperties(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState? provisioningState = default(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState?), System.Uri dashboardUri = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData DurableTaskRetentionPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyProperties DurableTaskRetentionPolicyProperties(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState? provisioningState = default(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyDetails> retentionPolicies = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.DurableTaskSchedulerData DurableTaskSchedulerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatchProperties DurableTaskSchedulerPatchProperties(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState? provisioningState = default(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState?), string endpoint = null, System.Collections.Generic.IEnumerable<string> ipAllowlist = null, Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate sku = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties DurableTaskSchedulerProperties(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState? provisioningState = default(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState?), string endpoint = null, System.Collections.Generic.IEnumerable<string> ipAllowlist = null, Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku sku = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku DurableTaskSchedulerSku(string name = null, int? capacity = default(int?), Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState? redundancyState = default(Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState?)) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate DurableTaskSchedulerSkuUpdate(string name = null, int? capacity = default(int?), Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState? redundancyState = default(Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState?)) { throw null; }
    }
    public partial class DurableTaskHubProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties>
    {
        public DurableTaskHubProperties() { }
        public System.Uri DashboardUri { get { throw null; } }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DurableTaskProvisioningState : System.IEquatable<Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DurableTaskProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState left, Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState left, Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DurableTaskPurgeableOrchestrationState : System.IEquatable<Azure.ResourceManager.DurableTask.Models.DurableTaskPurgeableOrchestrationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DurableTaskPurgeableOrchestrationState(string value) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskPurgeableOrchestrationState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskPurgeableOrchestrationState Completed { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskPurgeableOrchestrationState Failed { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskPurgeableOrchestrationState Terminated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DurableTask.Models.DurableTaskPurgeableOrchestrationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DurableTask.Models.DurableTaskPurgeableOrchestrationState left, Azure.ResourceManager.DurableTask.Models.DurableTaskPurgeableOrchestrationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.DurableTaskPurgeableOrchestrationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DurableTask.Models.DurableTaskPurgeableOrchestrationState left, Azure.ResourceManager.DurableTask.Models.DurableTaskPurgeableOrchestrationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DurableTaskResourceRedundancyState : System.IEquatable<Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DurableTaskResourceRedundancyState(string value) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState None { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState Zone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState left, Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState left, Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DurableTaskRetentionPolicyDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyDetails>
    {
        public DurableTaskRetentionPolicyDetails(int retentionPeriodInDays) { }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskPurgeableOrchestrationState? OrchestrationState { get { throw null; } set { } }
        public int RetentionPeriodInDays { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DurableTaskRetentionPolicyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyProperties>
    {
        public DurableTaskRetentionPolicyProperties() { }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyDetails> RetentionPolicies { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DurableTaskSchedulerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatch>
    {
        public DurableTaskSchedulerPatch() { }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DurableTaskSchedulerPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatchProperties>
    {
        public DurableTaskSchedulerPatchProperties() { }
        public string Endpoint { get { throw null; } }
        public System.Collections.Generic.IList<string> IPAllowlist { get { throw null; } }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate Sku { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DurableTaskSchedulerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties>
    {
        public DurableTaskSchedulerProperties(System.Collections.Generic.IEnumerable<string> ipAllowlist, Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku sku) { }
        public string Endpoint { get { throw null; } }
        public System.Collections.Generic.IList<string> IPAllowlist { get { throw null; } }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku Sku { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DurableTaskSchedulerSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku>
    {
        public DurableTaskSchedulerSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState? RedundancyState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DurableTaskSchedulerSkuUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate>
    {
        public DurableTaskSchedulerSkuUpdate() { }
        public int? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState? RedundancyState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
