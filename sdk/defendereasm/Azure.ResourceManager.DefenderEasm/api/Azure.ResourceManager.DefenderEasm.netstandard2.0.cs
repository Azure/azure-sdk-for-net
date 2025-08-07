namespace Azure.ResourceManager.DefenderEasm
{
    public partial class AzureResourceManagerDefenderEasmContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDefenderEasmContext() { }
        public static Azure.ResourceManager.DefenderEasm.AzureResourceManagerDefenderEasmContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class DefenderEasmExtensions
    {
        public static Azure.ResourceManager.DefenderEasm.EasmLabelResource GetEasmLabelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource> GetEasmWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource>> GetEasmWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource GetEasmWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DefenderEasm.EasmWorkspaceCollection GetEasmWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource> GetEasmWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource> GetEasmWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EasmLabelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DefenderEasm.EasmLabelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DefenderEasm.EasmLabelResource>, System.Collections.IEnumerable
    {
        protected EasmLabelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DefenderEasm.EasmLabelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string labelName, Azure.ResourceManager.DefenderEasm.EasmLabelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DefenderEasm.EasmLabelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string labelName, Azure.ResourceManager.DefenderEasm.EasmLabelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string labelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string labelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.EasmLabelResource> Get(string labelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DefenderEasm.EasmLabelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DefenderEasm.EasmLabelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.EasmLabelResource>> GetAsync(string labelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DefenderEasm.EasmLabelResource> GetIfExists(string labelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DefenderEasm.EasmLabelResource>> GetIfExistsAsync(string labelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DefenderEasm.EasmLabelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DefenderEasm.EasmLabelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DefenderEasm.EasmLabelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DefenderEasm.EasmLabelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EasmLabelData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.EasmLabelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.EasmLabelData>
    {
        public EasmLabelData() { }
        public string Color { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DefenderEasm.EasmLabelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.EasmLabelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.EasmLabelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DefenderEasm.EasmLabelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.EasmLabelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.EasmLabelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.EasmLabelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EasmLabelResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.EasmLabelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.EasmLabelData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EasmLabelResource() { }
        public virtual Azure.ResourceManager.DefenderEasm.EasmLabelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string labelName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.EasmLabelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.EasmLabelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DefenderEasm.EasmLabelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.EasmLabelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.EasmLabelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DefenderEasm.EasmLabelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.EasmLabelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.EasmLabelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.EasmLabelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.EasmLabelResource> Update(Azure.ResourceManager.DefenderEasm.Models.EasmLabelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.EasmLabelResource>> UpdateAsync(Azure.ResourceManager.DefenderEasm.Models.EasmLabelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EasmWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource>, System.Collections.IEnumerable
    {
        protected EasmWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.DefenderEasm.EasmWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.DefenderEasm.EasmWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EasmWorkspaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.EasmWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.EasmWorkspaceData>
    {
        public EasmWorkspaceData(Azure.Core.AzureLocation location) { }
        public string DataPlaneEndpoint { get { throw null; } }
        public Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DefenderEasm.EasmWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.EasmWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.EasmWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DefenderEasm.EasmWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.EasmWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.EasmWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.EasmWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EasmWorkspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.EasmWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.EasmWorkspaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EasmWorkspaceResource() { }
        public virtual Azure.ResourceManager.DefenderEasm.EasmWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.EasmLabelResource> GetEasmLabel(string labelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.EasmLabelResource>> GetEasmLabelAsync(string labelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DefenderEasm.EasmLabelCollection GetEasmLabels() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.Models.EasmTask> GetTaskByWorkspace(string taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.Models.EasmTask>> GetTaskByWorkspaceAsync(string taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DefenderEasm.EasmWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.EasmWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.EasmWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DefenderEasm.EasmWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.EasmWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.EasmWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.EasmWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource> Update(Azure.ResourceManager.DefenderEasm.Models.EasmWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource>> UpdateAsync(Azure.ResourceManager.DefenderEasm.Models.EasmWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DefenderEasm.Mocking
{
    public partial class MockableDefenderEasmArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDefenderEasmArmClient() { }
        public virtual Azure.ResourceManager.DefenderEasm.EasmLabelResource GetEasmLabelResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource GetEasmWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDefenderEasmResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDefenderEasmResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource> GetEasmWorkspace(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource>> GetEasmWorkspaceAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DefenderEasm.EasmWorkspaceCollection GetEasmWorkspaces() { throw null; }
    }
    public partial class MockableDefenderEasmSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDefenderEasmSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource> GetEasmWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DefenderEasm.EasmWorkspaceResource> GetEasmWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DefenderEasm.Models
{
    public static partial class ArmDefenderEasmModelFactory
    {
        public static Azure.ResourceManager.DefenderEasm.EasmLabelData EasmLabelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState?), string displayName = null, string color = null) { throw null; }
        public static Azure.ResourceManager.DefenderEasm.Models.EasmLabelPatch EasmLabelPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState?), string displayName = null, string color = null) { throw null; }
        public static Azure.ResourceManager.DefenderEasm.Models.EasmTask EasmTask(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState?), string startedAt = null, string completedAt = null, string lastPolledAt = null, string state = null, string phase = null, string reason = null, System.BinaryData metadata = null) { throw null; }
        public static Azure.ResourceManager.DefenderEasm.EasmWorkspaceData EasmWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState?), string dataPlaneEndpoint = null) { throw null; }
        public static Azure.ResourceManager.DefenderEasm.Models.EasmWorkspacePatch EasmWorkspacePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.SystemData systemData = null) { throw null; }
    }
    public partial class EasmLabelPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.Models.EasmLabelPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.Models.EasmLabelPatch>
    {
        public EasmLabelPatch() { }
        public string Color { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DefenderEasm.Models.EasmLabelPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.Models.EasmLabelPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.Models.EasmLabelPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DefenderEasm.Models.EasmLabelPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.Models.EasmLabelPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.Models.EasmLabelPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.Models.EasmLabelPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EasmResourceProvisioningState : System.IEquatable<Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EasmResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState ConfiguringApplication { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState CreatingArtifacts { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState DeletingArtifacts { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState InstallingApplication { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState MigratingApplicationData { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState ProvisioningResources { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState RunningValidations { get { throw null; } }
        public static Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState left, Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState left, Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EasmTask : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.Models.EasmTask>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.Models.EasmTask>
    {
        public EasmTask() { }
        public string CompletedAt { get { throw null; } set { } }
        public string LastPolledAt { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public string Phase { get { throw null; } set { } }
        public Azure.ResourceManager.DefenderEasm.Models.EasmResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string Reason { get { throw null; } set { } }
        public string StartedAt { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DefenderEasm.Models.EasmTask System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.Models.EasmTask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.Models.EasmTask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DefenderEasm.Models.EasmTask System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.Models.EasmTask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.Models.EasmTask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.Models.EasmTask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EasmWorkspacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.Models.EasmWorkspacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.Models.EasmWorkspacePatch>
    {
        public EasmWorkspacePatch() { }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DefenderEasm.Models.EasmWorkspacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.Models.EasmWorkspacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DefenderEasm.Models.EasmWorkspacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DefenderEasm.Models.EasmWorkspacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.Models.EasmWorkspacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.Models.EasmWorkspacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DefenderEasm.Models.EasmWorkspacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
