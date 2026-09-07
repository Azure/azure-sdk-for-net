namespace Azure.ResourceManager.ContainerRegistry.Tasks
{
    public partial class AzureResourceManagerContainerRegistryTasksContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerContainerRegistryTasksContext() { }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.AzureResourceManagerContainerRegistryTasksContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ContainerRegistryAgentPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryAgentPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource> Get(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource>> GetAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource> GetIfExists(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource>> GetIfExistsAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryAgentPoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData>
    {
        public ContainerRegistryAgentPoolData(Azure.Core.AzureLocation location) { }
        public int? Count { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS? OS { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState? ProvisioningState { get { throw null; } }
        public string Tier { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualNetworkSubnetResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryAgentPoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryAgentPoolResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string agentPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolQueueStatus> GetQueueStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolQueueStatus>> GetQueueStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryRunCollection() { }
        public virtual Azure.Response<bool> Exists(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource> Get(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource>> GetAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource> GetIfExists(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource>> GetIfExistsAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryRunData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData>
    {
        internal ContainerRegistryRunData() { }
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
        public System.DateTimeOffset? StartsOn { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus? Status { get { throw null; } }
        public string Task { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerDescriptor TimerTrigger { get { throw null; } }
        public string UpdateTriggerToken { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryRunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryRunResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string runId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunLogResult> GetLogSasUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunLogResult>> GetLogSasUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource> Update(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource>> UpdateAsync(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryTaskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryTaskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string taskName, Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string taskName, Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource> Get(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource>> GetAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource> GetIfExists(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource>> GetIfExistsAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryTaskData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData>
    {
        public ContainerRegistryTaskData(Azure.Core.AzureLocation location) { }
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
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties Step { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerProperties Trigger { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryTaskResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string taskName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource> GetDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource>> GetDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource> Update(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource>> UpdateAsync(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryTaskRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryTaskRunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string taskRunName, Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string taskRunName, Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource> Get(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource>> GetAsync(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource> GetIfExists(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource>> GetIfExistsAsync(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryTaskRunData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData>
    {
        public ContainerRegistryTaskRunData() { }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent RunRequest { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData RunResult { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskRunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryTaskRunResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string taskRunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource> GetDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource>> GetDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ContainerRegistryTasksExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult> GetBuildSourceUploadUrl(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult>> GetBuildSourceUploadUrlAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource> GetContainerRegistryAgentPool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource>> GetContainerRegistryAgentPoolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource GetContainerRegistryAgentPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolCollection GetContainerRegistryAgentPools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource> GetContainerRegistryRun(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource>> GetContainerRegistryRunAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource GetContainerRegistryRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunCollection GetContainerRegistryRuns(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource> GetContainerRegistryTask(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource>> GetContainerRegistryTaskAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource GetContainerRegistryTaskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource> GetContainerRegistryTaskRun(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource>> GetContainerRegistryTaskRunAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource GetContainerRegistryTaskRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunCollection GetContainerRegistryTaskRuns(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskCollection GetContainerRegistryTasks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource> ScheduleRun(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource>> ScheduleRunAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerRegistry.Tasks.Mocking
{
    public partial class MockableContainerRegistryTasksArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerRegistryTasksArmClient() { }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource GetContainerRegistryAgentPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource GetContainerRegistryRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource GetContainerRegistryTaskResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource GetContainerRegistryTaskRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableContainerRegistryTasksResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerRegistryTasksResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult> GetBuildSourceUploadUrl(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult>> GetBuildSourceUploadUrlAsync(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource> GetContainerRegistryAgentPool(string registryName, string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolResource>> GetContainerRegistryAgentPoolAsync(string registryName, string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolCollection GetContainerRegistryAgentPools(string registryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource> GetContainerRegistryRun(string registryName, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource>> GetContainerRegistryRunAsync(string registryName, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunCollection GetContainerRegistryRuns(string registryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource> GetContainerRegistryTask(string registryName, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskResource>> GetContainerRegistryTaskAsync(string registryName, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource> GetContainerRegistryTaskRun(string registryName, string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunResource>> GetContainerRegistryTaskRunAsync(string registryName, string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunCollection GetContainerRegistryTaskRuns(string registryName) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskCollection GetContainerRegistryTasks(string registryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource> ScheduleRun(string registryName, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunResource>> ScheduleRunAsync(string registryName, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerRegistry.Tasks.Models
{
    public static partial class ArmContainerRegistryTasksModelFactory
    {
        public static Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryAgentPoolData ContainerRegistryAgentPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), int? count = default(int?), string tier = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS? os = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS?), Azure.Core.ResourceIdentifier virtualNetworkSubnetResourceId = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolPatch ContainerRegistryAgentPoolPatch(int? count = default(int?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolQueueStatus ContainerRegistryAgentPoolQueueStatus(int? count = default(int?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildContent ContainerRegistryDockerBuildContent(bool? isArchiveEnabled = default(bool?), string agentPoolName = null, string logTemplate = null, System.Collections.Generic.IEnumerable<string> imageNames = null, bool? isPushEnabled = default(bool?), bool? isCacheDisabled = default(bool?), string dockerFilePath = null, string target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument> arguments = null, int? timeoutInSeconds = default(int?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties platform = null, int? agentCpu = default(int?), string sourceLocation = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials credentials = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildStep ContainerRegistryDockerBuildStep(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null, System.Collections.Generic.IEnumerable<string> imageNames = null, bool? isPushEnabled = default(bool?), bool? isCacheDisabled = default(bool?), string dockerFilePath = null, string target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument> arguments = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildStepUpdateContent ContainerRegistryDockerBuildStepUpdateContent(string contextPath = null, string contextAccessToken = null, System.Collections.Generic.IEnumerable<string> imageNames = null, bool? isPushEnabled = default(bool?), bool? isCacheDisabled = default(bool?), string dockerFilePath = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument> arguments = null, string target = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskRunContent ContainerRegistryEncodedTaskRunContent(bool? isArchiveEnabled = default(bool?), string agentPoolName = null, string logTemplate = null, string encodedTaskContent = null, string encodedValuesContent = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null, int? timeoutInSeconds = default(int?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties platform = null, int? agentCpu = default(int?), string sourceLocation = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials credentials = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskStep ContainerRegistryEncodedTaskStep(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null, string encodedTaskContent = null, string encodedValuesContent = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskStepUpdateContent ContainerRegistryEncodedTaskStepUpdateContent(string contextPath = null, string contextAccessToken = null, string encodedTaskContent = null, string encodedValuesContent = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskRunContent ContainerRegistryFileTaskRunContent(bool? isArchiveEnabled = default(bool?), string agentPoolName = null, string logTemplate = null, string taskFilePath = null, string valuesFilePath = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null, int? timeoutInSeconds = default(int?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties platform = null, int? agentCpu = default(int?), string sourceLocation = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials credentials = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskStep ContainerRegistryFileTaskStep(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null, string taskFilePath = null, string valuesFilePath = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskStepUpdateContent ContainerRegistryFileTaskStepUpdateContent(string contextPath = null, string contextAccessToken = null, string taskFilePath = null, string valuesFilePath = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent ContainerRegistryRunContent(string type = null, bool? isArchiveEnabled = default(bool?), string agentPoolName = null, string logTemplate = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData ContainerRegistryRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string runId = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunStatus?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunType? runType = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunType?), string agentPoolName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? startsOn = default(System.DateTimeOffset?), System.DateTimeOffset? finishOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor> outputImages = null, string task = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageUpdateTrigger imageUpdateTrigger = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerDescriptor sourceTrigger = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerDescriptor timerTrigger = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties platform = null, string sourceRegistryAuth = null, System.Collections.Generic.IEnumerable<string> customRegistries = null, string runErrorMessage = null, string updateTriggerToken = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor logArtifact = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState?), bool? isArchiveEnabled = default(bool?), int? agentCpu = default(int?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunPatch ContainerRegistryRunPatch(bool? isArchiveEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument ContainerRegistryTaskArgument(string name = null, string value = null, bool? isSecret = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfo ContainerRegistryTaskAuthInfo(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTokenType tokenType = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTokenType), string token = null, string refreshToken = null, string scope = null, int? expiresInSeconds = default(int?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfoUpdateContent ContainerRegistryTaskAuthInfoUpdateContent(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTokenType? tokenType = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTokenType?), string token = null, string refreshToken = null, string scope = null, int? expiresInSeconds = default(int?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency ContainerRegistryTaskBaseImageDependency(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependencyType? type = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependencyType?), string registry = null, string repository = null, string tag = null, string digest = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTrigger ContainerRegistryTaskBaseImageTrigger(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerType baseImageTriggerType = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerType), string updateTriggerEndpoint = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUpdateTriggerPayloadType? updateTriggerPayloadType = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUpdateTriggerPayloadType?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus?), string name = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerUpdateContent ContainerRegistryTaskBaseImageTriggerUpdateContent(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerType? baseImageTriggerType = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerType?), string updateTriggerEndpoint = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUpdateTriggerPayloadType? updateTriggerPayloadType = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUpdateTriggerPayloadType?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus?), string name = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials ContainerRegistryTaskCredentials(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryCredentials sourceRegistry = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCustomRegistryCredentials> customRegistries = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCustomRegistryCredentials ContainerRegistryTaskCustomRegistryCredentials(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObject userName = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObject password = null, string identity = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskData ContainerRegistryTaskData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties platform = null, string agentPoolName = null, int? timeoutInSeconds = default(int?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties step = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerProperties trigger = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials credentials = null, string logTemplate = null, bool? isSystemTask = default(bool?), int? agentCpu = default(int?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties identity = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties ContainerRegistryTaskIdentityProperties(string principalId = null, string tenantId = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskResourceIdentityType? type = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskResourceIdentityType?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUserIdentityProperties> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor ContainerRegistryTaskImageDescriptor(string registry = null, string repository = null, string tag = null, string digest = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageUpdateTrigger ContainerRegistryTaskImageUpdateTrigger(string id = null, System.DateTimeOffset? occurredOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskImageDescriptor> images = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOverrideStepProperties ContainerRegistryTaskOverrideStepProperties(string contextPath = null, string file = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument> arguments = null, string target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> values = null, string updateTriggerToken = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPatch ContainerRegistryTaskPatch(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties identity = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformUpdateContent platform = null, string agentPoolName = null, int? timeoutInSeconds = default(int?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent step = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerUpdateContent trigger = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials credentials = null, string logTemplate = null, int? agentCpu = default(int?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties ContainerRegistryTaskPlatformProperties(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS os = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture? architecture = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskVariant? variant = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskVariant?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformUpdateContent ContainerRegistryTaskPlatformUpdateContent(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS? os = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOS?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture? architecture = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArchitecture?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskVariant? variant = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskVariant?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunContent ContainerRegistryTaskRunContent(bool? isArchiveEnabled = default(bool?), string agentPoolName = null, string logTemplate = null, string taskId = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOverrideStepProperties overrideTaskStepProperties = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryTaskRunData ContainerRegistryTaskRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskProvisioningState?), Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent runRequest = null, Azure.ResourceManager.ContainerRegistry.Tasks.ContainerRegistryRunData runResult = null, string forceUpdateTag = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties identity = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunLogResult ContainerRegistryTaskRunLogResult(string logLink = null, string logArtifactLink = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunPatch ContainerRegistryTaskRunPatch(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties identity = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent runRequest = null, string forceUpdateTag = null, string location = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObject ContainerRegistryTaskSecretObject(string value = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObjectType? type = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSecretObjectType?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue ContainerRegistryTaskSetValue(string name = null, string value = null, bool? isSecret = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceProperties ContainerRegistryTaskSourceProperties(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceControlType sourceControlType = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceControlType), System.Uri repositoryUri = null, string branch = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfo sourceControlAuthProperties = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryCredentials ContainerRegistryTaskSourceRegistryCredentials(string identity = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryLoginMode? loginMode = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceRegistryLoginMode?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTrigger ContainerRegistryTaskSourceTrigger(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceProperties sourceRepository = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerEvent> sourceTriggerEvents = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus?), string name = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerDescriptor ContainerRegistryTaskSourceTriggerDescriptor(string id = null, string eventType = null, string commitId = null, string pullRequestId = null, System.Uri repositoryUri = null, string branchName = null, string providerType = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerUpdateContent ContainerRegistryTaskSourceTriggerUpdateContent(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUpdateContent sourceRepository = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerEvent> sourceTriggerEvents = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus?), string name = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUpdateContent ContainerRegistryTaskSourceUpdateContent(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceControlType? sourceControlType = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceControlType?), string repositoryUri = null, string branch = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskAuthInfoUpdateContent sourceControlAuthProperties = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceUploadResult ContainerRegistryTaskSourceUploadResult(string uploadUri = null, string relativePath = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties ContainerRegistryTaskStepProperties(string type = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent ContainerRegistryTaskStepUpdateContent(string type = null, string contextPath = null, string contextAccessToken = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTrigger ContainerRegistryTaskTimerTrigger(string schedule = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus?), string name = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerDescriptor ContainerRegistryTaskTimerTriggerDescriptor(string timerTriggerName = null, string scheduleOccurrence = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerUpdateContent ContainerRegistryTaskTimerTriggerUpdateContent(string schedule = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus? status = default(Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerStatus?), string name = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerProperties ContainerRegistryTaskTriggerProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTrigger> timerTriggers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTrigger> sourceTriggers = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTrigger baseImageTrigger = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerUpdateContent ContainerRegistryTaskTriggerUpdateContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTimerTriggerUpdateContent> timerTriggers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSourceTriggerUpdateContent> sourceTriggers = null, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageTriggerUpdateContent baseImageTrigger = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskUserIdentityProperties ContainerRegistryTaskUserIdentityProperties(string principalId = null, string clientId = null) { throw null; }
    }
    public partial class ContainerRegistryAgentPoolPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolPatch>
    {
        public ContainerRegistryAgentPoolPatch() { }
        public int? Count { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryAgentPoolQueueStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolQueueStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolQueueStatus>
    {
        internal ContainerRegistryAgentPoolQueueStatus() { }
        public int? Count { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolQueueStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolQueueStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolQueueStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolQueueStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolQueueStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolQueueStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolQueueStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolQueueStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryAgentPoolQueueStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryDockerBuildContent : Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildContent>
    {
        public ContainerRegistryDockerBuildContent(string dockerFilePath, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties platform) { }
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
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryDockerBuildStep : Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildStep>
    {
        public ContainerRegistryDockerBuildStep(string dockerFilePath) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument> Arguments { get { throw null; } }
        public string DockerFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ImageNames { get { throw null; } }
        public bool? IsCacheDisabled { get { throw null; } set { } }
        public bool? IsPushEnabled { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryDockerBuildStepUpdateContent : Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildStepUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildStepUpdateContent>
    {
        public ContainerRegistryDockerBuildStepUpdateContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskArgument> Arguments { get { throw null; } }
        public string DockerFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ImageNames { get { throw null; } }
        public bool? IsCacheDisabled { get { throw null; } set { } }
        public bool? IsPushEnabled { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildStepUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildStepUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildStepUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildStepUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildStepUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildStepUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryDockerBuildStepUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryEncodedTaskRunContent : Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskRunContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskRunContent>
    {
        public ContainerRegistryEncodedTaskRunContent(string encodedTaskContent, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties platform) { }
        public int? AgentCpu { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials Credentials { get { throw null; } set { } }
        public string EncodedTaskContent { get { throw null; } set { } }
        public string EncodedValuesContent { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties Platform { get { throw null; } set { } }
        public string SourceLocation { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> Values { get { throw null; } }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskRunContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskRunContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskRunContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskRunContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskRunContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskRunContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskRunContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryEncodedTaskStep : Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskStep>
    {
        public ContainerRegistryEncodedTaskStep(string encodedTaskContent) { }
        public string EncodedTaskContent { get { throw null; } set { } }
        public string EncodedValuesContent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> Values { get { throw null; } }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryEncodedTaskStepUpdateContent : Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskStepUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskStepUpdateContent>
    {
        public ContainerRegistryEncodedTaskStepUpdateContent() { }
        public string EncodedTaskContent { get { throw null; } set { } }
        public string EncodedValuesContent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> Values { get { throw null; } }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskStepUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskStepUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskStepUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskStepUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskStepUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskStepUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryEncodedTaskStepUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryFileTaskRunContent : Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskRunContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskRunContent>
    {
        public ContainerRegistryFileTaskRunContent(string taskFilePath, Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties platform) { }
        public int? AgentCpu { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformProperties Platform { get { throw null; } set { } }
        public string SourceLocation { get { throw null; } set { } }
        public string TaskFilePath { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> Values { get { throw null; } }
        public string ValuesFilePath { get { throw null; } set { } }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskRunContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskRunContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskRunContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskRunContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskRunContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskRunContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskRunContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryFileTaskStep : Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskStep>
    {
        public ContainerRegistryFileTaskStep(string taskFilePath) { }
        public string TaskFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> Values { get { throw null; } }
        public string ValuesFilePath { get { throw null; } set { } }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryFileTaskStepUpdateContent : Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskStepUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskStepUpdateContent>
    {
        public ContainerRegistryFileTaskStepUpdateContent() { }
        public string TaskFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskSetValue> Values { get { throw null; } }
        public string ValuesFilePath { get { throw null; } set { } }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskStepUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskStepUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskStepUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskStepUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskStepUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskStepUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryFileTaskStepUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ContainerRegistryRunContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent>
    {
        internal ContainerRegistryRunContent() { }
        public string AgentPoolName { get { throw null; } set { } }
        public bool? IsArchiveEnabled { get { throw null; } set { } }
        public string LogTemplate { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryRunPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunPatch>
    {
        public ContainerRegistryRunPatch() { }
        public bool? IsArchiveEnabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ContainerRegistryTaskPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPatch>
    {
        public ContainerRegistryTaskPatch() { }
        public int? AgentCpu { get { throw null; } set { } }
        public string AgentPoolName { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskCredentials Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties Identity { get { throw null; } set { } }
        public string LogTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPlatformUpdateContent Platform { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent Step { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskTriggerUpdateContent Trigger { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ContainerRegistryTaskRunContent : Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunContent>
    {
        public ContainerRegistryTaskRunContent(string taskId) { }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskOverrideStepProperties OverrideTaskStepProperties { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ContainerRegistryTaskRunPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunPatch>
    {
        public ContainerRegistryTaskRunPatch() { }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskIdentityProperties Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryRunContent RunRequest { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskRunPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class ContainerRegistryTaskStepProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties>
    {
        internal ContainerRegistryTaskStepProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskBaseImageDependency> BaseImageDependencies { get { throw null; } }
        public string ContextAccessToken { get { throw null; } set { } }
        public string ContextPath { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ContainerRegistryTaskStepUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent>
    {
        internal ContainerRegistryTaskStepUpdateContent() { }
        public string ContextAccessToken { get { throw null; } set { } }
        public string ContextPath { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Tasks.Models.ContainerRegistryTaskStepUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
}
