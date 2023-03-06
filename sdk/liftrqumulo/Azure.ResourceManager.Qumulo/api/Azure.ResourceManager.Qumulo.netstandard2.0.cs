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
        public JobDefinitionData(Azure.ResourceManager.Qumulo.Models.CopyMode copyMode, string sourceName, string targetName) { }
        public Azure.ResourceManager.Qumulo.Models.CopyMode CopyMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string LatestQumuloJobRunName { get { throw null; } }
        public string LatestQumuloJobRunResourceId { get { throw null; } }
        public Azure.ResourceManager.Qumulo.Models.QumuloJobRunStatus? LatestQumuloJobRunStatus { get { throw null; } }
        public Azure.ResourceManager.Qumulo.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string QumuloAgentName { get { throw null; } set { } }
        public string QumuloAgentResourceId { get { throw null; } }
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
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string qumuloStorageMoverName, string qumuloProjectName, string jobDefinitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.JobDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.JobDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloJobRunResource> GetQumuloJobRun(string qumuloJobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloJobRunResource>> GetQumuloJobRunAsync(string qumuloJobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Qumulo.QumuloJobRunCollection GetQumuloJobRuns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.Models.QumuloJobRunResourceId> StartJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.Models.QumuloJobRunResourceId>> StartJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.Models.QumuloJobRunResourceId> StopJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.Models.QumuloJobRunResourceId>> StopJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.JobDefinitionResource> Update(Azure.ResourceManager.Qumulo.Models.JobDefinitionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.JobDefinitionResource>> UpdateAsync(Azure.ResourceManager.Qumulo.Models.JobDefinitionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QumuloAgentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.QumuloAgentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.QumuloAgentResource>, System.Collections.IEnumerable
    {
        protected QumuloAgentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Qumulo.QumuloAgentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string qumuloAgentName, Azure.ResourceManager.Qumulo.QumuloAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Qumulo.QumuloAgentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string qumuloAgentName, Azure.ResourceManager.Qumulo.QumuloAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string qumuloAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string qumuloAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloAgentResource> Get(string qumuloAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Qumulo.QumuloAgentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Qumulo.QumuloAgentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloAgentResource>> GetAsync(string qumuloAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Qumulo.QumuloAgentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.QumuloAgentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Qumulo.QumuloAgentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.QumuloAgentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QumuloAgentData : Azure.ResourceManager.Models.ResourceData
    {
        public QumuloAgentData(string arcResourceId, string arcVmUuid) { }
        public string ArcResourceId { get { throw null; } set { } }
        public string ArcVmUuid { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Qumulo.Models.QumuloAgentPropertiesErrorDetails ErrorDetails { get { throw null; } }
        public System.DateTimeOffset? LastStatusUpdate { get { throw null; } }
        public string LocalIPAddress { get { throw null; } }
        public long? MemoryInMB { get { throw null; } }
        public long? NumberOfCores { get { throw null; } }
        public Azure.ResourceManager.Qumulo.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Qumulo.Models.QumuloAgentStatus? QumuloAgentStatus { get { throw null; } }
        public string QumuloAgentVersion { get { throw null; } }
        public long? UptimeInSeconds { get { throw null; } }
    }
    public partial class QumuloAgentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QumuloAgentResource() { }
        public virtual Azure.ResourceManager.Qumulo.QumuloAgentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string qumuloStorageMoverName, string qumuloAgentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloAgentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloAgentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloAgentResource> Update(Azure.ResourceManager.Qumulo.Models.QumuloQumuloAgentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloAgentResource>> UpdateAsync(Azure.ResourceManager.Qumulo.Models.QumuloQumuloAgentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QumuloEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.QumuloEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.QumuloEndpointResource>, System.Collections.IEnumerable
    {
        protected QumuloEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Qumulo.QumuloEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string qumuloEndpointName, Azure.ResourceManager.Qumulo.QumuloEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Qumulo.QumuloEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string qumuloEndpointName, Azure.ResourceManager.Qumulo.QumuloEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string qumuloEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string qumuloEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloEndpointResource> Get(string qumuloEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Qumulo.QumuloEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Qumulo.QumuloEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloEndpointResource>> GetAsync(string qumuloEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Qumulo.QumuloEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.QumuloEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Qumulo.QumuloEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.QumuloEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QumuloEndpointData : Azure.ResourceManager.Models.ResourceData
    {
        public QumuloEndpointData(Azure.ResourceManager.Qumulo.Models.QumuloEndpointBaseProperties properties) { }
        public Azure.ResourceManager.Qumulo.Models.QumuloEndpointBaseProperties Properties { get { throw null; } set { } }
    }
    public partial class QumuloEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QumuloEndpointResource() { }
        public virtual Azure.ResourceManager.Qumulo.QumuloEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string qumuloStorageMoverName, string qumuloEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloEndpointResource> Update(Azure.ResourceManager.Qumulo.Models.QumuloQumuloEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloEndpointResource>> UpdateAsync(Azure.ResourceManager.Qumulo.Models.QumuloQumuloEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class QumuloExtensions
    {
        public static Azure.ResourceManager.Qumulo.JobDefinitionResource GetJobDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Qumulo.QumuloAgentResource GetQumuloAgentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Qumulo.QumuloEndpointResource GetQumuloEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Qumulo.QumuloJobRunResource GetQumuloJobRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Qumulo.QumuloProjectResource GetQumuloProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource> GetQumuloStorageMover(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string qumuloStorageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource>> GetQumuloStorageMoverAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string qumuloStorageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Qumulo.QumuloStorageMoverResource GetQumuloStorageMoverResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Qumulo.QumuloStorageMoverCollection GetQumuloStorageMovers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource> GetQumuloStorageMovers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource> GetQumuloStorageMoversAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QumuloJobRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.QumuloJobRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.QumuloJobRunResource>, System.Collections.IEnumerable
    {
        protected QumuloJobRunCollection() { }
        public virtual Azure.Response<bool> Exists(string qumuloJobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string qumuloJobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloJobRunResource> Get(string qumuloJobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Qumulo.QumuloJobRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Qumulo.QumuloJobRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloJobRunResource>> GetAsync(string qumuloJobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Qumulo.QumuloJobRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.QumuloJobRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Qumulo.QumuloJobRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.QumuloJobRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QumuloJobRunData : Azure.ResourceManager.Models.ResourceData
    {
        public QumuloJobRunData() { }
        public long? BytesExcluded { get { throw null; } }
        public long? BytesFailed { get { throw null; } }
        public long? BytesNoTransferNeeded { get { throw null; } }
        public long? BytesScanned { get { throw null; } }
        public long? BytesTransferred { get { throw null; } }
        public long? BytesUnsupported { get { throw null; } }
        public Azure.ResourceManager.Qumulo.Models.QumuloJobRunError Error { get { throw null; } }
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
        public Azure.ResourceManager.Qumulo.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string QumuloAgentName { get { throw null; } }
        public string QumuloAgentResourceId { get { throw null; } }
        public Azure.ResourceManager.Qumulo.Models.QumuloJobRunScanStatus? ScanStatus { get { throw null; } }
        public string SourceName { get { throw null; } }
        public System.BinaryData SourceProperties { get { throw null; } }
        public string SourceResourceId { get { throw null; } }
        public Azure.ResourceManager.Qumulo.Models.QumuloJobRunStatus? Status { get { throw null; } }
        public string TargetName { get { throw null; } }
        public System.BinaryData TargetProperties { get { throw null; } }
        public string TargetResourceId { get { throw null; } }
    }
    public partial class QumuloJobRunResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QumuloJobRunResource() { }
        public virtual Azure.ResourceManager.Qumulo.QumuloJobRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string qumuloStorageMoverName, string qumuloProjectName, string jobDefinitionName, string qumuloJobRunName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloJobRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloJobRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QumuloProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.QumuloProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.QumuloProjectResource>, System.Collections.IEnumerable
    {
        protected QumuloProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Qumulo.QumuloProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string qumuloProjectName, Azure.ResourceManager.Qumulo.QumuloProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Qumulo.QumuloProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string qumuloProjectName, Azure.ResourceManager.Qumulo.QumuloProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string qumuloProjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string qumuloProjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloProjectResource> Get(string qumuloProjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Qumulo.QumuloProjectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Qumulo.QumuloProjectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloProjectResource>> GetAsync(string qumuloProjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Qumulo.QumuloProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.QumuloProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Qumulo.QumuloProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.QumuloProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QumuloProjectData : Azure.ResourceManager.Models.ResourceData
    {
        public QumuloProjectData() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Qumulo.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class QumuloProjectResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QumuloProjectResource() { }
        public virtual Azure.ResourceManager.Qumulo.QumuloProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string qumuloStorageMoverName, string qumuloProjectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.JobDefinitionResource> GetJobDefinition(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.JobDefinitionResource>> GetJobDefinitionAsync(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Qumulo.JobDefinitionCollection GetJobDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloProjectResource> Update(Azure.ResourceManager.Qumulo.Models.QumuloQumuloProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloProjectResource>> UpdateAsync(Azure.ResourceManager.Qumulo.Models.QumuloQumuloProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QumuloStorageMoverCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource>, System.Collections.IEnumerable
    {
        protected QumuloStorageMoverCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string qumuloStorageMoverName, Azure.ResourceManager.Qumulo.QumuloStorageMoverData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string qumuloStorageMoverName, Azure.ResourceManager.Qumulo.QumuloStorageMoverData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string qumuloStorageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string qumuloStorageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource> Get(string qumuloStorageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource>> GetAsync(string qumuloStorageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QumuloStorageMoverData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public QumuloStorageMoverData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Qumulo.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class QumuloStorageMoverResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QumuloStorageMoverResource() { }
        public virtual Azure.ResourceManager.Qumulo.QumuloStorageMoverData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string qumuloStorageMoverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloAgentResource> GetQumuloAgent(string qumuloAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloAgentResource>> GetQumuloAgentAsync(string qumuloAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Qumulo.QumuloAgentCollection GetQumuloAgents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloEndpointResource> GetQumuloEndpoint(string qumuloEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloEndpointResource>> GetQumuloEndpointAsync(string qumuloEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Qumulo.QumuloEndpointCollection GetQumuloEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloProjectResource> GetQumuloProject(string qumuloProjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloProjectResource>> GetQumuloProjectAsync(string qumuloProjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Qumulo.QumuloProjectCollection GetQumuloProjects() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource> Update(Azure.ResourceManager.Qumulo.Models.QumuloQumuloStorageMoverPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Qumulo.QumuloStorageMoverResource>> UpdateAsync(Azure.ResourceManager.Qumulo.Models.QumuloQumuloStorageMoverPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Qumulo.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CopyMode : System.IEquatable<Azure.ResourceManager.Qumulo.Models.CopyMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CopyMode(string value) { throw null; }
        public static Azure.ResourceManager.Qumulo.Models.CopyMode Additive { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.CopyMode Mirror { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Qumulo.Models.CopyMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Qumulo.Models.CopyMode left, Azure.ResourceManager.Qumulo.Models.CopyMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Qumulo.Models.CopyMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Qumulo.Models.CopyMode left, Azure.ResourceManager.Qumulo.Models.CopyMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobDefinitionPatch
    {
        public JobDefinitionPatch() { }
        public Azure.ResourceManager.Qumulo.Models.CopyMode? CopyMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string QumuloAgentName { get { throw null; } set { } }
    }
    public partial class NfsMountQumuloEndpointProperties : Azure.ResourceManager.Qumulo.Models.QumuloEndpointBaseProperties
    {
        public NfsMountQumuloEndpointProperties(string host, string export) { }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Qumulo.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Qumulo.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Qumulo.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Qumulo.Models.ProvisioningState left, Azure.ResourceManager.Qumulo.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Qumulo.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Qumulo.Models.ProvisioningState left, Azure.ResourceManager.Qumulo.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
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
    public abstract partial class QumuloEndpointBaseProperties
    {
        protected QumuloEndpointBaseProperties() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Qumulo.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class QumuloJobRunError
    {
        internal QumuloJobRunError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class QumuloJobRunResourceId
    {
        internal QumuloJobRunResourceId() { }
        public string QumuloJobRunResourceIdValue { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QumuloJobRunScanStatus : System.IEquatable<Azure.ResourceManager.Qumulo.Models.QumuloJobRunScanStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QumuloJobRunScanStatus(string value) { throw null; }
        public static Azure.ResourceManager.Qumulo.Models.QumuloJobRunScanStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.QumuloJobRunScanStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.QumuloJobRunScanStatus Scanning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Qumulo.Models.QumuloJobRunScanStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Qumulo.Models.QumuloJobRunScanStatus left, Azure.ResourceManager.Qumulo.Models.QumuloJobRunScanStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Qumulo.Models.QumuloJobRunScanStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Qumulo.Models.QumuloJobRunScanStatus left, Azure.ResourceManager.Qumulo.Models.QumuloJobRunScanStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QumuloJobRunStatus : System.IEquatable<Azure.ResourceManager.Qumulo.Models.QumuloJobRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QumuloJobRunStatus(string value) { throw null; }
        public static Azure.ResourceManager.Qumulo.Models.QumuloJobRunStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.QumuloJobRunStatus Canceling { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.QumuloJobRunStatus CancelRequested { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.QumuloJobRunStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.QumuloJobRunStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.QumuloJobRunStatus Running { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.QumuloJobRunStatus Started { get { throw null; } }
        public static Azure.ResourceManager.Qumulo.Models.QumuloJobRunStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Qumulo.Models.QumuloJobRunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Qumulo.Models.QumuloJobRunStatus left, Azure.ResourceManager.Qumulo.Models.QumuloJobRunStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Qumulo.Models.QumuloJobRunStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Qumulo.Models.QumuloJobRunStatus left, Azure.ResourceManager.Qumulo.Models.QumuloJobRunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QumuloQumuloAgentPatch
    {
        public QumuloQumuloAgentPatch() { }
        public string Description { get { throw null; } set { } }
    }
    public partial class QumuloQumuloEndpointPatch
    {
        public QumuloQumuloEndpointPatch() { }
        public string QumuloEndpointBaseUpdateDescription { get { throw null; } set { } }
    }
    public partial class QumuloQumuloProjectPatch
    {
        public QumuloQumuloProjectPatch() { }
        public string Description { get { throw null; } set { } }
    }
    public partial class QumuloQumuloStorageMoverPatch
    {
        public QumuloQumuloStorageMoverPatch() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class StorageBlobContainerEndpointProperties : Azure.ResourceManager.Qumulo.Models.QumuloEndpointBaseProperties
    {
        public StorageBlobContainerEndpointProperties(string storageAccountResourceId, string blobContainerName) { }
        public string BlobContainerName { get { throw null; } set { } }
        public string StorageAccountResourceId { get { throw null; } set { } }
    }
}
