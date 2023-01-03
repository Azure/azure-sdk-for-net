namespace Azure.ResourceManager.LiftrQumulo
{
    public partial class AgentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.AgentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.AgentResource>, System.Collections.IEnumerable
    {
        protected AgentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LiftrQumulo.AgentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agentName, Azure.ResourceManager.LiftrQumulo.AgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LiftrQumulo.AgentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agentName, Azure.ResourceManager.LiftrQumulo.AgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.AgentResource> Get(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LiftrQumulo.AgentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LiftrQumulo.AgentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.AgentResource>> GetAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LiftrQumulo.AgentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.AgentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LiftrQumulo.AgentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.AgentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AgentData : Azure.ResourceManager.Models.ResourceData
    {
        public AgentData(string arcResourceId, string arcVmUuid) { }
        public Azure.ResourceManager.LiftrQumulo.Models.AgentStatus? AgentStatus { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public string ArcResourceId { get { throw null; } set { } }
        public string ArcVmUuid { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.LiftrQumulo.Models.AgentPropertiesErrorDetails ErrorDetails { get { throw null; } }
        public System.DateTimeOffset? LastStatusUpdate { get { throw null; } }
        public string LocalIPAddress { get { throw null; } }
        public long? MemoryInMB { get { throw null; } }
        public long? NumberOfCores { get { throw null; } }
        public Azure.ResourceManager.LiftrQumulo.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public long? UptimeInSeconds { get { throw null; } }
    }
    public partial class AgentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AgentResource() { }
        public virtual Azure.ResourceManager.LiftrQumulo.AgentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName, string agentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.AgentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.AgentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.AgentResource> Update(Azure.ResourceManager.LiftrQumulo.Models.AgentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.AgentResource>> UpdateAsync(Azure.ResourceManager.LiftrQumulo.Models.AgentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.EndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.EndpointResource>, System.Collections.IEnumerable
    {
        protected EndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LiftrQumulo.EndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.LiftrQumulo.EndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LiftrQumulo.EndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.LiftrQumulo.EndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.EndpointResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LiftrQumulo.EndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LiftrQumulo.EndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.EndpointResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LiftrQumulo.EndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.EndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LiftrQumulo.EndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.EndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EndpointData : Azure.ResourceManager.Models.ResourceData
    {
        public EndpointData(Azure.ResourceManager.LiftrQumulo.Models.EndpointBaseProperties properties) { }
        public Azure.ResourceManager.LiftrQumulo.Models.EndpointBaseProperties Properties { get { throw null; } set { } }
    }
    public partial class EndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EndpointResource() { }
        public virtual Azure.ResourceManager.LiftrQumulo.EndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.EndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.EndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.EndpointResource> Update(Azure.ResourceManager.LiftrQumulo.Models.EndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.EndpointResource>> UpdateAsync(Azure.ResourceManager.LiftrQumulo.Models.EndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource>, System.Collections.IEnumerable
    {
        protected JobDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jobDefinitionName, Azure.ResourceManager.LiftrQumulo.JobDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jobDefinitionName, Azure.ResourceManager.LiftrQumulo.JobDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource> Get(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource>> GetAsync(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobDefinitionData : Azure.ResourceManager.Models.ResourceData
    {
        public JobDefinitionData(Azure.ResourceManager.LiftrQumulo.Models.CopyMode copyMode, string sourceName, string targetName) { }
        public string AgentName { get { throw null; } set { } }
        public string AgentResourceId { get { throw null; } }
        public Azure.ResourceManager.LiftrQumulo.Models.CopyMode CopyMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string LatestJobRunName { get { throw null; } }
        public string LatestJobRunResourceId { get { throw null; } }
        public Azure.ResourceManager.LiftrQumulo.Models.JobRunStatus? LatestJobRunStatus { get { throw null; } }
        public Azure.ResourceManager.LiftrQumulo.Models.ProvisioningState? ProvisioningState { get { throw null; } }
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
        public virtual Azure.ResourceManager.LiftrQumulo.JobDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName, string projectName, string jobDefinitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.JobRunResource> GetJobRun(string jobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.JobRunResource>> GetJobRunAsync(string jobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LiftrQumulo.JobRunCollection GetJobRuns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.Models.JobRunResourceId> StartJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.Models.JobRunResourceId>> StartJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.Models.JobRunResourceId> StopJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.Models.JobRunResourceId>> StopJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource> Update(Azure.ResourceManager.LiftrQumulo.Models.JobDefinitionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource>> UpdateAsync(Azure.ResourceManager.LiftrQumulo.Models.JobDefinitionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.JobRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.JobRunResource>, System.Collections.IEnumerable
    {
        protected JobRunCollection() { }
        public virtual Azure.Response<bool> Exists(string jobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.JobRunResource> Get(string jobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LiftrQumulo.JobRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LiftrQumulo.JobRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.JobRunResource>> GetAsync(string jobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LiftrQumulo.JobRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.JobRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LiftrQumulo.JobRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.JobRunResource>.GetEnumerator() { throw null; }
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
        public Azure.ResourceManager.LiftrQumulo.Models.JobRunError Error { get { throw null; } }
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
        public Azure.ResourceManager.LiftrQumulo.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.LiftrQumulo.Models.JobRunScanStatus? ScanStatus { get { throw null; } }
        public string SourceName { get { throw null; } }
        public System.BinaryData SourceProperties { get { throw null; } }
        public string SourceResourceId { get { throw null; } }
        public Azure.ResourceManager.LiftrQumulo.Models.JobRunStatus? Status { get { throw null; } }
        public string TargetName { get { throw null; } }
        public System.BinaryData TargetProperties { get { throw null; } }
        public string TargetResourceId { get { throw null; } }
    }
    public partial class JobRunResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobRunResource() { }
        public virtual Azure.ResourceManager.LiftrQumulo.JobRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName, string projectName, string jobDefinitionName, string jobRunName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.JobRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.JobRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class LiftrQumuloExtensions
    {
        public static Azure.ResourceManager.LiftrQumulo.AgentResource GetAgentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.EndpointResource GetEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.JobDefinitionResource GetJobDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.JobRunResource GetJobRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.ProjectResource GetProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.LiftrQumulo.StorageMoverResource> GetStorageMover(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.StorageMoverResource>> GetStorageMoverAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.StorageMoverResource GetStorageMoverResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.StorageMoverCollection GetStorageMovers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.LiftrQumulo.StorageMoverResource> GetStorageMovers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.LiftrQumulo.StorageMoverResource> GetStorageMoversAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.ProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.ProjectResource>, System.Collections.IEnumerable
    {
        protected ProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LiftrQumulo.ProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.LiftrQumulo.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LiftrQumulo.ProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.LiftrQumulo.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.ProjectResource> Get(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LiftrQumulo.ProjectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LiftrQumulo.ProjectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.ProjectResource>> GetAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LiftrQumulo.ProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.ProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LiftrQumulo.ProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.ProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectData : Azure.ResourceManager.Models.ResourceData
    {
        public ProjectData() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.LiftrQumulo.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ProjectResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectResource() { }
        public virtual Azure.ResourceManager.LiftrQumulo.ProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName, string projectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.ProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.ProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource> GetJobDefinition(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource>> GetJobDefinitionAsync(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LiftrQumulo.JobDefinitionCollection GetJobDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.ProjectResource> Update(Azure.ResourceManager.LiftrQumulo.Models.ProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.ProjectResource>> UpdateAsync(Azure.ResourceManager.LiftrQumulo.Models.ProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageMoverCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.StorageMoverResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.StorageMoverResource>, System.Collections.IEnumerable
    {
        protected StorageMoverCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LiftrQumulo.StorageMoverResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageMoverName, Azure.ResourceManager.LiftrQumulo.StorageMoverData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LiftrQumulo.StorageMoverResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageMoverName, Azure.ResourceManager.LiftrQumulo.StorageMoverData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.StorageMoverResource> Get(string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LiftrQumulo.StorageMoverResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LiftrQumulo.StorageMoverResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.StorageMoverResource>> GetAsync(string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LiftrQumulo.StorageMoverResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.StorageMoverResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LiftrQumulo.StorageMoverResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.StorageMoverResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageMoverData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public StorageMoverData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.LiftrQumulo.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class StorageMoverResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageMoverResource() { }
        public virtual Azure.ResourceManager.LiftrQumulo.StorageMoverData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.StorageMoverResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.StorageMoverResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.StorageMoverResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.AgentResource> GetAgent(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.AgentResource>> GetAgentAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LiftrQumulo.AgentCollection GetAgents() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.StorageMoverResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.EndpointResource> GetEndpoint(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.EndpointResource>> GetEndpointAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LiftrQumulo.EndpointCollection GetEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.ProjectResource> GetProject(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.ProjectResource>> GetProjectAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LiftrQumulo.ProjectCollection GetProjects() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.StorageMoverResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.StorageMoverResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.StorageMoverResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.StorageMoverResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.StorageMoverResource> Update(Azure.ResourceManager.LiftrQumulo.Models.StorageMoverPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.StorageMoverResource>> UpdateAsync(Azure.ResourceManager.LiftrQumulo.Models.StorageMoverPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.LiftrQumulo.Models
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
    public readonly partial struct AgentStatus : System.IEquatable<Azure.ResourceManager.LiftrQumulo.Models.AgentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentStatus(string value) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.Models.AgentStatus Executing { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.AgentStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.AgentStatus Online { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.AgentStatus Registering { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.AgentStatus RequiresAttention { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.AgentStatus Unregistering { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LiftrQumulo.Models.AgentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LiftrQumulo.Models.AgentStatus left, Azure.ResourceManager.LiftrQumulo.Models.AgentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.LiftrQumulo.Models.AgentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LiftrQumulo.Models.AgentStatus left, Azure.ResourceManager.LiftrQumulo.Models.AgentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureStorageBlobContainerEndpointProperties : Azure.ResourceManager.LiftrQumulo.Models.EndpointBaseProperties
    {
        public AzureStorageBlobContainerEndpointProperties(string storageAccountResourceId, string blobContainerName) { }
        public string BlobContainerName { get { throw null; } set { } }
        public string StorageAccountResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CopyMode : System.IEquatable<Azure.ResourceManager.LiftrQumulo.Models.CopyMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CopyMode(string value) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.Models.CopyMode Additive { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.CopyMode Mirror { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LiftrQumulo.Models.CopyMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LiftrQumulo.Models.CopyMode left, Azure.ResourceManager.LiftrQumulo.Models.CopyMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.LiftrQumulo.Models.CopyMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LiftrQumulo.Models.CopyMode left, Azure.ResourceManager.LiftrQumulo.Models.CopyMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class EndpointBaseProperties
    {
        protected EndpointBaseProperties() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.LiftrQumulo.Models.ProvisioningState? ProvisioningState { get { throw null; } }
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
        public Azure.ResourceManager.LiftrQumulo.Models.CopyMode? CopyMode { get { throw null; } set { } }
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
    public readonly partial struct JobRunScanStatus : System.IEquatable<Azure.ResourceManager.LiftrQumulo.Models.JobRunScanStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobRunScanStatus(string value) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.Models.JobRunScanStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.JobRunScanStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.JobRunScanStatus Scanning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LiftrQumulo.Models.JobRunScanStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LiftrQumulo.Models.JobRunScanStatus left, Azure.ResourceManager.LiftrQumulo.Models.JobRunScanStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.LiftrQumulo.Models.JobRunScanStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LiftrQumulo.Models.JobRunScanStatus left, Azure.ResourceManager.LiftrQumulo.Models.JobRunScanStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobRunStatus : System.IEquatable<Azure.ResourceManager.LiftrQumulo.Models.JobRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobRunStatus(string value) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.Models.JobRunStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.JobRunStatus Canceling { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.JobRunStatus CancelRequested { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.JobRunStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.JobRunStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.JobRunStatus Running { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.JobRunStatus Started { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.JobRunStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LiftrQumulo.Models.JobRunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LiftrQumulo.Models.JobRunStatus left, Azure.ResourceManager.LiftrQumulo.Models.JobRunStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.LiftrQumulo.Models.JobRunStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LiftrQumulo.Models.JobRunStatus left, Azure.ResourceManager.LiftrQumulo.Models.JobRunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NfsMountEndpointProperties : Azure.ResourceManager.LiftrQumulo.Models.EndpointBaseProperties
    {
        public NfsMountEndpointProperties(string host, string export) { }
        public string Export { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public Azure.ResourceManager.LiftrQumulo.Models.NfsVersion? NfsVersion { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NfsVersion : System.IEquatable<Azure.ResourceManager.LiftrQumulo.Models.NfsVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NfsVersion(string value) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.Models.NfsVersion NFSauto { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.NfsVersion NFSv3 { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.NfsVersion NFSv4 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LiftrQumulo.Models.NfsVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LiftrQumulo.Models.NfsVersion left, Azure.ResourceManager.LiftrQumulo.Models.NfsVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.LiftrQumulo.Models.NfsVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LiftrQumulo.Models.NfsVersion left, Azure.ResourceManager.LiftrQumulo.Models.NfsVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProjectPatch
    {
        public ProjectPatch() { }
        public string Description { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.LiftrQumulo.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LiftrQumulo.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LiftrQumulo.Models.ProvisioningState left, Azure.ResourceManager.LiftrQumulo.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.LiftrQumulo.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LiftrQumulo.Models.ProvisioningState left, Azure.ResourceManager.LiftrQumulo.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageMoverPatch
    {
        public StorageMoverPatch() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
}
