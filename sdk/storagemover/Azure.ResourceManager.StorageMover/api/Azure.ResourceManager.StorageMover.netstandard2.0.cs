namespace Azure.ResourceManager.StorageMover
{
    public partial class AgentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.AgentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.AgentResource>, System.Collections.IEnumerable
    {
        protected AgentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageMover.AgentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agentName, Azure.ResourceManager.StorageMover.AgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageMover.AgentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agentName, Azure.ResourceManager.StorageMover.AgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.AgentResource> Get(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageMover.AgentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageMover.AgentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.AgentResource>> GetAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageMover.AgentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.AgentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageMover.AgentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.AgentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AgentData : Azure.ResourceManager.Models.ResourceData
    {
        public AgentData(string arcResourceId, string arcVmUuid) { }
        public Azure.ResourceManager.StorageMover.Models.AgentStatus? AgentStatus { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public string ArcResourceId { get { throw null; } set { } }
        public string ArcVmUuid { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.StorageMover.Models.AgentPropertiesErrorDetails ErrorDetails { get { throw null; } }
        public System.DateTimeOffset? LastStatusUpdate { get { throw null; } }
        public string LocalIPAddress { get { throw null; } }
        public long? MemoryInMB { get { throw null; } }
        public long? NumberOfCores { get { throw null; } }
        public Azure.ResourceManager.StorageMover.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public long? UptimeInSeconds { get { throw null; } }
    }
    public partial class AgentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AgentResource() { }
        public virtual Azure.ResourceManager.StorageMover.AgentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName, string agentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.AgentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.AgentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.AgentResource> Update(Azure.ResourceManager.StorageMover.Models.AgentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.AgentResource>> UpdateAsync(Azure.ResourceManager.StorageMover.Models.AgentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.EndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.EndpointResource>, System.Collections.IEnumerable
    {
        protected EndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageMover.EndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.StorageMover.EndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageMover.EndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.StorageMover.EndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.EndpointResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageMover.EndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageMover.EndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.EndpointResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageMover.EndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.EndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageMover.EndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.EndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EndpointData : Azure.ResourceManager.Models.ResourceData
    {
        public EndpointData(Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties properties) { }
        public Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties Properties { get { throw null; } set { } }
    }
    public partial class EndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EndpointResource() { }
        public virtual Azure.ResourceManager.StorageMover.EndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.EndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.EndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.EndpointResource> Update(Azure.ResourceManager.StorageMover.Models.EndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.EndpointResource>> UpdateAsync(Azure.ResourceManager.StorageMover.Models.EndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageMover.JobDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.JobDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageMover.JobDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.JobDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobDefinitionData : Azure.ResourceManager.Models.ResourceData
    {
        public JobDefinitionData(Azure.ResourceManager.StorageMover.Models.CopyMode copyMode, string sourceName, string targetName) { }
        public string AgentName { get { throw null; } set { } }
        public string AgentResourceId { get { throw null; } }
        public Azure.ResourceManager.StorageMover.Models.CopyMode CopyMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string LatestJobRunName { get { throw null; } }
        public string LatestJobRunResourceId { get { throw null; } }
        public Azure.ResourceManager.StorageMover.Models.JobRunStatus? LatestJobRunStatus { get { throw null; } }
        public Azure.ResourceManager.StorageMover.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SourceName { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } }
        public string SourceSubpath { get { throw null; } set { } }
        public string TargetName { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } }
        public string TargetSubpath { get { throw null; } set { } }
    }
    public partial class JobDefinitionResource : Azure.ResourceManager.ArmResource
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageMover.JobRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.JobRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageMover.JobRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.JobRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobRunData : Azure.ResourceManager.Models.ResourceData
    {
        public JobRunData() { }
        public string AgentName { get { throw null; } }
        public string AgentResourceId { get { throw null; } }
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
        public Azure.ResourceManager.StorageMover.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.StorageMover.Models.JobRunScanStatus? ScanStatus { get { throw null; } }
        public string SourceName { get { throw null; } }
        public System.BinaryData SourceProperties { get { throw null; } }
        public string SourceResourceId { get { throw null; } }
        public Azure.ResourceManager.StorageMover.Models.JobRunStatus? Status { get { throw null; } }
        public string TargetName { get { throw null; } }
        public System.BinaryData TargetProperties { get { throw null; } }
        public string TargetResourceId { get { throw null; } }
    }
    public partial class JobRunResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobRunResource() { }
        public virtual Azure.ResourceManager.StorageMover.JobRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName, string projectName, string jobDefinitionName, string jobRunName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.JobRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.JobRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.ProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.ProjectResource>, System.Collections.IEnumerable
    {
        protected ProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageMover.ProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.StorageMover.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageMover.ProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.StorageMover.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.ProjectResource> Get(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageMover.ProjectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageMover.ProjectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.ProjectResource>> GetAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageMover.ProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.ProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageMover.ProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.ProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectData : Azure.ResourceManager.Models.ResourceData
    {
        public ProjectData() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.StorageMover.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ProjectResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectResource() { }
        public virtual Azure.ResourceManager.StorageMover.ProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName, string projectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.ProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.ProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.JobDefinitionResource> GetJobDefinition(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.JobDefinitionResource>> GetJobDefinitionAsync(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageMover.JobDefinitionCollection GetJobDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.ProjectResource> Update(Azure.ResourceManager.StorageMover.Models.ProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.ProjectResource>> UpdateAsync(Azure.ResourceManager.StorageMover.Models.ProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageMover.StorageMoverResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageMover.StorageMoverResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageMover.StorageMoverResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageMover.StorageMoverResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageMoverData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public StorageMoverData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.StorageMover.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public static partial class StorageMoverExtensions
    {
        public static Azure.ResourceManager.StorageMover.AgentResource GetAgentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageMover.EndpointResource GetEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageMover.JobDefinitionResource GetJobDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageMover.JobRunResource GetJobRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageMover.ProjectResource GetProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource> GetStorageMover(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource>> GetStorageMoverAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StorageMover.StorageMoverResource GetStorageMoverResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageMover.StorageMoverCollection GetStorageMovers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StorageMover.StorageMoverResource> GetStorageMovers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StorageMover.StorageMoverResource> GetStorageMoversAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageMoverResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.AgentResource> GetAgent(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.AgentResource>> GetAgentAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageMover.AgentCollection GetAgents() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.EndpointResource> GetEndpoint(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.EndpointResource>> GetEndpointAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageMover.EndpointCollection GetEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.ProjectResource> GetProject(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.ProjectResource>> GetProjectAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageMover.ProjectCollection GetProjects() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource> Update(Azure.ResourceManager.StorageMover.Models.StorageMoverPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageMover.StorageMoverResource>> UpdateAsync(Azure.ResourceManager.StorageMover.Models.StorageMoverPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StorageMover.Models
{
    public partial class AgentPatch
    {
        public AgentPatch() { }
        public string Description { get { throw null; } set { } }
    }
    public partial class AgentPropertiesErrorDetails
    {
        internal AgentPropertiesErrorDetails() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentStatus : System.IEquatable<Azure.ResourceManager.StorageMover.Models.AgentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentStatus(string value) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.AgentStatus Executing { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.AgentStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.AgentStatus Online { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.AgentStatus Registering { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.AgentStatus RequiresAttention { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.AgentStatus Unregistering { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageMover.Models.AgentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageMover.Models.AgentStatus left, Azure.ResourceManager.StorageMover.Models.AgentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageMover.Models.AgentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageMover.Models.AgentStatus left, Azure.ResourceManager.StorageMover.Models.AgentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureStorageBlobContainerEndpointProperties : Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties
    {
        public AzureStorageBlobContainerEndpointProperties(string storageAccountResourceId, string blobContainerName) { }
        public string BlobContainerName { get { throw null; } set { } }
        public string StorageAccountResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CopyMode : System.IEquatable<Azure.ResourceManager.StorageMover.Models.CopyMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CopyMode(string value) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.CopyMode Additive { get { throw null; } }
        public static Azure.ResourceManager.StorageMover.Models.CopyMode Mirror { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageMover.Models.CopyMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageMover.Models.CopyMode left, Azure.ResourceManager.StorageMover.Models.CopyMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageMover.Models.CopyMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageMover.Models.CopyMode left, Azure.ResourceManager.StorageMover.Models.CopyMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class EndpointBaseProperties
    {
        protected EndpointBaseProperties() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.StorageMover.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class EndpointPatch
    {
        public EndpointPatch() { }
        public string EndpointBaseUpdateDescription { get { throw null; } set { } }
    }
    public partial class JobDefinitionPatch
    {
        public JobDefinitionPatch() { }
        public string AgentName { get { throw null; } set { } }
        public Azure.ResourceManager.StorageMover.Models.CopyMode? CopyMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
    }
    public partial class JobRunError
    {
        internal JobRunError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class JobRunResourceId
    {
        internal JobRunResourceId() { }
        public string JobRunResourceIdValue { get { throw null; } }
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
    public partial class NfsMountEndpointProperties : Azure.ResourceManager.StorageMover.Models.EndpointBaseProperties
    {
        public NfsMountEndpointProperties(string host, string export) { }
        public string Export { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public Azure.ResourceManager.StorageMover.Models.NfsVersion? NfsVersion { get { throw null; } set { } }
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
    public partial class ProjectPatch
    {
        public ProjectPatch() { }
        public string Description { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.StorageMover.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.StorageMover.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageMover.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageMover.Models.ProvisioningState left, Azure.ResourceManager.StorageMover.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageMover.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageMover.Models.ProvisioningState left, Azure.ResourceManager.StorageMover.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageMoverPatch
    {
        public StorageMoverPatch() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
}
