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
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult> GetBuildSourceUploadUrl(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult>> GetBuildSourceUploadUrlAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageUpdateTrigger ImageUpdateTrigger { get { throw null; } }
        public bool? IsArchiveEnabled { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor LogArtifact { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor> OutputImages { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties Platform { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState? ProvisioningState { get { throw null; } }
        public string RunErrorMessage { get { throw null; } }
        public string RunId { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunType? RunType { get { throw null; } }
        public string SourceRegistryAuth { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerDescriptor SourceTrigger { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus? Status { get { throw null; } }
        public string Task { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerDescriptor TimerTrigger { get { throw null; } }
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
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunLogResult> GetLogSasUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunLogResult>> GetLogSasUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties Identity { get { throw null; } set { } }
        public bool? IsSystemTask { get { throw null; } set { } }
        public string LogTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties Platform { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties Step { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerProperties Trigger { get { throw null; } set { } }
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
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties Identity { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult> GetBuildSourceUploadUrl(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult>> GetBuildSourceUploadUrlAsync(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency ContainerRegistryTaskBaseImageDependency(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependencyType? type = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependencyType?), string registry = null, string repository = null, string tag = null, string digest = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerUpdateContent ContainerRegistryTaskBaseImageTriggerUpdateContent(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerType? baseImageTriggerType = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerType?), string updateTriggerEndpoint = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUpdateTriggerPayloadType? updateTriggerPayloadType = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUpdateTriggerPayloadType?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus?), string name = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials ContainerRegistryTaskCredentials(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryCredentials sourceRegistry = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCustomRegistryCredentials> customRegistries = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties ContainerRegistryTaskIdentityProperties(string principalId = null, string tenantId = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskResourceIdentityType? type = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskResourceIdentityType?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUserIdentityProperties> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor ContainerRegistryTaskImageDescriptor(string registry = null, string repository = null, string tag = null, string digest = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageUpdateTrigger ContainerRegistryTaskImageUpdateTrigger(string id = null, System.DateTimeOffset? occurredOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor> images = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOverrideStepProperties ContainerRegistryTaskOverrideStepProperties(string contextPath = null, string file = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument> arguments = null, string target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null, string updateTriggerToken = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunLogResult ContainerRegistryTaskRunLogResult(string logLink = null, string logArtifactLink = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTrigger ContainerRegistryTaskSourceTrigger(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceProperties sourceRepository = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerEvent> sourceTriggerEvents = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus?), string name = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerDescriptor ContainerRegistryTaskSourceTriggerDescriptor(string id = null, string eventType = null, string commitId = null, string pullRequestId = null, System.Uri repositoryUri = null, string branchName = null, string providerType = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerUpdateContent ContainerRegistryTaskSourceTriggerUpdateContent(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUpdateContent sourceRepository = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerEvent> sourceTriggerEvents = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus?), string name = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult ContainerRegistryTaskSourceUploadResult(string uploadUri = null, string relativePath = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerDescriptor ContainerRegistryTaskTimerTriggerDescriptor(string timerTriggerName = null, string scheduleOccurrence = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerUpdateContent ContainerRegistryTaskTimerTriggerUpdateContent(string schedule = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus?), string name = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerProperties ContainerRegistryTaskTriggerProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTrigger> timerTriggers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTrigger> sourceTriggers = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTrigger baseImageTrigger = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerUpdateContent ContainerRegistryTaskTriggerUpdateContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerUpdateContent> timerTriggers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerUpdateContent> sourceTriggers = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerUpdateContent baseImageTrigger = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUserIdentityProperties ContainerRegistryTaskUserIdentityProperties(string principalId = null, string clientId = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildContent DockerBuildContent(bool? isArchiveEnabled = default(bool?), string agentPoolName = null, string logTemplate = null, System.Collections.Generic.IEnumerable<string> imageNames = null, bool? isPushEnabled = default(bool?), bool? isCacheDisabled = default(bool?), string dockerFilePath = null, string target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument> arguments = null, int? timeoutInSeconds = default(int?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties platform = null, int? agentCpu = default(int?), string sourceLocation = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials credentials = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStep DockerBuildStep(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null, System.Collections.Generic.IEnumerable<string> imageNames = null, bool? isPushEnabled = default(bool?), bool? isCacheDisabled = default(bool?), string dockerFilePath = null, string target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument> arguments = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildStepUpdateContent DockerBuildStepUpdateContent(string contextPath = null, string contextAccessToken = null, System.Collections.Generic.IEnumerable<string> imageNames = null, bool? isPushEnabled = default(bool?), bool? isCacheDisabled = default(bool?), string dockerFilePath = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument> arguments = null, string target = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskRunContent EncodedTaskRunContent(bool? isArchiveEnabled = default(bool?), string agentPoolName = null, string logTemplate = null, string encodedTaskContent = null, string encodedValuesContent = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null, int? timeoutInSeconds = default(int?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties platform = null, int? agentCpu = default(int?), string sourceLocation = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials credentials = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStep EncodedTaskStep(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null, string encodedTaskContent = null, string encodedValuesContent = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.EncodedTaskStepUpdateContent EncodedTaskStepUpdateContent(string contextPath = null, string contextAccessToken = null, string encodedTaskContent = null, string encodedValuesContent = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskRunContent FileTaskRunContent(bool? isArchiveEnabled = default(bool?), string agentPoolName = null, string logTemplate = null, string taskFilePath = null, string valuesFilePath = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null, int? timeoutInSeconds = default(int?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties platform = null, int? agentCpu = default(int?), string sourceLocation = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials credentials = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStep FileTaskStep(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null, string taskFilePath = null, string valuesFilePath = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.FileTaskStepUpdateContent FileTaskStepUpdateContent(string contextPath = null, string contextAccessToken = null, string taskFilePath = null, string valuesFilePath = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.RunData RunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string runId = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunType? runType = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunType?), string agentPoolName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? finishOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor> outputImages = null, string task = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageUpdateTrigger imageUpdateTrigger = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerDescriptor sourceTrigger = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerDescriptor timerTrigger = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties platform = null, string sourceRegistryAuth = null, System.Collections.Generic.IEnumerable<string> customRegistries = null, string runErrorMessage = null, string updateTriggerToken = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor logArtifact = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState?), bool? isArchiveEnabled = default(bool?), int? agentCpu = default(int?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.TaskData TaskData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties platform = null, string agentPoolName = null, int? timeoutInSeconds = default(int?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties step = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerProperties trigger = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials credentials = null, string logTemplate = null, bool? isSystemTask = default(bool?), int? agentCpu = default(int?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties identity = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskPatch TaskPatch(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties identity = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformUpdateContent platform = null, string agentPoolName = null, int? timeoutInSeconds = default(int?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent step = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerUpdateContent trigger = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials credentials = null, string logTemplate = null, int? agentCpu = default(int?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.TaskRunData TaskRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent runRequest = null, Azure.ResourceManager.ContainerRegistry.Tasks.RunData runResult = null, string forceUpdateTag = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties identity = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskRunPatch TaskRunPatch(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties identity = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent runRequest = null, string forceUpdateTag = null, string location = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepProperties TaskStepProperties(string type = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null) { throw null; }
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
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture X386 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture X86 { get { throw null; } }
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
    public partial class ContainerRegistryTaskAuthInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfo>
    {
        public ContainerRegistryTaskAuthInfo(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTokenType tokenType, string token) { }
        public int? ExpiresInSeconds { get { throw null; } set { } }
        public string RefreshToken { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTokenType TokenType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskAuthInfoUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfoUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfoUpdateContent>
    {
        public ContainerRegistryTaskAuthInfoUpdateContent() { }
        public int? ExpiresInSeconds { get { throw null; } set { } }
        public string RefreshToken { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTokenType? TokenType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfoUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfoUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfoUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfoUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfoUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfoUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfoUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfoUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfoUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskBaseImageDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency>
    {
        internal ContainerRegistryTaskBaseImageDependency() { }
        public string Digest { get { throw null; } }
        public string Registry { get { throw null; } }
        public string Repository { get { throw null; } }
        public string Tag { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependencyType? Type { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTaskBaseImageDependencyType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependencyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTaskBaseImageDependencyType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependencyType BuildTime { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependencyType RunTime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependencyType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependencyType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependencyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependencyType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependencyType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependencyType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependencyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryTaskBaseImageTrigger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTrigger>
    {
        public ContainerRegistryTaskBaseImageTrigger(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerType baseImageTriggerType, string name) { }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerType BaseImageTriggerType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? Status { get { throw null; } set { } }
        public string UpdateTriggerEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUpdateTriggerPayloadType? UpdateTriggerPayloadType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTaskBaseImageTriggerType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTaskBaseImageTriggerType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerType All { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerType Runtime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryTaskBaseImageTriggerUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerUpdateContent>
    {
        public ContainerRegistryTaskBaseImageTriggerUpdateContent(string name) { }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerType? BaseImageTriggerType { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? Status { get { throw null; } set { } }
        public string UpdateTriggerEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUpdateTriggerPayloadType? UpdateTriggerPayloadType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials>
    {
        public ContainerRegistryTaskCredentials() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCustomRegistryCredentials> CustomRegistries { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryCredentials SourceRegistry { get { throw null; } set { } }
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
    public partial class ContainerRegistryTaskCustomRegistryCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCustomRegistryCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCustomRegistryCredentials>
    {
        public ContainerRegistryTaskCustomRegistryCredentials() { }
        public string Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObject Password { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObject UserName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCustomRegistryCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCustomRegistryCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCustomRegistryCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCustomRegistryCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCustomRegistryCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCustomRegistryCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCustomRegistryCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCustomRegistryCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCustomRegistryCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskIdentityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties>
    {
        public ContainerRegistryTaskIdentityProperties() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskResourceIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUserIdentityProperties> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskImageDescriptor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor>
    {
        internal ContainerRegistryTaskImageDescriptor() { }
        public string Digest { get { throw null; } }
        public string Registry { get { throw null; } }
        public string Repository { get { throw null; } }
        public string Tag { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskImageUpdateTrigger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageUpdateTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageUpdateTrigger>
    {
        internal ContainerRegistryTaskImageUpdateTrigger() { }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor> Images { get { throw null; } }
        public System.DateTimeOffset? OccurredOn { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageUpdateTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageUpdateTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageUpdateTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageUpdateTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageUpdateTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageUpdateTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageUpdateTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageUpdateTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageUpdateTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ContainerRegistryTaskOverrideStepProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOverrideStepProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOverrideStepProperties>
    {
        public ContainerRegistryTaskOverrideStepProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument> Arguments { get { throw null; } }
        public string ContextPath { get { throw null; } set { } }
        public string File { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public string UpdateTriggerToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> Values { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOverrideStepProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOverrideStepProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOverrideStepProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOverrideStepProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOverrideStepProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOverrideStepProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOverrideStepProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOverrideStepProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOverrideStepProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskPlatformProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties>
    {
        public ContainerRegistryTaskPlatformProperties(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS os) { }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture? Architecture { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS OS { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskVariant? Variant { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskPlatformUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformUpdateContent>
    {
        public ContainerRegistryTaskPlatformUpdateContent() { }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture? Architecture { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS? OS { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskVariant? Variant { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public enum ContainerRegistryTaskResourceIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
        SystemAssignedUserAssigned = 2,
        None = 3,
    }
    public partial class ContainerRegistryTaskRunLogResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunLogResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunLogResult>
    {
        internal ContainerRegistryTaskRunLogResult() { }
        public string LogArtifactLink { get { throw null; } }
        public string LogLink { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunLogResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunLogResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunLogResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunLogResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunLogResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunLogResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunLogResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunLogResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunLogResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct ContainerRegistryTaskSourceControlType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceControlType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTaskSourceControlType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceControlType Github { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceControlType VisualStudioTeamService { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceControlType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceControlType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceControlType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceControlType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceControlType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceControlType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceControlType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryTaskSourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceProperties>
    {
        public ContainerRegistryTaskSourceProperties(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceControlType sourceControlType, System.Uri repositoryUri) { }
        public string Branch { get { throw null; } set { } }
        public System.Uri RepositoryUri { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfo SourceControlAuthProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceControlType SourceControlType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskSourceRegistryCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryCredentials>
    {
        public ContainerRegistryTaskSourceRegistryCredentials() { }
        public string Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryLoginMode? LoginMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTaskSourceRegistryLoginMode : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryLoginMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTaskSourceRegistryLoginMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryLoginMode Default { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryLoginMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryLoginMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryLoginMode left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryLoginMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryLoginMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryLoginMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryLoginMode left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryLoginMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryTaskSourceTrigger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTrigger>
    {
        public ContainerRegistryTaskSourceTrigger(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceProperties sourceRepository, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerEvent> sourceTriggerEvents, string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceProperties SourceRepository { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerEvent> SourceTriggerEvents { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskSourceTriggerDescriptor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerDescriptor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerDescriptor>
    {
        internal ContainerRegistryTaskSourceTriggerDescriptor() { }
        public string BranchName { get { throw null; } }
        public string CommitId { get { throw null; } }
        public string EventType { get { throw null; } }
        public string Id { get { throw null; } }
        public string ProviderType { get { throw null; } }
        public string PullRequestId { get { throw null; } }
        public System.Uri RepositoryUri { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerDescriptor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerDescriptor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerDescriptor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerDescriptor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerDescriptor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerDescriptor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerDescriptor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerDescriptor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerDescriptor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTaskSourceTriggerEvent : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTaskSourceTriggerEvent(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerEvent Commit { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerEvent PullRequest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerEvent other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerEvent left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerEvent right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerEvent (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerEvent? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerEvent left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryTaskSourceTriggerUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerUpdateContent>
    {
        public ContainerRegistryTaskSourceTriggerUpdateContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUpdateContent SourceRepository { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerEvent> SourceTriggerEvents { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskSourceUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUpdateContent>
    {
        public ContainerRegistryTaskSourceUpdateContent() { }
        public string Branch { get { throw null; } set { } }
        public string RepositoryUri { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfoUpdateContent SourceControlAuthProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceControlType? SourceControlType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskSourceUploadResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult>
    {
        internal ContainerRegistryTaskSourceUploadResult() { }
        public string RelativePath { get { throw null; } }
        public string UploadUri { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ContainerRegistryTaskTimerTrigger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTrigger>
    {
        public ContainerRegistryTaskTimerTrigger(string schedule, string name) { }
        public string Name { get { throw null; } set { } }
        public string Schedule { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskTimerTriggerDescriptor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerDescriptor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerDescriptor>
    {
        internal ContainerRegistryTaskTimerTriggerDescriptor() { }
        public string ScheduleOccurrence { get { throw null; } }
        public string TimerTriggerName { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerDescriptor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerDescriptor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerDescriptor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerDescriptor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerDescriptor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerDescriptor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerDescriptor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerDescriptor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerDescriptor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskTimerTriggerUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerUpdateContent>
    {
        public ContainerRegistryTaskTimerTriggerUpdateContent(string name) { }
        public string Name { get { throw null; } }
        public string Schedule { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ContainerRegistryTaskTriggerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerProperties>
    {
        public ContainerRegistryTaskTriggerProperties() { }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTrigger BaseImageTrigger { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTrigger> SourceTriggers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTrigger> TimerTriggers { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ContainerRegistryTaskTriggerUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerUpdateContent>
    {
        public ContainerRegistryTaskTriggerUpdateContent() { }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerUpdateContent BaseImageTrigger { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerUpdateContent> SourceTriggers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerUpdateContent> TimerTriggers { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTaskUpdateTriggerPayloadType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUpdateTriggerPayloadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTaskUpdateTriggerPayloadType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUpdateTriggerPayloadType Default { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUpdateTriggerPayloadType Token { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUpdateTriggerPayloadType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUpdateTriggerPayloadType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUpdateTriggerPayloadType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUpdateTriggerPayloadType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUpdateTriggerPayloadType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUpdateTriggerPayloadType left, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUpdateTriggerPayloadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryTaskUserIdentityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUserIdentityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUserIdentityProperties>
    {
        public ContainerRegistryTaskUserIdentityProperties() { }
        public string ClientId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUserIdentityProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUserIdentityProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUserIdentityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUserIdentityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUserIdentityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUserIdentityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUserIdentityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUserIdentityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUserIdentityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DockerBuildContent : Azure.ResourceManager.ContainerRegistry.Tasks.Models.RunContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.DockerBuildContent>
    {
        public DockerBuildContent(string dockerFilePath, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties platform) { }
        public int? AgentCpu { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument> Arguments { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials Credentials { get { throw null; } set { } }
        public string DockerFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ImageNames { get { throw null; } }
        public bool? IsCacheDisabled { get { throw null; } set { } }
        public bool? IsPushEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties Platform { get { throw null; } set { } }
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
        public EncodedTaskRunContent(string encodedTaskContent, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties platform) { }
        public int? AgentCpu { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials Credentials { get { throw null; } set { } }
        public string EncodedTaskContent { get { throw null; } set { } }
        public string EncodedValuesContent { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties Platform { get { throw null; } set { } }
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
        public FileTaskRunContent(string taskFilePath, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties platform) { }
        public int? AgentCpu { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties Platform { get { throw null; } set { } }
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
    public partial class TaskPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskPatch>
    {
        public TaskPatch() { }
        public int? AgentCpu { get { throw null; } set { } }
        public string AgentPoolName { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties Identity { get { throw null; } set { } }
        public string LogTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformUpdateContent Platform { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.TaskStepUpdateContent Step { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerUpdateContent Trigger { get { throw null; } set { } }
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
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOverrideStepProperties OverrideTaskStepProperties { get { throw null; } set { } }
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
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties Identity { get { throw null; } set { } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency> BaseImageDependencies { get { throw null; } }
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
}
