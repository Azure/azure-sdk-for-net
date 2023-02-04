namespace Azure.ResourceManager.StreamAnalytics
{
    public partial class StreamAnalyticsClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource>, System.Collections.IEnumerable
    {
        protected StreamAnalyticsClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StreamAnalyticsClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public StreamAnalyticsClusterData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSku Sku { get { throw null; } set { } }
    }
    public partial class StreamAnalyticsClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StreamAnalyticsClusterResource() { }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource> GetStreamAnalyticsPrivateEndpoint(string privateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource>> GetStreamAnalyticsPrivateEndpointAsync(string privateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointCollection GetStreamAnalyticsPrivateEndpoints() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterJob> GetStreamingJobs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterJob> GetStreamingJobsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class StreamAnalyticsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationResult> CompileQuerySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsCompileQuery compileQuery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationResult>> CompileQuerySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsCompileQuery compileQuery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubscriptionQuota> GetQuotasSubscriptions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubscriptionQuota> GetQuotasSubscriptionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource> GetStreamAnalyticsCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource>> GetStreamAnalyticsClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource GetStreamAnalyticsClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterCollection GetStreamAnalyticsClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource> GetStreamAnalyticsClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource> GetStreamAnalyticsClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource GetStreamAnalyticsPrivateEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> GetStreamingJob(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobResource>> GetStreamingJobAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource GetStreamingJobFunctionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource GetStreamingJobInputResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource GetStreamingJobOutputResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.StreamingJobResource GetStreamingJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.StreamingJobCollection GetStreamingJobs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> GetStreamingJobs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> GetStreamingJobsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationResource GetStreamingJobTransformationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResult> SampleInputSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResult>> SampleInputSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResult> TestInputSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResult>> TestInputSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResult> TestOutputSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestOutput testOutput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResult>> TestOutputSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestOutput testOutput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResult> TestQuerySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestQuery testQuery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResult>> TestQuerySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestQuery testQuery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StreamAnalyticsPrivateEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource>, System.Collections.IEnumerable
    {
        protected StreamAnalyticsPrivateEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointName, Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointName, Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource> Get(string privateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource>> GetAsync(string privateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StreamAnalyticsPrivateEndpointData : Azure.ResourceManager.Models.ResourceData
    {
        public StreamAnalyticsPrivateEndpointData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateEndpointProperties Properties { get { throw null; } set { } }
    }
    public partial class StreamAnalyticsPrivateEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StreamAnalyticsPrivateEndpointResource() { }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string privateEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobCompatibilityLevel? CompatibilityLevel { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobContentStoragePolicy? ContentStoragePolicy { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.AzureLocation? DataLocalion { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public int? EventsLateArrivalMaxDelayInSeconds { get { throw null; } set { } }
        public int? EventsOutOfOrderMaxDelayInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.EventsOutOfOrderPolicy? EventsOutOfOrderPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobExternal Externals { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData> Functions { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.StreamingJobInputData> Inputs { get { throw null; } }
        public System.Guid? JobId { get { throw null; } }
        public string JobState { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobStorageAccount JobStorageAccount { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobType? JobType { get { throw null; } set { } }
        public System.DateTimeOffset? LastOutputEventOn { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputErrorPolicy? OutputErrorPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData> Outputs { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputStartMode? OutputStartMode { get { throw null; } set { } }
        public System.DateTimeOffset? OutputStartOn { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSkuName? SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData Transformation { get { throw null; } set { } }
    }
    public partial class StreamingJobFunctionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource>, System.Collections.IEnumerable
    {
        protected StreamingJobFunctionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string functionName, Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string functionName, Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource> Get(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource> GetAll(string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource> GetAllAsync(string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource>> GetAsync(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StreamingJobFunctionData : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubResource
    {
        public StreamingJobFunctionData() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionProperties Properties { get { throw null; } set { } }
    }
    public partial class StreamingJobFunctionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StreamingJobFunctionResource() { }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string jobName, string functionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource> RetrieveDefaultDefinition(Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource>> RetrieveDefaultDefinitionAsync(Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsResourceTestStatus> Test(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsResourceTestStatus>> TestAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource> Update(Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource>> UpdateAsync(Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StreamingJobInputCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource>, System.Collections.IEnumerable
    {
        protected StreamingJobInputCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string inputName, Azure.ResourceManager.StreamAnalytics.StreamingJobInputData input, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string inputName, Azure.ResourceManager.StreamAnalytics.StreamingJobInputData input, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string inputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string inputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource> Get(string inputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource> GetAll(string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource> GetAllAsync(string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource>> GetAsync(string inputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StreamingJobInputData : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubResource
    {
        public StreamingJobInputData() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputProperties Properties { get { throw null; } set { } }
    }
    public partial class StreamingJobInputResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StreamingJobInputResource() { }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamingJobInputData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string jobName, string inputName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsResourceTestStatus> Test(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.StreamingJobInputData input = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsResourceTestStatus>> TestAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.StreamingJobInputData input = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource> Update(Azure.ResourceManager.StreamAnalytics.StreamingJobInputData input, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource>> UpdateAsync(Azure.ResourceManager.StreamAnalytics.StreamingJobInputData input, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StreamingJobOutputCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource>, System.Collections.IEnumerable
    {
        protected StreamingJobOutputCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string outputName, Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string outputName, Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string outputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string outputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource> Get(string outputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource> GetAll(string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource> GetAllAsync(string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource>> GetAsync(string outputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StreamingJobOutputData : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubResource
    {
        public StreamingJobOutputData() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource Datasource { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobDiagnosticCondition> DiagnosticsConditions { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StreamAnalytics.Models.LastOutputEventTimestamp> LastOutputEventTimestamps { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization Serialization { get { throw null; } set { } }
        public float? SizeWindow { get { throw null; } set { } }
        public System.TimeSpan? TimeFrame { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please use TimeFrame instead.", false)]
        public System.DateTimeOffset? TimeWindow { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkProperties WatermarkSettings { get { throw null; } set { } }
    }
    public partial class StreamingJobOutputResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StreamingJobOutputResource() { }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string jobName, string outputName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsResourceTestStatus> Test(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsResourceTestStatus>> TestAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource> Update(Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource>> UpdateAsync(Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource> GetStreamingJobFunction(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource>> GetStreamingJobFunctionAsync(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionCollection GetStreamingJobFunctions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource> GetStreamingJobInput(string inputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource>> GetStreamingJobInputAsync(string inputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamingJobInputCollection GetStreamingJobInputs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource> GetStreamingJobOutput(string outputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource>> GetStreamingJobOutputAsync(string outputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamingJobOutputCollection GetStreamingJobOutputs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationResource> GetStreamingJobTransformation(string transformationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationResource>> GetStreamingJobTransformationAsync(string transformationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationCollection GetStreamingJobTransformations() { throw null; }
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
    public partial class StreamingJobTransformationCollection : Azure.ResourceManager.ArmCollection
    {
        protected StreamingJobTransformationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string transformationName, Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string transformationName, Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string transformationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string transformationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationResource> Get(string transformationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationResource>> GetAsync(string transformationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StreamingJobTransformationData : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubResource
    {
        public StreamingJobTransformationData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Query { get { throw null; } set { } }
        public int? StreamingUnits { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> ValidStreamingUnits { get { throw null; } }
    }
    public partial class StreamingJobTransformationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StreamingJobTransformationResource() { }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string jobName, string transformationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationResource> Update(Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationResource>> UpdateAsync(Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StreamAnalytics.Models
{
    public partial class AggregateFunctionProperties : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionProperties
    {
        public AggregateFunctionProperties() { }
    }
    public partial class AvroFormatSerialization : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization
    {
        public AvroFormatSerialization() { }
        public System.BinaryData Properties { get { throw null; } set { } }
    }
    public partial class BlobOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource
    {
        public BlobOutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string BlobPathPrefix { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.BlobOutputWriteMode? BlobWriteMode { get { throw null; } set { } }
        public string Container { get { throw null; } set { } }
        public string DateFormat { get { throw null; } set { } }
        public string PathPattern { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsStorageAccount> StorageAccounts { get { throw null; } }
        public string TimeFormat { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobOutputWriteMode : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.BlobOutputWriteMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobOutputWriteMode(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.BlobOutputWriteMode Append { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.BlobOutputWriteMode Once { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.BlobOutputWriteMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.BlobOutputWriteMode left, Azure.ResourceManager.StreamAnalytics.Models.BlobOutputWriteMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.BlobOutputWriteMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.BlobOutputWriteMode left, Azure.ResourceManager.StreamAnalytics.Models.BlobOutputWriteMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BlobReferenceInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource
    {
        public BlobReferenceInputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string BlobName { get { throw null; } set { } }
        public string Container { get { throw null; } set { } }
        public string DateFormat { get { throw null; } set { } }
        public string DeltaPathPattern { get { throw null; } set { } }
        public System.TimeSpan? DeltaSnapshotRefreshInterval { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please use DeltaSnapshotRefreshInterval instead.", false)]
        public string DeltaSnapshotRefreshRate { get { throw null; } set { } }
        public System.TimeSpan? FullSnapshotRefreshInterval { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please use FullSnapshotRefreshInterval instead.", false)]
        public string FullSnapshotRefreshRate { get { throw null; } set { } }
        public string PathPattern { get { throw null; } set { } }
        public int? SourcePartitionCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsStorageAccount> StorageAccounts { get { throw null; } }
        public string TimeFormat { get { throw null; } set { } }
    }
    public partial class BlobStreamInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource
    {
        public BlobStreamInputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string Container { get { throw null; } set { } }
        public string DateFormat { get { throw null; } set { } }
        public string PathPattern { get { throw null; } set { } }
        public int? SourcePartitionCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsStorageAccount> StorageAccounts { get { throw null; } }
        public string TimeFormat { get { throw null; } set { } }
    }
    public partial class CSharpFunctionBinding : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding
    {
        public CSharpFunctionBinding() { }
        public string Class { get { throw null; } set { } }
        public string DllPath { get { throw null; } set { } }
        public string Method { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUpdateMode? UpdateMode { get { throw null; } set { } }
    }
    public partial class CSharpFunctionRetrieveDefaultDefinitionContent : Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent
    {
        public CSharpFunctionRetrieveDefaultDefinitionContent() { }
        public string Script { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUdfType? UdfType { get { throw null; } set { } }
    }
    public partial class CsvFormatSerialization : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization
    {
        public CsvFormatSerialization() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerializationEncoding? Encoding { get { throw null; } set { } }
        public string FieldDelimiter { get { throw null; } set { } }
    }
    public partial class CustomClrFormatSerialization : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization
    {
        public CustomClrFormatSerialization() { }
        public string SerializationClassName { get { throw null; } set { } }
        public string SerializationDllPath { get { throw null; } set { } }
    }
    public partial class DataLakeStoreOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource
    {
        public DataLakeStoreOutputDataSource() { }
        public string AccountName { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string DateFormat { get { throw null; } set { } }
        public string FilePathPrefix { get { throw null; } set { } }
        public string RefreshToken { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public string TimeFormat { get { throw null; } set { } }
        public string TokenUserDisplayName { get { throw null; } set { } }
        public string TokenUserPrincipalName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataRefreshType : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.DataRefreshType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataRefreshType(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.DataRefreshType Blocking { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.DataRefreshType Nonblocking { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.DataRefreshType RefreshPeriodicallyWithDelta { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.DataRefreshType RefreshPeriodicallyWithFull { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.DataRefreshType Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.DataRefreshType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.DataRefreshType left, Azure.ResourceManager.StreamAnalytics.Models.DataRefreshType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.DataRefreshType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.DataRefreshType left, Azure.ResourceManager.StreamAnalytics.Models.DataRefreshType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentDbOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource
    {
        public DocumentDbOutputDataSource() { }
        public string AccountId { get { throw null; } set { } }
        public string AccountKey { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string CollectionNamePattern { get { throw null; } set { } }
        public string Database { get { throw null; } set { } }
        public string DocumentId { get { throw null; } set { } }
        public string PartitionKey { get { throw null; } set { } }
    }
    public partial class EMachineLearningStudioFunctionBinding : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding
    {
        public EMachineLearningStudioFunctionBinding() { }
        public string ApiKey { get { throw null; } set { } }
        public int? BatchSize { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputs Inputs { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioOutputColumn> Outputs { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsStorageAccount> StorageAccounts { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.EventHubV2StreamInputDataSource Subscriber { get { throw null; } set { } }
    }
    public partial class EventHubOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource
    {
        public EventHubOutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
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
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string ConsumerGroupName { get { throw null; } set { } }
        public string EventHubName { get { throw null; } set { } }
        public int? PartitionCount { get { throw null; } set { } }
        public int? PrefetchCount { get { throw null; } set { } }
        public string ServiceBusNamespace { get { throw null; } set { } }
        public string SharedAccessPolicyKey { get { throw null; } set { } }
        public string SharedAccessPolicyName { get { throw null; } set { } }
    }
    public partial class EventHubV2OutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource
    {
        public EventHubV2OutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
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
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
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
    public partial class FunctionOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource
    {
        public FunctionOutputDataSource() { }
        public string ApiKey { get { throw null; } set { } }
        public string FunctionAppName { get { throw null; } set { } }
        public string FunctionName { get { throw null; } set { } }
        public int? MaxBatchCount { get { throw null; } set { } }
        public int? MaxBatchSize { get { throw null; } set { } }
    }
    public abstract partial class FunctionRetrieveDefaultDefinitionContent
    {
        protected FunctionRetrieveDefaultDefinitionContent() { }
    }
    public partial class GatewayMessageBusOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource
    {
        public GatewayMessageBusOutputDataSource() { }
        public string Topic { get { throw null; } set { } }
    }
    public partial class GatewayMessageBusStreamInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource
    {
        public GatewayMessageBusStreamInputDataSource() { }
        public string Topic { get { throw null; } set { } }
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
    public partial class JavaScriptFunctionBinding : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding
    {
        public JavaScriptFunctionBinding() { }
        public string Script { get { throw null; } set { } }
    }
    public partial class JavaScriptFunctionRetrieveDefaultDefinitionContent : Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent
    {
        public JavaScriptFunctionRetrieveDefaultDefinitionContent() { }
        public string Script { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUdfType? UdfType { get { throw null; } set { } }
    }
    public partial class JsonFormatSerialization : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization
    {
        public JsonFormatSerialization() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerializationEncoding? Encoding { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.JsonOutputSerializationFormat? Format { get { throw null; } set { } }
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
    public partial class LastOutputEventTimestamp
    {
        internal LastOutputEventTimestamp() { }
        public System.DateTimeOffset? LastOutputEventOn { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
    }
    public partial class MachineLearningServiceFunctionBinding : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding
    {
        public MachineLearningServiceFunctionBinding() { }
        public string ApiKey { get { throw null; } set { } }
        public int? BatchSize { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string InputRequestName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceInputColumn> Inputs { get { throw null; } }
        public int? NumberOfParallelRequests { get { throw null; } set { } }
        public string OutputResponseName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceOutputColumn> Outputs { get { throw null; } }
    }
    public partial class MachineLearningServiceFunctionRetrieveDefaultDefinitionContent : Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent
    {
        public MachineLearningServiceFunctionRetrieveDefaultDefinitionContent() { }
        public string ExecuteEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUdfType? UdfType { get { throw null; } set { } }
    }
    public partial class MachineLearningServiceInputColumn
    {
        public MachineLearningServiceInputColumn() { }
        public string DataType { get { throw null; } set { } }
        public int? MapTo { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class MachineLearningServiceOutputColumn
    {
        public MachineLearningServiceOutputColumn() { }
        public string DataType { get { throw null; } set { } }
        public int? MapTo { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class MachineLearningStudioFunctionRetrieveDefaultDefinitionContent : Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent
    {
        public MachineLearningStudioFunctionRetrieveDefaultDefinitionContent() { }
        public string ExecuteEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUdfType? UdfType { get { throw null; } set { } }
    }
    public partial class MachineLearningStudioInputColumn
    {
        public MachineLearningStudioInputColumn() { }
        public string DataType { get { throw null; } set { } }
        public int? MapTo { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class MachineLearningStudioInputs
    {
        public MachineLearningStudioInputs() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputColumn> ColumnNames { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class MachineLearningStudioOutputColumn
    {
        public MachineLearningStudioOutputColumn() { }
        public string DataType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ParquetFormatSerialization : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization
    {
        public ParquetFormatSerialization() { }
        public System.BinaryData Properties { get { throw null; } set { } }
    }
    public partial class PostgreSQLOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource
    {
        public PostgreSQLOutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string Database { get { throw null; } set { } }
        public int? MaxWriterCount { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
    }
    public partial class PowerBIOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource
    {
        public PowerBIOutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string Dataset { get { throw null; } set { } }
        public System.Guid? GroupId { get { throw null; } set { } }
        public string GroupName { get { throw null; } set { } }
        public string RefreshToken { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
        public string TokenUserDisplayName { get { throw null; } set { } }
        public string TokenUserPrincipalName { get { throw null; } set { } }
    }
    public partial class RawOutputDatasource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource
    {
        public RawOutputDatasource() { }
        public System.Uri PayloadUri { get { throw null; } set { } }
    }
    public partial class RawReferenceInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource
    {
        public RawReferenceInputDataSource() { }
        public System.BinaryData Payload { get { throw null; } set { } }
        public System.Uri PayloadUri { get { throw null; } set { } }
    }
    public partial class RawStreamInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource
    {
        public RawStreamInputDataSource() { }
        public System.BinaryData Payload { get { throw null; } set { } }
        public System.Uri PayloadUri { get { throw null; } set { } }
    }
    public abstract partial class ReferenceInputDataSource
    {
        protected ReferenceInputDataSource() { }
    }
    public partial class ReferenceInputProperties : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputProperties
    {
        public ReferenceInputProperties() { }
        public Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource Datasource { get { throw null; } set { } }
    }
    public partial class ScalarFunctionProperties : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionProperties
    {
        public ScalarFunctionProperties() { }
    }
    public partial class ScaleStreamingJobContent
    {
        public ScaleStreamingJobContent() { }
        public int? StreamingUnits { get { throw null; } set { } }
    }
    public partial class ServiceBusQueueOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource
    {
        public ServiceBusQueueOutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PropertyColumns { get { throw null; } }
        public string QueueName { get { throw null; } set { } }
        public string ServiceBusNamespace { get { throw null; } set { } }
        public string SharedAccessPolicyKey { get { throw null; } set { } }
        public string SharedAccessPolicyName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SystemPropertyColumns { get { throw null; } }
    }
    public partial class ServiceBusTopicOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource
    {
        public ServiceBusTopicOutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PropertyColumns { get { throw null; } }
        public string ServiceBusNamespace { get { throw null; } set { } }
        public string SharedAccessPolicyKey { get { throw null; } set { } }
        public string SharedAccessPolicyName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SystemPropertyColumns { get { throw null; } }
        public string TopicName { get { throw null; } set { } }
    }
    public partial class SqlDatabaseOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource
    {
        public SqlDatabaseOutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string Database { get { throw null; } set { } }
        public int? MaxBatchCount { get { throw null; } set { } }
        public int? MaxWriterCount { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
    }
    public partial class SqlReferenceInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource
    {
        public SqlReferenceInputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string Database { get { throw null; } set { } }
        public string DeltaSnapshotQuery { get { throw null; } set { } }
        public string FullSnapshotQuery { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public System.TimeSpan? RefreshInterval { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please use RefreshInterval instead.", false)]
        public System.DateTimeOffset? RefreshRate { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.DataRefreshType? RefreshType { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
    }
    public partial class StartStreamingJobContent
    {
        public StartStreamingJobContent() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputStartMode? OutputStartMode { get { throw null; } set { } }
        public System.DateTimeOffset? OutputStartOn { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamAnalyticsAuthenticationMode : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamAnalyticsAuthenticationMode(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode ConnectionString { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode Msi { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode UserToken { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode left, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode left, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StreamAnalyticsClusterJob
    {
        internal StreamAnalyticsClusterJob() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState? JobState { get { throw null; } }
        public int? StreamingUnits { get { throw null; } }
    }
    public partial class StreamAnalyticsClusterProperties
    {
        public StreamAnalyticsClusterProperties() { }
        public int? CapacityAllocated { get { throw null; } }
        public int? CapacityAssigned { get { throw null; } }
        public System.Guid? ClusterId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamAnalyticsClusterProvisioningState : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamAnalyticsClusterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProvisioningState left, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProvisioningState left, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StreamAnalyticsClusterSku
    {
        public StreamAnalyticsClusterSku() { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSkuName? Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamAnalyticsClusterSkuName : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamAnalyticsClusterSkuName(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSkuName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSkuName left, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSkuName left, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StreamAnalyticsCompileQuery
    {
        public StreamAnalyticsCompileQuery(string query, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobType jobType) { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobCompatibilityLevel? CompatibilityLevel { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryFunction> Functions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryInput> Inputs { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobType JobType { get { throw null; } }
        public string Query { get { throw null; } }
    }
    public abstract partial class StreamAnalyticsDataSerialization
    {
        protected StreamAnalyticsDataSerialization() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamAnalyticsDataSerializationEncoding : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerializationEncoding>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamAnalyticsDataSerializationEncoding(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerializationEncoding Utf8 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerializationEncoding other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerializationEncoding left, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerializationEncoding right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerializationEncoding (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerializationEncoding left, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerializationEncoding right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StreamAnalyticsError
    {
        internal StreamAnalyticsError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsErrorDetails> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class StreamAnalyticsErrorDetails
    {
        internal StreamAnalyticsErrorDetails() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public static partial class StreamAnalyticsModelFactory
    {
        public static Azure.ResourceManager.StreamAnalytics.Models.AggregateFunctionProperties AggregateFunctionProperties(Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionInput> inputs = null, string outputDataType = null, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding binding = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.LastOutputEventTimestamp LastOutputEventTimestamp(System.DateTimeOffset? lastOutputEventOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputProperties ReferenceInputProperties(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization serialization = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobDiagnosticCondition> diagnosticsConditions = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.StreamAnalytics.Models.StreamingCompressionType? compressionType = default(Azure.ResourceManager.StreamAnalytics.Models.StreamingCompressionType?), string partitionKey = null, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputWatermarkMode? watermarkMode = default(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputWatermarkMode?), Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource datasource = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.ScalarFunctionProperties ScalarFunctionProperties(Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionInput> inputs = null, string outputDataType = null, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding binding = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData StreamAnalyticsClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSku sku = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProperties properties = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterJob StreamAnalyticsClusterJob(Azure.Core.ResourceIdentifier id = null, int? streamingUnits = default(int?), Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState? jobState = default(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState?)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProperties StreamAnalyticsClusterProperties(System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Guid? clusterId = default(System.Guid?), Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProvisioningState? provisioningState = default(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProvisioningState?), int? capacityAllocated = default(int?), int? capacityAssigned = default(int?)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsError StreamAnalyticsError(string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsErrorDetails> details = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsErrorDetails StreamAnalyticsErrorDetails(string code = null, string target = null, string message = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData StreamAnalyticsPrivateEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateEndpointProperties properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateEndpointProperties StreamAnalyticsPrivateEndpointProperties(System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkServiceConnection> manualPrivateLinkServiceConnections = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkConnectionState StreamAnalyticsPrivateLinkConnectionState(string status = null, string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkServiceConnection StreamAnalyticsPrivateLinkServiceConnection(Azure.Core.ResourceIdentifier privateLinkServiceId = null, System.Collections.Generic.IEnumerable<string> groupIds = null, string requestMessage = null, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkConnectionState privateLinkServiceConnectionState = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationError StreamAnalyticsQueryCompilationError(string message = null, int? startLine = default(int?), int? startColumn = default(int?), int? endLine = default(int?), int? endColumn = default(int?), bool? isGlobal = default(bool?)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationResult StreamAnalyticsQueryCompilationResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationError> errors = null, System.Collections.Generic.IEnumerable<string> warnings = null, System.Collections.Generic.IEnumerable<string> inputs = null, System.Collections.Generic.IEnumerable<string> outputs = null, System.Collections.Generic.IEnumerable<string> functions = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResult StreamAnalyticsQueryTestingResult(string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsErrorDetails> details = null, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResultStatus? status = default(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResultStatus?), System.Uri outputUri = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsResourceTestStatus StreamAnalyticsResourceTestStatus(string status = null, string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResult StreamAnalyticsSampleInputResult(string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsErrorDetails> details = null, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResultStatus? status = default(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResultStatus?), System.Collections.Generic.IEnumerable<string> diagnostics = null, System.Uri eventsDownloadUri = null, System.DateTimeOffset? lastArrivedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubResource StreamAnalyticsSubResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubscriptionQuota StreamAnalyticsSubscriptionQuota(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), int? maxCount = default(int?), int? currentCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResult StreamAnalyticsTestDatasourceResult(string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsErrorDetails> details = null, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResultStatus? status = default(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResultStatus?)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.StreamingJobData StreamingJobData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSkuName? skuName = default(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSkuName?), System.Guid? jobId = default(System.Guid?), string provisioningState = null, string jobState = null, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobType? jobType = default(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobType?), Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputStartMode? outputStartMode = default(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputStartMode?), System.DateTimeOffset? outputStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastOutputEventOn = default(System.DateTimeOffset?), Azure.ResourceManager.StreamAnalytics.Models.EventsOutOfOrderPolicy? eventsOutOfOrderPolicy = default(Azure.ResourceManager.StreamAnalytics.Models.EventsOutOfOrderPolicy?), Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputErrorPolicy? outputErrorPolicy = default(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputErrorPolicy?), int? eventsOutOfOrderMaxDelayInSeconds = default(int?), int? eventsLateArrivalMaxDelayInSeconds = default(int?), Azure.Core.AzureLocation? dataLocalion = default(Azure.Core.AzureLocation?), Azure.ResourceManager.StreamAnalytics.Models.StreamingJobCompatibilityLevel? compatibilityLevel = default(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobCompatibilityLevel?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobInputData> inputs = null, Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData transformation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData> outputs = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData> functions = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.StreamAnalytics.Models.StreamingJobStorageAccount jobStorageAccount = null, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobContentStoragePolicy? contentStoragePolicy = default(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobContentStoragePolicy?), Azure.ResourceManager.StreamAnalytics.Models.StreamingJobExternal externals = null, Azure.Core.ResourceIdentifier clusterId = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobDiagnosticCondition StreamingJobDiagnosticCondition(System.DateTimeOffset? since = default(System.DateTimeOffset?), string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData StreamingJobFunctionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionProperties StreamingJobFunctionProperties(string functionPropertiesType = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionInput> inputs = null, string outputDataType = null, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding binding = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.StreamingJobInputData StreamingJobInputData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputProperties properties = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputProperties StreamingJobInputProperties(string inputPropertiesType = null, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization serialization = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobDiagnosticCondition> diagnosticsConditions = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.StreamAnalytics.Models.StreamingCompressionType? compressionType = default(Azure.ResourceManager.StreamAnalytics.Models.StreamingCompressionType?), string partitionKey = null, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputWatermarkMode? watermarkMode = default(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputWatermarkMode?)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData StreamingJobOutputData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource datasource = null, System.TimeSpan? timeFrame = default(System.TimeSpan?), float? sizeWindow = default(float?), Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization serialization = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobDiagnosticCondition> diagnosticsConditions = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.LastOutputEventTimestamp> lastOutputEventTimestamps = null, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkProperties watermarkSettings = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData StreamingJobTransformationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), int? streamingUnits = default(int?), System.Collections.Generic.IEnumerable<int> validStreamingUnits = null, string query = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamInputProperties StreamInputProperties(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization serialization = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobDiagnosticCondition> diagnosticsConditions = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.StreamAnalytics.Models.StreamingCompressionType? compressionType = default(Azure.ResourceManager.StreamAnalytics.Models.StreamingCompressionType?), string partitionKey = null, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputWatermarkMode? watermarkMode = default(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputWatermarkMode?), Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource datasource = null) { throw null; }
    }
    public partial class StreamAnalyticsPrivateEndpointProperties
    {
        public StreamAnalyticsPrivateEndpointProperties() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkServiceConnection> ManualPrivateLinkServiceConnections { get { throw null; } }
    }
    public partial class StreamAnalyticsPrivateLinkConnectionState
    {
        public StreamAnalyticsPrivateLinkConnectionState() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class StreamAnalyticsPrivateLinkServiceConnection
    {
        public StreamAnalyticsPrivateLinkServiceConnection() { }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkServiceId { get { throw null; } set { } }
        public string RequestMessage { get { throw null; } }
    }
    public partial class StreamAnalyticsQueryCompilationError
    {
        internal StreamAnalyticsQueryCompilationError() { }
        public int? EndColumn { get { throw null; } }
        public int? EndLine { get { throw null; } }
        public bool? IsGlobal { get { throw null; } }
        public string Message { get { throw null; } }
        public int? StartColumn { get { throw null; } }
        public int? StartLine { get { throw null; } }
    }
    public partial class StreamAnalyticsQueryCompilationResult
    {
        internal StreamAnalyticsQueryCompilationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationError> Errors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Functions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Inputs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Outputs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Warnings { get { throw null; } }
    }
    public partial class StreamAnalyticsQueryFunction
    {
        public StreamAnalyticsQueryFunction(string name, string queryFunctionType, string bindingType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionInput> inputs, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionOutput output) { }
        public string BindingType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionInput> Inputs { get { throw null; } }
        public string Name { get { throw null; } }
        public string OutputDataType { get { throw null; } }
        public string QueryFunctionType { get { throw null; } }
    }
    public partial class StreamAnalyticsQueryInput
    {
        public StreamAnalyticsQueryInput(string name, string queryInputType) { }
        public string Name { get { throw null; } }
        public string QueryInputType { get { throw null; } }
    }
    public partial class StreamAnalyticsQueryTestingResult : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsError
    {
        internal StreamAnalyticsQueryTestingResult() { }
        public System.Uri OutputUri { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResultStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamAnalyticsQueryTestingResultStatus : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamAnalyticsQueryTestingResultStatus(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResultStatus CompilerError { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResultStatus RuntimeError { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResultStatus Started { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResultStatus Success { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResultStatus Timeout { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResultStatus UnknownError { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResultStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResultStatus left, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResultStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResultStatus left, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResultStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StreamAnalyticsResourceTestStatus
    {
        internal StreamAnalyticsResourceTestStatus() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class StreamAnalyticsSampleInputContent
    {
        public StreamAnalyticsSampleInputContent() { }
        public string CompatibilityLevel { get { throw null; } set { } }
        public Azure.Core.AzureLocation? DataLocalion { get { throw null; } set { } }
        public System.Uri EventsUri { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.StreamingJobInputData Input { get { throw null; } set { } }
    }
    public partial class StreamAnalyticsSampleInputResult : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsError
    {
        internal StreamAnalyticsSampleInputResult() { }
        public System.Collections.Generic.IReadOnlyList<string> Diagnostics { get { throw null; } }
        public System.Uri EventsDownloadUri { get { throw null; } }
        public System.DateTimeOffset? LastArrivedOn { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResultStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamAnalyticsSampleInputResultStatus : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamAnalyticsSampleInputResultStatus(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResultStatus ErrorConnectingToInput { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResultStatus NoEventsFoundInRange { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResultStatus ReadAllEventsInRange { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResultStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResultStatus left, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResultStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResultStatus left, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResultStatus right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class StreamAnalyticsStorageAccount
    {
        public StreamAnalyticsStorageAccount() { }
        public string AccountKey { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
    }
    public partial class StreamAnalyticsSubResource
    {
        public StreamAnalyticsSubResource() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
    }
    public partial class StreamAnalyticsSubscriptionQuota : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubResource
    {
        public StreamAnalyticsSubscriptionQuota() { }
        public int? CurrentCount { get { throw null; } }
        public int? MaxCount { get { throw null; } }
    }
    public partial class StreamAnalyticsTestContent
    {
        public StreamAnalyticsTestContent(Azure.ResourceManager.StreamAnalytics.StreamingJobInputData input) { }
        public Azure.ResourceManager.StreamAnalytics.StreamingJobInputData Input { get { throw null; } }
    }
    public partial class StreamAnalyticsTestDatasourceResult : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsError
    {
        internal StreamAnalyticsTestDatasourceResult() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResultStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamAnalyticsTestDatasourceResultStatus : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamAnalyticsTestDatasourceResultStatus(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResultStatus TestFailed { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResultStatus TestSucceeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResultStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResultStatus left, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResultStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResultStatus left, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResultStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StreamAnalyticsTestOutput
    {
        public StreamAnalyticsTestOutput(Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData output) { }
        public Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData Output { get { throw null; } }
    }
    public partial class StreamAnalyticsTestQuery
    {
        public StreamAnalyticsTestQuery(Azure.ResourceManager.StreamAnalytics.StreamingJobData streamingJob) { }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.StreamingJobData StreamingJob { get { throw null; } }
        public System.Uri WriteUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamingCompressionType : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.StreamingCompressionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamingCompressionType(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingCompressionType Deflate { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingCompressionType Gzip { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingCompressionType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.StreamingCompressionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.StreamingCompressionType left, Azure.ResourceManager.StreamAnalytics.Models.StreamingCompressionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.StreamingCompressionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.StreamingCompressionType left, Azure.ResourceManager.StreamAnalytics.Models.StreamingCompressionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamingJobCompatibilityLevel : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobCompatibilityLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamingJobCompatibilityLevel(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobCompatibilityLevel Level1_0 { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobCompatibilityLevel Level1_2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobCompatibilityLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobCompatibilityLevel left, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobCompatibilityLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.StreamingJobCompatibilityLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobCompatibilityLevel left, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobCompatibilityLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamingJobContentStoragePolicy : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobContentStoragePolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamingJobContentStoragePolicy(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobContentStoragePolicy JobStorageAccount { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobContentStoragePolicy SystemAccount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobContentStoragePolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobContentStoragePolicy left, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobContentStoragePolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.StreamingJobContentStoragePolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobContentStoragePolicy left, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobContentStoragePolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StreamingJobDiagnosticCondition
    {
        internal StreamingJobDiagnosticCondition() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Since { get { throw null; } }
    }
    public partial class StreamingJobExternal
    {
        public StreamingJobExternal() { }
        public string Container { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobRefreshConfiguration RefreshConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsStorageAccount StorageAccount { get { throw null; } set { } }
    }
    public abstract partial class StreamingJobFunctionBinding
    {
        protected StreamingJobFunctionBinding() { }
    }
    public partial class StreamingJobFunctionInput
    {
        public StreamingJobFunctionInput() { }
        public string DataType { get { throw null; } set { } }
        public bool? IsConfigurationParameter { get { throw null; } set { } }
    }
    public partial class StreamingJobFunctionOutput
    {
        public StreamingJobFunctionOutput() { }
        public string DataType { get { throw null; } set { } }
    }
    public abstract partial class StreamingJobFunctionProperties
    {
        protected StreamingJobFunctionProperties() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding Binding { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionInput> Inputs { get { throw null; } }
        public string OutputDataType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamingJobFunctionUdfType : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUdfType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamingJobFunctionUdfType(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUdfType Scalar { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUdfType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUdfType left, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUdfType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUdfType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUdfType left, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUdfType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamingJobFunctionUpdateMode : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUpdateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamingJobFunctionUpdateMode(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUpdateMode Refreshable { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUpdateMode Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUpdateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUpdateMode left, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUpdateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUpdateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUpdateMode left, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUpdateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class StreamingJobInputProperties
    {
        protected StreamingJobInputProperties() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingCompressionType? CompressionType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobDiagnosticCondition> DiagnosticsConditions { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string PartitionKey { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization Serialization { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputWatermarkMode? WatermarkMode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamingJobInputWatermarkMode : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputWatermarkMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamingJobInputWatermarkMode(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputWatermarkMode None { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputWatermarkMode ReadWatermark { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputWatermarkMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputWatermarkMode left, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputWatermarkMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputWatermarkMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputWatermarkMode left, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputWatermarkMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class StreamingJobOutputDataSource
    {
        protected StreamingJobOutputDataSource() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamingJobOutputErrorPolicy : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputErrorPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamingJobOutputErrorPolicy(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputErrorPolicy Drop { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputErrorPolicy Stop { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputErrorPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputErrorPolicy left, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputErrorPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputErrorPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputErrorPolicy left, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputErrorPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamingJobOutputStartMode : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputStartMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamingJobOutputStartMode(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputStartMode CustomTime { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputStartMode JobStartTime { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputStartMode LastOutputEventTime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputStartMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputStartMode left, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputStartMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputStartMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputStartMode left, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputStartMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamingJobOutputWatermarkMode : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamingJobOutputWatermarkMode(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkMode None { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkMode SendCurrentPartitionWatermark { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkMode SendLowestWatermarkAcrossPartitions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkMode left, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkMode left, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StreamingJobOutputWatermarkProperties
    {
        public StreamingJobOutputWatermarkProperties() { }
        public string MaxWatermarkDifferenceAcrossPartitions { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkMode? WatermarkMode { get { throw null; } set { } }
    }
    public partial class StreamingJobRefreshConfiguration
    {
        public StreamingJobRefreshConfiguration() { }
        public string DateFormat { get { throw null; } set { } }
        public string PathPattern { get { throw null; } set { } }
        public string RefreshInterval { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.DataRefreshType? RefreshType { get { throw null; } set { } }
        public string TimeFormat { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamingJobState : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamingJobState(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState Created { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState Degraded { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState Deleting { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState Failed { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState Restarting { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState Running { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState Scaling { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState Starting { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState Stopped { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState left, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState left, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StreamingJobStorageAccount : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsStorageAccount
    {
        public StreamingJobStorageAccount() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamingJobType : System.IEquatable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamingJobType(string value) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobType Cloud { get { throw null; } }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamingJobType Edge { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobType left, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StreamAnalytics.Models.StreamingJobType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobType left, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class StreamInputDataSource
    {
        protected StreamInputDataSource() { }
    }
    public partial class StreamInputProperties : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputProperties
    {
        public StreamInputProperties() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource Datasource { get { throw null; } set { } }
    }
    public partial class SynapseOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource
    {
        public SynapseOutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string Database { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
    }
    public partial class TableOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource
    {
        public TableOutputDataSource() { }
        public string AccountKey { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public int? BatchSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ColumnsToRemove { get { throw null; } }
        public string PartitionKey { get { throw null; } set { } }
        public string RowKey { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
    }
}
