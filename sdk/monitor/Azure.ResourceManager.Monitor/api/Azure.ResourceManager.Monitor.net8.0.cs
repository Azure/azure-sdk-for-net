namespace Azure.ResourceManager.Monitor
{
    public partial class AzureMonitorWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource>, System.Collections.IEnumerable
    {
        protected AzureMonitorWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string azureMonitorWorkspaceName, Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string azureMonitorWorkspaceName, Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource> Get(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource>> GetAsync(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource> GetIfExists(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource>> GetIfExistsAsync(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AzureMonitorWorkspaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData>
    {
        public AzureMonitorWorkspaceData(Azure.Core.AzureLocation location) { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureMonitorWorkspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AzureMonitorWorkspaceResource() { }
        public virtual Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureMonitorWorkspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource> Update(Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource>> UpdateAsync(Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerMonitorContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerMonitorContext() { }
        public static Azure.ResourceManager.Monitor.AzureResourceManagerMonitorContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class MonitorExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource> GetAzureMonitorWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource>> GetAzureMonitorWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource GetAzureMonitorWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.AzureMonitorWorkspaceCollection GetAzureMonitorWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource> GetAzureMonitorWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource> GetAzureMonitorWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.PipelineGroupResource> GetPipelineGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string pipelineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PipelineGroupResource>> GetPipelineGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string pipelineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroupResource GetPipelineGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroupCollection GetPipelineGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.PipelineGroupResource> GetPipelineGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.PipelineGroupResource> GetPipelineGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PipelineGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.PipelineGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PipelineGroupResource>, System.Collections.IEnumerable
    {
        protected PipelineGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.PipelineGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string pipelineGroupName, Azure.ResourceManager.Monitor.PipelineGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.PipelineGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string pipelineGroupName, Azure.ResourceManager.Monitor.PipelineGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string pipelineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string pipelineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PipelineGroupResource> Get(string pipelineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.PipelineGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.PipelineGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PipelineGroupResource>> GetAsync(string pipelineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.PipelineGroupResource> GetIfExists(string pipelineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.PipelineGroupResource>> GetIfExistsAsync(string pipelineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.PipelineGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.PipelineGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.PipelineGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PipelineGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PipelineGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroupData>
    {
        public PipelineGroupData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.PipelineGroupProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PipelineGroupResource() { }
        public virtual Azure.ResourceManager.Monitor.PipelineGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PipelineGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PipelineGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string pipelineGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PipelineGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PipelineGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PipelineGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PipelineGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PipelineGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PipelineGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.PipelineGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.Models.PipelineGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.PipelineGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.Models.PipelineGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Monitor.Mocking
{
    public partial class MockableMonitorArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMonitorArmClient() { }
        public virtual Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource GetAzureMonitorWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Monitor.PipelineGroupResource GetPipelineGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMonitorResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMonitorResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource> GetAzureMonitorWorkspace(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource>> GetAzureMonitorWorkspaceAsync(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.AzureMonitorWorkspaceCollection GetAzureMonitorWorkspaces() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PipelineGroupResource> GetPipelineGroup(string pipelineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PipelineGroupResource>> GetPipelineGroupAsync(string pipelineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.PipelineGroupCollection GetPipelineGroups() { throw null; }
    }
    public partial class MockableMonitorSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMonitorSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource> GetAzureMonitorWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.AzureMonitorWorkspaceResource> GetAzureMonitorWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.PipelineGroupResource> GetPipelineGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.PipelineGroupResource> GetPipelineGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Monitor.Models
{
    public static partial class ArmMonitorModelFactory
    {
        public static Azure.ResourceManager.Monitor.AzureMonitorWorkspaceData AzureMonitorWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspacePatch AzureMonitorWorkspacePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Monitor.Models.Metrics azureMonitorWorkspaceUpdateMetrics = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceProperties AzureMonitorWorkspaceProperties(string accountId = null, Azure.ResourceManager.Monitor.Models.Metrics metrics = null, Azure.ResourceManager.Monitor.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Monitor.Models.ProvisioningState?), Azure.ResourceManager.Monitor.Models.IngestionSettings defaultIngestionSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnection> privateEndpointConnections = null, Azure.ResourceManager.Monitor.Models.PublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Monitor.Models.PublicNetworkAccess?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.IngestionSettings IngestionSettings(string dataCollectionRuleResourceId = null, string dataCollectionEndpointResourceId = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.Metrics Metrics(string prometheusQueryEndpoint = null, string internalId = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnection MonitorPrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Monitor.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkServiceConnectionState MonitorPrivateLinkServiceConnectionState(Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus? status = default(Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus?), string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.NetworkingConfiguration NetworkingConfiguration(Azure.ResourceManager.Monitor.Models.ExternalNetworkingMode externalNetworkingMode = default(Azure.ResourceManager.Monitor.Models.ExternalNetworkingMode), string host = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.NetworkingRoute> routes = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.Pipeline Pipeline(string name = null, Azure.ResourceManager.Monitor.Models.PipelineType type = default(Azure.ResourceManager.Monitor.Models.PipelineType), System.Collections.Generic.IEnumerable<string> receivers = null, System.Collections.Generic.IEnumerable<string> processors = null, System.Collections.Generic.IEnumerable<string> exporters = null) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroupData PipelineGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Monitor.Models.PipelineGroupProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.PipelineGroupPatch PipelineGroupPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Monitor.Models.PipelineGroupUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.PipelineGroupProperties PipelineGroupProperties(int? replicas = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.Receiver> receivers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.Processor> processors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.Exporter> exporters = null, Azure.ResourceManager.Monitor.Models.Service service = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.NetworkingConfiguration> networkingConfigurations = null, Azure.ResourceManager.Monitor.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Monitor.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.PipelineGroupUpdateProperties PipelineGroupUpdateProperties(int? replicas = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.Receiver> receivers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.Processor> processors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.Exporter> exporters = null, Azure.ResourceManager.Monitor.Models.Service service = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.NetworkingConfiguration> networkingConfigurations = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.PrivateEndpointConnectionProperties PrivateEndpointConnectionProperties(System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.SchemaMap SchemaMap(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.RecordMap> recordMap = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.ResourceMap> resourceMap = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.ScopeMap> scopeMap = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.Service Service(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.Pipeline> pipelines = null, string persistencePersistentVolumeName = null) { throw null; }
    }
    public partial class AzureMonitorWorkspaceLogsApiConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsApiConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsApiConfig>
    {
        public AzureMonitorWorkspaceLogsApiConfig(string dataCollectionEndpointUri, string stream, string dataCollectionRule, Azure.ResourceManager.Monitor.Models.SchemaMap schema) { }
        public string DataCollectionEndpointUri { get { throw null; } set { } }
        public string DataCollectionRule { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.SchemaMap Schema { get { throw null; } set { } }
        public string Stream { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsApiConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsApiConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsApiConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsApiConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsApiConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsApiConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsApiConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsApiConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsApiConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureMonitorWorkspaceLogsExporter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsExporter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsExporter>
    {
        public AzureMonitorWorkspaceLogsExporter(Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsApiConfig api) { }
        public Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsApiConfig Api { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.CacheConfiguration Cache { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.ConcurrencyConfiguration Concurrency { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsExporter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsExporter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsExporter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsExporter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsExporter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsExporter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsExporter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsExporter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsExporter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureMonitorWorkspacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspacePatch>
    {
        public AzureMonitorWorkspacePatch() { }
        public Azure.ResourceManager.Monitor.Models.Metrics AzureMonitorWorkspaceUpdateMetrics { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspacePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspacePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureMonitorWorkspaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceProperties>
    {
        public AzureMonitorWorkspaceProperties() { }
        public string AccountId { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.IngestionSettings DefaultIngestionSettings { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.Metrics Metrics { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchProcessor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.BatchProcessor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.BatchProcessor>
    {
        public BatchProcessor() { }
        public int? BatchSize { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Models.BatchProcessor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.BatchProcessor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.BatchProcessor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.BatchProcessor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.BatchProcessor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.BatchProcessor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.BatchProcessor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.BatchProcessor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.BatchProcessor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CacheConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.CacheConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.CacheConfiguration>
    {
        public CacheConfiguration() { }
        public int? MaxStorageUsage { get { throw null; } set { } }
        public int? RetentionPeriod { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Models.CacheConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.CacheConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.CacheConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.CacheConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.CacheConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.CacheConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.CacheConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.CacheConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.CacheConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConcurrencyConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.ConcurrencyConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.ConcurrencyConfiguration>
    {
        public ConcurrencyConfiguration() { }
        public int? BatchQueueSize { get { throw null; } set { } }
        public int? WorkerCount { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Models.ConcurrencyConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.ConcurrencyConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.ConcurrencyConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.ConcurrencyConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.ConcurrencyConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.ConcurrencyConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.ConcurrencyConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.ConcurrencyConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.ConcurrencyConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Exporter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.Exporter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Exporter>
    {
        public Exporter(Azure.ResourceManager.Monitor.Models.ExporterType type, string name) { }
        public Azure.ResourceManager.Monitor.Models.AzureMonitorWorkspaceLogsExporter AzureMonitorWorkspaceLogs { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string TcpUri { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.ExporterType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Models.Exporter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.Exporter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.Exporter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.Exporter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.Exporter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.Exporter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Exporter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Exporter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Exporter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExporterType : System.IEquatable<Azure.ResourceManager.Monitor.Models.ExporterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExporterType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.ExporterType AzureMonitorWorkspaceLogs { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ExporterType PipelineGroup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.ExporterType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.ExporterType left, Azure.ResourceManager.Monitor.Models.ExporterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.ExporterType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.ExporterType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.ExporterType left, Azure.ResourceManager.Monitor.Models.ExporterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExternalNetworkingMode : System.IEquatable<Azure.ResourceManager.Monitor.Models.ExternalNetworkingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExternalNetworkingMode(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.ExternalNetworkingMode LoadBalancerOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.ExternalNetworkingMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.ExternalNetworkingMode left, Azure.ResourceManager.Monitor.Models.ExternalNetworkingMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.ExternalNetworkingMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.ExternalNetworkingMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.ExternalNetworkingMode left, Azure.ResourceManager.Monitor.Models.ExternalNetworkingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IngestionSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.IngestionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.IngestionSettings>
    {
        internal IngestionSettings() { }
        public string DataCollectionEndpointResourceId { get { throw null; } }
        public string DataCollectionRuleResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Models.IngestionSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.IngestionSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.IngestionSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.IngestionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.IngestionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.IngestionSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.IngestionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.IngestionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.IngestionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Metrics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.Metrics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Metrics>
    {
        public Metrics() { }
        public string InternalId { get { throw null; } }
        public string PrometheusQueryEndpoint { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Models.Metrics JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.Metrics PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.Metrics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.Metrics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.Metrics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.Metrics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Metrics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Metrics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Metrics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorPrivateEndpointConnection : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnection>
    {
        internal MonitorPrivateEndpointConnection() { }
        public Azure.ResourceManager.Monitor.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitorPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkServiceConnectionState>
    {
        internal MonitorPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkingConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.NetworkingConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.NetworkingConfiguration>
    {
        public NetworkingConfiguration(Azure.ResourceManager.Monitor.Models.ExternalNetworkingMode externalNetworkingMode, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.NetworkingRoute> routes) { }
        public Azure.ResourceManager.Monitor.Models.ExternalNetworkingMode ExternalNetworkingMode { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.NetworkingRoute> Routes { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Models.NetworkingConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.NetworkingConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.NetworkingConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.NetworkingConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.NetworkingConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.NetworkingConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.NetworkingConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.NetworkingConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.NetworkingConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkingRoute : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.NetworkingRoute>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.NetworkingRoute>
    {
        public NetworkingRoute(string receiver) { }
        public string Path { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public string Receiver { get { throw null; } set { } }
        public string Subdomain { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Models.NetworkingRoute JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.NetworkingRoute PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.NetworkingRoute System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.NetworkingRoute>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.NetworkingRoute>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.NetworkingRoute System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.NetworkingRoute>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.NetworkingRoute>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.NetworkingRoute>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Pipeline : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.Pipeline>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Pipeline>
    {
        public Pipeline(string name, Azure.ResourceManager.Monitor.Models.PipelineType type, System.Collections.Generic.IEnumerable<string> receivers, System.Collections.Generic.IEnumerable<string> exporters) { }
        public System.Collections.Generic.IList<string> Exporters { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Processors { get { throw null; } }
        public System.Collections.Generic.IList<string> Receivers { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.PipelineType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Models.Pipeline JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.Pipeline PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.Pipeline System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.Pipeline>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.Pipeline>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.Pipeline System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Pipeline>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Pipeline>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Pipeline>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.PipelineGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.PipelineGroupPatch>
    {
        public PipelineGroupPatch() { }
        public Azure.ResourceManager.Monitor.Models.PipelineGroupUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Models.PipelineGroupPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.PipelineGroupPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.PipelineGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.PipelineGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.PipelineGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.PipelineGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.PipelineGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.PipelineGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.PipelineGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.PipelineGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.PipelineGroupProperties>
    {
        public PipelineGroupProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.Receiver> receivers, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.Processor> processors, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.Exporter> exporters, Azure.ResourceManager.Monitor.Models.Service service) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.Exporter> Exporters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.NetworkingConfiguration> NetworkingConfigurations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.Processor> Processors { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.Receiver> Receivers { get { throw null; } }
        public int? Replicas { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.Service Service { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Models.PipelineGroupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.PipelineGroupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.PipelineGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.PipelineGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.PipelineGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.PipelineGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.PipelineGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.PipelineGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.PipelineGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineGroupUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.PipelineGroupUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.PipelineGroupUpdateProperties>
    {
        public PipelineGroupUpdateProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.Exporter> Exporters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.NetworkingConfiguration> NetworkingConfigurations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.Processor> Processors { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.Receiver> Receivers { get { throw null; } }
        public int? Replicas { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.Service Service { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Models.PipelineGroupUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.PipelineGroupUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.PipelineGroupUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.PipelineGroupUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.PipelineGroupUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.PipelineGroupUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.PipelineGroupUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.PipelineGroupUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.PipelineGroupUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PipelineType : System.IEquatable<Azure.ResourceManager.Monitor.Models.PipelineType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PipelineType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.PipelineType Logs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.PipelineType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.PipelineType left, Azure.ResourceManager.Monitor.Models.PipelineType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.PipelineType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.PipelineType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.PipelineType left, Azure.ResourceManager.Monitor.Models.PipelineType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.PrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.PrivateEndpointConnectionProperties>
    {
        internal PrivateEndpointConnectionProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Models.PrivateEndpointConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.PrivateEndpointConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.PrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.PrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.PrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.PrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.PrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Processor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.Processor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Processor>
    {
        public Processor(Azure.ResourceManager.Monitor.Models.ProcessorType type, string name) { }
        public Azure.ResourceManager.Monitor.Models.BatchProcessor Batch { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.ProcessorType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Models.Processor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.Processor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.Processor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.Processor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.Processor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.Processor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Processor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Processor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Processor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProcessorType : System.IEquatable<Azure.ResourceManager.Monitor.Models.ProcessorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProcessorType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.ProcessorType Batch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.ProcessorType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.ProcessorType left, Azure.ResourceManager.Monitor.Models.ProcessorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.ProcessorType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.ProcessorType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.ProcessorType left, Azure.ResourceManager.Monitor.Models.ProcessorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Monitor.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.ProvisioningState left, Azure.ResourceManager.Monitor.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.ProvisioningState left, Azure.ResourceManager.Monitor.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Monitor.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.PublicNetworkAccess other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.PublicNetworkAccess left, Azure.ResourceManager.Monitor.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.PublicNetworkAccess (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.PublicNetworkAccess? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.PublicNetworkAccess left, Azure.ResourceManager.Monitor.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Receiver : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.Receiver>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Receiver>
    {
        public Receiver(Azure.ResourceManager.Monitor.Models.ReceiverType type, string name) { }
        public string Name { get { throw null; } set { } }
        public string OtlpEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.SyslogReceiver Syslog { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.ReceiverType Type { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.UdpReceiver Udp { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Models.Receiver JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.Receiver PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.Receiver System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.Receiver>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.Receiver>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.Receiver System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Receiver>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Receiver>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Receiver>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReceiverType : System.IEquatable<Azure.ResourceManager.Monitor.Models.ReceiverType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReceiverType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.ReceiverType Ama { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ReceiverType OTLP { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ReceiverType PipelineGroup { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ReceiverType Syslog { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ReceiverType UDP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.ReceiverType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.ReceiverType left, Azure.ResourceManager.Monitor.Models.ReceiverType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.ReceiverType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.ReceiverType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.ReceiverType left, Azure.ResourceManager.Monitor.Models.ReceiverType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecordMap : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.RecordMap>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.RecordMap>
    {
        public RecordMap(string from, string to) { }
        public string From { get { throw null; } set { } }
        public string To { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Models.RecordMap JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.RecordMap PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.RecordMap System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.RecordMap>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.RecordMap>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.RecordMap System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.RecordMap>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.RecordMap>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.RecordMap>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceMap : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.ResourceMap>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.ResourceMap>
    {
        public ResourceMap(string from, string to) { }
        public string From { get { throw null; } set { } }
        public string To { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Models.ResourceMap JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.ResourceMap PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.ResourceMap System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.ResourceMap>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.ResourceMap>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.ResourceMap System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.ResourceMap>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.ResourceMap>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.ResourceMap>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchemaMap : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.SchemaMap>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.SchemaMap>
    {
        public SchemaMap(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.RecordMap> recordMap) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.RecordMap> RecordMap { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ResourceMap> ResourceMap { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ScopeMap> ScopeMap { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Models.SchemaMap JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.SchemaMap PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.SchemaMap System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.SchemaMap>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.SchemaMap>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.SchemaMap System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.SchemaMap>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.SchemaMap>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.SchemaMap>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScopeMap : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.ScopeMap>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.ScopeMap>
    {
        public ScopeMap(string from, string to) { }
        public string From { get { throw null; } set { } }
        public string To { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Models.ScopeMap JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.ScopeMap PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.ScopeMap System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.ScopeMap>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.ScopeMap>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.ScopeMap System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.ScopeMap>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.ScopeMap>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.ScopeMap>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Service : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.Service>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Service>
    {
        public Service(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.Pipeline> pipelines) { }
        public string PersistencePersistentVolumeName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.Pipeline> Pipelines { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Models.Service JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.Service PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.Service System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.Service>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.Service>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.Service System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Service>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Service>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.Service>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamEncodingType : System.IEquatable<Azure.ResourceManager.Monitor.Models.StreamEncodingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamEncodingType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.StreamEncodingType Ascii { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.StreamEncodingType Big5 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.StreamEncodingType Nop { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.StreamEncodingType Utf16be { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.StreamEncodingType Utf16le { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.StreamEncodingType Utf8 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.StreamEncodingType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.StreamEncodingType left, Azure.ResourceManager.Monitor.Models.StreamEncodingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.StreamEncodingType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.StreamEncodingType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.StreamEncodingType left, Azure.ResourceManager.Monitor.Models.StreamEncodingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyslogProtocol : System.IEquatable<Azure.ResourceManager.Monitor.Models.SyslogProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyslogProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.SyslogProtocol Rfc3164 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogProtocol Rfc5424 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.SyslogProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.SyslogProtocol left, Azure.ResourceManager.Monitor.Models.SyslogProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.SyslogProtocol (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.SyslogProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.SyslogProtocol left, Azure.ResourceManager.Monitor.Models.SyslogProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SyslogReceiver : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.SyslogReceiver>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.SyslogReceiver>
    {
        public SyslogReceiver(string endpoint) { }
        public string Endpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.SyslogProtocol? Protocol { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Models.SyslogReceiver JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.SyslogReceiver PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.SyslogReceiver System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.SyslogReceiver>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.SyslogReceiver>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.SyslogReceiver System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.SyslogReceiver>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.SyslogReceiver>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.SyslogReceiver>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UdpReceiver : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.UdpReceiver>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.UdpReceiver>
    {
        public UdpReceiver(string endpoint) { }
        public Azure.ResourceManager.Monitor.Models.StreamEncodingType? Encoding { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public int? ReadQueueLength { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Models.UdpReceiver JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Models.UdpReceiver PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Models.UdpReceiver System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.UdpReceiver>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Models.UdpReceiver>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Models.UdpReceiver System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.UdpReceiver>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.UdpReceiver>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Models.UdpReceiver>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
