namespace Azure.ResourceManager.StorageMover
{
    public partial class AzureResourceManagerStorageMoverContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerStorageMoverContext() { }
        public static Azure.ResourceManager.StorageMover.AzureResourceManagerStorageMoverContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class JobDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.JobDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.JobDefinitionResource>, System.Collections.IEnumerable
    {
        protected JobDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageMover.JobDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jobDefinitionName, Azure.ResourceManager.StorageMover.JobDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageMover.JobDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jobDefinitionName, Azure.ResourceManager.StorageMover.JobDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.JobDefinitionResource> Get(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageMover.JobDefinitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageMover.JobDefinitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.JobDefinitionResource>> GetAsync(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.StorageMover.JobDefinitionResource> GetIfExists(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StorageMover.JobDefinitionResource>> GetIfExistsAsync(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageMover.JobDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.JobDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageMover.JobDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.JobDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobDefinitionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.JobDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.JobDefinitionData>
    {
        public JobDefinitionData(Azure.ResourceManager.StorageMover.Models.StorageMoverCopyMode copyMode, string sourceName, string targetName) { }
        public string AgentName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AgentResourceId { get { throw null; } }
        public Azure.ResourceManager.StorageMover.Models.StorageMoverCopyMode CopyMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.StorageMover.Models.JobType? JobType { get { throw null; } set { } }
        public string LatestJobRunName { get { throw null; } }
        public Azure.Core.ResourceIdentifier LatestJobRunResourceId { get { throw null; } }
        public Azure.ResourceManager.StorageMover.Models.JobRunStatus? LatestJobRunStatus { get { throw null; } }
        public Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState? ProvisioningState { get { throw null; } }
        public string SourceName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } }
        public string SourceSubpath { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StorageMover.Models.SourceTargetMap> SourceTargetMapValue { get { throw null; } }
        public string TargetName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } }
        public string TargetSubpath { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.JobDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.JobDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.JobDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.JobDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.JobDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.JobDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.JobDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JobDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.JobDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.JobDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobDefinitionResource() { }
        public virtual Azure.ResourceManager.StorageMover.JobDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName, string projectName, string jobDefinitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.JobDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.JobDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.JobRunResource> GetJobRun(string jobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.JobRunResource>> GetJobRunAsync(string jobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageMover.JobRunCollection GetJobRuns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.Models.JobRunResourceId> StartJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.Models.JobRunResourceId>> StartJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.Models.JobRunResourceId> StopJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.Models.JobRunResourceId>> StopJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.StorageMover.JobDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.JobDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.JobDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.JobDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.JobDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.JobDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.JobDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.JobDefinitionResource> Update(Azure.ResourceManager.StorageMover.Models.JobDefinitionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.JobDefinitionResource>> UpdateAsync(Azure.ResourceManager.StorageMover.Models.JobDefinitionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.JobRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.JobRunResource>, System.Collections.IEnumerable
    {
        protected JobRunCollection() { }
        public virtual Azure.Response<bool> Exists(string jobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.JobRunResource> Get(string jobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageMover.JobRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageMover.JobRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.JobRunResource>> GetAsync(string jobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.StorageMover.JobRunResource> GetIfExists(string jobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StorageMover.JobRunResource>> GetIfExistsAsync(string jobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageMover.JobRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.JobRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageMover.JobRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.JobRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobRunData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.JobRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.JobRunData>
    {
        public JobRunData() { }
        public string AgentName { get { throw null; } }
        public Azure.Core.ResourceIdentifier AgentResourceId { get { throw null; } }
        public long? BytesExcluded { get { throw null; } }
        public long? BytesFailed { get { throw null; } }
        public long? BytesNoTransferNeeded { get { throw null; } }
        public long? BytesScanned { get { throw null; } }
        public long? BytesTransferred { get { throw null; } }
        public long? BytesUnsupported { get { throw null; } }
        public Azure.ResourceManager.StorageMover.Models.JobRunError Error { get { throw null; } }
        public System.DateTimeOffset? ExecutionEndOn { get { throw null; } }
        public System.DateTimeOffset? ExecutionStartOn { get { throw null; } }
        public long? ItemsExcluded { get { throw null; } }
        public long? ItemsFailed { get { throw null; } }
        public long? ItemsNoTransferNeeded { get { throw null; } }
        public long? ItemsScanned { get { throw null; } }
        public long? ItemsTransferred { get { throw null; } }
        public long? ItemsUnsupported { get { throw null; } }
        public System.BinaryData JobDefinitionProperties { get { throw null; } }
        public System.DateTimeOffset? LastStatusUpdate { get { throw null; } }
        public Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.StorageMover.Models.JobRunScanStatus? ScanStatus { get { throw null; } }
        public string SourceName { get { throw null; } }
        public System.BinaryData SourceProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } }
        public Azure.ResourceManager.StorageMover.Models.JobRunStatus? Status { get { throw null; } }
        public string TargetName { get { throw null; } }
        public System.BinaryData TargetProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.JobRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.JobRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.JobRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.JobRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.JobRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.JobRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.JobRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JobRunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.JobRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.JobRunData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobRunResource() { }
        public virtual Azure.ResourceManager.StorageMover.JobRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName, string projectName, string jobDefinitionName, string jobRunName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.JobRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.JobRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.StorageMover.JobRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.JobRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.JobRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.JobRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.JobRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.JobRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.JobRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageMoverAgentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.StorageMoverAgentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.StorageMoverAgentResource>, System.Collections.IEnumerable
    {
        protected StorageMoverAgentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageMover.StorageMoverAgentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agentName, Azure.ResourceManager.StorageMover.StorageMoverAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageMover.StorageMoverAgentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agentName, Azure.ResourceManager.StorageMover.StorageMoverAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverAgentResource> Get(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageMover.StorageMoverAgentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageMover.StorageMoverAgentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverAgentResource>> GetAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.StorageMover.StorageMoverAgentResource> GetIfExists(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StorageMover.StorageMoverAgentResource>> GetIfExistsAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageMover.StorageMoverAgentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.StorageMoverAgentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageMover.StorageMoverAgentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.StorageMoverAgentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageMoverAgentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverAgentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverAgentData>
    {
        public StorageMoverAgentData(string arcResourceId, string arcVmUuid) { }
        public Azure.ResourceManager.StorageMover.Models.StorageMoverAgentStatus? AgentStatus { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public string ArcResourceId { get { throw null; } set { } }
        public string ArcVmUuid { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPropertiesErrorDetails ErrorDetails { get { throw null; } }
        public System.DateTimeOffset? LastStatusUpdate { get { throw null; } }
        public string LocalIPAddress { get { throw null; } }
        public long? MemoryInMB { get { throw null; } }
        public long? NumberOfCores { get { throw null; } }
        public Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState? ProvisioningState { get { throw null; } }
        public string TimeZone { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StorageMover.Models.UploadLimitWeeklyRecurrence> UploadLimitScheduleWeeklyRecurrences { get { throw null; } }
        public long? UptimeInSeconds { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.StorageMoverAgentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverAgentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverAgentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.StorageMoverAgentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverAgentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverAgentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverAgentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageMoverAgentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverAgentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverAgentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageMoverAgentResource() { }
        public virtual Azure.ResourceManager.StorageMover.StorageMoverAgentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName, string agentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverAgentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverAgentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.StorageMover.StorageMoverAgentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverAgentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverAgentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.StorageMoverAgentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverAgentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverAgentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverAgentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverAgentResource> Update(Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverAgentResource>> UpdateAsync(Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageMoverCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.StorageMoverResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.StorageMoverResource>, System.Collections.IEnumerable
    {
        protected StorageMoverCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageMover.StorageMoverResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageMoverName, Azure.ResourceManager.StorageMover.StorageMoverData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageMover.StorageMoverResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageMoverName, Azure.ResourceManager.StorageMover.StorageMoverData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource> Get(string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageMover.StorageMoverResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageMover.StorageMoverResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource>> GetAsync(string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.StorageMover.StorageMoverResource> GetIfExists(string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StorageMover.StorageMoverResource>> GetIfExistsAsync(string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageMover.StorageMoverResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.StorageMoverResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageMover.StorageMoverResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.StorageMoverResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageMoverData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverData>
    {
        public StorageMoverData(Azure.Core.AzureLocation location) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.StorageMoverData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.StorageMoverData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageMoverEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.StorageMoverEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.StorageMoverEndpointResource>, System.Collections.IEnumerable
    {
        protected StorageMoverEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageMover.StorageMoverEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.StorageMover.StorageMoverEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageMover.StorageMoverEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.StorageMover.StorageMoverEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverEndpointResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageMover.StorageMoverEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageMover.StorageMoverEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverEndpointResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.StorageMover.StorageMoverEndpointResource> GetIfExists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StorageMover.StorageMoverEndpointResource>> GetIfExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageMover.StorageMoverEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.StorageMoverEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageMover.StorageMoverEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.StorageMoverEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageMoverEndpointData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverEndpointData>
    {
        public StorageMoverEndpointData(Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties properties) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.StorageMoverEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.StorageMoverEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageMoverEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverEndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageMoverEndpointResource() { }
        public virtual Azure.ResourceManager.StorageMover.StorageMoverEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.StorageMover.StorageMoverEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.StorageMoverEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverEndpointResource> Update(Azure.ResourceManager.StorageMover.Models.StorageMoverEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverEndpointResource>> UpdateAsync(Azure.ResourceManager.StorageMover.Models.StorageMoverEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class StorageMoverExtensions
    {
        public static Azure.ResourceManager.StorageMover.JobDefinitionResource GetJobDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageMover.JobRunResource GetJobRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource> GetStorageMover(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StorageMover.StorageMoverAgentResource GetStorageMoverAgentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource>> GetStorageMoverAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StorageMover.StorageMoverEndpointResource GetStorageMoverEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageMover.StorageMoverProjectResource GetStorageMoverProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageMover.StorageMoverResource GetStorageMoverResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageMover.StorageMoverCollection GetStorageMovers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StorageMover.StorageMoverResource> GetStorageMovers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StorageMover.StorageMoverResource> GetStorageMoversAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageMoverProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.StorageMoverProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.StorageMoverProjectResource>, System.Collections.IEnumerable
    {
        protected StorageMoverProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageMover.StorageMoverProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.StorageMover.StorageMoverProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageMover.StorageMoverProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.StorageMover.StorageMoverProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverProjectResource> Get(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageMover.StorageMoverProjectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageMover.StorageMoverProjectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverProjectResource>> GetAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.StorageMover.StorageMoverProjectResource> GetIfExists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StorageMover.StorageMoverProjectResource>> GetIfExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageMover.StorageMoverProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.StorageMoverProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageMover.StorageMoverProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.StorageMoverProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageMoverProjectData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverProjectData>
    {
        public StorageMoverProjectData() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.StorageMoverProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.StorageMoverProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageMoverProjectResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverProjectData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageMoverProjectResource() { }
        public virtual Azure.ResourceManager.StorageMover.StorageMoverProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName, string projectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.JobDefinitionResource> GetJobDefinition(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.JobDefinitionResource>> GetJobDefinitionAsync(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageMover.JobDefinitionCollection GetJobDefinitions() { throw null; }
        Azure.ResourceManager.StorageMover.StorageMoverProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.StorageMoverProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverProjectResource> Update(Azure.ResourceManager.StorageMover.Models.StorageMoverProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverProjectResource>> UpdateAsync(Azure.ResourceManager.StorageMover.Models.StorageMoverProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageMoverResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageMoverResource() { }
        public virtual Azure.ResourceManager.StorageMover.StorageMoverData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverAgentResource> GetStorageMoverAgent(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverAgentResource>> GetStorageMoverAgentAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageMover.StorageMoverAgentCollection GetStorageMoverAgents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverEndpointResource> GetStorageMoverEndpoint(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverEndpointResource>> GetStorageMoverEndpointAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageMover.StorageMoverEndpointCollection GetStorageMoverEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverProjectResource> GetStorageMoverProject(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverProjectResource>> GetStorageMoverProjectAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageMover.StorageMoverProjectCollection GetStorageMoverProjects() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.StorageMover.StorageMoverData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.StorageMoverData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.StorageMoverData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.StorageMoverData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource> Update(Azure.ResourceManager.StorageMover.Models.StorageMoverPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource>> UpdateAsync(Azure.ResourceManager.StorageMover.Models.StorageMoverPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StorageMover.Mocking
{
    public partial class MockableStorageMoverArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableStorageMoverArmClient() { }
        public virtual Azure.ResourceManager.StorageMover.JobDefinitionResource GetJobDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StorageMover.JobRunResource GetJobRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StorageMover.StorageMoverAgentResource GetStorageMoverAgentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StorageMover.StorageMoverEndpointResource GetStorageMoverEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StorageMover.StorageMoverProjectResource GetStorageMoverProjectResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StorageMover.StorageMoverResource GetStorageMoverResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableStorageMoverResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableStorageMoverResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource> GetStorageMover(string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource>> GetStorageMoverAsync(string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageMover.StorageMoverCollection GetStorageMovers() { throw null; }
    }
    public partial class MockableStorageMoverSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableStorageMoverSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageMover.StorageMoverResource> GetStorageMovers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageMover.StorageMoverResource> GetStorageMoversAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StorageMover.Models
{
    public static partial class ArmStorageMoverModelFactory
    {
        public static Azure.ResourceManager.StorageMover.Models.AzureMultiCloudConnectorEndpointProperties AzureMultiCloudConnectorEndpointProperties(string description = null, Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState? provisioningState = default(Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState?), Azure.Core.ResourceIdentifier multiCloudConnectorId = null, Azure.Core.ResourceIdentifier awsS3BucketId = null) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.AzureStorageBlobContainerEndpointProperties AzureStorageBlobContainerEndpointProperties(string description = null, Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState? provisioningState = default(Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState?), string storageAccountResourceId = null, string blobContainerName = null) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.AzureStorageNfsFileShareEndpointProperties AzureStorageNfsFileShareEndpointProperties(string description = null, Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState? provisioningState = default(Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState?), Azure.Core.ResourceIdentifier storageAccountResourceId = null, string fileShareName = null) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.AzureStorageSmbFileShareEndpointProperties AzureStorageSmbFileShareEndpointProperties(string description = null, Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState? provisioningState = default(Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState?), Azure.Core.ResourceIdentifier storageAccountResourceId = null, string fileShareName = null) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties EndpointBaseProperties(string endpointType = null, string description = null, Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState? provisioningState = default(Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.StorageMover.JobDefinitionData JobDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, Azure.ResourceManager.StorageMover.Models.JobType? jobType = default(Azure.ResourceManager.StorageMover.Models.JobType?), Azure.ResourceManager.StorageMover.Models.StorageMoverCopyMode copyMode = default(Azure.ResourceManager.StorageMover.Models.StorageMoverCopyMode), string sourceName = null, Azure.Core.ResourceIdentifier sourceResourceId = null, string sourceSubpath = null, string targetName = null, Azure.Core.ResourceIdentifier targetResourceId = null, string targetSubpath = null, string latestJobRunName = null, Azure.Core.ResourceIdentifier latestJobRunResourceId = null, Azure.ResourceManager.StorageMover.Models.JobRunStatus? latestJobRunStatus = default(Azure.ResourceManager.StorageMover.Models.JobRunStatus?), string agentName = null, Azure.Core.ResourceIdentifier agentResourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.Models.SourceTargetMap> sourceTargetMapValue = null, Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState? provisioningState = default(Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.StorageMover.JobRunData JobRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.StorageMover.Models.JobRunStatus? status = default(Azure.ResourceManager.StorageMover.Models.JobRunStatus?), Azure.ResourceManager.StorageMover.Models.JobRunScanStatus? scanStatus = default(Azure.ResourceManager.StorageMover.Models.JobRunScanStatus?), string agentName = null, Azure.Core.ResourceIdentifier agentResourceId = null, System.DateTimeOffset? executionStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? executionEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastStatusUpdate = default(System.DateTimeOffset?), long? itemsScanned = default(long?), long? itemsExcluded = default(long?), long? itemsUnsupported = default(long?), long? itemsNoTransferNeeded = default(long?), long? itemsFailed = default(long?), long? itemsTransferred = default(long?), long? bytesScanned = default(long?), long? bytesExcluded = default(long?), long? bytesUnsupported = default(long?), long? bytesNoTransferNeeded = default(long?), long? bytesFailed = default(long?), long? bytesTransferred = default(long?), string sourceName = null, Azure.Core.ResourceIdentifier sourceResourceId = null, System.BinaryData sourceProperties = null, string targetName = null, Azure.Core.ResourceIdentifier targetResourceId = null, System.BinaryData targetProperties = null, System.BinaryData jobDefinitionProperties = null, Azure.ResourceManager.StorageMover.Models.JobRunError error = null, Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState? provisioningState = default(Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.JobRunError JobRunError(string code = null, string message = null, string target = null) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.JobRunResourceId JobRunResourceId(Azure.Core.ResourceIdentifier jobRunResourceIdValue = null) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.NfsMountEndpointProperties NfsMountEndpointProperties(string description = null, Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState? provisioningState = default(Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState?), string host = null, Azure.ResourceManager.StorageMover.Models.NfsVersion? nfsVersion = default(Azure.ResourceManager.StorageMover.Models.NfsVersion?), string export = null) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.SmbMountEndpointProperties SmbMountEndpointProperties(string description = null, Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState? provisioningState = default(Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState?), string host = null, string shareName = null, Azure.ResourceManager.StorageMover.Models.AzureKeyVaultSmbCredentials credentials = null) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.SourceEndpointProperties SourceEndpointProperties(string name = null, Azure.Core.ResourceIdentifier sourceEndpointResourceId = null, Azure.Core.ResourceIdentifier awsS3BucketId = null) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.SourceTargetMap SourceTargetMap(Azure.ResourceManager.StorageMover.Models.SourceEndpointProperties sourceEndpointProperties = null, Azure.ResourceManager.StorageMover.Models.TargetEndpointProperties targetEndpointProperties = null) { throw null; }
        public static Azure.ResourceManager.StorageMover.StorageMoverAgentData StorageMoverAgentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, string agentVersion = null, string arcResourceId = null, string arcVmUuid = null, Azure.ResourceManager.StorageMover.Models.StorageMoverAgentStatus? agentStatus = default(Azure.ResourceManager.StorageMover.Models.StorageMoverAgentStatus?), System.DateTimeOffset? lastStatusUpdate = default(System.DateTimeOffset?), string localIPAddress = null, long? memoryInMB = default(long?), long? numberOfCores = default(long?), long? uptimeInSeconds = default(long?), string timeZone = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.Models.UploadLimitWeeklyRecurrence> uploadLimitScheduleWeeklyRecurrences = null, Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPropertiesErrorDetails errorDetails = null, Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState? provisioningState = default(Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPropertiesErrorDetails StorageMoverAgentPropertiesErrorDetails(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.StorageMover.StorageMoverData StorageMoverData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string description = null, Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState? provisioningState = default(Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.StorageMover.StorageMoverEndpointData StorageMoverEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.StorageMover.StorageMoverProjectData StorageMoverProjectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState? provisioningState = default(Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.TargetEndpointProperties TargetEndpointProperties(string name = null, Azure.Core.ResourceIdentifier targetEndpointResourceId = null, Azure.Core.ResourceIdentifier azureStorageAccountResourceId = null, string azureStorageBlobContainerName = null) { throw null; }
    }
    public partial class AzureKeyVaultSmbCredentials : Azure.ResourceManager.StorageMover.Models.StorageMoverCredentials, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureKeyVaultSmbCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureKeyVaultSmbCredentials>
    {
        public AzureKeyVaultSmbCredentials() { }
        public string PasswordUriString { get { throw null; } set { } }
        public string UsernameUriString { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.AzureKeyVaultSmbCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureKeyVaultSmbCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureKeyVaultSmbCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.AzureKeyVaultSmbCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureKeyVaultSmbCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureKeyVaultSmbCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureKeyVaultSmbCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureMultiCloudConnectorEndpointProperties : Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureMultiCloudConnectorEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureMultiCloudConnectorEndpointProperties>
    {
        public AzureMultiCloudConnectorEndpointProperties(Azure.Core.ResourceIdentifier multiCloudConnectorId, Azure.Core.ResourceIdentifier awsS3BucketId) { }
        public Azure.Core.ResourceIdentifier AwsS3BucketId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MultiCloudConnectorId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.AzureMultiCloudConnectorEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureMultiCloudConnectorEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureMultiCloudConnectorEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.AzureMultiCloudConnectorEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureMultiCloudConnectorEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureMultiCloudConnectorEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureMultiCloudConnectorEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureMultiCloudConnectorEndpointUpdateProperties : Azure.ResourceManager.StorageMover.Models.EndpointBaseUpdateProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureMultiCloudConnectorEndpointUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureMultiCloudConnectorEndpointUpdateProperties>
    {
        public AzureMultiCloudConnectorEndpointUpdateProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.AzureMultiCloudConnectorEndpointUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureMultiCloudConnectorEndpointUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureMultiCloudConnectorEndpointUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.AzureMultiCloudConnectorEndpointUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureMultiCloudConnectorEndpointUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureMultiCloudConnectorEndpointUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureMultiCloudConnectorEndpointUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureStorageBlobContainerEndpointProperties : Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureStorageBlobContainerEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageBlobContainerEndpointProperties>
    {
        public AzureStorageBlobContainerEndpointProperties(string storageAccountResourceId, string blobContainerName) { }
        public string BlobContainerName { get { throw null; } set { } }
        public string StorageAccountResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.AzureStorageBlobContainerEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureStorageBlobContainerEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureStorageBlobContainerEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.AzureStorageBlobContainerEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageBlobContainerEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageBlobContainerEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageBlobContainerEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureStorageBlobContainerEndpointUpdateProperties : Azure.ResourceManager.StorageMover.Models.EndpointBaseUpdateProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureStorageBlobContainerEndpointUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageBlobContainerEndpointUpdateProperties>
    {
        public AzureStorageBlobContainerEndpointUpdateProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.AzureStorageBlobContainerEndpointUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureStorageBlobContainerEndpointUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureStorageBlobContainerEndpointUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.AzureStorageBlobContainerEndpointUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageBlobContainerEndpointUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageBlobContainerEndpointUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageBlobContainerEndpointUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureStorageNfsFileShareEndpointProperties : Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureStorageNfsFileShareEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageNfsFileShareEndpointProperties>
    {
        public AzureStorageNfsFileShareEndpointProperties(Azure.Core.ResourceIdentifier storageAccountResourceId, string fileShareName) { }
        public string FileShareName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.AzureStorageNfsFileShareEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureStorageNfsFileShareEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureStorageNfsFileShareEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.AzureStorageNfsFileShareEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageNfsFileShareEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageNfsFileShareEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageNfsFileShareEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureStorageNfsFileShareEndpointUpdateProperties : Azure.ResourceManager.StorageMover.Models.EndpointBaseUpdateProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureStorageNfsFileShareEndpointUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageNfsFileShareEndpointUpdateProperties>
    {
        public AzureStorageNfsFileShareEndpointUpdateProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.AzureStorageNfsFileShareEndpointUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureStorageNfsFileShareEndpointUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureStorageNfsFileShareEndpointUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.AzureStorageNfsFileShareEndpointUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageNfsFileShareEndpointUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageNfsFileShareEndpointUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageNfsFileShareEndpointUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureStorageSmbFileShareEndpointProperties : Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureStorageSmbFileShareEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageSmbFileShareEndpointProperties>
    {
        public AzureStorageSmbFileShareEndpointProperties(Azure.Core.ResourceIdentifier storageAccountResourceId, string fileShareName) { }
        public string FileShareName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.AzureStorageSmbFileShareEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureStorageSmbFileShareEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureStorageSmbFileShareEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.AzureStorageSmbFileShareEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageSmbFileShareEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageSmbFileShareEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageSmbFileShareEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureStorageSmbFileShareEndpointUpdateProperties : Azure.ResourceManager.StorageMover.Models.EndpointBaseUpdateProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureStorageSmbFileShareEndpointUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageSmbFileShareEndpointUpdateProperties>
    {
        public AzureStorageSmbFileShareEndpointUpdateProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.AzureStorageSmbFileShareEndpointUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureStorageSmbFileShareEndpointUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.AzureStorageSmbFileShareEndpointUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.AzureStorageSmbFileShareEndpointUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageSmbFileShareEndpointUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageSmbFileShareEndpointUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.AzureStorageSmbFileShareEndpointUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EndpointBaseProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties>
    {
        protected EndpointBaseProperties() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EndpointBaseUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.EndpointBaseUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.EndpointBaseUpdateProperties>
    {
        protected EndpointBaseUpdateProperties() { }
        public string Description { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.EndpointBaseUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.EndpointBaseUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.EndpointBaseUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.EndpointBaseUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.EndpointBaseUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.EndpointBaseUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.EndpointBaseUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JobDefinitionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.JobDefinitionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.JobDefinitionPatch>
    {
        public JobDefinitionPatch() { }
        public string AgentName { get { throw null; } set { } }
        public Azure.ResourceManager.StorageMover.Models.StorageMoverCopyMode? CopyMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.JobDefinitionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.JobDefinitionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.JobDefinitionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.JobDefinitionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.JobDefinitionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.JobDefinitionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.JobDefinitionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JobRunError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.JobRunError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.JobRunError>
    {
        internal JobRunError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.JobRunError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.JobRunError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.JobRunError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.JobRunError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.JobRunError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.JobRunError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.JobRunError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JobRunResourceId : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.JobRunResourceId>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.JobRunResourceId>
    {
        internal JobRunResourceId() { }
        public Azure.Core.ResourceIdentifier JobRunResourceIdValue { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.JobRunResourceId System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.JobRunResourceId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.JobRunResourceId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.JobRunResourceId System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.JobRunResourceId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.JobRunResourceId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.JobRunResourceId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobRunScanStatus : System.IEquatable<Azure.ResourceManager.StorageMover.Models.JobRunScanStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobRunScanStatus(string value) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.JobRunScanStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.JobRunScanStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.JobRunScanStatus Scanning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageMover.Models.JobRunScanStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageMover.Models.JobRunScanStatus left, Azure.ResourceManager.StorageMover.Models.JobRunScanStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageMover.Models.JobRunScanStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageMover.Models.JobRunScanStatus left, Azure.ResourceManager.StorageMover.Models.JobRunScanStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobRunStatus : System.IEquatable<Azure.ResourceManager.StorageMover.Models.JobRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobRunStatus(string value) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.JobRunStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.JobRunStatus Canceling { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.JobRunStatus CancelRequested { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.JobRunStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.JobRunStatus PausedByBandwidthManagement { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.JobRunStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.JobRunStatus Running { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.JobRunStatus Started { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.JobRunStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageMover.Models.JobRunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageMover.Models.JobRunStatus left, Azure.ResourceManager.StorageMover.Models.JobRunStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageMover.Models.JobRunStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageMover.Models.JobRunStatus left, Azure.ResourceManager.StorageMover.Models.JobRunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobType : System.IEquatable<Azure.ResourceManager.StorageMover.Models.JobType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobType(string value) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.JobType CloudToCloud { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.JobType OnPremToCloud { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageMover.Models.JobType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageMover.Models.JobType left, Azure.ResourceManager.StorageMover.Models.JobType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageMover.Models.JobType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageMover.Models.JobType left, Azure.ResourceManager.StorageMover.Models.JobType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NfsMountEndpointProperties : Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.NfsMountEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.NfsMountEndpointProperties>
    {
        public NfsMountEndpointProperties(string host, string export) { }
        public string Export { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public Azure.ResourceManager.StorageMover.Models.NfsVersion? NfsVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.NfsMountEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.NfsMountEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.NfsMountEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.NfsMountEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.NfsMountEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.NfsMountEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.NfsMountEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NfsMountEndpointUpdateProperties : Azure.ResourceManager.StorageMover.Models.EndpointBaseUpdateProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.NfsMountEndpointUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.NfsMountEndpointUpdateProperties>
    {
        public NfsMountEndpointUpdateProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.NfsMountEndpointUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.NfsMountEndpointUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.NfsMountEndpointUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.NfsMountEndpointUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.NfsMountEndpointUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.NfsMountEndpointUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.NfsMountEndpointUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NfsVersion : System.IEquatable<Azure.ResourceManager.StorageMover.Models.NfsVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NfsVersion(string value) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.NfsVersion NFSauto { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.NfsVersion NFSv3 { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.NfsVersion NFSv4 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageMover.Models.NfsVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageMover.Models.NfsVersion left, Azure.ResourceManager.StorageMover.Models.NfsVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageMover.Models.NfsVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageMover.Models.NfsVersion left, Azure.ResourceManager.StorageMover.Models.NfsVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ScheduleDayOfWeek
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduleMinute : System.IEquatable<Azure.ResourceManager.StorageMover.Models.ScheduleMinute>
    {
        private readonly int _dummyPrimitive;
        public ScheduleMinute(int value) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.ScheduleMinute Thirty { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.ScheduleMinute Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageMover.Models.ScheduleMinute other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageMover.Models.ScheduleMinute left, Azure.ResourceManager.StorageMover.Models.ScheduleMinute right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageMover.Models.ScheduleMinute (int value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageMover.Models.ScheduleMinute left, Azure.ResourceManager.StorageMover.Models.ScheduleMinute right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScheduleRecurrence : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.ScheduleRecurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.ScheduleRecurrence>
    {
        public ScheduleRecurrence(Azure.ResourceManager.StorageMover.Models.ScheduleTime startTime, Azure.ResourceManager.StorageMover.Models.ScheduleTime endTime) { }
        public Azure.ResourceManager.StorageMover.Models.ScheduleTime EndTime { get { throw null; } set { } }
        public Azure.ResourceManager.StorageMover.Models.ScheduleTime StartTime { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.ScheduleRecurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.ScheduleRecurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.ScheduleRecurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.ScheduleRecurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.ScheduleRecurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.ScheduleRecurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.ScheduleRecurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduleTime : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.ScheduleTime>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.ScheduleTime>
    {
        public ScheduleTime(int hour) { }
        public int Hour { get { throw null; } set { } }
        public Azure.ResourceManager.StorageMover.Models.ScheduleMinute? Minute { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.ScheduleTime System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.ScheduleTime>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.ScheduleTime>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.ScheduleTime System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.ScheduleTime>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.ScheduleTime>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.ScheduleTime>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduleWeeklyRecurrence : Azure.ResourceManager.StorageMover.Models.ScheduleRecurrence, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.ScheduleWeeklyRecurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.ScheduleWeeklyRecurrence>
    {
        public ScheduleWeeklyRecurrence(Azure.ResourceManager.StorageMover.Models.ScheduleTime startTime, Azure.ResourceManager.StorageMover.Models.ScheduleTime endTime, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.Models.ScheduleDayOfWeek> days) : base (default(Azure.ResourceManager.StorageMover.Models.ScheduleTime), default(Azure.ResourceManager.StorageMover.Models.ScheduleTime)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.StorageMover.Models.ScheduleDayOfWeek> Days { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.ScheduleWeeklyRecurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.ScheduleWeeklyRecurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.ScheduleWeeklyRecurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.ScheduleWeeklyRecurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.ScheduleWeeklyRecurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.ScheduleWeeklyRecurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.ScheduleWeeklyRecurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SmbMountEndpointProperties : Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.SmbMountEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.SmbMountEndpointProperties>
    {
        public SmbMountEndpointProperties(string host, string shareName) { }
        public Azure.ResourceManager.StorageMover.Models.AzureKeyVaultSmbCredentials Credentials { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public string ShareName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.SmbMountEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.SmbMountEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.SmbMountEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.SmbMountEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.SmbMountEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.SmbMountEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.SmbMountEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SmbMountEndpointUpdateProperties : Azure.ResourceManager.StorageMover.Models.EndpointBaseUpdateProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.SmbMountEndpointUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.SmbMountEndpointUpdateProperties>
    {
        public SmbMountEndpointUpdateProperties() { }
        public Azure.ResourceManager.StorageMover.Models.AzureKeyVaultSmbCredentials Credentials { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.SmbMountEndpointUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.SmbMountEndpointUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.SmbMountEndpointUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.SmbMountEndpointUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.SmbMountEndpointUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.SmbMountEndpointUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.SmbMountEndpointUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SourceEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.SourceEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.SourceEndpointProperties>
    {
        internal SourceEndpointProperties() { }
        public Azure.Core.ResourceIdentifier AwsS3BucketId { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceEndpointResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.SourceEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.SourceEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.SourceEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.SourceEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.SourceEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.SourceEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.SourceEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SourceTargetMap : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.SourceTargetMap>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.SourceTargetMap>
    {
        internal SourceTargetMap() { }
        public Azure.ResourceManager.StorageMover.Models.SourceEndpointProperties SourceEndpointProperties { get { throw null; } }
        public Azure.ResourceManager.StorageMover.Models.TargetEndpointProperties TargetEndpointProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.SourceTargetMap System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.SourceTargetMap>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.SourceTargetMap>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.SourceTargetMap System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.SourceTargetMap>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.SourceTargetMap>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.SourceTargetMap>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageMoverAgentPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPatch>
    {
        public StorageMoverAgentPatch() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StorageMover.Models.UploadLimitWeeklyRecurrence> UploadLimitScheduleWeeklyRecurrences { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageMoverAgentPropertiesErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPropertiesErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPropertiesErrorDetails>
    {
        internal StorageMoverAgentPropertiesErrorDetails() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPropertiesErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPropertiesErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPropertiesErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPropertiesErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPropertiesErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPropertiesErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverAgentPropertiesErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageMoverAgentStatus : System.IEquatable<Azure.ResourceManager.StorageMover.Models.StorageMoverAgentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageMoverAgentStatus(string value) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.StorageMoverAgentStatus Executing { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.StorageMoverAgentStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.StorageMoverAgentStatus Online { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.StorageMoverAgentStatus Registering { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.StorageMoverAgentStatus RequiresAttention { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.StorageMoverAgentStatus Unregistering { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageMover.Models.StorageMoverAgentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageMover.Models.StorageMoverAgentStatus left, Azure.ResourceManager.StorageMover.Models.StorageMoverAgentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageMover.Models.StorageMoverAgentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageMover.Models.StorageMoverAgentStatus left, Azure.ResourceManager.StorageMover.Models.StorageMoverAgentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageMoverCopyMode : System.IEquatable<Azure.ResourceManager.StorageMover.Models.StorageMoverCopyMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageMoverCopyMode(string value) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.StorageMoverCopyMode Additive { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.StorageMoverCopyMode Mirror { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageMover.Models.StorageMoverCopyMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageMover.Models.StorageMoverCopyMode left, Azure.ResourceManager.StorageMover.Models.StorageMoverCopyMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageMover.Models.StorageMoverCopyMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageMover.Models.StorageMoverCopyMode left, Azure.ResourceManager.StorageMover.Models.StorageMoverCopyMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class StorageMoverCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.StorageMoverCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverCredentials>
    {
        protected StorageMoverCredentials() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.StorageMoverCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.StorageMoverCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.StorageMoverCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.StorageMoverCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageMoverEndpointPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.StorageMoverEndpointPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverEndpointPatch>
    {
        public StorageMoverEndpointPatch() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public string EndpointBaseUpdateDescription { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.StorageMover.Models.EndpointBaseUpdateProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.StorageMoverEndpointPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.StorageMoverEndpointPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.StorageMoverEndpointPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.StorageMoverEndpointPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverEndpointPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverEndpointPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverEndpointPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageMoverPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.StorageMoverPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverPatch>
    {
        public StorageMoverPatch() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.StorageMoverPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.StorageMoverPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.StorageMoverPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.StorageMoverPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageMoverProjectPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.StorageMoverProjectPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverProjectPatch>
    {
        public StorageMoverProjectPatch() { }
        public string Description { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.StorageMoverProjectPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.StorageMoverProjectPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.StorageMoverProjectPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.StorageMoverProjectPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverProjectPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverProjectPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.StorageMoverProjectPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageMoverProvisioningState : System.IEquatable<Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageMoverProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState left, Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState left, Azure.ResourceManager.StorageMover.Models.StorageMoverProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TargetEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.TargetEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.TargetEndpointProperties>
    {
        internal TargetEndpointProperties() { }
        public Azure.Core.ResourceIdentifier AzureStorageAccountResourceId { get { throw null; } }
        public string AzureStorageBlobContainerName { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetEndpointResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.TargetEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.TargetEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.TargetEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.TargetEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.TargetEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.TargetEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.TargetEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UploadLimitWeeklyRecurrence : Azure.ResourceManager.StorageMover.Models.ScheduleWeeklyRecurrence, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.UploadLimitWeeklyRecurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.UploadLimitWeeklyRecurrence>
    {
        public UploadLimitWeeklyRecurrence(Azure.ResourceManager.StorageMover.Models.ScheduleTime startTime, Azure.ResourceManager.StorageMover.Models.ScheduleTime endTime, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.Models.ScheduleDayOfWeek> days, int limitInMbps) : base (default(Azure.ResourceManager.StorageMover.Models.ScheduleTime), default(Azure.ResourceManager.StorageMover.Models.ScheduleTime), default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.Models.ScheduleDayOfWeek>)) { }
        public int LimitInMbps { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.UploadLimitWeeklyRecurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.UploadLimitWeeklyRecurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StorageMover.Models.UploadLimitWeeklyRecurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StorageMover.Models.UploadLimitWeeklyRecurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.UploadLimitWeeklyRecurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.UploadLimitWeeklyRecurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StorageMover.Models.UploadLimitWeeklyRecurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
