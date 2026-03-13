namespace Azure.ResourceManager.ContainerRegistry.Tasks
{
    public partial class AgentPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource>, System.Collections.IEnumerable
    {
        protected AgentPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource> Get(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource>> GetAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource> GetIfExists(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource>> GetIfExistsAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AgentPoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData>
    {
        public AgentPoolData(Azure.Core.AzureLocation location) { }
        public int? Count { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS? OS { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState? ProvisioningState { get { throw null; } }
        public string Tier { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualNetworkSubnetResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentPoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AgentPoolResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string agentPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolQueueStatus> GetQueueStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolQueueStatus>> GetQueueStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerContainerRegistryTasksContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerContainerRegistryTasksContext() { }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.AzureResourceManagerContainerRegistryTasksContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ContainerRegistryTasksExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource> GetAgentPool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource>> GetAgentPoolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource GetAgentPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolCollection GetAgentPools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUploadResult> GetBuildSourceUploadUrl(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUploadResult>> GetBuildSourceUploadUrlAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource> GetRun(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource>> GetRunAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.RunResource GetRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.RunCollection GetRuns(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource> GetTask(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource>> GetTaskAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource GetTaskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource> GetTaskRun(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource>> GetTaskRunAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource GetTaskRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunCollection GetTaskRuns(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.TaskCollection GetTasks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource> ScheduleRun(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource>> ScheduleRunAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource>, System.Collections.IEnumerable
    {
        protected RunCollection() { }
        public virtual Azure.Response<bool> Exists(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource> Get(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource>> GetAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource> GetIfExists(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource>> GetIfExistsAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RunData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.RunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.RunData>
    {
        internal RunData() { }
        public int? AgentCpu { get { throw null; } }
        public string AgentPoolName { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<string> CustomRegistries { get { throw null; } }
        public System.DateTimeOffset? FinishOn { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageUpdateTrigger ImageUpdateTrigger { get { throw null; } }
        public bool? IsArchiveEnabled { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageDescriptor LogArtifact { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageDescriptor> OutputImages { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties Platform { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState? ProvisioningState { get { throw null; } }
        public string RunErrorMessage { get { throw null; } }
        public string RunId { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunType? RunType { get { throw null; } }
        public string SourceRegistryAuth { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerDescriptor SourceTrigger { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus? Status { get { throw null; } }
        public string Task { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerDescriptor TimerTrigger { get { throw null; } }
        public string UpdateTriggerToken { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.RunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.RunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.RunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.RunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.RunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.RunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.RunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.RunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.RunData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RunResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.RunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string runId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunGetLogResult> GetLogSasUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunGetLogResult>> GetLogSasUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.RunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.RunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.RunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.RunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.RunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.RunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.RunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource> Update(Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource>> UpdateAsync(Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TaskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource>, System.Collections.IEnumerable
    {
        protected TaskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string taskName, Azure.ResourceManager.ContainerRegistry.Tasks.TaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string taskName, Azure.ResourceManager.ContainerRegistry.Tasks.TaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource> Get(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource>> GetAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource> GetIfExists(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource>> GetIfExistsAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TaskData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskData>
    {
        public TaskData(Azure.Core.AzureLocation location) { }
        public int? AgentCpu { get { throw null; } set { } }
        public string AgentPoolName { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.IdentityProperties Identity { get { throw null; } set { } }
        public bool? IsSystemTask { get { throw null; } set { } }
        public string LogTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties Platform { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties Step { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerProperties Trigger { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.TaskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.TaskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TaskResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TaskResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.TaskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string taskName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource> GetDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource>> GetDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.TaskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.TaskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource> Update(Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource>> UpdateAsync(Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TaskRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource>, System.Collections.IEnumerable
    {
        protected TaskRunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string taskRunName, Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string taskRunName, Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource> Get(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource>> GetAsync(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource> GetIfExists(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource>> GetIfExistsAsync(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TaskRunData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData>
    {
        public TaskRunData() { }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.IdentityProperties Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent RunRequest { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.RunData RunResult { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TaskRunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TaskRunResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string taskRunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource> GetDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource>> GetDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerRegistry.Tasks.Mocking
{
    public partial class MockableContainerRegistryTasksArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerRegistryTasksArmClient() { }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource GetAgentPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.RunResource GetRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource GetTaskResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource GetTaskRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableContainerRegistryTasksResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerRegistryTasksResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource> GetAgentPool(string registryName, string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolResource>> GetAgentPoolAsync(string registryName, string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolCollection GetAgentPools(string registryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUploadResult> GetBuildSourceUploadUrl(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUploadResult>> GetBuildSourceUploadUrlAsync(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource> GetRun(string registryName, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource>> GetRunAsync(string registryName, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.RunCollection GetRuns(string registryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource> GetTask(string registryName, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskResource>> GetTaskAsync(string registryName, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource> GetTaskRun(string registryName, string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunResource>> GetTaskRunAsync(string registryName, string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunCollection GetTaskRuns(string registryName) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.TaskCollection GetTasks(string registryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource> ScheduleRun(string registryName, Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.RunResource>> ScheduleRunAsync(string registryName, Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerRegistry.Tasks.Models
{
    public partial class AgentPoolPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolPatch>
    {
        public AgentPoolPatch() { }
        public int? Count { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentPoolQueueStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolQueueStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolQueueStatus>
    {
        internal AgentPoolQueueStatus() { }
        public int? Count { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolQueueStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolQueueStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolQueueStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolQueueStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolQueueStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolQueueStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolQueueStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolQueueStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolQueueStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmContainerRegistryTasksModelFactory
    {
        public static Azure.ResourceManager.ContainerRegistry.Tasks.AgentPoolData AgentPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), int? count = default(int?), string tier = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS? os = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS?), Azure.Core.ResourceIdentifier virtualNetworkSubnetResourceId = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolPatch AgentPoolPatch(int? count = default(int?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.AgentPoolQueueStatus AgentPoolQueueStatus(int? count = default(int?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependency BaseImageDependency(Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependencyType? type = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependencyType?), string registry = null, string repository = null, string tag = null, string digest = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerUpdateContent BaseImageTriggerUpdateContent(Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerType? baseImageTriggerType = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerType?), string updateTriggerEndpoint = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.UpdateTriggerPayloadType? updateTriggerPayloadType = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.UpdateTriggerPayloadType?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus?), string name = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials ContainerRegistryTaskCredentials(Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryCredentials sourceRegistry = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ContainerRegistry.Tasks.Models.CustomRegistryCredentials> customRegistries = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildContent DockerBuildContent(bool? isArchiveEnabled = default(bool?), string agentPoolName = null, string logTemplate = null, System.Collections.Generic.IEnumerable<string> imageNames = null, bool? isPushEnabled = default(bool?), bool? isCacheDisabled = default(bool?), string dockerFilePath = null, string target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument> arguments = null, int? timeoutInSeconds = default(int?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties platform = null, int? agentCpu = default(int?), string sourceLocation = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials credentials = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStep DockerBuildStep(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null, System.Collections.Generic.IEnumerable<string> imageNames = null, bool? isPushEnabled = default(bool?), bool? isCacheDisabled = default(bool?), string dockerFilePath = null, string target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument> arguments = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStepUpdateContent DockerBuildStepUpdateContent(string contextPath = null, string contextAccessToken = null, System.Collections.Generic.IEnumerable<string> imageNames = null, bool? isPushEnabled = default(bool?), bool? isCacheDisabled = default(bool?), string dockerFilePath = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument> arguments = null, string target = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskRunContent EncodedTaskRunContent(bool? isArchiveEnabled = default(bool?), string agentPoolName = null, string logTemplate = null, string encodedTaskContent = null, string encodedValuesContent = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null, int? timeoutInSeconds = default(int?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties platform = null, int? agentCpu = default(int?), string sourceLocation = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials credentials = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStep EncodedTaskStep(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null, string encodedTaskContent = null, string encodedValuesContent = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStepUpdateContent EncodedTaskStepUpdateContent(string contextPath = null, string contextAccessToken = null, string encodedTaskContent = null, string encodedValuesContent = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskRunContent FileTaskRunContent(bool? isArchiveEnabled = default(bool?), string agentPoolName = null, string logTemplate = null, string taskFilePath = null, string valuesFilePath = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null, int? timeoutInSeconds = default(int?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties platform = null, int? agentCpu = default(int?), string sourceLocation = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials credentials = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStep FileTaskStep(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null, string taskFilePath = null, string valuesFilePath = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStepUpdateContent FileTaskStepUpdateContent(string contextPath = null, string contextAccessToken = null, string taskFilePath = null, string valuesFilePath = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.IdentityProperties IdentityProperties(string principalId = null, string tenantId = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ResourceIdentityType? type = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ResourceIdentityType?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ContainerRegistry.Tasks.Models.UserIdentityProperties> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageDescriptor ImageDescriptor(string registry = null, string repository = null, string tag = null, string digest = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageUpdateTrigger ImageUpdateTrigger(string id = null, System.DateTimeOffset? occurredOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageDescriptor> images = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.OverrideTaskStepProperties OverrideTaskStepProperties(string contextPath = null, string file = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument> arguments = null, string target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null, string updateTriggerToken = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.RunData RunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string runId = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunType? runType = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunType?), string agentPoolName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? finishOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageDescriptor> outputImages = null, string task = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageUpdateTrigger imageUpdateTrigger = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerDescriptor sourceTrigger = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerDescriptor timerTrigger = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties platform = null, string sourceRegistryAuth = null, System.Collections.Generic.IEnumerable<string> customRegistries = null, string runErrorMessage = null, string updateTriggerToken = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageDescriptor logArtifact = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState?), bool? isArchiveEnabled = default(bool?), int? agentCpu = default(int?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunGetLogResult RunGetLogResult(string logLink = null, string logArtifactLink = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTrigger SourceTrigger(Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceProperties sourceRepository = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerEvent> sourceTriggerEvents = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus?), string name = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerDescriptor SourceTriggerDescriptor(string id = null, string eventType = null, string commitId = null, string pullRequestId = null, System.Uri repositoryUri = null, string branchName = null, string providerType = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerUpdateContent SourceTriggerUpdateContent(Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUpdateContent sourceRepository = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerEvent> sourceTriggerEvents = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus?), string name = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUploadResult SourceUploadResult(string uploadUri = null, string relativePath = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.TaskData TaskData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties platform = null, string agentPoolName = null, int? timeoutInSeconds = default(int?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties step = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerProperties trigger = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials credentials = null, string logTemplate = null, bool? isSystemTask = default(bool?), int? agentCpu = default(int?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.IdentityProperties identity = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskPatch TaskPatch(Azure.ResourceManager.ContainerRegistry.Tasks.Models.IdentityProperties identity = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformUpdateContent platform = null, string agentPoolName = null, int? timeoutInSeconds = default(int?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent step = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerUpdateContent trigger = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials credentials = null, string logTemplate = null, int? agentCpu = default(int?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData TaskRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent runRequest = null, Azure.ResourceManager.ContainerRegistry.Tasks.RunData runResult = null, string forceUpdateTag = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.IdentityProperties identity = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunPatch TaskRunPatch(Azure.ResourceManager.ContainerRegistry.Tasks.Models.IdentityProperties identity = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent runRequest = null, string forceUpdateTag = null, string location = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties TaskStepProperties(string type = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerDescriptor TimerTriggerDescriptor(string timerTriggerName = null, string scheduleOccurrence = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerUpdateContent TimerTriggerUpdateContent(string schedule = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus?), string name = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerProperties TriggerProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTrigger> timerTriggers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTrigger> sourceTriggers = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTrigger baseImageTrigger = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerUpdateContent TriggerUpdateContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerUpdateContent> timerTriggers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerUpdateContent> sourceTriggers = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerUpdateContent baseImageTrigger = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.UserIdentityProperties UserIdentityProperties(string principalId = null, string clientId = null) { throw null; }
    }
    public partial class AuthInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfo>
    {
        public AuthInfo(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTokenType tokenType, string token) { }
        public int? ExpiresInSeconds { get { throw null; } set { } }
        public string RefreshToken { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTokenType TokenType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthInfoUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfoUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfoUpdateContent>
    {
        public AuthInfoUpdateContent() { }
        public int? ExpiresInSeconds { get { throw null; } set { } }
        public string RefreshToken { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTokenType? TokenType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfoUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfoUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfoUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfoUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfoUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfoUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfoUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfoUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfoUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BaseImageDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependency>
    {
        internal BaseImageDependency() { }
        public string Digest { get { throw null; } }
        public string Registry { get { throw null; } }
        public string Repository { get { throw null; } }
        public string Tag { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependencyType? Type { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependency JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependency PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BaseImageDependencyType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependencyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BaseImageDependencyType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependencyType BuildTime { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependencyType RunTime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependencyType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependencyType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependencyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependencyType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependencyType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependencyType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependencyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BaseImageTrigger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTrigger>
    {
        public BaseImageTrigger(Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerType baseImageTriggerType, string name) { }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerType BaseImageTriggerType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? Status { get { throw null; } set { } }
        public string UpdateTriggerEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.UpdateTriggerPayloadType? UpdateTriggerPayloadType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BaseImageTriggerType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BaseImageTriggerType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerType All { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerType Runtime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BaseImageTriggerUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerUpdateContent>
    {
        public BaseImageTriggerUpdateContent(string name) { }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerType? BaseImageTriggerType { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? Status { get { throw null; } set { } }
        public string UpdateTriggerEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.UpdateTriggerPayloadType? UpdateTriggerPayloadType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTaskArchitecture : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTaskArchitecture(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture Amd64 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture Arm { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture Arm64 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture X86 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture _386 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryTaskArgument : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument>
    {
        public ContainerRegistryTaskArgument(string name, string value) { }
        public bool? IsSecret { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials>
    {
        public ContainerRegistryTaskCredentials() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ContainerRegistry.Tasks.Models.CustomRegistryCredentials> CustomRegistries { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryCredentials SourceRegistry { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTaskOS : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTaskOS(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS Linux { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTaskProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTaskProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTaskRunStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTaskRunStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus Error { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus Running { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus Started { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTaskRunType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTaskRunType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunType AutoBuild { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunType AutoRun { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunType QuickBuild { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunType QuickRun { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryTaskSecretObject : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObject>
    {
        public ContainerRegistryTaskSecretObject() { }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObjectType? Type { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObject JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObject PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObject System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObject System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTaskSecretObjectType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObjectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTaskSecretObjectType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObjectType Opaque { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObjectType VaultSecret { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObjectType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObjectType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObjectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObjectType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObjectType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObjectType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObjectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryTaskSetValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue>
    {
        public ContainerRegistryTaskSetValue(string name, string value) { }
        public bool? IsSecret { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTaskStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTaskStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTaskTokenType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTokenType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTaskTokenType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTokenType OAuth { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTokenType PAT { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTokenType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTokenType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTokenType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTokenType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTokenType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTokenType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTokenType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTaskTriggerStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTaskTriggerStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTaskVariant : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskVariant>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTaskVariant(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskVariant V6 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskVariant V7 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskVariant V8 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskVariant other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskVariant left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskVariant right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskVariant (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskVariant? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskVariant left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskVariant right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomRegistryCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.CustomRegistryCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.CustomRegistryCredentials>
    {
        public CustomRegistryCredentials() { }
        public string Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObject Password { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObject UserName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.CustomRegistryCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.CustomRegistryCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.CustomRegistryCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.CustomRegistryCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.CustomRegistryCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.CustomRegistryCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.CustomRegistryCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.CustomRegistryCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.CustomRegistryCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DockerBuildContent : Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildContent>
    {
        public DockerBuildContent(string dockerFilePath, Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties platform) { }
        public int? AgentCpu { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument> Arguments { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials Credentials { get { throw null; } set { } }
        public string DockerFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ImageNames { get { throw null; } }
        public bool? IsCacheDisabled { get { throw null; } set { } }
        public bool? IsPushEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties Platform { get { throw null; } set { } }
        public string SourceLocation { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DockerBuildStep : Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStep>
    {
        public DockerBuildStep(string dockerFilePath) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument> Arguments { get { throw null; } }
        public string DockerFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ImageNames { get { throw null; } }
        public bool? IsCacheDisabled { get { throw null; } set { } }
        public bool? IsPushEnabled { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DockerBuildStepUpdateContent : Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStepUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStepUpdateContent>
    {
        public DockerBuildStepUpdateContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument> Arguments { get { throw null; } }
        public string DockerFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ImageNames { get { throw null; } }
        public bool? IsCacheDisabled { get { throw null; } set { } }
        public bool? IsPushEnabled { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStepUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStepUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStepUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStepUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStepUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStepUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStepUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EncodedTaskRunContent : Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskRunContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskRunContent>
    {
        public EncodedTaskRunContent(string encodedTaskContent, Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties platform) { }
        public int? AgentCpu { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials Credentials { get { throw null; } set { } }
        public string EncodedTaskContent { get { throw null; } set { } }
        public string EncodedValuesContent { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties Platform { get { throw null; } set { } }
        public string SourceLocation { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> Values { get { throw null; } }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskRunContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskRunContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskRunContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskRunContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskRunContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskRunContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskRunContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EncodedTaskStep : Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStep>
    {
        public EncodedTaskStep(string encodedTaskContent) { }
        public string EncodedTaskContent { get { throw null; } set { } }
        public string EncodedValuesContent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> Values { get { throw null; } }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EncodedTaskStepUpdateContent : Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStepUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStepUpdateContent>
    {
        public EncodedTaskStepUpdateContent() { }
        public string EncodedTaskContent { get { throw null; } set { } }
        public string EncodedValuesContent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> Values { get { throw null; } }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStepUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStepUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStepUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStepUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStepUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStepUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStepUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileTaskRunContent : Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskRunContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskRunContent>
    {
        public FileTaskRunContent(string taskFilePath, Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties platform) { }
        public int? AgentCpu { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties Platform { get { throw null; } set { } }
        public string SourceLocation { get { throw null; } set { } }
        public string TaskFilePath { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> Values { get { throw null; } }
        public string ValuesFilePath { get { throw null; } set { } }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskRunContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskRunContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskRunContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskRunContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskRunContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskRunContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskRunContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileTaskStep : Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStep>
    {
        public FileTaskStep(string taskFilePath) { }
        public string TaskFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> Values { get { throw null; } }
        public string ValuesFilePath { get { throw null; } set { } }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileTaskStepUpdateContent : Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStepUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStepUpdateContent>
    {
        public FileTaskStepUpdateContent() { }
        public string TaskFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> Values { get { throw null; } }
        public string ValuesFilePath { get { throw null; } set { } }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStepUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStepUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStepUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStepUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStepUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStepUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStepUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IdentityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.IdentityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.IdentityProperties>
    {
        public IdentityProperties() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ResourceIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ContainerRegistry.Tasks.Models.UserIdentityProperties> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.IdentityProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.IdentityProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.IdentityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.IdentityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.IdentityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.IdentityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.IdentityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.IdentityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.IdentityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageDescriptor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageDescriptor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageDescriptor>
    {
        internal ImageDescriptor() { }
        public string Digest { get { throw null; } }
        public string Registry { get { throw null; } }
        public string Repository { get { throw null; } }
        public string Tag { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageDescriptor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageDescriptor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageDescriptor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageDescriptor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageDescriptor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageDescriptor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageDescriptor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageDescriptor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageDescriptor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageUpdateTrigger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageUpdateTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageUpdateTrigger>
    {
        internal ImageUpdateTrigger() { }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageDescriptor> Images { get { throw null; } }
        public System.DateTimeOffset? OccurredOn { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageUpdateTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageUpdateTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageUpdateTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageUpdateTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageUpdateTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageUpdateTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageUpdateTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageUpdateTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ImageUpdateTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OverrideTaskStepProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.OverrideTaskStepProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.OverrideTaskStepProperties>
    {
        public OverrideTaskStepProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument> Arguments { get { throw null; } }
        public string ContextPath { get { throw null; } set { } }
        public string File { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public string UpdateTriggerToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> Values { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.OverrideTaskStepProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.OverrideTaskStepProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.OverrideTaskStepProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.OverrideTaskStepProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.OverrideTaskStepProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.OverrideTaskStepProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.OverrideTaskStepProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.OverrideTaskStepProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.OverrideTaskStepProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlatformProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties>
    {
        public PlatformProperties(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS os) { }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture? Architecture { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS OS { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskVariant? Variant { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlatformUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformUpdateContent>
    {
        public PlatformUpdateContent() { }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture? Architecture { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS? OS { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskVariant? Variant { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ResourceIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
        SystemAssignedUserAssigned = 2,
        None = 3,
    }
    public abstract partial class RunContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent>
    {
        internal RunContent() { }
        public string AgentPoolName { get { throw null; } set { } }
        public bool? IsArchiveEnabled { get { throw null; } set { } }
        public string LogTemplate { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunGetLogResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunGetLogResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunGetLogResult>
    {
        internal RunGetLogResult() { }
        public string LogArtifactLink { get { throw null; } }
        public string LogLink { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunGetLogResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunGetLogResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunGetLogResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunGetLogResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunGetLogResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunGetLogResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunGetLogResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunGetLogResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunGetLogResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunPatch>
    {
        public RunPatch() { }
        public bool? IsArchiveEnabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceControlType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceControlType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceControlType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceControlType Github { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceControlType VisualStudioTeamService { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceControlType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceControlType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceControlType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceControlType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceControlType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceControlType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceControlType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceProperties>
    {
        public SourceProperties(Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceControlType sourceControlType, System.Uri repositoryUri) { }
        public string Branch { get { throw null; } set { } }
        public System.Uri RepositoryUri { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfo SourceControlAuthProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceControlType SourceControlType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SourceRegistryCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryCredentials>
    {
        public SourceRegistryCredentials() { }
        public string Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryLoginMode? LoginMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceRegistryLoginMode : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryLoginMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceRegistryLoginMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryLoginMode Default { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryLoginMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryLoginMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryLoginMode left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryLoginMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryLoginMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryLoginMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryLoginMode left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceRegistryLoginMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SourceTrigger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTrigger>
    {
        public SourceTrigger(Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceProperties sourceRepository, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerEvent> sourceTriggerEvents, string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceProperties SourceRepository { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerEvent> SourceTriggerEvents { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SourceTriggerDescriptor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerDescriptor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerDescriptor>
    {
        internal SourceTriggerDescriptor() { }
        public string BranchName { get { throw null; } }
        public string CommitId { get { throw null; } }
        public string EventType { get { throw null; } }
        public string Id { get { throw null; } }
        public string ProviderType { get { throw null; } }
        public string PullRequestId { get { throw null; } }
        public System.Uri RepositoryUri { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerDescriptor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerDescriptor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerDescriptor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerDescriptor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerDescriptor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerDescriptor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerDescriptor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerDescriptor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerDescriptor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceTriggerEvent : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceTriggerEvent(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerEvent Commit { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerEvent PullRequest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerEvent other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerEvent left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerEvent right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerEvent (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerEvent? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerEvent left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SourceTriggerUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerUpdateContent>
    {
        public SourceTriggerUpdateContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUpdateContent SourceRepository { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerEvent> SourceTriggerEvents { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SourceUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUpdateContent>
    {
        public SourceUpdateContent() { }
        public string Branch { get { throw null; } set { } }
        public string RepositoryUri { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.AuthInfoUpdateContent SourceControlAuthProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceControlType? SourceControlType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SourceUploadResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUploadResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUploadResult>
    {
        internal SourceUploadResult() { }
        public string RelativePath { get { throw null; } }
        public string UploadUri { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUploadResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUploadResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUploadResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUploadResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUploadResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUploadResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUploadResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUploadResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceUploadResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TaskPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskPatch>
    {
        public TaskPatch() { }
        public int? AgentCpu { get { throw null; } set { } }
        public string AgentPoolName { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.IdentityProperties Identity { get { throw null; } set { } }
        public string LogTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.PlatformUpdateContent Platform { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent Step { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerUpdateContent Trigger { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TaskRunContent : Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunContent>
    {
        public TaskRunContent(string taskId) { }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.OverrideTaskStepProperties OverrideTaskStepProperties { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TaskRunPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunPatch>
    {
        public TaskRunPatch() { }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.IdentityProperties Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent RunRequest { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TaskStepProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties>
    {
        internal TaskStepProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageDependency> BaseImageDependencies { get { throw null; } }
        public string ContextAccessToken { get { throw null; } set { } }
        public string ContextPath { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TaskStepUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent>
    {
        internal TaskStepUpdateContent() { }
        public string ContextAccessToken { get { throw null; } set { } }
        public string ContextPath { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TimerTrigger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTrigger>
    {
        public TimerTrigger(string schedule, string name) { }
        public string Name { get { throw null; } set { } }
        public string Schedule { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TimerTriggerDescriptor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerDescriptor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerDescriptor>
    {
        internal TimerTriggerDescriptor() { }
        public string ScheduleOccurrence { get { throw null; } }
        public string TimerTriggerName { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerDescriptor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerDescriptor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerDescriptor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerDescriptor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerDescriptor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerDescriptor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerDescriptor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerDescriptor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerDescriptor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TimerTriggerUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerUpdateContent>
    {
        public TimerTriggerUpdateContent(string name) { }
        public string Name { get { throw null; } }
        public string Schedule { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TriggerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerProperties>
    {
        public TriggerProperties() { }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTrigger BaseImageTrigger { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTrigger> SourceTriggers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTrigger> TimerTriggers { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TriggerUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerUpdateContent>
    {
        public TriggerUpdateContent() { }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.BaseImageTriggerUpdateContent BaseImageTrigger { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.SourceTriggerUpdateContent> SourceTriggers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TimerTriggerUpdateContent> TimerTriggers { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TriggerUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateTriggerPayloadType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.UpdateTriggerPayloadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateTriggerPayloadType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.UpdateTriggerPayloadType Default { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.UpdateTriggerPayloadType Token { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.UpdateTriggerPayloadType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.UpdateTriggerPayloadType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.UpdateTriggerPayloadType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.UpdateTriggerPayloadType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.UpdateTriggerPayloadType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.UpdateTriggerPayloadType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.UpdateTriggerPayloadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserIdentityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.UserIdentityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.UserIdentityProperties>
    {
        public UserIdentityProperties() { }
        public string ClientId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.UserIdentityProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.UserIdentityProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.UserIdentityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.UserIdentityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.UserIdentityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.UserIdentityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.UserIdentityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.UserIdentityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.UserIdentityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
