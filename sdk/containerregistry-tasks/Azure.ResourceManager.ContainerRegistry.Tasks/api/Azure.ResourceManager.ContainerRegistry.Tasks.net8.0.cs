namespace Azure.ResourceManager.ContainerRegistry
{
    public partial class ContainerRegistryAgentPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryAgentPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> Get(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>> GetAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> GetIfExists(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>> GetIfExistsAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryAgentPoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>
    {
        public ContainerRegistryAgentPoolData(Azure.Core.AzureLocation location) { }
        public int? Count { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS? OS { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public string Tier { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualNetworkSubnetResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryAgentPoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryAgentPoolResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string agentPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus> GetQueueStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus>> GetQueueStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryRunCollection() { }
        public virtual Azure.Response<bool> Exists(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> Get(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>> GetAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> GetIfExists(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>> GetIfExistsAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryRunData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>
    {
        public ContainerRegistryRunData() { }
        public int? AgentCpu { get { throw null; } set { } }
        public string AgentPoolName { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> CustomRegistries { get { throw null; } }
        public System.DateTimeOffset? FinishOn { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger ImageUpdateTrigger { get { throw null; } set { } }
        public bool? IsArchiveEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor LogArtifact { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor> OutputImages { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties Platform { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string RunErrorMessage { get { throw null; } }
        public string RunId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType? RunType { get { throw null; } set { } }
        public string SourceRegistryAuth { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor SourceTrigger { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus? Status { get { throw null; } set { } }
        public string Task { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor TimerTrigger { get { throw null; } set { } }
        public string UpdateTriggerToken { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryRunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryRunResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string runId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult> GetLogSasUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult>> GetLogSasUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryTaskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryTaskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string taskName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string taskName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> Get(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> GetAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> GetIfExists(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> GetIfExistsAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryTaskData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>
    {
        public ContainerRegistryTaskData(Azure.Core.AzureLocation location) { }
        public int? AgentCpu { get { throw null; } set { } }
        public string AgentPoolName { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsSystemTask { get { throw null; } set { } }
        public string LogTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties Platform { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties Step { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties Trigger { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryTaskResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string taskName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> GetDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> GetDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryTaskRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryTaskRunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string taskRunName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string taskRunName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> Get(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>> GetAsync(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> GetIfExists(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>> GetIfExistsAsync(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryTaskRunData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>
    {
        public ContainerRegistryTaskRunData() { }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent RunRequest { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData RunResult { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskRunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryTaskRunResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string taskRunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> GetDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>> GetDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerRegistry.Models
{
    public partial class ContainerRegistryAgentPoolListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolListResult>
    {
        internal ContainerRegistryAgentPoolListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryAgentPoolPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch>
    {
        public ContainerRegistryAgentPoolPatch() { }
        public int? Count { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryAgentPoolQueueStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus>
    {
        internal ContainerRegistryAgentPoolQueueStatus() { }
        public int? Count { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryAgentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentProperties>
    {
        public ContainerRegistryAgentProperties() { }
        public int? Cpu { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryBaseImageDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency>
    {
        internal ContainerRegistryBaseImageDependency() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType? DependencyType { get { throw null; } }
        public string Digest { get { throw null; } }
        public string Registry { get { throw null; } }
        public string Repository { get { throw null; } }
        public string Tag { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryBaseImageDependencyType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryBaseImageDependencyType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType BuildTime { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType RunTime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryBaseImageTrigger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTrigger>
    {
        public ContainerRegistryBaseImageTrigger(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType baseImageTriggerType, string name) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType BaseImageTriggerType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus? Status { get { throw null; } set { } }
        public string UpdateTriggerEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType? UpdateTriggerPayloadType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryBaseImageTriggerType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryBaseImageTriggerType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType All { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType Runtime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryBaseImageTriggerUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent>
    {
        public ContainerRegistryBaseImageTriggerUpdateContent(string name) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType? BaseImageTriggerType { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus? Status { get { throw null; } set { } }
        public string UpdateTriggerEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType? UpdateTriggerPayloadType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryCpuVariant : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryCpuVariant(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant V6 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant V7 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant V8 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials>
    {
        public ContainerRegistryCredentials() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials> CustomRegistries { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode? SourceRegistryLoginMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryDockerBuildContent : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildContent>
    {
        public ContainerRegistryDockerBuildContent(string dockerFilePath, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties platform) { }
        public int? AgentCpu { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument> Arguments { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials Credentials { get { throw null; } set { } }
        public string DockerFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ImageNames { get { throw null; } }
        public bool? IsPushEnabled { get { throw null; } set { } }
        public bool? NoCache { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties Platform { get { throw null; } set { } }
        public string SourceLocation { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryDockerBuildStep : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStep>
    {
        public ContainerRegistryDockerBuildStep(string dockerFilePath) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument> Arguments { get { throw null; } }
        public string DockerFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ImageNames { get { throw null; } }
        public bool? IsPushEnabled { get { throw null; } set { } }
        public bool? NoCache { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryDockerBuildStepUpdateContent : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStepUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStepUpdateContent>
    {
        public ContainerRegistryDockerBuildStepUpdateContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument> Arguments { get { throw null; } }
        public string DockerFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ImageNames { get { throw null; } }
        public bool? IsPushEnabled { get { throw null; } set { } }
        public bool? NoCache { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStepUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStepUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStepUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStepUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStepUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStepUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStepUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryEncodedTaskRunContent : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskRunContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskRunContent>
    {
        public ContainerRegistryEncodedTaskRunContent(string encodedTaskContent, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties platform) { }
        public int? AgentCpu { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials Credentials { get { throw null; } set { } }
        public string EncodedTaskContent { get { throw null; } set { } }
        public string EncodedValuesContent { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties Platform { get { throw null; } set { } }
        public string SourceLocation { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskRunContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskRunContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskRunContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskRunContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskRunContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskRunContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskRunContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryEncodedTaskStep : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStep>
    {
        public ContainerRegistryEncodedTaskStep(string encodedTaskContent) { }
        public string EncodedTaskContent { get { throw null; } set { } }
        public string EncodedValuesContent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryEncodedTaskStepUpdateContent : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStepUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStepUpdateContent>
    {
        public ContainerRegistryEncodedTaskStepUpdateContent() { }
        public string EncodedTaskContent { get { throw null; } set { } }
        public string EncodedValuesContent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStepUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStepUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStepUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStepUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStepUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStepUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStepUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryFileTaskRunContent : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskRunContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskRunContent>
    {
        public ContainerRegistryFileTaskRunContent(string taskFilePath, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties platform) { }
        public int? AgentCpu { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties Platform { get { throw null; } set { } }
        public string SourceLocation { get { throw null; } set { } }
        public string TaskFilePath { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
        public string ValuesFilePath { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskRunContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskRunContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskRunContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskRunContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskRunContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskRunContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskRunContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryFileTaskStep : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStep>
    {
        public ContainerRegistryFileTaskStep(string taskFilePath) { }
        public string TaskFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
        public string ValuesFilePath { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryFileTaskStepUpdateContent : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStepUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStepUpdateContent>
    {
        public ContainerRegistryFileTaskStepUpdateContent() { }
        public string TaskFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
        public string ValuesFilePath { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStepUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStepUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStepUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStepUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStepUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStepUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStepUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryImageDescriptor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor>
    {
        public ContainerRegistryImageDescriptor() { }
        public string Digest { get { throw null; } set { } }
        public string Registry { get { throw null; } set { } }
        public string Repository { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryImageUpdateTrigger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger>
    {
        public ContainerRegistryImageUpdateTrigger() { }
        public System.Guid? Id { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor> Images { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryOS : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryOS(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS Linux { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryOSArchitecture : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryOSArchitecture(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture Amd64 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture Arm { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture Arm64 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture ThreeHundredEightySix { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture X86 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryOverrideTaskStepProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOverrideTaskStepProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOverrideTaskStepProperties>
    {
        public ContainerRegistryOverrideTaskStepProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument> Arguments { get { throw null; } }
        public string ContextPath { get { throw null; } set { } }
        public string File { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public string UpdateTriggerToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOverrideTaskStepProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOverrideTaskStepProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOverrideTaskStepProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOverrideTaskStepProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOverrideTaskStepProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOverrideTaskStepProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOverrideTaskStepProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryPlatformProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties>
    {
        public ContainerRegistryPlatformProperties(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS os) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture? Architecture { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS OS { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant? Variant { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryPlatformUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformUpdateContent>
    {
        public ContainerRegistryPlatformUpdateContent() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture? Architecture { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS? OS { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant? Variant { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryRunArgument : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument>
    {
        public ContainerRegistryRunArgument(string name, string value) { }
        public bool? IsSecret { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ContainerRegistryRunContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent>
    {
        protected ContainerRegistryRunContent() { }
        public string AgentPoolName { get { throw null; } set { } }
        public bool? IsArchiveEnabled { get { throw null; } set { } }
        public string LogTemplate { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryRunGetLogResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult>
    {
        internal ContainerRegistryRunGetLogResult() { }
        public string LogArtifactLink { get { throw null; } }
        public string LogLink { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryRunListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunListResult>
    {
        internal ContainerRegistryRunListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryRunPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch>
    {
        public ContainerRegistryRunPatch() { }
        public bool? IsArchiveEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryRunStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryRunStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus Error { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus Running { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus Started { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryRunType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryRunType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType AutoBuild { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType AutoRun { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType QuickBuild { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType QuickRun { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistrySecretObject : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject>
    {
        public ContainerRegistrySecretObject() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObjectType? ObjectType { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistrySecretObjectType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObjectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistrySecretObjectType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObjectType Opaque { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObjectType VaultSecret { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObjectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObjectType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObjectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObjectType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObjectType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObjectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistrySourceTrigger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTrigger>
    {
        public ContainerRegistrySourceTrigger(Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties sourceRepository, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent> sourceTriggerEvents, string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties SourceRepository { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent> SourceTriggerEvents { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistrySourceTriggerDescriptor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor>
    {
        public ContainerRegistrySourceTriggerDescriptor() { }
        public string BranchName { get { throw null; } set { } }
        public string CommitId { get { throw null; } set { } }
        public string EventType { get { throw null; } set { } }
        public System.Guid? Id { get { throw null; } set { } }
        public string ProviderType { get { throw null; } set { } }
        public string PullRequestId { get { throw null; } set { } }
        public System.Uri RepositoryUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistrySourceTriggerEvent : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistrySourceTriggerEvent(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent Commit { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent PullRequest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistrySourceTriggerUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent>
    {
        public ContainerRegistrySourceTriggerUpdateContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent SourceRepository { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent> SourceTriggerEvents { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskListResult>
    {
        internal ContainerRegistryTaskListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskOverridableValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue>
    {
        public ContainerRegistryTaskOverridableValue(string name, string value) { }
        public bool? IsSecret { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch>
    {
        public ContainerRegistryTaskPatch() { }
        public int? AgentCpu { get { throw null; } set { } }
        public string AgentPoolName { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string LogTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformUpdateContent Platform { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent Step { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerUpdateContent Trigger { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskRunContent : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunContent>
    {
        public ContainerRegistryTaskRunContent(Azure.Core.ResourceIdentifier taskId) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOverrideTaskStepProperties OverrideTaskStepProperties { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TaskId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskRunListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunListResult>
    {
        internal ContainerRegistryTaskRunListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskRunPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch>
    {
        public ContainerRegistryTaskRunPatch() { }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent RunRequest { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTaskStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTaskStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ContainerRegistryTaskStepProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties>
    {
        protected ContainerRegistryTaskStepProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency> BaseImageDependencies { get { throw null; } }
        public string ContextAccessToken { get { throw null; } set { } }
        public string ContextPath { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTaskStepType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTaskStepType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepType Docker { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepType EncodedTask { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepType FileTask { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ContainerRegistryTaskStepUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent>
    {
        protected ContainerRegistryTaskStepUpdateContent() { }
        public string ContextAccessToken { get { throw null; } set { } }
        public string ContextPath { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTimerTrigger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTrigger>
    {
        public ContainerRegistryTimerTrigger(string schedule, string name) { }
        public string Name { get { throw null; } set { } }
        public string Schedule { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTimerTriggerDescriptor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor>
    {
        public ContainerRegistryTimerTriggerDescriptor() { }
        public string ScheduleOccurrence { get { throw null; } set { } }
        public string TimerTriggerName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTimerTriggerUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent>
    {
        public ContainerRegistryTimerTriggerUpdateContent(string name) { }
        public string Name { get { throw null; } }
        public string Schedule { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTriggerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties>
    {
        public ContainerRegistryTriggerProperties() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTrigger BaseImageTrigger { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTrigger> SourceTriggers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTrigger> TimerTriggers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTriggerStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTriggerStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryTriggerUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerUpdateContent>
    {
        public ContainerRegistryTriggerUpdateContent() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent BaseImageTrigger { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent> SourceTriggers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent> TimerTriggers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryUpdateTriggerPayloadType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryUpdateTriggerPayloadType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType Default { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType Token { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomRegistryCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials>
    {
        public CustomRegistryCredentials() { }
        public string Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject Password { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject UserName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SourceCodeRepoAuthInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfo>
    {
        public SourceCodeRepoAuthInfo(Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType tokenType, string token) { }
        public int? ExpireInSeconds { get { throw null; } set { } }
        public string RefreshToken { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType TokenType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SourceCodeRepoAuthInfoUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfoUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfoUpdateContent>
    {
        public SourceCodeRepoAuthInfoUpdateContent() { }
        public int? ExpiresIn { get { throw null; } set { } }
        public string RefreshToken { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType? TokenType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfoUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfoUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfoUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfoUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfoUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfoUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfoUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceCodeRepoAuthTokenType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceCodeRepoAuthTokenType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType OAuth { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType Pat { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType left, Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType left, Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SourceCodeRepoProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties>
    {
        public SourceCodeRepoProperties(Azure.ResourceManager.ContainerRegistry.Models.SourceControlType sourceControlType, System.Uri repositoryUri) { }
        public string Branch { get { throw null; } set { } }
        public System.Uri RepositoryUri { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfo SourceControlAuthProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceControlType SourceControlType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SourceCodeRepoUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent>
    {
        public SourceCodeRepoUpdateContent() { }
        public string Branch { get { throw null; } set { } }
        public System.Uri RepositoryUri { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfoUpdateContent SourceControlAuthProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceControlType? SourceControlType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceControlType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.SourceControlType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceControlType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.SourceControlType Github { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.SourceControlType VisualStudioTeamService { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.SourceControlType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.SourceControlType left, Azure.ResourceManager.ContainerRegistry.Models.SourceControlType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.SourceControlType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.SourceControlType left, Azure.ResourceManager.ContainerRegistry.Models.SourceControlType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SourceRegistryCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryCredentials>
    {
        public SourceRegistryCredentials() { }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode? LoginMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceRegistryLoginMode : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceRegistryLoginMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode Default { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode left, Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode left, Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SourceUploadDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition>
    {
        internal SourceUploadDefinition() { }
        public string RelativePath { get { throw null; } }
        public System.Uri UploadUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerRegistry.Tasks
{
    public partial class AzureResourceManagerContainerRegistryTasksContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerContainerRegistryTasksContext() { }
        public static Azure.ResourceManager.ContainerRegistry.Tasks.AzureResourceManagerContainerRegistryTasksContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ContainerRegistryTasksExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition> GetBuildSourceUploadUrl(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition>> GetBuildSourceUploadUrlAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> GetContainerRegistryAgentPool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>> GetContainerRegistryAgentPoolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource GetContainerRegistryAgentPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolCollection GetContainerRegistryAgentPools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> GetContainerRegistryRun(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>> GetContainerRegistryRunAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource GetContainerRegistryRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunCollection GetContainerRegistryRuns(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> GetContainerRegistryTask(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> GetContainerRegistryTaskAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource GetContainerRegistryTaskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> GetContainerRegistryTaskRun(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>> GetContainerRegistryTaskRunAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource GetContainerRegistryTaskRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunCollection GetContainerRegistryTaskRuns(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskCollection GetContainerRegistryTasks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> ScheduleRun(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string registryName, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>> ScheduleRunAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string registryName, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerRegistry.Tasks.Mocking
{
    public partial class MockableContainerRegistryTasksArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerRegistryTasksArmClient() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource GetContainerRegistryAgentPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource GetContainerRegistryRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource GetContainerRegistryTaskResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource GetContainerRegistryTaskRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableContainerRegistryTasksResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerRegistryTasksResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition> GetBuildSourceUploadUrl(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition>> GetBuildSourceUploadUrlAsync(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> GetContainerRegistryAgentPool(string registryName, string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>> GetContainerRegistryAgentPoolAsync(string registryName, string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolCollection GetContainerRegistryAgentPools(string registryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> GetContainerRegistryRun(string registryName, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>> GetContainerRegistryRunAsync(string registryName, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunCollection GetContainerRegistryRuns(string registryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> GetContainerRegistryTask(string registryName, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> GetContainerRegistryTaskAsync(string registryName, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> GetContainerRegistryTaskRun(string registryName, string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>> GetContainerRegistryTaskRunAsync(string registryName, string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunCollection GetContainerRegistryTaskRuns(string registryName) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskCollection GetContainerRegistryTasks(string registryName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> ScheduleRun(Azure.WaitUntil waitUntil, string registryName, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>> ScheduleRunAsync(Azure.WaitUntil waitUntil, string registryName, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
