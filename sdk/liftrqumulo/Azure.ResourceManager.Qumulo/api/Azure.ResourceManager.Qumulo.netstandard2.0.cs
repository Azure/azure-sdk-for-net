namespace Azure.ResourceManager.Qumulo
{
    public partial class JobDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.JobDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.JobDefinitionResource>, System.Collections.IEnumerable
    {
        protected JobDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Qumulo.JobDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jobDefinitionName, Azure.ResourceManager.Qumulo.JobDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Qumulo.JobDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jobDefinitionName, Azure.ResourceManager.Qumulo.JobDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.JobDefinitionResource> Get(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Qumulo.JobDefinitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Qumulo.JobDefinitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.JobDefinitionResource>> GetAsync(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Qumulo.JobDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.JobDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Qumulo.JobDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.JobDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobDefinitionData : Azure.ResourceManager.Models.ResourceData
    {
        public JobDefinitionData(Azure.ResourceManager.Qumulo.Models.QumuloCopyMode copyMode, string sourceName, string targetName) { }
        public string AgentName { get { throw null; } set { } }
        public string AgentResourceId { get { throw null; } }
        public Azure.ResourceManager.Qumulo.Models.QumuloCopyMode CopyMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string LatestJobRunName { get { throw null; } }
        public string LatestJobRunResourceId { get { throw null; } }
        public Azure.ResourceManager.Qumulo.Models.JobRunStatus? LatestJobRunStatus { get { throw null; } }
        public Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState? ProvisioningState { get { throw null; } }
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
        public virtual Azure.ResourceManager.Qumulo.JobDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName, string projectName, string jobDefinitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.JobDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.JobDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.JobRunResource> GetJobRun(string jobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.JobRunResource>> GetJobRunAsync(string jobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Qumulo.JobRunCollection GetJobRuns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.Models.JobRunResourceId> StartJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.Models.JobRunResourceId>> StartJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.Models.JobRunResourceId> StopJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.Models.JobRunResourceId>> StopJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.JobDefinitionResource> Update(Azure.ResourceManager.Qumulo.Models.JobDefinitionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.JobDefinitionResource>> UpdateAsync(Azure.ResourceManager.Qumulo.Models.JobDefinitionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.JobRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.JobRunResource>, System.Collections.IEnumerable
    {
        protected JobRunCollection() { }
        public virtual Azure.Response<bool> Exists(string jobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.JobRunResource> Get(string jobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Qumulo.JobRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Qumulo.JobRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.JobRunResource>> GetAsync(string jobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Qumulo.JobRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.JobRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Qumulo.JobRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.JobRunResource>.GetEnumerator() { throw null; }
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
        public Azure.ResourceManager.Qumulo.Models.JobRunError Error { get { throw null; } }
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
        public Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Qumulo.Models.JobRunScanStatus? ScanStatus { get { throw null; } }
        public string SourceName { get { throw null; } }
        public System.BinaryData SourceProperties { get { throw null; } }
        public string SourceResourceId { get { throw null; } }
        public Azure.ResourceManager.Qumulo.Models.JobRunStatus? Status { get { throw null; } }
        public string TargetName { get { throw null; } }
        public System.BinaryData TargetProperties { get { throw null; } }
        public string TargetResourceId { get { throw null; } }
    }
    public partial class JobRunResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobRunResource() { }
        public virtual Azure.ResourceManager.Qumulo.JobRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName, string projectName, string jobDefinitionName, string jobRunName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.JobRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.JobRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QumuloAgentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.QumuloAgentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.QumuloAgentResource>, System.Collections.IEnumerable
    {
        protected QumuloAgentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Qumulo.QumuloAgentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agentName, Azure.ResourceManager.Qumulo.QumuloAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Qumulo.QumuloAgentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agentName, Azure.ResourceManager.Qumulo.QumuloAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloAgentResource> Get(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Qumulo.QumuloAgentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Qumulo.QumuloAgentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloAgentResource>> GetAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Qumulo.QumuloAgentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.QumuloAgentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Qumulo.QumuloAgentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.QumuloAgentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QumuloAgentData : Azure.ResourceManager.Models.ResourceData
    {
        public QumuloAgentData(string arcResourceId, string arcVmUuid) { }
        public Azure.ResourceManager.Qumulo.Models.QumuloAgentStatus? AgentStatus { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public string ArcResourceId { get { throw null; } set { } }
        public string ArcVmUuid { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Qumulo.Models.QumuloAgentPropertiesErrorDetails ErrorDetails { get { throw null; } }
        public System.DateTimeOffset? LastStatusUpdate { get { throw null; } }
        public string LocalIPAddress { get { throw null; } }
        public long? MemoryInMB { get { throw null; } }
        public long? NumberOfCores { get { throw null; } }
        public Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState? ProvisioningState { get { throw null; } }
        public long? UptimeInSeconds { get { throw null; } }
    }
    public partial class QumuloAgentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QumuloAgentResource() { }
        public virtual Azure.ResourceManager.Qumulo.QumuloAgentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName, string agentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloAgentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloAgentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloAgentResource> Update(Azure.ResourceManager.Qumulo.Models.QumuloAgentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloAgentResource>> UpdateAsync(Azure.ResourceManager.Qumulo.Models.QumuloAgentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QumuloEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.QumuloEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.QumuloEndpointResource>, System.Collections.IEnumerable
    {
        protected QumuloEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Qumulo.QumuloEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.Qumulo.QumuloEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Qumulo.QumuloEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.Qumulo.QumuloEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloEndpointResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Qumulo.QumuloEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Qumulo.QumuloEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloEndpointResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Qumulo.QumuloEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.QumuloEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Qumulo.QumuloEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.QumuloEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QumuloEndpointData : Azure.ResourceManager.Models.ResourceData
    {
        public QumuloEndpointData(Azure.ResourceManager.Qumulo.Models.EndpointBaseProperties properties) { }
        public Azure.ResourceManager.Qumulo.Models.EndpointBaseProperties Properties { get { throw null; } set { } }
    }
    public partial class QumuloEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QumuloEndpointResource() { }
        public virtual Azure.ResourceManager.Qumulo.QumuloEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloEndpointResource> Update(Azure.ResourceManager.Qumulo.Models.QumuloEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloEndpointResource>> UpdateAsync(Azure.ResourceManager.Qumulo.Models.QumuloEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class QumuloExtensions
    {
        public static Azure.ResourceManager.Qumulo.JobDefinitionResource GetJobDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Qumulo.JobRunResource GetJobRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Qumulo.QumuloAgentResource GetQumuloAgentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Qumulo.QumuloEndpointResource GetQumuloEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Qumulo.QumuloProjectResource GetQumuloProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Qumulo.StorageMoverResource> GetStorageMover(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.StorageMoverResource>> GetStorageMoverAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Qumulo.StorageMoverResource GetStorageMoverResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Qumulo.StorageMoverCollection GetStorageMovers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Qumulo.StorageMoverResource> GetStorageMovers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Qumulo.StorageMoverResource> GetStorageMoversAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QumuloProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.QumuloProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.QumuloProjectResource>, System.Collections.IEnumerable
    {
        protected QumuloProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Qumulo.QumuloProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Qumulo.QumuloProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Qumulo.QumuloProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Qumulo.QumuloProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloProjectResource> Get(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Qumulo.QumuloProjectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Qumulo.QumuloProjectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloProjectResource>> GetAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Qumulo.QumuloProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.QumuloProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Qumulo.QumuloProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.QumuloProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QumuloProjectData : Azure.ResourceManager.Models.ResourceData
    {
        public QumuloProjectData() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class QumuloProjectResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QumuloProjectResource() { }
        public virtual Azure.ResourceManager.Qumulo.QumuloProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName, string projectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.JobDefinitionResource> GetJobDefinition(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.JobDefinitionResource>> GetJobDefinitionAsync(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Qumulo.JobDefinitionCollection GetJobDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloProjectResource> Update(Azure.ResourceManager.Qumulo.Models.QumuloProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloProjectResource>> UpdateAsync(Azure.ResourceManager.Qumulo.Models.QumuloProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageMoverCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.StorageMoverResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.StorageMoverResource>, System.Collections.IEnumerable
    {
        protected StorageMoverCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Qumulo.StorageMoverResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageMoverName, Azure.ResourceManager.Qumulo.StorageMoverData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Qumulo.StorageMoverResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageMoverName, Azure.ResourceManager.Qumulo.StorageMoverData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.StorageMoverResource> Get(string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Qumulo.StorageMoverResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Qumulo.StorageMoverResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.StorageMoverResource>> GetAsync(string storageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Qumulo.StorageMoverResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.StorageMoverResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Qumulo.StorageMoverResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.StorageMoverResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageMoverData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public StorageMoverData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class StorageMoverResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageMoverResource() { }
        public virtual Azure.ResourceManager.Qumulo.StorageMoverData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.StorageMoverResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.StorageMoverResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageMoverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.StorageMoverResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.StorageMoverResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloAgentResource> GetQumuloAgent(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloAgentResource>> GetQumuloAgentAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Qumulo.QumuloAgentCollection GetQumuloAgents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloEndpointResource> GetQumuloEndpoint(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloEndpointResource>> GetQumuloEndpointAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Qumulo.QumuloEndpointCollection GetQumuloEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloProjectResource> GetQumuloProject(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloProjectResource>> GetQumuloProjectAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Qumulo.QumuloProjectCollection GetQumuloProjects() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.StorageMoverResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.StorageMoverResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.StorageMoverResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.StorageMoverResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.StorageMoverResource> Update(Azure.ResourceManager.Qumulo.Models.StorageMoverPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.StorageMoverResource>> UpdateAsync(Azure.ResourceManager.Qumulo.Models.StorageMoverPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Qumulo.Models
{
    public static partial class ArmQumuloModelFactory
    {
        public static Azure.ResourceManager.Qumulo.Models.AzureStorageBlobContainerEndpointProperties AzureStorageBlobContainerEndpointProperties(string description = null, Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState? provisioningState = default(Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState?), string storageAccountResourceId = null, string blobContainerName = null) { throw null; }
        public static Azure.ResourceManager.Qumulo.Models.EndpointBaseProperties EndpointBaseProperties(string endpointType = "Unknown", string description = null, Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState? provisioningState = default(Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Qumulo.JobDefinitionData JobDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, Azure.ResourceManager.Qumulo.Models.QumuloCopyMode copyMode = default(Azure.ResourceManager.Qumulo.Models.QumuloCopyMode), string sourceName = null, string sourceResourceId = null, string sourceSubpath = null, string targetName = null, string targetResourceId = null, string targetSubpath = null, string latestJobRunName = null, string latestJobRunResourceId = null, Azure.ResourceManager.Qumulo.Models.JobRunStatus? latestJobRunStatus = default(Azure.ResourceManager.Qumulo.Models.JobRunStatus?), string agentName = null, string agentResourceId = null, Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState? provisioningState = default(Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Qumulo.JobRunData JobRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Qumulo.Models.JobRunStatus? status = default(Azure.ResourceManager.Qumulo.Models.JobRunStatus?), Azure.ResourceManager.Qumulo.Models.JobRunScanStatus? scanStatus = default(Azure.ResourceManager.Qumulo.Models.JobRunScanStatus?), string agentName = null, string agentResourceId = null, System.DateTimeOffset? executionStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? executionEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastStatusUpdate = default(System.DateTimeOffset?), long? itemsScanned = default(long?), long? itemsExcluded = default(long?), long? itemsUnsupported = default(long?), long? itemsNoTransferNeeded = default(long?), long? itemsFailed = default(long?), long? itemsTransferred = default(long?), long? bytesScanned = default(long?), long? bytesExcluded = default(long?), long? bytesUnsupported = default(long?), long? bytesNoTransferNeeded = default(long?), long? bytesFailed = default(long?), long? bytesTransferred = default(long?), string sourceName = null, string sourceResourceId = null, System.BinaryData sourceProperties = null, string targetName = null, string targetResourceId = null, System.BinaryData targetProperties = null, System.BinaryData jobDefinitionProperties = null, Azure.ResourceManager.Qumulo.Models.JobRunError error = null, Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState? provisioningState = default(Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Qumulo.Models.JobRunError JobRunError(string code = null, string message = null, string target = null) { throw null; }
        public static Azure.ResourceManager.Qumulo.Models.JobRunResourceId JobRunResourceId(string jobRunResourceIdValue = null) { throw null; }
        public static Azure.ResourceManager.Qumulo.Models.NfsMountEndpointProperties NfsMountEndpointProperties(string description = null, Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState? provisioningState = default(Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState?), string host = null, Azure.ResourceManager.Qumulo.Models.NfsVersion? nfsVersion = default(Azure.ResourceManager.Qumulo.Models.NfsVersion?), string export = null) { throw null; }
        public static Azure.ResourceManager.Qumulo.QumuloAgentData QumuloAgentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, string agentVersion = null, string arcResourceId = null, string arcVmUuid = null, Azure.ResourceManager.Qumulo.Models.QumuloAgentStatus? agentStatus = default(Azure.ResourceManager.Qumulo.Models.QumuloAgentStatus?), System.DateTimeOffset? lastStatusUpdate = default(System.DateTimeOffset?), string localIPAddress = null, long? memoryInMB = default(long?), long? numberOfCores = default(long?), long? uptimeInSeconds = default(long?), Azure.ResourceManager.Qumulo.Models.QumuloAgentPropertiesErrorDetails errorDetails = null, Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState? provisioningState = default(Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Qumulo.Models.QumuloAgentPropertiesErrorDetails QumuloAgentPropertiesErrorDetails(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Qumulo.QumuloEndpointData QumuloEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Qumulo.Models.EndpointBaseProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Qumulo.QumuloProjectData QumuloProjectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState? provisioningState = default(Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Qumulo.StorageMoverData StorageMoverData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string description = null, Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState? provisioningState = default(Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState?)) { throw null; }
    }
    public partial class AzureStorageBlobContainerEndpointProperties : Azure.ResourceManager.Qumulo.Models.EndpointBaseProperties
    {
        public AzureStorageBlobContainerEndpointProperties(string storageAccountResourceId, string blobContainerName) { }
        public string BlobContainerName { get { throw null; } set { } }
        public string StorageAccountResourceId { get { throw null; } set { } }
    }
    public abstract partial class EndpointBaseProperties
    {
        protected EndpointBaseProperties() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class JobDefinitionPatch
    {
        public JobDefinitionPatch() { }
        public string AgentName { get { throw null; } set { } }
        public Azure.ResourceManager.Qumulo.Models.QumuloCopyMode? CopyMode { get { throw null; } set { } }
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
    public readonly partial struct JobRunScanStatus : System.IEquatable<Azure.ResourceManager.Qumulo.Models.JobRunScanStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobRunScanStatus(string value) { throw null; }
        public static Azure.ResourceManager.Qumulo.Models.JobRunScanStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.JobRunScanStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.JobRunScanStatus Scanning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Qumulo.Models.JobRunScanStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Qumulo.Models.JobRunScanStatus left, Azure.ResourceManager.Qumulo.Models.JobRunScanStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Qumulo.Models.JobRunScanStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Qumulo.Models.JobRunScanStatus left, Azure.ResourceManager.Qumulo.Models.JobRunScanStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobRunStatus : System.IEquatable<Azure.ResourceManager.Qumulo.Models.JobRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobRunStatus(string value) { throw null; }
        public static Azure.ResourceManager.Qumulo.Models.JobRunStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.JobRunStatus Canceling { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.JobRunStatus CancelRequested { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.JobRunStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.JobRunStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.JobRunStatus Running { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.JobRunStatus Started { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.JobRunStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Qumulo.Models.JobRunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Qumulo.Models.JobRunStatus left, Azure.ResourceManager.Qumulo.Models.JobRunStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Qumulo.Models.JobRunStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Qumulo.Models.JobRunStatus left, Azure.ResourceManager.Qumulo.Models.JobRunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NfsMountEndpointProperties : Azure.ResourceManager.Qumulo.Models.EndpointBaseProperties
    {
        public NfsMountEndpointProperties(string host, string export) { }
        public string Export { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public Azure.ResourceManager.Qumulo.Models.NfsVersion? NfsVersion { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NfsVersion : System.IEquatable<Azure.ResourceManager.Qumulo.Models.NfsVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NfsVersion(string value) { throw null; }
        public static Azure.ResourceManager.Qumulo.Models.NfsVersion NFSauto { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.NfsVersion NFSv3 { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.NfsVersion NFSv4 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Qumulo.Models.NfsVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Qumulo.Models.NfsVersion left, Azure.ResourceManager.Qumulo.Models.NfsVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Qumulo.Models.NfsVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Qumulo.Models.NfsVersion left, Azure.ResourceManager.Qumulo.Models.NfsVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QumuloAgentPatch
    {
        public QumuloAgentPatch() { }
        public string Description { get { throw null; } set { } }
    }
    public partial class QumuloAgentPropertiesErrorDetails
    {
        internal QumuloAgentPropertiesErrorDetails() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QumuloAgentStatus : System.IEquatable<Azure.ResourceManager.Qumulo.Models.QumuloAgentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QumuloAgentStatus(string value) { throw null; }
        public static Azure.ResourceManager.Qumulo.Models.QumuloAgentStatus Executing { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.QumuloAgentStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.QumuloAgentStatus Online { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.QumuloAgentStatus Registering { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.QumuloAgentStatus RequiresAttention { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.QumuloAgentStatus Unregistering { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Qumulo.Models.QumuloAgentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Qumulo.Models.QumuloAgentStatus left, Azure.ResourceManager.Qumulo.Models.QumuloAgentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Qumulo.Models.QumuloAgentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Qumulo.Models.QumuloAgentStatus left, Azure.ResourceManager.Qumulo.Models.QumuloAgentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QumuloCopyMode : System.IEquatable<Azure.ResourceManager.Qumulo.Models.QumuloCopyMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QumuloCopyMode(string value) { throw null; }
        public static Azure.ResourceManager.Qumulo.Models.QumuloCopyMode Additive { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.QumuloCopyMode Mirror { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Qumulo.Models.QumuloCopyMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Qumulo.Models.QumuloCopyMode left, Azure.ResourceManager.Qumulo.Models.QumuloCopyMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Qumulo.Models.QumuloCopyMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Qumulo.Models.QumuloCopyMode left, Azure.ResourceManager.Qumulo.Models.QumuloCopyMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QumuloEndpointPatch
    {
        public QumuloEndpointPatch() { }
        public string EndpointBaseUpdateDescription { get { throw null; } set { } }
    }
    public partial class QumuloProjectPatch
    {
        public QumuloProjectPatch() { }
        public string Description { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QumuloProvisioningState : System.IEquatable<Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QumuloProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState left, Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState left, Azure.ResourceManager.Qumulo.Models.QumuloProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageMoverPatch
    {
        public StorageMoverPatch() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
}
