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
        public static Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource GetDurableTaskPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyResource GetDurableTaskRetentionPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource> GetDurableTaskScheduler(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerResource>> GetDurableTaskSchedulerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResource GetDurableTaskSchedulerPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DurableTaskPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected DurableTaskPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DurableTaskPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData>
    {
        public DurableTaskPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DurableTaskPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DurableTaskPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string schedulerName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DurableTaskRetentionPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData>
    {
        public DurableTaskRetentionPolicyData() { }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DurableTask.DurableTaskSchedulerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.DurableTaskSchedulerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DurableTaskSchedulerPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DurableTaskSchedulerPrivateLinkResource() { }
        public virtual Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string schedulerName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DurableTaskSchedulerPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected DurableTaskSchedulerPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DurableTaskSchedulerPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceData>
    {
        internal DurableTaskSchedulerPrivateLinkResourceData() { }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkResourceProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource> GetPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource>> GetPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResource> GetSchedulerPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResource>> GetSchedulerPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceCollection GetSchedulerPrivateLinkResources() { throw null; }
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
        public virtual Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionResource GetDurableTaskPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyResource GetDurableTaskRetentionPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResource GetDurableTaskSchedulerPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public static Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData DurableTaskPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProperties DurableTaskPrivateEndpointConnectionProperties(System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkResourceProperties DurableTaskPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.DurableTaskRetentionPolicyData DurableTaskRetentionPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyProperties DurableTaskRetentionPolicyProperties(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState? provisioningState = default(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyDetails> retentionPolicies = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.DurableTaskSchedulerData DurableTaskSchedulerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatch DurableTaskSchedulerPatch(Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatchProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatchProperties DurableTaskSchedulerPatchProperties(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState? provisioningState, string endpoint, System.Collections.Generic.IEnumerable<string> ipAllowlist, Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate sku) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatchProperties DurableTaskSchedulerPatchProperties(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState? provisioningState = default(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState?), string endpoint = null, System.Collections.Generic.IEnumerable<string> ipAllowlist = null, Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate sku = null, Azure.ResourceManager.DurableTask.Models.DurableTaskPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.DurableTask.Models.DurableTaskPublicNetworkAccess?)) { throw null; }
        public static Azure.ResourceManager.DurableTask.DurableTaskSchedulerPrivateLinkResourceData DurableTaskSchedulerPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties DurableTaskSchedulerProperties(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState? provisioningState, string endpoint, System.Collections.Generic.IEnumerable<string> ipAllowlist, Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku sku) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties DurableTaskSchedulerProperties(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState? provisioningState = default(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState?), string endpoint = null, System.Collections.Generic.IEnumerable<string> ipAllowlist = null, Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku sku = null, Azure.ResourceManager.DurableTask.Models.DurableTaskPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.DurableTask.Models.DurableTaskPublicNetworkAccess?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku DurableTaskSchedulerSku(Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuName name = default(Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuName), int? capacity = default(int?), Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState? redundancyState = default(Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState?)) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate DurableTaskSchedulerSkuUpdate(Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuName? name = default(Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuName?), int? capacity = default(int?), Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState? redundancyState = default(Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState?)) { throw null; }
    }
    public partial class DurableTaskHubProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties>
    {
        public DurableTaskHubProperties() { }
        public System.Uri DashboardUri { get { throw null; } }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskHubProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DurableTaskPrivateEndpointConnectionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatch>
    {
        public DurableTaskPrivateEndpointConnectionPatch() { }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatchProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DurableTaskPrivateEndpointConnectionPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatchProperties>
    {
        public DurableTaskPrivateEndpointConnectionPatchProperties() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DurableTaskPrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProperties>
    {
        public DurableTaskPrivateEndpointConnectionProperties(Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkServiceConnectionState privateLinkServiceConnectionState) { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DurableTaskPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DurableTaskPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DurableTaskPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DurableTaskPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointServiceConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointServiceConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DurableTaskPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkResourceProperties>
    {
        internal DurableTaskPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DurableTaskPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkServiceConnectionState>
    {
        public DurableTaskPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState left, Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState left, Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DurableTaskPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.DurableTask.Models.DurableTaskPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DurableTaskPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DurableTask.Models.DurableTaskPublicNetworkAccess other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DurableTask.Models.DurableTaskPublicNetworkAccess left, Azure.ResourceManager.DurableTask.Models.DurableTaskPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.DurableTaskPublicNetworkAccess (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.DurableTaskPublicNetworkAccess? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DurableTask.Models.DurableTaskPublicNetworkAccess left, Azure.ResourceManager.DurableTask.Models.DurableTaskPublicNetworkAccess right) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DurableTask.Models.DurableTaskPurgeableOrchestrationState left, Azure.ResourceManager.DurableTask.Models.DurableTaskPurgeableOrchestrationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.DurableTaskPurgeableOrchestrationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.DurableTaskPurgeableOrchestrationState? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState left, Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState left, Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DurableTaskRetentionPolicyDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyDetails>
    {
        public DurableTaskRetentionPolicyDetails(int retentionPeriodInDays) { }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskPurgeableOrchestrationState? OrchestrationState { get { throw null; } set { } }
        public int RetentionPeriodInDays { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskRetentionPolicyProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.DurableTask.Models.DurableTaskPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DurableTask.DurableTaskPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DurableTaskSchedulerSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku>
    {
        public DurableTaskSchedulerSku(Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuName name) { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState? RedundancyState { get { throw null; } }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DurableTaskSchedulerSkuName : System.IEquatable<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DurableTaskSchedulerSkuName(string value) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuName Consumption { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuName Dedicated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuName left, Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuName left, Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DurableTaskSchedulerSkuUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate>
    {
        public DurableTaskSchedulerSkuUpdate() { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuName? Name { get { throw null; } set { } }
        public Azure.ResourceManager.DurableTask.Models.DurableTaskResourceRedundancyState? RedundancyState { get { throw null; } }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.DurableTaskSchedulerSkuUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
