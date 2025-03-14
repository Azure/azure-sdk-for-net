namespace Azure.ResourceManager.DurableTask
{
    public static partial class DurableTaskExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DurableTask.SchedulerResource> GetScheduler(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.SchedulerResource>> GetSchedulerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string schedulerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DurableTask.SchedulerResource GetSchedulerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DurableTask.SchedulerCollection GetSchedulers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DurableTask.SchedulerResource> GetSchedulers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DurableTask.SchedulerResource> GetSchedulersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DurableTask.TaskHubResource GetTaskHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.TaskHubResource> GetTaskHub(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.TaskHubResource>> GetTaskHubAsync(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DurableTask.TaskHubCollection GetTaskHubs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.SchedulerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.SchedulerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.SchedulerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.SchedulerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DurableTask.SchedulerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.SchedulerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.SchedulerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.SchedulerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.SchedulerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.SchedulerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.SchedulerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.SchedulerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.SchedulerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.SchedulerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.SchedulerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TaskHubCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DurableTask.TaskHubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DurableTask.TaskHubResource>, System.Collections.IEnumerable
    {
        protected TaskHubCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.TaskHubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string taskHubName, Azure.ResourceManager.DurableTask.TaskHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.TaskHubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string taskHubName, Azure.ResourceManager.DurableTask.TaskHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.TaskHubResource> Get(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DurableTask.TaskHubResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DurableTask.TaskHubResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.TaskHubResource>> GetAsync(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DurableTask.TaskHubResource> GetIfExists(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DurableTask.TaskHubResource>> GetIfExistsAsync(string taskHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DurableTask.TaskHubResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DurableTask.TaskHubResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DurableTask.TaskHubResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DurableTask.TaskHubResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TaskHubData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.TaskHubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.TaskHubData>
    {
        public TaskHubData() { }
        public Azure.ResourceManager.DurableTask.Models.TaskHubProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.TaskHubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.TaskHubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.TaskHubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.TaskHubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.TaskHubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.TaskHubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.TaskHubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TaskHubResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.TaskHubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.TaskHubData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TaskHubResource() { }
        public virtual Azure.ResourceManager.DurableTask.TaskHubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string schedulerName, string taskHubName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DurableTask.TaskHubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DurableTask.TaskHubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DurableTask.TaskHubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.TaskHubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.TaskHubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.TaskHubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.TaskHubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.TaskHubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.TaskHubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.TaskHubResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.TaskHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DurableTask.TaskHubResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DurableTask.TaskHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DurableTask.Mocking
{
    public partial class MockableDurableTaskArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDurableTaskArmClient() { }
        public virtual Azure.ResourceManager.DurableTask.SchedulerResource GetSchedulerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DurableTask.TaskHubResource GetTaskHubResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public static Azure.ResourceManager.DurableTask.SchedulerData SchedulerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DurableTask.Models.SchedulerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.SchedulerProperties SchedulerProperties(Azure.ResourceManager.DurableTask.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.DurableTask.Models.ProvisioningState?), string endpoint = null, System.Collections.Generic.IEnumerable<string> ipAllowlist = null, Azure.ResourceManager.DurableTask.Models.SchedulerSku sku = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.SchedulerSku SchedulerSku(string name = null, int? capacity = default(int?), Azure.ResourceManager.DurableTask.Models.RedundancyState? redundancyState = default(Azure.ResourceManager.DurableTask.Models.RedundancyState?)) { throw null; }
        public static Azure.ResourceManager.DurableTask.TaskHubData TaskHubData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DurableTask.Models.TaskHubProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.TaskHubProperties TaskHubProperties(Azure.ResourceManager.DurableTask.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.DurableTask.Models.ProvisioningState?), System.Uri dashboardUri = null) { throw null; }
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
    public readonly partial struct RedundancyState : System.IEquatable<Azure.ResourceManager.DurableTask.Models.RedundancyState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedundancyState(string value) { throw null; }
        public static Azure.ResourceManager.DurableTask.Models.RedundancyState None { get { throw null; } }
        public static Azure.ResourceManager.DurableTask.Models.RedundancyState Zone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DurableTask.Models.RedundancyState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DurableTask.Models.RedundancyState left, Azure.ResourceManager.DurableTask.Models.RedundancyState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DurableTask.Models.RedundancyState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DurableTask.Models.RedundancyState left, Azure.ResourceManager.DurableTask.Models.RedundancyState right) { throw null; }
        public override string ToString() { throw null; }
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
        public SchedulerSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DurableTask.Models.RedundancyState? RedundancyState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.SchedulerSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.SchedulerSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.SchedulerSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.SchedulerSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.SchedulerSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TaskHubProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.TaskHubProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.TaskHubProperties>
    {
        public TaskHubProperties() { }
        public System.Uri DashboardUri { get { throw null; } }
        public Azure.ResourceManager.DurableTask.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.TaskHubProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.TaskHubProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DurableTask.Models.TaskHubProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DurableTask.Models.TaskHubProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.TaskHubProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.TaskHubProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DurableTask.Models.TaskHubProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
