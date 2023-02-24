namespace Azure.ResourceManager.LiftrQumulo
{
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
        public Azure.ResourceManager.LiftrQumulo.Models.CopyMode CopyMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string LatestQumuloJobRunName { get { throw null; } }
        public string LatestQumuloJobRunResourceId { get { throw null; } }
        public Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunStatus? LatestQumuloJobRunStatus { get { throw null; } }
        public Azure.ResourceManager.LiftrQumulo.Models.ProvisioningState? ProvisioningState { get { throw null; } }
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
        public virtual Azure.ResourceManager.LiftrQumulo.JobDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string qumuloStorageMoverName, string qumuloProjectName, string jobDefinitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloJobRunResource> GetQumuloJobRun(string qumuloJobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloJobRunResource>> GetQumuloJobRunAsync(string qumuloJobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LiftrQumulo.QumuloJobRunCollection GetQumuloJobRuns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunResourceId> StartJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunResourceId>> StartJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunResourceId> StopJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunResourceId>> StopJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource> Update(Azure.ResourceManager.LiftrQumulo.Models.JobDefinitionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource>> UpdateAsync(Azure.ResourceManager.LiftrQumulo.Models.JobDefinitionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class LiftrQumuloExtensions
    {
        public static Azure.ResourceManager.LiftrQumulo.JobDefinitionResource GetJobDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.QumuloAgentResource GetQumuloAgentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.QumuloEndpointResource GetQumuloEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.QumuloJobRunResource GetQumuloJobRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.QumuloProjectResource GetQumuloProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource> GetQumuloStorageMover(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string qumuloStorageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource>> GetQumuloStorageMoverAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string qumuloStorageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource GetQumuloStorageMoverResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverCollection GetQumuloStorageMovers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource> GetQumuloStorageMovers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource> GetQumuloStorageMoversAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QumuloAgentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.QumuloAgentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.QumuloAgentResource>, System.Collections.IEnumerable
    {
        protected QumuloAgentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LiftrQumulo.QumuloAgentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string qumuloAgentName, Azure.ResourceManager.LiftrQumulo.QumuloAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LiftrQumulo.QumuloAgentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string qumuloAgentName, Azure.ResourceManager.LiftrQumulo.QumuloAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string qumuloAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string qumuloAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloAgentResource> Get(string qumuloAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LiftrQumulo.QumuloAgentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LiftrQumulo.QumuloAgentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloAgentResource>> GetAsync(string qumuloAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LiftrQumulo.QumuloAgentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.QumuloAgentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LiftrQumulo.QumuloAgentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.QumuloAgentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QumuloAgentData : Azure.ResourceManager.Models.ResourceData
    {
        public QumuloAgentData(string arcResourceId, string arcVmUuid) { }
        public string ArcResourceId { get { throw null; } set { } }
        public string ArcVmUuid { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.LiftrQumulo.Models.QumuloAgentPropertiesErrorDetails ErrorDetails { get { throw null; } }
        public System.DateTimeOffset? LastStatusUpdate { get { throw null; } }
        public string LocalIPAddress { get { throw null; } }
        public long? MemoryInMB { get { throw null; } }
        public long? NumberOfCores { get { throw null; } }
        public Azure.ResourceManager.LiftrQumulo.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.LiftrQumulo.Models.QumuloAgentStatus? QumuloAgentStatus { get { throw null; } }
        public string QumuloAgentVersion { get { throw null; } }
        public long? UptimeInSeconds { get { throw null; } }
    }
    public partial class QumuloAgentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QumuloAgentResource() { }
        public virtual Azure.ResourceManager.LiftrQumulo.QumuloAgentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string qumuloStorageMoverName, string qumuloAgentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloAgentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloAgentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloAgentResource> Update(Azure.ResourceManager.LiftrQumulo.Models.QumuloQumuloAgentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloAgentResource>> UpdateAsync(Azure.ResourceManager.LiftrQumulo.Models.QumuloQumuloAgentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QumuloEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.QumuloEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.QumuloEndpointResource>, System.Collections.IEnumerable
    {
        protected QumuloEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LiftrQumulo.QumuloEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string qumuloEndpointName, Azure.ResourceManager.LiftrQumulo.QumuloEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LiftrQumulo.QumuloEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string qumuloEndpointName, Azure.ResourceManager.LiftrQumulo.QumuloEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string qumuloEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string qumuloEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloEndpointResource> Get(string qumuloEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LiftrQumulo.QumuloEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LiftrQumulo.QumuloEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloEndpointResource>> GetAsync(string qumuloEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LiftrQumulo.QumuloEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.QumuloEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LiftrQumulo.QumuloEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.QumuloEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QumuloEndpointData : Azure.ResourceManager.Models.ResourceData
    {
        public QumuloEndpointData(Azure.ResourceManager.LiftrQumulo.Models.QumuloEndpointBaseProperties properties) { }
        public Azure.ResourceManager.LiftrQumulo.Models.QumuloEndpointBaseProperties Properties { get { throw null; } set { } }
    }
    public partial class QumuloEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QumuloEndpointResource() { }
        public virtual Azure.ResourceManager.LiftrQumulo.QumuloEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string qumuloStorageMoverName, string qumuloEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloEndpointResource> Update(Azure.ResourceManager.LiftrQumulo.Models.QumuloQumuloEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloEndpointResource>> UpdateAsync(Azure.ResourceManager.LiftrQumulo.Models.QumuloQumuloEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QumuloJobRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.QumuloJobRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.QumuloJobRunResource>, System.Collections.IEnumerable
    {
        protected QumuloJobRunCollection() { }
        public virtual Azure.Response<bool> Exists(string qumuloJobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string qumuloJobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloJobRunResource> Get(string qumuloJobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LiftrQumulo.QumuloJobRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LiftrQumulo.QumuloJobRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloJobRunResource>> GetAsync(string qumuloJobRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LiftrQumulo.QumuloJobRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.QumuloJobRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LiftrQumulo.QumuloJobRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.QumuloJobRunResource>.GetEnumerator() { throw null; }
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
        public Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunError Error { get { throw null; } }
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
        public string QumuloAgentName { get { throw null; } }
        public string QumuloAgentResourceId { get { throw null; } }
        public Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunScanStatus? ScanStatus { get { throw null; } }
        public string SourceName { get { throw null; } }
        public System.BinaryData SourceProperties { get { throw null; } }
        public string SourceResourceId { get { throw null; } }
        public Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunStatus? Status { get { throw null; } }
        public string TargetName { get { throw null; } }
        public System.BinaryData TargetProperties { get { throw null; } }
        public string TargetResourceId { get { throw null; } }
    }
    public partial class QumuloJobRunResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QumuloJobRunResource() { }
        public virtual Azure.ResourceManager.LiftrQumulo.QumuloJobRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string qumuloStorageMoverName, string qumuloProjectName, string jobDefinitionName, string qumuloJobRunName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloJobRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloJobRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QumuloProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.QumuloProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.QumuloProjectResource>, System.Collections.IEnumerable
    {
        protected QumuloProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LiftrQumulo.QumuloProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string qumuloProjectName, Azure.ResourceManager.LiftrQumulo.QumuloProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LiftrQumulo.QumuloProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string qumuloProjectName, Azure.ResourceManager.LiftrQumulo.QumuloProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string qumuloProjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string qumuloProjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloProjectResource> Get(string qumuloProjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LiftrQumulo.QumuloProjectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LiftrQumulo.QumuloProjectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloProjectResource>> GetAsync(string qumuloProjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LiftrQumulo.QumuloProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.QumuloProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LiftrQumulo.QumuloProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.QumuloProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QumuloProjectData : Azure.ResourceManager.Models.ResourceData
    {
        public QumuloProjectData() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.LiftrQumulo.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class QumuloProjectResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QumuloProjectResource() { }
        public virtual Azure.ResourceManager.LiftrQumulo.QumuloProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string qumuloStorageMoverName, string qumuloProjectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource> GetJobDefinition(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.JobDefinitionResource>> GetJobDefinitionAsync(string jobDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LiftrQumulo.JobDefinitionCollection GetJobDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloProjectResource> Update(Azure.ResourceManager.LiftrQumulo.Models.QumuloQumuloProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloProjectResource>> UpdateAsync(Azure.ResourceManager.LiftrQumulo.Models.QumuloQumuloProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QumuloStorageMoverCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource>, System.Collections.IEnumerable
    {
        protected QumuloStorageMoverCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string qumuloStorageMoverName, Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string qumuloStorageMoverName, Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string qumuloStorageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string qumuloStorageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource> Get(string qumuloStorageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource>> GetAsync(string qumuloStorageMoverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QumuloStorageMoverData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public QumuloStorageMoverData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.LiftrQumulo.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class QumuloStorageMoverResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QumuloStorageMoverResource() { }
        public virtual Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string qumuloStorageMoverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloAgentResource> GetQumuloAgent(string qumuloAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloAgentResource>> GetQumuloAgentAsync(string qumuloAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LiftrQumulo.QumuloAgentCollection GetQumuloAgents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloEndpointResource> GetQumuloEndpoint(string qumuloEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloEndpointResource>> GetQumuloEndpointAsync(string qumuloEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LiftrQumulo.QumuloEndpointCollection GetQumuloEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloProjectResource> GetQumuloProject(string qumuloProjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloProjectResource>> GetQumuloProjectAsync(string qumuloProjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LiftrQumulo.QumuloProjectCollection GetQumuloProjects() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource> Update(Azure.ResourceManager.LiftrQumulo.Models.QumuloQumuloStorageMoverPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LiftrQumulo.QumuloStorageMoverResource>> UpdateAsync(Azure.ResourceManager.LiftrQumulo.Models.QumuloQumuloStorageMoverPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.LiftrQumulo.Models
{
    public partial class AzureStorageBlobContainerQumuloEndpointProperties : Azure.ResourceManager.LiftrQumulo.Models.QumuloEndpointBaseProperties
    {
        public AzureStorageBlobContainerQumuloEndpointProperties(string storageAccountResourceId, string blobContainerName) { }
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
    public partial class JobDefinitionPatch
    {
        public JobDefinitionPatch() { }
        public Azure.ResourceManager.LiftrQumulo.Models.CopyMode? CopyMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string QumuloAgentName { get { throw null; } set { } }
    }
    public partial class NfsMountQumuloEndpointProperties : Azure.ResourceManager.LiftrQumulo.Models.QumuloEndpointBaseProperties
    {
        public NfsMountQumuloEndpointProperties(string host, string export) { }
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
    public partial class QumuloAgentPropertiesErrorDetails
    {
        internal QumuloAgentPropertiesErrorDetails() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QumuloAgentStatus : System.IEquatable<Azure.ResourceManager.LiftrQumulo.Models.QumuloAgentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QumuloAgentStatus(string value) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.Models.QumuloAgentStatus Executing { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.QumuloAgentStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.QumuloAgentStatus Online { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.QumuloAgentStatus Registering { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.QumuloAgentStatus RequiresAttention { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.QumuloAgentStatus Unregistering { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LiftrQumulo.Models.QumuloAgentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LiftrQumulo.Models.QumuloAgentStatus left, Azure.ResourceManager.LiftrQumulo.Models.QumuloAgentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.LiftrQumulo.Models.QumuloAgentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LiftrQumulo.Models.QumuloAgentStatus left, Azure.ResourceManager.LiftrQumulo.Models.QumuloAgentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class QumuloEndpointBaseProperties
    {
        protected QumuloEndpointBaseProperties() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.LiftrQumulo.Models.ProvisioningState? ProvisioningState { get { throw null; } }
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
    public readonly partial struct QumuloJobRunScanStatus : System.IEquatable<Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunScanStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QumuloJobRunScanStatus(string value) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunScanStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunScanStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunScanStatus Scanning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunScanStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunScanStatus left, Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunScanStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunScanStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunScanStatus left, Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunScanStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QumuloJobRunStatus : System.IEquatable<Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QumuloJobRunStatus(string value) { throw null; }
        public static Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunStatus Canceling { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunStatus CancelRequested { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunStatus Running { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunStatus Started { get { throw null; } }
        public static Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunStatus left, Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunStatus left, Azure.ResourceManager.LiftrQumulo.Models.QumuloJobRunStatus right) { throw null; }
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
}
