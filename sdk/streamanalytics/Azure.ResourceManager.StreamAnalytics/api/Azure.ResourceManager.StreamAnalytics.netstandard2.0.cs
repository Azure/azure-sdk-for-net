namespace Azure.ResourceManager.StreamAnalytics
{
    public partial class ClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.ClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.ClusterResource>, System.Collections.IEnumerable
    {
        protected ClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.ClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.StreamAnalytics.ClusterData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.ClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.StreamAnalytics.ClusterData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.ClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StreamAnalytics.ClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.ClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.ClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StreamAnalytics.ClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.ClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StreamAnalytics.ClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.ClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ClusterData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? Etag { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.ClusterProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.ClusterSku Sku { get { throw null; } set { } }
    }
    public partial class ClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterResource() { }
        public virtual Azure.ResourceManager.StreamAnalytics.ClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.ClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.ClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.ClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.ClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.PrivateEndpointResource> GetPrivateEndpoint(string privateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.PrivateEndpointResource>> GetPrivateEndpointAsync(string privateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StreamAnalytics.PrivateEndpointCollection GetPrivateEndpoints() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StreamAnalytics.Models.ClusterJob> GetStreamingJobs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.Models.ClusterJob> GetStreamingJobsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.ClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.ClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.ClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.ClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.ClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.ClusterData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.ClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.ClusterData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FunctionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.FunctionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.FunctionResource>, System.Collections.IEnumerable
    {
        protected FunctionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.FunctionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string functionName, Azure.ResourceManager.StreamAnalytics.FunctionData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.FunctionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string functionName, Azure.ResourceManager.StreamAnalytics.FunctionData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.FunctionResource> Get(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StreamAnalytics.FunctionResource> GetAll(string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.FunctionResource> GetAllAsync(string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.FunctionResource>> GetAsync(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StreamAnalytics.FunctionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.FunctionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StreamAnalytics.FunctionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.FunctionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FunctionData : Azure.ResourceManager.StreamAnalytics.Models.SubResource
    {
        public FunctionData() { }
        public Azure.ResourceManager.StreamAnalytics.Models.FunctionProperties Properties { get { throw null; } set { } }
    }
    public partial class FunctionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FunctionResource() { }
        public virtual Azure.ResourceManager.StreamAnalytics.FunctionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string jobName, string functionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.FunctionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.FunctionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.FunctionResource> RetrieveDefaultDefinition(Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.FunctionResource>> RetrieveDefaultDefinitionAsync(Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.ResourceTestStatus> Test(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.FunctionData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.ResourceTestStatus>> TestAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.FunctionData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.FunctionResource> Update(Azure.ResourceManager.StreamAnalytics.FunctionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.FunctionResource>> UpdateAsync(Azure.ResourceManager.StreamAnalytics.FunctionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InputCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.InputResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.InputResource>, System.Collections.IEnumerable
    {
        protected InputCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.InputResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string inputName, Azure.ResourceManager.StreamAnalytics.InputData input, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.InputResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string inputName, Azure.ResourceManager.StreamAnalytics.InputData input, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string inputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string inputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.InputResource> Get(string inputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StreamAnalytics.InputResource> GetAll(string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.InputResource> GetAllAsync(string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.InputResource>> GetAsync(string inputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StreamAnalytics.InputResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.InputResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StreamAnalytics.InputResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.InputResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InputData : Azure.ResourceManager.StreamAnalytics.Models.SubResource
    {
        public InputData() { }
        public Azure.ResourceManager.StreamAnalytics.Models.InputProperties Properties { get { throw null; } set { } }
    }
    public partial class InputResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InputResource() { }
        public virtual Azure.ResourceManager.StreamAnalytics.InputData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string jobName, string inputName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.InputResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.InputResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.ResourceTestStatus> Test(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.InputData input = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.ResourceTestStatus>> TestAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.InputData input = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.InputResource> Update(Azure.ResourceManager.StreamAnalytics.InputData input, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.InputResource>> UpdateAsync(Azure.ResourceManager.StreamAnalytics.InputData input, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OutputCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.OutputResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.OutputResource>, System.Collections.IEnumerable
    {
        protected OutputCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.OutputResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string outputName, Azure.ResourceManager.StreamAnalytics.OutputData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.OutputResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string outputName, Azure.ResourceManager.StreamAnalytics.OutputData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string outputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string outputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.OutputResource> Get(string outputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StreamAnalytics.OutputResource> GetAll(string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.OutputResource> GetAllAsync(string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.OutputResource>> GetAsync(string outputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StreamAnalytics.OutputResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.OutputResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StreamAnalytics.OutputResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.OutputResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OutputData : Azure.ResourceManager.StreamAnalytics.Models.SubResource
    {
        public OutputData() { }
        public Azure.ResourceManager.StreamAnalytics.Models.OutputDataSource Datasource { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StreamAnalytics.Models.DiagnosticCondition> DiagnosticsConditions { get { throw null; } }
        public Azure.ETag? Etag { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StreamAnalytics.Models.LastOutputEventTimestamp> LastOutputEventTimestamps { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.Serialization Serialization { get { throw null; } set { } }
        public float? SizeWindow { get { throw null; } set { } }
        public string TimeWindow { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.OutputWatermarkProperties WatermarkSettings { get { throw null; } set { } }
    }
    public partial class OutputResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OutputResource() { }
        public virtual Azure.ResourceManager.StreamAnalytics.OutputData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string jobName, string outputName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.OutputResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.OutputResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.ResourceTestStatus> Test(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.OutputData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.ResourceTestStatus>> TestAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.OutputData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.OutputResource> Update(Azure.ResourceManager.StreamAnalytics.OutputData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.OutputResource>> UpdateAsync(Azure.ResourceManager.StreamAnalytics.OutputData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.PrivateEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.PrivateEndpointResource>, System.Collections.IEnumerable
    {
        protected PrivateEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.PrivateEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointName, Azure.ResourceManager.StreamAnalytics.PrivateEndpointData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.PrivateEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointName, Azure.ResourceManager.StreamAnalytics.PrivateEndpointData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.PrivateEndpointResource> Get(string privateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StreamAnalytics.PrivateEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.PrivateEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.PrivateEndpointResource>> GetAsync(string privateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StreamAnalytics.PrivateEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.PrivateEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StreamAnalytics.PrivateEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.PrivateEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointData : Azure.ResourceManager.Models.ResourceData
    {
        public PrivateEndpointData() { }
        public Azure.ETag? Etag { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.PrivateEndpointProperties Properties { get { throw null; } set { } }
    }
    public partial class PrivateEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointResource() { }
        public virtual Azure.ResourceManager.StreamAnalytics.PrivateEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string privateEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.PrivateEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.PrivateEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.PrivateEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.PrivateEndpointData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.PrivateEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.PrivateEndpointData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class StreamAnalyticsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.StreamAnalytics.Models.QueryCompilationResult> CompileQuerySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.CompileQuery compileQuery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.Models.QueryCompilationResult>> CompileQuerySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.CompileQuery compileQuery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.StreamAnalytics.ClusterResource> GetCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.ClusterResource>> GetClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.ClusterResource GetClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.ClusterCollection GetClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StreamAnalytics.ClusterResource> GetClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.ClusterResource> GetClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.FunctionResource GetFunctionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.InputResource GetInputResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.OutputResource GetOutputResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.PrivateEndpointResource GetPrivateEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StreamAnalytics.Models.SubscriptionQuota> GetQuotasSubscriptions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.Models.SubscriptionQuota> GetQuotasSubscriptionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> GetStreamingJob(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobResource>> GetStreamingJobAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.StreamingJobResource GetStreamingJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.StreamingJobCollection GetStreamingJobs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> GetStreamingJobs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> GetStreamingJobsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.TransformationResource GetTransformationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.SampleInputResult> SampleInputSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.SampleContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.SampleInputResult>> SampleInputSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.SampleContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.TestDatasourceResult> TestInputSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.TestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.TestDatasourceResult>> TestInputSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.TestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.TestDatasourceResult> TestOutputSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.TestOutput testOutput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.TestDatasourceResult>> TestOutputSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.TestOutput testOutput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.QueryTestingResult> TestQuerySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.TestQuery testQuery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.QueryTestingResult>> TestQuerySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.TestQuery testQuery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StreamingJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobResource>, System.Collections.IEnumerable
    {
        protected StreamingJobCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.StreamAnalytics.StreamingJobData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.StreamingJobResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.StreamAnalytics.StreamingJobData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> Get(string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobResource>> GetAsync(string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StreamingJobData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public StreamingJobData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.Core.ResourceIdentifier ClusterId { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.CompatibilityLevel? CompatibilityLevel { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.ContentStoragePolicy? ContentStoragePolicy { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DataLocale { get { throw null; } set { } }
        public Azure.ETag? Etag { get { throw null; } }
        public int? EventsLateArrivalMaxDelayInSeconds { get { throw null; } set { } }
        public int? EventsOutOfOrderMaxDelayInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.EventsOutOfOrderPolicy? EventsOutOfOrderPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.External Externals { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.FunctionData> Functions { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.Identity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.InputData> Inputs { get { throw null; } }
        public string JobId { get { throw null; } }
        public string JobState { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.JobStorageAccount JobStorageAccount { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.JobType? JobType { get { throw null; } set { } }
        public System.DateTimeOffset? LastOutputEventOn { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.OutputErrorPolicy? OutputErrorPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.OutputData> Outputs { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.OutputStartMode? OutputStartMode { get { throw null; } set { } }
        public System.DateTimeOffset? OutputStartOn { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSkuName? SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.TransformationData Transformation { get { throw null; } set { } }
    }
    public partial class StreamingJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StreamingJobResource() { }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamingJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string jobName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.FunctionResource> GetFunction(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.FunctionResource>> GetFunctionAsync(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StreamAnalytics.FunctionCollection GetFunctions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.InputResource> GetInput(string inputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.InputResource>> GetInputAsync(string inputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StreamAnalytics.InputCollection GetInputs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.OutputResource> GetOutput(string outputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.OutputResource>> GetOutputAsync(string outputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StreamAnalytics.OutputCollection GetOutputs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.TransformationResource> GetTransformation(string transformationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.TransformationResource>> GetTransformationAsync(string transformationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StreamAnalytics.TransformationCollection GetTransformations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Scale(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.Models.ScaleStreamingJobContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ScaleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.Models.ScaleStreamingJobContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.Models.StartStreamingJobContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.Models.StartStreamingJobContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> Update(Azure.ResourceManager.StreamAnalytics.StreamingJobData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobResource>> UpdateAsync(Azure.ResourceManager.StreamAnalytics.StreamingJobData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TransformationCollection : Azure.ResourceManager.ArmCollection
    {
        protected TransformationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.TransformationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string transformationName, Azure.ResourceManager.StreamAnalytics.TransformationData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.TransformationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string transformationName, Azure.ResourceManager.StreamAnalytics.TransformationData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string transformationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string transformationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.TransformationResource> Get(string transformationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.TransformationResource>> GetAsync(string transformationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TransformationData : Azure.ResourceManager.StreamAnalytics.Models.SubResource
    {
        public TransformationData() { }
        public Azure.ETag? Etag { get { throw null; } }
        public string Query { get { throw null; } set { } }
        public int? StreamingUnits { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> ValidStreamingUnits { get { throw null; } }
    }
    public partial class TransformationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TransformationResource() { }
        public virtual Azure.ResourceManager.StreamAnalytics.TransformationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string jobName, string transformationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.TransformationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.TransformationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.TransformationResource> Update(Azure.ResourceManager.StreamAnalytics.TransformationData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.TransformationResource>> UpdateAsync(Azure.ResourceManager.StreamAnalytics.TransformationData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StreamAnalytics.Models
{
    public partial class AggregateFunctionProperties : Azure.ResourceManager.StreamAnalytics.Models.FunctionProperties
    {
        public AggregateFunctionProperties() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthenticationMode : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthenticationMode(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode ConnectionString { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode Msi { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode UserToken { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode left, Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode left, Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvroSerialization : Azure.ResourceManager.StreamAnalytics.Models.Serialization
    {
        public AvroSerialization() { }
        public System.BinaryData Properties { get { throw null; } set { } }
    }
    public partial class AzureDataLakeStoreOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.OutputDataSource
    {
        public AzureDataLakeStoreOutputDataSource() { }
        public string AccountName { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string DateFormat { get { throw null; } set { } }
        public string FilePathPrefix { get { throw null; } set { } }
        public string RefreshToken { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public string TimeFormat { get { throw null; } set { } }
        public string TokenUserDisplayName { get { throw null; } set { } }
        public string TokenUserPrincipalName { get { throw null; } set { } }
    }
    public partial class AzureFunctionOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.OutputDataSource
    {
        public AzureFunctionOutputDataSource() { }
        public string ApiKey { get { throw null; } set { } }
        public string FunctionAppName { get { throw null; } set { } }
        public string FunctionName { get { throw null; } set { } }
        public float? MaxBatchCount { get { throw null; } set { } }
        public float? MaxBatchSize { get { throw null; } set { } }
    }
    public partial class AzureMachineLearningServiceFunctionBinding : Azure.ResourceManager.StreamAnalytics.Models.FunctionBinding
    {
        public AzureMachineLearningServiceFunctionBinding() { }
        public string ApiKey { get { throw null; } set { } }
        public int? BatchSize { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string InputRequestName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.AzureMachineLearningServiceInputColumn> Inputs { get { throw null; } }
        public int? NumberOfParallelRequests { get { throw null; } set { } }
        public string OutputResponseName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.AzureMachineLearningServiceOutputColumn> Outputs { get { throw null; } }
    }
    public partial class AzureMachineLearningServiceInputColumn
    {
        public AzureMachineLearningServiceInputColumn() { }
        public string DataType { get { throw null; } set { } }
        public int? MapTo { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class AzureMachineLearningServiceOutputColumn
    {
        public AzureMachineLearningServiceOutputColumn() { }
        public string DataType { get { throw null; } set { } }
        public int? MapTo { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class AzureMachineLearningStudioFunctionBinding : Azure.ResourceManager.StreamAnalytics.Models.FunctionBinding
    {
        public AzureMachineLearningStudioFunctionBinding() { }
        public string ApiKey { get { throw null; } set { } }
        public int? BatchSize { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.AzureMachineLearningStudioInputs Inputs { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.AzureMachineLearningStudioOutputColumn> Outputs { get { throw null; } }
    }
    public partial class AzureMachineLearningStudioInputColumn
    {
        public AzureMachineLearningStudioInputColumn() { }
        public string DataType { get { throw null; } set { } }
        public int? MapTo { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class AzureMachineLearningStudioInputs
    {
        public AzureMachineLearningStudioInputs() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.AzureMachineLearningStudioInputColumn> ColumnNames { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class AzureMachineLearningStudioOutputColumn
    {
        public AzureMachineLearningStudioOutputColumn() { }
        public string DataType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class AzureSqlDatabaseOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.OutputDataSource
    {
        public AzureSqlDatabaseOutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string Database { get { throw null; } set { } }
        public float? MaxBatchCount { get { throw null; } set { } }
        public float? MaxWriterCount { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
    }
    public partial class AzureSqlReferenceInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource
    {
        public AzureSqlReferenceInputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string Database { get { throw null; } set { } }
        public string DeltaSnapshotQuery { get { throw null; } set { } }
        public string FullSnapshotQuery { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string RefreshRate { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.RefreshType? RefreshType { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
    }
    public partial class AzureSynapseOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.OutputDataSource
    {
        public AzureSynapseOutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string Database { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
    }
    public partial class AzureTableOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.OutputDataSource
    {
        public AzureTableOutputDataSource() { }
        public string AccountKey { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public int? BatchSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ColumnsToRemove { get { throw null; } }
        public string PartitionKey { get { throw null; } set { } }
        public string RowKey { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
    }
    public partial class BlobOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.OutputDataSource
    {
        public BlobOutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string BlobPathPrefix { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.BlobWriteMode? BlobWriteMode { get { throw null; } set { } }
        public string Container { get { throw null; } set { } }
        public string DateFormat { get { throw null; } set { } }
        public string PathPattern { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.StorageAccount> StorageAccounts { get { throw null; } }
        public string TimeFormat { get { throw null; } set { } }
    }
    public partial class BlobReferenceInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource
    {
        public BlobReferenceInputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string BlobName { get { throw null; } set { } }
        public string Container { get { throw null; } set { } }
        public string DateFormat { get { throw null; } set { } }
        public string DeltaPathPattern { get { throw null; } set { } }
        public string DeltaSnapshotRefreshRate { get { throw null; } set { } }
        public string FullSnapshotRefreshRate { get { throw null; } set { } }
        public string PathPattern { get { throw null; } set { } }
        public int? SourcePartitionCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.StorageAccount> StorageAccounts { get { throw null; } }
        public string TimeFormat { get { throw null; } set { } }
    }
    public partial class BlobStreamInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource
    {
        public BlobStreamInputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string Container { get { throw null; } set { } }
        public string DateFormat { get { throw null; } set { } }
        public string PathPattern { get { throw null; } set { } }
        public int? SourcePartitionCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.StorageAccount> StorageAccounts { get { throw null; } }
        public string TimeFormat { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobWriteMode : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.BlobWriteMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobWriteMode(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.BlobWriteMode Append { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.BlobWriteMode Once { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.BlobWriteMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.BlobWriteMode left, Azure.ResourceManager.StreamAnalytics.Models.BlobWriteMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.BlobWriteMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.BlobWriteMode left, Azure.ResourceManager.StreamAnalytics.Models.BlobWriteMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterJob
    {
        internal ClusterJob() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.JobState? JobState { get { throw null; } }
        public int? StreamingUnits { get { throw null; } }
    }
    public partial class ClusterProperties
    {
        public ClusterProperties() { }
        public int? CapacityAllocated { get { throw null; } }
        public int? CapacityAssigned { get { throw null; } }
        public string ClusterId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.ClusterProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterProvisioningState : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.ClusterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.ClusterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.ClusterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.ClusterProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.ClusterProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.ClusterProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.ClusterProvisioningState left, Azure.ResourceManager.StreamAnalytics.Models.ClusterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.ClusterProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.ClusterProvisioningState left, Azure.ResourceManager.StreamAnalytics.Models.ClusterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterSku
    {
        public ClusterSku() { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.ClusterSkuName? Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterSkuName : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.ClusterSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterSkuName(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.ClusterSkuName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.ClusterSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.ClusterSkuName left, Azure.ResourceManager.StreamAnalytics.Models.ClusterSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.ClusterSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.ClusterSkuName left, Azure.ResourceManager.StreamAnalytics.Models.ClusterSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CompatibilityLevel : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.CompatibilityLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CompatibilityLevel(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.CompatibilityLevel One0 { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.CompatibilityLevel One2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.CompatibilityLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.CompatibilityLevel left, Azure.ResourceManager.StreamAnalytics.Models.CompatibilityLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.CompatibilityLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.CompatibilityLevel left, Azure.ResourceManager.StreamAnalytics.Models.CompatibilityLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CompileQuery
    {
        public CompileQuery(string query, Azure.ResourceManager.StreamAnalytics.Models.JobType jobType) { }
        public Azure.ResourceManager.StreamAnalytics.Models.CompatibilityLevel? CompatibilityLevel { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.QueryFunction> Functions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.QueryInput> Inputs { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.JobType JobType { get { throw null; } }
        public string Query { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CompressionType : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.CompressionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CompressionType(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.CompressionType Deflate { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.CompressionType GZip { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.CompressionType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.CompressionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.CompressionType left, Azure.ResourceManager.StreamAnalytics.Models.CompressionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.CompressionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.CompressionType left, Azure.ResourceManager.StreamAnalytics.Models.CompressionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentStoragePolicy : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.ContentStoragePolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentStoragePolicy(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.ContentStoragePolicy JobStorageAccount { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.ContentStoragePolicy SystemAccount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.ContentStoragePolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.ContentStoragePolicy left, Azure.ResourceManager.StreamAnalytics.Models.ContentStoragePolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.ContentStoragePolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.ContentStoragePolicy left, Azure.ResourceManager.StreamAnalytics.Models.ContentStoragePolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CSharpFunctionBinding : Azure.ResourceManager.StreamAnalytics.Models.FunctionBinding
    {
        public CSharpFunctionBinding() { }
        public string Class { get { throw null; } set { } }
        public string DllPath { get { throw null; } set { } }
        public string Method { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.UpdateMode? UpdateMode { get { throw null; } set { } }
    }
    public partial class CsvSerialization : Azure.ResourceManager.StreamAnalytics.Models.Serialization
    {
        public CsvSerialization() { }
        public Azure.ResourceManager.StreamAnalytics.Models.Encoding? Encoding { get { throw null; } set { } }
        public string FieldDelimiter { get { throw null; } set { } }
    }
    public partial class CustomClrSerialization : Azure.ResourceManager.StreamAnalytics.Models.Serialization
    {
        public CustomClrSerialization() { }
        public string SerializationClassName { get { throw null; } set { } }
        public string SerializationDllPath { get { throw null; } set { } }
    }
    public partial class DiagnosticCondition
    {
        internal DiagnosticCondition() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Since { get { throw null; } }
    }
    public partial class DocumentDbOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.OutputDataSource
    {
        public DocumentDbOutputDataSource() { }
        public string AccountId { get { throw null; } set { } }
        public string AccountKey { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string CollectionNamePattern { get { throw null; } set { } }
        public string Database { get { throw null; } set { } }
        public string DocumentId { get { throw null; } set { } }
        public string PartitionKey { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Encoding : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.Encoding>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Encoding(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.Encoding UTF8 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.Encoding other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.Encoding left, Azure.ResourceManager.StreamAnalytics.Models.Encoding right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.Encoding (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.Encoding left, Azure.ResourceManager.StreamAnalytics.Models.Encoding right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Error
    {
        internal Error() { }
        public Azure.ResourceManager.StreamAnalytics.Models.ErrorError ErrorValue { get { throw null; } }
    }
    public partial class ErrorDetails
    {
        internal ErrorDetails() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class ErrorError
    {
        internal ErrorError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StreamAnalytics.Models.ErrorDetails> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class ErrorResponse
    {
        internal ErrorResponse() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridEventSchemaType : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.EventGridEventSchemaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridEventSchemaType(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.EventGridEventSchemaType CloudEventSchema { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.EventGridEventSchemaType EventGridEventSchema { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.EventGridEventSchemaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.EventGridEventSchemaType left, Azure.ResourceManager.StreamAnalytics.Models.EventGridEventSchemaType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.EventGridEventSchemaType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.EventGridEventSchemaType left, Azure.ResourceManager.StreamAnalytics.Models.EventGridEventSchemaType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventGridStreamInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource
    {
        public EventGridStreamInputDataSource() { }
        public System.Collections.Generic.IList<string> EventTypes { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.EventGridEventSchemaType? Schema { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.StorageAccount> StorageAccounts { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.EventHubV2StreamInputDataSource Subscriber { get { throw null; } set { } }
    }
    public partial class EventHubOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.OutputDataSource
    {
        public EventHubOutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string EventHubName { get { throw null; } set { } }
        public int? PartitionCount { get { throw null; } set { } }
        public string PartitionKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PropertyColumns { get { throw null; } }
        public string ServiceBusNamespace { get { throw null; } set { } }
        public string SharedAccessPolicyKey { get { throw null; } set { } }
        public string SharedAccessPolicyName { get { throw null; } set { } }
    }
    public partial class EventHubStreamInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource
    {
        public EventHubStreamInputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string ConsumerGroupName { get { throw null; } set { } }
        public string EventHubName { get { throw null; } set { } }
        public int? PartitionCount { get { throw null; } set { } }
        public int? PrefetchCount { get { throw null; } set { } }
        public string ServiceBusNamespace { get { throw null; } set { } }
        public string SharedAccessPolicyKey { get { throw null; } set { } }
        public string SharedAccessPolicyName { get { throw null; } set { } }
    }
    public partial class EventHubV2OutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.OutputDataSource
    {
        public EventHubV2OutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string EventHubName { get { throw null; } set { } }
        public int? PartitionCount { get { throw null; } set { } }
        public string PartitionKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PropertyColumns { get { throw null; } }
        public string ServiceBusNamespace { get { throw null; } set { } }
        public string SharedAccessPolicyKey { get { throw null; } set { } }
        public string SharedAccessPolicyName { get { throw null; } set { } }
    }
    public partial class EventHubV2StreamInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource
    {
        public EventHubV2StreamInputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string ConsumerGroupName { get { throw null; } set { } }
        public string EventHubName { get { throw null; } set { } }
        public int? PartitionCount { get { throw null; } set { } }
        public int? PrefetchCount { get { throw null; } set { } }
        public string ServiceBusNamespace { get { throw null; } set { } }
        public string SharedAccessPolicyKey { get { throw null; } set { } }
        public string SharedAccessPolicyName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventsOutOfOrderPolicy : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.EventsOutOfOrderPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventsOutOfOrderPolicy(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.EventsOutOfOrderPolicy Adjust { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.EventsOutOfOrderPolicy Drop { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.EventsOutOfOrderPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.EventsOutOfOrderPolicy left, Azure.ResourceManager.StreamAnalytics.Models.EventsOutOfOrderPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.EventsOutOfOrderPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.EventsOutOfOrderPolicy left, Azure.ResourceManager.StreamAnalytics.Models.EventsOutOfOrderPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class External
    {
        public External() { }
        public string Container { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.RefreshConfiguration RefreshConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StorageAccount StorageAccount { get { throw null; } set { } }
    }
    public partial class FunctionBinding
    {
        public FunctionBinding() { }
    }
    public partial class FunctionInput
    {
        public FunctionInput() { }
        public string DataType { get { throw null; } set { } }
        public bool? IsConfigurationParameter { get { throw null; } set { } }
    }
    public partial class FunctionOutput
    {
        public FunctionOutput() { }
        public string DataType { get { throw null; } set { } }
    }
    public partial class FunctionProperties
    {
        public FunctionProperties() { }
        public Azure.ResourceManager.StreamAnalytics.Models.FunctionBinding Binding { get { throw null; } set { } }
        public Azure.ETag? Etag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.FunctionInput> Inputs { get { throw null; } }
        public string OutputDataType { get { throw null; } set { } }
    }
    public partial class FunctionRetrieveDefaultDefinitionContent
    {
        public FunctionRetrieveDefaultDefinitionContent() { }
    }
    public partial class GatewayMessageBusOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.OutputDataSource
    {
        public GatewayMessageBusOutputDataSource() { }
        public string Topic { get { throw null; } set { } }
    }
    public partial class GatewayMessageBusStreamInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource
    {
        public GatewayMessageBusStreamInputDataSource() { }
        public string Topic { get { throw null; } set { } }
    }
    public partial class Identity
    {
        public Identity() { }
        public string IdentityType { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public System.BinaryData UserAssignedIdentities { get { throw null; } set { } }
    }
    public partial class InputProperties
    {
        public InputProperties() { }
        public Azure.ResourceManager.StreamAnalytics.Models.CompressionType? CompressionType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StreamAnalytics.Models.DiagnosticCondition> DiagnosticsConditions { get { throw null; } }
        public Azure.ETag? Etag { get { throw null; } }
        public string PartitionKey { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.Serialization Serialization { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.InputWatermarkMode? WatermarkMode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InputWatermarkMode : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.InputWatermarkMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InputWatermarkMode(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.InputWatermarkMode None { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.InputWatermarkMode ReadWatermark { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.InputWatermarkMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.InputWatermarkMode left, Azure.ResourceManager.StreamAnalytics.Models.InputWatermarkMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.InputWatermarkMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.InputWatermarkMode left, Azure.ResourceManager.StreamAnalytics.Models.InputWatermarkMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IoTHubStreamInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource
    {
        public IoTHubStreamInputDataSource() { }
        public string ConsumerGroupName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string IotHubNamespace { get { throw null; } set { } }
        public string SharedAccessPolicyKey { get { throw null; } set { } }
        public string SharedAccessPolicyName { get { throw null; } set { } }
    }
    public partial class JavaScriptFunctionBinding : Azure.ResourceManager.StreamAnalytics.Models.FunctionBinding
    {
        public JavaScriptFunctionBinding() { }
        public string Script { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobState : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.JobState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobState(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.JobState Created { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.JobState Degraded { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.JobState Deleting { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.JobState Failed { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.JobState Restarting { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.JobState Running { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.JobState Scaling { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.JobState Starting { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.JobState Stopped { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.JobState Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.JobState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.JobState left, Azure.ResourceManager.StreamAnalytics.Models.JobState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.JobState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.JobState left, Azure.ResourceManager.StreamAnalytics.Models.JobState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobStorageAccount : Azure.ResourceManager.StreamAnalytics.Models.StorageAccount
    {
        public JobStorageAccount() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobType : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.JobType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobType(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.JobType Cloud { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.JobType Edge { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.JobType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.JobType left, Azure.ResourceManager.StreamAnalytics.Models.JobType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.JobType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.JobType left, Azure.ResourceManager.StreamAnalytics.Models.JobType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JsonOutputSerializationFormat : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.JsonOutputSerializationFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JsonOutputSerializationFormat(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.JsonOutputSerializationFormat Array { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.JsonOutputSerializationFormat LineSeparated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.JsonOutputSerializationFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.JsonOutputSerializationFormat left, Azure.ResourceManager.StreamAnalytics.Models.JsonOutputSerializationFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.JsonOutputSerializationFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.JsonOutputSerializationFormat left, Azure.ResourceManager.StreamAnalytics.Models.JsonOutputSerializationFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JsonSerialization : Azure.ResourceManager.StreamAnalytics.Models.Serialization
    {
        public JsonSerialization() { }
        public Azure.ResourceManager.StreamAnalytics.Models.Encoding? Encoding { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.JsonOutputSerializationFormat? Format { get { throw null; } set { } }
    }
    public partial class LastOutputEventTimestamp
    {
        internal LastOutputEventTimestamp() { }
        public string LastOutputEventTime { get { throw null; } }
        public string LastUpdateTime { get { throw null; } }
    }
    public partial class OutputDataSource
    {
        public OutputDataSource() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OutputErrorPolicy : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.OutputErrorPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OutputErrorPolicy(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.OutputErrorPolicy Drop { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.OutputErrorPolicy Stop { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.OutputErrorPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.OutputErrorPolicy left, Azure.ResourceManager.StreamAnalytics.Models.OutputErrorPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.OutputErrorPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.OutputErrorPolicy left, Azure.ResourceManager.StreamAnalytics.Models.OutputErrorPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OutputStartMode : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.OutputStartMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OutputStartMode(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.OutputStartMode CustomTime { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.OutputStartMode JobStartTime { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.OutputStartMode LastOutputEventTime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.OutputStartMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.OutputStartMode left, Azure.ResourceManager.StreamAnalytics.Models.OutputStartMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.OutputStartMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.OutputStartMode left, Azure.ResourceManager.StreamAnalytics.Models.OutputStartMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OutputWatermarkMode : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.OutputWatermarkMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OutputWatermarkMode(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.OutputWatermarkMode None { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.OutputWatermarkMode SendCurrentPartitionWatermark { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.OutputWatermarkMode SendLowestWatermarkAcrossPartitions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.OutputWatermarkMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.OutputWatermarkMode left, Azure.ResourceManager.StreamAnalytics.Models.OutputWatermarkMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.OutputWatermarkMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.OutputWatermarkMode left, Azure.ResourceManager.StreamAnalytics.Models.OutputWatermarkMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OutputWatermarkProperties
    {
        public OutputWatermarkProperties() { }
        public string MaxWatermarkDifferenceAcrossPartitions { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.OutputWatermarkMode? WatermarkMode { get { throw null; } set { } }
    }
    public partial class ParquetSerialization : Azure.ResourceManager.StreamAnalytics.Models.Serialization
    {
        public ParquetSerialization() { }
        public System.BinaryData Properties { get { throw null; } set { } }
    }
    public partial class PostgreSQLOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.OutputDataSource
    {
        public PostgreSQLOutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string Database { get { throw null; } set { } }
        public float? MaxWriterCount { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
    }
    public partial class PowerBIOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.OutputDataSource
    {
        public PowerBIOutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string Dataset { get { throw null; } set { } }
        public string GroupId { get { throw null; } set { } }
        public string GroupName { get { throw null; } set { } }
        public string RefreshToken { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
        public string TokenUserDisplayName { get { throw null; } set { } }
        public string TokenUserPrincipalName { get { throw null; } set { } }
    }
    public partial class PrivateEndpointProperties
    {
        public PrivateEndpointProperties() { }
        public string CreatedDate { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.PrivateLinkServiceConnection> ManualPrivateLinkServiceConnections { get { throw null; } }
    }
    public partial class PrivateLinkConnectionState
    {
        public PrivateLinkConnectionState() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class PrivateLinkServiceConnection
    {
        public PrivateLinkServiceConnection() { }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.PrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public string PrivateLinkServiceId { get { throw null; } set { } }
        public string RequestMessage { get { throw null; } }
    }
    public partial class QueryCompilationError
    {
        internal QueryCompilationError() { }
        public int? EndColumn { get { throw null; } }
        public int? EndLine { get { throw null; } }
        public bool? IsGlobal { get { throw null; } }
        public string Message { get { throw null; } }
        public int? StartColumn { get { throw null; } }
        public int? StartLine { get { throw null; } }
    }
    public partial class QueryCompilationResult
    {
        internal QueryCompilationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StreamAnalytics.Models.QueryCompilationError> Errors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Functions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Inputs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Outputs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Warnings { get { throw null; } }
    }
    public partial class QueryFunction : Azure.ResourceManager.Models.ResourceData
    {
        public QueryFunction(string queryFunctionType, string bindingType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.FunctionInput> inputs, Azure.ResourceManager.StreamAnalytics.Models.FunctionOutput output) { }
        public string BindingType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.FunctionInput> Inputs { get { throw null; } }
        public string OutputDataType { get { throw null; } }
        public string QueryFunctionType { get { throw null; } }
    }
    public partial class QueryInput
    {
        public QueryInput(string name, string queryInputType) { }
        public string Name { get { throw null; } }
        public string QueryInputType { get { throw null; } }
    }
    public partial class QueryTestingResult : Azure.ResourceManager.StreamAnalytics.Models.Error
    {
        internal QueryTestingResult() { }
        public System.Uri OutputUri { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.QueryTestingResultStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryTestingResultStatus : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.QueryTestingResultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryTestingResultStatus(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.QueryTestingResultStatus CompilerError { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.QueryTestingResultStatus RuntimeError { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.QueryTestingResultStatus Started { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.QueryTestingResultStatus Success { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.QueryTestingResultStatus Timeout { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.QueryTestingResultStatus UnknownError { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.QueryTestingResultStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.QueryTestingResultStatus left, Azure.ResourceManager.StreamAnalytics.Models.QueryTestingResultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.QueryTestingResultStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.QueryTestingResultStatus left, Azure.ResourceManager.StreamAnalytics.Models.QueryTestingResultStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RawOutputDatasource : Azure.ResourceManager.StreamAnalytics.Models.OutputDataSource
    {
        public RawOutputDatasource() { }
        public System.Uri PayloadUri { get { throw null; } set { } }
    }
    public partial class RawReferenceInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource
    {
        public RawReferenceInputDataSource() { }
        public string Payload { get { throw null; } set { } }
        public System.Uri PayloadUri { get { throw null; } set { } }
    }
    public partial class RawStreamInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource
    {
        public RawStreamInputDataSource() { }
        public string Payload { get { throw null; } set { } }
        public System.Uri PayloadUri { get { throw null; } set { } }
    }
    public partial class ReferenceInputDataSource
    {
        public ReferenceInputDataSource() { }
    }
    public partial class ReferenceInputProperties : Azure.ResourceManager.StreamAnalytics.Models.InputProperties
    {
        public ReferenceInputProperties() { }
        public Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource Datasource { get { throw null; } set { } }
    }
    public partial class RefreshConfiguration
    {
        public RefreshConfiguration() { }
        public string DateFormat { get { throw null; } set { } }
        public string PathPattern { get { throw null; } set { } }
        public string RefreshInterval { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.RefreshType? RefreshType { get { throw null; } set { } }
        public string TimeFormat { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RefreshType : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.RefreshType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RefreshType(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.RefreshType Blocking { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.RefreshType Nonblocking { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.RefreshType RefreshPeriodicallyWithDelta { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.RefreshType RefreshPeriodicallyWithFull { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.RefreshType Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.RefreshType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.RefreshType left, Azure.ResourceManager.StreamAnalytics.Models.RefreshType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.RefreshType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.RefreshType left, Azure.ResourceManager.StreamAnalytics.Models.RefreshType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceTestStatus
    {
        internal ResourceTestStatus() { }
        public Azure.ResourceManager.StreamAnalytics.Models.ErrorResponse Error { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class SampleContent
    {
        public SampleContent() { }
        public string CompatibilityLevel { get { throw null; } set { } }
        public string DataLocale { get { throw null; } set { } }
        public System.Uri EventsUri { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.InputData Input { get { throw null; } set { } }
    }
    public partial class SampleInputResult : Azure.ResourceManager.StreamAnalytics.Models.Error
    {
        internal SampleInputResult() { }
        public System.Collections.Generic.IReadOnlyList<string> Diagnostics { get { throw null; } }
        public System.Uri EventsDownloadUri { get { throw null; } }
        public string LastArrivalTime { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.SampleInputResultStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SampleInputResultStatus : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.SampleInputResultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SampleInputResultStatus(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.SampleInputResultStatus ErrorConnectingToInput { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.SampleInputResultStatus NoEventsFoundInRange { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.SampleInputResultStatus ReadAllEventsInRange { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.SampleInputResultStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.SampleInputResultStatus left, Azure.ResourceManager.StreamAnalytics.Models.SampleInputResultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.SampleInputResultStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.SampleInputResultStatus left, Azure.ResourceManager.StreamAnalytics.Models.SampleInputResultStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScalarFunctionProperties : Azure.ResourceManager.StreamAnalytics.Models.FunctionProperties
    {
        public ScalarFunctionProperties() { }
    }
    public partial class ScaleStreamingJobContent
    {
        public ScaleStreamingJobContent() { }
        public int? StreamingUnits { get { throw null; } set { } }
    }
    public partial class Serialization
    {
        public Serialization() { }
    }
    public partial class ServiceBusQueueOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.OutputDataSource
    {
        public ServiceBusQueueOutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PropertyColumns { get { throw null; } }
        public string QueueName { get { throw null; } set { } }
        public string ServiceBusNamespace { get { throw null; } set { } }
        public string SharedAccessPolicyKey { get { throw null; } set { } }
        public string SharedAccessPolicyName { get { throw null; } set { } }
        public System.BinaryData SystemPropertyColumns { get { throw null; } set { } }
    }
    public partial class ServiceBusTopicOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.OutputDataSource
    {
        public ServiceBusTopicOutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PropertyColumns { get { throw null; } }
        public string ServiceBusNamespace { get { throw null; } set { } }
        public string SharedAccessPolicyKey { get { throw null; } set { } }
        public string SharedAccessPolicyName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SystemPropertyColumns { get { throw null; } }
        public string TopicName { get { throw null; } set { } }
    }
    public partial class StartStreamingJobContent
    {
        public StartStreamingJobContent() { }
        public Azure.ResourceManager.StreamAnalytics.Models.OutputStartMode? OutputStartMode { get { throw null; } set { } }
        public System.DateTimeOffset? OutputStartOn { get { throw null; } set { } }
    }
    public partial class StorageAccount
    {
        public StorageAccount() { }
        public string AccountKey { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.AuthenticationMode? AuthenticationMode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamAnalyticsSkuName : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamAnalyticsSkuName(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSkuName left, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSkuName left, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StreamInputDataSource
    {
        public StreamInputDataSource() { }
    }
    public partial class StreamInputProperties : Azure.ResourceManager.StreamAnalytics.Models.InputProperties
    {
        public StreamInputProperties() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource Datasource { get { throw null; } set { } }
    }
    public partial class SubResource
    {
        public SubResource() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } }
    }
    public partial class SubscriptionQuota : Azure.ResourceManager.StreamAnalytics.Models.SubResource
    {
        public SubscriptionQuota() { }
        public int? CurrentCount { get { throw null; } }
        public int? MaxCount { get { throw null; } }
    }
    public partial class TestContent
    {
        public TestContent(Azure.ResourceManager.StreamAnalytics.InputData input) { }
        public Azure.ResourceManager.StreamAnalytics.InputData Input { get { throw null; } }
    }
    public partial class TestDatasourceResult : Azure.ResourceManager.StreamAnalytics.Models.Error
    {
        internal TestDatasourceResult() { }
        public Azure.ResourceManager.StreamAnalytics.Models.TestDatasourceResultStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TestDatasourceResultStatus : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.TestDatasourceResultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TestDatasourceResultStatus(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.TestDatasourceResultStatus TestFailed { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.TestDatasourceResultStatus TestSucceeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.TestDatasourceResultStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.TestDatasourceResultStatus left, Azure.ResourceManager.StreamAnalytics.Models.TestDatasourceResultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.TestDatasourceResultStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.TestDatasourceResultStatus left, Azure.ResourceManager.StreamAnalytics.Models.TestDatasourceResultStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TestOutput
    {
        public TestOutput(Azure.ResourceManager.StreamAnalytics.OutputData output) { }
        public Azure.ResourceManager.StreamAnalytics.OutputData Output { get { throw null; } }
    }
    public partial class TestQuery
    {
        public TestQuery(Azure.ResourceManager.StreamAnalytics.StreamingJobData streamingJob) { }
        public Azure.ResourceManager.StreamAnalytics.Models.TestQueryDiagnostics Diagnostics { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.StreamingJobData StreamingJob { get { throw null; } }
    }
    public partial class TestQueryDiagnostics
    {
        public TestQueryDiagnostics(System.Uri writeUri) { }
        public string Path { get { throw null; } set { } }
        public System.Uri WriteUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateMode : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.UpdateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateMode(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.UpdateMode Refreshable { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.UpdateMode Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.UpdateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.UpdateMode left, Azure.ResourceManager.StreamAnalytics.Models.UpdateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.UpdateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.UpdateMode left, Azure.ResourceManager.StreamAnalytics.Models.UpdateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
}
